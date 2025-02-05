using Mascarate.Core;

namespace Mascarate.Extensions
{
    public static class StringExtensions
    {
        public static string Mascarate(this string input, string mask)
            => MaskFormatter.ApplyMask(input, mask);

        public static string UnMascarate(this string input)
            => MaskFormatter.RemoveMask(input);
        
        public static string UnMascarate(this string input, string mask)
            => MaskFormatter.RemoveMask(input, mask);

        public static bool MascarateValidate(this string input, string mask)
            => MaskFormatter.ValidateMask(input, mask);
    }
}

