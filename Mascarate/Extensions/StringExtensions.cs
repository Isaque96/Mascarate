using System;

namespace Mascarate.Extensions
{
    public static class StringExtensions
    {
        public static string Mascarate(this string str, string mask)
        {
            if (string.IsNullOrWhiteSpace(mask) ||
                string.IsNullOrEmpty(mask))
                throw new ArgumentNullException(nameof(mask));
            
            return str;
        }
    
        public static string UnMascarate(this string str)
        {
            return str;
        }
    }
}

