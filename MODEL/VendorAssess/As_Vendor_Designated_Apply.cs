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
        private string effectiveTime;
        private string purchaseAmount;
        private string reason;
        private string initiator;
        private string initiatorDate;
        private string applicant;
        private string requestDeptHead;
        private string finManager;
        private string applicantDate;
        private string requestDeptHeadDate;
        private string finManagerDate;
        private string purchasingManager;
        private string gM;
        private string purchasingManagerDtae;
        private string GMDate;
        private string director;
        private string supplyChainDirector; //供应链最高层
        private string directorDtae;
        private string supplyChainDirectorDate;
        private string president;
        private string presidenDate;
        private string finalDate;
        private string bar_Code;
        private string form_id;
        private string form_Type_ID;
        private string temp_Vendor_ID;
        private int flag;
        private string factory_Name;

        private string vendorName1;
        private string sAPCode_1;
        private string businessCategory1;
        private string effectiveTime1;
        private string purchaseAmount1;
        private string reason1;

        private string vendorName2;
        private string sAPCode_2;
        private string businessCategory2;
        private string effectiveTime2;
        private string purchaseAmount2;
        private string reason2;

        private string vendorName3;
        private string sAPCode_3;
        private string businessCategory3;
        private string effectiveTime3;
        private string purchaseAmount3;
        private string reason3;

        private string vendorName4;
        private string sAPCode_4;
        private string businessCategory4;
        private string effectiveTime4;
        private string purchaseAmount4;
        private string reason4;

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

        public string EffectiveTime
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

        public string Date
        {
            get
            {
                return InitiatorDate;
            }

            set
            {
                InitiatorDate = value;
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

        public string ApplicantDate
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

        public string RequestDeptHeadDate
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

        public string FinManagerDate
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

        public string GM
        {
            get
            {
                return gM;
            }

            set
            {
                gM = value;
            }
        }

        public string PurchasingManagerDtae
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

        public string GMDate1
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

        public string DirectorDtae
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

        public string SupplyChainDirectorDate
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



        public string FinalDate
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

        public string PresidenDate
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
                return president;
            }

            set
            {
                president = value;
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

        public string Form_Type_ID
        {
            get
            {
                return form_Type_ID;
            }

            set
            {
                form_Type_ID = value;
            }
        }

        public string Temp_Vendor_ID
        {
            get
            {
                return temp_Vendor_ID;
            }

            set
            {
                temp_Vendor_ID = value;
            }
        }

        public int Flag
        {
            get
            {
                return flag;
            }

            set
            {
                flag = value;
            }
        }

        public string InitiatorDate
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

        public string Factory_Name
        {
            get
            {
                return factory_Name;
            }

            set
            {
                factory_Name = value;
            }
        }

        public string VendorName1
        {
            get
            {
                return vendorName1;
            }

            set
            {
                vendorName1 = value;
            }
        }

        public string SAPCode_1
        {
            get
            {
                return sAPCode_1;
            }

            set
            {
                sAPCode_1 = value;
            }
        }

        public string BusinessCategory1
        {
            get
            {
                return businessCategory1;
            }

            set
            {
                businessCategory1 = value;
            }
        }

        public string EffectiveTime1
        {
            get
            {
                return effectiveTime1;
            }

            set
            {
                effectiveTime1 = value;
            }
        }

        public string PurchaseAmount1
        {
            get
            {
                return purchaseAmount1;
            }

            set
            {
                purchaseAmount1 = value;
            }
        }

        public string Reason1
        {
            get
            {
                return reason1;
            }

            set
            {
                reason1 = value;
            }
        }

        public string VendorName2
        {
            get
            {
                return vendorName2;
            }

            set
            {
                vendorName2 = value;
            }
        }

        public string SAPCode_2
        {
            get
            {
                return sAPCode_2;
            }

            set
            {
                sAPCode_2 = value;
            }
        }

        public string BusinessCategory2
        {
            get
            {
                return businessCategory2;
            }

            set
            {
                businessCategory2 = value;
            }
        }

        public string EffectiveTime2
        {
            get
            {
                return effectiveTime2;
            }

            set
            {
                effectiveTime2 = value;
            }
        }

        public string PurchaseAmount2
        {
            get
            {
                return purchaseAmount2;
            }

            set
            {
                purchaseAmount2 = value;
            }
        }

        public string Reason2
        {
            get
            {
                return reason2;
            }

            set
            {
                reason2 = value;
            }
        }

        public string VendorName3
        {
            get
            {
                return vendorName3;
            }

            set
            {
                vendorName3 = value;
            }
        }

        public string SAPCode_3
        {
            get
            {
                return sAPCode_3;
            }

            set
            {
                sAPCode_3 = value;
            }
        }

        public string BusinessCategory3
        {
            get
            {
                return businessCategory3;
            }

            set
            {
                businessCategory3 = value;
            }
        }

        public string EffectiveTime3
        {
            get
            {
                return effectiveTime3;
            }

            set
            {
                effectiveTime3 = value;
            }
        }

        public string PurchaseAmount3
        {
            get
            {
                return purchaseAmount3;
            }

            set
            {
                purchaseAmount3 = value;
            }
        }

        public string Reason3
        {
            get
            {
                return reason3;
            }

            set
            {
                reason3 = value;
            }
        }

        public string VendorName4
        {
            get
            {
                return vendorName4;
            }

            set
            {
                vendorName4 = value;
            }
        }

        public string SAPCode_4
        {
            get
            {
                return sAPCode_4;
            }

            set
            {
                sAPCode_4 = value;
            }
        }

        public string BusinessCategory4
        {
            get
            {
                return businessCategory4;
            }

            set
            {
                businessCategory4 = value;
            }
        }

        public string EffectiveTime4
        {
            get
            {
                return effectiveTime4;
            }

            set
            {
                effectiveTime4 = value;
            }
        }

        public string PurchaseAmount4
        {
            get
            {
                return purchaseAmount4;
            }

            set
            {
                purchaseAmount4 = value;
            }
        }

        public string Reason4
        {
            get
            {
                return reason4;
            }

            set
            {
                reason4 = value;
            }
        }
    }
}
