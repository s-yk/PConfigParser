using System;
using System.Linq;
using System.Collections.Generic;
using PConfigParser.ParsedObjects;

namespace PConfigParser
{
    public class Config
    {
        public IReadOnlyList<Sec> SecList { get; private set; }
        public Section Section { get; private set; }

        public class Builder
        {
            public List<Sec.Builder> SecBuilders { get; private set; }
            public List<Section.Builder> SectionBuilders { get; private set; }

            public Builder()
            {
                this.SecBuilders = new List<Sec.Builder>();
                this.SectionBuilders = new List<Section.Builder>();
            }

            public Config Build()
            {
                return new Config()
                {
                    SecList = this.SecBuilders.Select(builder => builder.Build() as Sec).OrderBy(sec => sec.No).ToList().AsReadOnly(),
                    Section = this.SectionBuilders.Select(builder => builder.Build() as Section).ToList()[0],
                };
            }
        }
    }
}
