using DotNetTest.Parsers;
using DotNetTest.Parsers.Validators;
using DotNetTest.Validators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetTest.IO
{
    internal class FileHandlerConfiguration
    {
        SettingCollection Settings { get; } = new SettingCollection();
        

        public FileHandlerConfiguration()
        {
        }
        
        public FileHandlerConfiguration UseParser<T>() 
            where T : IParser
        {
            Settings.AddIfNotExists<IParser>(() =>
            {
                return (T)typeof(T).GetConstructor(Type.EmptyTypes).Invoke(null);
            });
            return this;
        }

        public FileHandlerConfiguration AddValidator<T>(params object[] parameters)
            where T : IValidator
        {
            Settings.Add<IValidator>(() =>
            {
                int contador = 0;
                
                return (T)typeof(T).GetConstructors()
                    .Where(w => 
                        w.GetParameters().Length.Equals(parameters.Length) && 
                        parameters.All(a => a.GetType() == w.GetParameters()[contador++].ParameterType)
                     ).FirstOrDefault()?
                     .Invoke(parameters);
            });
            return this;
        }

        public FileHandlerConfiguration AddParsing<T>()
            where T : IParsingValidator
        {
            Settings.Add<IParsingValidator>(() =>
            {
                return (T)typeof(T).GetConstructor(Type.EmptyTypes).Invoke(null);
            });
            return this;
        }

        public FileHandlerConfiguration AddParsing<T>(object[] parameters)
            where T : IParsingValidator
        {
            Settings.Add<IParsingValidator>(() =>
            {
                int contador = 0;

                return (T)typeof(T).GetConstructors()
                    .Where(w =>
                        (w.GetParameters().Length.Equals(1) && w.GetParameters()[0].ParameterType.IsArray) || 
                        (
                            w.GetParameters().Length.Equals(parameters.Length) &&
                            parameters.All(a => a.GetType() == w.GetParameters()[contador++].ParameterType)
                        )
                     ).FirstOrDefault()?
                     .Invoke(parameters);
            });
            return this;
        }

        public FileHandlerConfiguration AddValidator<T>()
            where T : IValidator
        {
            Settings.Add<IValidator>(() =>
            {
                return (T)typeof(T).GetConstructor(Type.EmptyTypes).Invoke(null);
            });
            return this;
        }

        public IFileHandler Build()
        {        
            FileHandler handler = new FileHandler(Settings);

            return handler;
        }
    }
}