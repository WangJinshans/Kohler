using System;
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
        public string FORM_NAME = "价格调整审批";
        public string FORM_TYPE_ID = "023";
        private static string factory = "";
        private string tempVendorID = "";
        private string tempVendorName = "";
        private string formID = "";
        private string submit = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //获取session信息
                getSessionInfo();


                //检查表格是否已经存在
                int check = PurchaseChanges_BLL.check(formID);
                if (check == 0)
                {
                    As_Purchase_Changes asPurchaseChanges = new As_Purchase_Changes
                    {
                        Temp_Vendor_ID = tempVendorID,
                        Form_Type_ID = FORM_TYPE_ID,
                        Vendor = tempVendorName,
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
                        //获取formID信息
                        getSessionInfo();

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
        }

        /// <summary>
        /// 重新读取session
        /// </summary>
        private void getSessionInfo()
        {
            //初始化常量（伪）
            FORM_TYPE_ID = Request.QueryString["type"];
            FORM_NAME = FormType_BLL.getFormNameByTypeID(FORM_TYPE_ID);

            tempVendorID = Session["tempVendorID"].ToString();
            tempVendorName = TempVendor_BLL.getTempVendorName(tempVendorID);
            factory = Session["Factory_Name"].ToString().Trim();
            formID = VendorRiskAnalysis_BLL.getFormID(tempVendorID, FORM_TYPE_ID, factory);
            submit = Request.QueryString["submit"];
        }

        /// <summary>
        /// 绑定此表对应的文件信息
        /// </summary>
        public void bindingFormWithFile()
        {
            getSessionInfo();
            if (CheckFile_BLL.bindFormFile(FORM_TYPE_ID, tempVendorID, formID) == 0)
            {
                Response.Write("<script>window.alert('表格初始化错误（文件绑定失败）！')</script>");//若没有记录 返回文件不全
            }
        }

        private void show()
        {
            As_Purchase_Changes asPurchaseChanges = PurchaseChanges_BLL.get(formID);
            List<As_Purchase_Changes_Item> list = PurchaseChanges_BLL.getItems(formID);

            if (asPurchaseChanges != null)
            {
                TextBox1.Text = asPurchaseChanges.Vendor_Code;
                TextBox2.Text = asPurchaseChanges.Vendor;
                TextBox3.Text = asPurchaseChanges.Currency;
                TextBox4.Text = asPurchaseChanges.Date;
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
            
        }


        private void save(int flag, string str, bool check = false)
        {
            //读取session
            getSessionInfo();

            As_Purchase_Changes asPurchaseChanges = new As_Purchase_Changes()
            {
                Vendor_Code = TextBox1.Text,
                Vendor = TextBox2.Text,
                Currency = TextBox3.Text,
                Date = TextBox4.Text,
                Form_ID = formID
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

                        if (Convert.ToInt64(item.Yearly_Amount) > 100000 &&
                            Convert.ToSingle(item.Request_Price_VS_Last_PO_Price.Replace("%", "")) > 5)
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

            int join = PurchaseChanges_BLL.update(asPurchaseChanges, list);
            if (join > 0)
            {
                As_Write write = new As_Write
                {
                    Employee_ID = Session["Employee_ID"].ToString(),
                    Form_ID = asPurchaseChanges.Form_ID,
                    Form_Fill_Time = DateTime.Now.ToString(),
                    Manul = str,
                    Temp_Vendor_ID = tempVendorID
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
        public void approveAssess(string formId)
        {
            if (LocalApproveManager.doAddApprove(formId, FORM_NAME, FORM_TYPE_ID, tempVendorID,-1,new List<object>() {AddApproveType.Purchase,checkTotal()}) && checkTotal())
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
            //session
            getSessionInfo();
            if (submit == "yes")
            {
                save(2, "提交表格",true);
                approveAssess(formID);
            }
            else
            {
                LocalApproveManager.showPendingReason(Page, tempVendorID, true);
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


    }
}