using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MODEL.QualityDetection
{
    public class QT_Component_List
    {
        private string sKU;
        private string product_Name;
        private string product_Describes;
        private string detection_Requirement;
        private string pPAP;
        private string broken_Detection;
        private string mBR_Distinction;
        private string factory_Name;
        private string vendor_Code;
        private string class_Leval;
        private string aQL;
        private string surface_Inspection;
        private string suitability_Inspection;


        public string SKU
        {
            get
            {
                return sKU;
            }

            set
            {
                sKU = value;
            }
        }
        public string Product_Name
        {
            get
            {
                return product_Name;
            }

            set
            {
                product_Name = value;
            }
        }
        public string Product_Describes
        {
            get
            {
                return product_Describes;
            }

            set
            {
                product_Describes = value;
            }
        }
        public string Detection_Requirement
        {
            get
            {
                return detection_Requirement;
                
            }

            set
            {
                detection_Requirement = value;
            }
        }
        public string PPAP
        {
            get
            {
                return pPAP;
            }

            set
            {
                pPAP = value;
            }
        }
        public string Broken_Detection
        {
            get
            {
                return broken_Detection;
            }

            set
            {
                broken_Detection = value;
            }
        }
        public string MBR_Distinction
        {
            get
            {
                return mBR_Distinction;
            }

            set
            {
                mBR_Distinction = value;
            }

        }
        public string Factory_Name
        {
            get
            {
                return factory_Name;
            }

            set
            {
                factory_Name = value;
            }
        }
        public string Vendor_Code
        {
            get
            {
                return vendor_Code;
            }

            set
            {
                vendor_Code = value;
            }
        }
        public string Class_Leval
        {
            get
            {
                return class_Leval;
            }

            set
            {
                class_Leval = value;
            }

        }
        public string AQL
        {
            get
            {
                return aQL;
            }

            set
            {
                aQL = value;
            }
        }
        public string Surface_Inspection
        {
            get
            {
                return surface_Inspection;
            }

            set
            {
                surface_Inspection = value;
            }
        }
        public string Suitability_Inspection
        {
            get
            {
                return suitability_Inspection;
            }

            set
            {
                suitability_Inspection = value;
            }

        }
    }
}
