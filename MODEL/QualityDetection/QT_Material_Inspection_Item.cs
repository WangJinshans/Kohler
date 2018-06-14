using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.QualityDetection
{
    public class QT_Material_Inspection_Item
    {
        private string item;
        private string standard;
        private int material_NO;

        public string Item
        {
            get
            {
                return item;
            }

            set
            {
                item = value;
            }
        }

        public string Standard
        {
            get
            {
                return standard;
            }

            set
            {
                standard = value;
            }
        }

        public int Material_NO
        {
            get
            {
                return material_NO;
            }

            set
            {
                material_NO = value;
            }
        }
    }
}
