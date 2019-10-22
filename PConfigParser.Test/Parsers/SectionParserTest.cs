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
            Assert.IsTrue(parser.TryParse("section:", out var sectionBuilder));
            Assert.IsInstanceOf<Section.Builder>(sectionBuilder);
            Assert.AreEqual(sectionBuilder.Name, "section");
            Assert.AreEqual(sectionBuilder.No, 0);
            var section = sectionBuilder.Build();
            Assert.IsInstanceOf<Section>(section);

            Assert.IsTrue(parser.TryParse("sec1:", out sectionBuilder));
            Assert.IsInstanceOf<Sec.Builder>(sectionBuilder);
            Assert.AreEqual(sectionBuilder.Name, "sec");
            Assert.AreEqual(sectionBuilder.No, 1);
            section = sectionBuilder.Build();
            Assert.IsInstanceOf<Sec>(section);

            Assert.IsTrue(parser.TryParse("sec23:", out sectionBuilder));
            Assert.IsInstanceOf<Sec.Builder>(sectionBuilder);
            Assert.AreEqual(sectionBuilder.Name, "sec");
            Assert.AreEqual(sectionBuilder.No, 23);
            section = sectionBuilder.Build();
            Assert.IsInstanceOf<Sec>(section);
        }
    }
}
