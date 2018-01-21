using BLL;
using BLL.VendorAssess;
using Model;
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
    public partial class ApprovalProgress : System.Web.UI.Page
    {
        public Dictionary<string, Dictionary<string, string[]>> info;
        private string serializedJson;
        private static string tempVendorID = "";
        private static string factory = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //读取列表
                readVendorInfo();

                //处理get请求
                if (Request.QueryString["formID"] != null && Request.QueryString["formID"] != "")
                {
                    formName.InnerText = Request.QueryString["formID"];
                    showDetail(Request.QueryString["formID"]);
                }
                else
                {
                    //恢复现场
                    LocalScriptManager.CreateScript(Page, "recoverSelectData()", "recoverInfo");
                }
            }
            else
            {
                //重新读取供应商列表
                LocalScriptManager.CreateScript(Page, "getParams()", "getparams");

                //处理postback回调
                switch (Request["__EVENTTARGET"])
                {
                    case "refreshNewVendor":
                        tempVendorID = Request.Form["__EVENTARGUMENT"];
                        factory = TempVendor_BLL.getTempVendorFactory(tempVendorID);
                        refreshNewVendor(Request.Form["__EVENTARGUMENT"]);
                        break;
                    case "vendorTransfer":
                        btnTransfer_Click(Request.Form["__EVENTARGUMENT"]);
                        break;
                    case "vendorModifyTransfer":
                        //供应商信息修改后的转移
                        btnModifyTransfer_Click();
                        break;
                    default:
                        break;
                }

            }
        }

        private void readVendorInfo()
        {
            info = TempVendor_BLL.readVendorInfo();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            serializedJson = jss.Serialize(info);
            LocalScriptManager.CreateScript(Page, String.Format("setParams('{0}')", serializedJson), "params");
        }

        private void bindGridData(string tempVendorID)
        {
            string sql2 = "SELECT * FROM View_Vendor_FormType WHERE Temp_Vendor_ID='" + tempVendorID + "'";
            PagedDataSource objpds2 = new PagedDataSource();
            objpds2.DataSource = SelectForm_BLL.selectAllForm(sql2);
            //获取数据源
            GridView3.DataSource = objpds2;
            //绑定数据源
            GridView3.DataBind();
        }

        private void refreshNewVendor(string tempVendorID)
        {
            bindGridData(tempVendorID);

            Session["apTempVendorID"] = tempVendorID;

            vendorName.InnerText = TempVendor_BLL.getTempVendorName(tempVendorID);

            formName.InnerText = "表格名称";

            normalInfoDetail.InnerText = "";

            exceptionInfoDetail.InnerText = "";

            LocalScriptManager.createManagerScript(Page, String.Format("setVendorName('{0}')", TempVendor_BLL.getTempVendorName(tempVendorID)), "setvendorname");

            //LocalScriptManager.createManagerScript(Page, String.Format("setFormProgress('{0}')", 0), "setformprogress");

            //检查是否可转移
            string factory = Session["Factory_Name"].ToString();
            string employee_ID = Session["Employee_ID"].ToString();
            if (File_Transform_BLL.checkFormSubmit(tempVendorID, factory) && AddEmployeeVendor_BLL.hasEmployeeID(tempVendorID, employee_ID) && File_Transform_BLL.FormAccessSuccessFul(tempVendorID, factory))
            {
                btnTransfer.Enabled = true;
                btnTransfer.CssClass = "layui-btn";
                btnTransfer.ToolTip = "可以开始转移";
            }
            else if (TempVendor_BLL.isOldVendor(tempVendorID))
            {
                btnTransfer.Enabled = true;
                btnTransfer.CssClass = "layui-btn";
                btnTransfer.ToolTip = "可以开始转移";
            }
            else
            {
                btnTransfer.Enabled = false;
                btnTransfer.CssClass = "layui-btn layui-btn-disabled";
                btnTransfer.ToolTip = "无法转移，此账号无权限操作或仍然有表单未审批完成";
            }

            //检查是否修改可转移
            if (File_Transform_BLL.isModifyOK(tempVendorID, factory))
            {
                btnModifyTransfer.Enabled = true;
                btnModifyTransfer.CssClass = "layui-btn";
                btnModifyTransfer.ToolTip = "可以开始转移";
            }
            else
            {
                btnModifyTransfer.Enabled = false;
                btnModifyTransfer.CssClass = "layui-btn layui-btn-disabled";
                btnModifyTransfer.ToolTip = "无法转移，此账号无权限操作或仍然有表单未审批完成";
            }
        }

        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "showDetails")
            {
                GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
                formName.InnerText = HttpUtility.HtmlDecode(GridView3.Rows[drv.RowIndex].Cells[1].Text);
                showDetail(e.CommandArgument.ToString());
            }
        }

        private void showDetail(string formID)
        {
            string normal = ApprovalProgress_BLL.readFormNormalInfo(formID);
            string exception = ApprovalProgress_BLL.readFormExceptionInfo(formID);

            normalInfoDetail.InnerHtml = normal;
            exceptionInfoDetail.InnerHtml = exception;

            UpdatePanel.Update();
            //Random rd = new Random();
            //LocalScriptManager.createManagerScript(Page, String.Format("setFormProgress('{0}')", rd.Next(10, 101)), "setformprogress");

        }

        protected void btnTransfer_Click(string code)
        {
            /*
             * 如果fileoverdue中有此id对应的hold状态，进行file类型转移
             *否则检查formoverdue中是否有hold状态，进行form转移
             * 否则执行全转移
             */
            btnTransfer.Enabled = false;
            btnTransfer.CssClass = "layui-btn layui-btn-disabled";
            btnTransfer.ToolTip = "无法转移，请等待";

            string factory = Session["Factory_Name"].ToString();
            string tempVendorID = Request.Form["quiz3"];

            string[] options = code.Split('&');
            code = options[0];
            File_Transform_BLL.mode = options[1];

            if (!File_Transform_BLL.checkFileSubmit(tempVendorID, factory))
            {
                LocalScriptManager.createManagerScript(Page, "messageConfirmNone('请补充上传所有“必须”类型的文件')", "filemsg");
            }
            else
            {
                string transferResult = "";

                int transferType = File_Transform_BLL.getTransferType(tempVendorID);
                switch (transferType)
                {
                    case File_Transform_BLL.FILE_TYPE:
                        transferResult = File_Transform_BLL.vendorOverDueFileTransForm(tempVendorID, factory, code, Properties.Settings.Default.Transfer_Dest_Path, Session["Employee_ID"].ToString().Trim());
                        if (transferResult == "")
                        {
                            File_Transform_BLL.changeStatus(tempVendorID, true);
                            File_Transform_BLL.changeStatus(tempVendorID, false);
                        }
                        break;
                    case File_Transform_BLL.FORM_TYPE:
                        transferResult = File_Transform_BLL.vendorOverDueFormTransForm(tempVendorID, factory, code, Properties.Settings.Default.Transfer_Dest_Path, Session["Employee_ID"].ToString().Trim());
                        if (transferResult == "")
                        {
                            File_Transform_BLL.changeStatus(tempVendorID, false);
                        }
                        break;
                    case File_Transform_BLL.ALL_TYPE:
                        transferResult = File_Transform_BLL.vendorTransForm(tempVendorID, factory, code, Properties.Settings.Default.Transfer_Dest_Path, Session["Employee_ID"].ToString().Trim());
                        break;
                    default:
                        break;
                }

                if (transferResult == "")
                {
                    LocalScriptManager.createManagerScript(Page, "messageConfirmNone('已将最新的文件更新到供应商管理系统')", "filemsg1");
                }
                else if (transferResult.Equals(File_Transform_BLL.CODE_EXIST))
                {
                    LocalScriptManager.createManagerScript(Page, "messageConfirmNone('已将最新的文件更新到供应商管理系统，" + transferResult + "')", "filemsg1");
                }
                else
                {
                    LocalScriptManager.createManagerScript(Page, "messageConfirmNone('" + transferResult + "')", "filemsg1");
                }
            }
        }



        private void btnModifyTransfer_Click()
        {
            btnTransfer.Enabled = true;
            //btnTransfer.CssClass = "layui-btn layui-btn-disabled";
            btnTransfer.CssClass = "layui-btn";
            btnTransfer.ToolTip = "无法转移，请等待";
            string factory = Session["Factory_Name"].ToString();
            string tempVendorID = Request.Form["quiz3"];

            //在审批完成的时候转移了修改表 并插入了item_List中

            //转移新提交的文件 并复制到UpLoad文件夹中
            File_Transform_BLL.ModifyTransfer(tempVendorID, factory, Properties.Settings.Default.Transfer_Dest_Path, Session["Employee_ID"].ToString().Trim());
            LocalScriptManager.createManagerScript(Page, "messageConfirmNone('已将最新的修改的文件更新到供应商管理系统)", "filemsg1");
        }

        protected void btnTransfer_Click1(object sender, EventArgs e)
        {
            //Session["apTempVendorID"] = Request["quiz3"];
        }
    }
}