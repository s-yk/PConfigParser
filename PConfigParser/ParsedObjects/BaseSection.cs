using System;
namespace PConfigParser.ParsedObjects
{
    public class BaseSection : ParsedObject
    {
        public string Name { get; private set; }

        public int No { get; private set; }

        public BaseSection(string name) : this(name, 0) { }

        public BaseSection(string name, int no)
        {
            this.Name = name;
            this.No = no;
        }
    }
}
