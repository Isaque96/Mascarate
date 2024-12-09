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

        private static int CountSlashes(string mask)
        {
            var count = 0;
            for (var i = 0; i < mask.Length; i++)
            {
                if (mask[i] != '\\') continue;
                
                if (i + 1 < mask.Length && mask[i + 1] == '\\')
                    i++;
                
                count++;
            }
            
            return count;
        }

        public static int CountMaskTypes(string mask)
        {
            return mask.Count(c => MaskTypes.Masks.Contains(c)) - CountSlashes(mask);
        }
    }
}