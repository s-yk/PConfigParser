using System;
using System.Collections.Generic;

namespace PConfigParser.ParsedObjects
{
    public abstract class BaseSection
    {
        public string Name { get; private set; }

        public int No { get; private set; }

        public BaseSection(string name) : this(name, 0) { }

        public BaseSection(string name, int no)
        {
            this.Name = name;
            this.No = no;
        }

        public abstract class Builder
        {
            public string Name { get; set; }
            public int No { get; set; }

            public abstract BaseSection Build();
            public abstract void SetValue(KeyValue kv);
            public abstract void AddToConfigBuilder(Config.Builder configBuilder);
        }
    }
}
