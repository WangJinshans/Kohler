using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BLL.QualityDetection;
using Model;
using MODEL;
using MODEL.QualityDetection;
using SHZSZHSUPPLY.VendorAssess.Util;

namespace SHZSZHSUPPLY.VendorQualityDetection
{
    public partial class SCAR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "1";
            Label5.Text = "1";
            Label9.Text = "1";
            Label13.Text = "1";

            if (!IsPostBack)
            {
                
                bool check = SCAR_BLL.checkSCAR(Convert.ToString(ViewState["form_ID"]));    //有待修改
                if(check == false)
                {
                    QT_SCAR newSCAR = new QT_SCAR();
                    newSCAR.Factory = Convert.ToString(Session["Factory_Name"]);
                    newSCAR.Batch_No = "111111";
                    newSCAR.Vendor_Code = "2221313";
                    newSCAR.Flag = 0;           //表示未填写

                    int n = SCAR_BLL.addSCAR(newSCAR);
                    if (n == 0)
                    {
                        Response.Write("<script>window.alert('表格初始化错误（新建插入失败）！')</script>");
                        return;
                    }
                    else
                    {
                        string formID =  SCAR_BLL.getSCARFormID("2221313","上海科勒","111111");
                        ViewState.Add("form_ID", formID);
                    }
                }

            }

        }
        protected void Back_Click(object sender, EventArgs e)
        {

        }
        protected void Submit(object sender,EventArgs e)
        {
            saveForm(2);                //表示填写完成
            Response.Write("<script>window.alert('已写入数据库！')</script>");
        }


        //措施部分的Update还没有写
        private QT_SCAR getSCAR()
        {
            QT_SCAR newSCAR = new QT_SCAR();
            newSCAR.Approved_by2 = TextBox20.Text.ToString().Trim();
            newSCAR.I_C_A_Approved_by = TextBox34.Text.ToString().Trim();
            newSCAR.I_C_A_Approved_Date = TextBox35.Text.ToString().Trim();
            newSCAR.Approved_by4 = TextBox38.Text.ToString().Trim();
            newSCAR.P_C_A_Approved_by = TextBox52.Text.ToString().Trim();
            newSCAR.P_R_Approved_by = TextBox82.Text.ToString().Trim();
            newSCAR.V_E_Approved_by = TextBox54.Text.ToString().Trim();
            newSCAR.P_C_A_Approved_Date = TextBox53.Text.ToString().Trim();
            newSCAR.P_R_Approved_Date = TextBox83.Text.ToString().Trim();
            newSCAR.V_E_Approved_Date = TextBox55.Text.ToString().Trim();
            newSCAR.Business_Team_Member = TextBox17.Text.ToString().Trim();
            newSCAR.Completed_Date2 = TextBox21.Text.ToString().Trim();
            newSCAR.Completed_Date4 = TextBox39.Text.ToString().Trim();
            newSCAR.Customer = TextBox7.Text.ToString().Trim();
            newSCAR.Customer_satisfaction_degree = TextBox84.Text.ToString().Trim();
            newSCAR.Date_Raised = TextBox6.Text.ToString().Trim();
            
            newSCAR.Define_and_Verify_Root_Causes = TextBox36.Text.ToString().Trim();
            newSCAR.Deverlop_Team_Member = TextBox16.Text.ToString().Trim();
            newSCAR.Due_Date = TextBox13.Text.ToString().Trim();
            
            newSCAR.IQC_Team_Member = TextBox87.Text.ToString().Trim();
            
            newSCAR.Memo = TextBox85.Text.ToString().Trim();
            newSCAR.Occurred_Qty = TextBox5.Text.ToString().Trim();
            newSCAR.Occurred_Site = TextBox3.Text.ToString().Trim();
            newSCAR.Occurred_Time = TextBox4.Text.ToString().Trim();
            newSCAR.Part_Name = TextBox11.Text.ToString().Trim();
            newSCAR.Part_Number = TextBox8.Text.ToString().Trim();
           
            newSCAR.Prepared_by2 = TextBox19.Text.ToString().Trim();
            newSCAR.Prepared_by4 = TextBox37.Text.ToString().Trim();
            
            newSCAR.Problem_Description = TextBox18.Text.ToString().Trim();
            newSCAR.Produce_Team_Member = TextBox15.Text.ToString().Trim();
            newSCAR.Project_Team_Member = TextBox68.Text.ToString().Trim();
            newSCAR.Purchasing_Team_Member = TextBox69.Text.ToString().Trim();
            newSCAR.QA_Team_Member = TextBox14.Text.ToString().Trim();
            newSCAR.Qtv_Ins = TextBox9.Text.ToString().Trim();
            newSCAR.Qtv_Rei = TextBox12.Text.ToString().Trim();
            newSCAR.Raised_by = TextBox86.Text.ToString().Trim();
            newSCAR.Rea_For_CA = TextBox2.Text.ToString().Trim();
            newSCAR.Subject = TextBox1.Text.ToString().Trim();
            newSCAR.Supplier = TextBox10.Text.ToString().Trim();
            newSCAR.Immediate_Containment_Actions = new List<QT_SCAR_Immediate_Containment_Actions>();
            newSCAR.Permanent_Corrective_Actions = new List<QT_SCAR_Permanent_Corrective_Actions>();
            newSCAR.Prevent_Recurrence = new List<QT_SCAR_Prevent_Recurrence>();
            newSCAR.Verification_of_Effectiveness = new List<QT_SCAR_Verification_of_Effectiveness>();

            for(int i = 22,j=1; i <= 33 && j<=4; i += 3 , j++)
            {
                if ((FindControl("TextBox" + i) as TextBox).Text.ToString() == "") { break; }
                else
                {
                    QT_SCAR_Immediate_Containment_Actions item = new QT_SCAR_Immediate_Containment_Actions();
                    item.Immediate_Containment_Actions_No = (FindControl("Label" + j) as Label).Text.ToString();
                    item.Immediate_Containment_Actions_Content = (FindControl("TextBox" + i) as TextBox).Text.ToString();
                    item.Leader = (FindControl("TextBox" + (i + 1)) as TextBox).Text.ToString();
                    item.Date = (FindControl("TextBox" + (i + 2)) as TextBox).Text.ToString();
                    item.Form_ID = Convert.ToString(ViewState["form_ID"]);
                    newSCAR.Immediate_Containment_Actions.Add(item);
                }
            }

            for (int i = 40, j = 5; i <= 51 && j <= 8; i += 3, j++)
            {
                if ((FindControl("TextBox" + i) as TextBox).Text.ToString() == "") { break; }
                else
                {
                    QT_SCAR_Permanent_Corrective_Actions item = new QT_SCAR_Permanent_Corrective_Actions();
                    item.Permanent_Corrective_Actions_No = (FindControl("Label" + j) as Label).Text.ToString();
                    item.Permanent_Corrective_Actions_Content = (FindControl("TextBox" + i) as TextBox).Text.ToString();
                    item.Leader = (FindControl("TextBox" + (i + 1)) as TextBox).Text.ToString();
                    item.Date = (FindControl("TextBox" + (i + 2)) as TextBox).Text.ToString();
                    item.Form_ID = Convert.ToString(ViewState["form_ID"]);
                    newSCAR.Permanent_Corrective_Actions.Add(item);
                }
            }

            for (int i = 56, j = 9; i <= 67 && j <= 12; i += 3, j++)
            {
                if ((FindControl("TextBox" + i) as TextBox).Text.ToString() == "") { break; }
                else
                {
                    QT_SCAR_Prevent_Recurrence item = new QT_SCAR_Prevent_Recurrence();
                    item.Prevent_Recurrence_No = (FindControl("Label" + j) as Label).Text.ToString();
                    item.Prevent_Recurrence_Content = (FindControl("TextBox" + i) as TextBox).Text.ToString();
                    item.Leader = (FindControl("TextBox" + (i + 1)) as TextBox).Text.ToString();
                    item.Date = (FindControl("TextBox" + (i + 2)) as TextBox).Text.ToString();
                    item.Form_ID = Convert.ToString(ViewState["form_ID"]);
                    newSCAR.Prevent_Recurrence.Add(item);
                }
            }

            for (int i = 70, j = 13; i <= 81 && j <= 16; i += 3, j++)
            {
                if((FindControl("TextBox" + i) as TextBox).Text.ToString() == "") { break; }
                else { 
                QT_SCAR_Verification_of_Effectiveness item = new QT_SCAR_Verification_of_Effectiveness();
                item.Verification_of_Effectiveness_No= (FindControl("Label" + j) as Label).Text.ToString();
                item.Verification_of_Effectiveness_Content = (FindControl("TextBox" + i) as TextBox).Text.ToString();
                item.Verifier = (FindControl("TextBox" + (i + 1)) as TextBox).Text.ToString();
                item.Date = (FindControl("TextBox" + (i + 2)) as TextBox).Text.ToString();
                item.Form_ID = Convert.ToString(ViewState["form_ID"]);
                newSCAR.Verification_of_Effectiveness.Add(item);
                }
            }
            newSCAR.Person_Pro = "null";
            newSCAR.Machine_Pro = "null";
            newSCAR.Material_Pro = "null";
            newSCAR.Environment_Pro = "null";
            newSCAR.Law_Pro = "null";
            newSCAR.Measure_Pro = "null";

            if (CheckBox6.Checked == true) { newSCAR.Person_Pro += CheckBox6.Text.ToString().Trim(); }
            if (CheckBox7.Checked == true) { newSCAR.Person_Pro += CheckBox7.Text.ToString().Trim(); }
            if (CheckBox13.Checked == true) { newSCAR.Person_Pro += CheckBox13.Text.ToString().Trim(); }
            if (CheckBox19.Checked == true) { newSCAR.Person_Pro += CheckBox19.Text.ToString().Trim(); }

            if (CheckBox5.Checked == true) { newSCAR.Machine_Pro += CheckBox5.Text.ToString().Trim(); }
            if (CheckBox8.Checked == true) { newSCAR.Machine_Pro += CheckBox8.Text.ToString().Trim(); }
            if (CheckBox14.Checked == true) { newSCAR.Machine_Pro += CheckBox14.Text.ToString().Trim(); }
            if (CheckBox20.Checked == true) { newSCAR.Machine_Pro += CheckBox20.Text.ToString().Trim(); }
            if (CheckBox26.Checked == true) { newSCAR.Machine_Pro += CheckBox25.Text.ToString().Trim(); }
            if (CheckBox25.Checked == true) { newSCAR.Machine_Pro += CheckBox25.Text.ToString().Trim(); }

            if (CheckBox4.Checked == true) { newSCAR.Material_Pro += CheckBox4.Text.ToString().Trim(); }
            if (CheckBox9.Checked == true) { newSCAR.Material_Pro += CheckBox9.Text.ToString().Trim(); }
            if (CheckBox15.Checked == true) { newSCAR.Material_Pro += CheckBox15.Text.ToString().Trim(); }
            if (CheckBox21.Checked == true) { newSCAR.Material_Pro += CheckBox21.Text.ToString().Trim(); }
            if (CheckBox27.Checked == true) { newSCAR.Material_Pro += CheckBox27.Text.ToString().Trim(); }

            if (CheckBox3.Checked == true) { newSCAR.Law_Pro += CheckBox3.Text.ToString().Trim(); }
            if (CheckBox10.Checked == true) { newSCAR.Law_Pro += CheckBox10.Text.ToString().Trim(); }
            if (CheckBox16.Checked == true) { newSCAR.Law_Pro += CheckBox16.Text.ToString().Trim(); }
            if (CheckBox22.Checked == true) { newSCAR.Law_Pro += CheckBox22.Text.ToString().Trim(); }
            if (CheckBox28.Checked == true) { newSCAR.Law_Pro += CheckBox28.Text.ToString().Trim(); }
            if (CheckBox30.Checked == true) { newSCAR.Law_Pro += CheckBox30.Text.ToString().Trim(); }

            if (CheckBox2.Checked == true) { newSCAR.Environment_Pro += CheckBox2.Text.ToString().Trim(); }
            if (CheckBox12.Checked == true) { newSCAR.Environment_Pro += CheckBox12.Text.ToString().Trim(); }
            if (CheckBox17.Checked == true) { newSCAR.Environment_Pro += CheckBox17.Text.ToString().Trim(); }
            if (CheckBox23.Checked == true) { newSCAR.Environment_Pro += CheckBox23.Text.ToString().Trim(); }

            if (CheckBox1.Checked == true)  { newSCAR.Measure_Pro += CheckBox1.Text.ToString().Trim(); }
            if (CheckBox11.Checked == true) { newSCAR.Measure_Pro += CheckBox11.Text.ToString().Trim(); }
            if (CheckBox18.Checked == true) { newSCAR.Measure_Pro += CheckBox18.Text.ToString().Trim(); }
            if (CheckBox24.Checked == true) { newSCAR.Measure_Pro += CheckBox24.Text.ToString().Trim(); }

            return newSCAR;


        }

        
        private QT_SCAR saveForm(int flag)
        {
            QT_SCAR newSCAR = new QT_SCAR();
            newSCAR = getSCAR();
            newSCAR.Form_ID = Convert.ToString(ViewState["form_ID"]);
            newSCAR.Factory = "上海科勒";
            newSCAR.Batch_No = "111111";
            newSCAR.Vendor_Code = "2221313";
            newSCAR.Flag = flag;
            SCAR_BLL.updateSCAR(newSCAR);
            
            return newSCAR;
            

        }

        
        

        
    }
}