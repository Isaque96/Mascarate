using System;
using Mascarate.Configurations;
using Mascarate.Core;
using Mascarate.Exceptions;
using Mascarate.Utils;

namespace Mascarate.Extensions
{
    public static class StringExtensions
    {
        public static string Mascarate(this string input, string mask)
        {
            if (Validations(input, mask, out var exception))
                return MaskFormatter.FormatMask(input, mask);
            
            if (GlobalConfig.ShouldThrowFailureExceptions)
                throw exception;
                
            return null;
        }
    
        public static string UnMascarate(this string str)
        {
            return MaskFormatter.RemoveAnyMask(str);
        }

        public static string UnMascarate(this string input, string mask)
        {
            return MaskFormatter.RemoveMask(input, mask);
        }

        private static bool Validations(string input, string mask, out Exception exception)
        {
            exception = null;

            if (string.IsNullOrWhiteSpace(mask) || string.IsNullOrEmpty(mask))
            {
                exception = new ArgumentNullException(nameof(mask));
                return false;
            }

            if (string.IsNullOrWhiteSpace(input) || string.IsNullOrEmpty(input))
            {
                exception = new ArgumentNullException(nameof(input));
                return false;
            }

            if (input.Length != Util.CountMaskTypes(mask))
            {
                exception = new MissingValuesException();
                return false;
            }

            return true;
        }
    }
}

