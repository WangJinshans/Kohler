using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO.VenderInfo;
using BLL.VenderInfo;
using BLL.UserInfo;
using BLL.ErrorMessage;

namespace SHZSZHSUPPLY.VenderInfo
{
    public partial class VenderCreate : System.Web .UI .Page   
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usernum"] == null)
            {

                Response.Redirect("../Login.aspx");
                return;
            }

            if (IsPostBack == false)
            {
                DropDownList1.SelectedValue = Session["plantname"].ToString();

                if (Session["plantname"].ToString() == "无")
                {
                    TextBox1.Enabled = false;
                    TextBox2.Enabled = false;
                    Button1.Enabled = false;
                    
                }
                else
                {
                    VenderType_BLL Vendertype_BLL = new VenderType_BLL();
                    ListBox1.DataSource = Vendertype_BLL.VenderType_ALLList_BLL();
                    ListBox1.DataValueField = "Vender_Type";
                    ListBox1.DataTextField = "Vender_Type";
                    ListBox1.DataBind();
                    
                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            VenderList_BLL VenderList_BLL = new VenderList_BLL();

            if (TextBox1.Text.Trim().Length == 0 || TextBox2.Text.Trim().Length == 0 || TextBox3 .Text .Trim ().Length ==0)
            {
                string msg = "供应商代码,供应商名称,供应商类型不能为空";
                ErrorMsg_BLL.WebMessage(this.Page, msg);
                return;
                
            }
                                

            else
            {

                OperationLog_BLL OperationLog_BLL=new OperationLog_BLL ();
                VenderPlantList_BLL VenderPlantList_BLL = new VenderPlantList_BLL();
                List<VenderList_BO> VenderList = new List<VenderList_BO>();

                VenderList = VenderList_BLL.VenderList_BLL_List(TextBox1.Text.Trim () );

                if (VenderList_BLL.VenderList_BLL_Check(TextBox1.Text.Trim(), TextBox3.Text.Trim(), DropDownList1.Text) == false)
                {
                    string msg = "不能选择此供应商类型";
                    ErrorMsg_BLL.WebMessage(this.Page, msg);
                    return;
                }
               
             

                if (VenderList.Count > 0)
                {
                    TextBox2.Text = VenderList[0].Vender_Name;
                    Session.Remove ("vendercode");
                    Session.Remove("vendername");
                    Session.Remove("vendertype");
                    Session.Add("vendercode", TextBox1.Text.Trim ());
                    Session.Add("vendername", TextBox2.Text.Trim ());
                    Session.Add("vendertype", TextBox3.Text.Trim ());
                    iFrame1.Attributes["src"] = "VenderExist.aspx";

                }

                else
                {
                   

                    if (VenderPlantList_BLL.VenderPlantList_BLL_Insert(TextBox1.Text.Trim (), DropDownList1.Text, "Hold", TextBox3.Text.Trim ()) > 0 && VenderList_BLL.VenderList_BLL_Insert(TextBox1.Text.Trim (), TextBox2.Text.Trim ()) > 0 && OperationLog_BLL.VenderOperationLog_BLL_Insert(TextBox1.Text, TextBox3.Text, DropDownList1.Text, "Hold", Session["usernum"].ToString()) > 0)
                    {
                        Session.Remove("vendercode");
                        Session.Remove("vendername");
                        Session.Remove("vendertype");
                        Session.Add("vendercode", TextBox1.Text.Trim ());
                        Session.Add("vendername", TextBox2.Text.Trim ());
                        Session.Add("vendertype", TextBox3.Text.Trim ());
                      
                        iFrame1.Attributes["src"] = "VenderNoExist.aspx";

                    }

                }
            }            
        }

      

      

       

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox3.Text = ListBox1.SelectedValue;
        }

       
     }
}