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
using WebLearning.BLL;
using WebLearning.DAL;

namespace WebLearning.KeLe
{
    public partial class VendorModifyView : System.Web.UI.Page
    {

        private static string vendor_Name = "";
        private static string vendor_type = "";
        private static string tempVendorID = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
            else
            {
                switch (Request["__EVENTTARGET"])
                {
                    case "getVendorInfo":
                        getVendorInfo(Request.Form["__EVENTARGUMENT"], vendor_Name);
                        break;
                    case "getVendorType":
                        getVendorTypeInfo(Request.Form["__EVENTARGUMENT"]);
                        break;
                    case "wait":
                        flush(Request.Form["__EVENTARGUMENT"]);
                        break;
                    case "Selected":
                        selectionSure();
                        break;
                    default:
                        break;
                }
            }
        }


        /// <summary>
        /// 查询该供应商存在几个类型
        /// </summary>
        /// <param name="vendorCode"></param>
        private void getVendorTypeInfo(string vendorName)
        {
            vendor_Name = vendorName;
            As_Temp_Vendor temp = Vendor_Modify_File_BLL.getTempVendorInfo(vendor_Name);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string tempVendorString = jss.Serialize(temp);
            LocalScriptManager.CreateScript(Page, "showVendorTypeInfo('" + tempVendorString + "')", "showTypeInfo");
            if (temp.VendorTypeOne!=null && temp.VendorTypeOne.Equals("直接物料常规"))
            {
                type1.Visible = true;
            }
            if (temp.VendorTypeTwo != null && temp.VendorTypeTwo.Equals("直接物料危化品"))
            {
                type2.Visible = true;
            }
            if (temp.VendorTypeThree != null && temp.VendorTypeThree.Equals("非生产性特种劳防品"))
            {
                type3.Visible = true;
            }
            if (temp.VendorTypeFour != null && temp.VendorTypeFour.Equals("非生产性危化品"))
            {
                type4.Visible = true;
            }
            if (temp.VendorTypeFive != null && temp.VendorTypeFive.Equals("非生产性常规"))
            {
                type5.Visible = true;
            }
            if (temp.VendorTypeSix != null && temp.VendorTypeSix.Equals("非生产性质量部有标准的物料"))
            {
                type6.Visible = true;
            }
        }

        private void getVendorInfo(string vendorType,string vendor_Name)
        {
            string temp_Vendor_ID = TempVendor_BLL.getTempVendorIDByCodeAndType(vendor_Name, vendorType);
            tempVendorID = temp_Vendor_ID;
            Session["tempVendorID"] = temp_Vendor_ID;
            string isChanging = Vendor_Modify_File_BLL.isVendorChanging(vendor_Name, vendorType);
            if (isChanging.Equals("YES"))//正在修改中 即已经建立过修改流程了
            {
                ClientScript.RegisterStartupScript(this.GetType(), "change", "<script>isChanging('"+ temp_Vendor_ID+"');</script>");
                return;
            }
            As_Vendor_Modify_Info tempVendor = new As_Vendor_Modify_Info();
            tempVendor = TempVendor_BLL.getTempVendorByVendorCode(temp_Vendor_ID);
            JavaScriptSerializer js = new JavaScriptSerializer();
            string jsonString = js.Serialize(tempVendor);
            ClientScript.RegisterStartupScript(this.GetType(), "myscript", "<script>showVendorInfo('"+ jsonString + "');</script>");


            List<string> myTypeList = Vendor_Modify_File_DAL.getTypeListByName(vendor_Name);
            for (int i = 0; i < DropDownList1.Items.Count; i++)
            {
                if (isExistsType(DropDownList1.Items[i].Value, myTypeList))
                {
                    //DropDownList2.Items.Add(DropDownList1.Items[i].Value);
                    DropDownList1.Items.Remove(DropDownList1.Items[i].Value);
                    i--;
                }
            }
            //默认为第一个
            //if (DropDownList2 != null && DropDownList2.Items.Count > 0)
            //{
            //    DropDownList2.SelectedIndex = 0;
            //}
            LocalScriptManager.CreateScript(Page, "close()", "close");
        }


       /// <summary>
       /// 显示提示信息
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {

            //执行存储过程并初始化一些文件等等
            selectionSure();

            if (!checkType.Checked)//不可见
            {
                //供应商类型更新 新建了类型 直接跳转到VendorEmployee.aspx
                Response.Redirect("EmployeeVendor.aspx");
            }

            bool legalPerson = !faren.Checked;
            bool range = workRangeSwitch.Checked;
            bool stock = stockSwitch.Checked;
            bool place = workPlaceSwitch.Checked;
            bool partTwo = partTwoSwitch.Checked;
            bool partThree = partThreeSwitch.Checked;
            bool partFour = partFourSwitch.Checked;

            if (!faren.Checked)//法人更改 直接跳转新建
            {
                Response.Redirect("VendorInfo.aspx");
            }
            else
            {
                //get传递参数
                Response.Redirect("FileUpload.aspx?legalPerson=" + legalPerson + "&range=" + range + "&stock=" + stock + "&place=" + place + "&partTwo=" + partTwo + "&partThree=" + partThree + "&partFour=" + partFour + "&temp_vendor_id=" + tempVendorID);
            }
        }

        private void selectionSure()
        {

            string temp_Vendor_Name = vendor_Name;//供应商名称
            string newVendor_Type = "";
            //string oldVendor_Type = DropDownList2.SelectedValue.Trim();//原供应类型
            string oldVendor_Type = vendor_type;
            if (checkType.Checked)//不可见
            {
                newVendor_Type = oldVendor_Type; //新供应商类型
            }
            else
            {
                newVendor_Type = DropDownList1.SelectedValue.Trim();
            }
            string purchase_Money = Purchase_Money.Text.Trim();//金额
            bool promise = Promise.Checked;//承诺
            bool advance_charge = Advance_Charge.Checked;//预付款
            bool vendor_Assign = Vendor_Assign.Checked;//指定
            string factory_Name = Session["Factory_Name"].ToString();
            int money = 0;
            try
            {
                money = Convert.ToInt32(purchase_Money);
            }
            catch
            {
                return;
            }
            //插入到新的表中 保存相应的信息 最后审批完成之后执行一个存储过程



            //执行存储过程 将新的需要填写的表或提交的文件插入表
            //供应商类型类型更改后  是否需要填写修改表 一般修改之后本公司都是需要修改的 
            string newTemp_Vendor_ID = VendorCheckResult_BLL.modify_CheckResult("vendor_Modify_exist", temp_Vendor_Name, factory_Name, newVendor_Type,oldVendor_Type, promise, vendor_Assign, advance_charge, money,Session["Employee_ID"].ToString().Trim());
            //进入文件上传界面 上传vendorModify填写表格的必须文件 

            //获取提示信息
            ClientScript.RegisterStartupScript(this.GetType(), "my", "<script>popTips('"+ newTemp_Vendor_ID + "','"+factory_Name+"');</script>");

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void flush(string vendorName)
        {
            vendor_Name = vendorName;
            LocalScriptManager.CreateScript(Page, "waiting('正在加载页面')", "wait");
            List<string> myTypeList = Vendor_Modify_File_DAL.getTypeListByName(vendorName);
            for (int i = 0; i < DropDownList1.Items.Count; i++)
            {
                if (isExistsType(DropDownList1.Items[i].Value, myTypeList))
                {
                    //DropDownList2.Items.Add(DropDownList1.Items[i].Value);
                    DropDownList1.Items.Remove(DropDownList1.Items[i].Value);
                    i--;
                }
            }
            LocalScriptManager.CreateScript(Page, "close()", "close");
        }


        /// <summary>
        /// 判断是否包含指定的类型
        /// </summary>
        /// <param name="type"></param>
        /// <param name="myTypeList"></param>
        /// <returns></returns>
        private bool isExistsType(string type, List<string> myTypeList)
        {
            if (myTypeList.Count > 0)
            {
                foreach (string myType in myTypeList)
                {
                    if (myType.Equals(type))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        protected void types1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            //初始化选择的供应商类型
            vendor_type = btn.Text.ToString().Trim();
            getVendorInfo(btn.Text.ToString().Trim(), vendor_Name);
        }
    }
}