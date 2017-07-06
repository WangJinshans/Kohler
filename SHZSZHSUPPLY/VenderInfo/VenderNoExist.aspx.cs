using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO.VenderInfo;
using BLL.VenderInfo;
using BLL.ErrorMessage;
using System.IO;
using System.Net.Mail;
using BO.PlantInfo;
using BLL.PlantInfo;
using BLL.SendMail;
using BLL.SystemAdmin;



namespace SHZSZHSUPPLY.VenderInfo
{
    public partial class VenderNoExist : System.Web .UI.Page   
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            ItemCategoryVendertype_BLL  ItemCategory_BLL = new ItemCategoryVendertype_BLL();

            //if (Session["usernum"] == null)
            //{

            //    Response.Redirect("../Login.aspx");
            //    return;
            //}
          

            if (IsPostBack == false)
            {
                Label13.Text = Session["vendercode"].ToString ();
                Label14.Text = Session["usernum"].ToString ();
                Label2.Text = Session["plantname"].ToString();
                Label15.Text = Session["vendertype"].ToString();
               

                List<VenderPlantList_BO> VenderPlantList_List = new List<VenderPlantList_BO>();
                VenderPlantList_BLL VenderPlantList_BLL = new VenderPlantList_BLL();
                VenderPlantList_List = VenderPlantList_BLL.VenderPlantList_BLL_List(Label13.Text, Label2.Text,Label15.Text );
                GridView3.DataSource = VenderPlantList_List;
                GridView3.DataBind();




                List<ItemCategory_BO> ItemCategory_ALL_List = new List<ItemCategory_BO>();
                ItemCategory_ALL_List = ItemCategory_BLL.ItemCategory_BLL_ListAll(Label15.Text );
                DropDownList1.DataSource = ItemCategory_ALL_List;
                DropDownList1.DataTextField = "Item_Category";
                DropDownList1.DataValueField = "Item_Category";
                DropDownList1.DataBind();

                DateTime dt = DateTime.Now;

                foreach (ItemCategory_BO itemcategory in ItemCategory_ALL_List)
                {
                    if (itemcategory.Item_Category == DropDownList1.SelectedValue)
                    {
                        Label1.Text = itemcategory.Item_Option.ToString();
                        Label3.Text = itemcategory.Item_Valid.ToString();
                        Label16.Text = itemcategory.Item_VenderType_All.ToString();

                        if ( Label3.Text.ToUpper()  == "False".ToUpper ())
                        {
                            Image1.ID = "temp1";
                            Image2.ID = "temp2";
                        }

                        Label4.Text = itemcategory.Item_Label.ToString();
                        Label6.Text = itemcategory.Item_Notify.ToString();
                        Label7.Text = "提前" + itemcategory.Item_Notify_Day_Before.ToString() + "天";
                        Label8.Text = "提前" + itemcategory.Item_Notify_Day_Before_First.ToString() + "天";
                        Label9.Text = "提前" + itemcategory.Item_Notify_Day_Before_Second.ToString() + "天";
                        Label10.Text = "提前" + itemcategory.Item_Notify_Day_Before_Third.ToString() + "天";
                        Label11.Text = itemcategory.Item_Plant_All.ToString();

                        if (Label11.Text.ToUpper () == "True".ToUpper ())

                        { Label12.Text = "ALL"; }

                        else { Label12.Text = Label2.Text ; }

                        if (Label16.Text.ToUpper () == "True".ToUpper ())
                        {
                            Label17.Text = "ALL";
                        }

                        else
                        {
                            Label17.Text = Label15.Text;
                        }
                     

                        if (Label4.Text.ToUpper () == "True".ToUpper ())
                        {
                            switch (Label12.Text )
                            {
                                case "上海科勒":

                                    Label5.Text = Label13.Text  + itemcategory.Item_Label_Spec.ToString() + dt.ToString("yyyyMMddHHmmss") + "SK";

                                    break;
                                case "珠海科勒":

                                    Label5.Text = Label13.Text + itemcategory.Item_Label_Spec.ToString() + dt.ToString("yyyyMMddHHmmss") + "ZH";

                                    break;

                                case "中山科勒":

                                    Label5.Text = Label13.Text + itemcategory.Item_Label_Spec.ToString() + dt.ToString("yyyyMMddHHmmss") + "ZS";

                                    break;

                                case "ALL":

                                    Label5.Text = Label13.Text + itemcategory.Item_Label_Spec.ToString() + dt.ToString("yyyyMMddHHmmss") + "ALL";

                                    break;

                            }
                        }

                        else
                        {
                            Label5.Text = "";

                        }


                    }

                }

                List<ItemCategory_BO> ItemCategory_Must_List = new List<ItemCategory_BO>();
                ItemCategory_Must_List = ItemCategory_BLL.ItemCategory_BLL_List(Label13.Text , Label2.Text,Label15.Text  );


                GridView1.DataSource = ItemCategory_Must_List;
                GridView1.DataBind();

                ItemList_BLL ItemList_BLL = new ItemList_BLL();
                List<ItemList_BO> ItemList_BO_List = new List<ItemList_BO>();
                ItemList_BO_List = ItemList_BLL.ItemList_BLL_List_Plant(Label13.Text, Label2.Text, Label15.Text);

                
                GridView2.DataSource = ItemList_BO_List;
                GridView2.DataBind();



            }
                               

           
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
             ItemCategoryVendertype_BLL ItemCategory_BLL = new ItemCategoryVendertype_BLL();
             List<ItemCategory_BO> ItemCategory_ALL_List = new List<ItemCategory_BO>();
           
            ItemCategory_ALL_List = ItemCategory_BLL.ItemCategory_BLL_ListAll(Label15.Text );
         
            DateTime dt= DateTime.Now;

            foreach (ItemCategory_BO itemcategory in ItemCategory_ALL_List)
            {
                if (itemcategory.Item_Category == DropDownList1.SelectedValue)
                {
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    Label1.Text = itemcategory.Item_Option.ToString ();
                    Label3.Text = itemcategory.Item_Valid.ToString();
                    Label16.Text = itemcategory.Item_VenderType_All.ToString();
                    if (Label3.Text.ToUpper () == "False".ToUpper ())
                    {
                        Image1.ID = "temp1";
                        Image2.ID = "temp2";
                    }

                    Label4.Text = itemcategory.Item_Label.ToString();
                    Label6.Text = itemcategory.Item_Notify.ToString();
                    Label7.Text = "提前" + itemcategory.Item_Notify_Day_Before.ToString() + "天";
                    Label8.Text = "提前" + itemcategory.Item_Notify_Day_Before_First.ToString() + "天";
                    Label9.Text = "提前" + itemcategory.Item_Notify_Day_Before_Second.ToString() + "天";
                    Label10.Text = "提前" + itemcategory.Item_Notify_Day_Before_Third.ToString() + "天";
                    Label11.Text = itemcategory.Item_Plant_All.ToString();

                    if (Label11.Text.ToUpper () == "True".ToUpper ())

                    { Label12.Text = "ALL"; }

                    else { Label12.Text = Label2.Text ; }

                    if (Label16.Text.ToUpper () == "True".ToUpper ())
                    {
                        Label17.Text = "ALL";
                    }

                    else
                    {
                        Label17.Text = Label15.Text;
                    }

                    if (Label4.Text.ToUpper () == "True".ToUpper ())
                    {
                        switch (Label12 .Text )
                        {
                            case "上海科勒":

                                Label5.Text = Label13.Text  + itemcategory.Item_Label_Spec.ToString() + dt.ToString("yyyyMMddHHmmss") + "SK";

                                break;
                            case "珠海科勒":

                                Label5.Text = Label13.Text + itemcategory.Item_Label_Spec.ToString() + dt.ToString("yyyyMMddHHmmss") + "ZH";

                                break;

                            case "中山科勒":

                                Label5.Text = Label13.Text + itemcategory.Item_Label_Spec.ToString() + dt.ToString("yyyyMMddHHmmss") + "ZS";

                                break;

                            case "ALL":

                                Label5.Text = Label13.Text + itemcategory.Item_Label_Spec.ToString() + dt.ToString("yyyyMMddHHmmss") + "ALL";

                                break;
                        }
                    }

                    else
                    {
                        Label5.Text = "";

                    }
                    
                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            ItemCategoryVendertype_BLL ItemCategory_BLL = new ItemCategoryVendertype_BLL();
            DateTime dt = DateTime.Now;

            if (Label3.Text.ToUpper () == "True".ToUpper () && (TextBox1.Text.Length == 0 || TextBox2.Text.Length == 0))
            {
                string msg = "没有选择有效时间";
                ErrorMsg_BLL.WebMessage(this.Page, msg);
                return;
            }

            if (Label3.Text.ToUpper () == "True".ToUpper ())
            {
                if (DateTime.Parse(TextBox2.Text) <= DateTime.Parse(TextBox1.Text))

                {
                    string msg = "有效时间不正确";
                    ErrorMsg_BLL.WebMessage(this.Page, msg);
                    return;
                }


                if (DateTime.Parse(TextBox2.Text).Date  < DateTime.Now.Date)
                {
                    string msg = "有效时间不正确";
                    ErrorMsg_BLL.WebMessage(this.Page, msg);
                    return;
                }
            }


            if (FileUpload1.HasFile == true)
            {
                if (System.IO.Path.GetExtension(FileUpload1.FileName).ToUpper() != ".PDF")
                {
                    string msg = "请选择PDF文件";
                    ErrorMsg_BLL.WebMessage(this.Page, msg);
                    return;

                }


                string newfilename;
                if (Label5.Text.Length > 0)
                {
                    newfilename = Label5.Text;

                }

                else
                {
                    newfilename = Label13.Text + DropDownList1.SelectedValue.ToString() + DateTime.Now.ToString("yyyyMMddHHmmss");
                }

                string path = Server.MapPath("..\\upload") + "\\" + newfilename+".pdf";
                string pathxiangdui = "..\\upload" + "\\" + newfilename + ".pdf";
                FileUpload1.SaveAs(path);

             

                ItemList_BLL ItemList_BLL = new ItemList_BLL();
                OperationLog_BLL OperationLog_BLL = new OperationLog_BLL();

                if (TextBox1.Text.Length == 0 && TextBox2.Text.Length == 0)
                {
                    ItemList_BLL.ItemList_BLL_Insert(Label13.Text, DropDownList1.SelectedValue, pathxiangdui, Label12.Text, Label17.Text ,"Enable",  Label5.Text ,DateTime.Parse ("1900-01-01")  , DateTime.Parse("1900-01-01"), dt, Label14.Text, TextBox3.Text);
                    OperationLog_BLL.ItemOperationLog_BLL_Insert(Label5.Text, "Upload", Label14.Text);
                }
                else
                {
                    ItemList_BLL.ItemList_BLL_Insert(Label13.Text, DropDownList1.SelectedValue, pathxiangdui, Label12.Text, Label17.Text ,"Enable", Label5.Text, DateTime.Parse(TextBox1.Text), DateTime.Parse(TextBox2.Text), dt, Label14.Text, TextBox3.Text);
                    OperationLog_BLL.ItemOperationLog_BLL_Insert(Label5.Text, "Upload", Label14.Text);
                }
              

                List<ItemCategory_BO> ItemCategory_Must_List = new List<ItemCategory_BO>();
                List<ItemList_BO> ItemList_BO_List = new List<ItemList_BO>();

                ItemCategory_Must_List = ItemCategory_BLL.ItemCategory_BLL_List(Label13.Text, Label2.Text,Label15.Text );
                ItemList_BO_List = ItemList_BLL.ItemList_BLL_List_Plant(Label13.Text,Label2 .Text,Label15.Text  );

             

                GridView2.DataSource = ItemList_BO_List;
                GridView2.DataBind();


                GridView1.DataSource = ItemCategory_Must_List;
                GridView1.DataBind();

                VenderPlantList_BLL VenderPlantList_BLL = new VenderPlantList_BLL();

                if (VenderPlantList_BLL.VenderPlantList_BLL_Update(Label13.Text, Label2.Text,Label15.Text ) ==1)
                {
                    string msg = "供应商" + Label13.Text + "工厂" + Label2.Text + "类型"+Label15.Text +"已ENABLE";
                    ErrorMsg_BLL.WebMessage(this.Page, msg);

                    OperationLog_BLL.VenderOperationLog_BLL_Insert(Label13.Text, Label15.Text, Label2.Text, "Enable", Label14.Text);

                    List<VenderPlantList_BO> VenderPlantList_List = new List<VenderPlantList_BO>();
                   
                    VenderPlantList_List = VenderPlantList_BLL.VenderPlantList_BLL_List(Label13.Text, Label2.Text,Label15.Text );
                   

                    List<VenderList_BO> VenderList_BO = new List<VenderList_BO>();
                    VenderList_BLL VenderList_BLL = new VenderList_BLL();
                    VenderList_BO = VenderList_BLL.VenderList_BLL_List(Label13.Text);

                    SendMail_BLL SendMail_BLL = new SendMail_BLL();
                    SendMail_BLL.SendMail_BLL_Plant(Label2.Text, Label13.Text, VenderList_BO[0].Vender_Name, GridView3 .Rows[0].Cells [3].Text ,GridView3 .Rows[0].Cells [4].Text ,"Enable",Label14.Text ,"文档上传完毕");
                    GridView3.DataSource = VenderPlantList_List;
                    GridView3.DataBind();


                }
                

            }

            else
            {
                string msg = "请选择文件";
                ErrorMsg_BLL.WebMessage(this.Page, msg);
                return;
            }


          
            List<ItemCategory_BO> ItemCategory_ALL_List = new List<ItemCategory_BO>();

            ItemCategory_ALL_List = ItemCategory_BLL.ItemCategory_BLL_ListAll(Label15.Text);

           

            foreach (ItemCategory_BO itemcategory in ItemCategory_ALL_List)
            {
                if (itemcategory.Item_Category == DropDownList1.SelectedValue)
                {
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    Label1.Text = itemcategory.Item_Option.ToString();
                    Label3.Text = itemcategory.Item_Valid.ToString();
                    Label16.Text = itemcategory.Item_VenderType_All.ToString();
                    if (Label3.Text.ToUpper() == "False".ToUpper())
                    {
                        Image1.ID = "temp1";
                        Image2.ID = "temp2";
                    }

                    Label4.Text = itemcategory.Item_Label.ToString();
                    Label6.Text = itemcategory.Item_Notify.ToString();
                    Label7.Text = "提前" + itemcategory.Item_Notify_Day_Before.ToString() + "天";
                    Label8.Text = "提前" + itemcategory.Item_Notify_Day_Before_First.ToString() + "天";
                    Label9.Text = "提前" + itemcategory.Item_Notify_Day_Before_Second.ToString() + "天";
                    Label10.Text = "提前" + itemcategory.Item_Notify_Day_Before_Third.ToString() + "天";
                    Label11.Text = itemcategory.Item_Plant_All.ToString();

                    if (Label11.Text.ToUpper() == "True".ToUpper())

                    { Label12.Text = "ALL"; }

                    else { Label12.Text = Label2.Text; }

                    if (Label16.Text.ToUpper() == "True".ToUpper())
                    {
                        Label17.Text = "ALL";
                    }

                    else
                    {
                        Label17.Text = Label15.Text;
                    }

                    if (Label4.Text.ToUpper() == "True".ToUpper())
                    {
                        switch (Label12.Text)
                        {
                            case "上海科勒":

                                Label5.Text = Label13.Text + itemcategory.Item_Label_Spec.ToString() + dt.ToString("yyyyMMddHHmmss") + "SK";

                                break;
                            case "珠海科勒":

                                Label5.Text = Label13.Text + itemcategory.Item_Label_Spec.ToString() + dt.ToString("yyyyMMddHHmmss") + "ZH";

                                break;

                            case "中山科勒":

                                Label5.Text = Label13.Text + itemcategory.Item_Label_Spec.ToString() + dt.ToString("yyyyMMddHHmmss") + "ZS";

                                break;

                            case "ALL":

                                Label5.Text = Label13.Text + itemcategory.Item_Label_Spec.ToString() + dt.ToString("yyyyMMddHHmmss") + "ALL";

                                break;
                        }
                    }

                    else
                    {
                        Label5.Text = "";

                    }

                }

            }



        }
              
       

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int i = e.RowIndex;
            SendMail_BLL SendMail_BLL = new SendMail_BLL();

            SystemAdmin_BLL SystemAdmin_BLL=new SystemAdmin_BLL ();

            bool result = false;
            result =SystemAdmin_BLL .SystemAdmincheck (Label14.Text );

           

            if (GridView2.Rows[i].Cells[3].Text == "ALL" && result ==false  )
            {
                
                System.Web.UI.ScriptManager.RegisterStartupScript(UpdatePanel2, this.GetType(), "", "alert('不能删除工厂共享文档')", true);
            }

            else if (GridView2.Rows[i].Cells[11].Text == "ALL" && result  == false)
            {
                
                System.Web.UI.ScriptManager.RegisterStartupScript(UpdatePanel2, this.GetType(), "", "alert('不能删除供应商类型共享文档')", true);
            }
            else
            {
                OperationLog_BLL OperationLog_BLL=new OperationLog_BLL() ;                          
                ItemList_BLL ItemList_BLL = new ItemList_BLL();

                List<ItemList_BO> ItemList_BO_List_IO = new List<ItemList_BO>();
                ItemList_BO_List_IO = ItemList_BLL.ItemList_BLL_List(Label13.Text);

                foreach (ItemList_BO ItemList in ItemList_BO_List_IO)
                {
                    if (ItemList.Vender_Code == GridView2.Rows[e.RowIndex].Cells[0].Text && ItemList.Item_Label == GridView2.Rows[e.RowIndex].Cells[5].Text)
                    {
                        string pathjuedui = Server.MapPath(ItemList.Item_Path);
                        System.IO.File.Delete(pathjuedui);
                        HyperLink value = (HyperLink)GridView2.Rows[e.RowIndex].Cells[1].Controls[0];

                        if (result == false)
                        {
                            SendMail_BLL.Sendmail_BLL_Item(GridView2.Rows[e.RowIndex].Cells[0].Text, value.Text, GridView2.Rows[e.RowIndex].Cells[3].Text, GridView2.Rows[e.RowIndex].Cells[11].Text, GridView2.Rows[e.RowIndex].Cells[4].Text, GridView2.Rows[e.RowIndex].Cells[5].Text, GridView2.Rows[e.RowIndex].Cells[6].Text, GridView2.Rows[e.RowIndex].Cells[7].Text, GridView2.Rows[e.RowIndex].Cells[9].Text, GridView2.Rows[e.RowIndex].Cells[8].Text, "文档删除", Label14.Text);
                        }
                    }
                }



                if (ItemList_BLL.ItemList_BLL_Delete(Label13.Text, GridView2.Rows[e.RowIndex].Cells[5].Text) > 0 && OperationLog_BLL .ItemOperationLog_BLL_Insert (GridView2 .Rows[e.RowIndex ].Cells [5].Text ,"Delete",Label14.Text )>0)
                {
                   
                   
                    ItemCategoryVendertype_BLL ItemCategory_BLL = new ItemCategoryVendertype_BLL();



                    List<ItemCategory_BO> ItemCategory_Must_List = new List<ItemCategory_BO>();
                    List<ItemList_BO> ItemList_BO_List = new List<ItemList_BO>();

                   


                    ItemCategory_Must_List = ItemCategory_BLL.ItemCategory_BLL_List(Label13.Text, Label2.Text,Label15.Text );
                    ItemList_BO_List = ItemList_BLL.ItemList_BLL_List_Plant(Label13.Text,Label12.Text,Label15.Text  );

                    GridView1.DataSource = ItemCategory_Must_List;
                    GridView1.DataBind();

                    GridView2.DataSource = ItemList_BO_List;
                    GridView2.DataBind();

                    VenderPlantList_BLL VenderPlantList_BLL = new VenderPlantList_BLL();

                    if (VenderPlantList_BLL.VenderPlantList_BLL_Update(Label13.Text, Label2.Text,Label15.Text ) == 2)
                    {
                        string msg = "供应商" + Label13.Text + "工厂" + Label2.Text + "供应商类型"+Label15.Text +"已HOLD";
                        System.Web.UI.ScriptManager.RegisterStartupScript(UpdatePanel2, this.GetType(), "", "alert('" + msg + "')", true);

                        OperationLog_BLL.VenderOperationLog_BLL_Insert(Label13.Text, Label15.Text, Label2.Text, "Hold", Label14.Text);

                        List<VenderPlantList_BO> VenderPlantList_List = new List<VenderPlantList_BO>();

                        VenderPlantList_List = VenderPlantList_BLL.VenderPlantList_BLL_List(Label13.Text, Label2.Text,Label15.Text );
                      



                        List<VenderList_BO> VenderList_BO = new List<VenderList_BO>();
                        VenderList_BLL VenderList_BLL = new VenderList_BLL();
                        VenderList_BO = VenderList_BLL.VenderList_BLL_List(Label13.Text );

                      
                        SendMail_BLL.SendMail_BLL_Plant(Label2.Text, Label13.Text, VenderList_BO[0].Vender_Name,GridView3 .Rows [0].Cells [3].Text , GridView3 .Rows [0].Cells [4].Text ,"Hold",Label14.Text ,"文档删除");
                        GridView3.DataSource = VenderPlantList_List;
                        GridView3.DataBind();
                    }
                  
                    

                }

                }
            }

       

       

        }

       

       

      
    }
