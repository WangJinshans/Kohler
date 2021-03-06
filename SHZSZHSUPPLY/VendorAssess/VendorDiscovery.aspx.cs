﻿using BLL;
using BLL.VendorAssess;
using Model;
using MODEL.VendorAssess;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AendorAssess
{
    public partial class VendorDiscovery : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Image1.Visible = false;
            Image2.Visible = false;
            Image3.Visible = false;

            LocalScriptManager.CreateScript(Page, "initTextarea()", "initTextbox");

            if (!IsPostBack)
            {
                //获取session信息
                getSessionInfo();

                int check = VendorDiscovery_BLL.checkVendorDiscovery(Convert.ToString(ViewState["form_ID"]));//检查是否存在这张表
                if (check == 0)//数据库中不存在这张表，则自动初始化
                {
                    As_Vendor_Discovery Vendor_Discovery = new As_Vendor_Discovery();
                    Vendor_Discovery.Form_Type_ID = "001";
                    Vendor_Discovery.Temp_Vendor_Name = Convert.ToString(ViewState["tempVendorName"]);
                    Vendor_Discovery.Temp_Vendor_ID = Convert.ToString(ViewState["tempVendorID"]);
                    Vendor_Discovery.Flag = 0;//将表格标志位信息改为已填写
                    Vendor_Discovery.Factory_Name = Session["Factory_Name"].ToString();

                    int n = VendorDiscovery_BLL.addVendorDiscovery(Vendor_Discovery);
                    if (n == 0)
                    {
                        Response.Write("<script>window.alert('表格初始化错误（新建插入失败）！')</script>");
                        return;
                    }
                    else
                    {
                        string formID = VendorDiscovery_BLL.getVendorDiscoveryFormID(Convert.ToString(ViewState["tempVendorID"]), "001", Session["Factory_Name"].ToString().Trim(), n);
                        ViewState.Add("form_ID", formID);
                        //每次添加表格添加到As_Vendor_MutipleForm中 
                        As_MutipleForm forms = new As_MutipleForm();
                        forms.Temp_Vendor_ID = Convert.ToString(ViewState["tempVendorID"]);
                        forms.Temp_Vendor_Name = Convert.ToString(ViewState["tempVendorName"]);
                        forms.Form_Type_ID = "001";
                        forms.Form_ID = Convert.ToString(ViewState["form_ID"]);
                        forms.Flag = 0;
                        forms.Factory_Name = Session["Factory_Name"].ToString().Trim();
                        Vendor_MutipleForm_BLL.addVendorMutileForms(forms);

                        bindingFormWithFile();
                        showfilelist(Convert.ToString(ViewState["form_ID"]));
                    }
                }
                else
                {
                    showVendorDiscovery();
                }
            }
            else
            {
                //处理postback回调
                switch (Request["__EVENTTARGET"])
                {
                    case "submitForm":
                        LocalApproveManager.submitForm();
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

        /// <summary>
        /// 显示表格
        /// </summary>
        private void showVendorDiscovery()
        {
            As_Vendor_Discovery Vendor_Discovery = new As_Vendor_Discovery();
            Vendor_Discovery = VendorDiscovery_BLL.checkFlag(Convert.ToString(ViewState["form_ID"]));
            if (Vendor_Discovery!=null)
            {
                TextBox1.Text = Vendor_Discovery.File_Time;
                TextBox2.Text = Vendor_Discovery.Temp_Vendor_Name;
                TextBox3.Text = Vendor_Discovery.Legal_Person;
                TextBox4.Text = Vendor_Discovery.Address;
                TextBox5.Text = Vendor_Discovery.Tel;
                TextBox6.Text = Vendor_Discovery.Fax;
                TextBox7.Text = Vendor_Discovery.Product_Name_One;
                TextBox8.Text = Vendor_Discovery.Size_One;
                TextBox9.Text = Vendor_Discovery.Quality_One;
                TextBox10.Text = Vendor_Discovery.Position_Environment_One;
                TextBox11.Text = Vendor_Discovery.Envir_Protection_System_One;
                TextBox49.Text = Vendor_Discovery.Product_Name_Two;
                TextBox50.Text = Vendor_Discovery.Size_Two;
                TextBox51.Text = Vendor_Discovery.Quality_Two;
                TextBox52.Text = Vendor_Discovery.Position_Environment_Two;
                TextBox53.Text = Vendor_Discovery.Envir_Protection_System_Two;
                TextBox54.Text = Vendor_Discovery.Product_Name_Three;
                TextBox55.Text = Vendor_Discovery.Size_Three;
                TextBox56.Text = Vendor_Discovery.Quality_Three;
                TextBox57.Text = Vendor_Discovery.Position_Environment_Three;
                TextBox58.Text = Vendor_Discovery.Envir_Protection_System_Three;
                TextBox12.Text = Vendor_Discovery.Product_Ability;
                TextBox13.Text = Vendor_Discovery.Last_Sale;
                TextBox14.Text = Vendor_Discovery.Main_CusMark_One;
                TextBox41.Text = Vendor_Discovery.Main_CusMark_Two;
                TextBox42.Text = Vendor_Discovery.Main_CusMark_Three;
                TextBox15.Text = Vendor_Discovery.Register_Capital;
                TextBox16.Text = Vendor_Discovery.Fixed_Assets;
                TextBox17.Text = Vendor_Discovery.Flow_Capital;
                TextBox18.Text = Vendor_Discovery.Pay_Condition;
                TextBox19.Text = Vendor_Discovery.Employee_Num;
                TextBox20.Text = Vendor_Discovery.Manager;
                TextBox21.Text = Vendor_Discovery.Quality_Person;
                TextBox22.Text = Vendor_Discovery.Tech_Person;
                TextBox23.Text = Vendor_Discovery.Company_Area;
                TextBox24.Text = Vendor_Discovery.Factory_Area;
                TextBox25.Text = Vendor_Discovery.Entrepot_Area;
                TextBox26.Text = Vendor_Discovery.Week_Wrok_Time;
                TextBox27.Text = Vendor_Discovery.Week_Turn_Num;
                TextBox28.Text = Vendor_Discovery.Produce_Load;
                TextBox31.Text = Vendor_Discovery.Product_material_One;
                TextBox32.Text = Vendor_Discovery.Region_One;
                TextBox33.Text = Vendor_Discovery.Material_Store_Conditon_One;
                TextBox64.Text = Vendor_Discovery.Product_material_Two;
                TextBox65.Text = Vendor_Discovery.Region_Two;
                TextBox66.Text = Vendor_Discovery.Material_Store_Conditon_Two;
                TextBox67.Text = Vendor_Discovery.Product_material_Three;
                TextBox68.Text = Vendor_Discovery.Region_Three;
                TextBox69.Text = Vendor_Discovery.Material_Store_Conditon_Three;
                TextBox29.Text = Vendor_Discovery.ISO;
                TextBox30.Text = Vendor_Discovery.Transport;
                TextBox43.Text = Vendor_Discovery.Device_Name;
                TextBox44.Text = Vendor_Discovery.Device_Size;
                TextBox45.Text = Vendor_Discovery.Device_Year;
                TextBox46.Text = Vendor_Discovery.Device_Factory;
                TextBox47.Text = Vendor_Discovery.Device_Condition;
                TextBox34.Text = Vendor_Discovery.Check_Device;
                TextBox35.Text = Vendor_Discovery.Send_Ability;
                TextBox59.Text = Vendor_Discovery.Purchase_Period;
                TextBox60.Text = Vendor_Discovery.Min_Order_Num;
                TextBox36.Text = Vendor_Discovery.Vendor_Participate;
                TextBox37.Text = Vendor_Discovery.Produce_Flow;
                TextBox38.Text = Vendor_Discovery.Product_Book_Flow;
                TextBox39.Text = Vendor_Discovery.Manage_Dimension;
                TextBox40.Text = Vendor_Discovery.Employee_Experience;
                TextBox48.Text = Vendor_Discovery.Conclusion;
            }
            //showapproveform(formID);

            //展示附件
            showfilelist(Convert.ToString(ViewState["form_ID"]));
        }

        /// <summary>
        /// 显示文件列表
        /// </summary>
        /// <param name="FormID"></param>
        public void showfilelist(string FormID)
        {
            //return;
            //As_Form_File Form_File = new As_Form_File();
            //string sql = "select * from As_Form_File where Form_ID='" + FormID + "'  and Form_ID in (select Form_ID from As_Vendor_FormType where Temp_Vendor_ID='" + tempVendorID + "')";
            //PagedDataSource objpds = new PagedDataSource();
            //objpds.DataSource = FormFile_BLL.listFile(sql);
            //GridView2.DataSource = objpds;
            //GridView2.DataBind();
        }

        /// <summary>
        /// 保存表格
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="manul"></param>
        /// <returns></returns>
        private As_Vendor_Discovery saveForm(int flag, string manul)
        {
            As_Vendor_Discovery Vendor_Discovery = new As_Vendor_Discovery();
            Vendor_Discovery.Form_ID = Convert.ToString(ViewState["form_ID"]);
            Vendor_Discovery.Form_Type_ID = Convert.ToString(ViewState["formTypeID"]);
            Vendor_Discovery.File_Time = Convert.ToString(TextBox1.Text.Trim());
            Vendor_Discovery.Temp_Vendor_Name = TextBox2.Text.Trim();
            Vendor_Discovery.Legal_Person = Convert.ToString(TextBox3.Text.Trim());
            Vendor_Discovery.Address = Convert.ToString(TextBox4.Text.Trim());
            Vendor_Discovery.Tel = Convert.ToString(TextBox5.Text.Trim());
            Vendor_Discovery.Fax = Convert.ToString(TextBox6.Text.Trim());
            Vendor_Discovery.Product_Name_One = Convert.ToString(TextBox7.Text.Trim());
            Vendor_Discovery.Size_One = Convert.ToString(TextBox8.Text.Trim());
            Vendor_Discovery.Quality_One = Convert.ToString(TextBox9.Text.Trim());
            Vendor_Discovery.Position_Environment_One = Convert.ToString(TextBox10.Text.Trim());
            Vendor_Discovery.Envir_Protection_System_One = Convert.ToString(TextBox11.Text.Trim());
            Vendor_Discovery.Product_Name_Two = Convert.ToString(TextBox49.Text.Trim());
            Vendor_Discovery.Size_Two = Convert.ToString(TextBox50.Text.Trim());
            Vendor_Discovery.Quality_Two = Convert.ToString(TextBox51.Text.Trim());
            Vendor_Discovery.Position_Environment_Two = Convert.ToString(TextBox52.Text.Trim());
            Vendor_Discovery.Envir_Protection_System_Two = Convert.ToString(TextBox53.Text.Trim());
            Vendor_Discovery.Product_Name_Three = Convert.ToString(TextBox54.Text.Trim());
            Vendor_Discovery.Size_Three = Convert.ToString(TextBox55.Text.Trim());
            Vendor_Discovery.Quality_Three = Convert.ToString(TextBox56.Text.Trim());
            Vendor_Discovery.Position_Environment_Three = Convert.ToString(TextBox57.Text.Trim());
            Vendor_Discovery.Envir_Protection_System_Three = Convert.ToString(TextBox58.Text.Trim());
            Vendor_Discovery.Product_Ability = Convert.ToString(TextBox12.Text.Trim());
            Vendor_Discovery.Last_Sale = Convert.ToString(TextBox13.Text.Trim());
            Vendor_Discovery.Main_CusMark_One = Convert.ToString(TextBox14.Text.Trim());
            Vendor_Discovery.Main_CusMark_Two = Convert.ToString(TextBox41.Text.Trim());
            Vendor_Discovery.Main_CusMark_Three = Convert.ToString(TextBox42.Text.Trim());
            Vendor_Discovery.Register_Capital = Convert.ToString(TextBox15.Text.Trim());
            Vendor_Discovery.Fixed_Assets = Convert.ToString(TextBox16.Text.Trim());
            Vendor_Discovery.Flow_Capital = Convert.ToString(TextBox17.Text.Trim());
            Vendor_Discovery.Pay_Condition = Convert.ToString(TextBox18.Text.Trim());
            Vendor_Discovery.Employee_Num = Convert.ToString(TextBox19.Text.Trim());
            Vendor_Discovery.Manager = Convert.ToString(TextBox20.Text.Trim());
            Vendor_Discovery.Quality_Person = Convert.ToString(TextBox21.Text.Trim());
            Vendor_Discovery.Tech_Person = Convert.ToString(TextBox22.Text.Trim());
            Vendor_Discovery.Company_Area = Convert.ToString(TextBox23.Text.Trim());
            Vendor_Discovery.Factory_Area = Convert.ToString(TextBox24.Text.Trim());
            Vendor_Discovery.Entrepot_Area = Convert.ToString(TextBox25.Text.Trim());
            Vendor_Discovery.Week_Wrok_Time = Convert.ToString(TextBox26.Text.Trim());
            Vendor_Discovery.Week_Turn_Num = Convert.ToString(TextBox27.Text.Trim());
            Vendor_Discovery.Produce_Load = Convert.ToString(TextBox28.Text.Trim());
            Vendor_Discovery.Product_material_One = Convert.ToString(TextBox31.Text.Trim());
            Vendor_Discovery.Region_One = Convert.ToString(TextBox32.Text.Trim());
            Vendor_Discovery.Material_Store_Conditon_One = Convert.ToString(TextBox33.Text.Trim());
            Vendor_Discovery.Product_material_Two = Convert.ToString(TextBox64.Text.Trim());
            Vendor_Discovery.Region_Two = Convert.ToString(TextBox65.Text.Trim());
            Vendor_Discovery.Material_Store_Conditon_Two = Convert.ToString(TextBox66.Text.Trim());
            Vendor_Discovery.Product_material_Three = Convert.ToString(TextBox67.Text.Trim());
            Vendor_Discovery.Region_Three = Convert.ToString(TextBox68.Text.Trim());
            Vendor_Discovery.Material_Store_Conditon_Three = Convert.ToString(TextBox69.Text.Trim());
            Vendor_Discovery.ISO = Convert.ToString(TextBox29.Text.Trim());
            Vendor_Discovery.Transport = Convert.ToString(TextBox30.Text.Trim());
            Vendor_Discovery.Device_Name = Convert.ToString(TextBox43.Text.Trim());
            Vendor_Discovery.Device_Size = Convert.ToString(TextBox44.Text.Trim());
            Vendor_Discovery.Device_Year = Convert.ToString(TextBox45.Text.Trim());
            Vendor_Discovery.Device_Factory = Convert.ToString(TextBox46.Text.Trim());
            Vendor_Discovery.Device_Condition = Convert.ToString(TextBox47.Text.Trim());
            Vendor_Discovery.Check_Device = Convert.ToString(TextBox34.Text.Trim());
            Vendor_Discovery.Send_Ability = Convert.ToString(TextBox35.Text.Trim());
            Vendor_Discovery.Purchase_Period = Convert.ToString(TextBox59.Text.Trim());
            Vendor_Discovery.Min_Order_Num = Convert.ToString(TextBox60.Text.Trim());
            Vendor_Discovery.Vendor_Participate = Convert.ToString(TextBox36.Text.Trim());
            Vendor_Discovery.Produce_Flow = Convert.ToString(TextBox37.Text.Trim());
            Vendor_Discovery.Product_Book_Flow = Convert.ToString(TextBox38.Text.Trim());
            Vendor_Discovery.Manage_Dimension = Convert.ToString(TextBox39.Text.Trim());
            Vendor_Discovery.Employee_Experience = Convert.ToString(TextBox40.Text.Trim());
            Vendor_Discovery.Conclusion = Convert.ToString(TextBox48.Text.Trim());
            Vendor_Discovery.Flag = flag;                       //更改表格的标志位
            int join = VendorDiscovery_BLL.updateVendorDiscovery(Vendor_Discovery);
            if (join > 0)
            {
                As_Write write = new As_Write();                     //将填写信息记录
                write.Employee_ID = Session["Employee_ID"].ToString();
                write.Form_ID = Vendor_Discovery.Form_ID;
                write.Form_Fill_Time = DateTime.Now.ToString();
                write.Manul = manul;
                write.Temp_Vendor_ID = Convert.ToString(ViewState["tempVendorID"]);
                Write_BLL.addWrite(write);
                if (flag == 1)
                {
                    LocalScriptManager.createManagerScript(Page, "window.alert('保存成功！')", "save");
                }
                return Vendor_Discovery;
            }
            else
            {
                Response.Write("<script>window.alert('保存失败！')</script>");
                return null;
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

        public void Button1_Click(object sender, EventArgs e)//提交按钮
        {
            if (Convert.ToString(ViewState["submit"]).Equals("yes"))
            {
                //形成参数
                As_Vendor_Discovery Vendor_Discovery = saveForm(2, "提交表格");
                LocalApproveManager.doApproveWithSelection(Page,Convert.ToString(ViewState["form_ID"]), Convert.ToString(ViewState["formName"]), Convert.ToString(ViewState["formTypeID"]), Convert.ToString(ViewState["tempVendorID"]), Convert.ToString(ViewState["tempVendorName"]), Session["Factory_Name"].ToString());
            }
            else
            {
                LocalApproveManager.showPendingReason(Page, Convert.ToString(ViewState["tempVendorID"]),true);
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
            string filePath = As_Vendor_Designated_Apply_BLL.getFilePath(fileID);
            if (filePath != "")
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>viewFile('" + filePath + "');</script>");
            }
        }
    }
}