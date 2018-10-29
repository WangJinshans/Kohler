using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.QualityDetection
{
    public class QT_Inspection_Item
    {
        private string batch_No;//检验批
        private string sKU;//物料编号
        private string product_Name;
        private string product_Describes;
        private string vendor_Code;
        private string detection_Count;
        private string remark;
        private string go;
        private string to;
        private string form_ID;//报告表格ID
        private string status;//状态
        private string factory_Name;//厂名
        private string add_Time;//时间
        private string import_KO;//导入人的KO号码
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

        public string Detection_Count
        {
            get
            {
                return detection_Count;
            }

            set
            {
                detection_Count = value;
            }
        }

        public string Remark
        {
            get
            {
                return remark;
            }

            set
            {
                remark = value;
            }
        }

        public string Go
        {
            get
            {
                return go;
            }

            set
            {
                go = value;
            }
        }

        public string To
        {
            get
            {
                return to;
            }

            set
            {
                to = value;
            }
        }

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

        public string Add_Time
        {
            get
            {
                return add_Time;
            }

            set
            {
                add_Time = value;
            }
        }

        public string Import_KO
        {
            get
            {
                return import_KO;
            }

            set
            {
                import_KO = value;
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
