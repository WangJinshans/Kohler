using BLL;
using BLL.VendorAssess;
using DAL.VendorAssess;
using Model;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SHZSZHSUPPLY.VendorAssess.Html_Template
{
    public partial class TransferComparison : System.Web.UI.Page
    {
        private static bool transferAllCheck = true;
        private static bool isFirstTransfer = true;

        public static bool TransferAllCheck
        {
            get
            {
                return transferAllCheck;
            }

            set
            {
                transferAllCheck = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            refreshGrid();
            if (!IsPostBack)
            {
                inputNormalCode.Value = TempVendor_BLL.getNormalCode(Session["apTempVendorID"].ToString());
            }
            else
            {

            }
        }

        /// <summary>
        /// 给左右两个grid绑定数据，转移按钮下的功能执行一次之后立刻更新grid内的状态
        /// </summary>
        private void refreshGrid()
        {
            //args
            string tempVendorID = Session["apTempVendorID"].ToString();
            string normalID = TempVendor_BLL.getNormalCode(tempVendorID);

            //manageSystem
            PagedDataSource manageSystemSource = new PagedDataSource();
            manageSystemSource.DataSource = SelectForm_BLL.selecManageFile(string.Format("select * from itemList where Vender_Code='{0}' AND (Item_Plant='{1}' or Item_Plant='ALL')", normalID, Session["Factory_Name"].ToString()));
            manageSystemGrid.DataSource = manageSystemSource;
            manageSystemGrid.DataBind();
            if (manageSystemSource.Count>0)
            {
                isFirstTransfer = false;
            }
            else
            {
                isFirstTransfer = true;
                LocalScriptManager.createManagerScript(Page, "messageConfirmNone('此供应商不存在于管理系统，第一次执行转移需要进行全局检查（所有文件默认全部勾选，执行审批结果完整性和必要文件完整性检查）')", "msgFirst");
                LocalScriptManager.CreateScript(Page, "CheckAllThenBlock()", "blockCheck");
            }

            //assessSystem 选择管理系统中不存在的所有文件 转移打勾的
            PagedDataSource assessSystemSource = new PagedDataSource();
            assessSystemSource.DataSource = SelectForm_BLL.selectAssessFile(string.Format("select * from View_All_File Where Temp_Vendor_ID='{0}' AND (Factory_Name='{1}' or Factory_Name='ALL')", tempVendorID, Session["Factory_Name"].ToString()), normalID, tempVendorID);
            assessSystemGrid.DataSource = assessSystemSource;
            assessSystemGrid.DataBind();
        }

        protected void btnAddFile_Click(object sender, EventArgs e)
        {
            /*
             * 如果fileoverdue中有此id对应的hold状态，进行file类型转移
             *否则检查formoverdue中是否有hold状态，进行form转移
             * 否则执行全转移
             */
            string factory = Session["Factory_Name"].ToString();
            string tempVendorID = Session["apTempVendorID"].ToString();
            string[] options = hiddenArgs.Value.ToString().Split('&');
            string code = options[0];
            string transferResult = "";

            //change mode
            File_Transform_BLL.mode = options[1];

            if (!isFirstTransfer)  //无检查转移
            {
                Dictionary<string, string> dc = getAssessGridSelection();
                if (dc.Count > 0)
                {
                    string vendorName = TempVendor_BLL.getTempVendorName(tempVendorID);
                    string vendorType = TempVendor_BLL.getTempVendorType(tempVendorID);
                    transferResult = File_Transform_BLL.vendorUncheckTransform(dc, tempVendorID, factory, code, Properties.Settings.Default.Transfer_Dest_Path, Session["Employee_ID"].ToString().Trim());
                    File_Transform_BLL.addVendorPlantInfo(code, factory, vendorType, "Enable");
                    File_Transform_BLL.addNormalCode(code, vendorName);
                    refreshGrid();

                    //调用存储过程 添加新的三张表

                    //File_Transform_BLL.addNewForms(tempVendorID, factory);

                    UpdatePanelLeft.Update();
                    UpdatePanelRight.Update();
                }
                else
                {
                    transferResult = "请选择文件";
                }
            }
            else
            {
                //检查必选文件 并且没有表在审批
                if (!File_Transform_BLL.checkFileSubmit(tempVendorID, factory))
                {
                    LocalScriptManager.createManagerScript(Page, "messageConfirmNone('请补充上传所有“必须”类型的文件')", "filemsg");
                    if (withOutAccess(factory, tempVendorID))
                    {
                        LocalScriptManager.createManagerScript(Page, "messageConfirmNone('请完成已提交表格的审批')", "formmsg");
                    }
                }
                else
                {
                    Dictionary<string, string> dc = getAssessGridSelection();
                    if (dc.Count > 0)
                    {
                        transferResult = File_Transform_BLL.vendorUncheckTransform(dc, tempVendorID, factory, code, Properties.Settings.Default.Transfer_Dest_Path, Session["Employee_ID"].ToString().Trim());
                        //添加到vendorList,venderPlantInfo中  
                        string vendorName = TempVendor_BLL.getTempVendorName(tempVendorID);
                        string vendorType = TempVendor_BLL.getTempVendorType(tempVendorID);
                        insertNormalCode(code, tempVendorID);
                        File_Transform_BLL.addVendorPlantInfo(code, factory, vendorType, "Enable");
                        File_Transform_BLL.addNormalCode(code, vendorName);


                        File_Transform_BLL.addNewForms(tempVendorID, factory);

                        refreshGrid();
                        UpdatePanelLeft.Update();
                        UpdatePanelRight.Update();
                    }
                    else
                    {
                        transferResult = "请选择文件";
                    }

                    refreshGrid();
                }
            }

            //Refresh All Grid To Show current state of table


            if (transferResult == "")
            {
                LocalScriptManager.createManagerScript(Page, "messageConfirmNone('已将最新的文件更新到供应商管理系统')", "filemsg1");
            }
            else if (transferResult == null)
            {
                LocalScriptManager.createManagerScript(Page, "messageConfirmNone('文件更新到供应商管理系统时出错，" + transferResult + "')", "filemsg1");
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


        private bool withOutAccess(string factory, string temp_vendor_ID)
        {
            return FormType_BLL.withOutAccess(factory, temp_vendor_ID);
        }

        private string insertNormalCode(string code, string tempVendorID)
        {
            if (TempVendor_BLL.hasNormalCode(tempVendorID))
            {
                return "CODE_EXIST";
            }
            else
            {
                if (File_Transform_DAL.insertNormalCode(code, tempVendorID))
                {
                    return "";
                }
                else
                {
                    return "CODE_UPDATE_FAIL";
                }
            }
        }

        private Dictionary<string, string> getAssessGridSelection()
        {
            Dictionary<string, string> dc = new Dictionary<string, string>();
            HtmlInputCheckBox check = null;
            List<As_File> dt = (List<As_File>)((PagedDataSource)assessSystemGrid.DataSource).DataSource;
            string[] args = new string[8];

            foreach (GridViewRow row in assessSystemGrid.Rows)
            {
                check = (row.Cells[0].FindControl("assessCheck") as HtmlInputCheckBox);
                if (Request[check.Name] != null && Request[check.Name].Equals("on"))
                {
                    args[0] = dt[row.RowIndex].File_Path;
                    args[1] = dt[row.RowIndex].Is_Shared.ToString();
                    args[2] = dt[row.RowIndex].File_Type_ID;
                    args[3] = dt[row.RowIndex].File_Type_Range;
                    args[4] = dt[row.RowIndex].File_Enable_Time;
                    args[5] = dt[row.RowIndex].File_Due_Time;
                    args[6] = dt[row.RowIndex].File_Type_Name;
                    args[7] = dt[row.RowIndex].Source_From;
                    dc.Add(dt[row.RowIndex].File_ID, String.Join("&", args));
                }
            }
            return dc;
        }
    }
}