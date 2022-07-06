using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzhanCoreLayer.Utilities.FIxer
{
    public static class StringFixer
    {
        public static string Fixed(this string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                text = text.ToLower().Trim();
            }

            return text;
        }
    }
}
