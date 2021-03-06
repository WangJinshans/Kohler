﻿using BLL;
using BLL.VendorAssess;
using Model;
using MODEL.VendorAssess;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AendorAssess
{
    public partial class BiddingApprovalForm : System.Web.UI.Page
    {
        /// <summary>
        /// 保存当前页面的全局信息
        /// </summary>
        private void getSessionInfo()
        {            
            //保存状态
            ViewState.Add("formTypeID", Request.QueryString["type"]);
            ViewState.Add("formName", FormType_BLL.getFormNameByTypeID(ViewState["formTypeID"].ToString()));
            ViewState.Add("tempVendorID", Session["tempVendorID"].ToString());
            ViewState.Add("tempVendorName", TempVendor_BLL.getTempVendorName(ViewState["tempVendorID"].ToString()));
            ViewState.Add("factoryName", Session["Factory_Name"].ToString().Trim());
            ViewState.Add("submit", Request.QueryString["submit"]);
            ViewState.Add("singleFileSubmit", "false");

            try
            {
                ViewState.Add("form_ID", Request.QueryString["Form_ID"].ToString().Trim());
            }
            catch
            {
                ViewState.Add("form_ID", "");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Image2.Visible = false;
            Image3.Visible = false;
            Image4.Visible = false;//在非show页面中图片控件不可操作

            LocalScriptManager.CreateScript(Page, "initTextarea()", "initTextbox");

            if (!IsPostBack)
            {
                //获取session信息
                getSessionInfo();
                string formID = Convert.ToString(ViewState["form_ID"]);
                int check = As_Bidding_Approval_BLL.checkBiddingForm(formID);//检查是否存在这张表
                if (check == 0)//数据库中不存在这张表，则自动初始化
                {
                    As_Bidding_Approval biddingApproval = new As_Bidding_Approval();
                    biddingApproval.Form_Type_ID = Convert.ToString(ViewState["formTypeID"]);
                    biddingApproval.Temp_Vendor_Name = Convert.ToString(ViewState["tempVendorName"]);
                    biddingApproval.Temp_Vendor_ID = Convert.ToString(ViewState["tempVendorID"]);
                    biddingApproval.Initiator = String.Format(Signature_BLL.urlPath, Session["Employee_ID"]);
                    biddingApproval.Flag = 0;//将表格标志位信息改为已填写
                    biddingApproval.Factory_Name = Session["Factory_Name"].ToString();

                    int n = As_Bidding_Approval_BLL.addBiddingForm(biddingApproval);
                    if (n == 0)
                    {
                        Response.Write("<script>window.alert('表格初始化错误（新建插入失败）！')</script>");
                        return;
                    }
                    else
                    {
                        formID = As_Bidding_Approval_BLL.getVendorBiddingFormID(Convert.ToString(ViewState["tempVendorID"]), Convert.ToString(ViewState["formTypeID"]), Session["Factory_Name"].ToString(), n);
                        ViewState.Add("form_ID", formID);
                        //添加单独绑定的文件
                        VendorSingleFile_BLL.addSingleFile(formID, Convert.ToString(ViewState["formTypeID"]), Convert.ToString(ViewState["tempVendorID"]), Convert.ToString(ViewState["tempVendorName"]), Session["Factory_Name"].ToString(), "012");

                        
                        //每次添加表格添加到As_Vendor_MutipleForm中 
                        As_MutipleForm forms = new As_MutipleForm();
                        forms.Temp_Vendor_ID = Convert.ToString(ViewState["tempVendorID"]);
                        forms.Temp_Vendor_Name = Convert.ToString(ViewState["tempVendorName"]);
                        forms.Form_Type_ID = Convert.ToString(ViewState["formTypeID"]);
                        forms.Form_ID = formID;
                        forms.Flag = 0;
                        forms.Factory_Name = Session["Factory_Name"].ToString();
                        Vendor_MutipleForm_BLL.addVendorMutileForms(forms);


                        //向FormFile表中添加相应的文件、表格绑定信息
                        bindingFormWithFile();
                        showfilelist(formID);
                        showBiddingForm(formID);
                    }
                }
                else
                {
                    showBiddingForm(formID);
                }
            }
            else
            {
                //处理postback回调
                switch (Request["__EVENTTARGET"])
                {
                    case "submitForm":
                        LocalApproveManager.submitForm(Convert.ToString(ViewState["formTypeID"]));
                        break;
                    case "startSelection":
                        string realTypeID = getRealFormTypeID();
                        LocalApproveManager.doApproveWithSelection(Page, Convert.ToString(ViewState["form_ID"]), ViewState["formName"].ToString(), realTypeID, ViewState["tempVendorID"].ToString(), ViewState["tempVendorName"].ToString(), Session["Factory_Name"].ToString());
                        break;
                    case "isPromised":
                        startJudgeMoney(Request["__EVENTARGUMENT"].ToString());//判断金额
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 绑定此表对应的文件信息
        /// </summary>
        public void bindingFormWithFile()
        {
            if (CheckFile_BLL.bindFormFile(Convert.ToString(ViewState["formTypeID"]), Convert.ToString(ViewState["tempVendorID"]), Convert.ToString(ViewState["form_ID"])) == 0)
            {
                Response.Write("<script>window.alert('表格初始化错误（文件绑定失败）！')</script>");//若没有记录 返回文件不全
            }
        }


        private string getRealFormTypeID()
        {
            //获取表类型
            double money = Convert.ToDouble(TextBox4.Text.ToString());

            //表格类型编号
            return As_Bidding_Approval_BLL.getRealFlag(money, Convert.ToString(ViewState["isPromise"]));
        }


        private void startJudgeMoney(string promise)
        {
            ViewState.Add("isPromise", promise);
            //KCI
            bool iskci = false;
            string amount = "150";
            string content = "由于金额小于150万，系统已经自动识别为不需要KCI审批";
            if (promise.Equals("no"))
            {
                amount = "150";
            }
            else
            {
                amount = "60";
            }
            try
            {
                iskci = isKciByMoney(promise);
                
                if (iskci)
                {
                    content = "由于金额大于"+amount+"万，系统已经自动识别为需要KCI审批";
                }
                else
                {
                    content = "由于金额小于" + amount + "万，系统已经自动识别为不需要KCI审批";
                }
                LocalScriptManager.CreateScript(Page, String.Format("iskci('{0}','{1}');", iskci, content), "KCIseslection");
            }
            catch
            {
                LocalScriptManager.CreateScript(Page, "errorMoneyTip();", "errorMoneyTip");
            }
        }

        /// <summary>
        /// 显示表格
        /// </summary>
        private void showBiddingForm(string formID)
        {
            As_Bidding_Approval biddingForm = As_Bidding_Approval_BLL.getBiddingForm(formID);
            if (biddingForm != null)
            {
                TextBox1.Text = biddingForm.Serial_No;
                TextBox2.Text = biddingForm.Date;
                TextBox3.Text = biddingForm.Product;
                TextBox4.Text = biddingForm.Purchase_Amount;
                TextBox5.Text = biddingForm.MOQ1;
                TextBox6.Text = biddingForm.MOQ2;
                TextBox7.Text = biddingForm.MOQ3;
                TextBox8.Text = biddingForm.Lead_Time1;
                TextBox9.Text = biddingForm.Lead_Time2;
                TextBox10.Text = biddingForm.Lead_Time3;
                TextBox11.Text = biddingForm.Payment_Term1;
                TextBox12.Text = biddingForm.Payment_Term2;
                TextBox13.Text = biddingForm.Payment_Term3;
                TextBox14.Text = biddingForm.Remark1;
                TextBox15.Text = biddingForm.Remark2;
                TextBox16.Text = biddingForm.Remark3;
                TextBox17.Text = biddingForm.Reason_One;
                TextBox18.Text = biddingForm.Reason_Two;
                TextBox49.Text = biddingForm.Vendor_Recommend;
                TextBox50.Text = biddingForm.Rank1;
                TextBox51.Text = biddingForm.Rank2;
                TextBox52.Text = biddingForm.Rank3;
                TextBox53.Text = biddingForm.Rank_Remark;
                Image1.ImageUrl = biddingForm.Initiator;
                Image5.ImageUrl = biddingForm.User_Department_Manager;
                hideImage(biddingForm.Supplier_Chain_Leader, Image2);
                hideImage(biddingForm.Finance_Leader, Image3);
                hideImage(biddingForm.Business_Leader, Image4);
                int[] arr = { 0, 0, 0, 0, 0 };
                for (int i = 0; i < biddingForm.ProjectList.Count; i++)
                {
                    arr[i] = 1;
                }
                //list
                if (arr[0] == 1)
                {
                    TextBox19.Text = biddingForm.ProjectList[0].Item;
                    TextBox20.Text = biddingForm.ProjectList[0].Description;
                    TextBox21.Text = biddingForm.ProjectList[0].Price1;
                    TextBox22.Text = biddingForm.ProjectList[0].Price2;
                    TextBox23.Text = biddingForm.ProjectList[0].Price3;
                    TextBox24.Text = biddingForm.ProjectList[0].Remark;
                }
                if (arr[1] == 1)
                {
                    TextBox25.Text = biddingForm.ProjectList[1].Item;
                    TextBox26.Text = biddingForm.ProjectList[1].Description;
                    TextBox27.Text = biddingForm.ProjectList[1].Price1;
                    TextBox28.Text = biddingForm.ProjectList[1].Price2;
                    TextBox29.Text = biddingForm.ProjectList[1].Price3;
                    TextBox30.Text = biddingForm.ProjectList[1].Remark;
                }
                if (arr[2] == 1)
                {
                    TextBox31.Text = biddingForm.ProjectList[2].Item;
                    TextBox32.Text = biddingForm.ProjectList[2].Description;
                    TextBox33.Text = biddingForm.ProjectList[2].Price1;
                    TextBox34.Text = biddingForm.ProjectList[2].Price2;
                    TextBox35.Text = biddingForm.ProjectList[2].Price3;
                    TextBox36.Text = biddingForm.ProjectList[2].Remark;
                }
                if (arr[3] == 1)
                {
                    TextBox37.Text = biddingForm.ProjectList[3].Item;
                    TextBox38.Text = biddingForm.ProjectList[3].Description;
                    TextBox39.Text = biddingForm.ProjectList[3].Price1;
                    TextBox40.Text = biddingForm.ProjectList[3].Price2;
                    TextBox41.Text = biddingForm.ProjectList[3].Price3;
                    TextBox42.Text = biddingForm.ProjectList[3].Remark;
                }
                if (arr[4] == 1)
                {
                    TextBox43.Text = biddingForm.ProjectList[4].Item;
                    TextBox44.Text = biddingForm.ProjectList[4].Description;
                    TextBox45.Text = biddingForm.ProjectList[4].Price1;
                    TextBox46.Text = biddingForm.ProjectList[4].Price2;
                    TextBox47.Text = biddingForm.ProjectList[4].Price3;
                    TextBox48.Text = biddingForm.ProjectList[4].Remark;
                }
            }
            //展示附件
            showfilelist(formID);
        }


        private void hideImage(string signature, Image image)
        {
            if (signature != "")
            {
                image.ImageUrl = signature;
            }
            else
            {
                image.Visible = false;
            }
        }

        /// <summary>
        /// 显示文件列表
        /// </summary>
        /// <param name="FormID"></param>
        public void showfilelist(string FormID)//
        {

        }

        /// <summary>
        /// 保存表格
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="manul"></param>
        /// <returns></returns>
        private As_Bidding_Approval saveForm(int flag, string manul)
        {
            As_Bidding_Approval BiddingForm = new As_Bidding_Approval();
            BiddingForm.Form_ID = Convert.ToString(ViewState["form_ID"]);
            BiddingForm.Form_Type_ID = Convert.ToString(ViewState["formTypeID"]);
            BiddingForm.Temp_Vendor_ID = Convert.ToString(ViewState["tempVendorID"]);
            BiddingForm.Temp_Vendor_Name = Convert.ToString(ViewState["tempVendorName"]);
            BiddingForm.Flag = flag;                       //更改表格的标志位
            BiddingForm.Serial_No = TextBox1.Text.Trim();
            BiddingForm.Date = TextBox2.Text.Trim();
            BiddingForm.Product = TextBox3.Text.Trim();
            BiddingForm.Purchase_Amount = TextBox4.Text.Trim();
            BiddingForm.MOQ1 = TextBox5.Text.Trim();
            BiddingForm.MOQ2 = TextBox6.Text.Trim();
            BiddingForm.MOQ3 = TextBox7.Text.Trim();
            BiddingForm.Lead_Time1 = TextBox8.Text.Trim();
            BiddingForm.Lead_Time2 = TextBox9.Text.Trim();
            BiddingForm.Lead_Time3 = TextBox10.Text.Trim();
            BiddingForm.Payment_Term1 = TextBox11.Text.Trim();
            BiddingForm.Payment_Term2 = TextBox12.Text.Trim();
            BiddingForm.Payment_Term3 = TextBox13.Text.Trim();
            BiddingForm.Remark1 = TextBox14.Text.Trim();
            BiddingForm.Remark2 = TextBox15.Text.Trim();
            BiddingForm.Remark3 = TextBox16.Text.Trim();
            BiddingForm.Reason_One = TextBox17.Text.Trim();
            BiddingForm.Reason_Two = TextBox18.Text.Trim();
            BiddingForm.Vendor_Recommend = TextBox49.Text.Trim();
            BiddingForm.Rank1 = TextBox50.Text.Trim();
            BiddingForm.Rank2 = TextBox51.Text.Trim();
            BiddingForm.Rank3 = TextBox52.Text.Trim();
            BiddingForm.Rank_Remark = TextBox53.Text.Trim();
            BiddingForm.Initiator = Image1.ImageUrl;
            BiddingForm.User_Department_Manager = Image5.ImageUrl;
            BiddingForm.ProjectList = new List<As_Bidding_Approval_Item>() ;
            for (int i = 19; i <= 48; i+=6)
            {
                As_Bidding_Approval_Item item = new As_Bidding_Approval_Item();
                item.Item = (FindControl("TextBox" + i) as TextBox).Text.Trim();
                item.Description = (FindControl("TextBox" + (i + 1)) as TextBox).Text.Trim();
                item.Price1 = (FindControl("TextBox" + (i + 2)) as TextBox).Text.Trim();
                item.Price2 = (FindControl("TextBox" + (i + 3)) as TextBox).Text.Trim();
                item.Price3 = (FindControl("TextBox" + (i + 4)) as TextBox).Text.Trim();
                item.Remark = (FindControl("TextBox" + (i + 5)) as TextBox).Text.Trim();
                item.Form_ID = Convert.ToString(ViewState["form_ID"]);
                BiddingForm.ProjectList.Add(item);
            }

            int join = As_Bidding_Approval_BLL.updateBiddingForm(BiddingForm);
            if (join > 0)
            {
                As_Write write = new As_Write();                     //将填写信息记录
                write.Employee_ID = Session["Employee_ID"].ToString();
                write.Form_ID = BiddingForm.Form_ID;
                write.Form_Fill_Time = DateTime.Now.ToString();
                write.Manul = manul;
                write.Temp_Vendor_ID = Convert.ToString(ViewState["tempVendorID"]);
                Write_BLL.addWrite(write);
                if (flag == 1)
                {
                    LocalScriptManager.createManagerScript(Page, "window.alert('保存成功！')", "save");
                }
                return BiddingForm;
            }
            else
            {
                return null;
            }
        }

        public void Button1_Click(object sender, EventArgs e)//提交按钮
        {
            //检查特定绑定文件是否提交
            bool singleFileSubmit = Convert.ToBoolean(ViewState["singleFileSubmit"]);
            singleFileSubmit = VendorSingleFile_BLL.isSingleFileSubmit(Convert.ToString(ViewState["form_ID"]));
            if (!singleFileSubmit)
            {
                LocalScriptManager.createManagerScript(Page, "window.alert('请提交报价单')", "uploadsinglefile");
                return;
            }
            if (Convert.ToString(ViewState["submit"]) == "yes")
            {
                //形成参数
                saveForm(2, "提交表格");

                //弹出是否承诺性供应商询问框
                LocalScriptManager.CreateScript(Page, "isPromise();", "isPromiseTip");

                
            }
            else
            {
                LocalApproveManager.showPendingReason(Page, Convert.ToString(ViewState["tempVendorID"]),true);
               // Response.Write("<script>window.alert('无法提交，请等待其他表格审批完毕后再次尝试！')</script>");
            }
        }

        private bool isKciByMoney(string promise)
        {
            double money = Convert.ToDouble(TextBox4.Text.ToString());
            if (promise.Equals("no"))
            {
                if (!(money < 1500000))//元
                {
                    return true;
                }
                return false;
            }
            else
            {
                if (!(money < 600000))//元
                {
                    return true;
                }
                return false;
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

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            string fileID = GridView2.Rows[drv.RowIndex].Cells[1].ToString().Trim();//获取fileID
            string filePath = As_Bidding_Approval_BLL.getFilePath(fileID);
            if (filePath != "")
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>viewFile('" + filePath + "');</script>");
            }
        }

        protected void btnNewImage_Click(object sender, EventArgs e)
        {
            string[] temp = ImgExSrc.Value.ToString().Split(',');
            Control control = FindControl(temp[0]);
            if (control != null)
            {
                ((Image)control).ImageUrl = temp[1];
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string requestType = "signleupload";
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "signleupload", String.Format("uploadFile('{0}','{1}','{2}','{3}',{4})", requestType, Convert.ToString(ViewState["tempVendorID"]), Convert.ToString(ViewState["tempVendorName"]), Convert.ToString(ViewState["form_ID"]), "true"), true);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string fileID = "";
            fileID = Vendor_MutipleForm_BLL.getSingleFileID(Convert.ToString(ViewState["form_ID"]));
            string formPath = "../files/" + fileID + ".pdf";
            LocalScriptManager.createManagerScript(Page, "viewFile('" + formPath + "')", "view");
        }
    }
}