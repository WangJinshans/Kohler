namespace Model
{
    using System;

    public partial class As_Vendor_Risk
    {
        private string bar_Code;
        private string temp_Vendor_ID;

        public int ID { get; set; }

        public string Form_ID { get; set; }

        public string Form_Type_ID { get; set; }

        public string Supplier { get; set; }

        public string Part_No { get; set; }

        public string Manufacturer { get; set; }

        public string Where_Used { get; set; }

        public double? Annual_Spend { get; set; }

        public byte? Overall_Risk_Category { get; set; }

        public string General_Assessment { get; set; }

        public string Contingency_Plan { get; set; }

        public string Urgency { get; set; }

        public string Complete_By { get; set; }

        public string Compiled_By { get; set; }

        public DateTime? Date { get; set; }

        public byte? Corporate_Strategy { get; set; }

        public byte? Stability { get; set; }

        public byte? Contractual { get; set; }

        public byte? Third_Party_Involvement { get; set; }

        public byte? Location { get; set; }

        public byte? Transport { get; set; }

        public byte? Seasonality { get; set; }

        public byte? Environmental_Capacity { get; set; }

        public byte? Stocks { get; set; }

        public byte? Dedicated_Facilities { get; set; }

        public byte? Recycling_Policy { get; set; }

        public byte? Communication { get; set; }

        public byte? Financial { get; set; }

        public byte? Kohler_Forward_Plan { get; set; }

        public byte? Supplier_Forward_Plan { get; set; }

        public byte? Price { get; set; }

        public byte? Change_Of_Source { get; set; }

        public byte? Annual_Shutdown { get; set; }

        public byte? Computer_Systems { get; set; }

        public byte? Intellectual_Property_Kohler { get; set; }

        public byte? Relationship { get; set; }

        public byte? Technological_Capacity { get; set; }

        public byte? Machine_Breakdown { get; set; }

        public byte? Quality_Accreditation { get; set; }

        public byte? Audit_Failure { get; set; }

        public byte? Alternative_Supplier { get; set; }

        public byte? Alternative_Materials { get; set; }

        public byte? Complexity { get; set; }

        public byte? Research_And_Development { get; set; }

        public byte? Rejections_Or_Complaints { get; set; }

        public byte? Specifications { get; set; }

        public int Flag { get; set;  }

        public string Product { get; set; }

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
    }
}
