using NUnit.Framework;
using PConfigParser.ParsedObjects;

namespace PConfigParser.Parsers
{
    public class SectionParserTest
    {
        private SectionParser parser;

        [SetUp]
        public void SetUp()
        {
            parser = new SectionParser();
        }

        [Test]
        public void セクション文字列からオブジェクトを生成する()
        {
            Assert.IsTrue(parser.TryParse("section:", out var section));
            Assert.IsInstanceOf<Section>(section);
            Assert.AreEqual(section.Name, "section");
            Assert.AreEqual(section.No, 0);

            Assert.IsTrue(parser.TryParse("sec1:", out section));
            Assert.IsInstanceOf<Sec>(section);
            Assert.AreEqual(section.Name, "sec");
            Assert.AreEqual(section.No, 1);

            Assert.IsTrue(parser.TryParse("sec23:", out section));
            Assert.IsInstanceOf<Sec>(section);
            Assert.AreEqual(section.Name, "sec");
            Assert.AreEqual(section.No, 23);
        }
    }
}
