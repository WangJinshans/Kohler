using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;


namespace SHZSZHSUPPLY.VendorAssess
{
    public partial class ShowVendorDiscovery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string formid = null;
                string tempvendorname = null;
                tempvendorname = Session["tempvendorname"].ToString();
                formid = tempvendorname + "调查表PR-05-01-5";

                As_Vendor_Discovery Vendor_Discovery = new As_Vendor_Discovery();
                int check = VendorDiscovery_BLL.checkVendorDiscovery(formid);
                if(check>0)
                {
                    showVendorDiscovery();  
                }
            }

        }

        private void showVendorDiscovery()
        {
            string formid = null;
            string tempvendorname = null;
            tempvendorname = Session["tempvendorname"].ToString();
            formid = tempvendorname + "调查表PR-05-01-5";

            As_Vendor_Discovery Vendor_Discovery = new As_Vendor_Discovery();
            Vendor_Discovery = VendorDiscovery_BLL.checkFlag(formid);
            {
                TextBox1.Text = Vendor_Discovery.File_Time;
                TextBox2.Text = Vendor_Discovery.Temp_Vendor_Name;
                TextBox3.Text = Vendor_Discovery.Legal_Person;
                TextBox4.Text = Vendor_Discovery.Address;
                TextBox5.Text = Vendor_Discovery.Tel;
                TextBox6.Text = Vendor_Discovery.Fax;
                TextBox7.Text = Vendor_Discovery.Product_Name_One;
                TextBox8.Text = Vendor_Discovery.Size_One;
                TextBox9.Text = Vendor_Discovery.Quality_One;
                TextBox10.Text = Vendor_Discovery.Position_Environment_One;
                TextBox11.Text = Vendor_Discovery.Envir_Protection_System_One;
                TextBox49.Text = Vendor_Discovery.Product_Name_Two;
                TextBox50.Text = Vendor_Discovery.Size_Two;
                TextBox51.Text = Vendor_Discovery.Quality_Two;
                TextBox52.Text = Vendor_Discovery.Position_Environment_Two;
                TextBox53.Text = Vendor_Discovery.Envir_Protection_System_Two;
                TextBox54.Text = Vendor_Discovery.Product_Name_Three;
                TextBox55.Text = Vendor_Discovery.Size_Three;
                TextBox56.Text = Vendor_Discovery.Quality_Three;
                TextBox57.Text = Vendor_Discovery.Position_Environment_Three;
                TextBox58.Text = Vendor_Discovery.Envir_Protection_System_Three;
                TextBox12.Text = Vendor_Discovery.Product_Ability;
                TextBox13.Text = Vendor_Discovery.Last_Sale;
                TextBox14.Text = Vendor_Discovery.Main_CusMark_One;
                TextBox41.Text = Vendor_Discovery.Main_CusMark_Two;
                TextBox42.Text = Vendor_Discovery.Main_CusMark_Three;
                TextBox15.Text = Vendor_Discovery.Register_Capital;
                TextBox16.Text = Vendor_Discovery.Fixed_Assets;
                TextBox17.Text = Vendor_Discovery.Flow_Capital;
                TextBox18.Text = Vendor_Discovery.Pay_Condition;
                TextBox19.Text = Vendor_Discovery.Employee_Num;
                TextBox20.Text = Vendor_Discovery.Manager;
                TextBox21.Text = Vendor_Discovery.Quality_Person;
                TextBox22.Text = Vendor_Discovery.Tech_Person;
                TextBox23.Text = Vendor_Discovery.Company_Area;
                TextBox24.Text = Vendor_Discovery.Factory_Area;
                TextBox25.Text = Vendor_Discovery.Entrepot_Area;
                TextBox26.Text = Vendor_Discovery.Week_Wrok_Time;
                TextBox27.Text = Vendor_Discovery.Week_Turn_Num;
                TextBox28.Text = Vendor_Discovery.Produce_Load;
                TextBox31.Text = Vendor_Discovery.Product_material_One;
                TextBox32.Text = Vendor_Discovery.Region_One;
                TextBox33.Text = Vendor_Discovery.Material_Store_Conditon_One;
                TextBox64.Text = Vendor_Discovery.Product_material_Two;
                TextBox65.Text = Vendor_Discovery.Region_Two;
                TextBox66.Text = Vendor_Discovery.Material_Store_Conditon_Two;
                TextBox67.Text = Vendor_Discovery.Product_material_Three;
                TextBox68.Text = Vendor_Discovery.Region_Three;
                TextBox69.Text = Vendor_Discovery.Material_Store_Conditon_Three;
                TextBox29.Text = Vendor_Discovery.ISO;
                TextBox30.Text = Vendor_Discovery.Transport;
                TextBox43.Text = Vendor_Discovery.Device_Name;
                TextBox44.Text = Vendor_Discovery.Device_Size;
                TextBox45.Text = Vendor_Discovery.Device_Year;
                TextBox46.Text = Vendor_Discovery.Device_Factory;
                TextBox47.Text = Vendor_Discovery.Device_Condition;
                TextBox34.Text = Vendor_Discovery.Check_Device;
                TextBox35.Text = Vendor_Discovery.Send_Ability;
                TextBox59.Text = Vendor_Discovery.Purchase_Period;
                TextBox60.Text = Vendor_Discovery.Min_Order_Num;
                TextBox36.Text = Vendor_Discovery.Vendor_Participate;
                TextBox37.Text = Vendor_Discovery.Produce_Flow;
                TextBox38.Text = Vendor_Discovery.Product_Book_Flow;
                TextBox39.Text = Vendor_Discovery.Manage_Dimension;
                TextBox40.Text = Vendor_Discovery.Employee_Experience;
                TextBox48.Text = Vendor_Discovery.Conclusion;
            }
            showapproveform(formid);
            showfilelist(formid);

        }
        public void showapproveform(string FormID)
        {
            As_Approve approve = new As_Approve();
            string sql = "SELECT * FROM As_Approve WHERE Form_ID='" + FormID + "'";
            PagedDataSource objpds = new PagedDataSource();
            objpds.DataSource = AssessFlow_BLL.listApprove(sql);
            GridView1.DataSource = objpds;
            GridView1.DataBind();
        }
        public void showfilelist(string FormID)
        {
            As_Form_File Form_File = new As_Form_File();
            string sql = "select * from As_Form_File where Form_ID='" + FormID + "'";
            PagedDataSource objpds = new PagedDataSource();
            objpds.DataSource = FormFile_BLL.listFile(sql);
            GridView2.DataSource = objpds;
            GridView2.DataBind();
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "approvesuccess")
            {

                GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
                string formid = GridView1.Rows[drv.RowIndex].Cells[0].Text;
                string positionname = Session["Position_Name"].ToString();
                int i = AssessFlow_BLL.updateApprove(formid, positionname);
                if (i == 1)
                {
                    //Response.Redirect("Vendor_Discovery.aspx");
                }else if (e.CommandName == "fail")
                {
                    int j = AssessFlow_BLL.updateApproveFail(formid, positionname);
                }
            }
        }
    }
}