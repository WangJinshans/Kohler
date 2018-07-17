using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.QualityDetection
{
    public class StockInfo
    {
        private string batch_No;
        private string remark;
        private string source_From;
        private string status;
        private string add_Time;
        private string rC;
        private string rJ;

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

        public string Source_From
        {
            get
            {
                return source_From;
            }

            set
            {
                source_From = value;
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

        public string RC
        {
            get
            {
                return rC;
            }

            set
            {
                rC = value;
            }
        }

        public string RJ
        {
            get
            {
                return rJ;
            }

            set
            {
                rJ = value;
            }
        }
    }
}
