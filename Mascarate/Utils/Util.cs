using System.Linq;
using Mascarate.Configurations;

namespace Mascarate.Utils
{
    public static class Util
    {
        public static bool IsValidMaskType(char maskType)
        {
            return MaskTypes.Masks.Contains(maskType);
        }
    }
}