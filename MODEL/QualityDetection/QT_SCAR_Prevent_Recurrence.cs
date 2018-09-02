using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.QualityDetection
{
    public class QT_SCAR_Prevent_Recurrence
    {
        private string date;
        private string form_ID;
        private string leader;
        private string prevent_Recurrence_Content;
        private string prevent_Recurrence_No;
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
        public string Prevent_Recurrence_Content
        {
            get
            {
                return prevent_Recurrence_Content;
            }

            set
            {
                prevent_Recurrence_Content = value;
            }
        }
        public string Prevent_Recurrence_No
        {
            get
            {
                return prevent_Recurrence_No;
            }

            set
            {
                prevent_Recurrence_No = value;
            }
        }
    }
}
