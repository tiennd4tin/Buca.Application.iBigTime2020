using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Cash;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Deposit;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Voucher;
using BuCA.Application.iBigTime2020.Session;
using DevExpress.XtraEditors;
using RSSHelper;
using Ionic.Zip;
using Microsoft.SqlServer.Management.Smo;

namespace BuCA.Application.iBigTime2020.Report.ReportClass
{
    public class ExportXML : BaseReport
    {

        public ExportXML()
        {
            Model = new Model();
        }
        /// <summary>
        /// C4-02a/KB - Ủy nhiệm chi chuyển khoản, chuyển tiền điện tử
        /// </summary>
        /// <param name="reportParameter"></param>
        /// <param name="oRsTool"></param>
        /// <returns></returns>
        public IList<C402CKBModel> ReportC402AKBXML(ReportParameter reportParameter, ReportSharpHelper oRsTool, List<C402CKBModel> result = null, bool isParamater = false)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult results = DialogResult.Cancel;
                if (string.IsNullOrEmpty(GlobalVariable.PathXML))
                    results = fbd.ShowDialog();
                else
                { fbd.SelectedPath = GlobalVariable.PathXML; results = DialogResult.OK; }
                if (result == null && !isParamater)
                {
                    //var storeProcedure = "uspReport_BAV_Withdraw_TT08_C402";
                    var storeProcedure = reportParameter.RefType.Equals(157) ? "uspReport_BAV_Withdraw_TT08_C402" : "uspReport_BAV_Withdraw_TT08_C402_158";
                    result = Model.ReportC402CKB(storeProcedure, reportParameter.RefId).ToList();
                }
                if (result.Count <= 0)
                {
                    XtraMessageBox.Show("Dữ liệu báo cáo không có bản ghi nào!", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return null;
                }
                if (results == DialogResult.OK && !string.IsNullOrEmpty(fbd.SelectedPath))
                {
                    GlobalVariable.PathXML = string.IsNullOrEmpty(GlobalVariable.PathXML)
                        ? fbd.SelectedPath
                        : GlobalVariable.PathXML;
                    #region Dữ liệu xml

                    string reportName = "C402A";
                    string fileName = result[0].RefNo;
                    string savepath = reportName + fileName + @".xml";
                    Cursor.Current = Cursors.WaitCursor;
                    XmlTextWriter writer = new XmlTextWriter(savepath,
                        Encoding.UTF8);
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();

                    writer.WriteStartElement("java");
                    writer.WriteAttributeString("version", "1.7.0_17");
                    writer.WriteAttributeString("class", "java.beans.XMLDecoder");

                    writer.WriteStartElement("object");
                    writer.WriteAttributeString("class", "dvc.service.custom.TemplateChungTu");

                    writer.WriteStartElement("void");
                    writer.WriteAttributeString("property", "dmDvTratien");
                    writer.WriteStartElement("string");
                    writer.WriteString(GlobalVariable.CompanyCode);
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dmTiente"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString(result[0].CurencyCode); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvNhantienCtmt"); //Field name
                    writer.WriteEndElement(); //End void
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvNhantienDiachi"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString(result[0].AccountingObjectAddress); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvNhantienKbnn"); //Field name
                    writer.WriteEndElement(); //End void
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvNhantienKbnnNhTen"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString(result[0].ReceiptAccountInBank); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvNhantienLoai"); //Field name
                    writer.WriteStartElement("long"); //Start string
                    writer.WriteValue((long)0); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvNhantienMa"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString(result[0].BudgetCode); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvNhantienSotien"); //Field name
                    writer.WriteStartElement("double"); //Start string
                    writer.WriteValue((double)0); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvNhantienSotkSo"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString(result[0].AccountingObjectBankAccount); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvNhantienTen"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString(result[0].ReceiptObjectName); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvTratienCtmt"); //Field name
                    writer.WriteEndElement(); //End void
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvTratienDiachi"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString(GlobalVariable.CompanyAddress); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvTratienKbnn"); //Field name
                    writer.WriteEndElement(); //End void
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvTratienKbnnNhTen"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString(result[0].BankAccount); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvTratienLoai"); //Field name
                    writer.WriteStartElement("long"); //Start string
                    writer.WriteValue((long)(result[0].IsOpenInBank ? 0 : 1)); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvTratienMa"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString(GlobalVariable.CompanyCode); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvTratienTen"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString(GlobalVariable.CompanyName); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void


                    writer.WriteStartElement("void");
                    writer.WriteAttributeString("property", "gnHosoC402GtByGnHosoC402");

                    writer.WriteStartElement("object");
                    writer.WriteAttributeString("class", "java.util.ArrayList");

                    //Detail
                    var detaillist = Model.GetBAWithDraw(result[0].RefId, true, true, true, true, true);
                    var count = detaillist.BAWithDrawDetails.Count;
                    for (int i = 0; i < count; i++)
                    {
                        writer.WriteStartElement("void");
                        writer.WriteAttributeString("method", "add");
                        writer.WriteStartElement("object");
                        writer.WriteAttributeString("class", "dvc.service.custom.TemplateChungTuGt");

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "maHang"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString((i + 1).ToString()); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void
                                                  //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "noiDung"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(detaillist.BAWithDrawDetails[i].Description); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void
                                                  //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "nopThue"); //Field name
                        writer.WriteStartElement("double"); //Start string
                        writer.WriteValue((double)0); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void
                                                  //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "soTien"); //Field name
                        writer.WriteStartElement("double"); //Start string
                        writer.WriteValue((double)detaillist.BAWithDrawDetails[i].Amount); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void
                                                  //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "thanhToan"); //Field name
                        writer.WriteStartElement("double"); //Start string
                        writer.WriteValue((double)detaillist.BAWithDrawDetails[i].Amount); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void


                        writer.WriteEndElement(); // dvc.service.custom.TemplateChungTuGt
                        writer.WriteEndElement(); // Add
                    }
                    writer.WriteEndElement(); // arrayList
                    writer.WriteEndElement(); // gnHosoC202GtByGnHosoC202

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "gnTaiLieuId"); //Field name
                    writer.WriteStartElement("long"); //Start string
                    writer.WriteValue((long)425); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void");
                    writer.WriteAttributeString("property", "ngayChungTu");
                    writer.WriteStartElement("object");
                    writer.WriteAttributeString("class", "java.sql.Timestamp");
                    writer.WriteStartElement("long");
                    writer.WriteValue((long)(result[0].RefDate
                        .ToUniversalTime()
                        .Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds));
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndElement(); // ngayChungtu

                    //New field
                    writer.WriteStartElement("void");
                    writer.WriteAttributeString("property", "par1");
                    writer.WriteStartElement("string");
                    writer.WriteString(RSSHelper.NumberToWord.Read(result[0].Amount, "đồng", "", "#.0000"));
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "soChungTu"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString(result[0].RefNo); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "tongSoTien"); //Field name
                    writer.WriteStartElement("double"); //Start string
                    writer.WriteValue((double)result[0].Amount); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "typeChungTu"); //Field name
                    writer.WriteStartElement("long"); //Start string
                    writer.WriteValue(13);//(long)result[0].RefType); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    writer.WriteEndElement(); //dvc.service.custom.TemplateChungTu
                    writer.WriteEndElement(); //java

                    writer.WriteEndDocument();
                    writer.Close();

                    if (CreateZip(fileName, fbd.SelectedPath, reportName))
                        XtraMessageBox.Show("Xuất Xml thành công", "Thông báo");
                    else
                        XtraMessageBox.Show("Xuất Xml không thành công", "Thông báo");

                    result = null;

                    #endregion
                }
            }
            return null;
        }


        /// <summary>
        /// C4-02b/KB - Ủy nhiệm chi chuyển khoản, chuyển tiền điện tử
        /// </summary>
        /// <param name="reportParameter"></param>
        /// <param name="oRsTool"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public IList<C402CKBModel> ReportC402BKBXML(ReportParameter reportParameter, ReportSharpHelper oRsTool, List<C402CKBModel> result = null, bool isParamater = false)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult results = DialogResult.Cancel;
                if (string.IsNullOrEmpty(GlobalVariable.PathXML))
                    results = fbd.ShowDialog();
                else
                { fbd.SelectedPath = GlobalVariable.PathXML; results = DialogResult.OK; }
                if (result == null && !isParamater)
                {
                    var storeProcedure = "uspReport_BAV_Withdraw_TT08_C402";
                    result = Model.ReportC402CKB(storeProcedure, reportParameter.RefId).ToList();
                }
                if (result.Count <= 0)
                {
                    XtraMessageBox.Show("Dữ liệu báo cáo không có bản ghi nào!", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return null;
                }

                if (results == DialogResult.OK && !string.IsNullOrEmpty(fbd.SelectedPath))
                {
                    GlobalVariable.PathXML = string.IsNullOrEmpty(GlobalVariable.PathXML)
                        ? fbd.SelectedPath
                        : GlobalVariable.PathXML;
                    #region Dữ liệu xml

                    string reportName = "C402B";
                    string fileName = result[0].RefNo;
                    string savepath = reportName + fileName + @".xml";
                    Cursor.Current = Cursors.WaitCursor;
                    XmlTextWriter writer = new XmlTextWriter(savepath,
                        Encoding.UTF8);
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();

                    writer.WriteStartElement("java");
                    writer.WriteAttributeString("version", "1.7.0_17");
                    writer.WriteAttributeString("class", "java.beans.XMLDecoder");

                    writer.WriteStartElement("object");
                    writer.WriteAttributeString("class", "dvc.service.custom.TemplateChungTu");

                    writer.WriteStartElement("void");
                    writer.WriteAttributeString("property", "dmDvTratien");
                    writer.WriteStartElement("string");
                    writer.WriteString(GlobalVariable.CompanyCode);
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dmTiente"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString(result[0].CurencyCode); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvNhantienCtmt"); //Field name
                    writer.WriteEndElement(); //End void
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvNhantienDiachi"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString(result[0].AccountingObjectAddress); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvNhantienKbnnNhTen"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString(result[0].ReceiptAccountInBank); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvNhantienLoai"); //Field name
                    writer.WriteStartElement("long"); //Start string
                    writer.WriteValue((long)0); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvNhantienMa"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString(result[0].BudgetCode); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvNhantienNganhang"); //Field name
                    writer.WriteEndElement(); //End void
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvNhantienSotkSo"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString(result[0].AccountingObjectBankAccount); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvNhantienTen"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString(result[0].ReceiptObjectName); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvTratienCtmt"); //Field name
                    writer.WriteEndElement(); //End void
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvTratienDiachi"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString(GlobalVariable.CompanyAddress); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvTratienKbnn"); //Field name
                    writer.WriteEndElement(); //End void
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvTratienKbnnNhTen"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString(result[0].BankAccount); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvTratienLoai"); //Field name
                    writer.WriteStartElement("long"); //Start string
                    writer.WriteValue((long)(result[0].IsOpenInBank ? 0 : 1)); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvTratienMa"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString(GlobalVariable.CompanyCode); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvTratienTen"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString(GlobalVariable.CompanyName); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void


                    writer.WriteStartElement("void");
                    writer.WriteAttributeString("property", "gnHosoC402GtByGnHosoC402");

                    writer.WriteStartElement("object");
                    writer.WriteAttributeString("class", "java.util.ArrayList");

                    //Detail
                    var detaillist = Model.GetBAWithDraw(result[0].RefId, true, true, true, true, true);
                    var count = result.Count;// detaillist.BAWithDrawDetails.Count;
                    for (int i = 0; i < count; i++)
                    {
                        writer.WriteStartElement("void");
                        writer.WriteAttributeString("method", "add");
                        writer.WriteStartElement("object");
                        writer.WriteAttributeString("class", "dvc.service.custom.TemplateChungTuGt");

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "maHang"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString((i + 1).ToString()); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void
                                                  //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "noiDung"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(result.Count == 1? result[0].Description: detaillist.BAWithDrawDetails[i].Description); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void
                                                  //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "nopThue"); //Field name
                        writer.WriteStartElement("double"); //Start string
                        writer.WriteValue(result.Count == 1 ? (double)result.Sum(x => x.Tax) : (double)result[i].Tax); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void
                                                  //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "soTien"); //Field name
                        writer.WriteStartElement("double"); //Start string
                        writer.WriteValue(result.Count == 1 ? (double) detaillist.BAWithDrawDetails.Sum(x => x.Amount): (double)detaillist.BAWithDrawDetails[i].Amount); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void
                                                  //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "soTienNguyenTe"); //Field name
                        writer.WriteStartElement("double"); //Start string
                        writer.WriteValue(result.Count == 1 ? (double)detaillist.BAWithDrawDetails.Sum(x => x.AmountOC) : (double)detaillist.BAWithDrawDetails[i].AmountOC); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void
                                                  //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "thanhToan"); //Field name
                        writer.WriteStartElement("double"); //Start string
                        writer.WriteValue(result.Count == 1 ? (double)detaillist.BAWithDrawDetails.Sum(x => x.Amount) : (double)detaillist.BAWithDrawDetails[i].Amount); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void


                        writer.WriteEndElement(); // dvc.service.custom.TemplateChungTuGt
                        writer.WriteEndElement(); // Add
                    }
                    writer.WriteEndElement(); // arrayList
                    writer.WriteEndElement(); // gnHosoC202GtByGnHosoC202

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "gnTaiLieuId"); //Field name
                    writer.WriteStartElement("long"); //Start string
                    writer.WriteValue((long)420); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void");
                    writer.WriteAttributeString("property", "ngayChungTu");
                    writer.WriteStartElement("object");
                    writer.WriteAttributeString("class", "java.sql.Timestamp");
                    writer.WriteStartElement("long");
                    writer.WriteValue((long)(result[0].RefDate
                        .ToUniversalTime()
                        .Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds));
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndElement(); // ngayChungtu

                    //New field
                    writer.WriteStartElement("void");
                    writer.WriteAttributeString("property", "par1");
                    writer.WriteStartElement("string");
                    writer.WriteString(RSSHelper.NumberToWord.Read(result.Sum(x=> x.Amount), "đồng", "", "#.0000"));
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "par3"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString("0"); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "par4"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString(result.Sum(x => x.Amount).ToString()); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "soChungTu"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString(result[0].RefNo); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "tongSoTien"); //Field name
                    writer.WriteStartElement("double"); //Start string
                    writer.WriteValue((double)result.Sum(x => x.Amount)); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "typeChungTu"); //Field name
                    writer.WriteStartElement("long"); //Start string
                    writer.WriteValue(13);//(long)result[0].RefType); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    writer.WriteEndElement(); //dvc.service.custom.TemplateChungTu
                    writer.WriteEndElement(); //java

                    writer.WriteEndDocument();
                    writer.Close();
                    if (CreateZip(fileName, fbd.SelectedPath, reportName))
                        XtraMessageBox.Show("Xuất Xml thành công", "Thông báo");
                    else
                        XtraMessageBox.Show("Xuất Xml không thành công", "Thông báo");

                    result = null;

                    #endregion
                }
            }
            return null;
        }
        /// <summary>
        /// C4-09/KB – Giấy rút tiền mặt
        /// </summary>
        /// <param name="reportParameter"></param>
        /// <param name="oRsTool"></param>
        /// <returns></returns>
        public IList<C4_09Model> ReportCAReceipt_C4_09XML(ReportParameter reportParameter, ReportSharpHelper oRsTool, List<C4_09Model> result = null, bool isParamater = false)
        {
            try
            {
                IList<C4_09Model> list = null;
                GlobalVariable.IsDisplayNewLicenseInfo = false;
                list = Model.ReportCAReceipt_C4_09(reportParameter.RefId, (Enum.RefType)reportParameter.RefType);

                if (list.Count <= 0)
                {
                    XtraMessageBox.Show("Dữ liệu báo cáo không có bản ghi nào!", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return null;
                }
                int isshowdetail = 1;
                int isshowdate = 1;
                string accountdebit = "", accountcredit = "";
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult results = DialogResult.Cancel;
                    if (string.IsNullOrEmpty(GlobalVariable.PathXML))
                        results = fbd.ShowDialog();
                    else
                    { fbd.SelectedPath = GlobalVariable.PathXML; results = DialogResult.OK; }
                    if (results == DialogResult.OK && !string.IsNullOrEmpty(fbd.SelectedPath))
                    {
                        GlobalVariable.PathXML = string.IsNullOrEmpty(GlobalVariable.PathXML)
                            ? fbd.SelectedPath
                            : GlobalVariable.PathXML;
                        #region Dữ liệu xml

                        string reportName = "C409";
                        string fileName = list[0].RefNo;
                        string savepath = reportName + fileName + @".xml";
                        Cursor.Current = Cursors.WaitCursor;
                        XmlTextWriter writer = new XmlTextWriter(savepath,
                            Encoding.UTF8);
                        writer.Formatting = Formatting.Indented;
                        writer.WriteStartDocument();

                        writer.WriteStartElement("java");
                        writer.WriteAttributeString("version", "1.7.0_17");
                        writer.WriteAttributeString("class", "java.beans.XMLDecoder");

                        writer.WriteStartElement("object");
                        writer.WriteAttributeString("class", "dvc.service.custom.TemplateChungTu");

                        writer.WriteStartElement("void");
                        writer.WriteAttributeString("property", "diaChi");
                        writer.WriteStartElement("string");
                        writer.WriteString(GlobalVariable.CompanyAddress);
                        writer.WriteEndElement();
                        writer.WriteEndElement();

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dvqhnsMa"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(GlobalVariable.CompanyCode); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dmTiente"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(list[0].CurrencyCode); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dvqhnsTen"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(GlobalVariable.CompanyName); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        writer.WriteStartElement("void");
                        writer.WriteAttributeString("property", "gnHosoC409GtByGnHosoC409");

                        writer.WriteStartElement("object");
                        writer.WriteAttributeString("class", "java.util.ArrayList");

                        ////Detail
                        var detaillist = Model.GetReceiptVoucher(list[0].RefId, true, true);
                        var count = detaillist.CAReceiptDetails.Count;

                        for (int i = 0; i < count; i++)
                        {
                            writer.WriteStartElement("void");
                            writer.WriteAttributeString("method", "add");
                            writer.WriteStartElement("object");
                            writer.WriteAttributeString("class", "dvc.service.custom.TemplateChungTuGt");

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "maHang"); //Field name
                            writer.WriteStartElement("string"); //Start string
                            writer.WriteString((i + 1).ToString()); //Values
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "noiDung"); //Field name
                            writer.WriteStartElement("string"); //Start string
                            writer.WriteString(detaillist.CAReceiptDetails[i].Description); //Values
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "soTien"); //Field name
                            writer.WriteStartElement("double"); //Start string
                            writer.WriteValue((double)detaillist.CAReceiptDetails[i].Amount); //Values
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void

                            //End add
                            writer.WriteEndElement();
                            writer.WriteEndElement();
                        }
                        //End add
                        writer.WriteEndElement();
                        writer.WriteEndElement();

                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "gnTaiLieuId"); //Field name
                        writer.WriteStartElement("long"); //Start string
                        writer.WriteValue((long)320); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void
                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "nguoilinhHoten"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteValue(list[0].AccountingObjectName); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void
                        
                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "nguoilinhNgaycapCmnd"); //Field name
                        if (list[0].IssueDate != null)
                        {
                            writer.WriteStartElement("object");
                            writer.WriteAttributeString("class", "java.sql.Timestamp");
                            writer.WriteStartElement("long");
                            writer.WriteValue((long) (Convert.ToDateTime(list[0].IssueDate)
                                .ToUniversalTime()
                                .Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds));
                            writer.WriteEndElement();
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "nguoilinhNoicapCmnd"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteValue(list[0].IssueBy); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void
                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "nguoilinhSoCmnd"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteValue(list[0].IdentificationNumber); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void");
                        writer.WriteAttributeString("property", "par1");
                        writer.WriteStartElement("string");
                        writer.WriteString(RSSHelper.NumberToWord.Read(list[0].TotalAmount, "đồng", "", "#.0000"));
                        writer.WriteEndElement();
                        writer.WriteEndElement();

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "soChungTu"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(list[0].RefNo); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "tongSoTien"); //Field name
                        writer.WriteStartElement("double"); //Start string
                        writer.WriteValue((double)list[0].TotalAmount); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "typeChungTu"); //Field name
                        writer.WriteStartElement("long"); //Start string
                        writer.WriteValue(16); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        writer.WriteEndElement(); //dvc.service.custom.TemplateChungTu
                        writer.WriteEndElement(); //java

                        writer.WriteEndDocument();
                        writer.Close();
                        if (CreateZip(fileName, fbd.SelectedPath, reportName))
                            XtraMessageBox.Show("Xuất Xml thành công", "Thông báo");
                        else
                            XtraMessageBox.Show("Xuất Xml không thành công", "Thông báo");

                        //result = null;

                        #endregion
                    }
                }
                return null;
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi ở chỗ này " + ex.InnerException + ex.Message + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// C2-03/NS - Giấy đề nghị thanh toán tạm ứng ứng trước
        /// </summary>
        /// <param name="reportParameter"></param>
        /// <param name="oRsTool"></param>
        /// <param name="result"></param>
        public IList<C203NSModel> ReportC203NSTT77XML(ReportParameter reportParameter, List<C203NSModel> result = null, bool isParamater = false)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult results = DialogResult.Cancel;
                if (string.IsNullOrEmpty(GlobalVariable.PathXML))
                    results = fbd.ShowDialog();
                else
                { fbd.SelectedPath = GlobalVariable.PathXML; results = DialogResult.OK; }
                if (result == null && isParamater) return null;
                if (results == DialogResult.OK && !string.IsNullOrEmpty(fbd.SelectedPath))
                {
                    GlobalVariable.PathXML = string.IsNullOrEmpty(GlobalVariable.PathXML)
                        ? fbd.SelectedPath
                        : GlobalVariable.PathXML;
                    #region Dữ liệu xml

                    string reportName = "C203NS";
                    string fileName = result[0].RefNo;
                    string savepath = reportName + fileName + @".xml";
                    Cursor.Current = Cursors.WaitCursor;
                    XmlTextWriter writer = new XmlTextWriter(savepath,
                        Encoding.UTF8);
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();

                    writer.WriteStartElement("java");
                    writer.WriteAttributeString("version", "1.7.0_17");
                    writer.WriteAttributeString("class", "java.beans.XMLDecoder");

                    writer.WriteStartElement("object");
                    writer.WriteAttributeString("class", "dvc.service.custom.TemplateChungTu");

                    writer.WriteStartElement("void");
                    writer.WriteAttributeString("property", "dmTiente");
                    writer.WriteStartElement("string");
                    writer.WriteString("VND");
                    writer.WriteEndElement();
                    writer.WriteEndElement();

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvqhnsCancuTuUt"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString("0"); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvqhnsCancuTuUtKbnn"); //Field name
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvqhnsCancuTuUtKbnnTen"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString(" "); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void");
                    writer.WriteAttributeString("property", "dvqhnsCancuTuUtNgay");
                    writer.WriteStartElement("object");
                    writer.WriteAttributeString("class", "java.sql.Timestamp");
                    writer.WriteStartElement("long");
                    writer.WriteValue((long)(result[0].RefDate
                        .ToUniversalTime()
                        .Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds));
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndElement(); // ngayChungtu

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvqhnsCapns"); //Field name
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvqhnsCtmt"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString(result[0].TargetProgramCode); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvqhnsCtmtMa"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString(" "); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvqhnsCtmtTen"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString(" "); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvqhnsKbnn"); //Field name
                    writer.WriteEndElement(); //End string

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvqhnsMa"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString(GlobalVariable.CompanyCode); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvqhnsNamns"); //Field name
                    writer.WriteStartElement("long"); //Start string
                    writer.WriteValue((long)result[0].RefDate.Year); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvqhnsSotk"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteValue(" "); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvqhnsSotkSo"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteValue(" "); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvqhnsTen"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteValue(GlobalVariable.CompanyName); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvqhnsThanhtoanThanhTcUt"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteValue("0"); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvqhnsThanhtoanTuUt"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteValue("0"); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    writer.WriteStartElement("void");
                    writer.WriteAttributeString("property", "gnHosoC203GtByGnHosoC203");

                    writer.WriteStartElement("object");
                    writer.WriteAttributeString("class", "java.util.ArrayList");

                    //Detail
                    //var detaillist = Model.GetReceiptVoucher(list[0].RefId, true, true);
                    var count = result.Count;

                    for (int i = 0; i < count; i++)
                    {
                        writer.WriteStartElement("void");
                        writer.WriteAttributeString("method", "add");
                        writer.WriteStartElement("object");
                        writer.WriteAttributeString("class", "dvc.service.custom.TemplateChungTuGt");

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dmChuong"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(result[i].BudgetChapterCode); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dmNdkt"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(result[i].BudgetSubItemCode); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dmNganhKt"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(result[i].BudgetSubKindItemCode); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dmNguonchi"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(result[i].BudgetSourceCode); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "maHang"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString((i + 1).ToString()); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "soDeNghi"); //Field name
                        writer.WriteStartElement("double"); //Start string
                        writer.WriteValue((double)result[i].Col3); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "soPheDuyet"); //Field name
                        writer.WriteStartElement("double"); //Start string
                        writer.WriteValue((double)result[i].Col2); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "soUngTruoc"); //Field name
                        writer.WriteStartElement("double"); //Start string
                        writer.WriteValue((double)result[i].Col1); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //End add
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                    }
                    //End add
                    writer.WriteEndElement();
                    writer.WriteEndElement();

                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "gnTaiLieuId"); //Field name
                    writer.WriteStartElement("long"); //Start string
                    writer.WriteValue((long)88); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void");
                    writer.WriteAttributeString("property", "ngayChungTu");
                    writer.WriteStartElement("object");
                    writer.WriteAttributeString("class", "java.sql.Timestamp");
                    writer.WriteStartElement("long");
                    writer.WriteValue((long)(result[0].RefDate
                        .ToUniversalTime()
                        .Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds));
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndElement(); // ngayChungtu

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "par1"); //Field name
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "soChungTu"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString(result[0].RefNo); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "tongSoTien"); //Field name
                    writer.WriteStartElement("double"); //Start string
                    writer.WriteValue(0); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "tuUt"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString("0"); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "typeChungTu"); //Field name
                    writer.WriteStartElement("long"); //Start string
                    writer.WriteValue(2); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    writer.WriteEndElement(); //dvc.service.custom.TemplateChungTu
                    writer.WriteEndElement(); //java

                    writer.WriteEndDocument();
                    writer.Close();
                    if (CreateZip(fileName, fbd.SelectedPath, reportName))
                        XtraMessageBox.Show("Xuất Xml thành công", "Thông báo");
                    else
                        XtraMessageBox.Show("Xuất Xml không thành công", "Thông báo");

                    //result = null;

                    #endregion
                }
            }
            return null;
        }


        public IList<C302NSModel> GetReportC302NSXML(ReportParameter reportParameter, List<C302NSModel> result = null, bool isParamater = false)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                decimal denghiAmount = 0;
                decimal tamungAmount = 0;
                decimal thanhtoanAmount = 0;
                DialogResult results = DialogResult.Cancel;
                if (string.IsNullOrEmpty(GlobalVariable.PathXML))
                    results = fbd.ShowDialog();
                else
                { fbd.SelectedPath = GlobalVariable.PathXML; results = DialogResult.OK; }
                if (result == null && isParamater) return null;
                if (results == DialogResult.OK && !string.IsNullOrEmpty(fbd.SelectedPath))
                {
                    GlobalVariable.PathXML = string.IsNullOrEmpty(GlobalVariable.PathXML)
                        ? fbd.SelectedPath
                        : GlobalVariable.PathXML;
                    #region Dữ liệu xml

                    string reportName = "C3_02NS";
                    string fileName = result[0].RefNo;
                    string savepath = reportName + fileName + @".xml";
                    Cursor.Current = Cursors.WaitCursor;
                    XmlTextWriter writer = new XmlTextWriter(savepath,
                        Encoding.UTF8);
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();

                    writer.WriteStartElement("java");
                    writer.WriteAttributeString("version", "1.7.0_17");
                    writer.WriteAttributeString("class", "java.beans.XMLDecoder");

                    writer.WriteStartElement("object");
                    writer.WriteAttributeString("class", "dvc.service.custom.TemplateChungTu");

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "daCancuDenghiDenngay"); //Field name
                    writer.WriteStartElement("double"); //Start string
                    writer.WriteValue(0); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "daCancuDenghiSo"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString(result[0].InvestmentNumber); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "daCancuDenghiTungay"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString(result[0].InvestmentDate.ToString()); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "daCapns"); //Field name
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "daCkcHdth"); //Field name
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "daCtmt"); //Field name
                    writer.WriteStartElement("string");
                    writer.WriteString("");
                    writer.WriteEndElement();
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "daDenghiKbnn"); //Field name
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "daDenghiKbnnTen"); //Field name
                    writer.WriteStartElement("string");
                    writer.WriteString("");
                    writer.WriteEndElement();
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "daNamns"); //Field name
                    writer.WriteStartElement("long");
                    writer.WriteValue(result[0].YearPlan);
                    writer.WriteEndElement();
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "daSoduTamungUngtruoc"); //Field name
                    writer.WriteStartElement("double");
                    writer.WriteValue(0);
                    writer.WriteEndElement();
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "daSotk"); //Field name
                    writer.WriteStartElement("string");
                    writer.WriteString("");
                    writer.WriteEndElement();
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "daSotkSo"); //Field name
                    writer.WriteStartElement("string");
                    writer.WriteString("");
                    writer.WriteEndElement();
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "daTcUtDktt"); //Field name
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "daTuUtChuaDktt"); //Field name
                    writer.WriteEndElement(); //End void

                    writer.WriteStartElement("void");
                    writer.WriteAttributeString("property", "dmTiente");
                    writer.WriteStartElement("string");
                    writer.WriteString("VND");
                    writer.WriteEndElement();
                    writer.WriteEndElement();

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvqhnsMa"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString(GlobalVariable.CompanyCode); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvqhnsTen"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString(GlobalVariable.CompanyName); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    writer.WriteStartElement("void");
                    writer.WriteAttributeString("property", "gnHosoC302GtByGnHosoC302");

                    writer.WriteStartElement("object");
                    writer.WriteAttributeString("class", "java.util.ArrayList");

                    //Detail
                    //var detaillist = Model.GetReceiptVoucher(list[0].RefId, true, true);
                    var count = result.Count;

                    for (int i = 0; i < count; i++)
                    {
                        writer.WriteStartElement("void");
                        writer.WriteAttributeString("method", "add");
                        writer.WriteStartElement("object");
                        writer.WriteAttributeString("class", "dvc.service.custom.TemplateChungTuGt");

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dmChuong"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(result[i].BudgetChapterCode); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dmNdkt"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(result[i].BudgetSubItemCode); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dmNganhKt"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(result[i].BudgetSubKindItemCode); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dmNguonchi"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(result[i].Property); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "maHang"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString((i + 1).ToString()); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "namKhv"); //Field name
                        writer.WriteStartElement("long"); //Start string
                        writer.WriteValue(result[i].YearPlan); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "noiDung"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(result[i].Description); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "soDeNghi"); //Field name
                        writer.WriteStartElement("double"); //Start string
                        writer.WriteValue(result[i].PayAmount); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void
                        denghiAmount += result[i].PayAmount;

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "soDuTamUng"); //Field name
                        writer.WriteStartElement("double"); //Start string
                        writer.WriteValue(result[i].AdvancePaymentAmount); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void
                        tamungAmount += result[i].AdvancePaymentAmount;

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "soThanhToan"); //Field name
                        writer.WriteStartElement("double"); //Start string
                        writer.WriteValue(result[i].PayableAmount); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void
                        thanhtoanAmount += result[i].PayableAmount;

                        //End add
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                    }
                    //End add
                    writer.WriteEndElement();
                    writer.WriteEndElement();

                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "gnTaiLieuId"); //Field name
                    writer.WriteStartElement("long"); //Start string
                    writer.WriteValue((long)94); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void");
                    writer.WriteAttributeString("property", "ngayChungTu");
                    writer.WriteStartElement("object");
                    writer.WriteAttributeString("class", "java.sql.Timestamp");
                    writer.WriteStartElement("long");
                    writer.WriteValue((long)(result[0].RefDate
                        .ToUniversalTime()
                        .Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds));
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndElement(); // ngayChungtu

                    //New field
                    writer.WriteStartElement("void");
                    writer.WriteAttributeString("property", "par1");
                    writer.WriteStartElement("string");
                    writer.WriteString(RSSHelper.NumberToWord.Read(denghiAmount, "đồng", "", "#.0000"));
                    writer.WriteEndElement();
                    writer.WriteEndElement();

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "par3"); //Field name
                    writer.WriteStartElement("string");
                    writer.WriteString(thanhtoanAmount.ToString());
                    writer.WriteEndElement();
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "par4"); //Field name
                    writer.WriteStartElement("string");
                    writer.WriteString(tamungAmount.ToString());
                    writer.WriteEndElement();
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "soChungTu"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString(result[0].RefNo); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "tongSoTien"); //Field name
                    writer.WriteStartElement("double"); //Start string
                    writer.WriteValue(denghiAmount); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "tuUt"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString("0"); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "tuUt"); //Field name
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "typeChungTu"); //Field name
                    writer.WriteStartElement("long"); //Start string
                    writer.WriteValue(9); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    writer.WriteEndElement(); //dvc.service.custom.TemplateChungTu
                    writer.WriteEndElement(); //java

                    writer.WriteEndDocument();
                    writer.Close();
                    if (CreateZip(fileName, fbd.SelectedPath, reportName))
                        XtraMessageBox.Show("Xuất Xml thành công", "Thông báo");
                    else
                        XtraMessageBox.Show("Xuất Xml không thành công", "Thông báo");

                    //result = null;

                    #endregion
                }
            }
            return null;
        }

        //bỏ
        public IList<C2_02a_NSModel> ReportBUPlanWithDraw_C2_02BXML(ReportParameter reportParameter, List<C2_02a_NSModel> result = null, bool isParamater = false)
        {
            decimal totalAmount = 0;
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult results = DialogResult.Cancel;
                if (string.IsNullOrEmpty(GlobalVariable.PathXML))
                    results = fbd.ShowDialog();
                else
                { fbd.SelectedPath = GlobalVariable.PathXML; results = DialogResult.OK; }
                if (result == null && !isParamater)
                {
                    result = Model.ReportBUPlanWithDraw(reportParameter.RefId, 0, 1, 1,
                        (Enum.RefType)reportParameter.RefType).ToList();

                    if (result.Count <= 0)
                    {
                        XtraMessageBox.Show("Dữ liệu báo cáo không có bản ghi nào!", "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        return null;
                    }
                }
                if (results == DialogResult.OK && !string.IsNullOrEmpty(fbd.SelectedPath))
                {
                    GlobalVariable.PathXML = string.IsNullOrEmpty(GlobalVariable.PathXML)
                        ? fbd.SelectedPath
                        : GlobalVariable.PathXML;
                    #region Dữ liệu xml


                    string reportName = "C202b";
                    string fileName = result[0].RefNo;
                    string savepath = reportName + fileName + @".xml";
                    Cursor.Current = Cursors.WaitCursor;
                    XmlTextWriter writer = new XmlTextWriter(savepath,
                        Encoding.UTF8);
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();

                    writer.WriteStartElement("java");
                    writer.WriteAttributeString("version", "1.7.0_17");
                    writer.WriteAttributeString("class", "java.beans.XMLDecoder");

                    writer.WriteStartElement("object");
                    writer.WriteAttributeString("class", "dvc.service.custom.TemplateChungTu");
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "chuyenkhoanTienmat"); //Field name
                    writer.WriteStartElement("string");
                    writer.WriteString("0");
                    writer.WriteEndElement();
                    writer.WriteEndElement(); //End void

                    writer.WriteStartElement("void");
                    writer.WriteAttributeString("property", "dmDvqhns");
                    writer.WriteStartElement("string");
                    writer.WriteString(GlobalVariable.CompanyCode);
                    writer.WriteEndElement();
                    writer.WriteEndElement();

                    writer.WriteStartElement("void");
                    writer.WriteAttributeString("property", "dmTiente");
                    writer.WriteStartElement("string");
                    writer.WriteString("VND");
                    writer.WriteEndElement();
                    writer.WriteEndElement();

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvNhantienDiachi"); //Field name
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvNhantienKbnn"); //Field name
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvNhantienKbnnTen"); //Field name
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvNhantienLoai"); //Field name
                    writer.WriteStartElement("long"); //Start string
                    writer.WriteValue(0); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvNhantienMa"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString(result[0].BudgetCode); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void
                    decimal total_temp = 0;
                    for (int i = 0; i < result[0].Details.Count; i++)
                    {
                        total_temp += result[0].Details[i].Amount;
                    }
                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvNhantienSotiennhan"); //Field name
                    writer.WriteStartElement("double"); //Start string
                    writer.WriteValue((double)total_temp); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvNhantienSotkSo"); //Field name
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvNhantienTen"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString(result[0].Employee); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvNopthueChuong"); //Field name
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvNopthueCqthuMa"); //Field name
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvNopthueCqthuTen"); //Field name
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvNopthueKbHachtoan"); //Field name
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvNopthueKbHachtoanTen"); //Field name
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvNopthueKythue"); //Field name
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvNopthueMasothue"); //Field name
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvNopthueNdkt"); //Field name
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvNopthueSotiennop"); //Field name
                    writer.WriteStartElement("double"); //Start string
                    writer.WriteValue(0); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvNopthueTen"); //Field name
                    writer.WriteEndElement(); //End void

                    //New field (Chưa lấy dc)
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvqhnsCapns"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString(" "); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvqhnsCkcHdk"); //Field name
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvqhnsCkcHdth"); //Field name
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvqhnsCtmt"); //Field name
                    writer.WriteStartElement("string");
                    writer.WriteString(result[0].ProjectCode);
                    writer.WriteEndElement();
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvqhnsKbnn"); //Field name
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void");
                    writer.WriteAttributeString("property", "dvqhnsMa");
                    writer.WriteStartElement("string");
                    writer.WriteString(GlobalVariable.CompanyCode);
                    writer.WriteEndElement();
                    writer.WriteEndElement();

                    //New field
                    writer.WriteStartElement("void");
                    writer.WriteAttributeString("property", "dvqhnsNamns");
                    writer.WriteStartElement("long");
                    writer.WriteValue(result[0].PostedDate.Year);
                    writer.WriteEndElement();
                    writer.WriteEndElement();

                    //New field
                    writer.WriteStartElement("void");
                    writer.WriteAttributeString("property", "dvqhnsTen");
                    writer.WriteStartElement("string");
                    writer.WriteString(GlobalVariable.CompanyName);
                    writer.WriteEndElement();
                    writer.WriteEndElement();

                    writer.WriteStartElement("void");
                    writer.WriteAttributeString("property", "gnHosoC202GtByGnHosoC202");

                    writer.WriteStartElement("object");
                    writer.WriteAttributeString("class", "java.util.ArrayList");
                    //Detail
                    //var detaillist = Model.GetReceiptVoucher(list[0].RefId, true, true);
                    var count = result[0].Details.Count;

                    for (int i = 0; i < count; i++)
                    {
                        writer.WriteStartElement("void");
                        writer.WriteAttributeString("method", "add");
                        writer.WriteStartElement("object");
                        writer.WriteAttributeString("class", "dvc.service.custom.TemplateChungTuGt");

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dmChuong"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(result[0].Details[i].BudgetChapterCode); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dmNdkt"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(result[0].Details[i].BudgetSubItemCode); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dmNganhKt"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(result[0].Details[i].BudgetSubKindItemCode); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dmNguonchi"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(result[0].Details[i].BudgetSourceCode); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dvNhantien"); //Field name
                        writer.WriteStartElement("double"); //Start string
                        writer.WriteValue(result[0].Details[i].Amount); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void
                        totalAmount += result[0].Details[i].Amount;
                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dvNopthue"); //Field name
                        writer.WriteStartElement("double"); //Start string
                        writer.WriteValue((double)result[0].Details[i].AmountTax); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "maHang"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString((i + 1).ToString()); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "noiDung"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(result[0].JournalMemo); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "soTien"); //Field name
                        writer.WriteStartElement("double"); //Start string
                        writer.WriteValue(result[0].Details[i].Amount); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //End add
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                    }
                    //End add
                    writer.WriteEndElement();
                    writer.WriteEndElement();

                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "gnTaiLieuId"); //Field name
                    writer.WriteStartElement("long"); //Start string
                    writer.WriteValue((long)500); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void");
                    writer.WriteAttributeString("property", "ngayChungTu");
                    writer.WriteStartElement("object");
                    writer.WriteAttributeString("class", "java.sql.Timestamp");
                    writer.WriteStartElement("long");
                    writer.WriteValue((long)(result[0].PostedDate
                        .ToUniversalTime()
                        .Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds));
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndElement(); // ngayChungtu

                    //New field
                    writer.WriteStartElement("void");
                    writer.WriteAttributeString("property", "par1");
                    writer.WriteStartElement("string");
                    writer.WriteString(RSSHelper.NumberToWord.Read(totalAmount, "đồng", "", "#.0000"));
                    writer.WriteEndElement();
                    writer.WriteEndElement();

                    //New field
                    writer.WriteStartElement("void");
                    writer.WriteAttributeString("property", "par2");
                    writer.WriteEndElement();

                    //New field
                    writer.WriteStartElement("void");
                    writer.WriteAttributeString("property", "par3");
                    writer.WriteStartElement("string");
                    writer.WriteString(RSSHelper.NumberToWord.Read(totalAmount, "đồng", "", "#.0000"));
                    writer.WriteEndElement();
                    writer.WriteEndElement();

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "soChungTu"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString(result[0].RefNo); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "thucchiTamung"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString(result[0].CashWithDrawType.Equals(6) ? "0" : "1"); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "tongSoTien"); //Field name
                    writer.WriteStartElement("double"); //Start string
                    writer.WriteValue((double)totalAmount); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "typeChungTu"); //Field name
                    writer.WriteStartElement("long"); //Start string
                    writer.WriteValue(1); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    writer.WriteEndElement(); //dvc.service.custom.TemplateChungTu
                    writer.WriteEndElement(); //java

                    writer.WriteEndDocument();
                    writer.Close();
                    if (CreateZip(fileName, fbd.SelectedPath, reportName))
                        XtraMessageBox.Show("Xuất Xml thành công", "Thông báo");
                    else
                        XtraMessageBox.Show("Xuất Xml không thành công", "Thông báo");

                    //result = null;

                    #endregion
                }
            }
            return null;
        }

        public IList<TT39Model> ReportVoucherListTT39XML(ReportParameter reportParameter, ReportSharpHelper oRsTool, List<TT39Model> result = null, bool isParamater = false)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult results = DialogResult.Cancel;
                if (string.IsNullOrEmpty(GlobalVariable.PathXML))
                    results = fbd.ShowDialog();
                else
                { fbd.SelectedPath = GlobalVariable.PathXML; results = DialogResult.OK; }
                if (result == null && isParamater) return null;
                if (results == DialogResult.OK && !string.IsNullOrEmpty(fbd.SelectedPath))
                {
                    GlobalVariable.PathXML = string.IsNullOrEmpty(GlobalVariable.PathXML)
                        ? fbd.SelectedPath
                        : GlobalVariable.PathXML;
                    #region Dữ liệu xml


                    string reportName = "M01";
                    string fileName = result[0].RefNo;
                    string savepath = reportName + fileName + @".xml";
                    Cursor.Current = Cursors.WaitCursor;
                    XmlTextWriter writer = new XmlTextWriter(savepath,
                        Encoding.UTF8);
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();

                    writer.WriteStartElement("java");
                    writer.WriteAttributeString("version", "1.7.0_17");
                    writer.WriteAttributeString("class", "java.beans.XMLDecoder");

                    writer.WriteStartElement("object");
                    writer.WriteAttributeString("class", "dvc.service.custom.TemplateChungTu");

                    //New field
                    writer.WriteStartElement("void");
                    writer.WriteAttributeString("property", "dmDvqhns");
                    writer.WriteStartElement("string");
                    writer.WriteString(GlobalVariable.CompanyCode);
                    writer.WriteEndElement();
                    writer.WriteEndElement();

                    //New field
                    writer.WriteStartElement("void");
                    writer.WriteAttributeString("property", "dmTiente");
                    writer.WriteStartElement("string");
                    writer.WriteString(result[0].CurrencyCode);
                    writer.WriteEndElement();
                    writer.WriteEndElement();

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvqhnsCtmt"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString(result[0].ProjectCode); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvqhnsMa"); //Field name
                    writer.WriteStartElement("string");
                    writer.WriteString(GlobalVariable.CompanyCode);
                    writer.WriteEndElement();
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvqhnsNguon"); //Field name
                    writer.WriteStartElement("string");
                    writer.WriteString("01");
                    writer.WriteEndElement();
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "dvqhnsTen"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString(GlobalVariable.CompanyName); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    writer.WriteStartElement("void");
                    writer.WriteAttributeString("property", "gnHosoM01GtByGnHosoM01");

                    writer.WriteStartElement("object");
                    writer.WriteAttributeString("class", "java.util.ArrayList");

                    //Detail
                    //var detaillist = Model.GetReceiptVoucher(list[0].RefId, true, true);
                    var count = result.Count;

                    for (int i = 0; i < count; i++)
                    {
                        writer.WriteStartElement("void");
                        writer.WriteAttributeString("method", "add");
                        writer.WriteStartElement("object");
                        writer.WriteAttributeString("class", "dvc.service.custom.TemplateChungTuGt");

                        //New field
                        writer.WriteStartElement("void");
                        writer.WriteAttributeString("property", "chungTuNgay");
                        writer.WriteStartElement("object");
                        writer.WriteAttributeString("class", "java.sql.Timestamp");
                        writer.WriteStartElement("long");
                        writer.WriteValue((long)((result[i].RefDate)
                            .ToUniversalTime()
                            .Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds));
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                        writer.WriteEndElement(); // ngayChungtu

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "chungTuSo"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(result[i].RefNo); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dmNdkt"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(result[i].BudgetSubItemCode); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "ngayHoaDon"); //Field name
                        if (!string.IsNullOrEmpty(result[i].OrgRefDate.ToString()))
                        {
                            DateTime time = Convert.ToDateTime(result[i].OrgRefDate);
                            writer.WriteStartElement("object");
                            writer.WriteAttributeString("class", "java.sql.Timestamp");
                            writer.WriteStartElement("long");
                            writer.WriteValue((long)(time.ToUniversalTime()
                                .Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds));
                            writer.WriteEndElement();
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement(); // ngayChungtu

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "noiDung"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(result[i].Description); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "soHoaDon"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        //writer.WriteString((i + 1).ToString()); //Values
                        writer.WriteString(result[i].OrgRefNo); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "soTien"); //Field name
                        writer.WriteStartElement("double"); //Start string
                        writer.WriteValue((double)result[i].Amount); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "soTienDm"); //Field name
                        writer.WriteStartElement("double"); //Start string
                        writer.WriteValue((double)result[i].Quota); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "soTienSl"); //Field name
                        writer.WriteStartElement("long"); //Start string
                        writer.WriteValue((long)result[i].Quantity); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //End add
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                    }
                    //End add
                    writer.WriteEndElement();
                    writer.WriteEndElement();

                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "gnTaiLieuId"); //Field name
                    writer.WriteStartElement("long"); //Start string
                    writer.WriteValue((long)99); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void");
                    writer.WriteAttributeString("property", "ngayChungTu");
                    //writer.WriteStartElement("object");
                    //writer.WriteAttributeString("class", "java.sql.Timestamp");
                    //writer.WriteStartElement("long");
                    //writer.WriteValue((long)(result[0].RefDate
                    //    .ToUniversalTime()
                    //    .Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds));
                    //writer.WriteEndElement();
                    //writer.WriteEndElement();
                    writer.WriteEndElement(); // ngayChungtu

                    //New field
                    writer.WriteStartElement("void");
                    writer.WriteAttributeString("property", "par1");
                    writer.WriteStartElement("string");
                    writer.WriteString(RSSHelper.NumberToWord.Read(result.Sum(x => x.Amount), "đồng", "", "#.0000"));
                    writer.WriteEndElement();
                    writer.WriteEndElement();

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "soChungTu"); //Field name
                    writer.WriteStartElement("string"); //Start string
                    writer.WriteString(result[0].RefNo); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "thanhToan"); //Field name
                    writer.WriteStartElement("long"); //Start string
                    writer.WriteValue(result[0].CashWithDrawTypeId.Equals(1) || result[0].CashWithDrawTypeId.Equals(2) ? 2 : result[0].CashWithDrawTypeId.Equals(3) || result[0].CashWithDrawTypeId.Equals(9) ? 1 : 0); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "tongSoTien"); //Field name
                    writer.WriteStartElement("double"); //Start string
                    writer.WriteValue((double)result.Sum(x => x.Amount)); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    //New field
                    writer.WriteStartElement("void"); //Start void
                    writer.WriteAttributeString("property", "typeChungTu"); //Field name
                    writer.WriteStartElement("long"); //Start string
                    writer.WriteValue(15);//reportParameter.RefType); //Values
                    writer.WriteEndElement(); //End string
                    writer.WriteEndElement(); //End void

                    writer.WriteEndElement(); //dvc.service.custom.TemplateChungTu
                    writer.WriteEndElement(); //java

                    writer.WriteEndDocument();
                    writer.Close();
                    if (CreateZip(fileName, fbd.SelectedPath, reportName))
                        XtraMessageBox.Show("Xuất Xml thành công", "Thông báo");
                    else
                        XtraMessageBox.Show("Xuất Xml không thành công", "Thông báo");

                    //result = null;

                    #endregion
                }
            }
            return null;
        }

        /// <summary>
        /// C4-09/KB – Giấy rút tiền mặt
        /// </summary>
        /// <param name="reportParameter"></param>
        /// <param name="oRsTool"></param>
        /// <returns></returns>
        public IList<C304NSModel> GetReportC304NSXML(ReportParameter reportParameter, ReportSharpHelper oRsTool, List<C304NSModel> result = null, bool isParamater = false)
        {
            decimal totalAmount = 0;
            try
            {
                result = Model.ReportC304NS(reportParameter.RefId).ToList();
                    if (result == null && isParamater) return null;
                if (result.Count <= 0)
                {
                    XtraMessageBox.Show("Dữ liệu báo cáo không có bản ghi nào!", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return null;
                }
                var master = new BAWithDrawModel();
                if (reportParameter.RefType.Equals(157)) //Chưa sử dụng cho reftype 113
                    master = Model.GetBAWithDraw(reportParameter.RefId, false, false, false, false, false);
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult results = DialogResult.Cancel;
                    if (string.IsNullOrEmpty(GlobalVariable.PathXML))
                        results = fbd.ShowDialog();
                    else
                    { fbd.SelectedPath = GlobalVariable.PathXML; results = DialogResult.OK; }
                    if (results == DialogResult.OK && !string.IsNullOrEmpty(fbd.SelectedPath))
                        {
                            GlobalVariable.PathXML = string.IsNullOrEmpty(GlobalVariable.PathXML)
                                ? fbd.SelectedPath
                                : GlobalVariable.PathXML;

                            #region Dữ liệu xml


                            string reportName = "C304NS";
                            string fileName = result[0].RefNo;
                            string savepath = reportName + fileName + @".xml";
                            Cursor.Current = Cursors.WaitCursor;
                            XmlTextWriter writer = new XmlTextWriter(savepath,
                                Encoding.UTF8);
                            writer.Formatting = Formatting.Indented;
                            writer.WriteStartDocument();

                            writer.WriteStartElement("java");
                            writer.WriteAttributeString("version", "1.7.0_17");
                            writer.WriteAttributeString("class", "java.beans.XMLDecoder");

                            writer.WriteStartElement("object");
                            writer.WriteAttributeString("class", "dvc.service.custom.TemplateChungTu");

                            writer.WriteStartElement("void");
                            writer.WriteAttributeString("property", "daCkcHdk");
                            writer.WriteEndElement();

                            writer.WriteStartElement("void");
                            writer.WriteAttributeString("property", "daCkcHdth");
                            writer.WriteEndElement();

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "daCtmt"); //Field name
                            if (!string.IsNullOrEmpty(result[0].ProjectCode))
                            {
                                writer.WriteStartElement("string"); //Start string
                                writer.WriteString(result[0].ProjectCode); //Values
                                writer.WriteEndElement(); //End string
                            }
                            writer.WriteEndElement(); //End void

                            writer.WriteStartElement("void");
                            writer.WriteAttributeString("property", "daKbnn");
                            writer.WriteEndElement();

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "daNamns"); //Field name
                            writer.WriteStartElement("long"); //Start string
                            writer.WriteValue(result[0].PostedDate.Year); //Values
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "dmDvqhns"); //Field name
                            writer.WriteStartElement("string"); //Start string
                            writer.WriteString(GlobalVariable.CompanyCode); //Values
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "dmTiente"); //Field name
                            writer.WriteStartElement("string"); //Start string
                            writer.WriteString(master.CurrencyCode); //Values Currency code
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "dvNopLoai"); //Field name
                            writer.WriteStartElement("long"); //Start string
                            writer.WriteValue("1"); //Values Currency code
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "dvNopNganhangTen"); //Field name
                            writer.WriteStartElement("string"); //Start string
                            writer.WriteString(result[0].BankName); //Values Currency code
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "dvNopNguoinop"); //Field name
                            writer.WriteStartElement("string"); //Start string
                            writer.WriteString(" "); //Values Currency code
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "dvNopQdNgay"); //Field name
                            writer.WriteEndElement(); //End void

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "dvNopQdSo"); //Field name
                            writer.WriteEndElement(); //End void

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "dvNopSotkSo"); //Field name
                            writer.WriteStartElement("string"); //Start string
                            writer.WriteString(result[0].BankAccount); //Values Currency code
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "dvNopTk3521"); //Field name
                            writer.WriteStartElement("string"); //Start string
                            writer.WriteString("0"); //Values Currency code
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "dvNopTk3522"); //Field name
                            writer.WriteStartElement("string"); //Start string
                            writer.WriteString("0"); //Values Currency code
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "dvNopTk3523"); //Field name
                            writer.WriteStartElement("string"); //Start string
                            writer.WriteString("0"); //Values Currency code
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "dvNopTk3529"); //Field name
                            writer.WriteStartElement("string"); //Start string
                            writer.WriteString("0"); //Values Currency code
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "dvqhnsMa"); //Field name
                            writer.WriteStartElement("string"); //Start string
                            writer.WriteString(GlobalVariable.CompanyCode); //Values
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "dvqhnsTen"); //Field name
                            writer.WriteStartElement("string"); //Start string
                            writer.WriteString(GlobalVariable.CompanyName); //Values
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void

                            writer.WriteStartElement("void");
                            writer.WriteAttributeString("property", "gnHosoC304GtByGnHosoC304");

                            writer.WriteStartElement("object");
                            writer.WriteAttributeString("class", "java.util.ArrayList");

                            ////Detail
                            //var detaillist = Model.GetReceiptVoucher(list[0].RefId, true, true);
                            var count = result.Count;

                            for (int i = 0; i < count; i++)
                            {
                                writer.WriteStartElement("void");
                                writer.WriteAttributeString("method", "add");
                                writer.WriteStartElement("object");
                                writer.WriteAttributeString("class", "dvc.service.custom.TemplateChungTuGt");

                                //New field
                                writer.WriteStartElement("void"); //Start void
                                writer.WriteAttributeString("property", "dmChuong"); //Field name
                                writer.WriteStartElement("string"); //Start string
                                writer.WriteString(result[i].BudgetChapterCode); //Values
                                writer.WriteEndElement(); //End string
                                writer.WriteEndElement(); //End void

                                //New field
                                writer.WriteStartElement("void"); //Start void
                                writer.WriteAttributeString("property", "dmNdkt"); //Field name
                                writer.WriteStartElement("string"); //Start string
                                writer.WriteString(result[i].BudgetSubItemCode); //Values
                                writer.WriteEndElement(); //End string
                                writer.WriteEndElement(); //End void

                                //New field
                                writer.WriteStartElement("void"); //Start void
                                writer.WriteAttributeString("property", "dmNganhKt"); //Field name
                                writer.WriteStartElement("string"); //Start string
                                writer.WriteString(result[i].BudgetSubKindItemCode); //Values
                                writer.WriteEndElement(); //End string
                                writer.WriteEndElement(); //End void

                                //New field
                                writer.WriteStartElement("void"); //Start void
                                writer.WriteAttributeString("property", "dmNguonchi"); //Field name
                                writer.WriteStartElement("string"); //Start string
                                writer.WriteString(result[i].GovSourceCode); //Values
                                writer.WriteEndElement(); //End string
                                writer.WriteEndElement(); //End void

                                //New field
                                writer.WriteStartElement("void"); //Start void
                                writer.WriteAttributeString("property", "maHang"); //Field name
                                writer.WriteStartElement("string"); //Start string
                                writer.WriteString((i + 1).ToString()); //Values
                                writer.WriteEndElement(); //End string
                                writer.WriteEndElement(); //End void

                                //New field
                                writer.WriteStartElement("void"); //Start void
                                writer.WriteAttributeString("property", "namKhv"); //Field name
                                writer.WriteStartElement("string"); //Start string
                                writer.WriteString("0"); //Values
                                writer.WriteEndElement(); //End string
                                writer.WriteEndElement(); //End void

                                //New field
                                writer.WriteStartElement("void"); //Start void
                                writer.WriteAttributeString("property", "noiDung"); //Field name
                                writer.WriteStartElement("string"); //Start string
                                writer.WriteString(master.JournalMemo); //Values
                                writer.WriteEndElement(); //End string
                                writer.WriteEndElement(); //End void

                                //New field
                                writer.WriteStartElement("void"); //Start void
                                writer.WriteAttributeString("property", "soTien"); //Field name
                                writer.WriteStartElement("double"); //Start string
                                writer.WriteValue(result[0].Amount); //Values
                                writer.WriteEndElement(); //End string
                                writer.WriteEndElement(); //End void
                                totalAmount += result[0].Amount;
                                //End add
                                writer.WriteEndElement();
                                writer.WriteEndElement();
                            }
                            //End add
                            writer.WriteEndElement();
                            writer.WriteEndElement();

                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "gnTaiLieuId"); //Field name
                            writer.WriteStartElement("long"); //Start string
                            writer.WriteValue((long)96); //Values
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void

                            //New field
                            writer.WriteStartElement("void");
                            writer.WriteAttributeString("property", "ngayChungTu");
                            writer.WriteStartElement("object");
                            writer.WriteAttributeString("class", "java.sql.Timestamp");
                            writer.WriteStartElement("long");
                            writer.WriteValue((long)(result[0].RefDate
                                .ToUniversalTime()
                                .Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds));
                            writer.WriteEndElement();
                            writer.WriteEndElement();
                            writer.WriteEndElement(); // ngayChungtu

                            //New field
                            writer.WriteStartElement("void");
                            writer.WriteAttributeString("property", "par1");
                            writer.WriteStartElement("string");
                            writer.WriteString(RSSHelper.NumberToWord.Read(totalAmount, "đồng", "", "#.0000"));
                            writer.WriteEndElement();
                            writer.WriteEndElement();

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "soChungTu"); //Field name
                            writer.WriteStartElement("string"); //Start string
                            writer.WriteString(result[0].RefNo); //Values
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "tmCk"); //Field name
                            writer.WriteStartElement("string"); //Start string
                            writer.WriteString("0"); //Values
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "tongSoTien"); //Field name
                            writer.WriteStartElement("double"); //Start string
                            writer.WriteValue((double)totalAmount); //Values
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "typeChungTu"); //Field name
                            writer.WriteStartElement("long"); //Start string
                            writer.WriteValue(11); //Values
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void

                            writer.WriteEndElement(); //dvc.service.custom.TemplateChungTu
                            writer.WriteEndElement(); //java

                            writer.WriteEndDocument();
                            writer.Close();
                            if (CreateZip(fileName, fbd.SelectedPath, reportName))
                                XtraMessageBox.Show("Xuất Xml thành công", "Thông báo");
                            else
                                XtraMessageBox.Show("Xuất Xml không thành công", "Thông báo");

                            //result = null;

                            #endregion
                        }
                    
                    return null;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi ở chỗ này " + ex.InnerException + ex.Message + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// C206NS
        /// </summary>
        /// <param name="reportParameter"></param>
        /// <param name="oRsTool"></param>
        /// <returns></returns>
        public IList<C205aModel> GetReportC205AXML(ReportParameter reportParameter, ReportSharpHelper oRsTool, List<C205aModel> result = null, bool isParamater = false)
        {
            decimal totalAmount = 0;
            try
            {
                if (result == null && !isParamater)
                {
                    result = Model.ReportC205A(reportParameter.RefId).ToList();
                    if (result.Count <= 0)
                    {
                        XtraMessageBox.Show("Dữ liệu báo cáo không có bản ghi nào!", "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        return null;
                    }
                }
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult results = DialogResult.Cancel;
                    if (string.IsNullOrEmpty(GlobalVariable.PathXML))
                        results = fbd.ShowDialog();
                    else
                    { fbd.SelectedPath = GlobalVariable.PathXML; results = DialogResult.OK; }
                    if (results == DialogResult.OK && !string.IsNullOrEmpty(fbd.SelectedPath))
                    {
                        GlobalVariable.PathXML = string.IsNullOrEmpty(GlobalVariable.PathXML)
                            ? fbd.SelectedPath
                            : GlobalVariable.PathXML;
                        #region Dữ liệu xml

                        string reportName = "C205a";
                        string fileName = result[0].RefNo;
                        string savepath = reportName + fileName + @".xml";
                        Cursor.Current = Cursors.WaitCursor;
                        XmlTextWriter writer = new XmlTextWriter(savepath,
                            Encoding.UTF8);
                        writer.Formatting = Formatting.Indented;
                        writer.WriteStartDocument();

                        writer.WriteStartElement("java");
                        writer.WriteAttributeString("version", "1.7.0_17");
                        writer.WriteAttributeString("class", "java.beans.XMLDecoder");

                        writer.WriteStartElement("object");
                        writer.WriteAttributeString("class", "dvc.service.custom.TemplateChungTu");

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dmDVDutoan"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(GlobalVariable.CompanyCode); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dmDvNop"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(GlobalVariable.CompanyCode); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dmTiente"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(result[0].CurrencyCode); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dvDutoanCapns"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(""); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dvDutoanCkcHdk"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(""); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dvDutoanCkcHdth"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(""); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dvDutoanCtmt"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(result[0].ProjectCode); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dvDutoanKbnn"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(" "); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dvDutoanMa"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(GlobalVariable.CompanyCode); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dvDutoanNamns"); //Field name
                        writer.WriteStartElement("long"); //Start string
                        writer.WriteValue((long)result[0].PostedDate.Year); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dvDutoanSotk"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(" "); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dvDutoanSotkSo"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(" "); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dvDutoanTen"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(GlobalVariable.CompanyName); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dvMa"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(GlobalVariable.CompanyCode); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dvNopKbNhTen"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(result[0].BankName); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dvNopKbnn"); //Field name
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dvNopNguoinop"); //Field name
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dvNopQdNgay"); //Field name
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dvNopQdSo"); //Field name
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dvNopSotkSo"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(result[0].BankAccount); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dvNopTk"); //Field name
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dvTen"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(GlobalVariable.CompanyName); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        writer.WriteStartElement("void");
                        writer.WriteAttributeString("property", "gnHosoC205GtByGnHosoC205");

                        writer.WriteStartElement("object");
                        writer.WriteAttributeString("class", "java.util.ArrayList");

                        ////Detail
                        //var detaillist = Model.GetReceiptVoucher(list[0].RefId, true, true);
                        var count = result.Count;

                        for (int i = 0; i < count; i++)
                        {
                            writer.WriteStartElement("void");
                            writer.WriteAttributeString("method", "add");
                            writer.WriteStartElement("object");
                            writer.WriteAttributeString("class", "dvc.service.custom.TemplateChungTuGt");

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "dmChuong"); //Field name
                            writer.WriteStartElement("string"); //Start string
                            writer.WriteString(result[i].BudgetChapterCode); //Values
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "dmNdkt"); //Field name
                            writer.WriteStartElement("string"); //Start string
                            writer.WriteString(result[i].BudgetSubItemCode); //Values
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "dmNganhKt"); //Field name
                            writer.WriteStartElement("string"); //Start string
                            writer.WriteString(result[i].BudgetSubKindItemCode); //Values
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "dmNguonchi"); //Field name
                            writer.WriteStartElement("string"); //Start string
                            writer.WriteString(result[i].GovSourceCode); //Values
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "maHang"); //Field name
                            writer.WriteStartElement("string"); //Start string
                            writer.WriteString((i + 1).ToString()); //Values
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "noiDung"); //Field name
                            writer.WriteStartElement("string"); //Start string
                            writer.WriteString(result[0].JournalMemo); //Values
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "soTien"); //Field name
                            writer.WriteStartElement("double"); //Start string
                            writer.WriteValue(result[0].Amount); //Values
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void
                            totalAmount += result[0].Amount;
                            //End add
                            writer.WriteEndElement();
                            writer.WriteEndElement();
                        }
                        //End add
                        writer.WriteEndElement();
                        writer.WriteEndElement();

                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "gnTaiLieuId"); //Field name
                        writer.WriteStartElement("long"); //Start string
                        writer.WriteValue((long)424); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void");
                        writer.WriteAttributeString("property", "ngayChungTu");
                        writer.WriteStartElement("object");
                        writer.WriteAttributeString("class", "java.sql.Timestamp");
                        writer.WriteStartElement("long");
                        writer.WriteValue((long)(result[0].RefDate
                            .ToUniversalTime()
                            .Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds));
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                        writer.WriteEndElement(); // ngayChungtu

                        //New field
                        writer.WriteStartElement("void");
                        writer.WriteAttributeString("property", "par1");
                        writer.WriteStartElement("string");
                        writer.WriteString(RSSHelper.NumberToWord.Read(totalAmount, "đồng", "", "#.0000"));
                        writer.WriteEndElement();
                        writer.WriteEndElement();

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "soChungTu"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(result[0].RefNo); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "tmCk"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString("0"); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "tongSoTien"); //Field name
                        writer.WriteStartElement("double"); //Start string
                        writer.WriteValue((double)totalAmount); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "typeChungTu"); //Field name
                        writer.WriteStartElement("long"); //Start string
                        writer.WriteValue(4); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dvNopSotkLoai"); //Field name
                        writer.WriteStartElement("long"); //Start string
                        writer.WriteValue(result[0].BudgetType.Equals(1)?0: result[0].BudgetType.Equals(2)?1:0); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        writer.WriteEndElement(); //dvc.service.custom.TemplateChungTu
                        writer.WriteEndElement(); //java

                        writer.WriteEndDocument();
                        writer.Close();

                        if (CreateZip(fileName, fbd.SelectedPath, reportName))
                            XtraMessageBox.Show("Xuất Xml thành công", "Thông báo");
                        else
                            XtraMessageBox.Show("Xuất Xml không thành công", "Thông báo");

                        //result = null;

                        #endregion

                    }
                }
                return null;
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi ở chỗ này " + ex.InnerException + ex.Message + ex.StackTrace);
                return null;
            }
        }

        //Bỏ
        /// <summary>
        /// C205A
        /// </summary>
        /// <param name="reportParameter"></param>
        /// <param name="oRsTool"></param>
        /// <returns></returns>
        public IList<C206NSModel> GetReportC206NSXML(ReportParameter reportParameter, ReportSharpHelper oRsTool, List<C206NSModel> result = null, bool isParamater = false)
        {
            decimal totalAmount = 0;
            try
            {
                if (result == null && !isParamater)
                {
                    result = Model.ReportC206NS(reportParameter.RefId).ToList();
                    if (result.Count <= 0)
                    {
                        XtraMessageBox.Show("Dữ liệu báo cáo không có bản ghi nào!", "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        return null;
                    }
                }
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult results = DialogResult.Cancel;
                    if (string.IsNullOrEmpty(GlobalVariable.PathXML))
                        results = fbd.ShowDialog();
                    else
                    { fbd.SelectedPath = GlobalVariable.PathXML; results = DialogResult.OK; }
                    if (results == DialogResult.OK && !string.IsNullOrEmpty(fbd.SelectedPath))
                    {
                        GlobalVariable.PathXML = string.IsNullOrEmpty(GlobalVariable.PathXML)
                            ? fbd.SelectedPath
                            : GlobalVariable.PathXML;
                        #region Dữ liệu xml


                        string reportName = "C206";
                        string fileName = result[0].RefNo;
                        string savepath = reportName + fileName + @".xml";
                        Cursor.Current = Cursors.WaitCursor;
                        XmlTextWriter writer = new XmlTextWriter(savepath,
                            Encoding.UTF8);
                        writer.Formatting = Formatting.Indented;
                        writer.WriteStartDocument();

                        writer.WriteStartElement("java");
                        writer.WriteAttributeString("version", "1.7.0_17");
                        writer.WriteAttributeString("class", "java.beans.XMLDecoder");

                        writer.WriteStartElement("object");
                        writer.WriteAttributeString("class", "dvc.service.custom.TemplateChungTu");

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "bkNganHang"); //Field name
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "bkNganHangTrungGianTen"); //Field name
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "bkNhSwiftCode"); //Field name
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "bkNhTgSwiftCode"); //Field name
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "bkSoTaiKhoan"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(result[0].AccountingObjectBankAccount); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "bkTaiNganHang"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(result[0].AccountingObjectBankName); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "bkTenTaiKhoan"); //Field name
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dmDvqhns"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(GlobalVariable.CompanyCode); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dmTiente"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(result[0].CurrencyCode); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dvqhnsCapns"); //Field name
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dvqhnsCkcHdk"); //Field name
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dvqhnsCkcHdth"); //Field name
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dvqhnsCkcHdth"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(result[0].TargetProgramCode); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dvqhnsKbnn"); //Field name
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dvqhnsMa"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(GlobalVariable.CompanyCode); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dvqhnsNamns"); //Field name
                        writer.WriteStartElement("long"); //Start string
                        writer.WriteValue(result[0].PostedDate.Year); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dvqhnsNoidung"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(result[0].JournalMemo); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dvqhnsSotk"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(result[0].BankAccount); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dvqhnsSotkSo"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(result[0].BankAccount); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dvqhnsTen"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(GlobalVariable.CompanyName); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        writer.WriteStartElement("void");
                        writer.WriteAttributeString("property", "gnHosoC206GtByGnHosoC206");

                        writer.WriteStartElement("object");
                        writer.WriteAttributeString("class", "java.util.ArrayList");

                        ////Detail
                        //var detaillist = Model.GetReceiptVoucher(list[0].RefId, true, true);
                        var count = result.Count;

                        for (int i = 0; i < count; i++)
                        {
                            writer.WriteStartElement("void");
                            writer.WriteAttributeString("method", "add");
                            writer.WriteStartElement("object");
                            writer.WriteAttributeString("class", "dvc.service.custom.TemplateChungTuGt");

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "dmChuong"); //Field name
                            writer.WriteStartElement("string"); //Start string
                            writer.WriteString(result[i].BudgetChapterCode); //Values
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "dmNdkt"); //Field name
                            writer.WriteStartElement("string"); //Start string
                            writer.WriteString(result[i].BudgetSubItemCode); //Values
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "dmNganhKt"); //Field name
                            writer.WriteStartElement("string"); //Start string
                            writer.WriteString(result[i].BudgetSubKindItemCode); //Values
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "dmNguonchi"); //Field name
                            writer.WriteStartElement("string"); //Start string
                            writer.WriteString(result[i].BudgetSourceCode); //Values
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "dmTiente"); //Field name
                            writer.WriteStartElement("string"); //Start string
                            writer.WriteString(result[0].CurrencyCode); //Values
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "maHang"); //Field name
                            writer.WriteStartElement("string"); //Start string
                            writer.WriteString("3." + (i + 1).ToString()); //Values
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "soTienNT"); //Field name
                            writer.WriteStartElement("double"); //Start string
                            writer.WriteValue(result[0].AmountOC); //Values
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void
                            totalAmount += result[0].Amount;

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "soTienVnd"); //Field name
                            writer.WriteStartElement("double"); //Start string
                            writer.WriteValue(result[0].Amount); //Values
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void
                            totalAmount += result[0].Amount;
                            //End add
                            writer.WriteEndElement();
                            writer.WriteEndElement();
                        }
                        //Phần add này nằm cuối detail

                        writer.WriteStartElement("void");
                        writer.WriteAttributeString("method", "add");
                        writer.WriteStartElement("object");
                        writer.WriteAttributeString("class", "dvc.service.custom.TemplateChungTuGt");

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dmChuong"); //Field name
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dmNdkt"); //Field name
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dmNganhKt"); //Field name
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dmNguonchi"); //Field name
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dmTiente"); //Field name
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "maHang"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString("2.2"); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "soTienNT"); //Field name
                        writer.WriteStartElement("double"); //Start string
                        writer.WriteValue(0); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void
                        totalAmount += result[0].Amount;

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "soTienVnd"); //Field name
                        writer.WriteStartElement("double"); //Start string
                        writer.WriteValue(0); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //End add
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                        //======================================================
                        //End for
                        writer.WriteEndElement();
                        writer.WriteEndElement();

                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "gnTaiLieuId"); //Field name
                        writer.WriteStartElement("long"); //Start string
                        writer.WriteValue((long)160); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void");
                        writer.WriteAttributeString("property", "ngayChungTu");
                        writer.WriteStartElement("object");
                        writer.WriteAttributeString("class", "java.sql.Timestamp");
                        writer.WriteStartElement("long");
                        writer.WriteValue((long)(result[0].RefDate
                            .ToUniversalTime()
                            .Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds));
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                        writer.WriteEndElement(); // ngayChungtu

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "nguoinhanCmndNgaycap"); //Field name
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "nguoinhanCmndNoicap"); //Field name
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "nguoinhanCmndSo"); //Field name
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "nguoinhanHoten"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(result[0].AccountingObjectName); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void");
                        writer.WriteAttributeString("property", "par1");
                        writer.WriteStartElement("string");
                        writer.WriteString(RSSHelper.NumberToWord.Read(totalAmount, "đồng", "", "#.0000"));
                        writer.WriteEndElement();
                        writer.WriteEndElement();

                        //New field
                        writer.WriteStartElement("void");
                        writer.WriteAttributeString("property", "par2");
                        writer.WriteStartElement("string");
                        writer.WriteString(RSSHelper.NumberToWord.Read(totalAmount, "đồng", "", "#.0000"));
                        writer.WriteEndElement();
                        writer.WriteEndElement();

                        //New field
                        writer.WriteStartElement("void");
                        writer.WriteAttributeString("property", "par3");
                        writer.WriteStartElement("string");
                        writer.WriteString(totalAmount.ToString());
                        writer.WriteEndElement();
                        writer.WriteEndElement();

                        //New field
                        writer.WriteStartElement("void");
                        writer.WriteAttributeString("property", "par4");
                        writer.WriteStartElement("string");
                        writer.WriteString(totalAmount.ToString());
                        writer.WriteEndElement();
                        writer.WriteEndElement();

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "soChungTu"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(result[0].RefNo); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "tcTu"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString("0"); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "ckTm"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(reportParameter.RefType.Equals(55)?"0":"1"); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "typeChungTu"); //Field name
                        writer.WriteStartElement("long"); //Start string
                        writer.WriteValue(5); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        writer.WriteEndElement(); //dvc.service.custom.TemplateChungTu
                        writer.WriteEndElement(); //java

                        writer.WriteEndDocument();
                        writer.Close();
                        if (CreateZip(fileName, fbd.SelectedPath, reportName))
                            XtraMessageBox.Show("Xuất Xml thành công", "Thông báo");
                        else
                            XtraMessageBox.Show("Xuất Xml không thành công", "Thông báo");

                        //result = null;

                        #endregion
                    }
                }
                return null;
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi ở chỗ này " + ex.InnerException + ex.Message + ex.StackTrace);
                return null;
            }
        }


        public IList<PaymentPurchaseModel> GetPaymentPurchaseXML(ReportParameter reportParameter, ReportSharpHelper oRsTool, List<PaymentPurchaseModel> result = null, bool isParamater = false)
        {
            decimal totalAmount = 0;
            try
            {
                if (result == null && !isParamater)
                {
                    result = Model.ReportPaymentPurchase(reportParameter.RefId).ToList();
                    if (result.Count <= 0)
                    {
                        XtraMessageBox.Show("Dữ liệu báo cáo không có bản ghi nào!", "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        return null;
                    }
                }
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult results = DialogResult.Cancel;
                    if (string.IsNullOrEmpty(GlobalVariable.PathXML))
                        results = fbd.ShowDialog();
                    else
                    { fbd.SelectedPath = GlobalVariable.PathXML; results = DialogResult.OK; }
                    if (results == DialogResult.OK && !string.IsNullOrEmpty(fbd.SelectedPath))
                    {
                        GlobalVariable.PathXML = string.IsNullOrEmpty(GlobalVariable.PathXML)
                            ? fbd.SelectedPath
                            : GlobalVariable.PathXML;
                        #region Dữ liệu xml


                        string reportName = "M05";
                        string fileName = result[0].RefNo;
                        string savepath = reportName + fileName + @".xml";
                        Cursor.Current = Cursors.WaitCursor;
                        XmlTextWriter writer = new XmlTextWriter(savepath,
                            Encoding.UTF8);
                        writer.Formatting = Formatting.Indented;
                        writer.WriteStartDocument();

                        writer.WriteStartElement("java");
                        writer.WriteAttributeString("version", "1.7.0_17");
                        writer.WriteAttributeString("class", "java.beans.XMLDecoder");

                        writer.WriteStartElement("object");
                        writer.WriteAttributeString("class", "dvc.service.custom.TemplateChungTu");
                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "daCancuHdNgay"); //Field name
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "daCancuHdSo"); //Field name
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "daCancuKlhtNgay"); //Field name
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "daCancuKlhtSo"); //Field name
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "daCancuPhulucHdngay"); //Field name
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "daCancuPhulucHdSo"); //Field name
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "daDenghiKehoachvon"); //Field name
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "daDenghiNamKhv"); //Field name
                        writer.WriteStartElement("long"); //Start string
                        writer.WriteValue((long)result[0].PostedDate.Year); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "daDenghiNguonvon"); //Field name
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "daDenghiTtLuyke"); //Field name
                        writer.WriteStartElement("double"); //Start string
                        writer.WriteValue((double)0); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "daDenghiTtSodu"); //Field name
                        writer.WriteStartElement("double"); //Start string
                        writer.WriteValue((double)0); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "daDenghiTuTt"); //Field name
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "daNgoainuocSo"); //Field name
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "daNgoainuocTai"); //Field name
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "daTrongnuocSo"); //Field name
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "daTrongnuocTai"); //Field name
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dmTiente"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString("VND"); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dvThuhuongSotkSo"); //Field name
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dvThuhuongSotkTai"); //Field name
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dvThuhuongTen"); //Field name
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dvqhnsMa"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(GlobalVariable.CompanyCode); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "dvqhnsTen"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(GlobalVariable.CompanyName); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        writer.WriteStartElement("void");
                        writer.WriteAttributeString("property", "gnHosoM05GtByGnHosoM05");

                        writer.WriteStartElement("object");
                        writer.WriteAttributeString("class", "java.util.ArrayList");

                        ////Detail
                        //var detaillist = Model.GetReceiptVoucher(list[0].RefId, true, true);
                        var count = result.Count;

                        for (int i = 0; i < count; i++)
                        {
                            writer.WriteStartElement("void");
                            writer.WriteAttributeString("method", "add");
                            writer.WriteStartElement("object");
                            writer.WriteAttributeString("class", "dvc.service.custom.TemplateChungTuGt");

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "duToan"); //Field name
                            writer.WriteStartElement("double"); //Start string
                            writer.WriteValue((double)0); //Values
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "luykeNgoainuoc"); //Field name
                            writer.WriteStartElement("double"); //Start string
                            writer.WriteValue((double)0); //Values
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "luykeTrongnuoc"); //Field name
                            writer.WriteStartElement("double"); //Start string
                            writer.WriteValue((double)0); //Values
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "dmNdkt"); //Field name
                            writer.WriteStartElement("string"); //Start string
                            writer.WriteString(result[i].BudgetSubItemCode); //Values
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "maHang"); //Field name
                            writer.WriteStartElement("string"); //Start string
                            writer.WriteString((i + 1).ToString()); //Values
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "noiDung"); //Field name
                            writer.WriteStartElement("string"); //Start string
                            writer.WriteString(result[i].Description); //Values
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "tamungNgoainuoc"); //Field name
                            writer.WriteStartElement("double"); //Start string
                            writer.WriteValue((double)result[i].ForeignArising); //Values
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void

                            //New field
                            writer.WriteStartElement("void"); //Start void
                            writer.WriteAttributeString("property", "tamungTrongnuoc"); //Field name
                            writer.WriteStartElement("double"); //Start string
                            writer.WriteValue((double)result[i].DomesticArising); //Values
                            writer.WriteEndElement(); //End string
                            writer.WriteEndElement(); //End void

                            totalAmount += result[i].DomesticArising;
                            //End add
                            writer.WriteEndElement();
                            writer.WriteEndElement();
                        }

                        //End for
                        writer.WriteEndElement();
                        writer.WriteEndElement();

                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "gnTaiLieuId"); //Field name
                        writer.WriteStartElement("long"); //Start string
                        writer.WriteValue((long)161); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void");
                        writer.WriteAttributeString("property", "ngayChungTu");
                        writer.WriteStartElement("object");
                        writer.WriteAttributeString("class", "java.sql.Timestamp");
                        writer.WriteStartElement("long");
                        writer.WriteValue((long)(result[0].PostedDate
                            .ToUniversalTime()
                            .Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds));
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                        writer.WriteEndElement(); // ngayChungtu

                        //New field
                        writer.WriteStartElement("void");
                        writer.WriteAttributeString("property", "par1");
                        writer.WriteStartElement("string");
                        writer.WriteString(RSSHelper.NumberToWord.Read(totalAmount, "đồng", "", "#.0000"));
                        writer.WriteEndElement();
                        writer.WriteEndElement();

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "par2"); //Field name
                        writer.WriteStartElement("double"); //Start string
                        writer.WriteValue((double)totalAmount); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "soChungTu"); //Field name
                        writer.WriteStartElement("string"); //Start string
                        writer.WriteString(result[0].RefNo); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "stBaohanh"); //Field name
                        writer.WriteStartElement("double"); //Start string
                        writer.WriteValue((double)0); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "stBaohanhNgoainuoc"); //Field name
                        writer.WriteStartElement("double"); //Start string
                        writer.WriteValue((double)0); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "stBaohanhTrongnuoc"); //Field name
                        writer.WriteStartElement("double"); //Start string
                        writer.WriteValue((double)0); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "stThue"); //Field name
                        writer.WriteStartElement("double"); //Start string
                        writer.WriteValue((double)0); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "stThuhoi"); //Field name
                        writer.WriteStartElement("double"); //Start string
                        writer.WriteValue((double)0); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "stThuhoiNgoainuoc"); //Field name
                        writer.WriteStartElement("double"); //Start string
                        writer.WriteValue((double)0); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "stThuhoiTrongnuoc"); //Field name
                        writer.WriteStartElement("double"); //Start string
                        writer.WriteValue((double)0); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "stThuhuong"); //Field name
                        writer.WriteStartElement("double"); //Start string
                        writer.WriteValue((double)0); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "stThuhuongNgoainuoc"); //Field name
                        writer.WriteStartElement("double"); //Start string
                        writer.WriteValue((double)0); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "stThuhuongTrongnuoc"); //Field name
                        writer.WriteStartElement("double"); //Start string
                        writer.WriteValue((double)0); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        //New field
                        writer.WriteStartElement("void"); //Start void
                        writer.WriteAttributeString("property", "typeChungTu"); //Field name
                        writer.WriteStartElement("long"); //Start string
                        writer.WriteValue(14);//reportParameter.RefType); //Values
                        writer.WriteEndElement(); //End string
                        writer.WriteEndElement(); //End void

                        writer.WriteEndElement(); //dvc.service.custom.TemplateChungTu
                        writer.WriteEndElement(); //java

                        writer.WriteEndDocument();
                        writer.Close();
                        if (CreateZip(fileName, fbd.SelectedPath, reportName))
                            XtraMessageBox.Show("Xuất Xml thành công", "Thông báo");
                        else
                            XtraMessageBox.Show("Xuất Xml không thành công", "Thông báo");

                        //result = null;

                        #endregion
                    }
                }
                return null;
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi ở chỗ này " + ex.InnerException + ex.Message + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Tạo file zip cho báo cáo
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="filePath"></param>
        /// <param name="reportName"></param>
        /// <returns></returns>
        public bool CreateZip(string fileName, string filePath, string reportName)
        {
            try
            {
                using (ZipFile zip = new ZipFile())
                {
                    var endpath = filePath + @"\" + reportName + @"\" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
                    if (!System.IO.Directory.Exists(endpath))
                        System.IO.Directory.CreateDirectory(endpath);
                    zip.AddFile(reportName + fileName + @".xml", "");
                    zip.Save(endpath + @"\" + reportName + fileName + @".zip");
                    if (File.Exists(reportName + fileName + @".xml"))
                        File.Delete(reportName + fileName + @".xml");
                    return true;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi ở chỗ này: " + ex.InnerException + ex.Message + ex.StackTrace);
                return false;
            }
        }
    }
}
