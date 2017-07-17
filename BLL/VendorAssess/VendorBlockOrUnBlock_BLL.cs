using DAL;
using MODEL;

namespace BLL
{
    public class VendorBlockOrUnBlock_BLL
    {
        public static int addVendorBlock(As_Vendor_Block_Or_UnBlock Block_UnBlock) //初始化表格赋值表格编号和表格种类编号
        {

            return VendorBlockOrUnBlock_DAL.addVendorBlock(Block_UnBlock);

        }

        public static int updateVendorBlock(As_Vendor_Block_Or_UnBlock Block_UnBlock)//更新供应商调查表
        {

            return VendorBlockOrUnBlock_DAL.updateVendorBlock(Block_UnBlock);
        }



        public static int checkVendorBlock(string FormId)//查询是否有表记录,1为存在 0为不存在
        {
            return VendorBlockOrUnBlock_DAL.checkVendorBlock(FormId);
        }

        public static As_Vendor_Block_Or_UnBlock getVendorBlock(string FormId)//按照表格编号和供应商名称查询供应商调查表
        {
            return VendorBlockOrUnBlock_DAL.getVendorBlock(FormId);
        }

        public static int getVendorBlockFlag(string FormId)//按照表格编号和供应商名称查询相应记录返回flag
        {
            return VendorBlockOrUnBlock_DAL.getVendorBlockFlag(FormId);
        }

    }
}
