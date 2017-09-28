using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace DotNetTest.Filters
{
    class FilterAge
    {
        private Dictionary<string, Func<DataRow, bool>> SimpleExpressions { get; } = new Dictionary<string, Func<DataRow, bool>>();

        private string ColumnAge { get; set; }

        private int AgeComper { get; set; }

        private string CurrentExpression { get; set; }

        public FilterAge()
        {
            SimpleExpressions.Add("default", (row) => true);
            SimpleExpressions.Add("<", (row) => GetAge(ColumnAge, row) < AgeComper);
            SimpleExpressions.Add(">", (row) => GetAge(ColumnAge, row) > AgeComper);
            SimpleExpressions.Add("<=", (row) => GetAge(ColumnAge, row) <= AgeComper);
            SimpleExpressions.Add(">=", (row) => GetAge(ColumnAge, row) >= AgeComper);
            SimpleExpressions.Add("=", (row) =>  GetAge(ColumnAge, row).Equals(AgeComper));
            SimpleExpressions.Add("<>", (row) => !GetAge(ColumnAge, row).Equals(AgeComper));
        }

        public FilterAge Column(string column)
        {
            ColumnAge = column;
            return this;
        }

        public FilterAge Is(string expression)
        {
            CurrentExpression = expression;
            return this;
        }

        public FilterAge Than(int age)
        {
            AgeComper = age;
            return this;
        }

        public Func<DataRow, bool> Build()
        {
            var expression = CurrentExpression;
            CurrentExpression = null;
            if (expression == null || !SimpleExpressions.ContainsKey(expression))
                return SimpleExpressions["default"];
            return SimpleExpressions[expression];
        }

        private int GetAge(string column, DataRow row)
        {
            var year = DateTime.Now;
            var bornDate = DateTime.Parse(row[column].ToString());
            return year.Subtract(TimeSpan.FromTicks(bornDate.Ticks)).Year;
        }
    }
}
