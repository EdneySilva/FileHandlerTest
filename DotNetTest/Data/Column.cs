namespace DotNetTest.Data
{
    public class Column
    {
        public Column(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
        public short EndIndex { get; internal set; }
        public int Index { get; internal set; }
        public int StartIndex { get; internal set; }
    }
}