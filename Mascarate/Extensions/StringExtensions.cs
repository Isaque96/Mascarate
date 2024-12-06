using System;
using Mascarate.Core;

namespace Mascarate.Extensions
{
    public static class StringExtensions
    {
        public static string Mascarate(this string input, string mask)
        {
            if (string.IsNullOrWhiteSpace(mask) ||
                string.IsNullOrEmpty(mask))
                throw new ArgumentNullException(nameof(mask));
            
            return MaskFormatter.FormatMask(input, mask);
        }
    
        public static string UnMascarate(this string str)
        {
            return str;
        }
    }
}

