using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.QualityDetection
{
    public class InspectionPlanResult
    {
        private string sample_Amount;
        private string aC;
        private string rE;
        private string aQL;
        private string sample_Code;
        private string inspection_Leval;
        private string class_Level;

        public string Sample_Amount
        {
            get
            {
                return sample_Amount;
            }

            set
            {
                sample_Amount = value;
            }
        }

        public string AC
        {
            get
            {
                return aC;
            }

            set
            {
                aC = value;
            }
        }

        public string RE
        {
            get
            {
                return rE;
            }

            set
            {
                rE = value;
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

        public string Sample_Code
        {
            get
            {
                return sample_Code;
            }

            set
            {
                sample_Code = value;
            }
        }

        public string Inspection_Leval
        {
            get
            {
                return inspection_Leval;
            }

            set
            {
                inspection_Leval = value;
            }
        }

        public string Class_Level
        {
            get
            {
                return class_Level;
            }

            set
            {
                class_Level = value;
            }
        }
    }
}
