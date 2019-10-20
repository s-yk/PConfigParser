using System;
using System.IO;
using System.Text;
using PConfigParser;
using PConfigParser.ParsedObjects;
using PConfigParser.Parsers;

namespace PConfigParser
{
    public class Parser
    {
        public void Parse(string path)
        {
            using (var fs = File.OpenRead(path))
            using (var sr = new StreamReader(fs, Encoding.UTF8))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    if (line.Length == 0) continue;

                    var lineType = CheckLineType(line);
                    if (lineType == LineType.COMMENT) continue;

                    var parser = createParser(lineType);
                    if (!parser.TryParse(line, out var parsedObject)) continue;
                }
            }
        }

        private LineType CheckLineType(string lineValue)
        {
            var c = lineValue[0];
            if (c == 0x20 || c == 0x09)
            {
                return LineType.PARAMETER;
            }

            if (lineValue.StartsWith("/*", StringComparison.Ordinal))
            {
                return LineType.COMMENT;
            }

            return LineType.SECTION;
        }

        private ILineParser<ParsedObject> createParser(LineType lineType)
        {
            switch(lineType)
            {
                case LineType.SECTION:
                    return new SectionParser() as ILineParser<ParsedObject>;
                case LineType.PARAMETER:
                    return new KeyValueParser() as ILineParser<ParsedObject>;
                default:
                    return new SectionParser() as ILineParser<ParsedObject>;
            }
        }
    }
}
