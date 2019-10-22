using System;
using System.IO;
using System.Text;
using PConfigParser.ParsedObjects;
using PConfigParser.Parsers;

namespace PConfigParser
{
    public class Parser
    {
        public Config Parse(string path)
        {
            var configBuilder = new Config.Builder();

            using (var fs = File.OpenRead(path))
            using (var sr = new StreamReader(fs, Encoding.UTF8))
            {
                var validSection = false;
                BaseSection.Builder currentSectionBuilder = null;
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    if (line.Length == 0) continue;

                    var lineType = CheckLineType(line);
                    if (lineType == LineType.COMMENT) continue;

                    if (lineType == LineType.SECTION)
                    {
                        var sectionParser = new SectionParser();
                        validSection = sectionParser.TryParse(line, out var sectionBuilder);
                        if (validSection)
                        {
                            sectionBuilder.AddToConfigBuilder(configBuilder);
                            currentSectionBuilder = sectionBuilder;
                        }
                    }
                    else if (lineType == LineType.PARAMETER)
                    {
                        if (validSection)
                        {
                            var kvParser = new KeyValueParser();
                            if (kvParser.TryParse(line, out var kv))
                            {
                                currentSectionBuilder.SetValue(kv);
                            }
                        }
                    }
                }
            }

            return configBuilder.Build();
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
    }
}
