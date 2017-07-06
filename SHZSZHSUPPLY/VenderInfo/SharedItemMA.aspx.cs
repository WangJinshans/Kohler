using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.SendMail;
using BLL.SystemAdmin;
using BLL.VenderInfo;
using BLL.ItemNotifyInfo;
using BO.VenderInfo;
using BO.ItemNotifyInfo;
using BLL.ErrorMessage;



namespace SHZSZHSUPPLY.VenderInfo
{
    public partial class SharedItemMA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["usernum"] == null)
            //{

            //    Response.Redirect("../Login.aspx");
            //    return;
            //}





            if (IsPostBack == false)
            {

                SystemAdmin_BLL systemadmin = new SystemAdmin_BLL();

                if (systemadmin.SystemAdmincheck(Session["usernum"].ToString ()) == true)
                {
                    DropDownList1.SelectedValue = Session["plantname"].ToString();
                    List<VenderList_BO> VenderList_BO_ListAll = new List<VenderList_BO>();
                    VenderList_BLL VenderList_BLL = new VenderList_BLL();
                    VenderList_BO_ListAll = VenderList_BLL.VenderList_BLL_ListAll();
                    DropDownList2.DataSource = VenderList_BO_ListAll;
                    DropDownList2.DataTextField = "vender_code";
                    DropDownList2.DataValueField = "vender_code";
                    DropDownList2.DataBind();
                    Label2.Text = Session["usernum"].ToString();

                    if (Session.Count > 0)
                    {
                        foreach (string key in Session.Keys)
                        {

                            if (key == "vendercodeExist")
                            {
                                DropDownList2.SelectedValue = Session["vendercodeExist"].ToString();
                                DropDownList3.SelectedValue = Session["vendertypeExist"].ToString();


                            }


                        }

                        Session.Remove("vendercodeExist");
                        Session.Remove("vendertypeExist");
                    }

                    List<VenderType_BO> VenderType_BO_List = new List<VenderType_BO>();
                    VenderType_BLL Vendertype_BLL = new VenderType_BLL();
             


                    List<VenderList_BO> VenderList_BO_List = new List<VenderList_BO>();
                    VenderList_BO_List = VenderList_BLL.VenderList_BLL_List(DropDownList2.SelectedValue);

                    if (VenderList_BO_List.Count > 0)
                    {
                        Label1.Text = VenderList_BO_List[0].Vender_Name;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    DropDownList1.Enabled = false;
                    DropDownList2.Enabled = false;
                    DropDownList3.Enabled = false;
                    Button1.Enabled = false;

                }
            }
           
        }

        protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           
            int i = e.RowIndex;
            SendMail_BLL SendMail_BLL = new SendMail_BLL();

            OperationLog_BLL Operation_BLL = new OperationLog_BLL();
            ItemList_BLL ItemList_BLL = new ItemList_BLL();

            List<ItemList_BO> ItemList_BO_List_IO = new List<ItemList_BO>();
            ItemList_BO_List_IO = ItemList_BLL.ItemList_BLL_List(DropDownList2 .Text );

            foreach (ItemList_BO ItemList in ItemList_BO_List_IO)
            {
                if (ItemList.Vender_Code == GridView3.Rows[e.RowIndex].Cells[0].Text && ItemList.Item_Label == GridView3.Rows[e.RowIndex].Cells[5].Text)
                {
                    string pathjuedui = Server.MapPath(ItemList.Item_Path);
                    System.IO.File.Delete(pathjuedui);
                 
                                    
                }
            }




            if (ItemList_BLL.ItemList_BLL_Delete(DropDownList2 .Text , GridView3.Rows[e.RowIndex].Cells[5].Text) > 0 && Operation_BLL.ItemOperationLog_BLL_Insert(GridView3.Rows[e.RowIndex].Cells[5].Text, "Delete", Label2.Text) > 0)
            {

              
                List<ItemList_BO> ItemList_BO = new List<ItemList_BO>();
                ItemList_BO = ItemList_BLL.ItemList_BLL_List(DropDownList2.SelectedValue);
                GridView3.DataSource = ItemList_BO;
                GridView3.DataBind();

                VenderPlantList_BLL VenderPlantList_BLL = new VenderPlantList_BLL();

                for (int r=0;r<=GridView4 .Rows .Count -1;++r)
                {

                if (VenderPlantList_BLL.VenderPlantList_BLL_Update(DropDownList2 .Text,GridView4 .Rows [r].Cells [2].Text ,GridView4 .Rows [r].Cells [3].Text  ) == 2)
                {
                    string msg = "供应商" +DropDownList2 .Text  + "工厂" +GridView4 .Rows [r].Cells [2].Text  + "供应商类型" + GridView4 .Rows [r].Cells [3].Text  + "已HOLD";
                    System.Web.UI.ScriptManager.RegisterStartupScript(this.Page , this.GetType(), "", "alert('" + msg + "')", true);

                    Operation_BLL.VenderOperationLog_BLL_Insert(DropDownList2 .Text ,GridView4 .Rows [r].Cells [3].Text ,GridView4 .Rows [r].Cells [2].Text ,"Delete",Label2.Text );

                    List<VenderPlantList_BO> venderplant = new List<VenderPlantList_BO>();
                    venderplant = VenderPlantList_BLL.VenderPlantList_BLL_ListAll(DropDownList2.SelectedValue);
                    GridView4.DataSource = venderplant;
                    GridView4.DataBind();


                   
                


                    SendMail_BLL.SendMail_BLL_Plant(GridView4 .Rows [r].Cells [2].Text ,DropDownList2 .Text ,Label1.Text , GridView4 .Rows [r].Cells [3].Text , GridView4.Rows[r].Cells[4].Text, "Hold", Label2.Text , "文档删除");
                 

                }

                }


            }
          
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<VenderList_BO> VenderList_BO_List = new List<VenderList_BO>();
            VenderList_BLL VenderList_BLL_List = new VenderList_BLL();

            List<VenderType_BO> VenderType_BO_List = new List<VenderType_BO>();
            VenderType_BLL Vendertype_BLL = new VenderType_BLL();
        



            VenderList_BO_List = VenderList_BLL_List.VenderList_BLL_List(DropDownList2.SelectedValue);
            Label1.Text = VenderList_BO_List[0].Vender_Name;
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            VenderPlantList_BLL VenderPlantList_BLL = new VenderPlantList_BLL();

            

            ItemList_BLL ItemList_BLL = new ItemList_BLL();
            List<ItemList_BO> ItemList_BO = new List<ItemList_BO>();
            ItemList_BO = ItemList_BLL.ItemList_BLL_List(DropDownList2.SelectedValue);
            GridView3.DataSource = ItemList_BO;
            GridView3.DataBind();


            List<VenderPlantList_BO> venderplant = new List<VenderPlantList_BO>();
            venderplant = VenderPlantList_BLL.VenderPlantList_BLL_ListAll(DropDownList2.SelectedValue);
            GridView4.DataSource = venderplant;
            GridView4.DataBind();

            VenderList_BLL VenderList_BLL = new VenderList_BLL();
            List<VenderList_BO> VenderList_BO_VenderName = new List<VenderList_BO>();
            VenderList_BO_VenderName = VenderList_BLL.VenderList_BLL_List   (DropDownList2 .SelectedValue );
            GridView5.DataSource = VenderList_BO_VenderName;
            GridView5.DataBind();
            

        }

    

        protected void GridView4_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SharedItemMA_BLL SharedItemMA_BLL = new SharedItemMA_BLL();

            int itemresult=0;

            switch (itemresult =SharedItemMA_BLL .VenderPlantInfo_DEL_BLL (GridView4 .Rows [e.RowIndex ].Cells [0].Text ,GridView4 .Rows[e.RowIndex ].Cells [3].Text ,GridView4 .Rows [e.RowIndex ].Cells [2].Text ))
            {
                case 1:
                    {
                        string msg = "需要删除所有文档";

                        ErrorMsg_BLL.WebMessage(this.Page, msg);
                       
                        break;
                    }

                case 2:
                    {
                        string msg = "需要删除所有" + GridView4.Rows[e.RowIndex].Cells[3].Text + "类型文档";

                        ErrorMsg_BLL.WebMessage(this.Page, msg);
                      
                        break;
                    }

                case 3:
                    {
                        string msg = "需要删除所有" + GridView4.Rows[e.RowIndex].Cells[2].Text + GridView4.Rows[e.RowIndex].Cells[3].Text + "文档";

                        ErrorMsg_BLL.WebMessage(this.Page, msg);

                       
                        break;
                    }

                case 4:
                    {
                        string msg = "需要删除所有" + GridView4.Rows[e.RowIndex].Cells[2].Text + "文档";

                        ErrorMsg_BLL.WebMessage(this.Page, msg);


                        break;
                    }


                case 5:
                    {
                        string msg = "需要删除所有" + GridView4.Rows[e.RowIndex].Cells[3].Text + "类型文档";

                        ErrorMsg_BLL.WebMessage(this.Page, msg);


                        break;
                    }

                case 6:
                    {
                        string msg = "需要删除所有" + GridView4.Rows[e.RowIndex].Cells[3].Text + "类型文档";

                        ErrorMsg_BLL.WebMessage(this.Page, msg);


                        break;
                    }
            }
            VenderPlantList_BLL VenderPlantList_BLL = new VenderPlantList_BLL();
            List<VenderPlantList_BO> venderplant = new List<VenderPlantList_BO>();
            venderplant = VenderPlantList_BLL.VenderPlantList_BLL_ListAll(DropDownList2.SelectedValue);
            GridView4.DataSource = venderplant;
            GridView4.DataBind();
            
        }

     

        protected void GridView5_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "change")
            {

                int i = Convert.ToInt32(e.CommandArgument.ToString());

                TextBox1.Text = GridView5.Rows[i].Cells[0].Text;
                Label25.Text = GridView5.Rows[i].Cells[0].Text;
                TextBox4.Text = GridView5.Rows[i].Cells[1].Text;
                Label13.Text = GridView5.Rows[i].Cells[1].Text;
                ModalPopupExtender1.Show();
            }
        }

        protected void GridView5_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (GridView4.Rows.Count > 0)
            {
              

                string msg = "供应商有工厂绑定，不能删除";

                ErrorMsg_BLL.WebMessage(this.Page, msg);
                
                //this.Page.ClientScript .RegisterStartupScript (this.GetType (),"","alert('供应商有工厂绑定，不能删除')", true);
                return;
            }

            else
            {
                VenderList_BLL VenderList_BLL = new VenderList_BLL();
                VenderList_BLL.VenderList_BLL_Del(GridView5.Rows[e.RowIndex].Cells[0].Text);

                List<VenderList_BO> VenderList_BO_VenderName = new List<VenderList_BO>();
                VenderList_BO_VenderName = VenderList_BLL.VenderList_BLL_List(DropDownList2.SelectedValue);
                GridView5.DataSource = VenderList_BO_VenderName;
                GridView5.DataBind();
             
            }


           
           
        }

       

       

        public void vendersave(object sender,EventArgs e)
        {

            VenderList_BLL VenderList_BLL = new VenderList_BLL();
            VenderPlantList_BLL VenderPlantList_BLL=new VenderPlantList_BLL ();
            ItemList_BLL ItemList_BLL = new ItemList_BLL();
            if (VenderList_BLL.VenderList_BLL_Update_CodeName(Label25.Text, TextBox1.Text, TextBox4.Text) > 0 && VenderPlantList_BLL.VenderPlantList_BLL_Update_VenderName(Label25.Text, TextBox1.Text, TextBox4.Text) > 0 && ItemList_BLL.ItemList_BLL_UpdateVendercode (Label25.Text ,TextBox1.Text )>0)
            {

                List<VenderList_BO> VenderList_BO_ListAll = new List<VenderList_BO>();
            
                VenderList_BO_ListAll = VenderList_BLL.VenderList_BLL_ListAll();
                DropDownList2.DataSource = VenderList_BO_ListAll;
                DropDownList2.DataTextField = "vender_code";
                DropDownList2.DataValueField = "vender_code";
                DropDownList2.DataBind();
                DropDownList2.Text = TextBox1.Text;



                List<VenderList_BO> VenderList_BO_VenderName = new List<VenderList_BO>();
                VenderList_BO_VenderName = VenderList_BLL.VenderList_BLL_List (DropDownList2.SelectedValue);
                GridView5.DataSource = VenderList_BO_VenderName;
                GridView5.DataBind();


                List<VenderPlantList_BO> venderplant = new List<VenderPlantList_BO>();
                venderplant = VenderPlantList_BLL.VenderPlantList_BLL_ListAll(DropDownList2.SelectedValue);
                GridView4.DataSource = venderplant;
                GridView4.DataBind();

                
                List<ItemList_BO> ItemList_BO = new List<ItemList_BO>();
                ItemList_BO = ItemList_BLL.ItemList_BLL_List(DropDownList2.SelectedValue);
                GridView3.DataSource = ItemList_BO;
                GridView3.DataBind();

            }
        }

       
       
       

       
    }
}