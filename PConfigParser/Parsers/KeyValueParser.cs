using System;
using System.Text.RegularExpressions;
using PConfigParser.ParsedObjects;

namespace PConfigParser.Parsers
{
    public class KeyValueParser
    {
        private const string pattern = @"(?<key>.+?)=(?<value>.+)";
        private const string commentPattern = @"/\*.*?\*/";
        private const string quoteValuePattern = @"^""(.+?)""";
        private static readonly Regex regex = new Regex(pattern, RegexOptions.Compiled);
        private static readonly Regex comRegex = new Regex(commentPattern, RegexOptions.Compiled);
        private static readonly Regex quoteRegex = new Regex(quoteValuePattern, RegexOptions.Compiled);

        public bool TryParse(string line, out KeyValue parsedObject)
        {
            parsedObject = null;
            var body = comRegex.Replace(line.Trim(' ', '\t'), string.Empty);
            var match = regex.Match(body);
            if (!match.Success) return false;

            var value = match.Groups["value"].Value.Trim(' ');
            if (value.StartsWith("\"", StringComparison.Ordinal))
            {
                var quoteMatch = quoteRegex.Match(value);
                if (quoteMatch.Success)
                {
                    value = quoteMatch.Groups[1].Value;
                }
            }

            parsedObject = new KeyValue(match.Groups["key"].Value.Trim(' '), value);
            return true;
        }
    }
}
