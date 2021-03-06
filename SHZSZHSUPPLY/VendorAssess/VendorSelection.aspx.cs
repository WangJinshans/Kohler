using AendorAssess;
using BLL;
using BLL.VendorAssess;
using DAL.VendorAssess;
using Model;
using MODEL.VendorAssess;
using SHZSZHSUPPLY.VendorAssess.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SHZSZHSUPPLY.VendorAssess
{
    public partial class VendorSelection : Util.BasePage
    {
        public Dictionary<string, List<string>> suppliers;// = new Dictionary<string, List<string>>();
        public List<string> list;
        private As_Form_EditFlow formEditFlow;
        private List<As_Employee_Form> employeeFormList;


        public const byte APPROVED = 0;
        public const byte C_APPROVAL = 1;
        public const byte REJECT = 2;

        protected void Page_Load(object sender, EventArgs e)
        {


            LocalScriptManager.CreateScript(Page, "initTextarea()", "initTextbox");

            if (!IsPostBack)
            {
                //获取session信息
                getSessionInfo();

                int check = VendorSelection_BLL.checkVendorSelection(Convert.ToString(ViewState["form_ID"]));
                if (check == 0)//数据库中不存在这张表，则自动初始化
                {
                    As_Vendor_Selection Vendor_Selection = new As_Vendor_Selection();
                    Vendor_Selection.Form_Type_ID = Convert.ToString(ViewState["formTypeID"]);
                    Vendor_Selection.Temp_Vendor_Name = Convert.ToString(ViewState["tempVendorName"]);
                    Vendor_Selection.Temp_Vendor_ID = Convert.ToString(ViewState["tempVendorID"]);
                    Vendor_Selection.Flag = 0;//将表格标志位信息改为已填写
                    Vendor_Selection.Factory_Name = Session["Factory_Name"].ToString();

                    int n = VendorSelection_BLL.addVendorSelection(Vendor_Selection);
                    if (n == 0)
                    {
                        Response.Write("<script>window.alert('表格初始化错误（新建插入失败）！')</script>");
                        return;
                    }
                    else
                    {
                        string formID = VendorSelection_BLL.getVendorSelectionFormID(Convert.ToString(ViewState["tempVendorID"]), Convert.ToString(ViewState["formTypeID"]), Session["Factory_Name"].ToString(), n);

                        ViewState.Add("form_ID", formID);
                        
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
                }
                else
                {
                    showVendorSelection();
                }
                displayButton();
            }
            else
            {
                //处理postback回调
                switch (Request["__EVENTTARGET"])
                {
                    case "showVendorSelection":
                        showVendorSelection();
                        break;
                    case "submitForm":
                        LocalApproveManager.submitForm();
                        //submitForm();
                        break;
                    case "r_d_yes":
                        r_d_Yes();
                        break;
                    case "r_d_no":
                        r_d_No();
                        break;
                    case "fileUploadResult":
                        fileUploadResult();
                        break;
                    case "selectResult":
                        selectResult();
                        break;
                    default:
                        break;
                }
            }
        }

        public string getSupplier(string sequence)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(suppliers[sequence]);
        }

        private void displayButton()
        {
            if (CheckFlag_BLL.multiFillFinished(Convert.ToString(ViewState["form_ID"]), Convert.ToString(ViewState["tempVendorID"]), Convert.ToString(ViewState["formTypeID"]), Session["Factory_Name"].ToString().Trim()))
            {
                Button1.Visible = true;
                Button4.Visible = false;
            }
            else
            {
                Button1.Visible = false;
                Button4.Visible = true;
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

        /// <summary>
        /// 显示表格
        /// </summary>
        private void showVendorSelection()
        {
            string[] strArray = { "one", "two", "three", "four", "five" };

            //初始化表格数据源
            As_Vendor_Selection vendorSelection = VendorSelection_BLL.checkFlag(Convert.ToString(ViewState["form_ID"]));

            //初始化supplier数据源
            suppliers = VendorSelectionSupplier_BLL.checkSupplier(Convert.ToString(ViewState["form_ID"]));

            //更新页面数据
            if (vendorSelection!= null)
            {
                txbRef.Text = vendorSelection.Ref_No;
                txbDate.Text = vendorSelection.Date;
                txbOne.Text = vendorSelection.Supplier_One_ID;
                txbTwo.Text = vendorSelection.Supplier_Two_ID;
                txbThree.Text = vendorSelection.Supplier_Three_ID;
                txbFour.Text = vendorSelection.Supplier_Four_ID;
                txbFive.Text = vendorSelection.Supplier_Five_ID;
                txbRecommend.Text = vendorSelection.Recommend;
            }

            //更新supplier数据
            if (suppliers != null)
            {
                for (int i = 0; i < suppliers.Count; i++)
                {
                    int t = i * 12 + 1;
                    List<string> supplier = suppliers[strArray[i]];
                    setSelected(Convert.ToByte(supplier[supplier.Count - 4]), new[] { (RadioButton)Controls[3].FindControl("RadioButton" + t), (RadioButton)Controls[3].FindControl("RadioButton" + (t + 1)), (RadioButton)Controls[3].FindControl("RadioButton" + (t + 2)) });
                    setSelected(Convert.ToByte(supplier[supplier.Count - 3]), new[] { (RadioButton)Controls[3].FindControl("RadioButton" + (t + 3)), (RadioButton)Controls[3].FindControl("RadioButton" + (t + 4)), (RadioButton)Controls[3].FindControl("RadioButton" + (t + 5)) });
                    setSelected(Convert.ToByte(supplier[supplier.Count - 2]), new[] { (RadioButton)Controls[3].FindControl("RadioButton" + (t + 6)), (RadioButton)Controls[3].FindControl("RadioButton" + (t + 7)), (RadioButton)Controls[3].FindControl("RadioButton" + (t + 8)) });
                    setSelected(Convert.ToByte(supplier[supplier.Count - 1]), new[] { (RadioButton)Controls[3].FindControl("RadioButton" + (t + 9)), (RadioButton)Controls[3].FindControl("RadioButton" + (t + 10)), (RadioButton)Controls[3].FindControl("RadioButton" + (t + 11)) });
                    LocalScriptManager.CreateScript(Page, "showSupplier("+i+"," + getSupplier(strArray[i]) + ");", "showSuppliers"+i);
                }
            }

            //重新计算Total
            LocalScriptManager.CreateScript(Page, "setTotal();", "reCalTotal");
        }

        private As_Vendor_Selection saveForm(int flag, string manul)
        {
            //As_Vendor_Selection
            As_Vendor_Selection vendorSelection = new As_Vendor_Selection();
            vendorSelection.Form_ID = Convert.ToString(ViewState["form_ID"]);
            vendorSelection.Ref_No = txbRef.Text.Trim();
            vendorSelection.Date = txbDate.Text.Trim();
            vendorSelection.Flag = flag;
            vendorSelection.Form_Type_ID = Convert.ToString(ViewState["formTypeID"]);
            vendorSelection.Temp_Vendor_ID = Convert.ToString(ViewState["tempVendorID"]);
            vendorSelection.Temp_Vendor_Name = Convert.ToString(ViewState["tempVendorName"]);
            vendorSelection.Supplier_One_ID = txbOne.Text.Trim();
            vendorSelection.Supplier_Two_ID = txbTwo.Text.Trim();
            vendorSelection.Supplier_Three_ID = txbThree.Text.Trim();
            vendorSelection.Supplier_Four_ID = txbFour.Text.Trim();
            vendorSelection.Supplier_Five_ID = txbFive.Text.Trim();
            vendorSelection.Recommend = txbRecommend.Text.Trim();

            //As_Vendor_Selection_Supplier
            int[] indexArray = new int[] { 1, 37, 48, 90, 94, 136, 140, 182, 186, 228 };
            List<As_Vendor_Selection_Supplier> list = new List<As_Vendor_Selection_Supplier>();
            for (int i = 0; i < 5; i++)
            {
                int pos = 1;
                As_Vendor_Selection_Supplier supplier = new As_Vendor_Selection_Supplier();
                PropertyInfo[] properties = supplier.GetType().GetProperties();
                for (int k = indexArray[2 * i]; k <= indexArray[2 * i + 1]; k++)
                {
                    TextBox txb = ((TextBox)Controls[3].FindControl("TextBox" + k));
                    if (!txb.ReadOnly)
                    {
                        try
                        {
                            properties[pos].SetValue(supplier, Convert.ToDouble(Request.Form[txb.ID]), null);
                        }
                        catch (Exception)
                        {
                            properties[pos].SetValue(supplier, 0, null);
                        }
                        pos++;
                    }
                }
                int t = i * 12 + 1;
                supplier.Assurance_Of_Supplier_Comments = getSelected(new[] { (RadioButton)Controls[3].FindControl("RadioButton" + t), (RadioButton)Controls[3].FindControl("RadioButton" + (t+1)) , (RadioButton)Controls[3].FindControl("RadioButton" + (t + 2))});
                supplier.Quality_Comments = getSelected(new[] { (RadioButton)Controls[3].FindControl("RadioButton" + (t + 3)), (RadioButton)Controls[3].FindControl("RadioButton" + (t + 4)), (RadioButton)Controls[3].FindControl("RadioButton" + (t + 5)) });
                supplier.R_D_Comments = getSelected(new[] { (RadioButton)Controls[3].FindControl("RadioButton" + (t + 6)), (RadioButton)Controls[3].FindControl("RadioButton" + (t + 7)), (RadioButton)Controls[3].FindControl("RadioButton" + (t + 8)) });
                supplier.Price_Comments = getSelected(new[] { (RadioButton)Controls[3].FindControl("RadioButton" + (t + 9)), (RadioButton)Controls[3].FindControl("RadioButton" + (t + 10)), (RadioButton)Controls[3].FindControl("RadioButton" + (t + 11)) });
                supplier.Form_ID = Convert.ToString(ViewState["form_ID"]);
                supplier.Supplier_Pos = i.ToString();
                list.Add(supplier);
            }

            int result_1 = VendorSelection_BLL.updateVendorSelection(vendorSelection);
            int result_2 = VendorSelectionSupplier_BLL.updateVendorSupplier(list);
            if (result_1 > 0 && result_2>0)
            {
                As_Write write = new As_Write();                     //将填写信息记录
                write.Employee_ID = Session["Employee_ID"].ToString();
                write.Form_ID = vendorSelection.Form_ID;
                write.Form_Fill_Time = DateTime.Now.ToString();
                write.Manul = manul;
                write.Temp_Vendor_ID = Convert.ToString(ViewState["tempVendorID"]);
                Write_BLL.addWrite(write);
                if (flag == 1)
                {
                    //Response.Write("<script>window.alert('保存成功！')</script>");
                }
                return vendorSelection;
            }
            else
            {
                return null;
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(ViewState["submit"]).Equals("yes"))
            {
                //形成参数
                As_Vendor_Selection Vendor_Selection = saveForm(2, "提交表格");

                //对于用户部门，使用弹出对话框选择
                LocalApproveManager.doApproveWithSelection(Page, Convert.ToString(ViewState["form_ID"]), Convert.ToString(ViewState["formName"]), Convert.ToString(ViewState["formTypeID"]), Convert.ToString(ViewState["tempVendorID"]), Convert.ToString(ViewState["tempVendorName"]), Session["Factory_Name"].ToString());
            }
            else
            {
                LocalApproveManager.showPendingReason(Page, Convert.ToString(ViewState["tempVendorID"]), true);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (saveForm(1, "保存表格") != null)
            {
                LocalScriptManager.createManagerScript(Page, "closeWaiting();layerMsg('保存成功！')", "save");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeVendor.aspx");
        }


        /// <summary>
        /// 确认按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button4_Click(object sender, EventArgs e)
        {
            saveForm(1, "保存表格");

            //info
            string currentDepartment = Employee_BLL.getEmployeeDepartment(Session["Employee_ID"].ToString(), Session["Position_Name"].ToString());
            As_Edit_Flow edtFlow = EditFlow_BLL.getEditFlow(Convert.ToString(ViewState["formTypeID"]));
            List<string> departments = new List<string>() { edtFlow.Edit_One_Department, edtFlow.Edit_Two_Department, edtFlow.Edit_Three_Department };

            //check, if multiForm record not exist
            if (EditFlow_BLL.checkFormEditFlow(Convert.ToString(ViewState["form_ID"])) <= 0)
            {
                departments.RemoveAll(delegate (string item)
                {
                    if (item == "" || item == currentDepartment)
                    {
                        return true;
                    }
                    return false;
                });

                List<string> totalIDList = new List<string>();
                List<string> totalNameList = new List<string>();

                for (int i = 0; i < departments.Count; i++)
                {
                    if (departments[i] == "" || departments.Equals(currentDepartment))
                    {
                        continue;
                    }
                    List<string> idList = Employee_BLL.viewGetEmployeeID(departments[i]);  //返回list1为id，2为name
                    List<string> nameList = Employee_BLL.viewGetEmployeeName(departments[i]);

                    totalIDList.AddRange(idList);
                    totalNameList.AddRange(nameList);
                }

                JavaScriptSerializer jss = new JavaScriptSerializer();
                LocalScriptManager.createManagerScript(Page, "selectEmployeeID(" + jss.Serialize(departments)+","+jss.Serialize(totalIDList)+","+jss.Serialize(totalNameList)+")", "selectID");
                //执行到此处并无日志和邮件写出
            }
            else
            {
                //如果是采购 或 供应链部
                if (VendorSelection_BLL.checkDepartment(Session["Employee_ID"].ToString(), edtFlow))
                {
                    //saveForm(1, "保存表格");//注意032为fileTypeID
                    bool has_R_D_File = VendorSelection_BLL.checkRDFile(Convert.ToString(ViewState["form_ID"]), "032");
                    LocalScriptManager.createManagerScript(Page, "R_D_Confirm("+has_R_D_File.ToString().ToLower()+",'"+ Convert.ToString(ViewState["tempVendorID"]) + "','"+ Convert.ToString(ViewState["tempVendorName"]) + "')", "rdcfm");
                }
                else
                {
                    departments.RemoveAll(delegate (string item)
                    {
                        if (item == "")
                        {
                            return true;
                        }
                        return false;
                    });
                    //saveForm(1, "保存表格");
                    EmployeeForm_BLL.changeFillFlag(Session["Employee_ID"].ToString(), Convert.ToString(ViewState["form_ID"]), 1);
                    UpdateFlag_BLL.updateFlagAsHold(Convert.ToString(ViewState["formTypeID"]), Convert.ToString(ViewState["tempVendorID"]));

                    //如果是最后一个填写人，更改表格状态为填写完成状态
                    if (currentDepartment.Equals(departments[departments.Count - 1]))
                    {
                        UpdateFlag_BLL.updateEditFlowFlag(Convert.ToString(ViewState["form_ID"]), Convert.ToString(ViewState["tempVendorID"]));
                        UpdateFlag_BLL.updateFlagAsFinish(Convert.ToString(ViewState["formTypeID"]), Convert.ToString(ViewState["tempVendorID"]));

                        //写出日志
                        As_Employee ae = Employee_BLL.getEmolyeeById(AddEmployeeVendor_BLL.getEmployeeID(Convert.ToString(ViewState["tempVendorID"]), HttpContext.Current.Session["Factory_Name"].ToString()), HttpContext.Current.Session["Factory_Name"].ToString());
                        LocalLog.writeLog(Convert.ToString(ViewState["form_ID"]), String.Format("{0}已填写，多人填写完毕",currentDepartment), As_Write.FORM_MULTI_EDIT, Convert.ToString(ViewState["tempVendorID"]));

                        //Mail
                        LocalMail.backToast(ae.Employee_Email, ae.Employee_Name, ae.Factory_Name, Convert.ToString(ViewState["tempVendorID"]), TempVendor_BLL.getTempVendorName(Convert.ToString(ViewState["tempVendorID"])), Convert.ToString(ViewState["formName"]), "填写完毕", DateTime.Now.ToString(), "此表格已填写完毕，请登陆系统后提交审批", Convert.ToString(ViewState["form_ID"]));
                    }
                    else
                    {
                        As_Approve ap = MultiEdit_BLL.getMultiEditTop(Convert.ToString(ViewState["form_ID"]));

                        //写出日志
                        LocalLog.writeLog(Convert.ToString(ViewState["form_ID"]), String.Format("{0}已填写，等待 {1} 填写",currentDepartment, ap.Employee_Name), As_Write.FORM_MULTI_EDIT, Convert.ToString(ViewState["tempVendorID"]));

                        //Mail
                        LocalMail.flowToast(ap.Email, ap.Employee_Name, ap.Factory_Name, Convert.ToString(ViewState["tempVendorID"]), ap.Temp_Vendor_Name, Convert.ToString(ViewState["formName"]), "等待填写", DateTime.Now.ToString(), "此表格已由其他部门填写完毕，正在等待当前部门填写，请登陆系统填写表格并确认", Convert.ToString(ViewState["form_ID"]));
                    }

                    LocalScriptManager.createManagerScript(Page, "layerMsgFunc('已确认',function(){window.location.href='FormWaitToFill.aspx';})", "otherCFM");
                }
            }
            //如果是，保存表格，禁止此人再次编辑，fill——flag此人均置为1
        }

        /// <summary>
        /// 选择填写部门之后
        /// </summary>
        private void selectResult()
        {
            string employee_ID = Session["Employee_ID"].ToString();
            string currentDepartment = Employee_BLL.getEmployeeDepartment(employee_ID, Session["Position_Name"].ToString());

            //根据选择的list，初始化formeditflow，employeeformlist
            JavaScriptSerializer jss = new JavaScriptSerializer();
            As_Edit_Flow editFlow = EditFlow_BLL.getEditFlow(Convert.ToString(ViewState["formTypeID"]));

            formEditFlow = new As_Form_EditFlow();
            Dictionary<string,string> dc = jss.Deserialize<Dictionary<string, string>>(Request.Form["__EVENTARGUMENT"]);

            formEditFlow.One = "";
            formEditFlow.Two ="";
            formEditFlow.Three = "";

            try
            {
                if (currentDepartment.Equals(editFlow.Edit_One_Department))
                {
                    formEditFlow.One = employee_ID;
                }
                else
                {
                    formEditFlow.One = dc[editFlow.Edit_One_Department];
                }
            }
            catch (Exception)
            {
            }
            try
            {
                formEditFlow.Two = dc[editFlow.Edit_Two_Department];
            }
            catch (Exception)
            {
            }
            try
            {
                formEditFlow.Three = dc[editFlow.Edit_Three_Department];
            }
            catch (Exception)
            {
            }

            formEditFlow.Form_ID = Convert.ToString(ViewState["form_ID"]);
            formEditFlow.Multi_Edit = editFlow.Multi_Edit;
            formEditFlow.Temp_Vendor_ID = Convert.ToString(ViewState["tempVendorID"]);
            formEditFlow.Factory_Name = Session["Factory_Name"].ToString(); 

            employeeFormList = new List<As_Employee_Form>();
            if (currentDepartment.Equals(editFlow.Edit_One_Department))
            {
                As_Employee_Form aef = new As_Employee_Form();
                aef.Form_ID = Convert.ToString(ViewState["form_ID"]);
                aef.Form_Type_Name = Convert.ToString(ViewState["formName"]);
                aef.Fill_Flag = 0;
                aef.Employee_ID = employee_ID;
                aef.Temp_Vendor_ID = Convert.ToString(ViewState["tempVendorID"]);
                employeeFormList.Add(aef);
            }
            foreach (KeyValuePair<string,string> item in dc)
            {
                As_Employee_Form aef = new As_Employee_Form();
                aef.Form_ID = Convert.ToString(ViewState["form_ID"]);
                aef.Form_Type_Name = Convert.ToString(ViewState["formName"]);
                aef.Fill_Flag = 0;
                aef.Employee_ID = item.Value;
                aef.Temp_Vendor_ID = Convert.ToString(ViewState["tempVendorID"]);
                employeeFormList.Add(aef);
            }

            EditFlow_BLL.addFormEditFlow(formEditFlow);
            foreach (As_Employee_Form item in employeeFormList)
            {
                EmployeeForm_BLL.addEmployeeForm(item);
            }
        }

        /// <summary>
        /// 上传文件之后
        /// </summary>
        private void fileUploadResult()
        {
            bool success = Convert.ToBoolean(Request.Form["__EVENTARGUMENT"]);
            if (success)
            {
                EmployeeForm_BLL.changeFillFlag(Session["Employee_ID"].ToString(), Convert.ToString(ViewState["form_ID"]), 1);
                UpdateFlag_BLL.updateFlagAsHold(Convert.ToString(ViewState["formTypeID"]), Convert.ToString(ViewState["tempVendorID"]));

                As_Approve ap = MultiEdit_BLL.getMultiEditTop(Convert.ToString(ViewState["form_ID"]));

                //Log
                LocalLog.writeLog(Convert.ToString(ViewState["form_ID"]), String.Format("{0}已填写，等待 {1} 填写", Employee_BLL.getEmployeeDepartment(Session["Employee_ID"].ToString(), Session["Position_Name"].ToString()),ap.Employee_Name), As_Write.FORM_MULTI_EDIT, Convert.ToString(ViewState["tempVendorID"]));
                
                //Mail
                LocalMail.flowToast(ap.Email, ap.Employee_Name, ap.Factory_Name, Convert.ToString(ViewState["tempVendorID"]), ap.Temp_Vendor_Name, Convert.ToString(ViewState["formName"]), "等待填写", DateTime.Now.ToString(), "此表格已由其他部门填写完毕，正在等待当前部门填写，请登陆系统填写表格并确认", Convert.ToString(ViewState["form_ID"]));

                //跳转
                Response.Redirect("EmployeeVendor.aspx");
            }

        }

        #region GridView

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

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
        #endregion

        #region OLD
        private void r_d_Yes()
        {
            //检查此表的R——D文件是否已经上传，如果没有，打开上传页面，上传文件，执行保存，执行禁止此人编辑

            //如果已经有rd文件
            if (VendorSelection_BLL.checkRDFile(Convert.ToString(ViewState["form_ID"]), "032"))
            {

            }
            else
            {
                string requestType = "multiFillUpload";
                //string fileTypeID = "032";
                LocalScriptManager.createManagerScript(Page, "layerMsg(" + "'请上传文件'" + ")", "rdyes1");
                LocalScriptManager.createManagerScript(Page, String.Format("uploadFile('{0}','{1}','{2}','{3}')", requestType, Convert.ToString(ViewState["tempVendorID"]), Convert.ToString(ViewState["tempVendorName"]), Convert.ToString(ViewState["form_ID"])), "upload");
                EmployeeForm_BLL.changeFillFlag(Session["Employee_ID"].ToString(), Convert.ToString(ViewState["form_ID"]), 1);
            }
        }

        private void r_d_No()
        {
            //保存表格，禁止此人编辑，直到所有部门均填写完毕后，开放提交

            LocalScriptManager.createManagerScript(Page, "layerMsg(" + "'已确认，正在等待其他部门填写该表'" + ")", "rdno1");
            EmployeeForm_BLL.changeFillFlag(Session["Employee_ID"].ToString(), Convert.ToString(ViewState["form_ID"]), 1);
            showVendorSelection();
        }

        private string getTotal(int startPoint, int endPoint)
        {
            double total = 0;
            for (int i = startPoint; i <= endPoint; i++)
            {
                try
                {
                    total += Convert.ToDouble(((TextBox)this.Controls[3].FindControl("TextBox" + i)).Text);
                }
                catch (Exception)
                {
                    total += 0;
                }
            }
            return total.ToString();
        }

        private string getPoint(string text, double percent)
        {
            try
            {
                return (Convert.ToDouble(text) * percent).ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            int startPoint = 97;
            switch (tb.ID.Replace("TextBox", ""))
            {
                case "1":
                    ((TextBox)this.Controls[3].FindControl("TextBox" + startPoint)).Text = getPoint(tb.Text, 0.2);
                    break;
                case "2":
                    ((TextBox)this.Controls[3].FindControl("TextBox" + (startPoint + 1))).Text = getPoint(tb.Text, 0.2);
                    break;
                case "3":
                    ((TextBox)this.Controls[3].FindControl("TextBox" + (startPoint + 2))).Text = getPoint(tb.Text, 0.2);
                    break;
                case "4":
                    ((TextBox)this.Controls[3].FindControl("TextBox" + (startPoint + 3))).Text = getPoint(tb.Text, 0.2);
                    break;
                case "5":
                    ((TextBox)this.Controls[3].FindControl("TextBox" + (startPoint + 4))).Text = getPoint(tb.Text, 0.2);
                    break;
                default:
                    break;
            }
        }


        /// <summary>
        /// 获取approved c_approved reject三个哪一个被选择
        /// </summary>
        /// <param name="rb"></param>
        /// <returns></returns>
        private byte getSelected(RadioButton[] rb)
        {
            if (rb[0].Checked)
            {
                return APPROVED;
            }
            else if (rb[1].Checked)
            {
                return C_APPROVAL;
            }
            else if (rb[2].Checked)
            {
                return REJECT;
            }
            return 3;
        }

        private void setSelected(byte? selected, RadioButton[] rb)
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
        #endregion
    }
}