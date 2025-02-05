using System;
using System.Linq;
using System.Text;
using Mascarate.Configurations;
using Mascarate.Exceptions;
using Mascarate.Utils;

namespace Mascarate.Core
{
    internal static class MaskFormatter
    {
        private static string FormatMask(string input, string mask)
        {
            var result = new StringBuilder();
            var inputIndex = 0;

            for (var i = 0; i < mask.Length; i++)
            {
                var maskChar = mask[i];

                // Skip next char if it is escaped
                if (maskChar == '\\' && i + 1 < mask.Length)
                {
                    result.Append(mask[++i]);
                    continue;
                }

                if (inputIndex >= input.Length)
                    break;

                var inputChar = input[inputIndex];

                switch (maskChar)
                {
                    case MaskTypes.AlphaNumericMask:
                        if (!char.IsLetterOrDigit(inputChar))
                            throw new InvalidValueForMaskTypeException(MaskTypes.AlphaNumericMask, inputChar);
                        result.Append(inputChar);
                        inputIndex++;
                        break;
                    case MaskTypes.LetterMask:
                        if (!char.IsLetter(inputChar))
                            throw new InvalidValueForMaskTypeException(MaskTypes.LetterMask, inputChar);
                        result.Append(inputChar);
                        inputIndex++;
                        break;
                    case MaskTypes.NumericMask:
                        if (!char.IsDigit(inputChar))
                            throw new InvalidValueForMaskTypeException(MaskTypes.NumericMask, inputChar);
                        result.Append(inputChar);
                        inputIndex++;
                        break;
                    default:
                        result.Append(maskChar);
                        if (inputChar == maskChar)
                            inputIndex++;
                        break;
                }
            }

            return result.ToString();
        }

        private static string RemoveFormatForAnyMask(string input)
        {
            return new string(input.Where(char.IsLetterOrDigit).ToArray());
        }

        private static string RemoveFormatMask(string input, string mask)
        {
            var result = new StringBuilder();
            var inputIndex = 0;

            for (var i = 0; i < mask.Length && inputIndex < input.Length; i++)
            {
                var maskChar = mask[i];
                var inputChar = input[inputIndex];

                switch (maskChar)
                {
                    case '\\' when i + 1 < mask.Length:
                        maskChar = mask[++i];
                        if (inputChar != maskChar)
                            result.Append(inputChar);
                        inputIndex++;
                        break;

                    case MaskTypes.AlphaNumericMask:
                        if (char.IsLetterOrDigit(inputChar))
                        {
                            result.Append(inputChar);
                            inputIndex++;
                        }
                        break;

                    case MaskTypes.LetterMask:
                        if (char.IsLetter(inputChar))
                        {
                            result.Append(inputChar);
                            inputIndex++;
                        }
                        break;

                    case MaskTypes.NumericMask:
                        if (char.IsDigit(inputChar))
                        {
                            result.Append(inputChar);
                            inputIndex++;
                        }
                        break;

                    default:
                        if (inputChar != maskChar)
                            result.Append(inputChar);
                        inputIndex++;
                        break;
                }
            }

            while (inputIndex < input.Length)
            {
                result.Append(input[inputIndex]);
                inputIndex++;
            }

            return result.ToString();
        }

        private static bool ValidateMaskFormat(string input, string mask)
        {
            var inputIndex = 0;

            for (var i = 0; i < mask.Length; i++)
            {
                var maskChar = mask[i];

                if (maskChar == '\\' && i + 1 < mask.Length)
                    maskChar = mask[++i];

                if (inputIndex >= input.Length)
                    return false;

                var inputChar = input[inputIndex];

                switch (maskChar)
                {
                    case MaskTypes.NumericMask:
                        if (!char.IsDigit(inputChar))
                            return false;
                        break;

                    case MaskTypes.LetterMask:
                        if (!char.IsLetter(inputChar))
                            return false;
                        break;

                    case MaskTypes.AlphaNumericMask:
                        if (!char.IsLetterOrDigit(inputChar))
                            return false;
                        break;

                    default:
                        if (inputChar != maskChar)
                            return false;
                        break;
                }

                inputIndex++;
            }

            return inputIndex >= input.Length;
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
        
        internal static string ApplyMask(string input, string mask)
        {
            if (Validations(input, mask, true, out var exception))
                return FormatMask(input, mask);
            
            if (GlobalConfig.ShouldThrowFailureExceptions)
                throw exception;
                
            return null;
        }
    
        internal static string RemoveMask(string str)
        {
            return RemoveFormatForAnyMask(str);
        }

        internal static string RemoveMask(string input, string mask)
        {
            if (Validations(input, mask, false, out var exception))
                return RemoveFormatMask(input, mask);
            
            if (GlobalConfig.ShouldThrowFailureExceptions)
                throw exception;
            
            return null;
        }

        internal static bool ValidateMask(string input, string mask)
        {
            var validations = Validations(input, mask, false, out _);
            var completeMaskValidation = ValidateMaskFormat(input, mask);
            
            return validations && completeMaskValidation;
        }
    }
}
