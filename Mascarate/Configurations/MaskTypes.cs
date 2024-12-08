namespace Mascarate.Configurations
{
    internal static class MaskTypes
    {
        public const char LetterMask = '@';
        public const char AlphaNumericMask = '*';
        public const char NumericMask = '#';

        public static readonly char[] Masks = { LetterMask, AlphaNumericMask, NumericMask };
    }
}