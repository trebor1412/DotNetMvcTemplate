using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace DotNet.Service
{
    public class MapperConfigurationFactory
    {
        public static MapperConfiguration CreateConfiguration(Assembly assembly)
        {
            var profileType = typeof(Profile);
            var profiles = assembly.ExportedTypes
                                   .Where(p => profileType.IsAssignableFrom(p))
                                   .Select(p => Activator.CreateInstance(p))
                                   .Cast<Profile>();

            var configuration = new MapperConfiguration(config =>
            {
                foreach (var profile in profiles)
                {
                    config.AddProfile(profile);
                }

                config.CreateMissingTypeMaps = false;
            });

            return configuration;
        }
    }
}