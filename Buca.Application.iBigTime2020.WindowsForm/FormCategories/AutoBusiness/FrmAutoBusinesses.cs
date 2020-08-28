/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 10, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  10/10/2017       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.CashWithdrawType;
using Buca.Application.iBigTime2020.Presenter.Dictionary.RefType;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AutoBusiness;


namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.AutoBusiness
{
    /// <summary>
    /// class UserControlAutoBusinessList
    /// </summary>
// ReSharper disable PartialTypeWithSinglePart
    public partial class FrmAutoBusinesses : FrmBaseList, IAutoBusinessesView, ICashWithdrawTypesView, IRefTypesView
// ReSharper restore PartialTypeWithSinglePart
    {
        private readonly AutoBusinessesPresenter _autoBusinessesPresenter;
        private RepositoryItemGridLookUpEdit _gridLookUpEditCashWithDrawType;
        private GridView _gridLookUpEditCashWithDrawTypeView;
        private readonly CashWithdrawTypesPresenter _cashWithdrawTypesPresenter;
        private RepositoryItemGridLookUpEdit _gridLookUpEditRefType;
        private GridView _gridLookUpEditRefTypeView;
        private readonly RefTypesPresenter _refTypesPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmAutoBusinesses" /> class.
        /// </summary>
        public FrmAutoBusinesses()
        {
            InitializeComponent();
            _autoBusinessesPresenter = new AutoBusinessesPresenter(this);
            _cashWithdrawTypesPresenter = new CashWithdrawTypesPresenter(this);
            _refTypesPresenter = new RefTypesPresenter(this);
        }

        #region IAutoBusinesssView Members

        /// <summary>
        /// Sets the autoBusinesss.
        /// </summary>
        /// <value>
        /// The autoBusinesss.
        /// </value>
        public IList<AutoBusinessModel> AutoBusinesses
        {
            set
            {
                grdList.DataSource = value;

                ColumnsCollection.Add(new XtraColumn { ColumnName = "AutoBusinessId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AutoBusinessCode", ColumnCaption = "Mã định khoản", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AutoBusinessName", ColumnCaption = "Tên định khoản", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 250 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefTypeId", ColumnCaption = "Loại chứng từ", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 150, RepositoryControl = _gridLookUpEditRefType});
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DebitAccount", ColumnCaption = "Tài khoản nợ", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 70 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CreditAccount", ColumnCaption = "Tài khoản có", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 70 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetKindItemCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubKindItemCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubItemCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "MethodDistributeId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CashWithDrawTypeId", ColumnCaption = "Nghiệp vụ", ColumnPosition = 6, ColumnVisible = false, ColumnWith = 150, RepositoryControl = _gridLookUpEditCashWithDrawType });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 70 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
            }
        }

        /// <summary>
        /// Sets the cash withdraw type models.
        /// </summary>
        /// <value>
        /// The cash withdraw type models.
        /// </value>
        public IList<CashWithdrawTypeModel> CashWithdrawTypeModels
        {
            set
            {
                try
                {
                    //RepositoryItemGridLookUpEdit VoucherType
                    _gridLookUpEditCashWithDrawTypeView = new GridView();
                    _gridLookUpEditCashWithDrawTypeView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditCashWithDrawType = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditCashWithDrawTypeView,
                        TextEditStyle = TextEditStyles.Standard,
                        ShowFooter = false
                    };
                    _gridLookUpEditCashWithDrawType.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditCashWithDrawType.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditCashWithDrawType.View.OptionsView.ShowHorizontalLines = DefaultBoolean.False;
                    _gridLookUpEditCashWithDrawType.View.OptionsView.ShowColumnHeaders = false;
                    _gridLookUpEditCashWithDrawType.View.BestFitColumns();

                    _gridLookUpEditCashWithDrawType.DataSource = value;
                    _gridLookUpEditCashWithDrawTypeView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn { ColumnName = "CashWithdrawTypeId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "CashWithdrawTypeName", ColumnCaption = "Nghiệp vụ", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 320 },
                        new XtraColumn { ColumnName = "CashWithdrawNo", ColumnVisible = false },
                        new XtraColumn { ColumnName = "SubSystemId", ColumnVisible = false }
                    };

                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditCashWithDrawTypeView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditCashWithDrawTypeView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditCashWithDrawTypeView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditCashWithDrawTypeView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditCashWithDrawType.DisplayMember = "CashWithdrawTypeName";
                    _gridLookUpEditCashWithDrawType.ValueMember = "CashWithdrawTypeId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Sets the cash withdraw type model.
        /// </summary>
        /// <value>
        /// The cash withdraw type model.
        /// </value>
        public CashWithdrawTypeModel CashWithdrawTypeModel { set; get; }

        /// <summary>
        /// Sets the reference types.
        /// </summary>
        /// <value>
        /// The reference types.
        /// </value>
        public IList<RefTypeModel> RefTypes
        {
            set
            {
                try
                {
                    //RepositoryItemGridLookUpEdit VoucherType
                    _gridLookUpEditRefTypeView = new GridView();
                    _gridLookUpEditRefTypeView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditRefType = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditRefTypeView,
                        TextEditStyle = TextEditStyles.Standard,
                        ShowFooter = false
                    };
                    _gridLookUpEditRefType.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditRefType.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditRefType.View.OptionsView.ShowHorizontalLines = DefaultBoolean.False;
                    _gridLookUpEditRefType.View.OptionsView.ShowColumnHeaders = false;
                    _gridLookUpEditRefType.View.BestFitColumns();

                    _gridLookUpEditRefType.DataSource = value;
                    _gridLookUpEditRefTypeView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn { ColumnName = "RefTypeId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "RefTypeName", ColumnCaption = "Tên chứng từ", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 320 },
                        new XtraColumn { ColumnName = "FunctionId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "RefTypeCategoryId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "MasterTableName", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DetailTableName", ColumnVisible = false },
                        new XtraColumn { ColumnName = "LayoutMaster", ColumnVisible = false },
                        new XtraColumn { ColumnName = "LayoutDetail", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DefaultDebitAccountCategoryId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DefaultDebitAccountId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DefaultCreditAccountCategoryId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DefaultCreditAccountId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DefaultTaxAccountCategoryId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DefaultTaxAccountId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "AllowDefaultSetting", ColumnVisible = false },
                        new XtraColumn { ColumnName = "Postable", ColumnVisible = false },
                        new XtraColumn { ColumnName = "Searchable", ColumnVisible = false },
                        new XtraColumn { ColumnName = "SortOrder", ColumnVisible = false },
                        new XtraColumn { ColumnName = "SubSystem", ColumnVisible = false }
                    };

                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditRefTypeView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditRefTypeView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditRefTypeView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditRefTypeView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditRefType.DisplayMember = "RefTypeName";
                    _gridLookUpEditRefType.ValueMember = "RefTypeId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Form event
        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _cashWithdrawTypesPresenter.DisplayList();
            _refTypesPresenter.Display();
            _autoBusinessesPresenter.Display();
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>;
        protected override void DeleteGrid()
        {
            new AutoBusinessPresenter(null).Delete(PrimaryKeyValue);
        }

        #endregion
        
        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseCategoryDetail GetFormDetail()
        {
            return new FrmAutoBusinessDetail();
        }

        
    }
}
