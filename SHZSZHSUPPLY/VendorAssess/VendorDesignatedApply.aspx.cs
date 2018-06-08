using System;
using Model;
using BLL;
using System.Web.UI.WebControls;
using AendorAssess;
using SHZSZHSUPPLY.VendorAssess.Util;
using System.Web.UI;
using BLL.VendorAssess;
using MODEL.VendorAssess;

namespace VendorAssess
{
    public partial class VendorDesignatedApply : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //在非show页面中不可操作
            Image2.Visible = false;
            Image3.Visible = false;
            Image4.Visible = false;
            Image5.Visible = false;
            Image6.Visible = false;
            Image7.Visible = false;



            LocalScriptManager.CreateScript(Page, "initTextarea()", "initTextbox");

            if (!IsPostBack)
            {
                //获取session信息
                getSessionInfo();
                int check = As_Vendor_Designated_Apply_BLL.checkVendorDesignatedApply(Convert.ToString(ViewState["form_ID"]));
                if (check == 0)//数据库中不存在这张表，则自动初始化
                {
                    As_Vendor_Designated_Apply vendorDesignatedApply = new As_Vendor_Designated_Apply();
                    vendorDesignatedApply.Form_Type_ID = Convert.ToString(ViewState["formTypeID"]);
                    vendorDesignatedApply.VendorName = Convert.ToString(ViewState["tempVendorName"]);
                    vendorDesignatedApply.Temp_Vendor_ID = Convert.ToString(ViewState["tempVendorID"]); 
                    vendorDesignatedApply.Flag = 0;//将表格标志位信息改为初始
                    vendorDesignatedApply.Factory_Name = Session["Factory_Name"].ToString();

                    //名字只读
                    TextBox1.Text = Convert.ToString(ViewState["tempVendorName"]);
                    TextBox1.ReadOnly = true;

                    int n = As_Vendor_Designated_Apply_BLL.addForm(vendorDesignatedApply);
                    if (n == 0)
                    {
                        Response.Write("<script>window.alert('表格初始化错误（新建插入失败）！')</script>");
                        return;
                    }
                    else
                    {
                        string formID = As_Vendor_Designated_Apply_BLL.getVendorDesignatedFormID(Convert.ToString(ViewState["tempVendorID"]), Convert.ToString(ViewState["formTypeID"]), Session["Factory_Name"].ToString(), n);
                        ViewState.Add("form_ID", formID);
                        //添加单独绑定的文件
                        VendorSingleFile_BLL.addSingleFile(formID, Convert.ToString(ViewState["formTypeID"]), Convert.ToString(ViewState["tempVendorID"]), Convert.ToString(ViewState["tempVendorName"]), Session["Factory_Name"].ToString(), "065");

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
                switch (Request["__EVENTTARGET"])
                {
                    case "submitForm":
                        LocalApproveManager.submitForm();
                        break;
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
        /// 显示表格
        /// </summary>
        private void showForm()
        {
            As_Vendor_Designated_Apply Vendor_Designated = As_Vendor_Designated_Apply_BLL.checkFlag(Convert.ToString(ViewState["form_ID"]));
            if (Vendor_Designated != null)
            {
                TextBox1.Text = Vendor_Designated.VendorName;
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

                //补
                TextBox9.Text = Vendor_Designated.VendorName1;
                TextBox10.Text = Vendor_Designated.SAPCode_1;
                TextBox11.Text = Vendor_Designated.BusinessCategory1;
                TextBox15.Text = Vendor_Designated.EffectiveTime1.ToString();
                TextBox16.Text = Vendor_Designated.PurchaseAmount1;
                TextBox19.Text = Vendor_Designated.Reason1;

                TextBox20.Text = Vendor_Designated.VendorName2;
                TextBox23.Text = Vendor_Designated.SAPCode_2;
                TextBox25.Text = Vendor_Designated.BusinessCategory2;
                TextBox26.Text = Vendor_Designated.EffectiveTime2.ToString();
                TextBox27.Text = Vendor_Designated.PurchaseAmount2;
                TextBox28.Text = Vendor_Designated.Reason2;

                TextBox29.Text = Vendor_Designated.VendorName3;
                TextBox30.Text = Vendor_Designated.SAPCode_3;
                TextBox31.Text = Vendor_Designated.BusinessCategory3;
                TextBox32.Text = Vendor_Designated.EffectiveTime3.ToString();
                TextBox33.Text = Vendor_Designated.PurchaseAmount3;
                TextBox34.Text = Vendor_Designated.Reason3;

                TextBox35.Text = Vendor_Designated.VendorName4;
                TextBox36.Text = Vendor_Designated.SAPCode_4;
                TextBox37.Text = Vendor_Designated.BusinessCategory4;
                TextBox38.Text = Vendor_Designated.EffectiveTime4.ToString();
                TextBox39.Text = Vendor_Designated.PurchaseAmount4;
                TextBox40.Text = Vendor_Designated.Reason4;
            }
            //展示附件
            showfilelist(Convert.ToString(ViewState["form_ID"]));
        }

        /// <summary>
        /// 显示文件列表
        /// </summary>
        /// <param name="FormID"></param>
        public void showfilelist(string FormID)
        {
            return;
            //As_Form_File Form_File = new As_Form_File();
            //string sql = "select * from As_Form_File where Form_ID='" + FormID + "'  and Form_ID in (select Form_ID from As_Vendor_FormType where Temp_Vendor_ID='" + tempVendorID + "')";
            //PagedDataSource objpds = new PagedDataSource();
            //objpds.DataSource = FormFile_BLL.listFile(sql);
            //GridView2.DataSource = objpds;
            //GridView2.DataBind();
        }

        /// <summary>
        /// 提交表格
        /// </summary>
        /// <returns></returns>
        protected string submitForm()
        {
            SelectDepartment.doSelect();

            //一旦提交就把表As_Vendor_FormType字段FLag置1.
            int updateFlag = UpdateFlag_BLL.updateFlag(Convert.ToString(ViewState["formTypeID"]), Convert.ToString(ViewState["tempVendorID"]));

            //插入到已提交表
            As_Form form = new As_Form();
            form.Form_ID = Convert.ToString(ViewState["form_ID"]);
            form.Form_Type_Name = "指定供应商申请表";
            form.Form_Type_ID = Convert.ToString(ViewState["formTypeID"]);
            form.Temp_Vendor_Name = Convert.ToString(ViewState["tempVendorName"]);
            form.Form_Path = "";
            form.Temp_Vendor_ID = Convert.ToString(ViewState["tempVendorID"]) ;
            form.Factory_Name = Session["Factory_Name"].ToString();
            int add = AddForm_BLL.addForm(form);

            Response.Redirect("EmployeeVendor.aspx");
            return "";
        }

        /// <summary>
        /// 保存表格
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="manul"></param>
        /// <returns></returns>
        private As_Vendor_Designated_Apply saveForm(int flag, string manul)
        {
            As_Vendor_Designated_Apply Vendor_Designated = new As_Vendor_Designated_Apply();
            Vendor_Designated.Form_id = Convert.ToString(ViewState["form_ID"]);
            Vendor_Designated.Form_Type_ID = Convert.ToString(ViewState["formTypeID"]);
            Vendor_Designated.Temp_Vendor_ID = Convert.ToString(ViewState["tempVendorID"]);
            Vendor_Designated.VendorName = Convert.ToString(ViewState["tempVendorName"]);
            Vendor_Designated.SAPCode1 = TextBox2.Text.ToString().Trim();
            Vendor_Designated.BusinessCategory = TextBox3.Text.ToString().Trim();
            Vendor_Designated.EffectiveTime = TextBox4.Text.ToString().Trim();
            Vendor_Designated.PurchaseAmount = TextBox5.Text.ToString().Trim();
            Vendor_Designated.Reason = TextBox6.Text.ToString().Trim();
            Vendor_Designated.Initiator = TextBox7.Text.ToString().Trim();
            Vendor_Designated.InitiatorDate = TextBox8.Text.ToString().Trim();
            Vendor_Designated.Applicant = Image8.ImageUrl;
            Vendor_Designated.RequestDeptHead = Image1.ImageUrl;
            Vendor_Designated.ApplicantDate = TextBox12.Text.ToString().Trim();
            Vendor_Designated.RequestDeptHeadDate = TextBox13.Text.ToString().Trim();
            Vendor_Designated.Flag = flag;

            Vendor_Designated.VendorName1 = TextBox9.Text;
            Vendor_Designated.SAPCode_1 = TextBox10.Text;
            Vendor_Designated.BusinessCategory1 = TextBox11.Text;
            Vendor_Designated.EffectiveTime1 = TextBox15.Text;
            Vendor_Designated.PurchaseAmount1 = TextBox16.Text;
            Vendor_Designated.Reason1 = TextBox19.Text;
            
            Vendor_Designated.VendorName2 = TextBox20.Text;
            Vendor_Designated.SAPCode_2 = TextBox23.Text;
            Vendor_Designated.BusinessCategory2 = TextBox25.Text;
            Vendor_Designated.EffectiveTime2 = TextBox26.Text;
            Vendor_Designated.PurchaseAmount2 = TextBox27.Text;
            Vendor_Designated.Reason2 = TextBox28.Text;
            
            Vendor_Designated.VendorName3 = TextBox29.Text;
            Vendor_Designated.SAPCode_3 = TextBox30.Text;
            Vendor_Designated.BusinessCategory3 = TextBox31.Text;
            Vendor_Designated.EffectiveTime3 = TextBox32.Text;
            Vendor_Designated.PurchaseAmount3 = TextBox33.Text;
            Vendor_Designated.Reason3 = TextBox34.Text;
            
            Vendor_Designated.VendorName4 = TextBox35.Text;
            Vendor_Designated.SAPCode_4 = TextBox36.Text;
            Vendor_Designated.BusinessCategory4 = TextBox37.Text;
            Vendor_Designated.EffectiveTime4 = TextBox38.Text;
            Vendor_Designated.PurchaseAmount4 = TextBox39.Text;
            Vendor_Designated.Reason4 = TextBox40.Text;

            int join = As_Vendor_Designated_Apply_BLL.updateForm(Vendor_Designated);
            if (join > 0)
            {
                As_Write write = new As_Write();                     //将填写信息记录
                write.Employee_ID = Session["Employee_ID"].ToString();
                write.Form_ID = Vendor_Designated.Form_id;
                write.Form_Fill_Time = DateTime.Now.ToString();
                write.Manul = manul;
                write.Temp_Vendor_ID = Convert.ToString(ViewState["tempVendorID"]);
                Write_BLL.addWrite(write);
                if (flag == 1)
                {
                    LocalScriptManager.createManagerScript(Page, "window.alert('保存成功！')", "save");
                    //Response.Write("<script>window.alert('保存成功！')</script>");
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
            bool singleFileSubmit = VendorSingleFile_BLL.isSingleFileSubmit(Convert.ToString(ViewState["form_ID"]));
            if (!singleFileSubmit)
            {
                LocalScriptManager.createManagerScript(Page, "window.alert('请提交指定供应商填写授权文件')", "uploadsinglefile");
                return;
            }
            if (Convert.ToString(ViewState["submit"]).Equals("yes"))
            {
                //形成参数
                As_Vendor_Designated_Apply Vendor_Designated = saveForm(2, "提交表格");

                //对于用户部门，使用弹出对话框选择
                LocalApproveManager.doApproveWithSelection(Page, Convert.ToString(ViewState["form_ID"]), Convert.ToString(ViewState["formName"]), Convert.ToString(ViewState["formTypeID"]), Convert.ToString(ViewState["tempVendorID"]), Convert.ToString(ViewState["tempVendorName"]), Session["Factory_Name"].ToString());
            }
            else
            {
                LocalApproveManager.showPendingReason(Page, Convert.ToString(ViewState["tempVendorID"]), true);
                //Response.Write("<script>window.alert('无法提交！')</script>");
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

        protected void btnNewImage_Click(object sender, EventArgs e)
        {
            string[] temp = ImgExSrc.Value.ToString().Split(',');
            Control control = FindControl(temp[0]);
            if (control != null)
            {
                ((Image)control).ImageUrl = temp[1];
            }
            if (temp[0].Equals("Image8"))   //find Head
            {
                Image1.ImageUrl = String.Format(Signature_BLL.urlPath, Employee_BLL.findHead(temp[1].Substring(temp[1].LastIndexOf('/')+1).Replace(".png", "")));
                tableUpdatePanel.Update();
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //指定授权不需要有效期
            string requestType = "signleupload";
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "signleupload", String.Format("uploadFile('{0}','{1}','{2}','{3}',{4})", requestType, Convert.ToString(ViewState["tempVendorID"]), Convert.ToString(ViewState["tempVendorName"]), Convert.ToString(ViewState["form_ID"]), ""), true);
        }
    }
}