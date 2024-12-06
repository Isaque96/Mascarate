using System;
using Mascarate.Configurations;
using Mascarate.Utils;

namespace Mascarate.Exceptions
{
    public class InvalidValueForMaskTypeException : Exception
    {
        public InvalidValueForMaskTypeException(char maskType, char value)
            : base(
                $"The value '{value}' is invalid for the mask type '{TypeOfMask(maskType)}' (code: '{maskType}')." +
                Environment.NewLine +
                $"Expected values: {ExpectedValues(maskType)}."
            ) { }

        private static string TypeOfMask(char maskType)
        {
            switch (maskType)
            {
                case MaskTypes.NumericMask:
                    return "Numbers";
                case MaskTypes.AlphaNumericMask:
                    return "Letters or Numbers";
                case MaskTypes.LetterMask:
                    return "Letters";
                default:
                    return "Unknown Mask Type";
            }
        }
        
        private static string ExpectedValues(char maskType)
        {
            switch (maskType)
            {
                case MaskTypes.NumericMask:
                    return "0-9";
                case MaskTypes.AlphaNumericMask:
                    return "A-Z, a-z, 0-9";
                case MaskTypes.LetterMask:
                    return "A-Z, a-z";
                default:
                    return "N/A";
            }
        }
    }
}