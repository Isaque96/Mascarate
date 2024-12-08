using System;
using System.Linq;
using System.Text;
using Mascarate.Configurations;
using Mascarate.Exceptions;

namespace Mascarate.Core
{
    internal static class MaskFormatter
    {
        public static string FormatMask(string input, string mask)
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

        public static string RemoveAnyMask(string input)
        {
            return new string(input.Where(char.IsLetterOrDigit).ToArray());
        }

        public static string RemoveMask(string input, string mask)
        {
            if (input is null) throw new ArgumentNullException(nameof(input), "Input must not be null.");
            if (mask is null) throw new ArgumentNullException(nameof(mask), "Mask must not be null.");
            if (input.Length == 0 || mask.Length == 0) 
                throw new ArgumentException("Input and mask must not be empty.");

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
    }
}
