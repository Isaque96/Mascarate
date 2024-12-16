using System;
using Mascarate.Core;
using Mascarate.Exceptions;
using Mascarate.Utils;

namespace Mascarate.Extensions
{
    public static class StringExtensions
    {
        public static string Mascarate(this string input, string mask)
        {
            if (string.IsNullOrWhiteSpace(mask) || string.IsNullOrEmpty(mask))
                throw new ArgumentNullException(nameof(mask));
            
            if (string.IsNullOrWhiteSpace(input) || string.IsNullOrEmpty(input))
                throw new ArgumentNullException(nameof(input));
            
            if (input.Length != Util.CountMaskTypes(mask))
                throw new MissingValuesException();
            
            return MaskFormatter.FormatMask(input, mask);
        }
    
        public static string UnMascarate(this string str)
        {
            return MaskFormatter.RemoveAnyMask(str);
        }

        public static string UnMascarate(this string input, string mask)
        {
            return MaskFormatter.RemoveMask(input, mask);
        }
    }
}

