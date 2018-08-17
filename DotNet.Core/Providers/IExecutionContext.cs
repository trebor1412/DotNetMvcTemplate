using AutoMapper;
using System;
using System.Collections.Generic;

namespace DotNet.Core
{
    public interface IExecutionContext
    {
        DateTime Now { get; }

        string AppRootPath { get; }

        IMapper Mapper { get; }

        MapperConfiguration MapperConfiguration { get; }

        /// <summary>
        /// 自IoC container取得指定型別實體
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        object Resolve(Type type);

        /// <summary>
        /// 自IoC container取得指定型別實體集合
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        IEnumerable<object> Resolves(Type type);

        /// <summary>
        /// 自IoC container取得實做指定介面之型別實體
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Resolve<T>();

        /// <summary>
        /// 自IoC container取得實做指定介面之型別實體集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IEnumerable<T> Resolves<T>();
    }
}