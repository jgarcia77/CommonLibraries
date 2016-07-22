namespace Common.Helpers.Text
{
    using System;
    using System.Collections.Generic;

    public class StringHelper
    {
        public static string AbbreviateInt(long integer)
        {
            var returnValue = string.Empty;

            if (integer < 1000)
            {
                returnValue = integer.ToString();
            }
            else if (integer >= 1000 && integer <= 999999)
            {
                var calculatedValue = FormatFloatTwoDecimals(integer, 1000);

                returnValue = string.Concat(calculatedValue, "k");
            }
            else if (integer >= 1000000 && integer <= 999999999)
            {
                var calculatedValue = FormatFloatTwoDecimals(integer, 1000000);

                returnValue = string.Concat(calculatedValue, "m");
            }
            else if (integer >= 1000000000 && integer <= 999999999999)
            {
                var calculatedValue = FormatFloatTwoDecimals(integer, 1000000000);

                returnValue = string.Concat(calculatedValue, "b");
            }
            else if (integer >= 1000000000000 && integer <= 999999999999999)
            {
                var calculatedValue = FormatFloatTwoDecimals(integer, 1000000000000);

                returnValue = string.Concat(calculatedValue, "t");
            }

            return returnValue;
        }

        private static double FormatFloatTwoDecimals(long integer, long denominator)
        {
            var dividen = (double)integer / denominator;

            var dividenFloor = Math.Floor(dividen);

            var remainder = dividen - dividenFloor;

            if (remainder > 0)
            {
                var remainderString = remainder.ToString();

                if (remainderString.Length > 3)
                {
                    var twoDigitRemainder = remainderString.Substring(2, 2);

                    var abbreviatedRemainder = int.Parse(twoDigitRemainder) * .01;

                    dividen = (double)dividenFloor + (double)abbreviatedRemainder;
                }
            }

            return dividen;
        }

        public static bool ParseTags(string openingTag, string closingTag, string value, List<string> output)
        {
            var returnValue = true;

            if (output == null)
            {
                output = new List<string>();
            }

            if (!string.IsNullOrWhiteSpace(value))
            {
                value = value.Trim();

                var openingTagIndex = value.IndexOf(openingTag);
                                
                while (true)
                {
                    if (openingTagIndex != -1)
                    {
                        // found an opening tag and need to search for closing tag
                        var startingSearchIndex = openingTagIndex + openingTag.Length;
                        var closingTagIndex = value.IndexOf(closingTag, startingSearchIndex);

                        if (closingTagIndex != -1)
                        {
                            var parsedValueLength = closingTagIndex - startingSearchIndex;
                            var parsedValue = value.Substring(startingSearchIndex, parsedValueLength);

                            output.Add(parsedValue);

                            // search for the next closing tag
                            var nextStartingIndex = closingTagIndex + closingTag.Length;
                            openingTagIndex = value.IndexOf(openingTag, nextStartingIndex);
                        }
                        else
                        {
                            // could not find a closing tag
                            returnValue = false;
                            break;
                        }
                    }
                    else
                    {
                        // searching is complete
                        break;
                    }
                }
            }
            
            return returnValue;
        }
    }
}
