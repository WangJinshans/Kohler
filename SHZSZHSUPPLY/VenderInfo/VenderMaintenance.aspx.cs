using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO.VenderInfo;
using BLL.VenderInfo;
using BLL.ErrorMessage;
using BLL.SendMail;
using BLL.SystemAdmin;
using Model;

namespace SHZSZHSUPPLY.VenderInfo
  
{
    public partial class VenderMaintenance : System.Web.UI.Page  
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
                SystemAdmin_BLL SystemAdmin_BLL=new SystemAdmin_BLL ();



                if (Session["plantname"].ToString () == "无" ) 
                {
                   DropDownList1.Enabled = false;
                   Label1.Enabled  = false;
                   Button1.Enabled = false;
                }

                DropDownList3.SelectedValue = Session["plantname"].ToString();
               

                if (Session.Count > 0)
                {
                    foreach (string key in Session.Keys)
                    {

                        if (key == "vendercodeExist")
                        {
                            DropDownList1.SelectedValue = Session["vendercodeExist"].ToString();
                           


                        }

                 

                        if (key == "vendertypeExist")
                        {
                           
                            DropDownList2.SelectedValue = Session["vendertypeExist"].ToString();


                        }


                    }

                    Session.Remove("vendercodeExist");
                    Session.Remove("vendertypeExist");
                }

                List<VenderList_BO> VenderList_BO_ListAll = new List<VenderList_BO>();
                VenderPlantList_BLL VenderPlantList_BLL = new VenderPlantList_BLL();
                VenderList_BO_ListAll = VenderPlantList_BLL.VenderPlantList_BLL_List_Plant(DropDownList3.Text);

                if (VenderList_BO_ListAll.Count > 0)
                {
                    DropDownList1.DataSource = VenderList_BO_ListAll;
                    DropDownList1.DataTextField = "vender_code";
                    DropDownList1.DataValueField = "vender_code";
                    DropDownList1.DataBind();
                }

                VenderType_BLL VenderType_BLL = new VenderType_BLL();
                List<VenderType_BO> VenderType_BO_List = new List<VenderType_BO>();
                VenderType_BO_List = VenderType_BLL.VenderType_List_VendercodePlantname_BLL(DropDownList1.Text, DropDownList3.Text);

                if (VenderType_BO_List.Count > 0)
                {
                    DropDownList2.DataSource = VenderType_BO_List;
                    DropDownList2.DataValueField = "vender_type";
                    DropDownList2.DataTextField = "vender_type";
                    DropDownList2.DataBind();
                }
                
                
                
                
                
                
                VenderList_BLL VenderList_BLL = new VenderList_BLL();
                List<VenderList_BO> VenderList_BO_List = new List<VenderList_BO>();

          
            


                VenderList_BO_List = VenderList_BLL.VenderList_BLL_List(DropDownList1.SelectedValue );
               
                if (VenderList_BO_List.Count > 0)
                {
                    Label1.Text = VenderList_BO_List[0].Vender_Name;
                }
                else
                {
                    return;
                }

            }

        }



        protected void Button1_Click1(object sender, EventArgs e)
        {
            VenderList_BLL VenderList_BLL = new VenderList_BLL();

    
          
      

            if (DropDownList1.Text.Length == 0)
            {
                ErrorMsg_BLL.WebMessage(this.Page, "没有选择供应商");
                return;
            }


            List<VenderList_BO> VenderList = new List<VenderList_BO>();
            VenderList = VenderList_BLL.VenderList_BLL_List(DropDownList1.Text  );
            if (VenderList.Count > 0)
            {
                Label1 .Text  = VenderList[0].Vender_Name;
            }

            List<VenderPlantList_BO> VenderPlantList_List = new List<VenderPlantList_BO>();
            VenderPlantList_BLL VenderPlantList_BLL = new VenderPlantList_BLL();
            VenderPlantList_List = VenderPlantList_BLL.VenderPlantList_BLL_List(DropDownList1.SelectedValue,DropDownList3 .SelectedValue,DropDownList2 .SelectedValue  );
            GridView1.DataSource = VenderPlantList_List;
            GridView1.DataBind();


            List<ItemCategory_BO> ItemCategory_ALL_List = new List<ItemCategory_BO>();
            ItemCategoryVendertype_BLL ItemCategory_BLL = new ItemCategoryVendertype_BLL();
            ItemCategory_ALL_List = ItemCategory_BLL.ItemCategory_BLL_ListAll(DropDownList2 .Text );
            DropDownList4.DataSource = ItemCategory_ALL_List;
            DropDownList4.DataTextField = "Item_Category";
            DropDownList4.DataValueField = "Item_Category";
            DropDownList4.DataBind();
            DateTime dt = DateTime.Now;
            foreach (ItemCategory_BO itemcategory in ItemCategory_ALL_List)
            {
                if (itemcategory.Item_Category == DropDownList4.SelectedValue)
                {
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    Label2.Text = itemcategory.Item_Option.ToString();
                    Label3.Text = itemcategory.Item_Valid.ToString();
                    Label29.Text = itemcategory.Item_VenderType_All.ToString();

                    if (Label3.Text.ToUpper () == "False".ToUpper ())
                    {
                        Image1.ID = "temp1";
                        Image2.ID = "temp2";
                    }

                    Label4.Text = itemcategory.Item_Label.ToString();
                    Label6.Text = itemcategory.Item_Notify.ToString();
                    Label7.Text = "提前"+itemcategory.Item_Notify_Day_Before.ToString() + "天";
                    Label8.Text = "提前" + itemcategory.Item_Notify_Day_Before_First.ToString() + "天";
                    Label9.Text = "提前" + itemcategory.Item_Notify_Day_Before_Second.ToString() + "天";
                    Label10.Text = "提前" + itemcategory.Item_Notify_Day_Before_Third.ToString() + "天";
                    Label11.Text = itemcategory.Item_Plant_All.ToString();
                    Label13.Text = DropDownList3.Text;
                    Label14.Text = DropDownList1.Text;
                    Label15.Text = Session["usernum"].ToString();
                    Label27.Text = DropDownList2.Text;

                    if (Label11.Text.ToUpper () == "True".ToUpper ())

                    { Label12.Text = "ALL"; }

                    else { Label12.Text = Label13.Text; }

                    if (Label29.Text.ToUpper () == "True".ToUpper ())
                    {
                        Label28.Text = "ALL";
                    }

                    else
                    {
                        Label28.Text = Label27.Text;
                    }


                    if (Label4.Text.ToUpper () == "True".ToUpper ())
                    {
                        switch (Label12.Text)
                        {
                            case "上海科勒":

                                Label5.Text = Label14.Text + itemcategory.Item_Label_Spec.ToString() + dt.ToString("yyyyMMddHHmmss") + "SK";

                                break;
                            case "珠海科勒":

                                Label5.Text = Label14.Text + itemcategory.Item_Label_Spec.ToString() + dt.ToString("yyyyMMddHHmmss") + "ZH";

                                break;

                            case "中山科勒":

                                Label5.Text = Label14.Text + itemcategory.Item_Label_Spec.ToString() + dt.ToString("yyyyMMddHHmmss") + "ZS";

                                break;
                            case "ALL":

                                Label5.Text = Label14.Text + itemcategory.Item_Label_Spec.ToString() + dt.ToString("yyyyMMddHHmmss") + "ALL";

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
            ItemCategory_Must_List = ItemCategory_BLL.ItemCategory_BLL_List(DropDownList1 .Text , DropDownList3 .Text,DropDownList2 .Text  );


            GridView4.DataSource = ItemCategory_Must_List;
            GridView4.DataBind();



            ItemList_BLL ItemList_BLL = new ItemList_BLL();
           List< ItemList_BO> ItemList_BO = new List<ItemList_BO>();
           ItemList_BO = ItemList_BLL.ItemList_BLL_List_Plant(DropDownList1.Text, DropDownList3.Text,DropDownList2 .Text );
            GridView2.DataSource = ItemList_BO;
            GridView2.DataBind();

        }

       

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.ClearSelection();
            List<VenderList_BO> VenderList_BO_List = new List<VenderList_BO>();
            VenderList_BLL VenderList_BLL_List = new VenderList_BLL();

            List<VenderType_BO> VenderType_BO_List = new List<VenderType_BO>();
            VenderType_BLL VenderType_BLL = new VenderType_BLL();

            VenderType_BO_List = VenderType_BLL.VenderType_List_VendercodePlantname_BLL(DropDownList1.Text,DropDownList3 .Text );

            DropDownList2.DataSource = VenderType_BO_List;
            DropDownList2.DataTextField = "vender_type";
            DropDownList2.DataValueField = "vender_type";
            DropDownList2.DataBind();


            VenderList_BO_List = VenderList_BLL_List.VenderList_BLL_List(DropDownList1.SelectedValue);
            Label1.Text = VenderList_BO_List[0].Vender_Name;
        }

        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {

            ItemCategoryVendertype_BLL ItemCategory_BLL = new ItemCategoryVendertype_BLL();
            List<ItemCategory_BO> ItemCategory_ALL_List = new List<ItemCategory_BO>();
            ItemCategory_ALL_List = ItemCategory_BLL.ItemCategory_BLL_ListAll(Label27.Text );

            DateTime dt = DateTime.Now;

            foreach (ItemCategory_BO itemcategory in ItemCategory_ALL_List)
            {
                if (itemcategory.Item_Category == DropDownList4.SelectedValue)
                {
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    Label2.Text = itemcategory.Item_Option.ToString();
                    Label3.Text = itemcategory.Item_Valid.ToString();
                    Label29.Text = itemcategory.Item_VenderType_All.ToString();

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

                    else { Label12.Text = Label13.Text; }

                    if (Label29.Text.ToUpper () == "True".ToUpper ())
                    { Label28.Text ="ALL";}
                    else
                    { Label28.Text = Label27.Text; }


                    if (Label4.Text.ToUpper () == "True".ToUpper ())
                    {
                        switch (Label12.Text)
                        {
                            case "上海科勒":

                                Label5.Text = Label14.Text + itemcategory.Item_Label_Spec.ToString() + dt.ToString("yyyyMMddHHmmss") + "SK";

                                break;
                            case "珠海科勒":

                                Label5.Text = Label14.Text + itemcategory.Item_Label_Spec.ToString() + dt.ToString("yyyyMMddHHmmss") + "ZH";

                                break;

                            case "中山科勒":

                                Label5.Text = Label14.Text + itemcategory.Item_Label_Spec.ToString() + dt.ToString("yyyyMMddHHmmss") + "ZS";

                                break;

                            case "ALL":

                                Label5.Text = Label14.Text + itemcategory.Item_Label_Spec.ToString() + dt.ToString("yyyyMMddHHmmss") + "ALL";

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

        protected void Button2_Click(object sender, EventArgs e)
        {


            ItemCategoryVendertype_BLL ItemCategory_BLL = new ItemCategoryVendertype_BLL();
            DateTime dt = DateTime.Now;
            if (Label5.Text.Length == 0)
            {
                string msg = "没有条码，请选择文档类型";
                ErrorMsg_BLL.WebMessage(this.Page, msg);
                return;
            }

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

                if (DateTime.Parse(TextBox2.Text).Date < DateTime.Now.Date)
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
                    newfilename = Label14.Text + DropDownList4.SelectedValue.ToString() + DateTime.Now.ToString("yyyyMMddHHmmss");
                }

                string path = Server.MapPath("..\\upload") + "\\" + newfilename + ".pdf";
                string pathxiangdui = "..\\upload" + "\\" + newfilename + ".pdf";
                FileUpload1.SaveAs(path);

              
                OperationLog_BLL OperationLog_BLL = new OperationLog_BLL();
                ItemList_BLL ItemList_BLL = new ItemList_BLL();

                if (TextBox1.Text.Length == 0 && TextBox2.Text.Length == 0)
                {
                    ItemList_BLL.ItemList_BLL_Insert(Label14.Text, DropDownList4.SelectedValue, pathxiangdui, Label12.Text,Label28.Text , "Enable", Label5.Text, DateTime.Parse("1900-01-01"), DateTime.Parse("1900-01-01"), dt, Label15.Text, TextBox3.Text);
                    OperationLog_BLL.ItemOperationLog_BLL_Insert(Label5.Text, "Upload", Label15.Text);
                }

                else
                {
                    ItemList_BLL.ItemList_BLL_Insert(Label14.Text, DropDownList4.SelectedValue, pathxiangdui, Label12.Text, Label28.Text ,"Enable", Label5.Text, DateTime.Parse(TextBox1.Text), DateTime.Parse(TextBox2.Text), dt, Label15.Text, TextBox3.Text);
                    string tempVendorID = BLL.TempVendor_BLL.getTempVendorIDByVendorCode(Label14.Text);
                    string tempVendorName = BLL.TempVendor_BLL.getTempVendorName(tempVendorID);
                    string fileTypeID = BLL.File_Type_BLL.getFileTypeIDByItemCategory(DropDownList4.SelectedValue);
                    As_File file = new As_File();
                    file.Temp_Vendor_ID = tempVendorID;
                    file.Temp_Vendor_Name = tempVendorName;
                    file.File_ID = Label5.Text;
                    file.File_Name = Label5.Text + ".pdf";
                    file.File_Path = pathxiangdui;
                    file.File_Enable_Time = TextBox1.Text;
                    file.File_Due_Time = TextBox2.Text;
                    file.Factory_Name = Label12.Text;
                    file.File_Type_ID = fileTypeID;
                    BLL.File_BLL.addFile(file);
                    OperationLog_BLL.ItemOperationLog_BLL_Insert(Label5.Text, "Upload", Label15.Text);
                }

            


                List<ItemCategory_BO> ItemCategory_Must_List = new List<ItemCategory_BO>();
               

                ItemCategory_Must_List = ItemCategory_BLL.ItemCategory_BLL_List(Label14.Text, Label13.Text,Label27.Text );
               

                GridView4.DataSource = ItemCategory_Must_List;
                GridView4.DataBind();

                List<ItemList_BO> ItemList_BO_List = new List<ItemList_BO>();
                ItemList_BO_List = ItemList_BLL.ItemList_BLL_List_Plant(Label14.Text, Label13.Text, Label27.Text);
                GridView2.DataSource = ItemList_BO_List;
                GridView2.DataBind();

                VenderPlantList_BLL VenderPlantList_BLL = new VenderPlantList_BLL();

                if (VenderPlantList_BLL.VenderPlantList_BLL_Update(Label14.Text, Label13.Text,Label27.Text ) ==1)
                {
                    string msg = "供应商" + Label14.Text + "工厂" + Label13.Text+"供应商类型"+Label27.Text  + "已ENABLE";
                    ErrorMsg_BLL.WebMessage(this.Page, msg);

                    OperationLog_BLL.VenderOperationLog_BLL_Insert(Label14.Text, Label27.Text, Label13.Text, "Enable", Label15.Text);

                    List<VenderPlantList_BO> VenderPlantList_List = new List<VenderPlantList_BO>();
                    VenderPlantList_List = VenderPlantList_BLL.VenderPlantList_BLL_List(DropDownList1.SelectedValue, DropDownList3.SelectedValue,DropDownList2 .Text );
               

                    List<VenderList_BO> VenderList_BO = new List<VenderList_BO>();
                    VenderList_BLL VenderList_BLL = new VenderList_BLL();
                    VenderList_BO = VenderList_BLL.VenderList_BLL_List(Label14.Text);

                    SendMail_BLL SendMail_BLL = new SendMail_BLL();
                    SendMail_BLL.SendMail_BLL_Plant(Label13.Text, Label14.Text, VenderList_BO[0].Vender_Name, GridView1 .Rows [0].Cells [3].Text ,GridView1 .Rows[0].Cells [4].Text ,"Enable",Label15.Text ,"文档上传完毕");
                    GridView1.DataSource = VenderPlantList_List;
                    GridView1.DataBind();

                   
                }


            }

            else
            {
                string msg = "请选择文件";
                ErrorMsg_BLL.WebMessage(this.Page, msg);
                return;
            }




           
            List<ItemCategory_BO> ItemCategory_ALL_List = new List<ItemCategory_BO>();
            ItemCategory_ALL_List = ItemCategory_BLL.ItemCategory_BLL_ListAll(Label27.Text);

         

            foreach (ItemCategory_BO itemcategory in ItemCategory_ALL_List)
            {
                if (itemcategory.Item_Category == DropDownList4.SelectedValue)
                {
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    Label2.Text = itemcategory.Item_Option.ToString();
                    Label3.Text = itemcategory.Item_Valid.ToString();
                    Label29.Text = itemcategory.Item_VenderType_All.ToString();

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

                    else { Label12.Text = Label13.Text; }

                    if (Label29.Text.ToUpper() == "True".ToUpper())
                    { Label28.Text = "ALL"; }
                    else
                    { Label28.Text = Label27.Text; }


                    if (Label4.Text.ToUpper() == "True".ToUpper())
                    {
                        switch (Label12.Text)
                        {
                            case "上海科勒":

                                Label5.Text = Label14.Text + itemcategory.Item_Label_Spec.ToString() + dt.ToString("yyyyMMddHHmmss") + "SK";

                                break;
                            case "珠海科勒":

                                Label5.Text = Label14.Text + itemcategory.Item_Label_Spec.ToString() + dt.ToString("yyyyMMddHHmmss") + "ZH";

                                break;

                            case "中山科勒":

                                Label5.Text = Label14.Text + itemcategory.Item_Label_Spec.ToString() + dt.ToString("yyyyMMddHHmmss") + "ZS";

                                break;

                            case "ALL":

                                Label5.Text = Label14.Text + itemcategory.Item_Label_Spec.ToString() + dt.ToString("yyyyMMddHHmmss") + "ALL";

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
            SystemAdmin_BLL SystemAdmin_BLL = new SystemAdmin_BLL();

          

           

            if (GridView2.Rows[i].Cells[3].Text == "ALL" )
            {
             System.Web.UI.ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "GridView2_RowDeleting", "alert('不能删除工厂共享文档')", true);
                
            }

            else if (GridView2.Rows[i].Cells[11].Text == "ALL" )
            {

                System.Web.UI.ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "", "alert('不能删除供应商类型共享文档')", true);
            }

            else
            {
                
            
                
                OperationLog_BLL Operation_BLL = new OperationLog_BLL();
                ItemList_BLL ItemList_BLL = new ItemList_BLL();

                List<ItemList_BO> ItemList_BO_List_IO = new List<ItemList_BO>();
                ItemList_BO_List_IO = ItemList_BLL.ItemList_BLL_List(Label14.Text);

                foreach (ItemList_BO ItemList in ItemList_BO_List_IO)
                {
                    if (ItemList.Vender_Code == GridView2.Rows[e.RowIndex].Cells[0].Text && ItemList.Item_Label == GridView2.Rows[e.RowIndex].Cells[5].Text)
                    {
                        string pathjuedui = Server.MapPath(ItemList.Item_Path);
                        System.IO.File.Delete(pathjuedui );
                        HyperLink value = (HyperLink)GridView2.Rows[e.RowIndex ].Cells[1].Controls[0];

                      
                            SendMail_BLL.Sendmail_BLL_Item(GridView2.Rows[e.RowIndex].Cells[0].Text, value.Text, GridView2.Rows[e.RowIndex].Cells[3].Text, GridView2.Rows[e.RowIndex].Cells[11].Text, GridView2.Rows[e.RowIndex].Cells[4].Text, GridView2.Rows[e.RowIndex].Cells[5].Text, GridView2.Rows[e.RowIndex].Cells[6].Text, GridView2.Rows[e.RowIndex].Cells[7].Text, GridView2.Rows[e.RowIndex].Cells[9].Text, GridView2.Rows[e.RowIndex].Cells[8].Text, "文档删除", Label15.Text);

                        
                    }
                }


                if (ItemList_BLL.ItemList_BLL_Delete(Label14.Text, GridView2.Rows[e.RowIndex].Cells[5].Text) > 0 && Operation_BLL .ItemOperationLog_BLL_Insert (GridView2 .Rows[e.RowIndex ].Cells [5].Text ,"Delete",Label15.Text )>0)
                {


                    ItemCategoryVendertype_BLL ItemCategory_BLL = new ItemCategoryVendertype_BLL();
                    

                    List<ItemCategory_BO> ItemCategory_Must_List = new List<ItemCategory_BO>();
                    ItemCategory_Must_List = ItemCategory_BLL.ItemCategory_BLL_List(DropDownList1.Text, DropDownList3.Text,DropDownList2 .Text );
                    GridView4.DataSource = ItemCategory_Must_List;
                    GridView4.DataBind();



                    List<ItemList_BO> ItemList_BO_List = new List<ItemList_BO>();
       

                 
                    ItemList_BO_List = ItemList_BLL.ItemList_BLL_List_Plant(Label14.Text,Label13 .Text,Label27.Text  );
                                 

                    GridView2.DataSource = ItemList_BO_List;
                    GridView2.DataBind();

                    VenderPlantList_BLL VenderPlantList_BLL = new VenderPlantList_BLL();

                 
                        if (VenderPlantList_BLL.VenderPlantList_BLL_Update(Label14.Text, Label13.Text,Label27.Text ) == 2)
                        {
                            string msg = "供应商" + Label14.Text + "工厂" + Label13.Text +"供应商类型"+Label27.Text + "已HOLD";
                            System.Web.UI.ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "", "alert('" + msg + "')", true);

                            Operation_BLL.VenderOperationLog_BLL_Insert(Label14.Text, Label27.Text, Label13.Text, "Hold", Label15.Text);

                            List<VenderPlantList_BO> VenderPlantList_List = new List<VenderPlantList_BO>();

                            VenderPlantList_List = VenderPlantList_BLL.VenderPlantList_BLL_List(Label14.Text, Label13.Text,Label27.Text );



                            List<VenderList_BO> VenderList_BO = new List<VenderList_BO>();
                            VenderList_BLL VenderList_BLL = new VenderList_BLL();
                            VenderList_BO = VenderList_BLL.VenderList_BLL_List(Label14.Text);


                            SendMail_BLL.SendMail_BLL_Plant(Label13.Text, Label14.Text, VenderList_BO[0].Vender_Name, GridView1 .Rows [0].Cells [3].Text ,GridView1.Rows[0].Cells[4].Text, "Hold", Label15.Text, "文档删除");
                            GridView1.DataSource = VenderPlantList_List;
                            GridView1.DataBind();

                        }
                    
              


                }
                                

            }
       

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           int i=Convert .ToInt32 ( e.CommandArgument .ToString () ) ;
                        

           string vendercode = GridView1.Rows[i].Cells[0].Text;
           string plantname = GridView1.Rows[i].Cells[2].Text;
           string vendertype = GridView1.Rows[i].Cells[3].Text;

            if (e.CommandName == "Enable" && GridView1 .Rows [i].Cells [3].Text  !="Enable")
            {
                VenderPlantList_BLL VenderPlantList_BLL = new VenderPlantList_BLL();
                OperationLog_BLL OperationLog_BLL = new OperationLog_BLL();
                if (VenderPlantList_BLL.VenderPlantList_BLL_Update(vendercode, plantname,vendertype) ==1 && OperationLog_BLL .VenderOperationLog_BLL_Insert (vendercode,vendertype ,plantname ,"Enable",Label15.Text )>0 )
                {
                    List<VenderPlantList_BO> VenderPlantList_List = new List<VenderPlantList_BO>();

                    VenderPlantList_List = VenderPlantList_BLL.VenderPlantList_BLL_List(DropDownList1.SelectedValue, DropDownList3.SelectedValue,DropDownList2 .SelectedValue );
                   


                    List<VenderList_BO> VenderList_BO = new List<VenderList_BO>();
                    VenderList_BLL VenderList_BLL = new VenderList_BLL();
                    VenderList_BO = VenderList_BLL.VenderList_BLL_List(Label14.Text);

                    SendMail_BLL SendMail_BLL = new SendMail_BLL();
                    SendMail_BLL.SendMail_BLL_Plant(Label13.Text, Label14.Text, VenderList_BO[0].Vender_Name,GridView1 .Rows [0].Cells [3].Text , GridView1 .Rows [0].Cells [4].Text ,"Enable",Label15.Text ,"供应商状态变更");
                    GridView1.DataSource = VenderPlantList_List;
                    GridView1.DataBind();
                }

                else
                {
                    
                    System.Web.UI.ScriptManager.RegisterStartupScript(UpdatePanel3, this.GetType(), "GridView1_RowCommand", "alert('必传文档没有上传,不能启用供应商')", true);
                   
                    return;
                }
            }

            if (e.CommandName == "Disable" && GridView1.Rows[i].Cells[3].Text != "Disable")
            {
                VenderPlantList_BLL VenderPlantList_BLL = new VenderPlantList_BLL();
                OperationLog_BLL OperationLog_BLL = new OperationLog_BLL();
                if (VenderPlantList_BLL.VenderPlantList_BLL_UpdateDisable(vendercode, plantname,vendertype) > 0 && OperationLog_BLL .VenderOperationLog_BLL_Insert (vendercode,vendertype,plantname,"Disable",Label15.Text )>0)
                {
                    List<VenderPlantList_BO> VenderPlantList_List = new List<VenderPlantList_BO>();

                    VenderPlantList_List = VenderPlantList_BLL.VenderPlantList_BLL_List(DropDownList1.SelectedValue, DropDownList3.SelectedValue,DropDownList2 .SelectedValue );
                   


                    ItemList_BLL ItemList_BLL = new ItemList_BLL();
                    List<ItemList_BO> ItemList_BO = new List<ItemList_BO>();
                    ItemList_BO = ItemList_BLL.ItemList_BLL_List_Plant(Label14.Text,Label13.Text,Label27.Text  );
                    GridView2.DataSource = ItemList_BO;
                    GridView2.DataBind();


                    ItemCategoryVendertype_BLL ItemCategory_BLL = new ItemCategoryVendertype_BLL();
                    List<ItemCategory_BO> ItemCategory_Must_List = new List<ItemCategory_BO>();
                    ItemCategory_Must_List = ItemCategory_BLL.ItemCategory_BLL_List(Label14.Text, Label13.Text,Label27.Text );


                    GridView4.DataSource = ItemCategory_Must_List;
                    GridView4.DataBind();

                    List<VenderList_BO> VenderList_BO = new List<VenderList_BO>();
                    VenderList_BLL VenderList_BLL = new VenderList_BLL();
                    VenderList_BO = VenderList_BLL.VenderList_BLL_List(Label14.Text );

                    SendMail_BLL SendMail_BLL = new SendMail_BLL();
                    SendMail_BLL.SendMail_BLL_Plant(Label13.Text, Label14.Text, VenderList_BO[0].Vender_Name, GridView1 .Rows [0].Cells [3].Text ,GridView1 .Rows [0].Cells [4].Text ,"Disable",Label15.Text ,"供应商状态变更");
                    GridView1.DataSource = VenderPlantList_List;
                    GridView1.DataBind();

                }
                else
                {
                    return;
                }


            }


            if (e.CommandName == "Hold" && GridView1.Rows[i].Cells[3].Text != "Hold")
            {
                VenderPlantList_BLL VenderPlantList_BLL = new VenderPlantList_BLL();
                OperationLog_BLL Operation_BLL=new OperationLog_BLL ();
                if (VenderPlantList_BLL.VenderPlantList_BLL_UpdateHold(vendercode, plantname,vendertype ) > 0 && Operation_BLL .VenderOperationLog_BLL_Insert (vendercode,vendertype,plantname,"Hold",Label15.Text )>0 )
                {
                    List<VenderPlantList_BO> VenderPlantList_List = new List<VenderPlantList_BO>();

                    VenderPlantList_List = VenderPlantList_BLL.VenderPlantList_BLL_List(DropDownList1.SelectedValue, DropDownList3.SelectedValue,DropDownList2 .SelectedValue );
                   


                    List<VenderList_BO> VenderList_BO = new List<VenderList_BO>();
                    VenderList_BLL VenderList_BLL = new VenderList_BLL();
                    VenderList_BO = VenderList_BLL.VenderList_BLL_List(Label14.Text );

                    SendMail_BLL SendMail_BLL = new SendMail_BLL();
                    SendMail_BLL.SendMail_BLL_Plant(Label13.Text, Label14.Text, VenderList_BO[0].Vender_Name, GridView1.Rows [0].Cells [3].Text ,GridView1 .Rows [0].Cells [4].Text ,"Hold",Label15 .Text ,"供应商状态变更");
                    GridView1.DataSource = VenderPlantList_List;
                    GridView1.DataBind();

                }
                else
                {
                    return;
                }
            }
        }



        protected void Edit(object sender, EventArgs e)
        {
           using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
               
                 Label17.Text  = row.Cells[0].Text;

                 HyperLink value = (HyperLink)row.Cells[1].Controls[0];
               Label19.Text  = value.Text ;
              Label21.Text  = row.Cells[3].Text;
              TextBox4 .Text   =row.Cells[6].Text;
              TextBox5 .Text  = row.Cells[7].Text;
              Label26.Text = row.Cells[5].Text;

               if (row.Cells [6].Text.Length  <10 ||row.Cells [7].Text.Length <10)
               {
                   return;
               }
              ModalPopupExtender1.Show();
             
            }

            
        }

       // protected void Button4_Click(object sender, EventArgs e)
       // {

            //ItemList_BLL ItemList_BLL = new ItemList_BLL();
           // ItemList_BLL.ItemList_BLL_UpdateValidity(Label26.Text, "Enable", DateTime.Parse(TextBox4.Text), DateTime.Parse(TextBox5.Text));
           
            //List<ItemList_BO> ItemList_BO = new List<ItemList_BO>();
           // ItemList_BO = ItemList_BLL.ItemList_BLL_List(Label14.Text);
           // GridView2.DataSource = ItemList_BO;
            //GridView2.DataBind();

        //}


        protected void Save(object sender, EventArgs e)
        {
            if (DateTime.Parse(TextBox5.Text) <= DateTime.Parse(TextBox4.Text) || DateTime.Parse(TextBox5.Text) < DateTime.Now)
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "Save", "alert('有效时间不正确')", true);
            }

            else
            {
                ItemList_BLL ItemList_BLL = new ItemList_BLL();
                OperationLog_BLL OperationLog_BLL = new BLL.VenderInfo.OperationLog_BLL();
                ItemList_BLL.ItemList_BLL_UpdateValidity(Label26.Text, "Enable", DateTime.Parse(TextBox4.Text), DateTime.Parse(TextBox5.Text));
                OperationLog_BLL.ItemOperationLog_BLL_Insert(Label26.Text, "Edit", Label15.Text);

                List<ItemList_BO> ItemList_BO = new List<ItemList_BO>();
                ItemList_BO = ItemList_BLL.ItemList_BLL_List_Plant(Label14.Text,Label13 .Text,Label27.Text  );
                GridView2.DataSource = ItemList_BO;
                GridView2.DataBind();


                ItemCategoryVendertype_BLL ItemCategoryVendertype_BLL = new ItemCategoryVendertype_BLL();
                List <ItemCategory_BO> ItemCategory_BO=new List<ItemCategory_BO>();
                ItemCategory_BO = ItemCategoryVendertype_BLL.ItemCategory_BLL_List(Label14.Text, Label13.Text, Label27.Text);

                GridView4.DataSource = ItemCategory_BO;
                GridView4.DataBind();


                VenderPlantList_BLL VenderPlantList_BLL = new VenderPlantList_BLL();

                if (VenderPlantList_BLL.VenderPlantList_BLL_List(Label14.Text, Label13.Text, Label27.Text)[0].Vender_State == "Enable")
                {
                }
                else
                {

                    if (VenderPlantList_BLL.VenderPlantList_BLL_Update(Label14.Text, Label13.Text, Label27.Text) == 1 && OperationLog_BLL .VenderOperationLog_BLL_Insert (Label14.Text ,Label27.Text ,Label13.Text ,"Enable",Label15.Text )>0)
                    {
                        string msg = "供应商" + Label14.Text + "工厂" + Label13.Text + "供应商类型" + Label27.Text + "已Enable";
                        System.Web.UI.ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "", "alert('" + msg + "')", true);


                        List<VenderPlantList_BO> VenderPlantList_List = new List<VenderPlantList_BO>();

                        VenderPlantList_List = VenderPlantList_BLL.VenderPlantList_BLL_List(Label14.Text, Label13.Text, Label27.Text);



                        List<VenderList_BO> VenderList_BO = new List<VenderList_BO>();
                        VenderList_BLL VenderList_BLL = new VenderList_BLL();
                        VenderList_BO = VenderList_BLL.VenderList_BLL_List(Label14.Text);

                        SendMail_BLL SendMail_BLL = new SendMail_BLL();
                        SendMail_BLL.SendMail_BLL_Plant(Label13.Text, Label14.Text, VenderList_BO[0].Vender_Name,GridView1.Rows [0].Cells [3].Text  , GridView1.Rows[0].Cells[4].Text, "Enable", Label15.Text, "文档删除");
                        GridView1.DataSource = VenderPlantList_List;
                        GridView1.DataBind();
                    }
                }


            }
          
        }

     

       

      

       

       
       
    }
}