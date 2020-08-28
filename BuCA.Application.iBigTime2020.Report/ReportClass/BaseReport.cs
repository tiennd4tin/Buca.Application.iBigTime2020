/***********************************************************************
 * <copyright file="BaseReport.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Wednesday, March 05, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections;
using Buca.Application.iBigTime2020.Model;
using System.Data;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BuCA.Application.iBigTime2020.Session;
using DevExpress.XtraEditors;
using PerpetuumSoft.Framework.Drawing;
using PerpetuumSoft.Reporting.Components;
using PerpetuumSoft.Reporting.DOM;


namespace BuCA.Application.iBigTime2020.Report.ReportClass
{

    public class BaseReport
    {
        protected static IModel Model { get; set; }
        
      
        public string ConvertDateToStringForReport(DateTime fromDate, DateTime toDate)
        {
            var result = "Từ ngày " + fromDate.ToString("dd/MM/yyyy") + " đến ngày " + toDate.ToString("dd/MM/yyyy");
            if (fromDate.Month == toDate.Month && fromDate.Year == toDate.Year && fromDate.Day == 1 &&
                toDate.Day == DateTime.DaysInMonth(toDate.Year, toDate.Month))
            {
                result = "Tháng " + fromDate.Month + " năm " + fromDate.Year;
            }
            else
            {
                if (fromDate.Year == toDate.Year && fromDate.Day == 1 && fromDate.Month == 1 && toDate.Month == 12 &&
                    toDate.Day == DateTime.DaysInMonth(toDate.Year, toDate.Month))
                {
                    result = "Năm " + fromDate.Year;
                }
                else
                {
                    if (fromDate.Year == toDate.Year)
                        if (fromDate.Day == 1 && toDate.Day == DateTime.DaysInMonth(toDate.Year, toDate.Month) &&
                            toDate.Month - fromDate.Month == 3)
                            switch (fromDate.Month)
                            {
                                case 1:
                                    result = "Quý 1 năm " + fromDate.Year;
                                    break;
                                case 4:
                                    result = "Quý 2 năm " + fromDate.Year;
                                    break;
                                case 7:
                                    result = "Quý 3 năm " + fromDate.Year;
                                    break;
                                case 10:
                                    result = "Quý 4 năm " + fromDate.Year;
                                    break;
                            }
                }
            }
            return result;
        }

        // Pivot Table
        public static DataTable GetInversedDataTable(DataTable table, string columnX,
            string columnY, string columnZ, string nullValue, bool sumValues)
        {
            //Create a DataTable to Return
            DataTable returnTable = new DataTable();

            if (columnX == "")
                columnX = table.Columns[0].ColumnName;

            //Add a Column at the beginning of the table
            returnTable.Columns.Add(columnY);

            //Read all DISTINCT values from columnX Column in the provided DataTale
            List<string> columnXValues = new List<string>();

            foreach (DataRow dr in table.Rows)
            {

                string columnXTemp2 = dr[columnX].ToString();
                string columnXTemp = "Dynamic" + dr[columnX];
                if (string.IsNullOrEmpty(columnXTemp2)) continue;

                if (!columnXValues.Contains(columnXTemp))
                {

                    //Read each row value, if it's different from others provided, add to 
                    //the list of values and creates a new Column with its value.
                    columnXValues.Add(columnXTemp);
                    returnTable.Columns.Add(columnXTemp);
                }
            }

            //Verify if Y and Z Axis columns re provided
            if (columnY != "" && columnZ != "")
            {
                //Read DISTINCT Values for Y Axis Column
                List<string> columnYValues = new List<string>();

                foreach (DataRow dr in table.Rows)
                {
                    if (!columnYValues.Contains(dr[columnY].ToString()))
                        columnYValues.Add(dr[columnY].ToString());

                }

                //Loop all Column Y Distinct Value
                foreach (string columnYValue in columnYValues)
                {
                    //Creates a new Row
                    DataRow drReturn = returnTable.NewRow();
                    drReturn[0] = columnYValue;
                    //foreach column Y value, The rows are selected distincted
                    DataRow[] rows = table.Select(columnY + "='" + columnYValue + "'");

                    //Read each row to fill the DataTable
                    foreach (DataRow dr in rows)
                    {
                        string rowColumnTitle = "Dynamic" + dr[columnX];

                        //Read each column to fill the DataTable
                        foreach (DataColumn dc in returnTable.Columns)
                        {
                            if (dc.ColumnName == rowColumnTitle)
                            {
                                //If Sum of Values is True it try to perform a Sum
                                //If sum is not possible due to value types, the value 
                                // displayed is the last one read
                                if (sumValues)
                                {
                                    try
                                    {
                                        drReturn[rowColumnTitle] =
                                            Convert.ToDecimal(drReturn[rowColumnTitle]) +
                                            Convert.ToDecimal(dr[columnZ]);
                                    }
                                    catch
                                    {
                                        drReturn[rowColumnTitle] = Convert.ToDecimal(dr[columnZ]);
                                    }
                                }
                                else
                                {
                                    drReturn[rowColumnTitle] = Convert.ToDecimal( dr[columnZ]);
                                }
                            }
                        }
                    }
                    returnTable.Rows.Add(drReturn);
                }
            }
            else
            {
                throw new Exception("The columns to perform inversion are not provided");
            }

            //if a nullValue is provided, fill the datable with it
            if (nullValue != "")
            {
                foreach (DataRow dr in returnTable.Rows)
                {
                    foreach (DataColumn dc in returnTable.Columns)
                    {
                        if (dr[dc.ColumnName].ToString() == "")
                            dr[dc.ColumnName] = nullValue;
                    }
                }
            }

            return returnTable;
        }

        //Join dynamic Table
        public static DataTable JoinDataTables(DataTable t1, DataTable t2, params Func<DataRow, DataRow, bool>[] joinOn)
        {
            DataTable result = new DataTable();
            foreach (DataColumn col in t1.Columns)
            {
                if (result.Columns[col.ColumnName] == null)
                    result.Columns.Add(col.ColumnName, col.DataType);
            }
            foreach (DataColumn col in t2.Columns)
            {
                if (result.Columns[col.ColumnName] == null)
                    result.Columns.Add(col.ColumnName, col.DataType);
            }
            foreach (DataRow row1 in t1.Rows)
            {
                var joinRows = t2.AsEnumerable().Where(row2 =>
                {
                    foreach (var parameter in joinOn)
                    {
                        if (!parameter(row1, row2)) return false;
                    }
                    return true;
                });
                foreach (DataRow fromRow in joinRows)
                {
                    DataRow insertRow = result.NewRow();
                    foreach (DataColumn col1 in t1.Columns)
                    {
                        insertRow[col1.ColumnName] = row1[col1.ColumnName];
                    }
                    foreach (DataColumn col2 in t2.Columns)
                    {
                        insertRow[col2.ColumnName] = fromRow[col2.ColumnName];
                    }
                    result.Rows.Add(insertRow);
                }
            }
            return result;
        }

        //Remove Duplicate Rows
        public DataTable RemoveDuplicateRows(DataTable dTable, string colName)
        {
            Hashtable hTable = new Hashtable();
            ArrayList duplicateList = new ArrayList();

            //Add list of all the unique item value to hashtable, which stores combination of key, value pair.
            //And add duplicate item value in arraylist.
            foreach (DataRow drow in dTable.Rows)
            {
                if (hTable.Contains(drow[colName]))
                    duplicateList.Add(drow);
                else
                    hTable.Add(drow[colName], string.Empty);
            }

            //Removing a list of duplicate items from datatable.
            foreach (DataRow dRow in duplicateList)
                dTable.Rows.Remove(dRow);

            //Datatable which contains unique records will be return as output.
            return dTable;
        }

        public bool RenderDynamicReport(DataTable dtSource, string reportFileName, double pmargin)
        {

            try
            {
                var reportSlot = new FileReportSlot {FilePath = GlobalVariable.ReportPath + reportFileName};

                Document doc = reportSlot.LoadReport();


                int pag = doc.Pages.Count;
                for (int i = 1; i < pag; i++)
                {
                    doc.Pages.RemoveAt(i);
                }
                PerpetuumSoft.Reporting.DOM.TextBox txtHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
                PerpetuumSoft.Reporting.DOM.TextBox textSubHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
                PerpetuumSoft.Reporting.DOM.TextBox txtDetail = new PerpetuumSoft.Reporting.DOM.TextBox();

                FontDescriptor fontHead = new FontDescriptor("Times New Roman", 9, FontStyleMode.On, FontStyleMode.Off,
                    FontStyleMode.Off);

                Header headerPage = (Header) doc.ControlByName("headerPage");
                Header header = (Header) doc.ControlByName("HeaderGroup");
                Header header3 = (Header) doc.ControlByName("HeaderSubGroup");
                Detail detail = (Detail) doc.ControlByName("DetailGroup");
                PageHeader pageHeader = (PageHeader) doc.ControlByName("ReportHeader");
                header.Controls.Clear();
                header3.Controls.Clear();
                detail.Controls.Clear();

                //header.StyleName = "HeaderFooter1";
                //header3.StyleName = "HeaderFooter1";
                Border oBorder = new Border();
                BorderLine oBorderLine = new BorderLine();
                oBorderLine.Width = 1;
                oBorderLine.Color = System.Drawing.Color.Black;
                oBorderLine.Style = PerpetuumSoft.Framework.Drawing.LineStyle.Solid;
                oBorder = new Border(oBorderLine, oBorderLine, oBorderLine, oBorderLine);

                string columnName = "";
                string columnAlias = "";
                string subHeader = "";
                double width = 0;
                double height = 0;
                double xPos = pmargin;
                ;
                double yPos = 0;
                string alignment = "";
                int countcolumn = 0;
                double widthDynamic = 0;
                double widthPlus = 0;
                //Tạo header
                foreach (DataRow dr in dtSource.Rows)
                {
                    columnName = dr["PayrollItemColumnID"].ToString();
                    columnAlias = dr["TitleColumn"].ToString();
                    subHeader = dr["SubHeader"].ToString();
                    width = Double.Parse(dr["Width"].ToString());
                    height = Double.Parse(dr["Height"].ToString());
                    alignment = dr["Alignment"].ToString();

                    ///xét Ypos theo collevel
                    if (dr["ColLevel"].ToString() == "0")
                    {
                        yPos = 0;
                    }
                    txtHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
                    txtHeader.Name = "txtHeader" + columnName;
                    txtHeader.Text = columnAlias;
                    header.Controls.Add(txtHeader);
                    txtHeader.Location = new Vector(xPos, yPos).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                    txtHeader.Size = new Vector(width, height).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                    txtHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    txtHeader.CanGrow = txtHeader.CanShrink = txtHeader.GrowToBottom = false;
                    txtHeader.Border = oBorder;
                    txtHeader.Font = fontHead;
                    if (dr["IsDetail"].ToString() == "False")
                    {
                        widthDynamic = width;
                    }
                    //tạo subheader và detail
                    if (dr["IsDetail"].ToString() == "True")
                    {

                        textSubHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
                        textSubHeader.Name = "txtSubHeader" + columnName;
                        textSubHeader.Text = subHeader;
                        header3.Controls.Add(textSubHeader);
                        textSubHeader.Location = new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textSubHeader.Size = new Vector(width, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textSubHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        textSubHeader.CanGrow = textSubHeader.CanShrink = textSubHeader.GrowToBottom = true;
                        textSubHeader.Border = oBorder;
                        textSubHeader.Font = fontHead;

                        txtDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
                        txtDetail.Name = "txtDetail" + columnName;
                        txtDetail.Text = "";
                        detail.Controls.Add(txtDetail);
                        txtDetail.Location = new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        txtDetail.Size = new Vector(width, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);

                        txtDetail.CanGrow = txtDetail.CanShrink = txtDetail.GrowToBottom = true;
                        txtDetail.Border = oBorder;

                        if (dr["DataType"].ToString() == "3")
                        {
                            txtDetail.GenerateScript = txtDetail.Name + ".Value=decimal.Parse(GetData(\"" +
                                                       columnName + "\").ToString()) ==0 ?\"\" : " + "GetData(\"" +
                                                       columnName + "\").ToString();"
                                                       + txtDetail.Name + ".TextFormat = "
                                                       + "(PerpetuumSoft.Framework.Text.TextFormat) GetData(\"RssObject.CurrencyFormat\");" +
                                                       txtDetail.Name +
                                                       ".TextAlign = System.Drawing.ContentAlignment." + alignment + ";"
                                                       + "if(GetData(\"IsBold\").ToString()==\"True\") "
                                                       + "{" + txtDetail.Name + ".StyleName  =  \"DetailNormalBold\";}"
                                                       + "else {" + txtDetail.Name + ".StyleName =  \"DetailNormal\";}";
                        }
                        else
                        {
                            txtDetail.GenerateScript = txtDetail.Name + ".Value=GetData(\"" +
                                                       columnName + "\").ToString();"
                                                       + txtDetail.Name + ".TextFormat = "
                                                       + "(PerpetuumSoft.Framework.Text.TextFormat) GetData(\"RssObject.CurrencyFormat\");" +
                                                       txtDetail.Name +
                                                       ".TextAlign = System.Drawing.ContentAlignment." + alignment + ";"
                                                       + "if(GetData(\"IsBold\").ToString()==\"True\") "
                                                       + "{" + txtDetail.Name + ".StyleName  =  \"DetailNormalBold\";}"
                                                       + "else {" + txtDetail.Name + ".StyleName =  \"DetailNormal\";}";

                        }


                        xPos = xPos + width;
                        if (dr["IsDynamic"].ToString() == "True")
                        {
                            widthPlus = widthPlus + width;
                        }
                    }

                    if (dr["ColLevel"].ToString() == "0")
                    {
                        yPos = height;
                    }

                }
                //Gen nốt cột trống trên template
                while (widthPlus < widthDynamic)
                {
                    txtHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
                    txtHeader.Name = "txtHeader" + columnName + countcolumn;
                    header.Controls.Add(txtHeader);
                    txtHeader.Location = new Vector(xPos, yPos).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                    txtHeader.Size = new Vector(width, height).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                    txtHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    txtHeader.CanGrow = txtHeader.CanShrink = txtHeader.GrowToBottom = false;
                    txtHeader.Border = oBorder;
                    txtHeader.Font = fontHead;

                    textSubHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
                    textSubHeader.Name = "txtSubHeader" + columnName + countcolumn;
                    header3.Controls.Add(textSubHeader);
                    textSubHeader.Location = new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                    textSubHeader.Size = new Vector(width, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                    textSubHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    textSubHeader.CanGrow = textSubHeader.CanShrink = textSubHeader.GrowToBottom = true;
                    textSubHeader.Border = oBorder;
                    textSubHeader.Font = fontHead;

                    txtDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
                    txtDetail.Name = "txtDetail" + columnName + countcolumn;
                    txtDetail.Text = "";
                    detail.Controls.Add(txtDetail);
                    txtDetail.Location = new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                    txtDetail.Size = new Vector(width, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);

                    txtDetail.CanGrow = txtDetail.CanShrink = txtDetail.GrowToBottom = true;
                    txtDetail.Border = oBorder;

                    xPos = xPos + width;
                    countcolumn = countcolumn + 1;
                    widthPlus = widthPlus + width;
                }

                reportSlot.SaveReport(doc);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public bool RenderDynamicReportMultiPage(DataTable dtSource, string ReportFileName, double pmargin)
        {

            try
            {
                var reportSlot = new FileReportSlot {FilePath = GlobalVariable.ReportPath + ReportFileName};

                Document doc = reportSlot.LoadReport();


                int pag = doc.Pages.Count;
               
                while(doc.Pages.Count >1)
                {
                    doc.Pages.RemoveAt(1);
                }


                PerpetuumSoft.Reporting.DOM.TextBox txtHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
                PerpetuumSoft.Reporting.DOM.TextBox textSubHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
                PerpetuumSoft.Reporting.DOM.TextBox txtDetail = new PerpetuumSoft.Reporting.DOM.TextBox();

                FontDescriptor fontHead = new FontDescriptor("Times New Roman", 9, FontStyleMode.On, FontStyleMode.Off,
                    FontStyleMode.Off);

                Header headerPage = (Header) doc.ControlByName("headerPage");
                Header header1 = (Header) doc.ControlByName("header1");
                DataBand dBand = (DataBand) doc.ControlByName("dbSalary");
                GroupBand gBand = (GroupBand) doc.ControlByName("groupSalary");

                Header header = (Header) doc.ControlByName("HeaderGroup");
                Header header3 = (Header) doc.ControlByName("HeaderSubGroup");
                Detail detail = (Detail) doc.ControlByName("DetailGroup");

                PageHeader pageHeader = (PageHeader) doc.ControlByName("ReportHeader");

                PageFooter pageFooter = (PageFooter) doc.ControlByName("pageFooter");
             

                header.Controls.Clear();
                header3.Controls.Clear();
                detail.Controls.Clear();


                Border oBorder = new Border();
                BorderLine oBorderLine = new BorderLine();
                oBorderLine.Width = 1;
                oBorderLine.Color = System.Drawing.Color.Black;
                oBorderLine.Style = PerpetuumSoft.Framework.Drawing.LineStyle.Solid;
                oBorder = new Border(oBorderLine, oBorderLine, oBorderLine, oBorderLine);

                string columnName = "";
                string columnAlias = "";
                string subHeader = "";

                string alignment = "";
                int countcolumn = 0;

                double width = 0;
                double height = 0;
                double xPos = pmargin;
                double yPos = 0;
                double widthDynamic = 0;
                double widthPlus = 0;

                int dataType = 0;
                DataTable dtFixColumn = new DataTable();
                DataTable dtDynamicGroupColumn = new DataTable();
                DataTable dtDynamicDetailColumn = new DataTable();
                int countGroupPage = 0;

                //Lấy những cột fix cố định ở các trang báo cáo 
                var objFixColumn = dtSource.AsEnumerable().Where(x =>
                    x.Field<bool>("IsDetail") == true && x.Field<bool>("IsDynamic") == false);
                if (objFixColumn.Any())
                {
                    dtFixColumn = objFixColumn.CopyToDataTable();
                }
                //Lấy những cột group gen động 
                var objDynamicGroupColumn = dtSource.AsEnumerable().Where(x =>
                    x.Field<bool>("IsDetail") == false && x.Field<bool>("IsDynamic") == true);
                if (objDynamicGroupColumn.Any())
                {
                    dtDynamicGroupColumn = objDynamicGroupColumn.CopyToDataTable();
                }

                foreach (DataRow drDynamic in dtDynamicGroupColumn.Rows) //mỗi 1 group gen động tạo ra 1 trang mới
                {
                    if (countGroupPage == 0)
                    {
                        width = 0;
                        height = 0;
                        xPos = pmargin;
                        yPos = 0;
                        widthDynamic = 0;
                        widthPlus = 0;
                        ///Add cột fix
                        foreach (DataRow drFix in dtFixColumn.Rows)
                        {
                            columnName = drFix["PayrollItemColumnID"].ToString();
                            columnAlias = drFix["TitleColumn"].ToString();
                            subHeader = drFix["SubHeader"].ToString();
                            width = Double.Parse(drFix["Width"].ToString());
                            height = Double.Parse(drFix["Height"].ToString());
                            alignment = drFix["Alignment"].ToString();
                            dataType = int.Parse(drFix["DataType"].ToString());
                            //tạo header
                            txtHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
                            txtHeader.Name = "txtHeader" + columnName + countGroupPage;
                            txtHeader.Text = columnAlias;
                            header.Controls.Add(txtHeader);
                            txtHeader.Location =
                                new Vector(xPos, yPos).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            txtHeader.Size = new Vector(width, height).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            txtHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            txtHeader.CanGrow = txtHeader.CanShrink = txtHeader.GrowToBottom = false;
                            txtHeader.Border = oBorder;
                            txtHeader.Font = fontHead;

                            //tạo subheader
                            textSubHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
                            textSubHeader.Name = "txtSubHeader" + columnName + countGroupPage;
                            textSubHeader.Text = subHeader;
                            header3.Controls.Add(textSubHeader);
                            textSubHeader.Location =
                                new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textSubHeader.Size =
                                new Vector(width, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textSubHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            textSubHeader.CanGrow = textSubHeader.CanShrink = textSubHeader.GrowToBottom = true;
                            textSubHeader.Border = oBorder;
                            textSubHeader.Font = fontHead;

                            //Tạo detail
                            txtDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
                            txtDetail.Name = "txtDetail" + columnName + countGroupPage;
                            txtDetail.Text = "";
                            detail.Controls.Add(txtDetail);
                            txtDetail.Location = new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            txtDetail.Size = new Vector(width, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            txtDetail.CanGrow = false;
                            txtDetail.CanShrink = false;
                            txtDetail.GrowToBottom = false;
                            txtDetail.Border = oBorder;

                            if (dataType == 3)
                            {
                                txtDetail.GenerateScript = txtDetail.Name + ".Value=decimal.Parse(GetData(\"" +
                                                            columnName + "\").ToString()) ==0 ?(object)null: " +
                                                            " decimal.Parse(GetData(\"" + columnName + "\").ToString());"
                                                           + txtDetail.Name + ".TextFormat = "
                                                           + "(PerpetuumSoft.Framework.Text.TextFormat) GetData(\"RssObject.CurrencyFormat\");" +
                                                           txtDetail.Name +
                                                           ".TextAlign = System.Drawing.ContentAlignment." +
                                                           alignment +
                                                           ";"
                                                           + "if(GetData(\"IsBold\").ToString()==\"True\") "
                                                           + "{" + txtDetail.Name +
                                                           ".StyleName  =  \"DetailNormalBold\";}"
                                                           + "else {" + txtDetail.Name +
                                                           ".StyleName =  \"DetailNormal\";}";
                            }
                            else
                            {

                                if(txtDetail.Name.Equals("txtDetailReportItemAlias0"))
                                txtDetail.GenerateScript = txtDetail.Name + ".Value= GetData(\"ReportItemAlias\").ToString();"+
                                                            //+ txtDetail.Name + ".TextFormat = " +
                                                            //+ "(PerpetuumSoft.Framework.Text.TextFormat) GetData(\"RssObject.CurrencyFormat\");" +
                                                           txtDetail.Name +
                                                            ".TextAlign = System.Drawing.ContentAlignment." +
                                                            alignment +
                                                            ";"
                                                            + "if(GetData(\"IsBold\").ToString()==\"True\") "
                                                            + "{" + txtDetail.Name +
                                                            ".StyleName  =  \"DetailNormalBold\";}"
                                                            + "else {" + txtDetail.Name +
                                                            ".StyleName =  \"DetailNormal\";}";
                                else
                                    txtDetail.GenerateScript = txtDetail.Name + ".Value=GetData(\"" +
                                                               columnName + "\").ToString();"
                                                               + txtDetail.Name + ".TextFormat = "
                                                               + "(PerpetuumSoft.Framework.Text.TextFormat) GetData(\"RssObject.CurrencyFormat\");" +
                                                               txtDetail.Name +
                                                               ".TextAlign = System.Drawing.ContentAlignment." +
                                                               alignment +
                                                               ";"
                                                               + "if(GetData(\"IsBold\").ToString()==\"True\") "
                                                               + "{" + txtDetail.Name +
                                                               ".StyleName  =  \"DetailNormalBold\";}"
                                                               + "else {" + txtDetail.Name +
                                                               ".StyleName =  \"DetailNormal\";}";
                            }

                            xPos = xPos + width;
                        }
                        //Add cột group động

                        columnName = drDynamic["PayrollItemColumnID"].ToString();
                        columnAlias = drDynamic["TitleColumn"].ToString();
                        subHeader = drDynamic["SubHeader"].ToString();
                        width = Double.Parse(drDynamic["Width"].ToString());
                        height = Double.Parse(drDynamic["Height"].ToString());
                        alignment = drDynamic["Alignment"].ToString();

                        //tạo header
                        txtHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
                        txtHeader.Name = "txtHeader" + columnName + countGroupPage;
                        txtHeader.Text = columnAlias;
                        header.Controls.Add(txtHeader);
                        txtHeader.Location =
                            new Vector(xPos, yPos).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        txtHeader.Size = new Vector(width, height).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        txtHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        txtHeader.CanGrow = txtHeader.CanShrink = txtHeader.GrowToBottom = false;
                        txtHeader.Border = oBorder;
                        txtHeader.Font = fontHead;
                        yPos = height;
                        widthDynamic = width;
                        //Add cột detail động
                        var objDynamicDetailColumn = dtSource.AsEnumerable().Where(x =>
                            x.Field<string>("ParentID") == drDynamic["PayrollItemColumnID"].ToString()).ToList();
                        //phân trang 4 detail trên 1 báo cáo

                        int surPlus = (objDynamicDetailColumn.ToList().Count - 4) % 10;
                        int pageIndex =
                            (objDynamicDetailColumn.Count - 4) / 10;
                        if (surPlus > 0) pageIndex = pageIndex + 2;
                        else pageIndex = pageIndex + 1;
                        for (int n = 1; n <= pageIndex; n++)
                        {

                            if (objDynamicDetailColumn.Any())
                            {
                                if (n == 1)
                                {
                                    dtDynamicDetailColumn = objDynamicDetailColumn.Skip(0).Take(4).CopyToDataTable();
                                    foreach (DataRow drDetail in dtDynamicDetailColumn.Rows)
                                    {
                                        if (drDetail["IsDetail"].ToString() == "True")
                                        {
                                            columnName = drDetail["PayrollItemColumnID"].ToString();
                                            columnAlias = drDetail["TitleColumn"].ToString();
                                            subHeader = drDetail["SubHeader"].ToString();
                                            width = Double.Parse(drDetail["Width"].ToString());
                                            height = Double.Parse(drDetail["Height"].ToString());
                                            alignment = drDetail["Alignment"].ToString();

                                            txtHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
                                            txtHeader.Name = "txtHeader" + columnName;
                                            txtHeader.Text = columnAlias;
                                            header.Controls.Add(txtHeader);
                                            txtHeader.Location =
                                                new Vector(xPos, yPos).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                            txtHeader.Size =
                                                new Vector(width, height).ConvertUnits(Unit.Centimeter,
                                                    Unit.InternalUnit);
                                            txtHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                            txtHeader.CanGrow = txtHeader.CanShrink = txtHeader.GrowToBottom = false;
                                            txtHeader.Border = oBorder;
                                            txtHeader.Font = fontHead;

                                            textSubHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
                                            textSubHeader.Name = "txtSubHeader" + columnName;
                                            textSubHeader.Text = subHeader;
                                            header3.Controls.Add(textSubHeader);
                                            textSubHeader.Location =
                                                new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                            textSubHeader.Size =
                                                new Vector(width, 0.6f).ConvertUnits(Unit.Centimeter,
                                                    Unit.InternalUnit);
                                            textSubHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                            textSubHeader.CanGrow =
                                                textSubHeader.CanShrink = textSubHeader.GrowToBottom = true;
                                            textSubHeader.Border = oBorder;
                                            textSubHeader.Font = fontHead;

                                            txtDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
                                            txtDetail.Name = "txtDetail" + columnName;
                                            txtDetail.Text = "";
                                            detail.Controls.Add(txtDetail);
                                            txtDetail.Location =
                                                new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                            txtDetail.Size =
                                                new Vector(width, 0.6f).ConvertUnits(Unit.Centimeter,
                                                    Unit.InternalUnit);

                                            txtDetail.CanGrow = false;
                                            txtDetail.CanShrink =  false;
                                            txtDetail.GrowToBottom = false;
                                            txtDetail.Border = oBorder;

                                            if (drDetail["DataType"].ToString() == "3")
                                            {
                                                txtDetail.GenerateScript =
                                                    txtDetail.Name + ".Value=decimal.Parse(GetData(\"" +
                                                    columnName + "\").ToString()) ==0 ?(object)null: " +
                                                    "decimal.Parse(GetData(\"" + columnName + "\").ToString());"
                                                    + txtDetail.Name + ".TextFormat = "
                                                    + "(PerpetuumSoft.Framework.Text.TextFormat) GetData(\"RssObject.CurrencyFormat\");" +
                                                    txtDetail.Name +
                                                    ".TextAlign = System.Drawing.ContentAlignment." +
                                                    alignment + ";"
                                                    + "if(GetData(\"IsBold\").ToString()==\"True\") "
                                                    + "{" + txtDetail.Name +
                                                    ".StyleName  =  \"DetailNormalBold\";}"
                                                    + "else {" + txtDetail.Name +
                                                    ".StyleName =  \"DetailNormal\";}";
                                            }

                                            xPos = xPos + width;
                                            if (drDetail["IsDynamic"].ToString() == "True")
                                            {
                                                widthPlus = widthPlus + width;
                                            }
                                        }
                                    }

                                    while (widthPlus < widthDynamic)
                                    {
                                        txtHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
                                        txtHeader.Name = "txtHeaderP" + countGroupPage + countcolumn;
                                        header.Controls.Add(txtHeader);
                                        txtHeader.Location =
                                            new Vector(xPos, yPos).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                        txtHeader.Size =
                                            new Vector(width, height).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                        txtHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                        txtHeader.CanGrow = txtHeader.CanShrink = txtHeader.GrowToBottom = false;
                                        txtHeader.Border = oBorder;
                                        txtHeader.Font = fontHead;

                                        textSubHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
                                        textSubHeader.Name = "txtSubHeaderP" + countGroupPage + countcolumn;
                                        header3.Controls.Add(textSubHeader);
                                        textSubHeader.Location =
                                            new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                        textSubHeader.Size =
                                            new Vector(width, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                        textSubHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                        textSubHeader.CanGrow =
                                            textSubHeader.CanShrink = textSubHeader.GrowToBottom = true;
                                        textSubHeader.Border = oBorder;
                                        textSubHeader.Font = fontHead;

                                        txtDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
                                        txtDetail.Name = "txtDetailP" + countGroupPage + countcolumn;
                                        txtDetail.Text = "";
                                        detail.Controls.Add(txtDetail);
                                        txtDetail.Location =
                                            new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                        txtDetail.Size =
                                            new Vector(width, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);

                                        txtDetail.CanGrow = false;
                                        txtDetail.CanShrink =  false;
                                        txtDetail.GrowToBottom = false;
                                        txtDetail.Border = oBorder;

                                        xPos = xPos + width;
                                        countcolumn = countcolumn + 1;
                                        widthPlus = widthPlus + width;
                                    }
                                    countGroupPage = countGroupPage + 1;
                                }
                                else
                                {
                                    #region tạo trang mới

                                    width = 0;
                                    height = 0;
                                    xPos = pmargin;
                                    yPos = 0;
                                    widthDynamic = 0;
                                    widthPlus = 0;
                                    //Khởi tạo page mới
                                    Page pageN = new Page();
                                    pageN.Orientation = PageOrientation.Landscape;
                                    pageN.Name = "page" + countGroupPage;

                                    //Khởi tạo DataBand mới
                                    DataBand dBandN = new DataBand();
                                    dBandN.DataSource = dBand.DataSource;
                                    dBandN.Size = dBand.Size;
                                    dBandN.Location = dBand.Location;
                                    dBandN.Name = dBand.Name + countGroupPage;
                                    dBandN.Controls.Clear();

                                    //Khởi tạo GroupBand mới
                                    GroupBand gBandN = new GroupBand();
                                    gBandN.GroupExpression = gBand.GroupExpression;
                                    gBandN.Location = gBand.Location;
                                    gBandN.Size = gBand.Size;
                                    gBandN.Name = gBand.Name + countGroupPage;
                                    gBandN.Controls.Clear();

                                    //Khởi tạo header,subheader,detail mới (lấy properties size,font,location theo header ở page 1  )
                                    Header header1N = new Header(); 
                                    header1N.Size = header1.Size;
                                    header1N.Location = header1.Location;
                                    header1N.CanGrow = header1.CanGrow;
                                    header1N.CanBreak = header1.CanBreak;
                                    header1N.CanShrink = header1.CanShrink;
                                    header1N.RepeatEveryPage = header1.RepeatEveryPage;
                                    header1N.Name = header1.Name + countGroupPage;



                                    Header headerN = new Header();
                                    headerN.Size = header.Size;
                                    headerN.Location = header.Location;
                                    headerN.CanGrow = header.CanGrow;
                                    headerN.CanBreak = header.CanBreak;
                                    headerN.CanShrink = header.CanShrink;
                                    headerN.RepeatEveryPage = header.RepeatEveryPage;
                                    headerN.Name = header.Name + countGroupPage;
                                    headerN.Controls.Clear();

                                    Header subHeaderN = new Header();
                                    subHeaderN.Location = header3.Location;
                                    subHeaderN.Size = header3.Size;
                                    subHeaderN.CanGrow = header3.CanGrow;
                                    subHeaderN.CanBreak = header3.CanBreak;
                                    subHeaderN.CanShrink = header3.CanShrink;
                                    subHeaderN.Name = header3.Name + countGroupPage;
                                    subHeaderN.RepeatEveryPage = header3.RepeatEveryPage;
                                    subHeaderN.Controls.Clear();

                                    Detail detailN = new Detail();
                                    detailN.Size = detail.Size;
                                    detailN.Location = detail.Location;
                                    detailN.CanGrow = detail.CanGrow;
                                    detailN.CanBreak = detail.CanBreak;
                                    detailN.CanShrink = detail.CanShrink;
                                    detailN.Name = detail.Name + countGroupPage;
                                    detailN.Controls.Clear();

                                    gBandN.Controls.Add(header1N);
                                    gBandN.Controls.Add(headerN);
                                    gBandN.Controls.Add(subHeaderN);
                                    gBandN.Controls.Add(detailN);

                                    dBandN.Controls.Add(gBandN);
                                    pageN.Controls.Add(dBandN);
                                    doc.Pages.Add(pageN);

                                    PerpetuumSoft.Reporting.DOM.TextBox txtHeaderN =
                                        new PerpetuumSoft.Reporting.DOM.TextBox();
                                    PerpetuumSoft.Reporting.DOM.TextBox textSubHeaderN =
                                        new PerpetuumSoft.Reporting.DOM.TextBox();
                                    PerpetuumSoft.Reporting.DOM.TextBox txtDetailN =
                                        new PerpetuumSoft.Reporting.DOM.TextBox();

                                    foreach (DataRow drFix in dtFixColumn.Rows)
                                    {
                                        columnName = drFix["PayrollItemColumnID"].ToString();
                                        columnAlias = drFix["TitleColumn"].ToString();
                                        subHeader = drFix["SubHeader"].ToString();
                                        width = Double.Parse(drFix["Width"].ToString());
                                        height = Double.Parse(drFix["Height"].ToString());
                                        alignment = drFix["Alignment"].ToString();

                                        //tạo header
                                        txtHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                        txtHeaderN.Name = "txtHeader" + columnName + countGroupPage;
                                        txtHeaderN.Text = columnAlias;
                                        headerN.Controls.Add(txtHeaderN);
                                        txtHeaderN.Location =
                                            new Vector(xPos, yPos).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                        txtHeaderN.Size =
                                            new Vector(width, height).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                        txtHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                        txtHeaderN.CanGrow = txtHeaderN.CanShrink = txtHeaderN.GrowToBottom = false;
                                        txtHeaderN.Border = oBorder;
                                        txtHeaderN.Font = fontHead;

                                        //tạo subheader
                                        textSubHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                        textSubHeaderN.Name = "txtSubHeader" + columnName + countGroupPage;
                                        textSubHeaderN.Text = subHeader;
                                        subHeaderN.Controls.Add(textSubHeaderN);
                                        textSubHeaderN.Location =
                                            new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                        textSubHeaderN.Size =
                                            new Vector(width, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                        textSubHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                        textSubHeaderN.CanGrow =
                                            textSubHeaderN.CanShrink = textSubHeaderN.GrowToBottom = true;
                                        textSubHeaderN.Border = oBorder;
                                        textSubHeaderN.Font = fontHead;

                                        //Tạo detail
                                        txtDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                        txtDetailN.Name = "txtDetail" + columnName + countGroupPage;
                                        txtDetailN.Text = "";
                                        detailN.Controls.Add(txtDetailN);
                                        txtDetailN.Location =
                                            new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                        txtDetailN.Size =
                                            new Vector(width, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                        txtDetailN.CanGrow = false;
                                        txtDetailN.CanShrink = false;
                                            txtDetailN.GrowToBottom = false;
                                        txtDetailN.Border = oBorder;

                                        txtDetailN.GenerateScript = txtDetailN.Name + ".Value=GetData(\"" +
                                                                    columnName + "\").ToString();"
                                                                    + txtDetailN.Name + ".TextFormat = "
                                                                    + "(PerpetuumSoft.Framework.Text.TextFormat) GetData(\"RssObject.CurrencyFormat\");" +
                                                                    txtDetailN.Name +
                                                                    ".TextAlign = System.Drawing.ContentAlignment." +
                                                                    alignment + ";"
                                                                    + "if(GetData(\"IsBold\").ToString()==\"True\") "
                                                                    + "{" + txtDetailN.Name +
                                                                    ".StyleName  =  \"DetailNormalBold\";}"
                                                                    + "else {" + txtDetailN.Name +
                                                                    ".StyleName =  \"DetailNormal\";}";

                                        xPos = xPos + width;
                                    }

                                    columnName = drDynamic["PayrollItemColumnID"].ToString();
                                    columnAlias = drDynamic["TitleColumn"].ToString();
                                    subHeader = drDynamic["SubHeader"].ToString();
                                    width = Double.Parse(drDynamic["Width"].ToString());
                                    height = Double.Parse(drDynamic["Height"].ToString());
                                    alignment = drDynamic["Alignment"].ToString();

                                    //tạo header
                                    txtHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                    txtHeaderN.Name = "txtHeader" + columnName + countGroupPage;
                                    txtHeaderN.Text = columnAlias;
                                    headerN.Controls.Add(txtHeaderN);
                                    txtHeaderN.Location =
                                        new Vector(xPos, yPos).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                    txtHeaderN.Size =
                                        new Vector(width, height).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                    txtHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                    txtHeaderN.CanGrow = txtHeaderN.CanShrink = txtHeaderN.GrowToBottom = false;
                                    txtHeaderN.Border = oBorder;
                                    txtHeaderN.Font = fontHead;
                                    yPos = height;
                                    widthDynamic = width;
                                    //Add cột detail động

                                    if (objDynamicDetailColumn.Any())
                                    {
                                        dtDynamicDetailColumn = objDynamicDetailColumn.Skip((n - 1) * 4).Take(4)
                                            .CopyToDataTable();


                                        foreach (DataRow drDetail in dtDynamicDetailColumn.Rows)
                                        {
                                            if (drDetail["IsDetail"].ToString() == "True")
                                            {
                                                columnName = drDetail["PayrollItemColumnID"].ToString();
                                                columnAlias = drDetail["TitleColumn"].ToString();
                                                subHeader = drDetail["SubHeader"].ToString();
                                                width = Double.Parse(drDetail["Width"].ToString());
                                                height = Double.Parse(drDetail["Height"].ToString());
                                                alignment = drDetail["Alignment"].ToString();

                                                txtHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                                txtHeaderN.Name = "txtHeader" + columnName;
                                                txtHeaderN.Text = columnAlias;
                                                headerN.Controls.Add(txtHeaderN);
                                                txtHeaderN.Location =
                                                    new Vector(xPos, yPos).ConvertUnits(Unit.Centimeter,
                                                        Unit.InternalUnit);
                                                txtHeaderN.Size =
                                                    new Vector(width, height).ConvertUnits(Unit.Centimeter,
                                                        Unit.InternalUnit);
                                                txtHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                                txtHeaderN.CanGrow = txtHeaderN.CanShrink =
                                                    txtHeaderN.GrowToBottom = false;
                                                txtHeaderN.Border = oBorder;
                                                txtHeaderN.Font = fontHead;

                                                textSubHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                                textSubHeaderN.Name = "txtSubHeader" + columnName;
                                                textSubHeaderN.Text = subHeader;
                                                subHeaderN.Controls.Add(textSubHeaderN);
                                                textSubHeaderN.Location =
                                                    new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter,
                                                        Unit.InternalUnit);
                                                textSubHeaderN.Size =
                                                    new Vector(width, 0.6f).ConvertUnits(Unit.Centimeter,
                                                        Unit.InternalUnit);
                                                textSubHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                                textSubHeaderN.CanGrow = false;
                                                textSubHeaderN.CanShrink = false;
                                                    textSubHeaderN.GrowToBottom = false;
                                                textSubHeaderN.Border = oBorder;
                                                textSubHeaderN.Font = fontHead;

                                                txtDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                                txtDetailN.Name = "txtDetail" + columnName;
                                                txtDetailN.Text = "";
                                                detailN.Controls.Add(txtDetailN);
                                                txtDetailN.Location =
                                                    new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter,
                                                        Unit.InternalUnit);
                                                txtDetailN.Size =
                                                    new Vector(width, 0.6f).ConvertUnits(Unit.Centimeter,
                                                        Unit.InternalUnit);

                                                txtDetailN.CanGrow = false;
                                                txtDetailN.CanShrink = false;
                                                    txtDetailN.GrowToBottom = false;
                                                txtDetailN.Border = oBorder;

                                                if (drDetail["DataType"].ToString() == "3")
                                                {
                                                    txtDetailN.GenerateScript =
                                                        txtDetailN.Name + ".Value=decimal.Parse(GetData(\"" +
                                                        columnName + "\").ToString()) ==0 ?(object)null : " +
                                                        "decimal.Parse(GetData(\"" + columnName + "\").ToString());"
                                                        + txtDetailN.Name + ".TextFormat = "
                                                        + "(PerpetuumSoft.Framework.Text.TextFormat) GetData(\"RssObject.CurrencyFormat\");" +
                                                        txtDetailN.Name +
                                                        ".TextAlign = System.Drawing.ContentAlignment." +
                                                        alignment + ";"
                                                        + "if(GetData(\"IsBold\").ToString()==\"True\") "
                                                        + "{" + txtDetailN.Name +
                                                        ".StyleName  =  \"DetailNormalBold\";}"
                                                        + "else {" + txtDetailN.Name +
                                                        ".StyleName =  \"DetailNormal\";}";
                                                }

                                                xPos = xPos + width;
                                                if (drDetail["IsDynamic"].ToString() == "True")
                                                {
                                                    widthPlus = widthPlus + width;
                                                }
                                            }
                                        }
                                        countcolumn = 0;
                                        while (widthPlus < widthDynamic)
                                        {
                                            txtHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                            txtHeaderN.Name = "txtHeaderN" + countGroupPage + countcolumn;
                                            headerN.Controls.Add(txtHeaderN);
                                            txtHeaderN.Location =
                                                new Vector(xPos, yPos).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                            txtHeaderN.Size =
                                                new Vector(width, height).ConvertUnits(Unit.Centimeter,
                                                    Unit.InternalUnit);
                                            txtHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                            txtHeaderN.CanGrow = txtHeader.CanShrink = txtHeader.GrowToBottom = false;
                                            txtHeaderN.Border = oBorder;
                                            txtHeaderN.Font = fontHead;

                                            textSubHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                            textSubHeaderN.Name = "txtSubHeaderN" + countGroupPage + countcolumn;
                                            subHeaderN.Controls.Add(textSubHeaderN);
                                            textSubHeaderN.Location =
                                                new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                            textSubHeaderN.Size =
                                                new Vector(width, 0.6f).ConvertUnits(Unit.Centimeter,
                                                    Unit.InternalUnit);
                                            textSubHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                            textSubHeaderN.CanGrow = true;
                                                textSubHeaderN.CanShrink = false;
                                                textSubHeaderN.GrowToBottom = true;
                                            textSubHeaderN.Border = oBorder;
                                            textSubHeaderN.Font = fontHead;

                                            txtDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                            txtDetailN.Name = "txtDetailN" + countGroupPage + countcolumn;
                                            txtDetailN.Text = "";
                                            detailN.Controls.Add(txtDetailN);
                                            txtDetailN.Location =
                                                new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                            txtDetailN.Size =
                                                new Vector(width, 0.6f).ConvertUnits(Unit.Centimeter,
                                                    Unit.InternalUnit);

                                            txtDetailN.CanGrow = false;
                                            txtDetailN.CanShrink = false;
                                            txtDetailN.GrowToBottom = false;
                                            txtDetailN.Border = oBorder;

                                            xPos = xPos + width;
                                            countcolumn = countcolumn + 1;
                                            widthPlus = widthPlus + width;
                                        }
                                    }

                                    #endregion
                                }
                            }

                        }

                    }
                    else
                    {
                        #region tạo trang mới

                        width = 0;
                        height = 0;
                        xPos = pmargin;
                        yPos = 0;
                        widthDynamic = 0;
                        widthPlus = 0;
                        //Khởi tạo page mới
                        Page pageN = new Page();
                        pageN.Orientation = PageOrientation.Landscape;
                        pageN.Name = "page" + countGroupPage;
                        pageN.Margins = new Margins(1f,1f,1f,1f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        pageN.GenerateScript = "iPageNumber=0;";

                        //Khởi tạo DataBand mới
                        DataBand dBandN = new DataBand();
                        dBandN.DataSource = dBand.DataSource;
                        dBandN.Size = dBand.Size;
                        dBandN.Location = dBand.Location;
                        dBandN.Name = dBand.Name + countGroupPage;
                        dBandN.Controls.Clear();

                        //Khởi tạo GroupBand mới
                        GroupBand gBandN = new GroupBand();
                        gBandN.GroupExpression = gBand.GroupExpression;
                        gBandN.Location = gBand.Location;
                        gBandN.Size = gBand.Size;
                        gBandN.NewPageBefore = true;
                        gBandN.Name = gBand.Name + countGroupPage;
                        gBandN.Controls.Clear();

                        Header headerPageN = new Header();
                        headerPageN.Size = headerPage.Size;
                        headerPageN.Location = headerPage.Location;
                        headerPageN.CanGrow = headerPage.CanGrow;
                        headerPageN.CanBreak = headerPage.CanBreak;
                        headerPageN.CanShrink = headerPage.CanShrink;
                        headerPageN.NewPageAfter = headerPage.NewPageAfter;
                        headerPageN.NewPageBefore = headerPage.NewPageBefore;
                        headerPageN.RepeatEveryPage = headerPage.RepeatEveryPage;
                        headerPageN.Name = headerPage.Name + countGroupPage;


                        Header headerN = new Header();
                        headerN.Size = header.Size;
                        headerN.Location = header.Location;
                        headerN.CanGrow = header.CanGrow;
                        headerN.CanBreak = header.CanBreak;
                        headerN.CanShrink = header.CanShrink;
                        headerN.NewPageAfter = header.NewPageAfter;
                        headerN.NewPageBefore = header.NewPageBefore;
                        headerN.RepeatEveryPage = header.RepeatEveryPage;
                        headerN.Name = header.Name + countGroupPage;
                        headerN.Controls.Clear();

                        Header subHeaderN = new Header();
                        subHeaderN.Location = header3.Location;
                        subHeaderN.Size = header3.Size;
                        subHeaderN.CanGrow = header3.CanGrow;
                        subHeaderN.CanBreak = header3.CanBreak;
                        subHeaderN.CanShrink = header3.CanShrink;
                        subHeaderN.RepeatEveryPage = header3.RepeatEveryPage;
                        subHeaderN.Name = header3.Name + countGroupPage;
                        subHeaderN.Controls.Clear();

                        Detail detailN = new Detail();
                        detailN.Size = detail.Size;
                        detailN.Location = detail.Location;
                        detailN.CanGrow = detail.CanGrow;
                        detailN.CanBreak = detail.CanBreak;
                        detailN.CanShrink = detail.CanShrink;
                        detailN.Name = detail.Name + countGroupPage;
                        detailN.GenerateScript = "iPageNumber+=1;";
                        detailN.Controls.Clear();

                        Header header1N = new Header();
                        header1N.Size = header1.Size;
                        header1N.Location = header1.Location;
                        header1N.CanGrow = header1.CanGrow;
                        header1N.CanBreak = header1.CanBreak;
                        header1N.CanShrink = header1.CanShrink;
                        header1N.Name = header1.Name + countGroupPage;

                        gBandN.Controls.Add(headerPageN);
                        gBandN.Controls.Add(header1N);
                        gBandN.Controls.Add(headerN);
                        gBandN.Controls.Add(subHeaderN);
                        gBandN.Controls.Add(detailN);

                        dBandN.Controls.Add(gBandN);

                        PageHeader pageHeaderN = new PageHeader();
                        pageHeaderN.Location = pageHeader.Location;
                        pageHeaderN.Size = pageHeader.Size;
                        pageHeaderN.Mode = pageHeader.Mode;
                        pageHeaderN.Name = "pageHeader" + countGroupPage;
                        pageHeaderN.Visible = false;


                        PageFooter pageFooterN = new PageFooter();
                        pageFooterN.Location = pageFooter.Location;
                        pageFooterN.Size = pageFooter.Size;
                        pageFooterN.Mode = pageFooter.Mode;
                        pageFooterN.CanGrow = pageFooter.CanGrow;
                        pageFooterN.CanShrink = pageFooter.CanShrink;
                        pageFooterN.Name = "pageFooter"+ countGroupPage;

                        pageN.Controls.Add(pageHeaderN);
                        pageN.Controls.Add(pageFooterN);
                        pageN.Controls.Add(dBandN);
                        doc.Pages.Add(pageN);

                        PerpetuumSoft.Reporting.DOM.TextBox txtHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                        PerpetuumSoft.Reporting.DOM.TextBox textSubHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                        PerpetuumSoft.Reporting.DOM.TextBox txtDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                        PerpetuumSoft.Reporting.DOM.TextBox txtPageFooterN = new PerpetuumSoft.Reporting.DOM.TextBox();
                        PerpetuumSoft.Reporting.DOM.TextBox txtLabelHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();


                        txtLabelHeaderN.Size = new Vector(9.4f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        txtLabelHeaderN.Location = new Vector(19.3f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        txtLabelHeaderN.Name = "txtLabelN" + countGroupPage;
                        txtLabelHeaderN.Font = new FontDescriptor("Times New Roman",9.75f);
                        txtLabelHeaderN.TextAlign = ContentAlignment.MiddleRight;
                        txtLabelHeaderN.GenerateScript = txtLabelHeaderN.Name + ".Value =\"Trang "+(countGroupPage+1) + "/ " + "\"" + "+(PageNumber -(iLineNumber*" + countGroupPage + ")).ToString();";
                           // txtLabelHeaderN.Name + ".Value= GetData(\"BudgetChapterCode\") == null ? \"Mã Chương: \" :\"Mã Chương: \" + GetData(\"BudgetChapterCode\").ToString();";
                        pageFooterN.Controls.Add(txtLabelHeaderN);

                        foreach (DataRow drFix in dtFixColumn.Rows)
                        {
                            columnName = drFix["PayrollItemColumnID"].ToString();
                            columnAlias = drFix["TitleColumn"].ToString();
                            subHeader = drFix["SubHeader"].ToString();
                            width = Double.Parse(drFix["Width"].ToString());
                            height = Double.Parse(drFix["Height"].ToString());
                            alignment = drFix["Alignment"].ToString();
                            dataType = int.Parse(drFix["DataType"].ToString());

                            //tạo header
                            txtHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                            txtHeaderN.Name = "txtHeader" + columnName + countGroupPage;
                            txtHeaderN.Text = columnAlias;
                            headerN.Controls.Add(txtHeaderN);
                            txtHeaderN.Location =
                                new Vector(xPos, yPos).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            txtHeaderN.Size =
                                new Vector(width, height).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            txtHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            txtHeaderN.CanGrow = txtHeaderN.CanShrink = txtHeaderN.GrowToBottom = false;
                            txtHeaderN.Border = oBorder;
                            txtHeaderN.Font = fontHead;

                            //tạo subheader
                            textSubHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                            textSubHeaderN.Name = "txtSubHeader" + columnName + countGroupPage;
                            textSubHeaderN.Text = subHeader;
                            subHeaderN.Controls.Add(textSubHeaderN);
                            textSubHeaderN.Location =
                                new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textSubHeaderN.Size =
                                new Vector(width, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textSubHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            textSubHeaderN.CanGrow = textSubHeaderN.CanShrink = textSubHeaderN.GrowToBottom = true;
                            textSubHeaderN.Border = oBorder;
                            textSubHeaderN.Font = fontHead;

                            //Tạo detail
                            txtDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                            txtDetailN.Name = "txtDetail" + columnName + countGroupPage;
                            txtDetailN.Text = "";
                            detailN.Controls.Add(txtDetailN);
                            txtDetailN.Location = new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            txtDetailN.Size = new Vector(width, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            txtDetailN.CanGrow = false;
                            txtDetailN.CanShrink = false;
                            txtDetail.GrowToBottom = false;
                            txtDetailN.Border = oBorder;
                            if (dataType == 3)
                            {
                                txtDetailN.GenerateScript = txtDetailN.Name + ".Value=decimal.Parse(GetData(\"" +
                                                            columnName + "\").ToString()) ==0 ? (object)null : " +
                                                            "decimal.Parse(GetData(\"" + columnName + "\").ToString());"
                                                           + txtDetailN.Name + ".TextFormat = "
                                                           + "(PerpetuumSoft.Framework.Text.TextFormat) GetData(\"RssObject.CurrencyFormat\");" +
                                                           txtDetailN.Name +
                                                           ".TextAlign = System.Drawing.ContentAlignment." +
                                                           alignment +
                                                           ";"
                                                           + "if(GetData(\"IsBold\").ToString()==\"True\") "
                                                           + "{" + txtDetailN.Name +
                                                           ".StyleName  =  \"DetailNormalBold\";}"
                                                           + "else {" + txtDetailN.Name +
                                                           ".StyleName =  \"DetailNormal\";}";
                            }
                            else
                            {


                                txtDetailN.GenerateScript = txtDetailN.Name + ".Value=GetData(\"" +
                                                            columnName + "\").ToString();"
                                                            + txtDetailN.Name + ".TextFormat = "
                                                            + "(PerpetuumSoft.Framework.Text.TextFormat) GetData(\"RssObject.CurrencyFormat\");" +
                                                            txtDetailN.Name +
                                                            ".TextAlign = System.Drawing.ContentAlignment." +
                                                            alignment +
                                                            ";"
                                                            + "if(GetData(\"IsBold\").ToString()==\"True\") "
                                                            + "{" + txtDetailN.Name +
                                                            ".StyleName  =  \"DetailNormalBold\";}"
                                                            + "else {" + txtDetailN.Name +
                                                            ".StyleName =  \"DetailNormal\";}";
                            }
                            xPos = xPos + width;
                        }

                        columnName = drDynamic["PayrollItemColumnID"].ToString();
                        columnAlias = drDynamic["TitleColumn"].ToString();
                        subHeader = drDynamic["SubHeader"].ToString();
                        width = Double.Parse(drDynamic["Width"].ToString());
                        height = Double.Parse(drDynamic["Height"].ToString());
                        alignment = drDynamic["Alignment"].ToString();


                        //tạo header
                        txtHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                        txtHeaderN.Name = "txtHeader" + columnName + countGroupPage;
                        txtHeaderN.Text = columnAlias;
                        headerN.Controls.Add(txtHeaderN);
                        txtHeaderN.Location =
                            new Vector(xPos, yPos).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        txtHeaderN.Size = new Vector(width, height).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        txtHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        txtHeaderN.CanGrow = txtHeaderN.CanShrink = txtHeaderN.GrowToBottom = false;
                        txtHeaderN.Border = oBorder;
                        txtHeaderN.Font = fontHead;
                        yPos = height;
                        widthDynamic = width;
                        //Add cột detail động
                        var objDynamicDetailColumnN = dtSource.AsEnumerable().Where(x =>
                            x.Field<string>("ParentID") == drDynamic["PayrollItemColumnID"].ToString()).ToList();

                        int surPlus = (objDynamicDetailColumnN.ToList().Count - 4) % 10;
                        int pageIndexN =
                            (objDynamicDetailColumnN.Count - 4) / 10;
                        if (surPlus > 0) pageIndexN = pageIndexN + 2;
                        else pageIndexN = pageIndexN + 1;

                        if (objDynamicDetailColumnN.Any())
                        {
                            for (int n = 1; n <= pageIndexN; n++)
                            {
                                if (n == 1)
                                {
                                    dtDynamicDetailColumn = objDynamicDetailColumnN.Skip(0).Take(4).CopyToDataTable();
                                    foreach (DataRow drDetail in dtDynamicDetailColumn.Rows)
                                    {
                                        if (drDetail["IsDetail"].ToString() == "True")
                                        {
                                            columnName = drDetail["PayrollItemColumnID"].ToString();
                                            columnAlias = drDetail["TitleColumn"].ToString();
                                            subHeader = drDetail["SubHeader"].ToString();
                                            width = Double.Parse(drDetail["Width"].ToString());
                                            height = Double.Parse(drDetail["Height"].ToString());
                                            alignment = drDetail["Alignment"].ToString();

                                            txtHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                            txtHeaderN.Name = "txtHeader" + columnName;
                                            txtHeaderN.Text = columnAlias;
                                            headerN.Controls.Add(txtHeaderN);
                                            txtHeaderN.Location =
                                                new Vector(xPos, yPos).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                            txtHeaderN.Size =
                                                new Vector(width, height).ConvertUnits(Unit.Centimeter,
                                                    Unit.InternalUnit);
                                            txtHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                            txtHeaderN.CanGrow = txtHeaderN.CanShrink = txtHeaderN.GrowToBottom = false;
                                            txtHeaderN.Border = oBorder;
                                            txtHeaderN.Font = fontHead;

                                            textSubHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                            textSubHeaderN.Name = "txtSubHeader" + columnName;
                                            textSubHeaderN.Text = subHeader;
                                            subHeaderN.Controls.Add(textSubHeaderN);
                                            textSubHeaderN.Location =
                                                new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                            textSubHeaderN.Size =
                                                new Vector(width, 0.6f).ConvertUnits(Unit.Centimeter,
                                                    Unit.InternalUnit);
                                            textSubHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                            textSubHeaderN.CanGrow = textSubHeaderN.CanShrink =
                                                textSubHeaderN.GrowToBottom = true;
                                            textSubHeaderN.Border = oBorder;
                                            textSubHeaderN.Font = fontHead;

                                            txtDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                            txtDetailN.Name = "txtDetail" + columnName;
                                            txtDetailN.Text = "";
                                            detailN.Controls.Add(txtDetailN);
                                            txtDetailN.Location =
                                                new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                            txtDetailN.Size =
                                                new Vector(width, 0.6f).ConvertUnits(Unit.Centimeter,
                                                    Unit.InternalUnit);

                                            txtDetailN.CanGrow = false;
                                                txtDetailN.CanShrink =  false;
                                            txtDetailN.GrowToBottom = false;
                                            txtDetailN.Border = oBorder;

                                            if (drDetail["DataType"].ToString() == "3")
                                            {
                                                txtDetailN.GenerateScript =
                                                    txtDetailN.Name + ".Value=decimal.Parse(GetData(\"" +
                                                    columnName + "\").ToString()) ==0 ?(object) null : " +
                                                    "decimal.Parse(GetData(\"" + columnName + "\").ToString());"
                                                    + txtDetailN.Name + ".TextFormat = "
                                                    + "(PerpetuumSoft.Framework.Text.TextFormat) GetData(\"RssObject.CurrencyFormat\");" +
                                                    txtDetailN.Name +
                                                    ".TextAlign = System.Drawing.ContentAlignment." +
                                                    alignment + ";"
                                                    + "if(GetData(\"IsBold\").ToString()==\"True\") "
                                                    + "{" + txtDetailN.Name +
                                                    ".StyleName  =  \"DetailNormalBold\";}"
                                                    + "else {" + txtDetailN.Name +
                                                    ".StyleName =  \"DetailNormal\";}";
                                            }

                                            xPos = xPos + width;
                                            if (drDetail["IsDynamic"].ToString() == "True")
                                            {
                                                widthPlus = widthPlus + width;
                                            }
                                        }                                        
                                    }

                                    countcolumn = 0;
                                    while (widthPlus < widthDynamic)
                                    {
                                        txtHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                        txtHeaderN.Name = "txtHeaderN" + countGroupPage + countcolumn;
                                        headerN.Controls.Add(txtHeaderN);
                                        txtHeaderN.Location =
                                            new Vector(xPos, yPos).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                        txtHeaderN.Size =
                                            new Vector(width, height).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                        txtHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                        txtHeaderN.CanGrow = txtHeader.CanShrink = txtHeader.GrowToBottom = false;
                                        txtHeaderN.Border = oBorder;
                                        txtHeaderN.Font = fontHead;

                                        textSubHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                        textSubHeaderN.Name = "txtSubHeaderN" + countGroupPage + countcolumn;
                                        subHeaderN.Controls.Add(textSubHeaderN);
                                        textSubHeaderN.Location =
                                            new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                        textSubHeaderN.Size =
                                            new Vector(width, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                        textSubHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                        textSubHeaderN.CanGrow =
                                            textSubHeaderN.CanShrink = textSubHeaderN.GrowToBottom = true;
                                        textSubHeaderN.Border = oBorder;
                                        textSubHeaderN.Font = fontHead;

                                        txtDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                        txtDetailN.Name = "txtDetailN" + countGroupPage + countcolumn;
                                        txtDetailN.Text = "";
                                        detailN.Controls.Add(txtDetailN);
                                        txtDetailN.Location =
                                            new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                        txtDetailN.Size =
                                            new Vector(width, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);

                                        txtDetailN.CanGrow = false;
                                        txtDetailN.CanShrink =  false;
                                        txtDetailN.GrowToBottom = false;
                                        txtDetailN.Border = oBorder;

                                        xPos = xPos + width;
                                        countcolumn = countcolumn + 1;
                                        widthPlus = widthPlus + width;
                                    }
                                }
                                else
                                {
                                    #region tạo trang mới

                                    width = 0;
                                    height = 0;
                                    xPos = pmargin;
                                    yPos = 0;
                                    widthDynamic = 0;
                                    widthPlus = 0;
                                    //Khởi tạo page mới
                                    Page pageN1 = new Page();
                                    pageN1.Orientation = PageOrientation.Landscape;
                                    pageN1.Name = "page" + countGroupPage;

                                    //Khởi tạo DataBand mới
                                    DataBand dBandN1 = new DataBand();
                                    dBandN1.DataSource = dBand.DataSource;
                                    dBandN1.Size = dBand.Size;
                                    dBandN1.Location = dBand.Location;
                                    dBandN1.Name = dBand.Name + countGroupPage;
                                    dBandN1.Controls.Clear();

                                    //Khởi tạo GroupBand mới
                                    GroupBand gBandN1 = new GroupBand();
                                    gBandN1.GroupExpression = gBand.GroupExpression;
                                    gBandN1.Location = gBand.Location;
                                    gBandN1.Size = gBand.Size;
                                    gBandN1.Name = gBand.Name + countGroupPage;
                                    gBandN1.Controls.Clear();
                                    //Khởi tạo header,subheader,detail mới (lấy properties size,font,location theo header ở page 1 chỉ đổi tên )

                                    Header header1N1 =  new Header();
                                    header1N1.Size = header1.Size;
                                   
                                    header1N1.Location = header1.Location;
                                    header1N1.CanGrow = header1.CanGrow;
                                    header1N1.CanBreak = header1.CanBreak;
                                    header1N1.CanShrink = header1.CanShrink;
                                    header1N1.RepeatEveryPage = header1.RepeatEveryPage;
                                    header1N1.Name = header1.Name + countGroupPage;

                                    Header headerN1 = new Header();
                                    headerN1.Size = header.Size;
                                    headerN1.Location = header.Location;
                                    headerN1.CanGrow = header.CanGrow;
                                    headerN1.CanBreak = header.CanBreak;
                                    headerN1.CanShrink = header.CanShrink;
                                    headerN1.RepeatEveryPage = header.RepeatEveryPage;
                                    headerN1.Name = header.Name + countGroupPage;
                                    headerN1.Controls.Clear();

                                    Header subHeaderN1 = new Header();
                                    subHeaderN1.Location = header3.Location;
                                    subHeaderN1.Size = header3.Size;
                                    subHeaderN1.CanGrow = header3.CanGrow;
                                    subHeaderN1.CanBreak = header3.CanBreak;
                                    subHeaderN1.CanShrink = header3.CanShrink;
                                    subHeaderN1.RepeatEveryPage = header3.RepeatEveryPage;
                                    subHeaderN1.Name = header3.Name + countGroupPage;
                                    subHeaderN1.Controls.Clear();

                                    Detail detailN1 = new Detail();
                                    detailN1.Size = detail.Size;
                                    detailN1.Location = detail.Location;
                                    detailN1.CanGrow = detail.CanGrow;
                                    detailN1.CanBreak = detail.CanBreak;
                                    detailN1.CanShrink = detail.CanShrink;
                                    detailN1.Name = detail.Name + countGroupPage;
                                    detailN1.Controls.Clear();

                                    gBandN.Controls.Add(header1N1);
                                    gBandN.Controls.Add(headerN);
                                    gBandN.Controls.Add(subHeaderN);
                                    gBandN.Controls.Add(detailN);

                                    dBandN.Controls.Add(gBandN);
                                    pageN.Controls.Add(dBandN);
                                    doc.Pages.Add(pageN);

                                    PerpetuumSoft.Reporting.DOM.TextBox txtHeaderN1 =
                                        new PerpetuumSoft.Reporting.DOM.TextBox();
                                    PerpetuumSoft.Reporting.DOM.TextBox textSubHeaderN1 =
                                        new PerpetuumSoft.Reporting.DOM.TextBox();
                                    PerpetuumSoft.Reporting.DOM.TextBox txtDetailN1 =
                                        new PerpetuumSoft.Reporting.DOM.TextBox();

                                    foreach (DataRow drFix in dtFixColumn.Rows)
                                    {
                                        columnName = drFix["PayrollItemColumnID"].ToString();
                                        columnAlias = drFix["TitleColumn"].ToString();
                                        subHeader = drFix["SubHeader"].ToString();
                                        width = Double.Parse(drFix["Width"].ToString());
                                        height = Double.Parse(drFix["Height"].ToString());
                                        alignment = drFix["Alignment"].ToString();

                                        //tạo header
                                        txtHeaderN1 = new PerpetuumSoft.Reporting.DOM.TextBox();
                                        txtHeaderN1.Name = "txtHeader" + columnName + countGroupPage + n;
                                        txtHeaderN1.Text = columnAlias;
                                        headerN1.Controls.Add(txtHeaderN1);
                                        txtHeaderN1.Location =
                                            new Vector(xPos, yPos).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                        txtHeaderN1.Size =
                                            new Vector(width, height).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                        txtHeaderN1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                        txtHeaderN1.CanGrow = txtHeaderN.CanShrink = txtHeaderN.GrowToBottom = false;
                                        txtHeaderN1.Border = oBorder;
                                        txtHeaderN1.Font = fontHead;

                                        //tạo subheader
                                        textSubHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                        textSubHeaderN.Name = "txtSubHeader" + columnName + countGroupPage;
                                        textSubHeaderN.Text = subHeader;
                                        subHeaderN.Controls.Add(textSubHeaderN);
                                        textSubHeaderN.Location =
                                            new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                        textSubHeaderN.Size =
                                            new Vector(width, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                        textSubHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                        textSubHeaderN.CanGrow =
                                        textSubHeaderN.CanShrink = textSubHeaderN.GrowToBottom = true;
                                        textSubHeaderN.Border = oBorder;
                                        textSubHeaderN.Font = fontHead;

                                        //Tạo detail
                                        txtDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                        txtDetailN.Name = "txtDetail" + columnName + countGroupPage;
                                        txtDetailN.Text = "";
                                        detailN.Controls.Add(txtDetailN);
                                        txtDetailN.Location =
                                            new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                        txtDetailN.Size =
                                            new Vector(width, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                        txtDetailN.CanGrow = txtDetailN.CanShrink = txtDetailN.GrowToBottom = true;
                                        txtDetailN.Border = oBorder;

                                        txtDetailN.GenerateScript = txtDetailN.Name + ".Value=GetData(\"" +
                                                                    columnName + "\").ToString();"
                                                                    + txtDetailN.Name + ".TextFormat = "
                                                                    + "(PerpetuumSoft.Framework.Text.TextFormat) GetData(\"RssObject.CurrencyFormat\");" +
                                                                    txtDetailN.Name +
                                                                    ".TextAlign = System.Drawing.ContentAlignment." +
                                                                    alignment + ";"
                                                                    + "if(GetData(\"IsBold\").ToString()==\"True\") "
                                                                    + "{" + txtDetailN.Name +
                                                                    ".StyleName  =  \"DetailNormalBold\";}"
                                                                    + "else {" + txtDetailN.Name +
                                                                    ".StyleName =  \"DetailNormal\";}";

                                        xPos = xPos + width;
                                    }

                                    columnName = drDynamic["PayrollItemColumnID"].ToString();
                                    columnAlias = drDynamic["TitleColumn"].ToString();
                                    subHeader = drDynamic["SubHeader"].ToString();
                                    width = Double.Parse(drDynamic["Width"].ToString());
                                    height = Double.Parse(drDynamic["Height"].ToString());
                                    alignment = drDynamic["Alignment"].ToString();

                                    //tạo header
                                    txtHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                    txtHeaderN.Name = "txtHeader" + columnName + countGroupPage;
                                    txtHeaderN.Text = columnAlias;
                                    headerN.Controls.Add(txtHeaderN);
                                    txtHeaderN.Location =
                                        new Vector(xPos, yPos).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                    txtHeaderN.Size =
                                        new Vector(width, height).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                    txtHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                    txtHeaderN.CanGrow = txtHeaderN.CanShrink = txtHeaderN.GrowToBottom = true;
                                    txtHeaderN.Border = oBorder;
                                    txtHeaderN.Font = fontHead;
                                    yPos = height;
                                    widthDynamic = width;
                                    //Add cột detail động

                                    if (objDynamicDetailColumnN.Any())
                                    {
                                        dtDynamicDetailColumn = objDynamicDetailColumnN.Skip((n - 1) * 4).Take(4)
                                            .CopyToDataTable();


                                        foreach (DataRow drDetail in dtDynamicDetailColumn.Rows)
                                        {
                                            if (drDetail["IsDetail"].ToString() == "True")
                                            {
                                                columnName = drDetail["PayrollItemColumnID"].ToString();
                                                columnAlias = drDetail["TitleColumn"].ToString();
                                                subHeader = drDetail["SubHeader"].ToString();
                                                width = Double.Parse(drDetail["Width"].ToString());
                                                height = Double.Parse(drDetail["Height"].ToString());
                                                alignment = drDetail["Alignment"].ToString();

                                                txtHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                                txtHeaderN.Name = "txtHeader" + columnName;
                                                txtHeaderN.Text = columnAlias;
                                                headerN.Controls.Add(txtHeaderN);
                                                txtHeaderN.Location =
                                                    new Vector(xPos, yPos).ConvertUnits(Unit.Centimeter,
                                                        Unit.InternalUnit);
                                                txtHeaderN.Size =
                                                    new Vector(width, height).ConvertUnits(Unit.Centimeter,
                                                        Unit.InternalUnit);
                                                txtHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                                txtHeaderN.CanGrow = true;
                                                txtHeaderN.CanShrink = true;
                                                txtHeaderN.GrowToBottom = true;
                                                txtHeaderN.Border = oBorder;
                                                txtHeaderN.Font = fontHead;

                                                textSubHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                                textSubHeaderN.Name = "txtSubHeader" + columnName;
                                                textSubHeaderN.Text = subHeader;
                                                subHeaderN.Controls.Add(textSubHeaderN);
                                                textSubHeaderN.Location =
                                                    new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter,
                                                        Unit.InternalUnit);
                                                textSubHeaderN.Size =
                                                    new Vector(width, 0.6f).ConvertUnits(Unit.Centimeter,
                                                        Unit.InternalUnit);
                                                textSubHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                                textSubHeaderN.CanGrow = true;
                                                textSubHeaderN.CanShrink = true;
                                                textSubHeaderN.GrowToBottom = true;
                                                textSubHeaderN.Border = oBorder;
                                                textSubHeaderN.Font = fontHead;

                                                txtDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                                txtDetailN.Name = "txtDetail" + columnName;
                                                txtDetailN.Text = "";
                                                detailN.Controls.Add(txtDetailN);
                                                txtDetailN.Location =
                                                    new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter,
                                                        Unit.InternalUnit);
                                                txtDetailN.Size =
                                                    new Vector(width, 0.6f).ConvertUnits(Unit.Centimeter,
                                                        Unit.InternalUnit);
                                                txtDetailN.CanGrow = false;
                                                txtDetailN.CanShrink = false;
                                                txtDetailN.GrowToBottom = false;
                                                txtDetailN.Border = oBorder;

                                                if (drDetail["DataType"].ToString() == "3")
                                                {
                                                    txtDetailN.GenerateScript =
                                                        txtDetailN.Name + ".Value=decimal.Parse(GetData(\"" +
                                                        columnName + "\").ToString()) ==0 ?(object)null : " +
                                                        "decimal.Parse(GetData(\"" + columnName + "\").ToString());"
                                                        + txtDetailN.Name + ".TextFormat = "
                                                        + "(PerpetuumSoft.Framework.Text.TextFormat) GetData(\"RssObject.CurrencyFormat\");" +
                                                        txtDetailN.Name +
                                                        ".TextAlign = System.Drawing.ContentAlignment." +
                                                        alignment + ";"
                                                        + "if(GetData(\"IsBold\").ToString()==\"True\") "
                                                        + "{" + txtDetailN.Name +
                                                        ".StyleName  =  \"DetailNormalBold\";}"
                                                        + "else {" + txtDetailN.Name +
                                                        ".StyleName =  \"DetailNormal\";}";
                                                }

                                                xPos = xPos + width;
                                                if (drDetail["IsDynamic"].ToString() == "True")
                                                {
                                                    widthPlus = widthPlus + width;
                                                }
                                            }
                                        }
                                        countcolumn = 0;
                                        while (widthPlus < widthDynamic)
                                        {
                                            txtHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                            txtHeaderN.Name = "txtHeaderN" + countGroupPage + countcolumn;
                                            headerN.Controls.Add(txtHeaderN);
                                            txtHeaderN.Location =
                                                new Vector(xPos, yPos).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                            txtHeaderN.Size =
                                                new Vector(width, height).ConvertUnits(Unit.Centimeter,
                                                    Unit.InternalUnit);
                                            txtHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                            txtHeaderN.CanGrow = txtHeader.CanShrink = txtHeader.GrowToBottom = true;
                                            txtHeaderN.Border = oBorder;
                                            txtHeaderN.Font = fontHead;

                                            textSubHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                            textSubHeaderN.Name = "txtSubHeaderN" + countGroupPage + countcolumn;
                                            subHeaderN.Controls.Add(textSubHeaderN);
                                            textSubHeaderN.Location =
                                                new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                            textSubHeaderN.Size =
                                                new Vector(width, 0.6f).ConvertUnits(Unit.Centimeter,
                                                    Unit.InternalUnit);
                                            textSubHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                            textSubHeaderN.CanGrow = textSubHeaderN.CanShrink =
                                                textSubHeaderN.GrowToBottom = true;
                                            textSubHeaderN.Border = oBorder;
                                            textSubHeaderN.Font = fontHead;

                                            txtDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                            txtDetailN.Name = "txtDetailN" + countGroupPage + countcolumn;
                                            txtDetailN.Text = "";
                                            detailN.Controls.Add(txtDetailN);
                                            txtDetailN.Location =
                                                new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                            txtDetailN.Size =
                                                new Vector(width, 0.6f).ConvertUnits(Unit.Centimeter,
                                                    Unit.InternalUnit);

                                            txtDetailN.CanGrow = false;
                                            txtDetailN.CanShrink = false;
                                            txtDetailN.GrowToBottom = false;
                                            txtDetailN.Border = oBorder;

                                            xPos = xPos + width;
                                            countcolumn = countcolumn + 1;
                                            widthPlus = widthPlus + width;
                                        }
                                    }
                                    #endregion
                                }
                            }
                            countGroupPage = countGroupPage + 1;
                        }
                        #endregion
                    }
                }
                reportSlot.SaveReport(doc);
                return true;
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }



        }
    }
}









































