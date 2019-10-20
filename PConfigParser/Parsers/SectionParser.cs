using System;
using System.Text.RegularExpressions;
using PConfigParser.ParsedObjects;

namespace PConfigParser.Parsers
{
    public class SectionParser : ILineParser<BaseSection>
    {
        private const string pattern = @"(?<name>[a-zA-Z]+)(?<no>\d+)?:";
        private const string commentPattern = @"/\*.*?\/";
        private static readonly Regex regex = new Regex(pattern, RegexOptions.Compiled);
        private static readonly Regex comRegex = new Regex(commentPattern, RegexOptions.Compiled); 

        public bool TryParse(string line, out BaseSection parsedObject)
        {
            parsedObject = null;
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
                    parsedObject = new Section(name);
                    return true;
                case "sec":
                    parsedObject = new Sec(name, no);
                    return true;
                default:
                    return false;
            }
        }
    }
}
