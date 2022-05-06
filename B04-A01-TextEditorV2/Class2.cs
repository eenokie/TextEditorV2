using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B04_A01_TextEditorV2
{
       
    public class FormProvider
    {
        
        public static suchDialog sd
        {
            get
            {
                if (_sd == null)
                {
                    _sd = new suchDialog();
                    _sd.MinimumSize = _sd.Size;
                    _sd.MaximumSize = _sd.MinimumSize;
                    _sd.TopMost = true;
                }
                return _sd;
            }
        }
        private static suchDialog _sd;

        public static replaceDialog rd
        {
            get
            {
                if (_rd == null)
                {
                    _rd = new replaceDialog();
                    _rd.MinimumSize = _rd.Size;
                    _rd.MaximumSize = _rd.MinimumSize;
                    _rd.TopMost = true;
                }
                return _rd;
            }
        }
        private static replaceDialog _rd;
       
    }
    
}
 