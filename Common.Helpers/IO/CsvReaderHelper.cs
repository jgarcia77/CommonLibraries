namespace Common.Helpers.IO
{
    using System;
    
    using System.Collections.Generic;
    
    using System.IO;
    
    using System.Linq;
    
    using System.Text;
    
    using System.Text.RegularExpressions;
    
    /// <summary>
    /// Reads a CSV file and returns a list of all the records
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CsvReaderHelper<T>
    {
        public List<T> Results { get; private set; }
        
        private static Regex rexCsvSplitter = new Regex(@",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))");
        private static Regex rexRunOnLine = new Regex(@"^[^""]*(?:""[^""]*""[^""]*)*""[^""]*$");

        private const string QUOTE = "\"";
        private const string ESCAPED_QUOTE = "\"\"";
        private static char[] CHARACTERS_THAT_MUST_BE_QUOTED = { ',', '"', '\n' };

        public CsvReaderHelper(string file)
        {
            this.Results = new List<T>();

            using (var reader = new StreamReader(File.OpenRead(file)))
            {
                var properties = typeof(T).GetProperties();

                while (!reader.EndOfStream)
                {
                    var lineIn = rexCsvSplitter.Split(reader.ReadLine());

                    var instance = Activator.CreateInstance<T>();

                    var fieldIndex = -1;
                    foreach (var property in properties)
                    {
                        fieldIndex++;

                        if (properties.Count() > lineIn.Length) break; //there are no more fields from the file

                        var value = Unescape(lineIn[fieldIndex].Trim());

                        var prop = instance.GetType().GetProperty(property.Name);

                        if (prop.PropertyType.FullName == "System.Int64")
                        {
                            instance.GetType().GetProperty(property.Name).SetValue(instance, long.Parse(value));
                        }
                        else if (prop.PropertyType.FullName == "System.Int32")
                        {
                            instance.GetType().GetProperty(property.Name).SetValue(instance, int.Parse(value));
                        }
                        else
                        {
                            instance.GetType().GetProperty(property.Name).SetValue(instance, value);
                        }
                    }

                    this.Results.Add(instance);
                }
            }

        }//End: CsvReader


        public string Escape(string s)
        {
            if (s.Contains(QUOTE))
                s = s.Replace(QUOTE, ESCAPED_QUOTE);

            if (s.IndexOfAny(CHARACTERS_THAT_MUST_BE_QUOTED) > -1)
                s = QUOTE + s + QUOTE;

            return s;
        }//End: Escape

        public string Unescape(string s)
        {
            if (s.StartsWith(QUOTE) && s.EndsWith(QUOTE))
            {
                s = s.Substring(1, s.Length - 2);

                if (s.Contains(ESCAPED_QUOTE))
                    s = s.Replace(ESCAPED_QUOTE, QUOTE);
            }

            return s;
        }//End: Unescape

    }//End: CsvReaderHelper

}//End: Common.Helpers.IO