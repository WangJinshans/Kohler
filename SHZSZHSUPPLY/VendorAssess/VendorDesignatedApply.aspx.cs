using System;
using Model;
using BLL;
using System.Web.UI.WebControls;
using AendorAssess;
using SHZSZHSUPPLY.VendorAssess.Util;

namespace VendorAssess
{
    public partial class VendorDesignatedApply : System.Web.UI.Page
    {
        public const string FORM_NAME = "指定供应商申请表";
        public const string FORM_TYPE_ID = "004";
        private string tempVendorID = "";
        private string tempVendorName = "";
        private string formID = "";
        private string submit = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            //在非show页面中不可操作
            Image1.Visible = false;
            Image2.Visible = false;
            Image3.Visible = false;
            Image4.Visible = false;
            Image5.Visible = false;
            Image6.Visible = false;
            Image7.Visible = false;
            TextBox13.Visible = false;//时间控件隐藏
            TextBox14.Visible = false;
            TextBox18.Visible = false;
            TextBox17.Visible = false;
            TextBox21.Visible = false;
            TextBox22.Visible = false;
            TextBox24.Visible = false;
            if (!IsPostBack)
            {
                //获取session信息
                getSessionInfo();
                int check = As_Vendor_Designated_Apply_BLL.checkVendorDesignatedApply(formID);
                if (check == 0)//数据库中不存在这张表，则自动初始化
                {
                    As_Vendor_Designated_Apply vendorDesignatedApply = new As_Vendor_Designated_Apply();
                    vendorDesignatedApply.Form_Type_ID = FORM_TYPE_ID;
                    vendorDesignatedApply.VendorName = tempVendorName;
                    vendorDesignatedApply.Temp_Vendor_ID = tempVendorID;
                    vendorDesignatedApply.Flag = 0;//将表格标志位信息改为初始
                    vendorDesignatedApply.Factory_Name = Employee_BLL.getEmployeeFactory(Session["Employee_ID"].ToString());

                    //名字只读
                    TextBox1.Text = tempVendorName;//
                    TextBox1.ReadOnly = true;

                    int n = As_Vendor_Designated_Apply_BLL.addForm(vendorDesignatedApply);
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
                    }
                }
                else
                {
                    showForm();
                }
            }
            else
            {
                //处理postback回调
                string res = Request["__EVENTTARGET"];
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
            if (CheckFile_BLL.bindFormFile(FORM_TYPE_ID, tempVendorID, formID) == 0)
            {
                Response.Write("<script>window.alert('表格初始化错误（文件绑定失败）！')</script>");//若没有记录 返回文件不全
            }
        }

        /// <summary>
        /// 重新读取session
        /// </summary>
        private void getSessionInfo()
        {
            tempVendorID = Session["tempVendorID"].ToString();
            tempVendorName = TempVendor_BLL.getTempVendorName(tempVendorID);
            formID = As_Vendor_Designated_Apply_BLL.getFormID(tempVendorID);
            submit = Request.QueryString["submit"];
        }

        /// <summary>
        /// 显示表格
        /// </summary>
        private void showForm()
        {
            As_Vendor_Designated_Apply Vendor_Designated = As_Vendor_Designated_Apply_BLL.checkFlag(formID);
            if (Vendor_Designated != null)
            {
                TextBox1.Text = Vendor_Designated.VendorName;//
                TextBox1.ReadOnly = true;
                TextBox2.Text = Vendor_Designated.SAPCode1;
                TextBox3.Text = Vendor_Designated.BusinessCategory;
                TextBox4.Text = Vendor_Designated.EffectiveTime.ToString();
                TextBox5.Text = Vendor_Designated.PurchaseAmount;
                TextBox6.Text = Vendor_Designated.Reason;
                TextBox7.Text = Vendor_Designated.Initiator;
                TextBox8.Text = Vendor_Designated.Date.ToString();
                Image8.ImageUrl = Vendor_Designated.Applicant;
                Image1.ImageUrl = Vendor_Designated.RequestDeptHead;
                Image2.ImageUrl = Vendor_Designated.FinManager;
                TextBox12.Text = Vendor_Designated.ApplicantDate.ToString();
                TextBox13.Text = Vendor_Designated.RequestDeptHeadDate.ToString();
                TextBox14.Text = Vendor_Designated.FinManagerDate.ToString();
                Image3.ImageUrl = Vendor_Designated.PurchasingManager;
                Image4.ImageUrl = Vendor_Designated.GM;
                TextBox17.Text = Vendor_Designated.PurchasingManagerDtae.ToString();
                TextBox18.Text = Vendor_Designated.GMDate1.ToString();
                Image5.ImageUrl = Vendor_Designated.Director;
                Image6.ImageUrl = Vendor_Designated.SupplyChainDirector;
                TextBox21.Text = Vendor_Designated.DirectorDtae.ToString();
                TextBox22.Text = Vendor_Designated.SupplyChainDirectorDate.ToString();
                Image7.ImageUrl = Vendor_Designated.Persident;
                TextBox24.Text = Vendor_Designated.FinalDate.ToString();
            }
            //展示附件
            showfilelist(formID);
        }

        ///// <summary>
        ///// 显示审批列表
        ///// </summary>
        ///// <param name="FormID"></param>
        //public void showApproveForm(string FormID)
        //{
        //    As_Approve approve = new As_Approve();
        //    string sql = "SELECT * FROM As_Approve WHERE Form_ID='" + FormID + "'";
        //    PagedDataSource objpds = new PagedDataSource();
        //    objpds.DataSource = AssessFlow_BLL.listApprove(sql,positionName);
        //    //GridView1.DataSource = objpds;
        //    //GridView1.DataBind();
        //}

        /// <summary>
        /// 显示文件列表
        /// </summary>
        /// <param name="FormID"></param>
        public void showfilelist(string FormID)
        {
            As_Form_File Form_File = new As_Form_File();
            string sql = "select * from As_Form_File where Form_ID='" + FormID + "'";
            PagedDataSource objpds = new PagedDataSource();
            objpds.DataSource = FormFile_BLL.listFile(sql);
            GridView2.DataSource = objpds;
            GridView2.DataBind();
        }

        /// <summary>
        /// 提交表格
        /// </summary>
        /// <returns></returns>
        protected string submitForm()
        {
            //读取session
            getSessionInfo();

            SelectDepartment.doSelect();

            //一旦提交就把表As_Vendor_FormType字段FLag置1.
            int updateFlag = UpdateFlag_BLL.updateFlag(FORM_TYPE_ID, tempVendorID);

            //插入到已提交表
            As_Form form = new As_Form();
            form.Form_ID = formID;
            form.Form_Type_Name = "指定供应商申请表";
            form.Form_Type_ID = FORM_TYPE_ID;
            form.Temp_Vendor_Name = tempVendorName;
            form.Form_Path = "";
            form.Temp_Vendor_ID = tempVendorID;
            int add = AddForm_BLL.addForm(form);

            Response.Redirect("EmployeeVendor.aspx");
            return "";
        }

        /// <summary>
        /// 网页内部弹出，确定用户部门流程
        /// </summary>
        /// <param name="formTypeID"></param>
        /// <param name="formID"></param>
        public void newApproveAccess(string formTypeID, string formID)
        {
            //形成参数
            As_Assess_Flow assess_flow = AssessFlow_BLL.getFirstAssessFlow(formTypeID);

            //写入session之后供SelectDepartment页面使用
            Session["AssessflowInfo"] = assess_flow;
            Session["tempVendorID"] = tempVendorID;
            Session["factory"] = "上海科勒";//TODO:自动三厂选择
            Session["form_name"] = FORM_NAME;
            Session["tempVendorName"] = tempVendorName;

            //如果是用户部门
            if (assess_flow.User_Department_Assess == "1")
            {
                LocalScriptManager.CreateScript(Page, "popUp('" + formID + "');", "SHOW");
            }
            else
            {
                Session["tempvendorname"] = tempVendorName;
                Session["Employee_ID"] = Session["Employee_ID"];
                Response.Write("<script>window.alert('提交成功！');window.location.href='EmployeeVendor.aspx'</script>");
            }
        }


        /// <summary>
        /// 保存表格
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="manul"></param>
        /// <returns></returns>
        private As_Vendor_Designated_Apply saveForm(int flag, string manul)
        {
            //读取session
            getSessionInfo();

            As_Vendor_Designated_Apply Vendor_Designated = new As_Vendor_Designated_Apply();
            Vendor_Designated.Form_id = formID;
            Vendor_Designated.Form_Type_ID = FORM_TYPE_ID;
            Vendor_Designated.Temp_Vendor_ID = tempVendorID;
            Vendor_Designated.VendorName = tempVendorName;//临时供应商名称
            Vendor_Designated.SAPCode1 = TextBox2.Text.ToString().Trim();
            Vendor_Designated.BusinessCategory = TextBox3.Text.ToString().Trim();
            Vendor_Designated.EffectiveTime = TextBox4.Text.ToString().Trim();//将字符转化为datetime类型
            Vendor_Designated.PurchaseAmount = TextBox5.Text.ToString().Trim();
            Vendor_Designated.Reason = TextBox6.Text.ToString().Trim();
            Vendor_Designated.Initiator = TextBox7.Text.ToString().Trim();
            Vendor_Designated.InitiatorDate = TextBox8.Text.ToString().Trim();
            Vendor_Designated.Applicant = Image8.ImageUrl;
            //Vendor_Designated.Applicant = TextBox9.Text.ToString().Trim();
            //Vendor_Designated.RequestDeptHead = TextBox10.Text.ToString().Trim();
            //Vendor_Designated.FinManager = TextBox11.Text.ToString().Trim();
            //Vendor_Designated.ApplicantDate = TextBox12.Text.ToString().Trim();
            //Vendor_Designated.RequestDeptHeadDate = TextBox13.Text.ToString().Trim();
            //Vendor_Designated.FinManagerDate = TextBox14.Text.ToString().Trim();
            //Vendor_Designated.PurchasingManager = TextBox15.Text.ToString().Trim();
            //Vendor_Designated.GM = TextBox16.Text.ToString().Trim();
            //Vendor_Designated.PurchasingManagerDtae = TextBox17.Text.ToString().Trim();
            //Vendor_Designated.GMDate1 = TextBox18.Text.ToString().Trim();
            //Vendor_Designated.Director = TextBox19.Text.ToString().Trim();
            //Vendor_Designated.SupplyChainDirector = TextBox20.Text.ToString().Trim();
            //Vendor_Designated.DirectorDtae = TextBox21.Text.ToString().Trim();
            //Vendor_Designated.SupplyChainDirectorDate = TextBox22.Text.ToString().Trim();
            //Vendor_Designated.Persident = TextBox23.Text.ToString().Trim();
            //Vendor_Designated.FinalDate = TextBox24.Text.ToString().Trim();
            Vendor_Designated.Flag = flag;
            
            int join = As_Vendor_Designated_Apply_BLL.updateForm(Vendor_Designated);
            if (join > 0)
            {
                As_Write write = new As_Write();                     //将填写信息记录
                write.Employee_ID = Session["Employee_ID"].ToString();
                write.Form_ID = Vendor_Designated.Form_id;
                write.Form_Fill_Time = DateTime.Now.ToString();
                write.Manul = manul;
                write.Temp_Vendor_ID = tempVendorID;
                Write_BLL.addWrite(write);
                if (flag == 1)
                {
                    Response.Write("<script>window.alert('保存成功！')</script>");
                }
                return Vendor_Designated;
            }
            else
            {
                return null;
            }
        }


        public void Button1_Click(object sender, EventArgs e)//提交按钮
        {
            getSessionInfo();
            if (submit == "yes")
            {
                //形成参数
                As_Vendor_Designated_Apply Vendor_Designated = saveForm(2, "提交表格");

                //对于用户部门，使用弹出对话框选择
                LocalApproveManager.doApproveWithSelection(Page, formID, FORM_NAME, FORM_TYPE_ID, tempVendorID, tempVendorName, Employee_BLL.getEmployeeFactory(Session["Employee_ID"].ToString()));
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

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "file")
            {
                Response.Write("<script>alert('文件!');window.open('../files/7.pdf');</script>");
            }
        }
    }
}