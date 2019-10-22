using System;
namespace PConfigParser.ParsedObjects
{
    public class Sec : BaseSection
    {
        public string Key11 { get; private set; }
        public string Key22 { get; private set; }
        public string Key33 { get; private set; }

        public Sec(string name, int no) : base(name, no) { }

        public class SecBuilder : Builder
        {
            public string Key11 { get; set; }
            public string Key22 { get; set; }
            public string Key33 { get; set; }

            public override void AddToConfigBuilder(Config.Builder configBuilder)
            {
                configBuilder.SecBuilders.Add(this);
            }

            public override BaseSection Build()
            {
                return new Sec(this.Name, this.No)
                {
                    Key11 = this.Key11,
                    Key22 = this.Key22,
                    Key33 = this.Key33,
                };
            }

            public override void SetValue(KeyValue kv)
            {
                switch (kv.Key)
                {
                    case "key11":
                        this.Key11 = kv.Value;
                        break;
                    case "key22":
                        this.Key22 = kv.Value;
                        break;
                    case "key33":
                        this.Key33 = kv.Value;
                        break;
                }
            }
        }
    }
}
