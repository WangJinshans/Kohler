using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class VendorDiscovery_DAL
    {
        /// <summary>
        /// 添加新建表格
        /// </summary>
        /// <param name="Vendor_Discovery"></param>
        /// <returns></returns>
        public static int addVendorDiscovery(As_Vendor_Discovery Vendor_Discovery) //初始化表格赋值表格编号和表格种类编号
        {
            string sql = "insert into As_Vendor_Discovery(Form_Type_ID,Temp_Vendor_ID,Temp_Vendor_Name,Flag)values(@Form_Type_ID,@Temp_Vendor_ID,@Temp_Vendor_Name,@Flag)";
            SqlParameter[] sp = new SqlParameter[]
            {
               new SqlParameter("@Temp_Vendor_Name",Vendor_Discovery.Temp_Vendor_Name),
               new SqlParameter("@Flag",Vendor_Discovery.Flag),
               new SqlParameter("@Form_Type_ID",Vendor_Discovery.Form_Type_ID),
               new SqlParameter("@Temp_Vendor_ID",Vendor_Discovery.Temp_Vendor_ID)
            };
            return DBHelp.GetScalar(sql, sp);

        }

        public static int updateVendorDiscovery(As_Vendor_Discovery Vendor_Discovery)//更新供应商调查表
        {
            string sql = "update As_Vendor_Discovery set Temp_Vendor_Name=@Temp_Vendor_Name,Legal_Person=@Legal_Person, Address=@Address,Tel=@Tel,Fax=@Fax,Product_Name_One=@Product_Name_One,Size_One=@Size_One,Quality_One=@Quality_One, Product_Name_Two =@Product_Name_Two, Size_Two =@Size_Two,Quality_Two =@Quality_Two,Product_Name_Three=@Product_Name_Three ,Size_Three =@Size_Three,Quality_Three =@Quality_Three,Position_Environment_One=@Position_Environment_One,Envir_Protection_System_One=@Envir_Protection_System_One, Position_Environment_Two = @Position_Environment_Two,Envir_Protection_System_Two = @Envir_Protection_System_Two, Position_Environment_Three = @Position_Environment_Three,Envir_Protection_System_Three = @Envir_Protection_System_Three, Product_Ability =@Product_Ability,Last_Sale=@Last_Sale,Main_CusMark_One=@Main_CusMark_One,Main_CusMark_Two =@Main_CusMark_Two,Main_CusMark_Three=@Main_CusMark_Three,Register_Capital = @Register_Capital, Fixed_Assets = @Fixed_Assets, Flow_Capital = @Flow_Capital,Pay_Condition = @Pay_Condition,Employee_Num = @Employee_Num,Manager = @Manager,Quality_Person = @Quality_Person, Tech_Person = @Tech_Person,Company_Area = @Company_Area, Factory_Area = @Factory_Area,Entrepot_Area = @Entrepot_Area,Week_Turn_Num = @Week_Turn_Num,Week_Wrok_Time = @Week_Wrok_Time,Produce_Load = @Produce_Load,Product_material_One = @Product_material_One,Region_One = @Region_One,Material_Store_Conditon_One = @Material_Store_Conditon_One,Product_material_Two = @Product_material_Two,Region_Two = @Region_Two,Material_Store_Conditon_Two = @Material_Store_Conditon_Two, Product_material_Three = @Product_material_Three ,Region_Three = @Region_Three, Material_Store_Conditon_Three = @Material_Store_Conditon_Three,ISO = @ISO ,Transport = @Transport, Check_Device = @Check_Device,Send_Ability = @Send_Ability, Purchase_Period = @Purchase_Period,Min_Order_Num = @Min_Order_Num,Vendor_Participate = @Vendor_Participate,Produce_Flow = @Produce_Flow,Product_Book_Flow = @Product_Book_Flow ,Manage_Dimension = @Manage_Dimension,Employee_Experience = @Employee_Experience,File_Time = @File_Time,Conclusion = @Conclusion,Device_Name=@Device_Name,Device_Size=@Device_Size,Device_Year=@Device_Year,Device_Factory=@Device_Factory,Device_Condition=@Device_Condition,Flag=@Flag where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",Vendor_Discovery.Form_ID),
                new SqlParameter("@Form_Type_ID",Vendor_Discovery.Form_Type_ID),
                new SqlParameter("@Temp_Vendor_Name",Vendor_Discovery.Temp_Vendor_Name),
                new SqlParameter("@Legal_Person",Vendor_Discovery.Legal_Person),
                new SqlParameter("@Address",Vendor_Discovery.Address),
                new SqlParameter("@Tel",Vendor_Discovery.Tel),
                new SqlParameter("@Fax",Vendor_Discovery.Fax),
                new SqlParameter("@Product_Name_One",Vendor_Discovery.Product_Name_One),
                new SqlParameter("@Size_One",Vendor_Discovery.Size_One),
                new SqlParameter("@Quality_One",Vendor_Discovery.Quality_One),
                new SqlParameter("@Product_Name_Two",Vendor_Discovery.Product_Name_Two),
                new SqlParameter("@Size_Two",Vendor_Discovery.Size_Two),
                new SqlParameter("@Quality_Two",Vendor_Discovery.Quality_Two),
                new SqlParameter("@Product_Name_Three",Vendor_Discovery.Product_Name_Three),
                new SqlParameter("@Size_Three",Vendor_Discovery.Size_Three),
                new SqlParameter("@Quality_Three",Vendor_Discovery.Quality_Three),
                new SqlParameter("@Position_Environment_One",Vendor_Discovery.Position_Environment_One),
                new SqlParameter("@Envir_Protection_System_One",Vendor_Discovery.Envir_Protection_System_One),
                new SqlParameter("@Position_Environment_Two",Vendor_Discovery.Position_Environment_Two),
                new SqlParameter("@Envir_Protection_System_Two",Vendor_Discovery.Envir_Protection_System_Two),
                new SqlParameter("@Position_Environment_Three",Vendor_Discovery.Position_Environment_Three),
                new SqlParameter("@Envir_Protection_System_Three",Vendor_Discovery.Envir_Protection_System_Three),
                new SqlParameter("@Product_Ability",Vendor_Discovery.Product_Ability),
                new SqlParameter("@Last_Sale",Vendor_Discovery.Last_Sale),
                new SqlParameter("@Main_CusMark_One",Vendor_Discovery.Main_CusMark_One),
                new SqlParameter("@Main_CusMark_Two",Vendor_Discovery.Main_CusMark_Two),
                new SqlParameter("@Main_CusMark_Three",Vendor_Discovery.Main_CusMark_Three),
                new SqlParameter("@Register_Capital",Vendor_Discovery.Register_Capital),
                new SqlParameter("@Fixed_Assets",Vendor_Discovery.Fixed_Assets),
                new SqlParameter("@Flow_Capital",Vendor_Discovery.Flow_Capital),
                new SqlParameter("@Pay_Condition",Vendor_Discovery.Pay_Condition),
                new SqlParameter("@Employee_Num",Vendor_Discovery.Employee_Num),
                new SqlParameter("@Manager",Vendor_Discovery.Manager),
                new SqlParameter("@Quality_Person",Vendor_Discovery.Quality_Person),
                new SqlParameter("@Tech_Person",Vendor_Discovery.Tech_Person),
                new SqlParameter("@Company_Area",Vendor_Discovery.Company_Area),
                new SqlParameter("@Factory_Area",Vendor_Discovery.Factory_Area),
                new SqlParameter("@Entrepot_Area",Vendor_Discovery.Entrepot_Area),
                new SqlParameter("@Week_Turn_Num",Vendor_Discovery.Week_Turn_Num),
                new SqlParameter("@Week_Wrok_Time",Vendor_Discovery.Week_Wrok_Time),
                new SqlParameter("@Produce_Load",Vendor_Discovery.Produce_Load),
                new SqlParameter("@Product_material_One",Vendor_Discovery.Product_material_One),
                new SqlParameter("@Region_One",Vendor_Discovery.Region_One),
                new SqlParameter("@Material_Store_Conditon_One",Vendor_Discovery.Material_Store_Conditon_One),
                new SqlParameter("@Product_material_Two",Vendor_Discovery.Product_material_Two),
                new SqlParameter("@Region_Two",Vendor_Discovery.Region_Two),
                new SqlParameter("@Material_Store_Conditon_Two",Vendor_Discovery.Material_Store_Conditon_Two),
                new SqlParameter("@Product_material_Three",Vendor_Discovery.Product_material_Three),
                new SqlParameter("@Region_Three",Vendor_Discovery.Region_Three),
                new SqlParameter("@Material_Store_Conditon_Three",Vendor_Discovery.Material_Store_Conditon_Three),
                new SqlParameter("@ISO",Vendor_Discovery.ISO),
                new SqlParameter("@Transport",Vendor_Discovery.Transport),
                new SqlParameter("@Device_Name",Vendor_Discovery.Device_Name),
                new SqlParameter("@Device_Size",Vendor_Discovery.Device_Size),
                new SqlParameter("@Device_Year",Vendor_Discovery.Device_Year),
                new SqlParameter("@Device_Factory",Vendor_Discovery.Device_Factory),
                new SqlParameter("@Device_Condition",Vendor_Discovery.Device_Condition),
                new SqlParameter("@Check_Device",Vendor_Discovery.Check_Device),
                new SqlParameter("@Send_Ability",Vendor_Discovery.Send_Ability),
                new SqlParameter("@Purchase_Period",Vendor_Discovery.Purchase_Period),
                new SqlParameter("@Min_Order_Num",Vendor_Discovery.Min_Order_Num),
                new SqlParameter("@Vendor_Participate",Vendor_Discovery.Vendor_Participate),
                new SqlParameter("@Produce_Flow",Vendor_Discovery.Produce_Flow),
                new SqlParameter("@Product_Book_Flow",Vendor_Discovery.Product_Book_Flow),
                new SqlParameter("@Manage_Dimension",Vendor_Discovery.Manage_Dimension),
                new SqlParameter("@Employee_Experience",Vendor_Discovery.Employee_Experience),
                new SqlParameter("@File_Time",Vendor_Discovery.File_Time),
                new SqlParameter("@Conclusion",Vendor_Discovery.Conclusion),
                new SqlParameter("@Flag",Vendor_Discovery.Flag)
            };
            return DBHelp.ExecuteCommand(sql, sp);
        }

        /// <summary>
        /// 获取表格标识
        /// </summary>
        /// <param name="tempVendorID"></param>
        /// <returns></returns>
        public static string getFormID(string tempVendorID)
        {
            string formID = "";
            string sql = "select Form_ID from As_Vendor_Discovery where Temp_Vendor_ID=@Temp_Vendor_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("Temp_Vendor_ID",tempVendorID)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    formID = dr["Form_ID"].ToString();
                }
            }
            return formID;
        }

        public static int checkVendorDiscovery(string FormId)//查询是否有表记录,1为存在 0为不存在
        {
            string sql = "select * from As_Vendor_Discovery where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",FormId)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public static As_Vendor_Discovery getVendorDiscovery(string FormId)//按照表格编号和供应商名称查询供应商调查表
        {
            As_Vendor_Discovery Vendor_Discovery = null;
            string sql = "select * from As_Vendor_Discovery where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",FormId)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                Vendor_Discovery = new As_Vendor_Discovery();
                foreach (DataRow dr in dt.Rows)
                {
                    Vendor_Discovery.File_Time = Convert.ToString(dr["File_Time"]);
                    Vendor_Discovery.Form_ID = Convert.ToString(dr["Form_ID"]);
                    Vendor_Discovery.Form_Type_ID = Convert.ToString(dr["Form_Type_ID"]);
                    Vendor_Discovery.Temp_Vendor_Name = Convert.ToString(dr["Temp_Vendor_Name"]);
                    Vendor_Discovery.Legal_Person = Convert.ToString(dr["Legal_Person"]);
                    Vendor_Discovery.Address = Convert.ToString(dr["Address"]);
                    Vendor_Discovery.Tel = Convert.ToString(dr["Tel"]);
                    Vendor_Discovery.Fax = Convert.ToString(dr["Fax"]);
                    Vendor_Discovery.Product_Name_One = Convert.ToString(dr["Product_Name_One"]);
                    Vendor_Discovery.Size_One = Convert.ToString(dr["Size_One"]);
                    Vendor_Discovery.Quality_One = Convert.ToString(dr["Quality_One"]);
                    Vendor_Discovery.Product_Name_Two = Convert.ToString(dr["Product_Name_Two"]);
                    Vendor_Discovery.Size_Two = Convert.ToString(dr["Size_Two"]);
                    Vendor_Discovery.Quality_Two = Convert.ToString(dr["Quality_Two"]);
                    Vendor_Discovery.Product_Name_Three = Convert.ToString(dr["Product_Name_Three"]);
                    Vendor_Discovery.Size_Three = Convert.ToString(dr["Size_Three"]);
                    Vendor_Discovery.Quality_Three = Convert.ToString(dr["Quality_Three"]);
                    Vendor_Discovery.Position_Environment_One = Convert.ToString(dr["Position_Environment_One"]);
                    Vendor_Discovery.Envir_Protection_System_One = Convert.ToString(dr["Envir_Protection_System_One"]);
                    Vendor_Discovery.Position_Environment_Two = Convert.ToString(dr["Position_Environment_Two"]);
                    Vendor_Discovery.Envir_Protection_System_Two = Convert.ToString(dr["Envir_Protection_System_Two"]);
                    Vendor_Discovery.Position_Environment_Three = Convert.ToString(dr["Position_Environment_Three"]);
                    Vendor_Discovery.Envir_Protection_System_Three = Convert.ToString(dr["Envir_Protection_System_Three"]);
                    Vendor_Discovery.Product_Ability = Convert.ToString(dr["Product_Ability"]);
                    Vendor_Discovery.Last_Sale = Convert.ToString(dr["Last_Sale"]);
                    Vendor_Discovery.Main_CusMark_One = Convert.ToString(dr["Main_CusMark_One"]);
                    Vendor_Discovery.Main_CusMark_Two = Convert.ToString(dr["Main_CusMark_Two"]);
                    Vendor_Discovery.Main_CusMark_Three = Convert.ToString(dr["Main_CusMark_Three"]);
                    Vendor_Discovery.Register_Capital = Convert.ToString(dr["Register_Capital"]);
                    Vendor_Discovery.Fixed_Assets = Convert.ToString(dr["Fixed_Assets"]);
                    Vendor_Discovery.Flow_Capital = Convert.ToString(dr["Flow_Capital"]);
                    Vendor_Discovery.Pay_Condition = Convert.ToString(dr["Pay_Condition"]);
                    Vendor_Discovery.Employee_Num = Convert.ToString(dr["Employee_Num"]);
                    Vendor_Discovery.Manager = Convert.ToString(dr["Manager"]);
                    Vendor_Discovery.Quality_Person = Convert.ToString(dr["Quality_Person"]);
                    Vendor_Discovery.Tech_Person = Convert.ToString(dr["Tech_Person"]);
                    Vendor_Discovery.Company_Area = Convert.ToString(dr["Company_Area"]);
                    Vendor_Discovery.Factory_Area = Convert.ToString(dr["Factory_Area"]);
                    Vendor_Discovery.Entrepot_Area = Convert.ToString(dr["Entrepot_Area"]);
                    Vendor_Discovery.Week_Turn_Num = Convert.ToString(dr["Week_Turn_Num"]);
                    Vendor_Discovery.Week_Wrok_Time = Convert.ToString(dr["Week_Wrok_Time"]);
                    Vendor_Discovery.Produce_Load = Convert.ToString(dr["Produce_Load"]);
                    Vendor_Discovery.Product_material_One = Convert.ToString(dr["Product_material_One"]);
                    Vendor_Discovery.Region_One = Convert.ToString(dr["Region_One"]);
                    Vendor_Discovery.Material_Store_Conditon_One = Convert.ToString(dr["Material_Store_Conditon_One"]);
                    Vendor_Discovery.Product_material_Two = Convert.ToString(dr["Product_material_Two"]);
                    Vendor_Discovery.Region_Two = Convert.ToString(dr["Region_Two"]);
                    Vendor_Discovery.Material_Store_Conditon_Two = Convert.ToString(dr["Material_Store_Conditon_Two"]);
                    Vendor_Discovery.Product_material_Three = Convert.ToString(dr["Product_material_Three"]);
                    Vendor_Discovery.Region_Three = Convert.ToString(dr["Region_Three"]);
                    Vendor_Discovery.Material_Store_Conditon_Three = Convert.ToString(dr["Material_Store_Conditon_Three"]);
                    Vendor_Discovery.ISO = Convert.ToString(dr["ISO"]);
                    Vendor_Discovery.Device_Name = Convert.ToString(dr["Device_Name"]);
                    Vendor_Discovery.Device_Size = Convert.ToString(dr["Device_Size"]);
                    Vendor_Discovery.Device_Year = Convert.ToString(dr["Device_Year"]);
                    Vendor_Discovery.Device_Factory = Convert.ToString(dr["Device_Factory"]);
                    Vendor_Discovery.Device_Condition = Convert.ToString(dr["Device_Condition"]);
                    Vendor_Discovery.Check_Device = Convert.ToString(dr["Check_Device"]);
                    Vendor_Discovery.Send_Ability = Convert.ToString(dr["Send_Ability"]);
                    Vendor_Discovery.Purchase_Period = Convert.ToString(dr["Purchase_Period"]);
                    Vendor_Discovery.Min_Order_Num = Convert.ToString(dr["Min_Order_Num"]);
                    Vendor_Discovery.Vendor_Participate = Convert.ToString(dr["Vendor_Participate"]);
                    Vendor_Discovery.Produce_Flow = Convert.ToString(dr["Produce_Flow"]);
                    Vendor_Discovery.Product_Book_Flow = Convert.ToString(dr["Product_Book_Flow"]);
                    Vendor_Discovery.Manage_Dimension = Convert.ToString(dr["Manage_Dimension"]);
                    Vendor_Discovery.Employee_Experience = Convert.ToString(dr["Employee_Experience"]);
                    Vendor_Discovery.Conclusion = Convert.ToString(dr["Conclusion"]);
                }

            }
            return Vendor_Discovery;
        }

        public static int getVendorDiscoveryFlag(string FormId)//按照表格编号和供应商名称查询相应记录返回flag
        {
            As_Vendor_Discovery Vendor_Discovery = null;
            string sql = "select Flag from As_Vendor_Discovery where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",FormId)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                Vendor_Discovery = new As_Vendor_Discovery();
                foreach (DataRow dr in dt.Rows)
                {
                    Vendor_Discovery.Flag = Convert.ToInt32(dr["Flag"]);
                }
            }
            return Vendor_Discovery.Flag;
        }


    }
}
