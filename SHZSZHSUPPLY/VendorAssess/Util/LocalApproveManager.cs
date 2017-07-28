using BLL;
using BLL.VendorAssess;
using Model;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHZSZHSUPPLY.VendorAssess.Util
{
    public class LocalApproveManager
    {
        public const int NOT_FINAL = 0;
        public const int NORMAL_FINAL = 1;
        public const int KCI_FINAL = 2;

        /// <summary>
        /// 非用户部门的审批建立
        /// </summary>
        /// <param name="formID"></param>
        /// <param name="FORM_TYPE_ID"></param>
        public static bool doAddApprove(string formID,string FORM_TYPE_ID,string tempVendorID,string factory)
        {
            //实例化审批流程
            As_Assess_Flow assess_flow = AssessFlow_BLL.getFirstAssessFlow(FORM_TYPE_ID);
            As_Form_AssessFlow Form_AssessFlow = new As_Form_AssessFlow();
            Form_AssessFlow.Form_ID = formID;
            Form_AssessFlow.First = assess_flow.User_Department_Assess;
            Form_AssessFlow.Second = assess_flow.Assess_Two_ID;
            Form_AssessFlow.Third = assess_flow.Assess_Three_ID;
            Form_AssessFlow.Four = assess_flow.Assess_Four_ID;
            Form_AssessFlow.Five = assess_flow.Assess_Five_ID;
            Form_AssessFlow.Kci = assess_flow.Assess_Six_ID;
            Form_AssessFlow.Temp_Vendor_ID = tempVendorID;
            Form_AssessFlow.Factory_Name = factory;


            As_Approve approve = new As_Approve();
            approve.Form_ID = formID;
            approve.Assess_Flag = "0";  //0为未通过
            approve.Assess_Reason = "";
            approve.Assess_Time = DateTime.Now.ToString();
            approve.Temp_Vendor_ID = tempVendorID;
            approve.Factory_Name = factory;

            //添加此表的审批流程到动态写入表
            AssessFlow_BLL.addFormAssessFlow(Form_AssessFlow);

            //TODO 2017-7-6::判断审批顺序，截留越界的批准,预防重复插入，最好先检查是否已经存在
            //添加员工所要审批的表格

            if (Form_AssessFlow.First != "")
            {
                approve.Position_Name = Form_AssessFlow.First;
                AssessFlow_BLL.addApprove(approve);
            }
            if (Form_AssessFlow.Second != "")
            {
                approve.Position_Name = Form_AssessFlow.Second;
                AssessFlow_BLL.addApprove(approve);
            }
            if (Form_AssessFlow.Third != "")
            {
                approve.Position_Name = Form_AssessFlow.Third;
                AssessFlow_BLL.addApprove(approve);
            }
            if (Form_AssessFlow.Four != "")
            {
                approve.Position_Name = Form_AssessFlow.Four;
                AssessFlow_BLL.addApprove(approve);
            }
            if (Form_AssessFlow.Five != "")
            {
                approve.Position_Name = Form_AssessFlow.Five;
                AssessFlow_BLL.addApprove(approve);
            }

            return true;
        }


        public static bool doSuccessApprove(string formID, string tempVendorID, string formTypeID, string positionName)
        {
            int result = isFinalApprove(formID, positionName);

            //KCI最终
            if (result == KCI_FINAL)
            {
                return doKCIApprove(formID, tempVendorID, formTypeID, positionName);
            }//正常最终
            else if (result == NORMAL_FINAL)
            {
                return doFinalApprove(formID, tempVendorID, formTypeID, positionName);
            }
            else//非最终
            {
                if (AssessFlow_BLL.updateApprove(formID, positionName)>0)
                {
                    return true;
                }
            }

            //签名，写入数据库，图片路径
            return false;
        }


        public static int isFinalApprove(string formID,string positionName)
        {
            As_Form_AssessFlow flow = AssessFlow_BLL.getFormAssessFlow(formID);
            List<string> flowSequence = new List<string> { flow.First, flow.Second, flow.Third, flow.Four, flow.Five };

            foreach (string item in flowSequence)
            {
                if (item == "")
                {
                    flowSequence.Remove(item);
                }
            }

            if (positionName.Equals(flowSequence[flowSequence.Count-1]))
            {
                if (flow.Kci == "1")
                {
                    return KCI_FINAL;
                }
                else
                {
                    return NORMAL_FINAL;
                }
            }

            //IEnumerable<string> trueSequence = from str in flowSequence where !str.Equals("") select str ;
            
            return NOT_FINAL;
        }


        /// <summary>
        /// KCI
        /// </summary>
        /// <param name="formID"></param>
        /// <param name="tempVendorID"></param>
        /// <param name="formTypeID"></param>
        /// <param name="positionName"></param>
        public static bool doKCIApprove(string formID,string tempVendorID,string formTypeID,string positionName)
        {
            int rs1 = AssessFlow_BLL.updateApprove(formID, positionName);
            int rs2 = UpdateFlag_BLL.updateFlagWaitKCI(formTypeID, tempVendorID);

            As_KCI_Approval kciApproval = new As_KCI_Approval();
            kciApproval.Form_ID = formID;
            kciApproval.Temp_Vendor_ID = tempVendorID;
            kciApproval.Flag = 0;
            kciApproval.Position_Name = positionName;
            int rs3 = KCIApproval_BLL.addKCIApproval(kciApproval);

            if (rs1 > 0 && rs2 > 0 && rs3>0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 非KCI
        /// </summary>
        /// <param name="formID"></param>
        /// <param name="positionName"></param>
        public static bool doFinalApprove(string formID, string tempVendorID, string formTypeID, string positionName)
        {
            int rs1 = AssessFlow_BLL.updateApprove(formID, positionName);
            int rs2 = UpdateFlag_BLL.updateFlagAsApproved(formTypeID, tempVendorID);

            if (rs1>0 && rs2>0)
            {
                return true;
            }
            return false;
            //TODO::邮件通知
        }

    }
}