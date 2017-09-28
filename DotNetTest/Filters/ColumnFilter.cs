using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetTest.Filters
{
    class ColumnFilter
    {
        Dictionary<string, Func<bool>> Visibility { get; } = new Dictionary<string, Func<bool>>();
        public ColumnFilter ConfigureVisibility(string columnName, Func<bool> configuration)
        {
            Visibility.Add(columnName, configuration);
            return this;
        }

        public string[] Build()
        {
            return Visibility.Where(w => !w.Value()).Select(s => s.Key).ToArray();
        }
    }
}
