/***********************************************************************
 * <copyright file="FrmXtraBaseParameter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Monday, August 25, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using BuCA.Application.iBigTime2020.Report.CommonClass;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using BuCA.Application.iBigTime2020.Session;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using System.Threading;

namespace BuCA.Application.iBigTime2020.Report.BaseParameterForm
{
    public partial class FrmXtraBaseParameter : DevExpress.XtraEditors.XtraForm
    {
        public FrmXtraBaseParameter()
        {
            InitializeComponent();
        }

        protected virtual bool ValidData()
        {
            return true;
        }
        public bool IsPreviewOrExportXML;

        public void btnOk_Click(object sender, System.EventArgs e)
        {
            if (!ValidData())
            {
                btnOk.DialogResult = DialogResult.None;
                return;
            }
            IsPreviewOrExportXML = true;
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Visible and invisible column in grid view
        /// </summary>
        public static void ShowXtraColumnInGridView<T>(List<XtraColumn> listXtraColumn, GridView gridView)
        {
            Type myType = typeof(T);
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            foreach (PropertyInfo prop in props)
            {
                var column = listXtraColumn.FirstOrDefault(obj => obj.ColumnName.Equals(prop.Name));
                if (column != null)
                {
                    gridView.Columns[prop.Name].Visible = column.ColumnVisible;
                    if (column.ColumnVisible)
                    {
                        gridView.Columns[prop.Name].Caption = column.ColumnCaption;
                        gridView.Columns[prop.Name].VisibleIndex = column.ColumnPosition;
                        gridView.Columns[prop.Name].Width = column.ColumnWith;
                    }
                }
                else
                {
                    gridView.Columns[prop.Name].Visible = false;
                }
            }
        }

        /// <summary>
        /// Visible and invisible column in banded grid view
        /// </summary>
        /// <param name="listXtraColumn"></param>
        /// <param name="bandedGridView"></param>
        public static void ShowXtraColumnInBandedGridView<T>(List<XtraColumn> listXtraColumn, DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView)
        {
            Type myType = typeof(T);
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            foreach (PropertyInfo prop in props)
            {
                var column = listXtraColumn.FirstOrDefault(obj => obj.ColumnName.Equals(prop.Name));
                if (column != null)
                {
                    if (bandedGridView.Columns[column.ColumnName] != null)
                    {
                        bandedGridView.Columns[column.ColumnName].Visible = column.ColumnVisible;
                        if (column.ColumnVisible)
                        {
                            bandedGridView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            bandedGridView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            bandedGridView.Columns[column.ColumnName].Width = column.ColumnWith;
                            bandedGridView.Columns[column.ColumnName].UnboundType = column.ColumnType;
                            bandedGridView.Columns[column.ColumnName].Fixed = column.FixedColumn;
                            bandedGridView.Columns[column.ColumnName].OptionsColumn.AllowEdit = column.AllowEdit;
                            bandedGridView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                            bandedGridView.Columns[column.ColumnName].OptionsColumn.AllowSort = DefaultBoolean.False;
                            bandedGridView.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                            if (column.IsSummaryText)
                            {
                                bandedGridView.Columns[column.ColumnName].SummaryItem.SummaryType = SummaryItemType.Custom;
                                bandedGridView.Columns[column.ColumnName].SummaryItem.DisplayFormat = "Tổng cộng"; // Properties.Resources.SummaryText;
                            }
                        }
                    }
                }
                else
                {
                    bandedGridView.Columns[prop.Name].Visible = false;
                }
            }
        }

        /// <summary>
        /// Visible and invisible column in lookup edit
        /// </summary>
        /// <param name="listXtraColumn"></param>
        /// <param name="gridView"></param>
        public static void ShowXtraColumnInLookUpEdit<T>(List<XtraColumn> listXtraColumn, LookUpEdit lookUpEdit)
        {
            Type myType = typeof(T);
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            int popUpWith = 0;

            foreach (PropertyInfo prop in props)
            {
                var column = listXtraColumn.FirstOrDefault(obj => obj.ColumnName.Equals(prop.Name));
                if (column != null)
                {
                    lookUpEdit.Properties.Columns[prop.Name].Visible = column.ColumnVisible;
                    if (column.ColumnVisible)
                    {
                        lookUpEdit.Properties.Columns[prop.Name].Caption = column.ColumnCaption;
                        //lookUpEdit.Properties.Columns[prop.Name].VisibleIndex = column.ColumnPosition;
                        lookUpEdit.Properties.Columns[prop.Name].Width = column.ColumnWith;
                        popUpWith += column.ColumnWith;
                    }
                }
                else
                {
                    lookUpEdit.Properties.Columns[prop.Name].Visible = false;
                }
            }

            lookUpEdit.Properties.PopupWidth = popUpWith;
        }

        protected virtual void SetNumericFormatControl(GridView gridView, bool isSummary)
        {
            //Get format data from db to format grid control
            var repositoryCurrencyCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };
            var repositoryNumberCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };
            var repositoryDateEdit = new RepositoryItemDateEdit() { AllowMouseWheel = false };

            foreach (GridColumn oCol in gridView.Columns)
            {
                if (!oCol.Visible)
                    continue;
                switch (oCol.UnboundType)
                {

                    case UnboundColumnType.Decimal:
                        repositoryCurrencyCalcEdit.Mask.MaskType = MaskType.Numeric;
                        if (oCol.Name == "ExchangeRate")
                        {
                            repositoryCurrencyCalcEdit.Mask.EditMask = @"c" + GlobalVariable.ExchangeRateDecimalDigits;
                            repositoryCurrencyCalcEdit.Precision = int.Parse(GlobalVariable.ExchangeRateDecimalDigits);
                        }
                        else
                        {
                            repositoryCurrencyCalcEdit.Mask.EditMask = @"c" + GlobalVariable.CurrencyDecimalDigits;
                            repositoryCurrencyCalcEdit.Precision = GlobalVariable.CurrencyDecimalDigits;
                        }

                        repositoryCurrencyCalcEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                        repositoryCurrencyCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                        oCol.ColumnEdit = repositoryCurrencyCalcEdit;
                        if (isSummary)
                        {
                            oCol.SummaryItem.SummaryType = SummaryItemType.Sum;
                            oCol.SummaryItem.DisplayFormat = GlobalVariable.CurrencyDisplayString;
                            oCol.SummaryItem.Format = Thread.CurrentThread.CurrentCulture;
                        }
                        break;

                    case UnboundColumnType.Integer:
                        repositoryNumberCalcEdit.Mask.MaskType = MaskType.Numeric;
                        repositoryNumberCalcEdit.Mask.EditMask = @"n0";
                        repositoryNumberCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                        repositoryNumberCalcEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                        oCol.ColumnEdit = repositoryNumberCalcEdit;

                        if (isSummary)
                        {
                            oCol.SummaryItem.SummaryType = SummaryItemType.Sum;
                            oCol.SummaryItem.DisplayFormat = GlobalVariable.NumericDisplayString;
                            oCol.SummaryItem.Format = Thread.CurrentThread.CurrentCulture;
                        }
                        break;

                    case UnboundColumnType.DateTime:
                        //oCol.DisplayFormat.FormatString =
                        //    Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                        repositoryDateEdit.Mask.MaskType = MaskType.DateTimeAdvancingCaret;
                        repositoryDateEdit.Mask.EditMask = @"dd/MM/yyyy";
                        repositoryDateEdit.DisplayFormat.FormatType = FormatType.DateTime;
                        repositoryDateEdit.Mask.UseMaskAsDisplayFormat = true;
                        oCol.ColumnEdit = repositoryDateEdit;

                        //oCol.DisplayFormat.FormatString = "dd/MM/yyyy";
                        //oCol.DisplayFormat.FormatType = FormatType.DateTime;
                        //oCol.DisplayFormat.Format = Thread.CurrentThread.CurrentCulture.DateTimeFormat;
                        break;
                }
            }
        }


    }
}