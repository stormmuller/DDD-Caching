namespace CachedDomainState.Common
{
    using System;
    using System.Linq;

    public static class StringExtentions
    {
        public static string RemoveWhitespace(this string input)
        {
            return new string(input
                .Where(c => !char.IsWhiteSpace(c))
                .ToArray());
        }
    }
}
