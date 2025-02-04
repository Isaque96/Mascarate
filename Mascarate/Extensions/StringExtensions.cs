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
            if (Validations(input, mask, true, out var exception))
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
            if (Validations(input, mask, false, out var exception))
                return MaskFormatter.RemoveMask(input, mask);
            
            if (GlobalConfig.ShouldThrowFailureExceptions)
                throw exception;
            
            return null;
        }

        public static bool MascarateValidate(this string input, string mask)
        {
            var validations = Validations(input, mask, false, out _);
            var completeMaskValidation = MaskFormatter.ValidateMask(input, mask);
            
            return validations && completeMaskValidation;
        }
        
        private static bool Validations(string input, string mask, bool isMascarate, out Exception exception)
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

            if (isMascarate)
            {
                if (input.Length == Util.CountMaskTypes(mask))
                    return true;
            }
            else
            {
                if (input.Length == (mask.Length - Util.CountSlashes(mask, false)))
                    return true;
            }

            exception = new MissingValuesException();
            return false;
        }
    }
}

