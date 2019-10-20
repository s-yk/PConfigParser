using System;
using NUnit.Framework;

namespace PConfigParser.Parsers
{
    public class KeyValueParserTest
    {
        private KeyValueParser parser;

        [SetUp]
        public void SetUp()
        {
            parser = new KeyValueParser();
        }

        [Test]
        public void KeyValue文字列からオブジェクトを生成する()
        {
            Assert.IsTrue(parser.TryParse("key1=value1", out var keyValue));
            Assert.AreEqual(keyValue.Key, "key1");
            Assert.AreEqual(keyValue.Value, "value1");

            Assert.IsTrue(parser.TryParse("  key2=value2", out keyValue));
            Assert.AreEqual(keyValue.Key, "key2");
            Assert.AreEqual(keyValue.Value, "value2");

            Assert.IsTrue(parser.TryParse("\tkey3=value3", out keyValue));
            Assert.AreEqual(keyValue.Key, "key3");
            Assert.AreEqual(keyValue.Value, "value3");

            Assert.IsTrue(parser.TryParse("key4=value4     /* comment  */", out keyValue));
            Assert.AreEqual(keyValue.Key, "key4");
            Assert.AreEqual(keyValue.Value, "value4");
        }
    }
}
