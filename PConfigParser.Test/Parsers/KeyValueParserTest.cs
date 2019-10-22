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
            Assert.AreEqual("key1", keyValue.Key);
            Assert.AreEqual("value1", keyValue.Value);

            Assert.IsTrue(parser.TryParse("  key2=value2", out keyValue));
            Assert.AreEqual("key2", keyValue.Key);
            Assert.AreEqual("value2", keyValue.Value);

            Assert.IsTrue(parser.TryParse("\tkey3=value3", out keyValue));
            Assert.AreEqual("key3", keyValue.Key);
            Assert.AreEqual("value3", keyValue.Value);

            Assert.IsTrue(parser.TryParse("key4=value4     /* comment  */", out keyValue));
            Assert.AreEqual("key4", keyValue.Key);
            Assert.AreEqual("value4", keyValue.Value);

            Assert.IsTrue(parser.TryParse("key5=\"  value5   \"", out keyValue));
            Assert.AreEqual("key5", keyValue.Key);
            Assert.AreEqual("  value5   ", keyValue.Value);

            Assert.IsTrue(parser.TryParse("key6=\"  value6   ", out keyValue));
            Assert.AreEqual("key6", keyValue.Key);
            Assert.AreEqual("\"  value6", keyValue.Value);
        }
    }
}
