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
    public partial class ServiceComponentApplication : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            image2.Visible = false;
            image3.Visible = false;
            image4.Visible = false;
            if (!IsPostBack)
            {
                getSessionInfo();
                int check = ServiceComponentApplication_BLL.checkVendorServiceComponent(Convert.ToString(ViewState["form_ID"]));//检查是否存在这张表
                if (check == 0)//数据库中不存在这张表，则自动初始化
                {
                    As_ServiceComponentApplication serviceComponent = new As_ServiceComponentApplication();
                    serviceComponent.Form_Type_ID = Convert.ToString(ViewState["formTypeID"]);
                    serviceComponent.Temp_Vendor_Name = Convert.ToString(ViewState["tempVendorName"]);
                    serviceComponent.Temp_Vendor_ID = Convert.ToString(ViewState["tempVendorID"]);
                    serviceComponent.Flag = 0;//将表格标志位信息改为已填写
                    serviceComponent.Factory_Name = Session["Factory_Name"].ToString().Trim();

                    int n = ServiceComponentApplication_BLL.addVendorServiceComponent(serviceComponent);
                    if (n == 0)
                    {
                        Response.Write("<script>window.alert('表格初始化错误（新建插入失败）！')</script>");
                        return;
                    }
                    else
                    {
                        string formID = ServiceComponentApplication_BLL.getVendorServiceComponentFormID(Convert.ToString(ViewState["tempVendorID"]), Convert.ToString(ViewState["formTypeID"]), Session["Factory_Name"].ToString().Trim(), n);
                        ViewState.Add("form_ID", formID);
                        VendorSingleFile_BLL.addSingleFile(formID, Convert.ToString(ViewState["fo"]), Convert.ToString(ViewState["tempVendorID"]), Convert.ToString(ViewState["tempVendorName"]), Session["Factory_Name"].ToString().Trim(), "012");


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
                    showVendorServiceComponentApplication();
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

        private void showVendorServiceComponentApplication()
        {
            As_ServiceComponentApplication serviceComponent = new As_ServiceComponentApplication();
            serviceComponent = ServiceComponentApplication_BLL.checkFlag(Convert.ToString(ViewState["form_ID"]));
            if (serviceComponent != null)
            {
                if (serviceComponent.ComponentApplicationItem != null && serviceComponent.ComponentApplicationItem.Count > 0)
                {
                    textbox101.Text = serviceComponent.Remark;
                    #region
                    for (int i = 0; i < serviceComponent.ComponentApplicationItem.Count; i++)
                    {
                        if (i == 0)
                        {
                            textbox1.Text = serviceComponent.ComponentApplicationItem[i].Item_No;
                            textbox2.Text = serviceComponent.ComponentApplicationItem[i].Description;
                            textbox3.Text = serviceComponent.ComponentApplicationItem[i].Sku_Number;
                            textbox4.Text = serviceComponent.ComponentApplicationItem[i].UOM;
                            textbox5.Text = serviceComponent.ComponentApplicationItem[i].Supplier;
                            textbox6.Text = serviceComponent.ComponentApplicationItem[i].Service_Cost;
                            textbox7.Text = serviceComponent.ComponentApplicationItem[i].Original_Cost;
                            textbox8.Text = serviceComponent.ComponentApplicationItem[i].MOQ;
                            textbox9.Text = serviceComponent.ComponentApplicationItem[i].MOQ_PO;
                            textbox10.Text =serviceComponent.ComponentApplicationItem[i].Lead_Time;
                        }
                        if (i == 1)
                        {
                            textbox11.Text = serviceComponent.ComponentApplicationItem[i].Item_No;
                            textbox12.Text = serviceComponent.ComponentApplicationItem[i].Description;
                            textbox13.Text = serviceComponent.ComponentApplicationItem[i].Sku_Number;
                            textbox14.Text = serviceComponent.ComponentApplicationItem[i].UOM;
                            textbox15.Text = serviceComponent.ComponentApplicationItem[i].Supplier;
                            textbox16.Text = serviceComponent.ComponentApplicationItem[i].Service_Cost;
                            textbox17.Text = serviceComponent.ComponentApplicationItem[i].Original_Cost;
                            textbox18.Text = serviceComponent.ComponentApplicationItem[i].MOQ;
                            textbox19.Text = serviceComponent.ComponentApplicationItem[i].MOQ_PO;
                            textbox20.Text = serviceComponent.ComponentApplicationItem[i].Lead_Time;
                        }
                        if (i == 2)
                        {
                            textbox21.Text = serviceComponent.ComponentApplicationItem[i].Item_No;
                            textbox22.Text = serviceComponent.ComponentApplicationItem[i].Description;
                            textbox23.Text = serviceComponent.ComponentApplicationItem[i].Sku_Number;
                            textbox24.Text = serviceComponent.ComponentApplicationItem[i].UOM;
                            textbox25.Text = serviceComponent.ComponentApplicationItem[i].Supplier;
                            textbox26.Text = serviceComponent.ComponentApplicationItem[i].Service_Cost;
                            textbox27.Text = serviceComponent.ComponentApplicationItem[i].Original_Cost;
                            textbox28.Text = serviceComponent.ComponentApplicationItem[i].MOQ;
                            textbox29.Text = serviceComponent.ComponentApplicationItem[i].MOQ_PO;
                            textbox30.Text = serviceComponent.ComponentApplicationItem[i].Lead_Time;
                        }
                        if (i == 3)
                        {
                            textbox31.Text = serviceComponent.ComponentApplicationItem[i].Item_No;
                            textbox32.Text = serviceComponent.ComponentApplicationItem[i].Description;
                            textbox33.Text = serviceComponent.ComponentApplicationItem[i].Sku_Number;
                            textbox34.Text = serviceComponent.ComponentApplicationItem[i].UOM;
                            textbox35.Text = serviceComponent.ComponentApplicationItem[i].Supplier;
                            textbox36.Text = serviceComponent.ComponentApplicationItem[i].Service_Cost;
                            textbox37.Text = serviceComponent.ComponentApplicationItem[i].Original_Cost;
                            textbox38.Text = serviceComponent.ComponentApplicationItem[i].MOQ;
                            textbox39.Text = serviceComponent.ComponentApplicationItem[i].MOQ_PO;
                            textbox40.Text = serviceComponent.ComponentApplicationItem[i].Lead_Time;
                        }
                        if (i == 4)
                        {
                            textbox41.Text = serviceComponent.ComponentApplicationItem[i].Item_No;
                            textbox42.Text = serviceComponent.ComponentApplicationItem[i].Description;
                            textbox43.Text = serviceComponent.ComponentApplicationItem[i].Sku_Number;
                            textbox44.Text = serviceComponent.ComponentApplicationItem[i].UOM;
                            textbox45.Text = serviceComponent.ComponentApplicationItem[i].Supplier;
                            textbox46.Text = serviceComponent.ComponentApplicationItem[i].Service_Cost;
                            textbox47.Text = serviceComponent.ComponentApplicationItem[i].Original_Cost;
                            textbox48.Text = serviceComponent.ComponentApplicationItem[i].MOQ;
                            textbox49.Text = serviceComponent.ComponentApplicationItem[i].MOQ_PO;
                            textbox50.Text = serviceComponent.ComponentApplicationItem[i].Lead_Time;
                        }
                        if (i == 5)
                        {
                            textbox51.Text = serviceComponent.ComponentApplicationItem[i].Item_No;
                            textbox52.Text = serviceComponent.ComponentApplicationItem[i].Description;
                            textbox53.Text = serviceComponent.ComponentApplicationItem[i].Sku_Number;
                            textbox54.Text = serviceComponent.ComponentApplicationItem[i].UOM;
                            textbox55.Text = serviceComponent.ComponentApplicationItem[i].Supplier;
                            textbox56.Text = serviceComponent.ComponentApplicationItem[i].Service_Cost;
                            textbox57.Text = serviceComponent.ComponentApplicationItem[i].Original_Cost;
                            textbox58.Text = serviceComponent.ComponentApplicationItem[i].MOQ;
                            textbox59.Text = serviceComponent.ComponentApplicationItem[i].MOQ_PO;
                            textbox60.Text = serviceComponent.ComponentApplicationItem[i].Lead_Time;
                        }
                        if (i == 6)
                        {
                            textbox61.Text = serviceComponent.ComponentApplicationItem[i].Item_No;
                            textbox62.Text = serviceComponent.ComponentApplicationItem[i].Description;
                            textbox63.Text = serviceComponent.ComponentApplicationItem[i].Sku_Number;
                            textbox64.Text = serviceComponent.ComponentApplicationItem[i].UOM;
                            textbox65.Text = serviceComponent.ComponentApplicationItem[i].Supplier;
                            textbox66.Text = serviceComponent.ComponentApplicationItem[i].Service_Cost;
                            textbox67.Text = serviceComponent.ComponentApplicationItem[i].Original_Cost;
                            textbox68.Text = serviceComponent.ComponentApplicationItem[i].MOQ;
                            textbox69.Text = serviceComponent.ComponentApplicationItem[i].MOQ_PO;
                            textbox70.Text = serviceComponent.ComponentApplicationItem[i].Lead_Time;
                        }
                        if (i == 7)
                        {
                            textbox71.Text = serviceComponent.ComponentApplicationItem[i].Item_No;
                            textbox72.Text = serviceComponent.ComponentApplicationItem[i].Description;
                            textbox73.Text = serviceComponent.ComponentApplicationItem[i].Sku_Number;
                            textbox74.Text = serviceComponent.ComponentApplicationItem[i].UOM;
                            textbox75.Text = serviceComponent.ComponentApplicationItem[i].Supplier;
                            textbox76.Text = serviceComponent.ComponentApplicationItem[i].Service_Cost;
                            textbox77.Text = serviceComponent.ComponentApplicationItem[i].Original_Cost;
                            textbox78.Text = serviceComponent.ComponentApplicationItem[i].MOQ;
                            textbox79.Text = serviceComponent.ComponentApplicationItem[i].MOQ_PO;
                            textbox80.Text = serviceComponent.ComponentApplicationItem[i].Lead_Time;
                        }
                        if (i == 8)
                        {
                            textbox81.Text = serviceComponent.ComponentApplicationItem[i].Item_No;
                            textbox82.Text = serviceComponent.ComponentApplicationItem[i].Description;
                            textbox83.Text = serviceComponent.ComponentApplicationItem[i].Sku_Number;
                            textbox84.Text = serviceComponent.ComponentApplicationItem[i].UOM;
                            textbox85.Text = serviceComponent.ComponentApplicationItem[i].Supplier;
                            textbox86.Text = serviceComponent.ComponentApplicationItem[i].Service_Cost;
                            textbox87.Text = serviceComponent.ComponentApplicationItem[i].Original_Cost;
                            textbox88.Text = serviceComponent.ComponentApplicationItem[i].MOQ;
                            textbox89.Text = serviceComponent.ComponentApplicationItem[i].MOQ_PO;
                            textbox90.Text = serviceComponent.ComponentApplicationItem[i].Lead_Time;
                        }
                        if (i == 9)
                        {
                            textbox91.Text = serviceComponent.ComponentApplicationItem[i].Item_No;
                            textbox92.Text = serviceComponent.ComponentApplicationItem[i].Description;
                            textbox93.Text = serviceComponent.ComponentApplicationItem[i].Sku_Number;
                            textbox94.Text = serviceComponent.ComponentApplicationItem[i].UOM;
                            textbox95.Text = serviceComponent.ComponentApplicationItem[i].Supplier;
                            textbox96.Text = serviceComponent.ComponentApplicationItem[i].Service_Cost;
                            textbox97.Text = serviceComponent.ComponentApplicationItem[i].Original_Cost;
                            textbox98.Text = serviceComponent.ComponentApplicationItem[i].MOQ;
                            textbox99.Text = serviceComponent.ComponentApplicationItem[i].MOQ_PO;
                            textbox100.Text = serviceComponent.ComponentApplicationItem[i].Lead_Time;
                        }
                    }
                    #endregion
                    hideImage(serviceComponent.Initiator, image1);
                    hideImage(serviceComponent.Supply_Chain_Manager, image2);
                    hideImage(serviceComponent.Finance_Manager, image3);
                    hideImage(serviceComponent.GM, image4);
                }
            }

            LocalScriptManager.CreateScript(Page, "initTextarea()", "initTextbox");
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
            bool singleFileSubmit = VendorSingleFile_BLL.isSingleFileSubmit(Convert.ToString(ViewState["form_ID"]));
            if (!singleFileSubmit)
            {
                LocalScriptManager.createManagerScript(Page, "window.alert('请提交报价单')", "uploadsinglefile");
                return;
            }
            if (Convert.ToString(ViewState["submit"]).Equals("yes"))
            {
                //形成参数
                As_ServiceComponentApplication serviceComponent = saveForm(2, "提交表格");
                approveAssess();
            }
            else
            {
                LocalApproveManager.showPendingReason(Page, Convert.ToString(ViewState["tempVendorID"]), true);
            }
        }

        public void approveAssess()
        {
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


        private As_ServiceComponentApplication saveForm(int flag, string manul)
        {
            As_ServiceComponentApplication serviceComponent = new As_ServiceComponentApplication();
            serviceComponent.ComponentApplicationItem = new List<As_ServiceComponentApplication_Item>();
            As_ServiceComponentApplication_Item item = null;
            for (int i = 0; i < 10; i++)
            {
                item = new As_ServiceComponentApplication_Item();
                item.Form_ID = Convert.ToString(ViewState["form_ID"]);
                item.Item_No = (FindControl("textbox" + (i * 10 + 1)) as TextBox).Text.ToString();
                item.Description = (FindControl("textbox" + (i * 10 + 2)) as TextBox).Text.ToString();
                item.Sku_Number = (FindControl("textbox" + (i * 10 + 3)) as TextBox).Text.ToString();
                item.UOM = (FindControl("textbox" + (i * 10 + 4)) as TextBox).Text.ToString();
                item.Supplier = (FindControl("textbox" + (i * 10 + 5)) as TextBox).Text.ToString();
                item.Service_Cost = (FindControl("textbox" + (i * 10 + 6)) as TextBox).Text.ToString();
                item.Original_Cost = (FindControl("textbox" + (i * 10 + 7)) as TextBox).Text.ToString();
                item.MOQ = (FindControl("textbox" + (i * 10 + 8)) as TextBox).Text.ToString();
                item.MOQ_PO = (FindControl("textbox" + (i * 10 + 9)) as TextBox).Text.ToString();
                item.Lead_Time = (FindControl("textbox" + (i * 10 + 10)) as TextBox).Text.ToString();
                serviceComponent.ComponentApplicationItem.Add(item);
            }
            serviceComponent.Form_Type_ID = Convert.ToString(ViewState["formTypeID"]);
            serviceComponent.Form_ID = Convert.ToString(ViewState["form_ID"]);
            serviceComponent.Factory_Name = Session["Factory_Name"].ToString().Trim();
            serviceComponent.Temp_Vendor_ID = Convert.ToString(ViewState["tempVendorID"]);
            serviceComponent.Temp_Vendor_Name = Convert.ToString(ViewState["tempVendorName"]);
            serviceComponent.Flag = flag;
            serviceComponent.Initiator = image1.ImageUrl;
            serviceComponent.Remark = textbox101.Text;
            int join = ServiceComponentApplication_BLL.updateVendorServiceComponent(serviceComponent);
            if (join > 0)
            {
                As_Write write = new As_Write();                     //将填写信息记录
                write.Employee_ID = Session["Employee_ID"].ToString();
                write.Form_ID = serviceComponent.Form_ID;
                write.Form_Fill_Time = DateTime.Now.ToString();
                write.Manul = manul;
                write.Temp_Vendor_ID = Convert.ToString(ViewState["tempVendorID"]);
                Write_BLL.addWrite(write);
                if (flag == 1)
                {
                    LocalScriptManager.createManagerScript(Page, "window.alert('保存成功！')", "save");
                }
                return serviceComponent;
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