using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.QualityDetection
{
    public class QT_SCAR_Verification_of_Effectiveness
    {
        private string date;
        private string form_ID;
        private string verification_of_Effectiveness_Content;
        private string verification_of_Effectiveness_No;
        private string verifier;
        public string Verifier
        {
            get
            {
                return verifier;
            }

            set
            {
                verifier = value;
            }
        }
        public string Verification_of_Effectiveness_No
        {
            get
            {
                return verification_of_Effectiveness_No;
            }

            set
            {
                verification_of_Effectiveness_No = value;
            }
        }
        public string Verification_of_Effectiveness_Content
        {
            get
            {
                return verification_of_Effectiveness_Content;
            }

            set
            {
                verification_of_Effectiveness_Content = value;
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
    }
}
