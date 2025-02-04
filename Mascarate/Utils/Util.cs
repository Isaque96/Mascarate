using System.Linq;
using Mascarate.Configurations;

namespace Mascarate.Utils
{
    internal static class Util
    {
        internal static int CountSlashes(string mask, bool isMascarate)
        {
            var count = 0;
            for (var i = 0; i < mask.Length; i++)
            {
                if (mask[i] != '\\') continue;

                if (i + 1 < mask.Length && mask[i + 1] == '\\')
                {
                    if (isMascarate)
                        i++;
                    continue;
                }
                
                count++;
            }
            
            return count;
        }

        internal static int CountMaskTypes(string mask)
        {
            return mask.Count(c => MaskTypes.Masks.Contains(c)) - CountSlashes(mask, true);
        }
    }
}