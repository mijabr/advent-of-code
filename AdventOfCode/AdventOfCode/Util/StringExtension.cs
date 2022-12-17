﻿namespace AdventOfCode.Util
{
    public static class StringExtension
    {
        public static int IndexOfNth(this string searchString, string value, int nth) => searchString.IndexOfNth(value, nth, 0);

        public static int IndexOfNth(this string searchString, string value, int nth, int startIndex)
        {
            int pos;
            do
            {
                pos = searchString.IndexOf(value, startIndex);
                startIndex = pos + 1;
                nth--;
            } while (nth > 0 && pos != -1);

            return pos;
        }

        public static T ParseAfter<T>(this string searchString, string after, int startIndex = 0) where T : IParsable<T>
        {
            return searchString.Parse<T>(searchString.IndexOf(after, startIndex) + after.Length);
        }

        public static T Parse<T>(this string searchString, int startIndex = 0, IFormatProvider? format = null) where T : IParsable<T>
        {
            var endIndex = searchString.IndexOfNoneOf("-0123456789".ToCharArray(), startIndex);
            return endIndex == -1
                ? T.Parse(searchString.Substring(startIndex), format)
                : T.Parse(searchString.Substring(startIndex, endIndex - startIndex), format);
        }

        public static int IndexOfNoneOf(this string searchString, char[] noneOf, int startIndex = 0)
        {
            while (searchString.Length > startIndex)
            {
                if (!noneOf.Contains(searchString[startIndex]))
                {
                    return startIndex;
                }

                startIndex++;
            }

            return -1;
        }
    }
}
