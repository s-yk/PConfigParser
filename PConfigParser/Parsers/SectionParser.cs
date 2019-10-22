using System;
using System.Text.RegularExpressions;
using PConfigParser.ParsedObjects;

namespace PConfigParser.Parsers
{
    public class SectionParser
    {
        private const string pattern = @"(?<name>[a-zA-Z]+)(?<no>\d+)?:";
        private const string commentPattern = @"/\*.*?\/";
        private static readonly Regex regex = new Regex(pattern, RegexOptions.Compiled);
        private static readonly Regex comRegex = new Regex(commentPattern, RegexOptions.Compiled); 

        public bool TryParse(string line, out BaseSection.Builder sectionBuilder)
        {
            sectionBuilder = null;
            var body =  comRegex.Replace(line.Trim(), string.Empty);
            var match = regex.Match(body);
            if (!match.Success)
            {
                return false;
            }

            var name = match.Groups["name"].Value.Trim();
            if (!int.TryParse(match.Groups["no"].Value.Trim(), out var no))
            {
                no = 0;
            }

            switch(name)
            {
                case "section":
                    sectionBuilder = new Section.SectionBuilder { Name = name, };
                    return true;
                case "sec":
                    sectionBuilder = new Sec.SecBuilder { Name = name, No = no };
                    return true;
                default:
                    return false;
            }
        }
    }
}
