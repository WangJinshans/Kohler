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

        public const string FORM_NAME = "供应商选择表";
        public const string FORM_TYPE_ID = "016";
        private string tempVendorID = "";
        private string tempVendorName = "";
        private string formID = "";
        private string submit = "";

        public const byte APPROVED = 0;
        public const byte C_APPROVAL = 1;
        public const byte REJECT = 2;

        protected void Page_Load(object sender, EventArgs e)
        {
            //foreach (Control item in this.Controls[3].Controls)
            //{
            //    if (item is TextBox && item.ID.Contains("TextBox"))
            //    {
            //        ((TextBox)item).Text = "0";
            //    }
            //}

            if (!IsPostBack)
            {
                //获取session信息
                getSessionInfo();
                
                int check = VendorSelection_BLL.checkVendorSelection(formID);
                if (check == 0)//数据库中不存在这张表，则自动初始化
                {
                    As_Vendor_Selection Vendor_Selection = new As_Vendor_Selection();
                    Vendor_Selection.Form_Type_ID = FORM_TYPE_ID;
                    Vendor_Selection.Temp_Vendor_Name = tempVendorName;
                    Vendor_Selection.Temp_Vendor_ID = tempVendorID;
                    Vendor_Selection.Flag = 0;//将表格标志位信息改为已填写

                    int n = VendorSelection_BLL.addVendorSelection(Vendor_Selection);
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
                    showVendorSelection();
                }
                displayButton();
            }
            else
            {
                //处理postback回调
                switch (Request["__EVENTTARGET"])
                {
                    case "submitForm":
                        submitForm();
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
            if (CheckFlag_BLL.multiFillFinished(formID,tempVendorID,FORM_TYPE_ID))
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
            tempVendorID = Session["tempVendorID"].ToString();
            tempVendorName = TempVendor_BLL.getTempVendorName(tempVendorID);
            formID = VendorSelection_BLL.getFormID(tempVendorID);
            submit = Request.QueryString["submit"];
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
        /// 显示表格
        /// </summary>
        private void showVendorSelection()
        {
            string[] strArray = { "one", "two", "three", "four", "five" };

            //初始化表格数据源
            As_Vendor_Selection vendorSelection = VendorSelection_BLL.checkFlag(formID);

            //初始化supplier数据源
            suppliers = VendorSelectionSupplier_BLL.checkSupplier(formID);

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
                    LocalScriptManager.CreateScript(Page, "showSupplier("+i+"," + getSupplier(strArray[i]) + ")", "showSuppliers"+i);
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

            //插入到已提交表
            As_Form form = new As_Form();
            form.Form_ID = formID;
            form.Form_Name = FORM_NAME;
            form.Form_Type_ID = FORM_TYPE_ID;
            form.Temp_Vendor_Name = tempVendorName;
            form.Form_Path = "";
            form.Temp_Vendor_ID = tempVendorID;
            int add = AddForm_BLL.addForm(form);

            //一旦提交就把表As_Vendor_FormType字段FLag置1.
            int updateFlag = UpdateFlag_BLL.updateFlag(FORM_TYPE_ID, tempVendorID);

            Response.Redirect("EmployeeVendor.aspx");
            return "";
        }

        /// <summary>
        /// 网页内部弹出对话框，确定用户部门流程
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
                //TODO::这里不能这样写，具体参考Creation的写法，这里暂时不改
                Session["tempvendorname"] = tempVendorName;
                Session["Employee_ID"] = Session["Employee_ID"];
                Response.Write("<script>window.alert('提交成功！');window.location.href='EmployeeVendor.aspx'</script>");
            }
        }



        private As_Vendor_Selection saveForm(int flag, string manul)
        {
            //读取session
            getSessionInfo();

            //As_Vendor_Selection
            As_Vendor_Selection vendorSelection = new As_Vendor_Selection();
            vendorSelection.Form_ID = formID;
            vendorSelection.Ref_No = txbRef.Text.Trim();
            vendorSelection.Date = txbDate.Text.Trim();
            vendorSelection.Flag = flag;
            vendorSelection.Form_Type_ID = FORM_TYPE_ID;
            vendorSelection.Temp_Vendor_ID = tempVendorID;
            vendorSelection.Temp_Vendor_Name = tempVendorName;
            vendorSelection.Supplier_One_ID = txbOne.Text.Trim();
            vendorSelection.Supplier_Two_ID = txbTwo.Text.Trim();
            vendorSelection.Supplier_Three_ID = txbThree.Text.Trim();
            vendorSelection.Supplier_Four_ID = txbFour.Text.Trim();
            vendorSelection.Supplier_Five_ID = txbFive.Text.Trim();

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
                supplier.Form_ID = formID;
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
                write.Temp_Vendor_ID = tempVendorID;
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
            //重新获取session信息和get信息
            getSessionInfo();

            if (submit == "yes")
            {
                //形成参数
                As_Vendor_Selection Vendor_Selection = saveForm(2, "提交表格");

                //对于用户部门，使用弹出对话框选择
                newApproveAccess(FORM_TYPE_ID, formID);
            }
            else
            {
                Response.Write("<script>window.alert('无法提交，请等待其他表格审批完毕后再次尝试！')</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (saveForm(1, "保存表格") != null)
            {
                LocalScriptManager.CreateScript(Page, String.Format("layerMsg('{0}')", "保存成功！"), "saveForm");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeVendor.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //session Info
            getSessionInfo();

            saveForm(1, "保存表格");

            //info
            string currentDepartment = Employee_BLL.getEmployeeDepartment(Session["Employee_ID"].ToString());
            As_Edit_Flow edtFlow = EditFlow_BLL.getEditFlow(FORM_TYPE_ID);
            List<string> departments = new List<string>() { edtFlow.Edit_One_Department, edtFlow.Edit_Two_Department, edtFlow.Edit_Three_Department };

            //check
            if (EditFlow_BLL.checkFormEditFlow(formID) <= 0)
            {
                //TODO::从数据库摘取静态flow，弹窗选择对应employee id，插入editflow表，插入employee form
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
                LocalScriptManager.CreateScript(Page, "selectEmployeeID(" + jss.Serialize(departments)+","+jss.Serialize(totalIDList)+","+jss.Serialize(totalNameList)+")", "selectID");

            }
            else
            {
                //如果是采购
                if (VendorSelection_BLL.checkDepartment(Session["Employee_ID"].ToString(), edtFlow))
                {
                    //saveForm(1, "保存表格");
                    bool has_R_D_File = VendorSelection_BLL.checkRDFile(formID, "032");
                    LocalScriptManager.CreateScript(Page, "R_D_Confirm("+has_R_D_File.ToString().ToLower()+",'"+tempVendorID+"','"+tempVendorName+"')", "rdcfm");
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
                    EmployeeForm_BLL.changeFillFlag(Session["Employee_ID"].ToString(), formID, 1);
                    UpdateFlag_BLL.updateFlagAsHold(FORM_TYPE_ID, tempVendorID);

                    //如果是最后一个填写人，更改表格状态为填写完成状态
                    if (currentDepartment.Equals(departments[departments.Count - 1]))
                    {
                        UpdateFlag_BLL.updateEditFlowFlag(formID, tempVendorID);
                        UpdateFlag_BLL.updateFlagAsFinish(FORM_TYPE_ID, tempVendorID);
                    }
                    LocalScriptManager.CreateScript(Page, "layerMsgFunc('已确认',function(){window.location.href='FormWaitToFill.aspx';})", "otherCFM");
                    //Response.Redirect("FormWaitToFill.aspx");
                }
            }
            //如果是，保存表格，禁止此人再次编辑，fill——flag此人均置为1
        }

        private void selectResult()
        {
            getSessionInfo();

            string employee_ID = Session["Employee_ID"].ToString();
            string currentDepartment = Employee_BLL.getEmployeeDepartment(employee_ID);

            //TODO::根据选择的list，初始化formeditflow，employeeformlist
            JavaScriptSerializer jss = new JavaScriptSerializer();
            As_Edit_Flow editFlow = EditFlow_BLL.getEditFlow(FORM_TYPE_ID);

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

            formEditFlow.Form_ID = formID;
            formEditFlow.Multi_Edit = editFlow.Multi_Edit;
            formEditFlow.Temp_Vendor_ID = tempVendorID;
            formEditFlow.Factory_Name = "上海科勒"; //TODO::三厂

            employeeFormList = new List<As_Employee_Form>();
            if (currentDepartment.Equals(editFlow.Edit_One_Department))
            {
                As_Employee_Form aef = new As_Employee_Form();
                aef.Form_ID = formID;
                aef.Form_Type_Name = FORM_NAME;
                aef.Fill_Flag = 0;
                aef.Employee_ID = employee_ID;
                aef.Temp_Vendor_ID = tempVendorID;
                employeeFormList.Add(aef);
            }
            foreach (KeyValuePair<string,string> item in dc)
            {
                As_Employee_Form aef = new As_Employee_Form();
                aef.Form_ID = formID;
                aef.Form_Type_Name = FORM_NAME;
                aef.Fill_Flag = 0;
                aef.Employee_ID = item.Value;
                aef.Temp_Vendor_ID = tempVendorID;
                employeeFormList.Add(aef);
            }

            EditFlow_BLL.addFormEditFlow(formEditFlow);
            foreach (As_Employee_Form item in employeeFormList)
            {
                EmployeeForm_BLL.addEmployeeForm(item);
            }
        }

        private void fileUploadResult()
        {
            getSessionInfo();

            bool success = Convert.ToBoolean(Request.Form["__EVENTARGUMENT"]);
            if (success)
            {
                EmployeeForm_BLL.changeFillFlag(Session["Employee_ID"].ToString(), formID, 1);
                UpdateFlag_BLL.updateFlagAsHold(FORM_TYPE_ID, tempVendorID);
                Response.Redirect("EmployeeVendor.aspx");
            }
        }

        #region GridView

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
        #endregion

        #region OLD
        private void r_d_Yes()
        {
            getSessionInfo();
            //TODO:检查此表的R——D文件是否已经上传，如果没有，打开上传页面，上传文件，执行保存，执行禁止此人编辑

            //如果已经有rd文件
            if (VendorSelection_BLL.checkRDFile(formID, "032"))
            {

            }
            else
            {
                string requestType = "multiFillUpload";
                string fileTypeID = "032";
                LocalScriptManager.CreateScript(Page, "layerMsg(" + "'请上传文件'" + ")", "rdyes1");
                LocalScriptManager.CreateScript(Page, String.Format("uploadFile('{0}','{1}','{2}','{3}')", requestType, tempVendorID, tempVendorName, fileTypeID), "upload");
                EmployeeForm_BLL.changeFillFlag(Session["Employee_ID"].ToString(), formID, 1);
            }
        }

        private void r_d_No()
        {
            //TODO:保存表格，禁止此人编辑，直到所有部门均填写完毕后，开放提交

            LocalScriptManager.CreateScript(Page, "layerMsg(" + "'已确认，正在等待其他部门填写该表'" + ")", "rdno1");
            EmployeeForm_BLL.changeFillFlag(Session["Employee_ID"].ToString(), formID, 1);

            getSessionInfo();
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