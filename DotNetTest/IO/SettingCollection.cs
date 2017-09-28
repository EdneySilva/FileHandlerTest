using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DotNetTest.IO
{
    public class SettingCollection
    {
        Dictionary<string, List<Func<object>>> Settings { get; } = new Dictionary<string, List<Func<object>>>();

        public bool HasSetting(string key)
        {
            return Settings.ContainsKey(key);
        }

        public void Add<T>(string key, Func<T> factory)
        {
            if(!Settings.ContainsKey(key))
                Settings.Add(key, new List<Func<object>>());
            Settings[key].Add(() => factory());
        }

        public void Add<T>(Func<T> factory)
        {
            var type = typeof(T);
            if (!Settings.ContainsKey(type.Name))
                Settings.Add(type.Name, new List<Func<object>>());
            Settings[type.Name].Add(() => factory());
        }

        public void AddIfNotExists<T>(string key, Func<T> factory)
        {
            if (!HasSetting(key))
                Add(key, factory);
        }

        public void AddIfNotExists<T>(Func<T> factory)
        {
            var type = typeof(T);
            if (!HasSetting(type.Name))
                Add(type.Name, factory);
        }
        
        public T Get<T>()
        {
            var type = typeof(T);
            if (
                (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>)) || 
                typeof(T).GetInterfaces().Any(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            ) {
                var method = this.GetType().GetMethod("GetAll", BindingFlags.NonPublic | BindingFlags.Instance);
                method = method.MakeGenericMethod(type.GetGenericArguments());
                return (T)(object)method.Invoke(this, null);                
            }

            return (T)Settings.Where(w => w.Key == typeof(T).Name).SelectMany(s => s.Value).First().Invoke();
        }

        IEnumerable<T> GetAll<T>()
        {
            return Settings.Where(w => w.Key == typeof(T).Name).SelectMany(s => s.Value).Select(s => (T)s()).ToArray();
        }
    }
}