using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B04_A01_TextEditorV2
{
    public static class Ext
    {
        public static IEnumerable<int> AllIndexesOf(this string str, string value)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("Der zu findende String darf nicht leer sein", "Wert");
            for (int index = 0; ; index += 1)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                    break;
                yield return index;
            }
        }
        public static IEnumerable<int> AllIndexesOfIC(this string str, string value)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("Der zu findende String darf nicht leer sein", "Wert");
            for (int index = 0; ; index += 1)
            {
                index = str.IndexOf(value, index, StringComparison.OrdinalIgnoreCase);
                if (index == -1)
                    break;
                yield return index;
            }
        }            
    }
}
