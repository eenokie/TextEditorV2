using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B04_A01_TextEditorV2
{
    public static class Ext
    {
        public static IEnumerable<int> AllIndexesOf(this string str, string value, bool shouldIgnoreCase)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("Der zu findende String darf nicht leer sein", "Wert");
            for (int index = 0; ; index += 1)
            {
                if (shouldIgnoreCase)
                {
                    index = str.IndexOf(value, index, StringComparison.OrdinalIgnoreCase);
                }
                else
                {
                    index = str.IndexOf(value, index);
                }
                if (index == -1)
                    break;
                yield return index;
            }                  
               
            

        }            
    }
}
