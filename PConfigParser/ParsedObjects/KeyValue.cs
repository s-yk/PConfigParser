using System;
namespace PConfigParser.ParsedObjects
{
    public class KeyValue : ParsedObject
    {
        public string Key { get; private set; }
        public string Value { get; private set; }

        public KeyValue(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
}
