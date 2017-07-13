using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 该类为指定供应商信息采集表中对应的元素 使整张表为一个对象
    /// 对应的Date是对应元素下的日期
    /// </summary>
    public class As_Vendor_Designated_Apply
    {
        private string vendorName;
        private string SAPCode;
        private string businessCategory;
        private DateTime effectiveTime;
        private string purchaseAmount;
        private string reason;
        private string initiator;
        private DateTime initiatorDate;
        private string applicant;
        private string requestDeptHead;
        private string finManager;
        private DateTime applicantDate;
        private DateTime requestDeptHeadDate;
        private DateTime finManagerDate;
        private string purchasingManager;
        private string GM;
        private DateTime purchasingManagerDtae;
        private DateTime GMDate;
        private string director;
        private string supplyChainDirector; //供应链最高层
        private DateTime directorDtae;
        private DateTime supplyChainDirectorDate;
        private string persident;
        private DateTime presidenDate;
        private DateTime finalDate;
        private string bar_Code;
        private string form_id;

        public string VendorName
        {
            get
            {
                return vendorName;
            }

            set
            {
                vendorName = value;
            }
        }

        public string SAPCode1
        {
            get
            {
                return SAPCode;
            }

            set
            {
                SAPCode = value;
            }
        }

        public string BusinessCategory
        {
            get
            {
                return businessCategory;
            }

            set
            {
                businessCategory = value;
            }
        }

        public DateTime EffectiveTime
        {
            get
            {
                return effectiveTime;
            }

            set
            {
                effectiveTime = value;
            }
        }

        public string PurchaseAmount
        {
            get
            {
                return purchaseAmount;
            }

            set
            {
                purchaseAmount = value;
            }
        }

        public string Reason
        {
            get
            {
                return reason;
            }

            set
            {
                reason = value;
            }
        }

        public string Initiator
        {
            get
            {
                return initiator;
            }

            set
            {
                initiator = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return initiatorDate;
            }

            set
            {
                initiatorDate = value;
            }
        }

        public string Applicant
        {
            get
            {
                return applicant;
            }

            set
            {
                applicant = value;
            }
        }

        public string RequestDeptHead
        {
            get
            {
                return requestDeptHead;
            }

            set
            {
                requestDeptHead = value;
            }
        }

        public string FinManager
        {
            get
            {
                return finManager;
            }

            set
            {
                finManager = value;
            }
        }

        public DateTime ApplicantDate
        {
            get
            {
                return applicantDate;
            }

            set
            {
                applicantDate = value;
            }
        }

        public DateTime RequestDeptHeadDate
        {
            get
            {
                return requestDeptHeadDate;
            }

            set
            {
                requestDeptHeadDate = value;
            }
        }

        public DateTime FinManagerDate
        {
            get
            {
                return finManagerDate;
            }

            set
            {
                finManagerDate = value;
            }
        }

        public string PurchasingManager
        {
            get
            {
                return purchasingManager;
            }

            set
            {
                purchasingManager = value;
            }
        }

        public string GM1
        {
            get
            {
                return GM;
            }

            set
            {
                GM = value;
            }
        }

        public DateTime PurchasingManagerDtae
        {
            get
            {
                return purchasingManagerDtae;
            }

            set
            {
                purchasingManagerDtae = value;
            }
        }

        public DateTime GMDate1
        {
            get
            {
                return GMDate;
            }

            set
            {
                GMDate = value;
            }
        }

        public string Director
        {
            get
            {
                return director;
            }

            set
            {
                director = value;
            }
        }

        public string SupplyChainDirector
        {
            get
            {
                return supplyChainDirector;
            }

            set
            {
                supplyChainDirector = value;
            }
        }

        public DateTime DirectorDtae
        {
            get
            {
                return directorDtae;
            }

            set
            {
                directorDtae = value;
            }
        }

        public DateTime SupplyChainDirectorDate
        {
            get
            {
                return supplyChainDirectorDate;
            }

            set
            {
                supplyChainDirectorDate = value;
            }
        }

        

        public DateTime FinalDate
        {
            get
            {
                return finalDate;
            }

            set
            {
                finalDate = value;
            }
        }

        public DateTime PresidenDate
        {
            get
            {
                return presidenDate;
            }

            set
            {
                presidenDate = value;
            }
        }

        public string Persident
        {
            get
            {
                return persident;
            }

            set
            {
                persident = value;
            }
        }

        public string Bar_Code
        {
            get
            {
                return bar_Code;
            }

            set
            {
                bar_Code = value;
            }
        }

        public string Form_id
        {
            get
            {
                return form_id;
            }

            set
            {
                form_id = value;
            }
        }
    }
}
