using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

namespace VendorAssess
{
    public partial class VendorDesignatedApply : System.Web.UI.Page
    {
        private static string vendername;//在页面加载的时候初始化为临时供应商名称 防止session过期
        private As_Vendor_Designated_Apply form;//在Page_Load中被初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            form = new As_Vendor_Designated_Apply();
            //供应商名称由session获得 不可编辑
            if (!IsPostBack)
            {
                string formid = null;
                string tempvendorname = null;
                tempvendorname = Session["tempvendorname"].ToString();//session赋值
                form.VendorName = tempvendorname;//临时供应商名称
                vendername = tempvendorname;
                formid = tempvendorname + "指定供应商申请表PR-05-10-2";

                int updateFlag = UpdateFlag_BLL.updateFlag("004", tempvendorname);//

                As_Vendor_Discovery Vendor_Discovery = new As_Vendor_Discovery();
                As_Form forms = new As_Form();
                forms.Form_ID = formid;
                forms.Form_Name = "指定供应商申请表";
                forms.Form_Type_ID = "004";
                forms.Temp_Vendor_Name = tempvendorname;
                forms.Form_Path = "";
                //       操作表：As_Form
                int add = AddForm_BLL.addForm(forms);

                TextBox1.Text = tempvendorname;//
                TextBox1.ReadOnly = true;
                InitWholeForm();
            }
        }
        private void InitWholeForm()//从数据库初始化整个数据表
        {
            string vendorname= Session["tempvendorname"].ToString();
            form = As_Vendor_Designated_Apply_BLL.GetWholeFormInfo(vendorname);
            TextBox2.Text = form.SAPCode1;
            TextBox3.Text = form.BusinessCategory;
            TextBox4.Text = form.EffectiveTime.ToString();
            //TextBox5.Text = form.PurchaseAmount;
            //TextBox6.Text = form.Reason;
            //TextBox7.Text = form.Initiator;
            //TextBox8.Text = form.Date.ToString();
            //TextBox9.Text = form.Applicant;
            //TextBox10.Text = form.RequestDeptHead;
            //TextBox11.Text = form.FinManager;
            //TextBox12.Text = form.ApplicantDate.ToString();
            //TextBox13.Text = form.RequestDeptHeadDate.ToString();
            //TextBox14.Text = form.FinManagerDate.ToString();
            //TextBox15.Text = form.PurchasingManager;
            //TextBox16.Text = form.GM1;
            //TextBox17.Text = form.PurchasingManagerDtae.ToString();
            //TextBox18.Text = form.GMDate1.ToString();
            //TextBox19.Text = form.Director;
            //TextBox20.Text = form.SupplyChainDirector;
            //TextBox21.Text = form.DirectorDtae.ToString();
            //TextBox22.Text = form.SupplyChainDirectorDate.ToString();
            //TextBox23.Text = form.Persident;
            //TextBox24.Text = form.FinalDate.ToString();
        }
        private bool SaveWholeForm()//将整个数据表保存到数据库中
        {
            int result = 0;//插入成功后返回1
            form = getThisFormInfo();
            result = As_Vendor_Designated_Apply_BLL.SaveWholeForm(form);//
            if (result == 1)
            {
                return true;//保存成功
            }
            else
            {
                return false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int thisFormID = 0;
            As_Vendor_Designated_Apply form1 = new As_Vendor_Designated_Apply();
            form1 = this.getThisFormInfo();
            thisFormID = As_Vendor_Designated_Apply_BLL.GetAsVendorDesignatedApplyFormID(form1);
            bool ok = false;
            if (thisFormID != 0)//若这个表的ID能查出来 则说明已经填写过该表 点击保存会执行update操作
            {
                ok = UpdateWholeForm();
                if (ok)
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('保存成功！');</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('保存失败！');</script>");
                }
            }
            else
            {
                ok = SaveWholeForm();
                if (ok)
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('保存成功！');</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('保存失败！');</script>");
                }
            }
        }
        private bool UpdateWholeForm()
        {
            int result = 0;//插入成功后返回1
            form.VendorName = Session["tempvendorname"].ToString();//临时供应商名称
            form.SAPCode1 = TextBox2.Text.ToString().Trim();
            form.BusinessCategory = TextBox3.Text.ToString().Trim();
            form.EffectiveTime = DateTime.Now;
            //form.EffectiveTime = DateTime.Parse(TextBox4.Text.ToString().Trim());//将字符转化为datetime类型
            form.PurchaseAmount = TextBox5.Text.ToString().Trim();
            form.Reason = TextBox6.Text.ToString().Trim();
            form.Initiator = TextBox7.Text.ToString().Trim();
            form.Date = DateTime.Now;
            //form.Date = DateTime.Parse(TextBox8.Text.ToString().Trim());
            form.Applicant = TextBox9.Text.ToString().Trim();
            form.RequestDeptHead = TextBox10.Text.ToString().Trim();
            form.FinManager = TextBox11.Text.ToString().Trim();
            form.ApplicantDate = DateTime.Now;
            form.RequestDeptHeadDate = DateTime.Now;
            form.FinManagerDate = DateTime.Now;
            //form.ApplicantDate = DateTime.Parse(TextBox12.Text.ToString().Trim());
            //form.RequestDeptHeadDate = DateTime.Parse(TextBox13.Text.ToString().Trim());
            //form.FinManagerDate = DateTime.Parse(TextBox14.Text.ToString().Trim());
            form.PurchasingManager = TextBox15.Text.ToString().Trim();
            form.GM1 = TextBox16.Text.ToString().Trim();
            form.PurchasingManagerDtae = DateTime.Now;
            form.GMDate1 = DateTime.Now;
            //form.PurchasingManagerDtae = DateTime.Parse(TextBox17.Text.ToString().Trim());
            //form.GMDate1 = DateTime.Parse(TextBox18.Text.ToString().Trim());
            form.Director = TextBox19.Text.ToString().Trim();
            form.SupplyChainDirector = TextBox20.Text.ToString().Trim();
            form.DirectorDtae = DateTime.Now;
            form.SupplyChainDirectorDate = DateTime.Now;
            //form.DirectorDtae = DateTime.Parse(TextBox21.Text.ToString().Trim());
            //form.SupplyChainDirectorDate = DateTime.Parse(TextBox22.Text.ToString().Trim());
            form.PresidenDate = DateTime.Now;
            form.Persident = TextBox23.Text.ToString().Trim();
            form.FinalDate = DateTime.Now;
            //form.FinalDate = DateTime.Parse(TextBox24.Text.ToString().Trim());
            result = As_Vendor_Designated_Apply_BLL.UpdateWholeFormInfo(form);//跟新整个表
            if (result == 1)
            {
                return true;//更新成功
            }
            else
            {
                return false;
            }
        }
        private As_Vendor_Designated_Apply getThisFormInfo()
        {
            form = new As_Vendor_Designated_Apply();
            form.VendorName = Session["tempvendorname"].ToString();//临时供应商名称
            form.SAPCode1 = TextBox2.Text.ToString().Trim();
            form.BusinessCategory = TextBox3.Text.ToString().Trim();
            form.EffectiveTime = DateTime.Now;
            //form.EffectiveTime = DateTime.Parse(TextBox4.Text.ToString().Trim());//将字符转化为datetime类型
            form.PurchaseAmount = TextBox5.Text.ToString().Trim();
            form.Reason = TextBox6.Text.ToString().Trim();
            form.Initiator = TextBox7.Text.ToString().Trim();
            //form.Date = DateTime.Parse(TextBox8.Text.ToString().Trim());
            form.Applicant = TextBox9.Text.ToString().Trim();
            form.RequestDeptHead = TextBox10.Text.ToString().Trim();
            form.FinManager = TextBox11.Text.ToString().Trim();
            //form.ApplicantDate = DateTime.Parse(TextBox12.Text.ToString().Trim());
            //form.RequestDeptHeadDate = DateTime.Parse(TextBox13.Text.ToString().Trim());
            //form.FinManagerDate = DateTime.Parse(TextBox14.Text.ToString().Trim());
            form.PurchasingManager = TextBox15.Text.ToString().Trim();
            form.GM1 = TextBox16.Text.ToString().Trim();
            //form.PurchasingManagerDtae = DateTime.Parse(TextBox17.Text.ToString().Trim());
            //form.GMDate1 = DateTime.Parse(TextBox18.Text.ToString().Trim());
            form.Director = TextBox19.Text.ToString().Trim();
            form.SupplyChainDirector = TextBox20.Text.ToString().Trim();
            //form.DirectorDtae = DateTime.Parse(TextBox21.Text.ToString().Trim());
            //form.SupplyChainDirectorDate = DateTime.Parse(TextBox22.Text.ToString().Trim());
            form.Persident = TextBox23.Text.ToString().Trim();
            //form.FinalDate = DateTime.Parse(TextBox24.Text.ToString().Trim());
            return form;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            As_Vendor_Designated_Apply adva = null;
            adva = this.getThisFormInfo();
            string TempVendorName = vendername;
            string FormID = TempVendorName + "指定供应商申请表PR-05-10-2";//命名
            SaveWholeForm();
            approveaccess("004", FormID);//确定审批的流程 formTypeID为004 表示指定供应商申请表
        }
        private void approveaccess(string formTypeID, string formId)
        {
            string formtypeid = formTypeID;
            As_Assess_Flow assess_flow = new As_Assess_Flow();
            assess_flow = AssessFlow_BLL.getFirstAssessFlow(formtypeid);
            Session["AssessflowInfo"] = assess_flow;
            string i = assess_flow.User_Department_Assess;
            if (i == "1")
            {
                string s_url;
                s_url = "SelectDepartment.aspx?formId=" + formId;
                Response.Redirect(s_url);
            }
        }
    }
}