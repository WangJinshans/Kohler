using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.QualityDetection
{
    public class QT_SCAR_Permanent_Corrective_Actions
    {
        private string date;
        private string form_ID;
        private string leader;
        private string permanent_Corrective_Actions_Content;
        private string permanent_Corrective_Actions_No;

        public string Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
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
        public string Leader
        {
            get
            {
                return leader;
            }

            set
            {
                leader = value;
            }
        }
        public string Permanent_Corrective_Actions_Content
        {
            get
            {
                return permanent_Corrective_Actions_Content;
            }

            set
            {
                permanent_Corrective_Actions_Content = value;
            }
        }
        public string Permanent_Corrective_Actions_No
        {
            get
            {
                return permanent_Corrective_Actions_No;
            }

            set
            {
                permanent_Corrective_Actions_No = value;
            }
        }
    }
}
