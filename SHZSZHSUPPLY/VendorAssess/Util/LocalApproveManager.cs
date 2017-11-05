using AendorAssess;
using BLL;
using BLL.VendorAssess;
using Model;
using MODEL;
using SHZSZHSUPPLY.VendorAssess.Html_Template;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SHZSZHSUPPLY.VendorAssess.Util
{
    public class LocalApproveManager
    {
        public const int NOT_FINAL = 0;
        public const int NORMAL_FINAL = 1;
        public const int KCI_FINAL = 2;

        #region 审批建立
        /// <summary>
        /// 审批建立（非用户部门）
        /// </summary>
        /// <param name="formID"></param>
        /// <param name="FORM_TYPE_ID"></param>
        public static bool doAddApprove(string formID, string FORM_NAME, string FORM_TYPE_ID, string tempVendorID)
        {
            string Form_Type_Name = FORM_NAME;
            string factory = Employee_BLL.getEmployeeFactory(HttpContext.Current.Session["Employee_ID"].ToString());

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
            approve.Temp_Vendor_Name = TempVendor_BLL.getTempVendorName(tempVendorID);
            approve.Factory_Name = factory;
            approve.Form_Type_Name = Form_Type_Name;

            //添加此表的审批流程到动态写入表
            AssessFlow_BLL.addFormAssessFlow(Form_AssessFlow);

            //添加员工所要审批的表格
            if (Form_AssessFlow.First != "")
            {
                approve.User_Department = "NO";
                approve.Position_Name = Form_AssessFlow.First;
                AssessFlow_BLL.addApprove(approve);
            }
            if (Form_AssessFlow.Second != "")
            {
                approve.User_Department = "NO";
                approve.Position_Name = Form_AssessFlow.Second;
                AssessFlow_BLL.addApprove(approve);
            }
            if (Form_AssessFlow.Third != "")
            {
                approve.User_Department = "NO";
                approve.Position_Name = Form_AssessFlow.Third;
                AssessFlow_BLL.addApprove(approve);
            }
            if (Form_AssessFlow.Four != "")
            {
                approve.User_Department = "NO";
                approve.Position_Name = Form_AssessFlow.Four;
                AssessFlow_BLL.addApprove(approve);
            }
            if (Form_AssessFlow.Five != "")
            {
                approve.User_Department = "NO";
                approve.Position_Name = Form_AssessFlow.Five;
                AssessFlow_BLL.addApprove(approve);
            }

            //插入到已提交表
            As_Form form = new As_Form();
            form.Form_ID = formID;
            form.Form_Type_Name = Form_Type_Name;
            form.Form_Type_ID = FORM_TYPE_ID;
            form.Temp_Vendor_Name = TempVendor_BLL.getTempVendorName(tempVendorID);
            form.Form_Path = "";
            form.Temp_Vendor_ID = tempVendorID;
            form.Factory_Name = factory;
            int add = AddForm_BLL.addForm(form);

            //一旦提交就把表As_Vendor_FormType字段FLag置1.
            int updateFlag = UpdateFlag_BLL.updateFlag(FORM_TYPE_ID, tempVendorID);

            //更新session
            HttpContext.Current.Session["tempvendorname"] = form.Temp_Vendor_Name;
            HttpContext.Current.Session["Employee_ID"] = HttpContext.Current.Session["Employee_ID"];

            //写入日志
            LocalLog.writeLog(formID, String.Format("表格提交成功，等待{0}审批    时间：{1}", Form_AssessFlow.First, DateTime.Now),As_Write.FORM_EDIT, tempVendorID);

            //TODO::Async
            As_Approve ap = Approve_BLL.getApproveTop(formID);
            LocalMail.flowToast(ap.Email, ap.Employee_Name, ap.Factory_Name, tempVendorID, TempVendor_BLL.getTempVendorName(tempVendorID), Form_Type_Name, "等待审批", DateTime.Now.ToString(), "表格已提交，请登陆系统进行审批");

            //
 
            //result
            if (updateFlag > 0 && add > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 审批建立（用户部门）
        /// </summary>
        /// <param name="page"></param>
        /// <param name="formID"></param>
        /// <param name="FORM_NAME"></param>
        /// <param name="FORM_TYPE_ID"></param>
        /// <param name="tempVendorID"></param>
        /// <param name="tempVendorName"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public static bool doApproveWithSelection(System.Web.UI.Page page, string formID, string FORM_NAME, string FORM_TYPE_ID, string tempVendorID, string tempVendorName, string factory)
        {
            Dictionary<string, string> dc = new Dictionary<string, string>();
            dc.Add("FormID", formID);
            dc.Add("FormName", FORM_NAME);
            dc.Add("FormTypeID", FORM_TYPE_ID);
            dc.Add("TempVendorID", tempVendorID);
            dc.Add("TempVendorName", tempVendorName);
            dc.Add("Factory", factory);
            SelectDepartment.paramInfo = dc;
            SelectDepartment.originPage = page;

            //形成参数
            As_Assess_Flow assess_flow = AssessFlow_BLL.getFirstAssessFlow(FORM_TYPE_ID);

            //写入session之后供SelectDepartment页面使用
            HttpContext.Current.Session["AssessflowInfo"] = assess_flow;
            HttpContext.Current.Session["tempVendorID"] = tempVendorID;
            HttpContext.Current.Session["Factory_Name"] = Employee_BLL.getEmployeeFactory(HttpContext.Current.Session["Employee_ID"].ToString());
            HttpContext.Current.Session["form_name"] = FORM_NAME;
            HttpContext.Current.Session["tempVendorName"] = tempVendorName;

            //如果是用户部门
            if (assess_flow.User_Department_Assess == "1")
            {
                LocalScriptManager.CreateScript(page, "popUp('" + formID + "');", "SHOW");
            }
            else
            {
                //TODO::这里不能这样写，具体参考Creation的写法，这里暂时不改
                HttpContext.Current.Session["tempvendorname"] = tempVendorName;
                HttpContext.Current.Session["Employee_ID"] = HttpContext.Current.Session["Employee_ID"];
                HttpContext.Current.Response.Write("<script>window.alert('提交成功！');window.location.href='/VendorAssess/EmployeeVendor.aspx'</script>");
            }

            return true;
        }

        /// <summary>
        /// 提交表格（用户部门）
        /// </summary>
        /// <returns></returns>
        internal static bool submitForm()
        {
            //读取session
            //getSessionInfo();

            SelectDepartment.doSelect();
            Dictionary<string, string> dc = SelectDepartment.paramInfo;

            //插入到已提交表
            As_Form form = new As_Form();
            form.Form_ID = dc["FormID"];
            form.Form_Type_Name = dc["FormName"];
            form.Form_Type_ID = dc["FormTypeID"];
            form.Temp_Vendor_Name = dc["TempVendorName"];
            form.Form_Path = "";
            form.Temp_Vendor_ID = dc["TempVendorID"];
            form.Factory_Name = dc["Factory"];
            int add = AddForm_BLL.addForm(form);

            //一旦提交就把表As_Vendor_FormType字段FLag置1.
            int updateFlag = UpdateFlag_BLL.updateFlag(dc["FormTypeID"], dc["TempVendorID"]);

            //写入日志
            LocalLog.writeLog(form.Form_ID, String.Format("表格提交成功，等待{0}审批    时间：{1}", SelectDepartment.Form_AssessFlow.First, DateTime.Now), As_Write.FORM_EDIT, form.Temp_Vendor_ID);

            //TODO::Async
            As_Approve ap = Approve_BLL.getApproveTop(form.Form_ID);
            LocalMail.flowToast(ap.Email, ap.Employee_Name, ap.Factory_Name, form.Temp_Vendor_ID, TempVendor_BLL.getTempVendorName(form.Temp_Vendor_ID), form.Form_Type_Name, "等待审批", DateTime.Now.ToString(), "表格已提交，请登陆系统进行审批");

            LocalScriptManager.CreateScript(SelectDepartment.originPage, "message('提示测试')", "redirectpage1");

            //LocalScriptManager.CreateScript(SelectDepartment.originPage, String.Format("messageFunc('{0}', {1})","表格已成功提交", "function () {window.location.href='/VendorAssess/EmployeeVendor.aspx;}"), "redirectpage");
            HttpContext.Current.Response.Redirect("/VendorAssess/EmployeeVendor.aspx");
            return true;
        }
        #endregion

        #region 审批
        /// <summary>
        /// 做成功审批
        /// </summary>
        /// <param name="formID"></param>
        /// <param name="tempVendorID"></param>
        /// <param name="formTypeID"></param>
        /// <param name="positionName"></param>
        /// <returns></returns>
        public static bool doSuccessApprove(string formID, string tempVendorID, string formTypeID, string positionName, System.Web.UI.Page page)
        {
            int result = isFinalApprove(formID, positionName);

            //日志参数
            As_Employee ae = Employee_BLL.getEmolyeeById(HttpContext.Current.Session["Employee_ID"].ToString());

            //最终  即将进行KCI
            if (result == KCI_FINAL)
            {
                Signature_BLL.setSignature(formID, positionName);//签名
                Signature_BLL.setSignatureDate(formID, positionName);

                //PDF
                outPutPDF(formID,tempVendorID);

                return doKCIApprove(formID, tempVendorID, formTypeID, positionName, page);
            }//正常最终
            else if (result == NORMAL_FINAL)//签名
            {
                Signature_BLL.setSignature(formID, positionName);//签名
                Signature_BLL.setSignatureDate(formID, positionName);

                //PDF
                outPutPDF(formID,tempVendorID);

                return doFinalApprove(formID, tempVendorID, formTypeID, positionName, page);
            }
            else//非最终  签名
            {
                //第一个是用户部门
                As_Approve ap = Approve_BLL.getApproveTop(formID);

                if (ap.User_Department == "YES")//用户部门的审批签名
                {
                    Signature_BLL.setSignature(formID, positionName, "User_Department_Manager");
                    Signature_BLL.setUserDepartmentSignatureDate(formID, "User_Department_Manager_Date");
                    if (AssessFlow_BLL.updateUserDepartmentApprove(formID, positionName) > 0)
                    {
                        ap = Approve_BLL.getApproveTop(formID);

                        LocalLog.writeLog(formID, String.Format("{0}审批已通过，正在等待{1}审批    时间：{2}", ae.Positon_Name + ae.Employee_Name, ap.Position_Name, DateTime.Now), As_Write.APPROVE_SUCCESS, tempVendorID);

                        //TODO::Async
                        LocalMail.flowToast(ap.Email, ap.Employee_Name, ap.Factory_Name, tempVendorID, TempVendor_BLL.getTempVendorName(tempVendorID), ap.Form_Type_Name, "等待审批", DateTime.Now.ToString(), "表格已提交，请登陆系统进行审批");

                        //提示并拉起返回刷新
                        LocalScriptManager.CreateScript(page, String.Format("messageFunc('{0}',{1})", "审批成功", "function(){document.location.href = document.URL;}"), "toast");

                        //true结果返回后暂时无作用——2017年9月9日13:37:57
                        return true;
                    }
                }
                else
                {
                    //进行签名处理
                    if (Signature_BLL.setSignature(formID, positionName) && Signature_BLL.setSignatureDate(formID, positionName) != -1)
                    {
                        if (AssessFlow_BLL.updateApprove(formID, positionName) > 0)
                        {
                            ap = Approve_BLL.getApproveTop(formID);
                            LocalLog.writeLog(formID, String.Format("{0}审批已通过，正在等待{1}审批    时间：{2}", ae.Positon_Name + ae.Employee_Name, ap.Position_Name, DateTime.Now), As_Write.APPROVE_SUCCESS, tempVendorID);

                            //TODO::Async
                            LocalMail.flowToast(ap.Email, ap.Employee_Name, ap.Factory_Name, tempVendorID, TempVendor_BLL.getTempVendorName(tempVendorID), ap.Form_Type_Name, "等待审批", DateTime.Now.ToString(), "表格已提交，请登陆系统进行审批");

                            //提示并拉起返回刷新
                            LocalScriptManager.CreateScript(page, String.Format("messageFunc('{0}',{1})", "审批成功", "function(){document.location.href = document.URL;}"), "toast");

                            //true结果返回后暂时无作用——2017年9月9日13:37:57
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public static void outPutPDF(string formID,string tempVendorID)
        {
            try
            {
                string url = HttpContext.Current.Request.Url.ToString()+"&outPutID="+formID;
                string pdf = Properties.Settings.Default.PDF_Tool_Path;

                string fileTypeName = FormType_BLL.getFormNameByFormID(formID);
                string factory = AddForm_BLL.getFactoryByFormID(formID);
                string file = HttpContext.Current.Server.MapPath(LSetting.File_Path)+File_BLL.generateFileID(tempVendorID, fileTypeName, factory) + ".pdf";

                Process p = Process.Start(pdf, url + " \"" + file + "\"");
                p.WaitForExit();

                As_Form form = new As_Form();
                form.Form_ID = formID;
                form.Form_Path = file;
                int result = AddForm_BLL.upDateFormPath(formID, file);
                if (result <= 0)
                {
                    throw new Exception("数据库更新失败");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// 判断是否为最后审批人
        /// </summary>
        /// <param name="formID"></param>
        /// <param name="positionName"></param>
        /// <returns></returns>
        public static int isFinalApprove(string formID, string positionName)
        {
            As_Form_AssessFlow flow = AssessFlow_BLL.getFormAssessFlow(formID);
            List<string> flowSequence = new List<string> { flow.First, flow.Second, flow.Third, flow.Four, flow.Five };
            List<string> flowSequences = new List<string>();
            for (int i = 0; i < flowSequence.Count; i++)
            {
                if (flowSequence[i] != "")
                {
                    flowSequences.Add(flowSequence[i]);
                }
            }
            //判断该职位未审批 user_DepartMent为yes  防止用户部门选择最后一个人 被判断为最后一个人审批
            //当第一个人审批的时候用户部门的Asscess_Flag 为0 存在直接返回 NOT_FINAL  不存在再走下面的

            if (userDepartMentAsLastOne(formID, positionName))//
            {
                return NOT_FINAL;
            }
            if (positionName.Equals(flowSequences[flowSequences.Count - 1]))
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
        /// 判断用户部门选择的是否是最后一个审批人
        /// </summary>
        /// <param name="formID"></param>
        /// <param name="positionName"></param>
        /// <returns></returns>
        private static bool userDepartMentAsLastOne(string formID, string positionName)
        {
            return Approve_BLL.userDepartMentAsLastOne(formID, positionName);
        }

        /// <summary>
        /// KCI
        /// </summary>
        /// <param name="formID"></param>
        /// <param name="tempVendorID"></param>
        /// <param name="formTypeID"></param>
        /// <param name="positionName"></param>
        public static bool doKCIApprove(string formID, string tempVendorID, string formTypeID, string positionName, System.Web.UI.Page page)
        {
            int rs1 = AssessFlow_BLL.updateApprove(formID, positionName);
            int rs2 = UpdateFlag_BLL.updateFlagWaitKCI(formTypeID, tempVendorID);

            //添加KCI审批
            As_KCI_Approval kciApproval = new As_KCI_Approval();
            kciApproval.Form_ID = formID;
            kciApproval.Temp_Vendor_ID = tempVendorID;
            kciApproval.Flag = 0;
            kciApproval.Position_Name = "采购部经理";
            kciApproval.Temp_Vendor_Name = TempVendor_BLL.getTempVendorName(tempVendorID);
            kciApproval.Form_Type_Name = FormType_BLL.getFormNameByTypeID(formTypeID);
            int rs3 = KCIApproval_BLL.addKCIApproval(kciApproval);

            //判断结果
            if (rs1 > 0 && rs2 > 0 && rs3 > 0)
            {
                //日志
                LocalLog.writeLog(formID, String.Format("系统内部审批完成,KCI审批已添加，正在等待KCI审批结果    时间：{0}", DateTime.Now), As_Write.APPROVE_SUCCESS, tempVendorID);

                //邮件通知
                As_Employee ae = Employee_BLL.getEmolyeeById(AddEmployeeVendor_BLL.getEmployeeID(tempVendorID));
                LocalMail.backToast(ae.Employee_Email, ae.Employee_Name, ae.Factory_Name, tempVendorID, TempVendor_BLL.getTempVendorName(tempVendorID), FormType_BLL.getFormNameByTypeID(formTypeID), "等待审批", DateTime.Now.ToString(), "系统内部审批已完成，正在等待KCI审批结果，请获取KCI审批结果后登录系统更新KCI审批信息");

                //提示，并生成文件，写入系统，返回刷新
                string fileTypeName = FormType_BLL.getFormNameByFormID(formID);
                string factory = AddForm_BLL.getFactoryByFormID(formID);
                string file = File_BLL.generateFileID(tempVendorID, fileTypeName, factory) + ".pdf";
                LocalScriptManager.CreateScript(page, String.Format("messageFunc('{0}',{1})", "审批成功", "function(){document.location.href = document.URL;}"), "testid");

                //返回
                return true;
            }
            return false;
        }

        /// <summary>
        /// 非KCI
        /// </summary>
        /// <param name="formID"></param>
        /// <param name="positionName"></param>
        public static bool doFinalApprove(string formID, string tempVendorID, string formTypeID, string positionName,System.Web.UI.Page page)
        {
            int rs1 = AssessFlow_BLL.updateApprove(formID, positionName);
            int rs2 = UpdateFlag_BLL.updateFlagAsApproved(formTypeID, tempVendorID);
            int rs3 = 1;//之所以为1 是为了在times=0的时候不会造成任何影响
            bool isFormOverDue = false;
            isFormOverDue = FormOverDue_BLL.isOverDue(formID);
            if (isFormOverDue)//属于过期表   需要把重新审批的表的标签 改成已通过
            {
                string oldFormID = FormOverDue_BLL.getOldFormID(formID);//对于已经在重新审批中的表 oldFormID 在As_Vendor_FormType_History一定存在 在过期表中也一定存在
                rs3 = UpdateFlag_BLL.updateReAccessFormStatus(oldFormID, tempVendorID);//成功返回2 失败返回-1
                //首先属于表过期才存在文件过期引起的可能
                //bool isFileOverDue = false;
                //isFileOverDue = FileOverDue_BLL.isFileOverDue(formID);
                //if (isFileOverDue)
                //{
                //    bool ok = true;
                //    List<string> fileIDs = new List<string>();//过期文件集合
                //    List<string> formIDs = new List<string>();//每一个过期文件对应的所有表的集合
                //    fileIDs = FileOverDue_BLL.getFileIDsByFormID(formID);
                //    if (fileIDs.Count > 0)
                //    {
                //        //获取所有与该表绑定的文件 查出每一个文件绑定了那些表 如果某一个表绑定的文件都已经审批过了 更新文件过期审批标志
                //        foreach (string fileID in fileIDs)
                //        {
                //            //查出所有与该文件绑定的表的Form_ID
                //            formIDs = FileOverDue_BLL.getRelativeFormByFile(fileID);
                //            //判断是否所有的表都已经过审
                //            if (formIDs.Count > 0)
                //            {
                //                foreach (string form in formIDs)
                //                {
                //                    if (FillVendorInfo_BLL.isAccessSuccessful(form) == false)
                //                    {
                //                        //更新过期重新审批后的标志
                //                        ok = false;
                //                    }
                //                }
                //                if (ok)//所有的表都已经审批完成
                //                {
                //                    UpdateFlag_BLL.updateReAccessFileStatus(fileID);
                //                }
                //            }
                //        }
                //    }
                //}
            }
            if (rs1 > 0 && rs2 > 0 && rs3 > 0)
            {
                //日志
                LocalLog.writeLog(formID, String.Format("系统内部审批完成,表格审批完成    时间：{0}", DateTime.Now), As_Write.APPROVE_SUCCESS, tempVendorID);

                //邮件通知
                As_Employee ae = Employee_BLL.getEmolyeeById(AddEmployeeVendor_BLL.getEmployeeID(tempVendorID));
                LocalMail.backToast(ae.Employee_Email, ae.Employee_Name, ae.Factory_Name, tempVendorID, TempVendor_BLL.getTempVendorName(tempVendorID), FormType_BLL.getFormNameByTypeID(formTypeID), "审批完成", DateTime.Now.ToString(), "系统内部审批完成,表格审批完成");

                //提示
                string fileTypeName = FormType_BLL.getFormNameByFormID(formID);
                string factory = AddForm_BLL.getFactoryByFormID(formID);
                string file = File_BLL.generateFileID(tempVendorID, fileTypeName, factory) + ".pdf";
                LocalScriptManager.CreateScript(page, String.Format("messageFunc('{0}',{1})", "审批成功", "function(){document.location.href = document.URL;}"), "testid");

                //返回
                return true;
            }
            return false;
        }
        #endregion

        #region 状态回滚
        /// <summary>
        /// 表格审批未通过，状态回滚
        /// </summary>
        /// <returns></returns>
        public static bool resetFormStatus(string formID, string formTypeID, string tempVendorID)
        {
            return Approve_BLL.resetFormStatus(formID, formTypeID, tempVendorID);
        }
        #endregion
    }
}
