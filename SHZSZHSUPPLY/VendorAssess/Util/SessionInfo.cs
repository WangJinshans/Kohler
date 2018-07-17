using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHZSZHSUPPLY.VendorAssess.Util
{
    public class SessionInfo
    {
        private string formName;
        private string formTypeID;
        private string tempVendorID;
        private string factoryName;
        private string tempVendorName;
        private string formID;
        private string submit;
        private bool singleFileSubmit = false;

        public string FormName
        {
            get
            {
                return formName;
            }

            set
            {
                formName = value;
            }
        }

        public string FormTypeID
        {
            get
            {
                return formTypeID;
            }

            set
            {
                formTypeID = value;
            }
        }

        public string TempVendorID
        {
            get
            {
                return tempVendorID;
            }

            set
            {
                tempVendorID = value;
            }
        }

        public string FactoryName
        {
            get
            {
                return factoryName;
            }

            set
            {
                factoryName = value;
            }
        }

        public string TempVendorName
        {
            get
            {
                return tempVendorName;
            }

            set
            {
                tempVendorName = value;
            }
        }

        public string FormID
        {
            get
            {
                return formID;
            }

            set
            {
                formID = value;
            }
        }

        public string Submit
        {
            get
            {
                return submit;
            }

            set
            {
                submit = value;
            }
        }

        public bool SingleFileSubmit
        {
            get
            {
                return singleFileSubmit;
            }

            set
            {
                singleFileSubmit = value;
            }
        }
    }
}