using System;
using System.Text.RegularExpressions;
using PConfigParser.ParsedObjects;

namespace PConfigParser.Parsers
{
    public class KeyValueParser : ILineParser<KeyValue>
    {
        private const string pattern = @"(?<key>.+?)=(?<value>.+)";
        private const string commentPattern = @"/\*.*?\/";
        private static readonly Regex regex = new Regex(pattern, RegexOptions.Compiled);
        private static readonly Regex comRegex = new Regex(commentPattern, RegexOptions.Compiled);

        public bool TryParse(string line, out KeyValue parsedObject)
        {
            parsedObject = null;
            var body = comRegex.Replace(line.Trim(), string.Empty);
            var match = regex.Match(body);
            if (!match.Success)
            {
                return false;
            }

            parsedObject = new KeyValue(match.Groups["key"].Value.Trim(), match.Groups["value"].Value.Trim());
            return true;
        }
    }
}
