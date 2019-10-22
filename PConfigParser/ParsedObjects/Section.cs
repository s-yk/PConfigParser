using System;
namespace PConfigParser.ParsedObjects
{
    public class Section : BaseSection
    {
        public string Key1 { get; private set; }
        public string Key2 { get; private set; }
        public string Key3 { get; private set; }

        public Section(string name) : base(name) { }

        public class SectionBuilder : Builder
        {
            public string Key1 { get; set; }
            public string Key2 { get; set; }
            public string Key3 { get; set; }

            public override void AddToConfigBuilder(Config.Builder configBuilder)
            {
                configBuilder.SectionBuilders.Add(this);
            }

            public override BaseSection Build()
            {
                return new Section(this.Name)
                {
                    Key1 = this.Key1,
                    Key2 = this.Key2,
                    Key3 = this.Key3,
                };
            }

            public override void SetValue(KeyValue kv)
            {
                switch (kv.Key)
                {
                    case "key1":
                        this.Key1 = kv.Value;
                        break;
                    case "key2":
                        this.Key2 = kv.Value;
                        break;
                    case "key3":
                        this.Key3 = kv.Value;
                        break;
                }
            }
        }
    }
}
