using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.QualityDetection
{
    public class ConsignmentInspection
    {
        private string batch_No;
        private string consignment_KO;
        private string sKU;
        private string product_Name;
        private string vendor_Name;
        private string amount;
        private string arrave_Time;
        private string lab_Name;
        private string factory_Name;
        private string status;
        private string inspection_Type;

        public string Batch_No
        {
            get
            {
                return batch_No;
            }

            set
            {
                batch_No = value;
            }
        }

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

        public string Vendor_Name
        {
            get
            {
                return vendor_Name;
            }

            set
            {
                vendor_Name = value;
            }
        }

        public string Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
            }
        }

        public string Arrave_Time
        {
            get
            {
                return arrave_Time;
            }

            set
            {
                arrave_Time = value;
            }
        }

        public string Consignment_KO
        {
            get
            {
                return consignment_KO;
            }

            set
            {
                consignment_KO = value;
            }
        }

        public string Lab_Name
        {
            get
            {
                return lab_Name;
            }

            set
            {
                lab_Name = value;
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

        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public string Inspection_Type
        {
            get
            {
                return inspection_Type;
            }

            set
            {
                inspection_Type = value;
            }
        }
    }
}
