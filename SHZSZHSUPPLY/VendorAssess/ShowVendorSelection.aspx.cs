using BLL;
using BLL.VendorAssess;
using Model;
using MODEL.VendorAssess;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SHZSZHSUPPLY.VendorAssess
{
    public partial class ShowVendorSelection : System.Web.UI.Page
    {
        private string formID = null;
        private string positionName = null;
        private string FORM_TYPE_ID = "";
        private string tempVendorID = "";

        private Dictionary<string, List<string>> suppliers; 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //重新获取session
                getSessionInfo();

                int check = VendorSelection_BLL.checkVendorSelection(formID);
                if (check > 0)
                {
                    showVendorSelection();
                }
            }
        }
        public string getSupplier(string sequence)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(suppliers[sequence]);
        }

        /// <summary>
        /// 显示表格
        /// </summary>
        private void showVendorSelection()
        {
            string[] strArray = { "one", "two", "three", "four", "five" };

            //初始化表格数据源
            As_Vendor_Selection vendorSelection = VendorSelection_BLL.checkFlag(formID);

            //初始化supplier数据源
            suppliers = VendorSelectionSupplier_BLL.checkSupplier(formID);

            //更新页面数据
            if (vendorSelection != null)
            {
                txbRef.Text = vendorSelection.Ref_No;
                txbDate.Text = vendorSelection.Date;
                txbOne.Text = vendorSelection.Supplier_One_ID;
                txbTwo.Text = vendorSelection.Supplier_Two_ID;
                txbThree.Text = vendorSelection.Supplier_Three_ID;
                txbFour.Text = vendorSelection.Supplier_Four_ID;
                txbFive.Text = vendorSelection.Supplier_Five_ID;
            }

            //更新supplier数据
            if (suppliers != null)
            {
                for (int i = 0; i < suppliers.Count; i++)
                {
                    int t = i * 12 + 1;
                    List<string> supplier = suppliers[strArray[i]];
                    setSelected(Convert.ToByte(supplier[supplier.Count - 4]), new[] { (RadioButton)Controls[3].FindControl("RadioButton" + t), (RadioButton)Controls[3].FindControl("RadioButton" + (t + 1)), (RadioButton)Controls[3].FindControl("RadioButton" + (t + 2)) });
                    setSelected(Convert.ToByte(supplier[supplier.Count - 3]), new[] { (RadioButton)Controls[3].FindControl("RadioButton" + (t + 3)), (RadioButton)Controls[3].FindControl("RadioButton" + (t + 4)), (RadioButton)Controls[3].FindControl("RadioButton" + (t + 5)) });
                    setSelected(Convert.ToByte(supplier[supplier.Count - 2]), new[] { (RadioButton)Controls[3].FindControl("RadioButton" + (t + 6)), (RadioButton)Controls[3].FindControl("RadioButton" + (t + 7)), (RadioButton)Controls[3].FindControl("RadioButton" + (t + 8)) });
                    setSelected(Convert.ToByte(supplier[supplier.Count - 1]), new[] { (RadioButton)Controls[3].FindControl("RadioButton" + (t + 9)), (RadioButton)Controls[3].FindControl("RadioButton" + (t + 10)), (RadioButton)Controls[3].FindControl("RadioButton" + (t + 11)) });
                    LocalScriptManager.CreateScript(Page, "showSupplier(" + i + "," + getSupplier(strArray[i]) + ")", "showSuppliers" + i);
                }
            }

            //重新计算Total
            LocalScriptManager.CreateScript(Page, "setTotal()", "reCalTotal");

            //展示附件
            showfilelist(formID);
            showapproveform(formID);
        }

        public void showapproveform(string FormID)
        {
            As_Approve approve = new As_Approve();
            string sql = "SELECT * FROM View_Approve_Top WHERE Form_ID='" + FormID + "'";
            PagedDataSource objpds = new PagedDataSource();
            objpds.DataSource = AssessFlow_BLL.listApprove(sql, positionName);
            GridView1.DataSource = objpds;
            GridView1.DataBind();
        }
        public void showfilelist(string FormID)
        {
            As_Form_File Form_File = new As_Form_File();
            //string sql = "select * from As_Form_File where Form_ID='" + FormID + "' and Status='new'";
            string tempVendorID = AddForm_BLL.GetTempVendorID(formID);
            string sql = "select * from As_Form_File where Form_ID='" + FormID + "' and [File_ID] in (select [File_ID] from As_Vendor_FileType where Temp_Vendor_ID='" + tempVendorID + "') and Form_ID in (select Form_ID from As_Vendor_FormType where Temp_Vendor_ID='" + tempVendorID + "')";
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
                    if (LocalApproveManager.doSuccessApprove(formID, Session["tempVendorID"].ToString(), FORM_TYPE_ID, positionName, Page))
                    {
                        //Response.Write("<script>window.alert('成功通过审批！');window.location.href='ShowVendorSelection.aspx'</script>");
                    }
                    else
                    {
                        Response.Write("<script>window.alert('操作失败！');window.location.href='ShowVendorSelection.aspx'</script>");
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
            formID = Session["formID"].ToString();
            positionName = Session["Position_Name"].ToString();
            FORM_TYPE_ID = Request.QueryString["type"];
            tempVendorID = AddForm_BLL.GetTempVendorID(formID);//获取tempvendorID
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
            string fileTypeName = FormType_BLL.getFormNameByTypeID(FORM_TYPE_ID);
            string factory = AddForm_BLL.getFactoryByFormID(formID);
            string file = tempVendorID + File_Type_BLL.getFormSpec(fileTypeName) + DateTime.Now.ToString("yyyyMMddHHmmss") + File_BLL.getSimpleFactory(factory) + ".pdf";
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>takeScreenshot('" + file + "','" + formID + "');</script>");
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            string fileID = GridView2.Rows[drv.RowIndex].Cells[1].Text.ToString().Trim();//获取fileID
            if (e.CommandName == "view")
            {
                string filePath = "../files/" + fileID + ".pdf";
                if (filePath != "")
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>viewFile('" + filePath + "');</script>");
                }
            }
        }
    }
}