using System;
using PConfigParser.ParsedObjects;

namespace PConfigParser.Parsers
{
    public interface ILineParser<T> where T : ParsedObject
    {
        bool TryParse(string line, out T parsedObject);
    }
}
