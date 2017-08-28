using BLL;
using BLL.VendorAssess;
using Model;
using MODEL.VendorAssess;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace SHZSZHSUPPLY.VendorAssess
{
    public partial class FormOverDue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            string formid = GridView1.Rows[drv.RowIndex].Cells[0].Text;
            string temp_Vendor_ID = GridView1.Rows[drv.RowIndex].Cells[1].Text;
            string optional = GridView1.Rows[drv.RowIndex].Cells[2].Text;//可选与必选
            string status= GridView1.Rows[drv.RowIndex].Cells[3].Text;//状态标志  如果为审批中 无法再次重填
            string submit = "";//提交的顺序控制
            string aimPageName = "";
            
            /*
             *
             *
             *获取gridview中的所有表的优先级  
             * 通过formID获取优先级  
             * 
             * 
             */
            if (status == "审批中")
            {
                //弹窗提示
                //LocalScriptManager.CreateScript(Page, "messageBox('已经在审批中，不能重新填写！');", "test");
                return;
            }
            string form_Type_ID = AddForm_BLL.GetForm_Type_ID(formid);
            int selectedFormPriorityNumber = getSelectedFormPriorityNumber(form_Type_ID);
            //string form_Type_ID = "004";
            //int selectedFormPriorityNumber = 4;
            if (optional == "可选")
            {
                if (withOutAccess(selectedFormPriorityNumber, temp_Vendor_ID) && isOptionalMinimum(selectedFormPriorityNumber, temp_Vendor_ID) && isRequiredMinimum(selectedFormPriorityNumber, temp_Vendor_ID))
                {
                    submit = "yes";
                }
                else
                {
                    submit = "no";
                }
            }
            if (optional == "必选")
            {
                if (isMinimum(selectedFormPriorityNumber,temp_Vendor_ID))
                {
                    submit = "yes";
                }
                else
                {
                    submit = "no";
                }
            }
            if (e.CommandName == "refill")
            {
                if (formid.Contains("BiddingForm"))//比价表
                {
                    As_Bidding_Approval bidding = new As_Bidding_Approval();
                    As_Bidding_Approval newbidding = new As_Bidding_Approval();
                    bidding = As_Bidding_Approval_BLL.getBiddingForm(formid);
                    newbidding.Form_ID = bidding.Form_ID;//上一张表的值复制与不复制问题不大  Form_ID需要  但触发器会将其改掉  所以值无所谓
                    newbidding.Form_Type_ID = bidding.Form_Type_ID;
                    newbidding.Flag = 0;
                    As_Bidding_Approval_BLL.addBiddingForm(newbidding);//添加纪录 当查找的时候会找到最新的这张表
                    /*
                     * 新表绑定原来的文件：
                     * 1.通过原来的formID 在As_Form_File中查出需要绑定的文件 因为是表过期，文件是不用动的
                     * 2.获取新的form_ID
                     * 3.添加新的form_ID与对应文件进行绑定
                     */
                    As_New_Forms news = new As_New_Forms();
                    news.Factory_Name = DropDownList1.SelectedValue.ToString().Trim();
                    news.Form_Name = FormType_BLL.getFormNameByTypeID(newbidding.Form_Type_ID);
                    news.Temp_Vendor_ID = bidding.Temp_Vendor_ID;
                    string form_ID = NewForms_BLL.getNewFormID(news);//新的form_ID
                    FormFile_BLL.dataReBind(form_ID, bidding.Temp_Vendor_ID, bidding.Form_ID);//这一步 在进入表的时候会自动绑定一次

                    //添加到As_Vendor_Form_Type;
                    //As_Vendor_Form_Type vendor = new As_Vendor_Form_Type();
                    //vendor.Temp_Vendor_ID = bidding.Temp_Vendor_ID;
                    //vendor.Temp_Vendor_Name = TempVendor_BLL.getTempVendorName(bidding.Temp_Vendor_ID);
                    //vendor.Factory_Name = DropDownList1.SelectedValue;
                    //vendor.Form_Type_ID = newbidding.Form_Type_ID;
                    //vendor.Form_Type_Name = news.Form_Name;
                    //vendor.Form_ID = form_ID;
                    //vendor.Flag = 0;
                    //FormOverDue_BLL.addVendorFormType(vendor);//触发器会将原来的插入到history中
                    //update As_Vendor_Formtype中的form_ID
                    aimPageName = "BiddingApprovalForm.aspx";
                }
                if (formid.Contains("VendorDiscovery"))//比价表
                {
                    As_Vendor_Discovery bidding = new As_Vendor_Discovery();
                    As_Vendor_Discovery newbidding = new As_Vendor_Discovery();
                    bidding = VendorDiscovery_BLL.checkFlag(formid);
                    newbidding.Form_ID = bidding.Form_ID;//上一张表的值复制与不复制问题不大  Form_ID需要  但触发器会将其改掉  所以值无所谓
                    newbidding.Form_Type_ID = bidding.Form_Type_ID;
                    newbidding.Temp_Vendor_Name = bidding.Temp_Vendor_Name;
                    newbidding.Temp_Vendor_ID = bidding.Temp_Vendor_ID;
                    newbidding.Factory_Name = bidding.Factory_Name;
                    newbidding.Flag = 0;
                    VendorDiscovery_BLL.addVendorDiscovery(newbidding);//添加纪录 当查找的时候会找到最新的这张表
                    /*
                     * 新表绑定原来的文件：
                     * 1.通过原来的formID 在As_Form_File中查出需要绑定的文件 因为是表过期，文件是不用动的
                     * 2.获取新的form_ID
                     * 3.添加新的form_ID与对应文件进行绑定
                     */
                    As_New_Forms news = new As_New_Forms();
                    news.Factory_Name = DropDownList1.SelectedValue.ToString().Trim();
                    news.Form_Name = FormType_BLL.getFormNameByTypeID(newbidding.Form_Type_ID);
                    news.Temp_Vendor_ID = bidding.Temp_Vendor_ID;
                    string form_ID = NewForms_BLL.getNewFormID(news);//新的form_ID
                    FormFile_BLL.dataReBind(form_ID, bidding.Temp_Vendor_ID, bidding.Form_ID);//这一步 在进入表的时候会自动绑定一次

                    //添加到As_Vendor_Form_Type;
                    //As_Vendor_Form_Type vendor = new As_Vendor_Form_Type();
                    //vendor.Temp_Vendor_ID = bidding.Temp_Vendor_ID;
                    //vendor.Temp_Vendor_Name = TempVendor_BLL.getTempVendorName(bidding.Temp_Vendor_ID);
                    //vendor.Factory_Name = DropDownList1.SelectedValue;
                    //vendor.Form_Type_ID = newbidding.Form_Type_ID;
                    //vendor.Form_Type_Name = news.Form_Name;
                    //vendor.Form_ID = form_ID;
                    //vendor.Flag = 0;
                    //FormOverDue_BLL.addVendorFormType(vendor);//触发器会将原来的插入到history中
                    //update As_Vendor_Formtype中的form_ID
                    aimPageName = "VendorDiscovery.aspx";
                }
                if (formid.Contains("VendorDesignated"))//指定供应商申请表
                {
                    As_Vendor_Designated_Apply vendor = new As_Vendor_Designated_Apply();
                    As_Vendor_Designated_Apply newvendor = new As_Vendor_Designated_Apply();
                    vendor = As_Vendor_Designated_Apply_BLL.checkFlag(formid);
                    newvendor.Form_id = vendor.Form_id;
                    newvendor.VendorName = TempVendor_BLL.getTempVendorName(temp_Vendor_ID);
                    newvendor.Form_Type_ID = vendor.Form_Type_ID;
                    newvendor.Temp_Vendor_ID = TextBox1.Text.ToString().Trim();
                    newvendor.Flag = 0;

                    As_Vendor_Designated_Apply_BLL.addForm(newvendor);//添加纪录 当查找的时候会找到最新的这张表
                    As_New_Forms news = new As_New_Forms();
                    news.Factory_Name = DropDownList1.SelectedValue.ToString().Trim();
                    news.Form_Name = FormType_BLL.getFormNameByTypeID(newvendor.Form_Type_ID);
                    news.Temp_Vendor_ID = vendor.Temp_Vendor_ID;
                    string form_ID = NewForms_BLL.getNewFormID(news);//新的form_ID
                    FormFile_BLL.dataReBind(form_ID, vendor.Temp_Vendor_ID, vendor.Form_id);//这一步 在进入表的时候会自动绑定一次

                    //添加到As_Vendor_Form_Type;
                    //As_Vendor_Form_Type vendors = new As_Vendor_Form_Type();
                    //vendors.Temp_Vendor_ID = vendor.Temp_Vendor_ID;
                    //vendors.Temp_Vendor_Name = TempVendor_BLL.getTempVendorName(vendor.Temp_Vendor_ID);
                    //vendors.Factory_Name = DropDownList1.SelectedValue;
                    //vendors.Form_Type_ID = newvendor.Form_Type_ID;
                    //vendors.Form_Type_Name = news.Form_Name;
                    //vendors.Form_ID = form_ID;
                    //vendors.Flag = 0;
                    //FormOverDue_BLL.addVendorFormType(vendors);
                    aimPageName = "VendorDesignatedApply.aspx";        
                }
                /*
                 * 
                 * 原来传递的时候有type 不清楚是干什么的 貌似也没有用到  这里暂时不传递type
                 */
                Response.Redirect(aimPageName + "?submit=" + submit + "&type=" + form_Type_ID);
            }
        }

        protected void search_Click(object sender, EventArgs e)
        {
            string Temp_Vendor_ID = this.TextBox1.Text.ToString().Trim();
            if (Temp_Vendor_ID != null)//通过VendorID来加载数据库中该供应商的过期文件
            {
                PagedDataSource dataSource = new PagedDataSource();
                dataSource.DataSource = FormOverDue_BLL.getOverDueForm(Temp_Vendor_ID,DropDownList1.SelectedValue);
                GridView1.DataSource = dataSource;
                GridView1.DataBind();
                Session["tempVendorID"]= this.TextBox1.Text.ToString().Trim();
            }
        }

        private bool withOutAccess(int number, string temp_vendor_ID)
        {
            return FormType_BLL.withOutAccess(number, temp_vendor_ID);
        }
        private bool isOptionalMinimum(int number, string temp_Vendor_ID)
        {
            return FormType_BLL.isOptionalMinimum(number, temp_Vendor_ID);
        }
        private bool isRequiredMinimum(int number, string temp_Vendor_ID)//可选表前面的必须表都已经审完
        {
            return FormType_BLL.isRequiredMinimum(number, temp_Vendor_ID);
        }
        private int getSelectedFormPriorityNumber(string formTypeID)
        {
            return FormType_BLL.getSelectedFormPriorityNumber(formTypeID);
        }
        private bool isMinimum(int number, string temp_Vendor_ID)
        {
            bool ok = withOutAccess(number, temp_Vendor_ID);
            if (ok)
            {
                return FormType_BLL.isMinimumFormPriorityNumber(number, temp_Vendor_ID);
            }
            else
            {
                return false;
            }

        }
    }
}