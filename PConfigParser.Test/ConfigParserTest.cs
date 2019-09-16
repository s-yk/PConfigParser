using System.IO;
using NUnit.Framework;

namespace ConfigParser
{
    public class ConfigParserTest
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
            parser.Parse("resources/test1.txt");
        }

        [Test]
        public void ファイルが存在しない場合はFileNotFoundExceptionをスローする()
        {
            Assert.Throws<FileNotFoundException>(() => parser.Parse("resources/test1.txt_"));
        }
    }
}