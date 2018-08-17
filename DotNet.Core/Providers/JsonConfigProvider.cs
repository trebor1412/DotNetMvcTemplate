using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DotNet.Core
{
    public class JsonConfigProvider : IJsonConfigProvider
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;
        private readonly string _configFileName = "Config.json";
        private readonly string _configNameSuffix = "JsonConfig";
        private readonly IExecutionContext _executionContext;

        public JsonConfigProvider(IExecutionContext executionContext)
        {
            this._jsonSerializerSettings = new JsonSerializerSettings
            {
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
                ContractResolver = new ContractResolver(),
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            this._executionContext = executionContext;
        }

        private string jsonConfigFilePath => $"{_executionContext.AppRootPath}{_configFileName}";

        private bool hasJsonConfig => File.Exists(jsonConfigFilePath);

        private string jsonConfigText => hasJsonConfig ? File.ReadAllText(jsonConfigFilePath) : "{}";

        public T Load<T>() where T : class, new()
        {
            return Load(typeof(T)) as T;
        }

        public T LoadSection<T>() where T : class, new()
        {
            return LoadSection(typeof(T)) as T;
        }

        public object Load(Type type)
        {
            return JsonConvert.DeserializeObject(jsonConfigText, type, _jsonSerializerSettings);
        }

        public object LoadSection(Type type)
        {
            var section = type.Name.Replace(_configNameSuffix, string.Empty);
            var settingsData = JsonConvert.DeserializeObject<dynamic>(jsonConfigText, _jsonSerializerSettings);
            var settingsSection = settingsData[section];

            return settingsSection == null
                ? Activator.CreateInstance(type)
                : JsonConvert.DeserializeObject(JsonConvert.SerializeObject(settingsSection), type,
                    _jsonSerializerSettings);
        }

        private class ContractResolver : DefaultContractResolver
        {
            protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
            {
                var bindingFlags = (BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                var props = type.GetProperties(bindingFlags)
                                .Select(p => CreateProperty(p, memberSerialization))
                                .Union(type.GetFields(bindingFlags)
                                .Select(f => CreateProperty(f, memberSerialization)))
                                .ToList();

                props.ForEach(p =>
                {
                    p.Writable = true;
                    p.Readable = true;
                });

                return props;
            }
        }
    }
}