using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;
using MODEL.QualityDetection;

namespace SHZSZHSUPPLY.QualityDetection.Utils
{
    public class LocalExcelReadingUtil
    {
        public static MyExcelSheet readDate(string path)
        {
            MyExcelSheet mysheet = new MyExcelSheet();
            try
            {
                string filepath = path;
                //---实例化excel对象  
                Excel.Application excel = new Excel.Application();
                ///---设置不可见  
                excel.Visible = false;

                Excel.Workbook book = null;
                ///--指定工作表名  
                Excel.Worksheet sheet = null;

                //---指定存在的excel，参数为路径名  
                book = excel.Application.Workbooks.Open(filepath, Missing.Value, true, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                //---获取当前需要操作的sheet  
                sheet = (Excel.Worksheet)book.Sheets["Sheet1"];

                ///---读取EXcel单元格的值  
                ///---这里是获取固定位置上的值  
                ///---这里获取的是  行索引为 1列 索引为1的单元格的值  
                Excel.Range range = (Excel.Range)sheet.Cells[1, 1];
                Excel.Range range1 = (Excel.Range)sheet.Cells[1, 2];
                Excel.Range range2 = (Excel.Range)sheet.Cells[1, 3];
                Excel.Range range3 = (Excel.Range)sheet.Cells[2, 1];
                Excel.Range range4 = (Excel.Range)sheet.Cells[2, 2];
                Excel.Range range5 = (Excel.Range)sheet.Cells[2, 3];

                ///---显示获取的值  
                //textBox1.Text = range.Text;
                //textBox1.Text += range1.Text;
                //textBox1.Text += range2.Text;
                //textBox1.Text += range3.Text;
                //textBox1.Text += range4.Text;
                //textBox1.Text += range5.Text;

                //---关闭打开的表  
                book.Close();

                sheet = null;
                book = null;
                excel.Quit();
                excel = null;
                ///---回收系统资源  
                GC.Collect();

                ///----读取成功
                return mysheet;
            }
            catch (Exception ex)
            {
                ///----异常返回null
                mysheet = null;
                return mysheet;
            }
        }
    }
}