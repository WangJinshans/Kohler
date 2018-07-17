using BLL;
using BLL.VendorAssess;
using Model;
using MODEL.VendorAssess;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SHZSZHSUPPLY.VendorAssess
{
    public partial class PurchasePriceApplication : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            image2.Visible = false;
            image3.Visible = false;
            image4.Visible = false;
            image5.Visible = false;
            image6.Visible = false;
            if (!IsPostBack)
            {
                getSessionInfo();
                int check = PurchasePriceApplication_BLL.checkVendorPurchasePriceApplication(Convert.ToString(ViewState["form_ID"]));//检查是否存在这张表
                if (check == 0)//数据库中不存在这张表，则自动初始化
                {
                    As_PurchasePriceApplication purchasePrice = new As_PurchasePriceApplication();
                    purchasePrice.Form_Type_ID = Convert.ToString(ViewState["formTypeID"]);
                    purchasePrice.Temp_Vendor_Name = Convert.ToString(ViewState["tempVendorName"]);
                    purchasePrice.Temp_Vendor_ID = Convert.ToString(ViewState["tempVendorID"]);
                    purchasePrice.Flag = 0;//将表格标志位信息改为已填写
                    purchasePrice.Factory_Name = Session["Factory_Name"].ToString().Trim();

                    int n = PurchasePriceApplication_BLL.addVendorPurchasePriceApplication(purchasePrice);
                    if (n == 0)
                    {
                        Response.Write("<script>window.alert('表格初始化错误（新建插入失败）！')</script>");
                        return;
                    }
                    else
                    {
                        string formID = PurchasePriceApplication_BLL.getVendorPurchasePriceFormID(Convert.ToString(ViewState["tempVendorID"]), Convert.ToString(ViewState["formTypeID"]), Session["Factory_Name"].ToString().Trim(), n);
                        ViewState.Add("form_ID", formID);
                        //添加单独绑定的文件
                        VendorSingleFile_BLL.addSingleFile(formID, Convert.ToString(ViewState["formTypeID"]), Convert.ToString(ViewState["tempVendorID"]), Convert.ToString(ViewState["tempVendorID"]), Session["Factory_Name"].ToString().Trim(), "012");

                        //每次添加表格添加到As_Vendor_MutipleForm中 
                        As_MutipleForm forms = new As_MutipleForm();
                        forms.Temp_Vendor_ID = Convert.ToString(ViewState["tempVendorID"]);
                        forms.Temp_Vendor_Name = Convert.ToString(ViewState["tempVendorName"]);
                        forms.Form_Type_ID = Convert.ToString(ViewState["formTypeID"]);
                        forms.Form_ID = formID;
                        forms.Flag = 0;
                        forms.Factory_Name = Session["Factory_Name"].ToString().Trim();
                        Vendor_MutipleForm_BLL.addVendorMutileForms(forms);
                        //向FormFile表中添加相应的文件、表格绑定信息
                        bindingFormWithFile();
                        showfilelist(formID);
                    }
                }
                else
                {
                    showVendorPurchasePriceApplication();
                }
            }
            switch (Request["__EVENTTARGET"])
            {
                case "newImageSrc":
                    {
                        string[] temp = Request.Form["__EVENTARGUMENT"].ToString().Split(',');
                        Control control = FindControl(temp[0]);
                        if (control != null)
                        {
                            ((Image)control).ImageUrl = temp[1];
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void showfilelist(string formID)
        {
            
        }

        private void bindingFormWithFile()
        {
            
        }

        private void showVendorPurchasePriceApplication()
        {
            As_PurchasePriceApplication purchasePrice = new As_PurchasePriceApplication();
            purchasePrice = PurchasePriceApplication_BLL.checkFlag(Convert.ToString(ViewState["form_ID"]));
            if (purchasePrice != null)
            {
                if (purchasePrice.PurchasePriceItem != null && purchasePrice.PurchasePriceItem.Count > 0)
                {
                    textbox121.Text = purchasePrice.ReMark;
                    #region
                    for (int i = 0; i < purchasePrice.PurchasePriceItem.Count; i++)
                    {
                        if (i == 0)
                        {
                            textbox1.Text = purchasePrice.PurchasePriceItem[i].NO;
                            textbox2.Text = purchasePrice.PurchasePriceItem[i].SKU;
                            textbox3.Text = purchasePrice.PurchasePriceItem[i].Description;
                            textbox4.Text = purchasePrice.PurchasePriceItem[i].Supplier;
                            textbox5.Text = purchasePrice.PurchasePriceItem[i].USD_Cost;
                            textbox6.Text = purchasePrice.PurchasePriceItem[i].Tooling_Cost;
                            textbox7.Text = purchasePrice.PurchasePriceItem[i].TTL_Cost;
                            textbox8.Text = purchasePrice.PurchasePriceItem[i].MOQ;
                            textbox9.Text = purchasePrice.PurchasePriceItem[i].Lead_time;
                            textbox10.Text = purchasePrice.PurchasePriceItem[i].Other_Source;
                            textbox11.Text = purchasePrice.PurchasePriceItem[i].Order_Share;
                            textbox12.Text= purchasePrice.PurchasePriceItem[i].Now_Price;
                        }
                        if (i == 1)
                        {
                            textbox13.Text = purchasePrice.PurchasePriceItem[i].NO;
                            textbox14.Text = purchasePrice.PurchasePriceItem[i].SKU;
                            textbox15.Text = purchasePrice.PurchasePriceItem[i].Description;
                            textbox16.Text = purchasePrice.PurchasePriceItem[i].Supplier;
                            textbox17.Text = purchasePrice.PurchasePriceItem[i].USD_Cost;
                            textbox18.Text = purchasePrice.PurchasePriceItem[i].Tooling_Cost;
                            textbox19.Text = purchasePrice.PurchasePriceItem[i].TTL_Cost;
                            textbox20.Text = purchasePrice.PurchasePriceItem[i].MOQ;
                            textbox21.Text = purchasePrice.PurchasePriceItem[i].Lead_time;
                            textbox22.Text = purchasePrice.PurchasePriceItem[i].Other_Source;
                            textbox23.Text = purchasePrice.PurchasePriceItem[i].Order_Share;
                            textbox24.Text = purchasePrice.PurchasePriceItem[i].Now_Price;
                        }
                        if (i == 2)
                        {
                            textbox25.Text = purchasePrice.PurchasePriceItem[i].NO;
                            textbox26.Text = purchasePrice.PurchasePriceItem[i].SKU;
                            textbox27.Text = purchasePrice.PurchasePriceItem[i].Description;
                            textbox28.Text = purchasePrice.PurchasePriceItem[i].Supplier;
                            textbox29.Text = purchasePrice.PurchasePriceItem[i].USD_Cost;
                            textbox30.Text = purchasePrice.PurchasePriceItem[i].Tooling_Cost;
                            textbox31.Text = purchasePrice.PurchasePriceItem[i].TTL_Cost;
                            textbox32.Text = purchasePrice.PurchasePriceItem[i].MOQ;
                            textbox33.Text = purchasePrice.PurchasePriceItem[i].Lead_time;
                            textbox34.Text = purchasePrice.PurchasePriceItem[i].Other_Source;
                            textbox35.Text = purchasePrice.PurchasePriceItem[i].Order_Share;
                            textbox36.Text = purchasePrice.PurchasePriceItem[i].Now_Price;
                        }
                        if (i == 3)
                        {
                            textbox37.Text = purchasePrice.PurchasePriceItem[i].NO;
                            textbox38.Text = purchasePrice.PurchasePriceItem[i].SKU;
                            textbox39.Text = purchasePrice.PurchasePriceItem[i].Description;
                            textbox40.Text = purchasePrice.PurchasePriceItem[i].Supplier;
                            textbox41.Text = purchasePrice.PurchasePriceItem[i].USD_Cost;
                            textbox42.Text = purchasePrice.PurchasePriceItem[i].Tooling_Cost;
                            textbox43.Text = purchasePrice.PurchasePriceItem[i].TTL_Cost;
                            textbox44.Text = purchasePrice.PurchasePriceItem[i].MOQ;
                            textbox45.Text = purchasePrice.PurchasePriceItem[i].Lead_time;
                            textbox46.Text = purchasePrice.PurchasePriceItem[i].Other_Source;
                            textbox47.Text = purchasePrice.PurchasePriceItem[i].Order_Share;
                            textbox48.Text = purchasePrice.PurchasePriceItem[i].Now_Price;
                        }
                        if (i == 4)
                        {
                            textbox49.Text = purchasePrice.PurchasePriceItem[i].NO;
                            textbox50.Text = purchasePrice.PurchasePriceItem[i].SKU;
                            textbox51.Text = purchasePrice.PurchasePriceItem[i].Description;
                            textbox52.Text = purchasePrice.PurchasePriceItem[i].Supplier;
                            textbox53.Text = purchasePrice.PurchasePriceItem[i].USD_Cost;
                            textbox54.Text = purchasePrice.PurchasePriceItem[i].Tooling_Cost;
                            textbox55.Text = purchasePrice.PurchasePriceItem[i].TTL_Cost;
                            textbox56.Text = purchasePrice.PurchasePriceItem[i].MOQ;
                            textbox57.Text = purchasePrice.PurchasePriceItem[i].Lead_time;
                            textbox58.Text = purchasePrice.PurchasePriceItem[i].Other_Source;
                            textbox59.Text = purchasePrice.PurchasePriceItem[i].Order_Share;
                            textbox60.Text = purchasePrice.PurchasePriceItem[i].Now_Price;
                        }
                        if (i == 5)
                        {
                            textbox61.Text = purchasePrice.PurchasePriceItem[i].NO;
                            textbox62.Text = purchasePrice.PurchasePriceItem[i].SKU;
                            textbox63.Text = purchasePrice.PurchasePriceItem[i].Description;
                            textbox64.Text = purchasePrice.PurchasePriceItem[i].Supplier;
                            textbox65.Text = purchasePrice.PurchasePriceItem[i].USD_Cost;
                            textbox66.Text = purchasePrice.PurchasePriceItem[i].Tooling_Cost;
                            textbox67.Text = purchasePrice.PurchasePriceItem[i].TTL_Cost;
                            textbox68.Text = purchasePrice.PurchasePriceItem[i].MOQ;
                            textbox69.Text = purchasePrice.PurchasePriceItem[i].Lead_time;
                            textbox70.Text = purchasePrice.PurchasePriceItem[i].Other_Source;
                            textbox71.Text = purchasePrice.PurchasePriceItem[i].Order_Share;
                            textbox72.Text = purchasePrice.PurchasePriceItem[i].Now_Price;
                        }
                        if (i == 6)
                        {
                            textbox73.Text = purchasePrice.PurchasePriceItem[i].NO;
                            textbox74.Text = purchasePrice.PurchasePriceItem[i].SKU;
                            textbox75.Text = purchasePrice.PurchasePriceItem[i].Description;
                            textbox76.Text = purchasePrice.PurchasePriceItem[i].Supplier;
                            textbox77.Text = purchasePrice.PurchasePriceItem[i].USD_Cost;
                            textbox78.Text = purchasePrice.PurchasePriceItem[i].Tooling_Cost;
                            textbox79.Text = purchasePrice.PurchasePriceItem[i].TTL_Cost;
                            textbox80.Text = purchasePrice.PurchasePriceItem[i].MOQ;
                            textbox81.Text = purchasePrice.PurchasePriceItem[i].Lead_time;
                            textbox82.Text = purchasePrice.PurchasePriceItem[i].Other_Source;
                            textbox83.Text = purchasePrice.PurchasePriceItem[i].Order_Share;
                            textbox84.Text = purchasePrice.PurchasePriceItem[i].Now_Price;
                        }
                        if (i == 7)
                        {
                            textbox85.Text = purchasePrice.PurchasePriceItem[i].NO;
                            textbox86.Text = purchasePrice.PurchasePriceItem[i].SKU;
                            textbox87.Text = purchasePrice.PurchasePriceItem[i].Description;
                            textbox88.Text = purchasePrice.PurchasePriceItem[i].Supplier;
                            textbox89.Text = purchasePrice.PurchasePriceItem[i].USD_Cost;
                            textbox90.Text = purchasePrice.PurchasePriceItem[i].Tooling_Cost;
                            textbox91.Text = purchasePrice.PurchasePriceItem[i].TTL_Cost;
                            textbox92.Text = purchasePrice.PurchasePriceItem[i].MOQ;
                            textbox93.Text = purchasePrice.PurchasePriceItem[i].Lead_time;
                            textbox94.Text = purchasePrice.PurchasePriceItem[i].Other_Source;
                            textbox95.Text = purchasePrice.PurchasePriceItem[i].Order_Share;
                            textbox96.Text = purchasePrice.PurchasePriceItem[i].Now_Price;
                        }
                        if (i == 8)
                        {
                            textbox97.Text = purchasePrice.PurchasePriceItem[i].NO;
                            textbox98.Text = purchasePrice.PurchasePriceItem[i].SKU;
                            textbox99.Text = purchasePrice.PurchasePriceItem[i].Description;
                            textbox100.Text = purchasePrice.PurchasePriceItem[i].Supplier;
                            textbox101.Text = purchasePrice.PurchasePriceItem[i].USD_Cost;
                            textbox102.Text = purchasePrice.PurchasePriceItem[i].Tooling_Cost;
                            textbox103.Text = purchasePrice.PurchasePriceItem[i].TTL_Cost;
                            textbox104.Text = purchasePrice.PurchasePriceItem[i].MOQ;
                            textbox105.Text = purchasePrice.PurchasePriceItem[i].Lead_time;
                            textbox106.Text = purchasePrice.PurchasePriceItem[i].Other_Source;
                            textbox107.Text = purchasePrice.PurchasePriceItem[i].Order_Share;
                            textbox108.Text = purchasePrice.PurchasePriceItem[i].Now_Price;
                        }
                        if (i == 9)
                        {
                            textbox109.Text = purchasePrice.PurchasePriceItem[i].NO;
                            textbox110.Text = purchasePrice.PurchasePriceItem[i].SKU;
                            textbox111.Text = purchasePrice.PurchasePriceItem[i].Description;
                            textbox112.Text = purchasePrice.PurchasePriceItem[i].Supplier;
                            textbox113.Text = purchasePrice.PurchasePriceItem[i].USD_Cost;
                            textbox114.Text = purchasePrice.PurchasePriceItem[i].Tooling_Cost;
                            textbox115.Text = purchasePrice.PurchasePriceItem[i].TTL_Cost;
                            textbox116.Text = purchasePrice.PurchasePriceItem[i].MOQ;
                            textbox117.Text = purchasePrice.PurchasePriceItem[i].Lead_time;
                            textbox118.Text = purchasePrice.PurchasePriceItem[i].Other_Source;
                            textbox119.Text = purchasePrice.PurchasePriceItem[i].Order_Share;
                            textbox120.Text = purchasePrice.PurchasePriceItem[i].Now_Price;
                        }
                    }
                    #endregion
                    hideImage(purchasePrice.Initiator, image1);
                    hideImage(purchasePrice.Supply_Chain_Manager, image2);
                    hideImage(purchasePrice.Finance_Manager, image3);
                    hideImage(purchasePrice.GM, image4);
                    hideImage(purchasePrice.Director_Sourcing_KCI, image5);
                    hideImage(purchasePrice.Finance_Director_KCI, image6);

                    LocalScriptManager.CreateScript(Page, "initTextarea()", "initTextbox");
                }
            }
            showfilelist(Convert.ToString(ViewState["form_ID"]));
        }


        private void hideImage(string signature, Image image)
        {
            if (image.ID.Equals("image1"))
            {
                image.ImageUrl = signature;
            }
            else
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
        }

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

            //处理form_ID
            try
            {
                ViewState.Add("form_ID", Request.QueryString["Form_ID"].ToString().Trim());
            }
            catch
            {
                ViewState.Add("form_ID", "");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //getSessionInfo();
            bool singleFileSubmit = VendorSingleFile_BLL.isSingleFileSubmit(Convert.ToString(ViewState["form_ID"]));
            if (!singleFileSubmit)
            {
                LocalScriptManager.createManagerScript(Page, "window.alert('请提交报价单')", "uploadsinglefile");
                return;
            }
            if (Convert.ToString(ViewState["submit"]).Equals("yes"))
            {
                //形成参数
                As_PurchasePriceApplication PurchasePrice = saveForm(2, "提交表格");
                //目测需要KCI审批
                approveAssess();
            }
            else
            {
                LocalApproveManager.showPendingReason(Page, Convert.ToString(ViewState["tempVendorID"]), true);
            }
        }


        public void approveAssess()
        {
            //getSessionInfo();

            //在该方法中获取通过session获取了Factory_Name
            if (LocalApproveManager.doAddApprove(Convert.ToString(ViewState["form_ID"]), Convert.ToString(ViewState["formName"]), Convert.ToString(ViewState["formTypeID"]), Convert.ToString(ViewState["tempVendorID"])))
            {
                LocalScriptManager.createManagerScript(this.Page, string.Format("messageConfirm('{0}','{1}')", "提交成功", "EmployeeVendor.aspx"), "submited");
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


        private As_PurchasePriceApplication saveForm(int flag, string manul)
        {
            As_PurchasePriceApplication purchasePrice = new As_PurchasePriceApplication();
            purchasePrice.PurchasePriceItem = new List<As_PurchasePriceApplication_Item>();
            As_PurchasePriceApplication_Item item = null;
            for (int i = 0; i < 10; i++)
            {
                item = new As_PurchasePriceApplication_Item();
                item.Form_ID = Convert.ToString(ViewState["form_ID"]);
                item.NO = (FindControl("textbox" + (i * 12 + 1)) as TextBox).Text.ToString();
                item.SKU= (FindControl("textbox" + (i * 12 + 2)) as TextBox).Text.ToString();
                item.Description= (FindControl("textbox" + (i * 12 + 3)) as TextBox).Text.ToString();
                item.Supplier= (FindControl("textbox" + (i * 12 + 4)) as TextBox).Text.ToString();
                item.USD_Cost= (FindControl("textbox" + (i * 12 + 5)) as TextBox).Text.ToString();
                item.Tooling_Cost= (FindControl("textbox" + (i * 12 + 6)) as TextBox).Text.ToString();
                item.TTL_Cost= (FindControl("textbox" + (i * 12 + 7)) as TextBox).Text.ToString();
                item.MOQ= (FindControl("textbox" + (i * 12 + 8)) as TextBox).Text.ToString();
                item.Lead_time= (FindControl("textbox" + (i * 12 + 9)) as TextBox).Text.ToString();
                item.Other_Source= (FindControl("textbox" + (i * 12 + 10)) as TextBox).Text.ToString();
                item.Order_Share= (FindControl("textbox" + (i * 12 + 11)) as TextBox).Text.ToString();
                item.Now_Price= (FindControl("textbox" + (i * 12 + 12)) as TextBox).Text.ToString();
                purchasePrice.PurchasePriceItem.Add(item);
            }
            purchasePrice.Form_Type_ID = Convert.ToString(ViewState["formTypeID"]);
            purchasePrice.Form_ID = Convert.ToString(ViewState["form_ID"]);
            purchasePrice.Factory_Name = Session["Factory_Name"].ToString().Trim();
            purchasePrice.Temp_Vendor_ID = Convert.ToString(ViewState["tempVendorID"]);
            purchasePrice.Temp_Vendor_Name = Convert.ToString(ViewState["tempVendorName"]);
            purchasePrice.Flag = flag;
            purchasePrice.Initiator = image1.ImageUrl;
            purchasePrice.ReMark = textbox121.Text;
            int join = PurchasePriceApplication_BLL.updateVendorPurchasePriceApplication(purchasePrice);
            if (join > 0)
            {
                As_Write write = new As_Write();                     //将填写信息记录
                write.Employee_ID = Session["Employee_ID"].ToString();
                write.Form_ID = purchasePrice.Form_ID;
                write.Form_Fill_Time = DateTime.Now.ToString();
                write.Manul = manul;
                write.Temp_Vendor_ID = Convert.ToString(ViewState["tempVendorID"]);
                Write_BLL.addWrite(write);
                if (flag == 1)
                {
                    LocalScriptManager.createManagerScript(Page, "window.alert('保存成功！')", "save");
                }
                return purchasePrice;
            }
            else
            {
                Response.Write("<script>window.alert('保存失败！')</script>");
                return null;
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