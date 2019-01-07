using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BLL.QualityDetection;
using SHZSZHSUPPLY.VendorAssess.Util;
using MODEL.QualityDetection;

namespace SHZSZHSUPPLY.VendorQualityDetection
{
    public partial class QT_Component_Maintain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取职位  只有工程师才有权限进入
            //string position_Name = Employee_BLL.getEmployeePositionName(Session["Employee_ID"].ToString());
            //if (!position_Name.Contains("工程师"))
            //{
            //    return;
            //}

            //注册异步刷新控件
            ScriptManager1.RegisterAsyncPostBackControl(this.selectSKU);
            //初始化界面
            if (!IsPostBack)
            {

            }
            //产生回调之后所要处理的事件
            else
            {
                switch (Request["__EVENTTARGET"])
                {

                    //case "timeSelect":
                    //    {
                    //        Session["time"] = Request.Form["__EVENTARGUMENT"];
                    //        string time = Session["time"].ToString();
                    //        getListbyTime(time);
                    //        LocalScriptManager.CreateScript(Page, "getTime()", "getTime");   //调用前端函数
                    //        break;
                    //    }
                    case "add_Click":
                        {
                            add_Click();
                            break;
                        }
                    case "change_Click":
                        {
                            change_Click();
                            break;
                        }
                    default:
                        break;
                }
            }

        }

        protected void test()
        {
            LocalScriptManager.CreateScript(Page, "test1()", "test1");
        }


        protected DataTable getComponentBySKU(string sku)
        {
            DataTable itemList;
            itemList = ComponentList_BLL.selectComponentBySKU(sku);
            return itemList;
        }

        //用来显示对应的SKU信息
        protected void selectSKU_Click(object sender, EventArgs e)
        {
            string sku = inputSKU.Text.ToString();
            if (ComponentList_BLL.hasSKU(sku))
            {
                DataTable itemList = getComponentBySKU(sku);
                GridView1.DataSource = itemList.DefaultView;
                GridView1.DataBind();
                UpdatePanel1.Update();
            }
            else  //！有点问题无法使用前端语句
            {
                //Response.Write("<script>window.alert('查无此SKU对应Component信息,请重新输入')</script>");
                /*LocalScriptManager.CreateScript(Page, "selectSKUError()", "selectSKUError"); */ //可以换这种写法优化界面显示
                test();
            }

        }

        //比较填写的内容和已有的内容 如果没有填写则按照原有的item填写
        protected QT_Component_List getRawItem()
        {
            QT_Component_List item = new QT_Component_List();
            string sku = inputSKU.Text.ToString();
            DataTable dataTable = getComponentBySKU(sku);
            DataRow myDr = dataTable.Rows[0];           //默认取第一行的数据SKU对应一条数据所以对应一个item
            item.Product_Name = myDr["Product_Name"].ToString();
            item.Product_Describes = myDr["Product_Describes"].ToString();
            item.Detection_Requirement = myDr["Detection_Requirement"].ToString();
            item.PPAP = myDr["PPAP"].ToString();
            item.Broken_Detection = myDr["Broken_Detection"].ToString();
            item.MBR_Distinction = myDr["MBR_Distinction"].ToString();
            item.Factory_Name = myDr["Factory_Name"].ToString();
            item.Vendor_Code = myDr["Vendor_Code"].ToString();
            item.Class_Leval = myDr["Class_Leval"].ToString();
            item.AQL = myDr["AQL"].ToString();
            item.Surface_Inspection = myDr["Surface_Inspection"].ToString();
            item.Suitability_Inspection = myDr["Suitability_Inspection"].ToString();
            return item;
        }

        //获取修改的Model
        protected QT_Component_List getItem_change()
        {
            QT_Component_List item = new QT_Component_List();
            
            item = getRawItem();
            if (change1.Text != "") { item.Product_Name = change1.Text.ToString(); }
            if (change2.Text != "") { item.Product_Describes = change2.Text.ToString(); }
            if (change3.Text != "") { item.Detection_Requirement = change3.Text.ToString(); }
            if (change4.Text != "") { item.PPAP = change4.Text.ToString(); }
            if (change5.Text != "") { item.Broken_Detection = change5.Text.ToString(); }
            if (change6.Text != "") { item.MBR_Distinction = change6.Text.ToString(); }
            if (change7.Text != "") { item.Factory_Name = change7.Text.ToString(); }
            if (change8.Text != "") { item.Vendor_Code = change8.Text.ToString(); }
            if (change9.Text != "") { item.Class_Leval = change9.Text.ToString(); }
            if (change10.Text != "") { item.AQL = change10.Text.ToString(); }
            if (change11.Text != "") { item.Surface_Inspection = change11.Text.ToString(); }
            if (change12.Text != "") { item.Suitability_Inspection = change12.Text.ToString(); }
            
            return item;
        }

        protected void change_Click()
        {
            string sku = inputSKU.Text.ToString();
            if (ComponentList_BLL.hasSKU(sku))
            {
                QT_Component_List item = new QT_Component_List();
                item = getItem_change();
                ComponentList_BLL.updateComponent(sku, item);

            }
            else  //！有点问题无法使用前端语句
            {
                test();
                //提醒不存在SKU不能操作
            }

            
        }

        protected void clear_Click(object sender, EventArgs e)
        {
            change1.Text = "";
            change2.Text = "";
            change3.Text = "";
            change4.Text = "";
            change5.Text = "";
            change6.Text = "";
            change7.Text = "";
            change8.Text = "";
            change9.Text = "";
            change10.Text = "";
            change11.Text = "";
            change12.Text = "";
        }


        protected void clearInsert_Click(object sender, EventArgs e)
        {
            insert1.Text = "";
            insert2.Text = "";
            insert3.Text = "";
            insert4.Text = "";
            insert5.Text = "";
            insert6.Text = "";
            insert7.Text = "";
            insert8.Text = "";
            insert9.Text = "";
            insert10.Text = "";
            insert11.Text = "";
            insert12.Text = "";
            insert13.Text = "";
        }

        //获取手动添加的数据
        protected QT_Component_List getItem_add()
        {
            QT_Component_List item = new QT_Component_List();
            item.SKU = insert1.Text.ToString();
            item.Product_Name = insert2.Text.ToString();
            item.Product_Describes = insert3.Text.ToString();
            item.Detection_Requirement = insert4.Text.ToString();
            item.PPAP = insert5.Text.ToString();
            item.Broken_Detection = insert6.Text.ToString();
            item.MBR_Distinction = insert7.Text.ToString();
            item.Factory_Name = insert8.Text.ToString();
            item.Vendor_Code = insert9.Text.ToString();
            item.Class_Leval = insert10.Text.ToString();
            item.AQL = insert11.Text.ToString();
            item.Surface_Inspection = insert12.Text.ToString();
            item.Suitability_Inspection = insert13.Text.ToString();
            return item;
        }

        //添加Component数据
        protected void add_Click()
        {
            QT_Component_List item = getItem_add();
            ComponentList_BLL.addComponent(item);
        }
    }
}