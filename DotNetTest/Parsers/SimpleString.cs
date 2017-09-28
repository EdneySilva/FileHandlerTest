using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetTest.Parsers
{
    struct SimpleString
    {
        const string SPECIAL_STRING = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";
        const string REGULAR_STRING = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc";
        string Value { get; }
        private char[] Replacer { get; }
        public SimpleString(string value)
        {
            Value = value;
            Replacer = Value.ToArray();
        }

        public void ParseText(Func<int, char, bool> roles)
        {
            var value = Value;
            var simpleString = this;
            System.Threading.Tasks.Parallel.For(0, value.Length, (i) =>
            {
                var item = SPECIAL_STRING.IndexOf(value[i]);
                if (item >= 0)
                {
                    simpleString.Replace(i, REGULAR_STRING[item]);
                    return;
                }
                if(!roles(i, value[i]))
                    simpleString.Replace(i, '\0');
            });

        }

        public void Replace(int index, char value)
        {
            Replacer[index] = value;
        }

        public static implicit operator string(SimpleString simpleString)
        {
            return new string(simpleString.Replacer.Where(w => w != '\0').ToArray());
        }
    }

}
