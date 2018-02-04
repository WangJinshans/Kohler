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
        public string FORM_NAME = "供应商调查表";
        public string FORM_TYPE_ID = "027";
        private static string tempVendorID = "";
        private static string tempVendorName = "";
        private static string factory = "";
        private static string formID = "";
        private static string submit = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            image2.Visible = false;
            image3.Visible = false;
            image4.Visible = false;
            if (!IsPostBack)
            {
                getSessionInfo();
                int check = ServiceComponentApplication_BLL.checkVendorServiceComponent(formID);//检查是否存在这张表
                if (check == 0)//数据库中不存在这张表，则自动初始化
                {
                    As_ServiceComponentApplication serviceComponent = new As_ServiceComponentApplication();
                    serviceComponent.Form_Type_ID = FORM_TYPE_ID;
                    serviceComponent.Temp_Vendor_Name = tempVendorName;
                    serviceComponent.Temp_Vendor_ID = tempVendorID;
                    serviceComponent.Flag = 0;//将表格标志位信息改为已填写
                    serviceComponent.Factory_Name = factory;

                    int n = ServiceComponentApplication_BLL.addVendorServiceComponent(serviceComponent);
                    if (n == 0)
                    {
                        Response.Write("<script>window.alert('表格初始化错误（新建插入失败）！')</script>");
                        return;
                    }
                    else
                    {
                        //获取formID信息
                        getSessionInfo();

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
            serviceComponent = ServiceComponentApplication_BLL.checkFlag(formID);
            if (serviceComponent != null)
            {
                if (serviceComponent.ComponentApplicationItem != null && serviceComponent.ComponentApplicationItem.Count > 0)
                {
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
            showfilelist(formID);
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
            FORM_TYPE_ID = Request.QueryString["type"];
            FORM_NAME = FormType_BLL.getFormNameByTypeID(FORM_TYPE_ID);
            tempVendorID = Session["tempVendorID"].ToString();
            tempVendorName = TempVendor_BLL.getTempVendorName(tempVendorID);
            factory = Session["Factory_Name"].ToString().Trim();
            formID = ServiceComponentApplication_BLL.getFormID(tempVendorID, FORM_TYPE_ID, factory);
            submit = Request.QueryString["submit"];
            //FORM_TYPE_ID = "027";
            //FORM_NAME = FormType_BLL.getFormNameByTypeID(FORM_TYPE_ID);
            //tempVendorID = "TempVendor4071";
            //tempVendorName = "hgfhff";
            //factory = "上海科勒";
            //Session.Add("Factory_Name", factory);
            //formID = ServiceComponentApplication_BLL.getFormID(tempVendorID, FORM_TYPE_ID, factory);
            //submit = "yes";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            getSessionInfo();
            if (submit == "yes")
            {
                //形成参数
                As_ServiceComponentApplication serviceComponent = saveForm(2, "提交表格");
                approveAssess();
            }
            else
            {
                LocalApproveManager.showPendingReason(Page, tempVendorID, true);
            }
        }

        public void approveAssess()
        {
            getSessionInfo();

            if (LocalApproveManager.doAddApprove(formID, FORM_NAME, FORM_TYPE_ID, tempVendorID))
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
                item.Form_ID = formID;
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
            serviceComponent.Form_Type_ID = FORM_TYPE_ID;
            serviceComponent.Form_ID = formID;
            serviceComponent.Factory_Name = factory;
            serviceComponent.Temp_Vendor_ID = tempVendorID;
            serviceComponent.Temp_Vendor_Name = tempVendorName;
            serviceComponent.Flag = flag;
            serviceComponent.Initiator = image1.ImageUrl;
            int join = ServiceComponentApplication_BLL.updateVendorServiceComponent(serviceComponent);
            if (join > 0)
            {
                As_Write write = new As_Write();                     //将填写信息记录
                write.Employee_ID = Session["Employee_ID"].ToString();
                //write.Employee_ID = "ko53327";
                write.Form_ID = serviceComponent.Form_ID;
                write.Form_Fill_Time = DateTime.Now.ToString();
                write.Manul = manul;
                write.Temp_Vendor_ID = tempVendorID;
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
    }
}