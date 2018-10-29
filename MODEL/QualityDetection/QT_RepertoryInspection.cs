using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.QualityDetection
{
    public class QT_RepertoryInspection
    {
        private string batch_No;
        private string status;
        private string type;//仓库 车间
        private string take_Out;//取出数量
        private string unit;//单位
        private string bad;//有问题数量

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

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }


        public string Unit
        {
            get
            {
                return unit;
            }

            set
            {
                unit = value;
            }
        }

        public string Take_Out
        {
            get
            {
                return take_Out;
            }

            set
            {
                take_Out = value;
            }
        }

        public string Bad
        {
            get
            {
                return bad;
            }

            set
            {
                bad = value;
            }
        }
    }
}
