using System;
using System.IO;
using System.Text;

namespace ConfigParser
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
                    Console.WriteLine(line);
                }
            }
        }
    }
}
