using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SHZSZHSUPPLY.VendorAssess
{
    public partial class VendorRiskAnalysis : System.Web.UI.Page
    {
        public static string formNameNumber = "PR-05-13-5";
        public const string FORM_TYPE_ID = "003";
        public const byte LOW = 0;
        public const byte MEDIUM = 1;
        public const byte HIGH = 2;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string formID = null;
                string tempVendorName = null;

                //一开始填写表格就把表As_Employee_ID字段FLag置1.
                int updateFlag = UpdateFlag_BLL.updateFlag(FORM_TYPE_ID, tempVendorName);

                //初始化信息
                As_Vendor_Risk vendorRisk = new As_Vendor_Risk();
                tempVendorName = Session["tempvendorname"].ToString();
                formID = tempVendorName + formNameNumber;

                //显示文件列表
                showfilelist(formID);

                //向As_Form中添加表
                As_Form form = new As_Form();
                form.Form_ID = formID;
                form.Form_Name = "供应商风险分析表";
                form.Form_Type_ID = FORM_TYPE_ID;
                form.Temp_Vendor_Name = tempVendorName;
                form.Form_Path = "";
                int add = AddForm_BLL.addForm(form);

                //检查表格是否已经存在
                int check = VendorRiskAnalysis_BLL.checkVendorRiskAnalysis(formID);
                if (check == 0)
                {
                    //TODO::初始化新的风险分析表，并插入到数据库As_Vendor_RiskAnalysis表中
                    vendorRisk.Form_ID = formID;
                    vendorRisk.Form_Type_ID = FORM_TYPE_ID;
                    vendorRisk.Supplier = tempVendorName;
                    vendorRisk.Flag = 1;
                    int n = VendorRiskAnalysis_BLL.addVendorRisk(vendorRisk);
                }
                else
                {
                    showVendorRiskAnalysis();
                }
            }
        }

        /// <summary>
        /// 显示分析分析表
        /// </summary>
        private void showVendorRiskAnalysis()
        {
            string tempVendorName = Session["tempvendorname"].ToString();
            string formID = tempVendorName + formNameNumber;

            As_Vendor_Risk vendorRisk = new As_Vendor_Risk();
            vendorRisk = VendorRiskAnalysis_BLL.checkFlag(formID);
            {
                //TODO::绑定vendorRisk信息到表中，在这里初始化表（读取存储，新）
                TextBox8.Text = vendorRisk.Date.ToString();
            }
            //TODO::其他操作
            showapproveform(formID);
        }

        public void approveaccess(string formTypeID, string formId)
        {
            string formtypeid = formTypeID;
            As_Assess_Flow assess_flow = new As_Assess_Flow();
            assess_flow = AssessFlow_BLL.getFirstAssessFlow(formtypeid);
            Session["AssessflowInfo"] = assess_flow;
            string i = assess_flow.User_Department_Assess;
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

        public void Button1_Click(object sender, EventArgs e)//提交按钮
        {
            As_Vendor_Risk vendorRisk = null;
            string tempVendorName = Session["tempvendorname"].ToString();
            string formID = tempVendorName + formNameNumber;
            vendorRisk = saveForm(2, "提交表格");
            approveaccess(vendorRisk.Form_Type_ID, formID);            //确定审批流程
        }

        private As_Vendor_Risk saveForm(int flag, string manul)
        {
            As_Vendor_Risk vendorRisk = new As_Vendor_Risk();
            string tempVendorName = Session["tempvendorname"].ToString();
            string formID = tempVendorName + formNameNumber;
            vendorRisk.Form_ID = formID;
            vendorRisk.Form_Type_ID = "003";
            vendorRisk.Product = txbProduct.Text.Trim();
            vendorRisk.Supplier = txbVendor.Text.Trim();
            vendorRisk.Part_No = txbPartNo.Text.Trim();
            vendorRisk.Manufacturer = TextBox1.Text.Trim();
            vendorRisk.Where_Used = txbWhereUsed.Text.Trim();
            vendorRisk.Annual_Spend = Convert.ToDouble(TextBox2.Text.Trim());
            vendorRisk.Overall_Risk_Category = 0;//TODO::根据low mid high三个选项设置不同的值
            vendorRisk.General_Assessment = TextBox3.Text.Trim();
            vendorRisk.Contingency_Plan = TextBox4.Text.Trim();
            vendorRisk.Urgency = TextBox5.Text.Trim();
            vendorRisk.Complete_By = TextBox6.Text.Trim();
            vendorRisk.Compiled_By = TextBox7.Text.Trim();
            vendorRisk.Date = Convert.ToDateTime(TextBox8.Text.Trim());

            vendorRisk.Corporate_Strategy = Convert.ToByte(getSelected(new[] { RadioButton3, RadioButton4, RadioButton5 }));

            vendorRisk.Flag = flag;                       //更改表格的标志位
            int join = VendorRiskAnalysis_BLL.updateVendorRisk(vendorRisk);
            if (join > 0)
            {
                As_Write write = new As_Write();                     //将填写信息记录
                write.Employee_ID = Session["Employee_ID"].ToString();
                write.Form_ID = vendorRisk.Form_ID;
                write.Form_Fill_Time = vendorRisk.Date.ToString();
                write.Manul = manul;
                Write_BLL.addWrite(write);
                Response.Write("<script>window.alert('操作成功！')</script>");
                return vendorRisk;
            }
            else
            {
                return null;
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            string formid = GridView1.Rows[drv.RowIndex].Cells[0].Text;
            string positionname = Session["Position_Name"].ToString();
            if (e.CommandName == "approvesuccess")
            {
                int i = AssessFlow_BLL.updateApprove(formid, positionname);
                if (i == 1)
                {
                    //Response.Redirect("Vendor_Discovery.aspx");
                }
            }
            else if (e.CommandName == "fail")
            {
                int j = AssessFlow_BLL.updateApproveFail(formid, positionname);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            saveForm(1, "保存表格");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeVendor.aspx");
        }

        /// <summary>
        /// 获取low medium high三个哪一个被选择
        /// </summary>
        /// <param name="rb"></param>
        /// <returns></returns>
        private byte getSelected(RadioButton[] rb)
        {
            if (rb[0].Checked)
            {
                return LOW;
            }
            else if(rb[1].Checked)
            {
                return MEDIUM;
            }
            else if(rb[2].Checked)
            {
                return HIGH;
            }
            return 3;
        }
    }
}