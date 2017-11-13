using BLL;
using Model;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SHZSZHSUPPLY.VendorAssess
{
    public partial class ShowVendorRiskAnalysis : System.Web.UI.Page
    {
        private string formID = "";
        private string positionName = "";
        private string FORM_TYPE_ID = "";
        private string tempVendorID = "";

        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //重新获取session
                getSessionInfo();

                int check = VendorRiskAnalysis_BLL.checkVendorRiskAnalysis(formID);
                if (check > 0)
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
            As_Vendor_Risk vendorRisk = VendorRiskAnalysis_BLL.checkFlag(formID);
            Dictionary<string, string> notes = VendorRiskAnalysis_BLL.checkNotes(formID);
            if (vendorRisk != null)
            {
                txbProduct.Text = vendorRisk.Product;
                txbVendor.Text = vendorRisk.Supplier;
                txbPartNo.Text = vendorRisk.Part_No;
                txbWhereUsed.Text = vendorRisk.Where_Used;
                TextBox1.Text = vendorRisk.Manufacturer;
                TextBox2.Text = vendorRisk.Annual_Spend.ToString();
                setSelected(vendorRisk.Overall_Risk_Category, new[] { RadioButton1, RadioButton2, RadioButton3 });
                TextBox3.Text = vendorRisk.General_Assessment;
                TextBox4.Text = vendorRisk.Contingency_Plan;
                TextBox5.Text = vendorRisk.Urgency;
                TextBox6.Text = vendorRisk.Complete_By;
                TextBox7.Text = vendorRisk.Compiled_By;
                TextBox8.Text = vendorRisk.Date.ToString();
                setSelected(vendorRisk.Corporate_Strategy, new[] { RadioButton4, RadioButton5, RadioButton6 });
                setSelected(vendorRisk.Stability, new[] { RadioButton7, RadioButton8, RadioButton9 });
                setSelected(vendorRisk.Contractual, new[] { RadioButton10, RadioButton11, RadioButton12 });
                setSelected(vendorRisk.Third_Party_Involvement, new[] { RadioButton13, RadioButton14, RadioButton15 });
                setSelected(vendorRisk.Location, new[] { RadioButton16, RadioButton17, RadioButton18 });
                setSelected(vendorRisk.Transport, new[] { RadioButton19, RadioButton20, RadioButton21 });
                setSelected(vendorRisk.Seasonality, new[] { RadioButton22, RadioButton23, RadioButton24 });
                setSelected(vendorRisk.Environmental_Capacity, new[] { RadioButton25, RadioButton26, RadioButton27 });
                setSelected(vendorRisk.Stocks, new[] { RadioButton28, RadioButton29, RadioButton30 });
                setSelected(vendorRisk.Dedicated_Facilities, new[] { RadioButton31, RadioButton32, RadioButton33 });
                setSelected(vendorRisk.Recycling_Policy, new[] { RadioButton34, RadioButton35, RadioButton36 });
                setSelected(vendorRisk.Communication, new[] { RadioButton37, RadioButton38, RadioButton39 });
                setSelected(vendorRisk.Financial, new[] { RadioButton40, RadioButton41, RadioButton42 });
                setSelected(vendorRisk.Kohler_Forward_Plan, new[] { RadioButton43, RadioButton44, RadioButton45 });
                setSelected(vendorRisk.Supplier_Forward_Plan, new[] { RadioButton46, RadioButton47, RadioButton48 });
                setSelected(vendorRisk.Price, new[] { RadioButton94, RadioButton95, RadioButton96 });
                setSelected(vendorRisk.Change_Of_Source, new[] { RadioButton49, RadioButton50, RadioButton51 });
                setSelected(vendorRisk.Annual_Shutdown, new[] { RadioButton52, RadioButton53, RadioButton54 });
                setSelected(vendorRisk.Computer_Systems, new[] { RadioButton55, RadioButton56, RadioButton57 });
                setSelected(vendorRisk.Intellectual_Property_Kohler, new[] { RadioButton58, RadioButton59, RadioButton60 });
                setSelected(vendorRisk.Relationship, new[] { RadioButton61, RadioButton62, RadioButton63 });
                setSelected(vendorRisk.Technological_Capacity, new[] { RadioButton64, RadioButton65, RadioButton66 });
                setSelected(vendorRisk.Machine_Breakdown, new[] { RadioButton67, RadioButton68, RadioButton69 });
                setSelected(vendorRisk.Quality_Accreditation, new[] { RadioButton70, RadioButton71, RadioButton72 });
                setSelected(vendorRisk.Audit_Failure, new[] { RadioButton73, RadioButton74, RadioButton75 });
                setSelected(vendorRisk.Alternative_Supplier, new[] { RadioButton76, RadioButton77, RadioButton78 });
                setSelected(vendorRisk.Alternative_Materials, new[] { RadioButton79, RadioButton80, RadioButton81 });
                setSelected(vendorRisk.Complexity, new[] { RadioButton82, RadioButton83, RadioButton84 });
                setSelected(vendorRisk.Research_And_Development, new[] { RadioButton85, RadioButton86, RadioButton87 });
                setSelected(vendorRisk.Rejections_Or_Complaints, new[] { RadioButton88, RadioButton89, RadioButton90 });
                setSelected(vendorRisk.Specifications, new[] { RadioButton91, RadioButton92, RadioButton93 });

                foreach (Control item in this.Controls[3].Controls)
                {
                    if (item is TextBox && item.ID.Contains("TextBox") && Convert.ToInt32(item.ID.Replace("TextBox", "")) >= 10)
                    {
                        try
                        {
                            ((TextBox)item).Text = notes[item.ID];
                        }
                        catch (KeyNotFoundException)
                        {
                            continue;
                        }
                    }
                }
            }
            showapproveform(formID);
            showfilelist(formID);
        }

        public void showapproveform(string FormID)
        {
            As_Approve approve = new As_Approve();
            string sql = "SELECT * FROM View_Approve_Top WHERE Form_ID='" + FormID + "'";
            PagedDataSource objpds = new PagedDataSource();
            objpds.DataSource = AssessFlow_BLL.listApprove(sql,positionName);
            GridView1.DataSource = objpds;
            GridView1.DataBind();
        }
        public void showfilelist(string FormID)
        {
            As_Form_File Form_File = new As_Form_File();
            //string sql = "select * from As_Form_File where Form_ID='" + FormID + "' and Status='new'";
            string tempVendorID = AddForm_BLL.GetTempVendorID(formID);
            string sql = "select * from View_Form_File where Form_ID='" + FormID + "' and [File_ID] in (select [File_ID] from As_Vendor_FileType where Temp_Vendor_ID='" + tempVendorID + "') and Form_ID in (select Form_ID from As_Vendor_FormType where Temp_Vendor_ID='" + tempVendorID + "')";
            PagedDataSource objpds = new PagedDataSource();
            objpds.DataSource = FormFile_BLL.listFile(sql);
            GridView2.DataSource = objpds;
            GridView2.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //重新读取session信息
            getSessionInfo();

            //参数
            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            string formid = GridView1.Rows[drv.RowIndex].Cells[0].Text;
            string selectPositionName = GridView1.Rows[drv.RowIndex].Cells[1].Text;

            if (e.CommandName == "approvesuccess")
            {
                if (selectPositionName.Equals(positionName))
                {
                    //int i = AssessFlow_BLL.updateApprove(formid, positionName);
                    if (LocalApproveManager.doSuccessApprove(formID, tempVendorID, FORM_TYPE_ID, positionName, Page))
                    {
                        //Response.Write("<script>window.alert('成功通过审批！');window.location.href='ShowVendorRiskAnalysis.aspx'</script>");
                    }
                    else
                    {
                        Response.Write("<script>window.alert('操作失败！');window.location.href='ShowVendorRiskAnalysis.aspx'</script>");
                    }
                }
                else
                {
                    Response.Write("<script>window.alert('当前登录账号无对应权限！')</script>");
                }

            }
            else if (e.CommandName == "fail")
            {
                if (selectPositionName.Equals(positionName))
                {
                    LocalScriptManager.CreateScript(Page, String.Format("openReasonDialog('{0}','{1}','{2}',{3})", formID, positionName, Employee_BLL.getEmployeeFactory(Session["Employee_ID"].ToString()), "null"), "reasonDialog");
                }
                else
                {
                    Response.Write("<script>window.alert('当前登录账号无对应权限！')</script>");
                }
            }
        }

        /// <summary>
        /// 重新读取session
        /// </summary>
        private void getSessionInfo()
        {
            if (Request.QueryString["outPutID"] != null && Request.QueryString["outPutID"] != "")
            {
                formID = Request.QueryString["outPutID"];
                FORM_TYPE_ID = Request.QueryString["type"];
            }
            else
            {
                formID = Session["formID"].ToString();
                positionName = Session["Position_Name"].ToString();
                FORM_TYPE_ID = Request.QueryString["type"];
                tempVendorID = AddForm_BLL.GetTempVendorID(formID);//获取tempvendorID
            }
        }

        private void setSelected(byte? selected, RadioButton[] rb)
        {
            switch (selected)
            {
                case 0:
                    rb[0].Checked = true;
                    break;
                case 1:
                    rb[1].Checked = true;
                    break;
                case 2:
                    rb[2].Checked = true;
                    break;
                default:
                    break;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            getSessionInfo();
            //形成文件的ID 计划将简称保存到数据库的对应表中
            string fileTypeName = FormType_BLL.getFormNameByFormID(formID);
            string factory = AddForm_BLL.getFactoryByFormID(formID);
            string file = File_BLL.generateFileID(tempVendorID, fileTypeName, factory) + ".pdf";
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>takeScreenshot('" + file + "','" + formID + "');</script>");
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            string fileID = GridView2.Rows[drv.RowIndex].Cells[1].Text.ToString().Trim();//获取fileID
            if (e.CommandName == "view")
            {
                string filePath = LSetting.File_Reltive_Path + fileID + ".pdf";
                if (filePath != "")
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>viewFile('" + filePath + "');</script>");
                }
            }
        }
    }
}