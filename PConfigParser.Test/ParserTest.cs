using System.IO;
using NUnit.Framework;

namespace PConfigParser
{
    public class ParserTest
    {
        private Parser parser;

        [SetUp]
        public void Setup()
        {
            parser = new Parser();
        }

        [Test]
        public void Parseメソッドを使用してファイルを読み込むことができる()
        {
            var config = parser.Parse("resources/test1.txt");
            Assert.IsNotNull(config);

            Assert.IsNotNull(config.Section);
            Assert.AreEqual("section", config.Section.Name);
            Assert.AreEqual(0, config.Section.No);
            Assert.AreEqual("value1", config.Section.Key1);
            Assert.AreEqual("value2", config.Section.Key2);
            Assert.AreEqual("value3-1 value3-2", config.Section.Key3);

            Assert.IsNotNull(config.SecList);
            Assert.AreEqual(2, config.SecList.Count);
            Assert.AreEqual("value1-11", config.SecList[0].Key11);
            Assert.AreEqual("value1-22", config.SecList[0].Key22);
            Assert.AreEqual("  value1-33-1 value1-33-2", config.SecList[0].Key33);
            Assert.AreEqual("value2-11", config.SecList[1].Key11);
            Assert.AreEqual("value2-22", config.SecList[1].Key22);
            Assert.AreEqual("value2-33-1 value2-33-2  ", config.SecList[1].Key33);
        }

        [Test]
        public void ファイルが存在しない場合はFileNotFoundExceptionをスローする()
        {
            Assert.Throws<FileNotFoundException>(() => parser.Parse("resources/test1.txt_"));
        }
    }
}
