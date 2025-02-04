using Mascarate.Extensions;

namespace Mascarate
{
    public static class Mask
    {
        public static string Apply(string input, string mask)
            => input.Mascarate(mask);

        public static string Remove(string input)
            => input.UnMascarate();

        public static string Remove(string input, string mask)
            => input.UnMascarate(mask);

        public static bool Validate(string input, string mask)
            => input.MascarateValidate(mask);
    }
}