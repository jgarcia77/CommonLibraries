namespace Common.Helpers.IO
{
    using System;
    
    using System.Collections.Generic;
    
    using System.IO;
    
    using System.Text;
    
    /// <summary>
    /// Writes a CSV file based on a list that is provided
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CsvWriterHelper<T>
    {

        public CsvWriterHelper(string file, List<T> data)
        {
            var stringBuilder = new StringBuilder();
            var properties = typeof(T).GetProperties();
            var counter = -1;

            foreach (var property in properties)
            {
                counter++;

                if (counter == 0)
                    stringBuilder.Append(property.Name);
                else
                    stringBuilder.Append(string.Concat(",", property.Name));
            }

            foreach (var item in data)
            {
                counter = -1;

                foreach (var property in properties)
                {
                    counter++;

                    var value = item.GetType()
                                    .GetProperty(property.Name)
                                    .GetValue(item)
                                    .ToString();

                    if (counter == 0)
                        stringBuilder.Append(string.Concat(Environment.NewLine, value));
                    else
                        stringBuilder.Append(string.Concat(",", value));
                }
            }

            File.WriteAllText(file, stringBuilder.ToString());
        }//End: CsvWriterHelper

    }//End: CsvWriterHelper

}
