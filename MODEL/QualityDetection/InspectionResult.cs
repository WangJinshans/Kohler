using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.QualityDetection
{
    public class InspectionResult
    {
        private string result;
        private string judgement;

        public string Result
        {
            get
            {
                return result;
            }

            set
            {
                result = value;
            }
        }

        public string Judgement
        {
            get
            {
                return judgement;
            }

            set
            {
                judgement = value;
            }
        }
    }
}
