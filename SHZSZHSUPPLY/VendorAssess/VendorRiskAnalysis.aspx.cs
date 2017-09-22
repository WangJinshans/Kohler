using BLL;
using Model;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SHZSZHSUPPLY.VendorAssess
{
    public partial class VendorRiskAnalysis : System.Web.UI.Page
    {
        public string FORM_NAME = "供应商风险分析表";
        public string FORM_TYPE_ID = "003";
        private static string factory = "";
        private string tempVendorID = "";
        private string tempVendorName = "";
        private string formID = "";
        private string submit = "";
        public const byte LOW = 0;
        public const byte MEDIUM = 1;
        public const byte HIGH = 2;

        public const string formNameNumber = "PR-05-13-5";

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //获取session信息
                getSessionInfo();

                
                //检查表格是否已经存在
                int check = VendorRiskAnalysis_BLL.checkVendorRiskAnalysis(formID);
                if (check == 0)
                {
                    As_Vendor_Risk vendorRisk = new As_Vendor_Risk();
                    vendorRisk.Temp_Vendor_ID = tempVendorID;
                    vendorRisk.Form_Type_ID = FORM_TYPE_ID;
                    vendorRisk.Supplier = tempVendorName;
                    vendorRisk.Flag = 0;
                    vendorRisk.Factory_Name = Employee_BLL.getEmployeeFactory(Session["Employee_ID"].ToString());
                    int n = VendorRiskAnalysis_BLL.addVendorRisk(vendorRisk);
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
                    showVendorRiskAnalysis();
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
            formID = VendorRiskAnalysis_BLL .getFormID(tempVendorID,FORM_TYPE_ID,factory);
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

        /// <summary>
        /// 显示分析分析表
        /// </summary>
        private void showVendorRiskAnalysis()
        {
            As_Vendor_Risk vendorRisk = VendorRiskAnalysis_BLL.checkFlag(formID);
            Dictionary<string, string> notes = VendorRiskAnalysis_BLL.checkNotes(formID);
            if (vendorRisk != null)
            {
                txbProduct.Text = vendorRisk.Product;
                txbVendor.Text = vendorRisk.Supplier;
                txbPartNo.Text = vendorRisk.Part_No;
                TextBox1.Text = vendorRisk.Manufacturer;
                TextBox2.Text = vendorRisk.Annual_Spend.ToString();
                setSelected(vendorRisk.Overall_Risk_Category, new[] { RadioButton1, RadioButton2, RadioButton3 });
                TextBox3.Text = vendorRisk.General_Assessment;
                TextBox4.Text = vendorRisk.Contingency_Plan;
                TextBox5.Text = vendorRisk.Urgency;
                TextBox6.Text = vendorRisk.Complete_By;
                TextBox7.Text = vendorRisk.Compiled_By;
                TextBox8.Text = vendorRisk.Date.ToString();
                setSelected(vendorRisk.Corporate_Strategy, new[] { RadioButton4, RadioButton5, RadioButton6 });
                setSelected(vendorRisk.Stability, new[] { RadioButton7, RadioButton8, RadioButton9 });
                setSelected(vendorRisk.Contractual, new[] { RadioButton10, RadioButton11, RadioButton12 });
                setSelected(vendorRisk.Third_Party_Involvement, new[] { RadioButton13, RadioButton14, RadioButton15 });
                setSelected(vendorRisk.Location, new[] { RadioButton16, RadioButton17, RadioButton18 });
                setSelected(vendorRisk.Transport, new[] { RadioButton19, RadioButton20, RadioButton21 });
                setSelected(vendorRisk.Seasonality, new[] { RadioButton22, RadioButton23, RadioButton24 });
                setSelected(vendorRisk.Environmental_Capacity, new[] { RadioButton25, RadioButton26, RadioButton27 });
                setSelected(vendorRisk.Stocks, new[] { RadioButton28, RadioButton29, RadioButton30 });
                setSelected(vendorRisk.Dedicated_Facilities, new[] { RadioButton31, RadioButton32, RadioButton33 });
                setSelected(vendorRisk.Recycling_Policy, new[] { RadioButton34, RadioButton35, RadioButton36 });
                setSelected(vendorRisk.Communication, new[] { RadioButton37, RadioButton38, RadioButton39 });
                setSelected(vendorRisk.Financial, new[] { RadioButton40, RadioButton41, RadioButton42 });
                setSelected(vendorRisk.Kohler_Forward_Plan, new[] { RadioButton43, RadioButton44, RadioButton45 });
                setSelected(vendorRisk.Supplier_Forward_Plan, new[] { RadioButton46, RadioButton47, RadioButton48 });
                setSelected(vendorRisk.Change_Of_Source, new[] { RadioButton49, RadioButton50, RadioButton51 });
                setSelected(vendorRisk.Annual_Shutdown, new[] { RadioButton52, RadioButton53, RadioButton54 });
                setSelected(vendorRisk.Computer_Systems, new[] { RadioButton55, RadioButton56, RadioButton57 });
                setSelected(vendorRisk.Intellectual_Property_Kohler, new[] { RadioButton58, RadioButton59, RadioButton60 });
                setSelected(vendorRisk.Relationship, new[] { RadioButton61, RadioButton62, RadioButton63 });
                setSelected(vendorRisk.Technological_Capacity, new[] { RadioButton64, RadioButton65, RadioButton66 });
                setSelected(vendorRisk.Machine_Breakdown, new[] { RadioButton67, RadioButton68, RadioButton69 });
                setSelected(vendorRisk.Quality_Accreditation, new[] { RadioButton70, RadioButton71, RadioButton72 });
                setSelected(vendorRisk.Audit_Failure, new[] { RadioButton73, RadioButton74, RadioButton75 });
                setSelected(vendorRisk.Alternative_Supplier, new[] { RadioButton76, RadioButton77, RadioButton78 });
                setSelected(vendorRisk.Alternative_Materials, new[] { RadioButton79, RadioButton80, RadioButton81 });
                setSelected(vendorRisk.Complexity, new[] { RadioButton82, RadioButton83, RadioButton84 });
                setSelected(vendorRisk.Research_And_Development, new[] { RadioButton85, RadioButton86, RadioButton87 });
                setSelected(vendorRisk.Rejections_Or_Complaints, new[] { RadioButton88, RadioButton89, RadioButton90 });
                setSelected(vendorRisk.Specifications, new[] { RadioButton91, RadioButton92, RadioButton93 });

                foreach (Control item in this.Controls[3].Controls)
                {
                    if (item is TextBox && item.ID.Contains("TextBox") && Convert.ToInt32(item.ID.Replace("TextBox", "")) >= 10)
                    {
                        try
                        {
                            ((TextBox)item).Text = notes[item.ID];
                        }
                        catch (KeyNotFoundException)
                        {
                            continue;
                        }
                    }
                }
            }
            //展示附件
            showfilelist(formID);
        }

        /// <summary>
        /// 显示文件
        /// </summary>
        /// <param name="FormID"></param>
        private void showfilelist(string FormID)
        {
            return;
            As_Form_File Form_File = new As_Form_File();
            string sql = "select * from As_Form_File where Form_ID='" + FormID + "' and [File_ID] in (select [File_ID] from As_Vendor_FileType where Temp_Vendor_ID='" + tempVendorID + "') and Form_ID in (select Form_ID from As_Vendor_FormType where Temp_Vendor_ID='" + tempVendorID + "')";
            PagedDataSource objpds = new PagedDataSource();
            objpds.DataSource = FormFile_BLL.listFile(sql);
            GridView2.DataSource = objpds;
            GridView2.DataBind();
        }

        /// <summary>
        /// 保存表格
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="manul"></param>
        /// <returns></returns>
        private As_Vendor_Risk saveForm(int flag, string manul)
        {
            //读取session
            getSessionInfo();

            As_Vendor_Risk vendorRisk = new As_Vendor_Risk();
            vendorRisk.Form_ID = formID;
            vendorRisk.Form_Type_ID = FORM_TYPE_ID;
            vendorRisk.Temp_Vendor_ID = tempVendorID;
            vendorRisk.Product = txbProduct.Text.Trim();
            vendorRisk.Supplier = txbVendor.Text.Trim();
            vendorRisk.Part_No = txbPartNo.Text.Trim();
            vendorRisk.Manufacturer = TextBox1.Text.Trim();
            vendorRisk.Where_Used = txbWhereUsed.Text.Trim();
            vendorRisk.Annual_Spend = Convert.ToDouble(TextBox2.Text.Trim());
            vendorRisk.Overall_Risk_Category = Convert.ToByte(getSelected(new[] { RadioButton1, RadioButton2, RadioButton3 }));
            vendorRisk.General_Assessment = TextBox3.Text.Trim();
            vendorRisk.Contingency_Plan = TextBox4.Text.Trim();
            vendorRisk.Urgency = TextBox5.Text.Trim();
            vendorRisk.Complete_By = TextBox6.Text.Trim();
            vendorRisk.Compiled_By = TextBox7.Text.Trim();

            try
            {
                vendorRisk.Date = Convert.ToDateTime(TextBox8.Text.Trim());
            }
            catch (Exception)
            {
                vendorRisk.Date = DateTime.Now;
            }

            vendorRisk.Corporate_Strategy = Convert.ToByte(getSelected(new[] { RadioButton4, RadioButton5, RadioButton6 }));
            vendorRisk.Stability = Convert.ToByte(getSelected(new[] { RadioButton7, RadioButton8, RadioButton9 }));
            vendorRisk.Contractual = Convert.ToByte(getSelected(new[] { RadioButton10, RadioButton11, RadioButton12 }));
            vendorRisk.Third_Party_Involvement = Convert.ToByte(getSelected(new[] { RadioButton13, RadioButton14, RadioButton15 }));
            vendorRisk.Location = Convert.ToByte(getSelected(new[] { RadioButton16, RadioButton17, RadioButton18 }));
            vendorRisk.Transport = Convert.ToByte(getSelected(new[] { RadioButton19, RadioButton20, RadioButton21 }));
            vendorRisk.Seasonality = Convert.ToByte(getSelected(new[] { RadioButton22, RadioButton23, RadioButton24 }));
            vendorRisk.Environmental_Capacity = Convert.ToByte(getSelected(new[] { RadioButton25, RadioButton26, RadioButton27 }));
            vendorRisk.Stocks = Convert.ToByte(getSelected(new[] { RadioButton28, RadioButton29, RadioButton30 }));
            vendorRisk.Dedicated_Facilities = Convert.ToByte(getSelected(new[] { RadioButton31, RadioButton32, RadioButton33 }));
            vendorRisk.Recycling_Policy = Convert.ToByte(getSelected(new[] { RadioButton34, RadioButton35, RadioButton36 }));
            vendorRisk.Communication = Convert.ToByte(getSelected(new[] { RadioButton37, RadioButton38, RadioButton39 }));
            vendorRisk.Financial = Convert.ToByte(getSelected(new[] { RadioButton40, RadioButton41, RadioButton42 }));
            vendorRisk.Kohler_Forward_Plan = Convert.ToByte(getSelected(new[] { RadioButton43, RadioButton44, RadioButton45 }));
            vendorRisk.Supplier_Forward_Plan = Convert.ToByte(getSelected(new[] { RadioButton46, RadioButton47, RadioButton48 }));
            vendorRisk.Change_Of_Source = Convert.ToByte(getSelected(new[] { RadioButton49, RadioButton50, RadioButton51 }));
            vendorRisk.Annual_Shutdown = Convert.ToByte(getSelected(new[] { RadioButton52, RadioButton53, RadioButton54 }));
            vendorRisk.Computer_Systems = Convert.ToByte(getSelected(new[] { RadioButton55, RadioButton56, RadioButton57 }));
            vendorRisk.Intellectual_Property_Kohler = Convert.ToByte(getSelected(new[] { RadioButton58, RadioButton59, RadioButton60 }));
            vendorRisk.Relationship = Convert.ToByte(getSelected(new[] { RadioButton61, RadioButton62, RadioButton63 }));
            vendorRisk.Technological_Capacity = Convert.ToByte(getSelected(new[] { RadioButton64, RadioButton65, RadioButton66 }));
            vendorRisk.Machine_Breakdown = Convert.ToByte(getSelected(new[] { RadioButton67, RadioButton68, RadioButton69 }));
            vendorRisk.Quality_Accreditation = Convert.ToByte(getSelected(new[] { RadioButton70, RadioButton71, RadioButton72 }));
            vendorRisk.Audit_Failure = Convert.ToByte(getSelected(new[] { RadioButton73, RadioButton74, RadioButton75 }));
            vendorRisk.Alternative_Supplier = Convert.ToByte(getSelected(new[] { RadioButton76, RadioButton77, RadioButton78 }));
            vendorRisk.Alternative_Materials = Convert.ToByte(getSelected(new[] { RadioButton79, RadioButton80, RadioButton81 }));
            vendorRisk.Complexity = Convert.ToByte(getSelected(new[] { RadioButton82, RadioButton83, RadioButton84 }));
            vendorRisk.Research_And_Development = Convert.ToByte(getSelected(new[] { RadioButton85, RadioButton86, RadioButton87 }));
            vendorRisk.Rejections_Or_Complaints = Convert.ToByte(getSelected(new[] { RadioButton88, RadioButton89, RadioButton90 }));
            vendorRisk.Specifications = Convert.ToByte(getSelected(new[] { RadioButton91, RadioButton92, RadioButton93 }));
            vendorRisk.Flag = flag;                       //更改表格的标志位

            IList<As_Vendor_Risk_Notes> list = new List<As_Vendor_Risk_Notes>();
            foreach (Control item in this.Controls[3].Controls)
            {
                if (item is TextBox && ((TextBox)item).Text != "" && item.ID.Contains("TextBox") && Convert.ToInt32(item.ID.Replace("TextBox", "")) >= 10)
                {
                    As_Vendor_Risk_Notes notes = new As_Vendor_Risk_Notes();
                    notes.Notes = ((TextBox)item).Text;
                    notes.Property_Name = item.ID;
                    notes.Form_ID = formID;
                    list.Add(notes);
                }
            }


            int join = VendorRiskAnalysis_BLL.updateVendorRisk(vendorRisk, list);
            if (join > 0)
            {
                As_Write write = new As_Write();                     //将填写信息记录
                write.Employee_ID = Session["Employee_ID"].ToString();
                write.Form_ID = vendorRisk.Form_ID;
                write.Form_Fill_Time = DateTime.Now.ToString();
                write.Manul = manul;
                write.Temp_Vendor_ID = tempVendorID;
                Write_BLL.addWrite(write);
                if (flag == 1)
                {
                    Response.Write("<script>window.alert('保存成功！')</script>");
                }
                return vendorRisk;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 确定审批流程
        /// </summary>
        /// <param name="formTypeID"></param>
        /// <param name="formId"></param>
        public void approveAssess(string formId)
        {
            if (LocalApproveManager.doAddApprove(formId, FORM_NAME, FORM_TYPE_ID, tempVendorID))
            {
                Response.Write("<script>window.alert('提交成功！');window.location.href='EmployeeVendor.aspx'</script>");
            }
        }


        public void Button1_Click(object sender, EventArgs e)//提交按钮
        {
            //session
            getSessionInfo();
            if (submit == "yes")
            {
                saveForm(2, "提交表格");
                approveAssess(formID);
            }
            else
            {
                Response.Write("<script>window.alert('无法提交！')</script>");
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

        

        /// <summary>
        /// 获取low medium high三个哪一个被选择
        /// </summary>
        /// <param name="rb"></param>
        /// <returns></returns>
        private byte getSelected(RadioButton[] rb)
        {
            if (rb[0].Checked)
            {
                return LOW;
            }
            else if(rb[1].Checked)
            {
                return MEDIUM;
            }
            else if(rb[2].Checked)
            {
                return HIGH;
            }
            return 3;
        }

        private void setSelected(byte? selected,RadioButton[] rb)
        {
            switch (selected)
            {
                case 0:
                    rb[0].Checked = true;
                    break;
                case 1:
                    rb[1].Checked = true;
                    break;
                case 2:
                    rb[2].Checked = true;
                    break;
                default:
                    break;
            }
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            string fileID = GridView2.Rows[drv.RowIndex].Cells[1].Text.ToString().Trim();//获取fileID
            if (e.CommandName == "view")
            {
                string filePath = VendorCreation_BLL.getFilePath(fileID);
                if (filePath != "")
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>viewFile('" + filePath + "');</script>");
                }
            }
        }
    }
}