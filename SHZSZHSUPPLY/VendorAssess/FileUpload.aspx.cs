using BLL;
using DAL;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using WebLearning.BLL;
using WebLearning.Model;

namespace WebLearning.KeLe
{
    public partial class ModifySelection : System.Web.UI.Page
    {
        private string leagalPerson;//法人是否更改
        private string range;//经营范围
        private string stocks;//股份
        private string place;//营业场所
        private string namePartTwoSwitch;
        private string namePartThreeSwitch;
        private string namePartFourSwitch;

        private static string temp_Vendor_Name;
        private static string temp_vendor_ID;
        private static string factory_Name;
        private IList<Vendor_Modify_File> fileList = new List<Vendor_Modify_File>();

        protected void Page_Load(object sender, EventArgs e)
        {
            //获取所有的操作选项 并添加对应的需要上传的文件
            if (!IsPostBack)
            {
                leagalPerson = getOperation(Request.QueryString["legalPerson"]);
                range = getOperation(Request.QueryString["range"]);
                stocks = getOperation(Request.QueryString["stock"]);
                place = getOperation(Request.QueryString["place"]);
                namePartTwoSwitch = getOperation(Request.QueryString["PartTwo"]);
                namePartThreeSwitch = getOperation(Request.QueryString["PartThree"]);
                namePartFourSwitch = getOperation(Request.QueryString["PartFour"]);
                if (leagalPerson.Equals("null") && range.Equals("null") && stocks.Equals("null") && place.Equals("null") && namePartTwoSwitch.Equals("null") && namePartThreeSwitch.Equals("null") && namePartFourSwitch.Equals("null"))//从已新建跳转过来
                {
                    temp_vendor_ID = Request.QueryString["temp_vendor_id"].ToString().Trim();
                    factory_Name = Session["Factory_Name"].ToString();
                    refreshVendor();
                    return;
                }
                temp_vendor_ID = Request.QueryString["temp_vendor_id"].ToString().Trim();
                temp_Vendor_Name = TempVendor_BLL.getTempVendorName(temp_vendor_ID);
                factory_Name = Session["Factory_Name"].ToString();
                // 执行存储过程    向数据库As_Vendor_Modify_Info写入选择记录  并生成需要上传的文件列表到As_Vendor_Modify_File

                //判断该类型是否已经存在修改记录了 在类型不改变的情况下该factory的 Temp_Vendor_ID将不会发生改变
                //如果存在temp_Vendor_ID 则将status置为old 新插入的为new  

                if (!getTempVendorID(factory_Name, temp_vendor_ID))
                {
                    updateVendorModifyFile(temp_vendor_ID, factory_Name);
                }

                Vendor_Modify_File_BLL.initVendorFile(getSelectionData());

                //获取新文件的上传列表  并显示  提供上传按钮以供上传 上传后刷新界面 如果所有文件都已经提交  那么显示 修改按钮 点击进入供应商信息修改表
                refreshVendor();
            }
            else
            {
                //处理post回调
                switch (Request["__EVENTTARGET"])
                {
                    case "refreshVendor":
                        refreshVendor();//刷新
                        break;
                    default:
                        break;
                }
            }
        }

        private void updateVendorModifyFile(string temp_vendor_ID, string factory_Name)
        {
            string sql = "update As_Vendor_Modify_File set Status='old' where Temp_Vendor_ID='" + temp_vendor_ID + "' and Factory_Name='" + factory_Name + "'";
            DBHelp.ExecuteCommand(sql);
        }

        private bool getTempVendorID(string factory_Name, string temp_vendor_ID)
        {
            string sql = "select File_Type_ID from As_Vendor_Modify_File where Temp_Vendor_ID='" + temp_vendor_ID + "' and Factory_Name='" + factory_Name + "' and Status='new'";
            using (SqlDataReader reader = DBHelp.GetReader(sql))
            {
                if (reader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }



        //获取每项操作的值
        private string getOperation(string checks)
        {
            try
            {
                if (checks.Equals("True"))
                {
                    return "true";
                }
                else
                {
                    return "false";
                }
            }
            catch
            {
                return "null";
            }
        }

        private void initGridView(string temp_Vendor_ID, string factory_Name)
        {
            fileList = BLL.Vendor_Modify_File_BLL.getFileList(temp_Vendor_ID, factory_Name);
            GridView1.DataSource = fileList;
            GridView1.DataBind();
        }


        //刷新页面
        private void refreshVendor()
        {
            initGridView(temp_vendor_ID, factory_Name);
            //显示开始修改按钮
            showModifyButton(temp_vendor_ID, factory_Name);
        }


        /// <summary>
        /// 判断所有需要上传的文件是否都已经上传 
        /// </summary>
        private void showModifyButton(string tempVendorID, string factory_Name)
        {
            bool ok= Vendor_Modify_File_BLL.isFilesUpload(tempVendorID, factory_Name);
            if (ok)//ok表示文件都已经上传完成
            {
                //如果已经提交过这张表，则直接提示点击查看已提交的表格
                if (vendorModifyIsSubmit(temp_vendor_ID))
                {
                    LocalScriptManager.CreateScript(Page, "showModifyDetail()", "showModifyDetails");
                }
                else
                {
                    LocalScriptManager.CreateScript(Page, "showButton()", "button");
                }
            }
        }

        //有哪些文件需要替换As_File中已经上传过的文件  ( 新上传的文件 )
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            string requestType = "modifyFileUpload";
            string temp_Vendor_Name = GridView1.Rows[drv.RowIndex].Cells[0].Text.ToString().Trim();
            string temp_Vendor_ID = TempVendor_BLL.getTempVendorID(temp_Vendor_Name);
            string file_Type_Name = GridView1.Rows[drv.RowIndex].Cells[2].Text.ToString().Trim();
            string file_Type_ID = File_Type_BLL.getFileTypeIDByItemCategory(file_Type_Name);
            if (e.CommandName.Equals("upload"))//重新上传文件
            {
                LocalScriptManager.CreateScript(Page, String.Format("uploadFile('{0}','{1}','{2}','{3}',{4})", requestType, temp_Vendor_ID, temp_Vendor_Name, file_Type_ID, ""), "upload");
            }
        }


        private Dictionary<string, string> getSelectionData()
        {
            Dictionary<string, string> dc = new Dictionary<string, string>();
            dc.Add("leagalPerson", leagalPerson);
            dc.Add("range", range);
            dc.Add("stocks", stocks);
            dc.Add("place", place);
            dc.Add("namePartTwoSwitch", namePartTwoSwitch);
            dc.Add("namePartThreeSwitch", namePartThreeSwitch);
            dc.Add("namePartFourSwitch", namePartFourSwitch);
            dc.Add("temp_vendor_ID", temp_vendor_ID);
            dc.Add("factory_Name", factory_Name);
            return dc;
        }

        protected void startModify_Click(object sender, EventArgs e)
        {
            Response.Redirect("VendorModify.aspx?temp_Vendor_ID="+temp_vendor_ID);
        }

        /// <summary>
        /// 判断对应的类型的供应商是否已经提交过表格
        /// </summary>
        /// <param name="temp_vendor_ID"></param>
        private bool vendorModifyIsSubmit(string temp_vendor_ID)
        {
            return Vendor_Modify_File_BLL.vendorModifyIsSubmit(temp_vendor_ID);
        }


        /// <summary>
        /// 进入show页面查看  或者进入供应商文件管理界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void showDetail_Click(object sender, EventArgs e)
        {
            Session["formID"] = Vendor_Modify_File_BLL.getModifyFormID(temp_vendor_ID);
            Response.Redirect("ShowVendorModify.aspx?type=020");
        }
    }
}