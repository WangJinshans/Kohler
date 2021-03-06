﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BLL.VendorAssess;
using Model;
using MODEL.VendorAssess;
using SHZSZHSUPPLY.VendorAssess.Util;

namespace SHZSZHSUPPLY.VendorAssess
{
    public partial class PurchasePriceChanges : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //获取session信息
                getSessionInfo();


                //检查表格是否已经存在
                int check = PurchaseChanges_BLL.check(Convert.ToString(ViewState["form_ID"]));
                if (check == 0)
                {
                    As_Purchase_Changes asPurchaseChanges = new As_Purchase_Changes
                    {
                        Temp_Vendor_ID = Convert.ToString(ViewState["tempVendorID"]),
                        
                        Form_Type_ID = Convert.ToString(ViewState["formTypeID"]),
                        Vendor = Convert.ToString(ViewState["tempVendorName"]),
                        Flag = 0,
                        Factory_Name = Session["Factory_Name"].ToString()
                    };
                    int n = PurchaseChanges_BLL.add(asPurchaseChanges);
                    if (n == 0)
                    {
                        Response.Write("<script>window.alert('表格初始化错误（新建插入失败）！');window.location.href='EmployeeVendor.aspx'</script>");
                        return;
                    }
                    else
                    {
                        string formID = PurchaseChanges_BLL.getVendorPurchaseChangesFormID(Convert.ToString(ViewState["tempVendorID"]), Convert.ToString(ViewState["formTypeID"]), Session["Factory_Name"].ToString(), n);
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
                    }
                    show();
                }
                else
                {
                    show();
                }
            }
            else
            {
                switch (Request["__EVENTTARGET"])
                {
                    case "newImageSrc":
                        string[] url = Request.Form["__EVENTARGUMENT"].ToString().Split(',');
                        Control control = FindControl(url[0]);
                        if (control != null)
                        {
                            ((Image)control).ImageUrl = url[1];
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 重新读取session
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

        private void show()
        {
            As_Purchase_Changes asPurchaseChanges = PurchaseChanges_BLL.get(Convert.ToString(ViewState["form_ID"]));
            List<As_Purchase_Changes_Item> list = PurchaseChanges_BLL.getItems(Convert.ToString(ViewState["form_ID"]));

            if (asPurchaseChanges != null)
            {
                TextBox1.Text = asPurchaseChanges.Vendor_Code;
                TextBox2.Text = asPurchaseChanges.Vendor;
                TextBox3.Text = asPurchaseChanges.Currency;
                TextBox4.Text = asPurchaseChanges.Date;
                Image1.ImageUrl = asPurchaseChanges.Initiator;
                TextBox331.Text = asPurchaseChanges.Remark;
                //Show Page Images
            }
            else
            {
                Response.Write("<script>window.alert('数据查询失败！');window.location.href='EmployeeVendor.aspx'</script>");
            }

            if (list.Count > 0)
            {
                int index = 4;
                foreach (var item in list)
                {
                    ((TextBox)Controls[3].FindControl("TextBox" + (index + 1))).Text = item.SKU;
                    ((TextBox)Controls[3].FindControl("TextBox" + (index + 2))).Text = item.Description;
                    ((TextBox)Controls[3].FindControl("TextBox" + (index + 3))).Text = item.Unit;
                    ((TextBox)Controls[3].FindControl("TextBox" + (index + 4))).Text = item.Last_PO_Price;
                    ((TextBox)Controls[3].FindControl("TextBox" + (index + 5))).Text = item.Last_6_Months_Average_Price;
                    ((TextBox)Controls[3].FindControl("TextBox" + (index + 6))).Text = item.Required_Price;
                    ((TextBox)Controls[3].FindControl("TextBox" + (index + 7))).Text = item.STD_cost;
                    ((TextBox)Controls[3].FindControl("TextBox" + (index + 8))).Text = item.Request_Price_VS_Last_PO_Price;
                    ((TextBox)Controls[3].FindControl("TextBox" + (index + 9))).Text = item.STD_Cost_VS_Request_Price;
                    ((TextBox)Controls[3].FindControl("TextBox" + (index + 10))).Text = item.Yearly_Forecast;
                    ((TextBox)Controls[3].FindControl("TextBox" + (index + 11))).Text = item.Yearly_Amount;
                    ((TextBox)Controls[3].FindControl("TextBox" + (index + 12))).Text = item.PPV;
                    ((TextBox)Controls[3].FindControl("TextBox" + (index + 13))).Text = item.Current_Stock;
                    if (!item.Main_Material_Cost_Change.Equals("<EOF>"))
                    {
                        ((TextBox)Controls[3].FindControl("TextBox" + (index + 14))).Text = item.Main_Material_Cost_Change;
                        ((TextBox)Controls[3].FindControl("TextBox" + (index + 15))).Text = item.Main_Material_Cost_VS_Total_Cost;
                        ((TextBox)Controls[3].FindControl("TextBox" + (index + 16))).Text = item.Required_Cost_Change;
                        ((TextBox)Controls[3].FindControl("TextBox" + (index + 17))).Text = item.Effective_Date;
                        ((TextBox)Controls[3].FindControl("TextBox" + (index + 18))).Text = item.Remark;
                        index += 18;
                    }
                    else
                    {
                        ((TextBox)Controls[3].FindControl("TextBox" + (index + 14))).Text = item.Main_Material_Cost_VS_Total_Cost;
                        ((TextBox)Controls[3].FindControl("TextBox" + (index + 15))).Text = item.Required_Cost_Change;
                        ((TextBox)Controls[3].FindControl("TextBox" + (index + 16))).Text = item.Effective_Date;
                        ((TextBox)Controls[3].FindControl("TextBox" + (index + 17))).Text = item.Remark;
                        index += 17;
                    }

                }
            }
            LocalScriptManager.CreateScript(Page, "initTextarea()", "initTextbox");
        }


        private void save(int flag, string str, bool check = false)
        {
            As_Purchase_Changes asPurchaseChanges = new As_Purchase_Changes()
            {
                Vendor_Code = TextBox1.Text,
                Vendor = TextBox2.Text,
                Currency = TextBox3.Text,
                Date = TextBox4.Text,
                Form_ID = Convert.ToString(ViewState["form_ID"]),
                Initiator = Image1.ImageUrl,//保存申请人的签名
            };

            List<As_Purchase_Changes_Item> list = new List<As_Purchase_Changes_Item>();
            As_Purchase_Changes_Item item = null;
            item = new As_Purchase_Changes_Item()
            {
                SKU = TextBox5.Text,
                Description = TextBox6.Text,
                Unit = TextBox7.Text,
                Last_PO_Price = TextBox8.Text,
                Last_6_Months_Average_Price = TextBox9.Text,
                Required_Price = TextBox10.Text,
                STD_cost = TextBox11.Text,
                Request_Price_VS_Last_PO_Price = TextBox12.Text,
                STD_Cost_VS_Request_Price = TextBox13.Text,
                Yearly_Forecast = TextBox14.Text,
                Yearly_Amount = TextBox15.Text,
                PPV = TextBox16.Text,
                Current_Stock = TextBox17.Text,
                Main_Material_Cost_Change = TextBox18.Text,
                Main_Material_Cost_VS_Total_Cost = TextBox19.Text,
                Required_Cost_Change = TextBox20.Text,
                Effective_Date = TextBox21.Text,
                Remark = TextBox22.Text
            };
            list.Add(item);
            for (int i = 23; i < 295; i++)
            {
                item = new As_Purchase_Changes_Item()
                {
                    SKU = Request["TextBox" + i],
                    Description = Request["TextBox" + (i+1)],
                    Unit = Request["TextBox" + (i + 2)],
                    Last_PO_Price = Request["TextBox" + (i + 3)],
                    Last_6_Months_Average_Price = Request["TextBox" + (i + 4)],
                    Required_Price = Request["TextBox" + (i + 5)],
                    STD_cost = Request["TextBox" + (i + 6)],
                    Request_Price_VS_Last_PO_Price = Request["TextBox" + (i + 7)],
                    STD_Cost_VS_Request_Price = Request["TextBox" + (i + 8)],
                    Yearly_Forecast = Request["TextBox" + (i + 9)],
                    Yearly_Amount = Request["TextBox" + (i + 10)],
                    PPV = Request["TextBox" + (i + 11)],
                    Current_Stock = Request["TextBox" + (i + 12)],
                    Main_Material_Cost_Change = "<EOF>",
                    Main_Material_Cost_VS_Total_Cost = Request["TextBox" + (i + 13)],
                    Required_Cost_Change = Request["TextBox" + (i + 14)],
                    Effective_Date = Request["TextBox" + (i + 15)],
                    Remark = Request["TextBox" + (i + 16)],
                };
                list.Add(item);
                i += 16;
            }
            for (int i = 295; i < 331; i++)
            {
                item = new As_Purchase_Changes_Item()
                {
                    SKU = Request["TextBox" + i],
                    Description = Request["TextBox" + (i + 1)],
                    Unit = Request["TextBox" + (i + 2)],
                    Last_PO_Price = Request["TextBox" + (i + 3)],
                    Last_6_Months_Average_Price = Request["TextBox" + (i + 4)],
                    Required_Price = Request["TextBox" + (i + 5)],
                    STD_cost = Request["TextBox" + (i + 6)],
                    Request_Price_VS_Last_PO_Price = Request["TextBox" + (i + 7)],
                    STD_Cost_VS_Request_Price = Request["TextBox" + (i + 8)],
                    Yearly_Forecast = Request["TextBox" + (i + 9)],
                    Yearly_Amount = Request["TextBox" + (i + 10)],
                    PPV = Request["TextBox" + (i + 11)],
                    Current_Stock = Request["TextBox" + (i + 12)],
                    Main_Material_Cost_Change = Request["TextBox" + (i + 13)],
                    Main_Material_Cost_VS_Total_Cost = Request["TextBox" + (i + 14)],
                    Required_Cost_Change = Request["TextBox" + (i + 15)],
                    Effective_Date = Request["TextBox" + (i + 16)],
                    Remark = Request["TextBox" + (i + 17)],
                };
                list.Add(item);
                i += 17;
            }

            if (check)
            {
                Session["PurchaseChangesRange"] = false;
                for (int i = 0; i < list.Count; i++)
                {
                    item = list[i];

                    if (item.Yearly_Amount == "" && item.Request_Price_VS_Last_PO_Price == "")
                    {
                        continue;
                    }
                    try
                    {

                        if (Convert.ToInt64(item.Yearly_Amount) > 100000 && Convert.ToSingle(item.Request_Price_VS_Last_PO_Price.Replace("%", "")) > 5)
                        {
                            Session["PurchaseChangesRange"] = true;
                        }
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
            }
            asPurchaseChanges.Remark = TextBox331.Text;
            int join = PurchaseChanges_BLL.update(asPurchaseChanges, list);
            if (join > 0)
            {
                As_Write write = new As_Write
                {
                    Employee_ID = Session["Employee_ID"].ToString(),
                    Form_ID = asPurchaseChanges.Form_ID,
                    Form_Fill_Time = DateTime.Now.ToString(),
                    Manul = str,
                    Temp_Vendor_ID = Convert.ToString(ViewState["tempVendorID"])
                }; //将填写信息记录
                if (flag == 1)
                {
                    LocalScriptManager.createManagerScript(Page, "closeWaiting();message('保存成功！')", "save");
                    if (Write_BLL.addWrite(write)<=0)
                    {
                        LocalScriptManager.createManagerScript(Page, "closeWaiting();message('保存成功，但日志写入失败！')", "save");
                    }
                }
                
            }
            else
            {
                LocalScriptManager.createManagerScript(Page, "closeWaiting();message('数据库更新失败！')", "save");
            }

        }


        /// <summary>
        /// 确定审批流程
        /// </summary>
        /// <param name="formTypeID"></param>
        /// <param name="formId"></param>
        public void approveAssess(string formID)
        {
            if (LocalApproveManager.doAddApprove(formID, Convert.ToString(ViewState["formName"]), Convert.ToString(ViewState["formTypeID"]), Convert.ToString(ViewState["tempVendorID"]), -1,new List<object>() {AddApproveType.Purchase,checkTotal()}) && checkTotal())
            {
                LocalScriptManager.createManagerScript(this.Page, string.Format("messageConfirm('{0}','{1}')", "提交成功，请注意此表最终需要kci审批", "EmployeeVendor.aspx"), "submited");
            }
            else
            {
                LocalScriptManager.createManagerScript(this.Page, string.Format("messageConfirm('{0}','{1}')", "提交成功，自动判定为无需kci审批", "EmployeeVendor.aspx"), "submited");
            }
        }

        /// <summary>
        /// 检查更改的金额是否大于5%或者大于10w，是true，否则false
        /// </summary>
        /// <returns></returns>
        private bool checkTotal()
        {
            return (bool)Session["PurchaseChangesRange"];
        }

        public void Button1_Click(object sender, EventArgs e)//提交按钮
        {
            bool singleFileSubmit = VendorSingleFile_BLL.isSingleFileSubmit(Convert.ToString(ViewState["form_ID"]));
            if (!singleFileSubmit)
            {
                LocalScriptManager.createManagerScript(Page, "window.alert('请提交报价单')", "uploadsinglefile");
                return;
            }

            if (Convert.ToString(ViewState["submit"]).Equals("yes"))
            {
                save(2, "提交表格",true);
                approveAssess(Convert.ToString(ViewState["form_ID"]));
            }
            else
            {
                LocalApproveManager.showPendingReason(Page, Convert.ToString(ViewState["tempVendorID"]), true);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            save(1, "保存表格");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeVendor.aspx");
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