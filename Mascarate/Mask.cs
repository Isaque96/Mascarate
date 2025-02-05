using Mascarate.Core;

namespace Mascarate
{
    public static class Mask
    {
        public static string Apply(string input, string mask)
            => MaskFormatter.ApplyMask(input, mask);

        public static string Remove(string input)
            => MaskFormatter.RemoveMask(input);

        public static string Remove(string input, string mask)
            => MaskFormatter.RemoveMask(input, mask);

        public static bool Validate(string input, string mask)
            => MaskFormatter.ValidateMask(input, mask);
    }
}