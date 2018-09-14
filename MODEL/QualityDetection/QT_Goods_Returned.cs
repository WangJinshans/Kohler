using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.QualityDetection
{
    public class QT_Goods_Returned
    {
        private string form_ID;
        private string batch_No;
        private string vendor_Code;
        private string total;
        private string reject;
        private string reason;
        private string scar_ID;
        private string factory_Name;
        private string status;

        public string Form_ID
        {
            get
            {
                return form_ID;
            }

            set
            {
                form_ID = value;
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

        public string Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }

        public string Reject
        {
            get
            {
                return reject;
            }

            set
            {
                reject = value;
            }
        }

        public string Reason
        {
            get
            {
                return reason;
            }

            set
            {
                reason = value;
            }
        }

        public string Scar_ID
        {
            get
            {
                return scar_ID;
            }

            set
            {
                scar_ID = value;
            }
        }

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
    }
}
