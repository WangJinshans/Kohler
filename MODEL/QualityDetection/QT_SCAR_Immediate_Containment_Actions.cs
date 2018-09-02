using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.QualityDetection
{
    public class QT_SCAR_Immediate_Containment_Actions
    {
        private string date;
        private string form_ID;
        private string immediate_Containment_Actions_Content;
        private string immediate_Containment_Actions_No;
        private string leader;

        public string Immediate_Containment_Actions_Content
        {
            get
            {
                return immediate_Containment_Actions_Content;
            }

            set
            {
                immediate_Containment_Actions_Content = value;
            }
        }
        public string Immediate_Containment_Actions_No
        {
            get
            {
                return immediate_Containment_Actions_No;
            }

            set
            {
                immediate_Containment_Actions_No = value;
            }
        }
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
    }
}
