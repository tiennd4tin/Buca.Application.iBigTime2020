﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BuCA.Enum;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Bank;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FundStructure;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.Presenter.Estimate;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.View.Estimate;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObject;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using Buca.Application.iBigTime2020.WindowsForm.Code;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Estimate
{
    /// <summary>
    /// Class FrmBUCommitmentRequests.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList.FrmBaseVoucherList" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Estimate.IBUCommitmentRequestsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IAccountsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetChaptersView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetSourcesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetKindItemsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IFundStructuresView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBanksView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IProjectsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetItemsView" />
    public partial class FrmBUCommitmentAdjustments : FrmBaseVoucherList, IBUCommitmentAdjustmentsView, IAccountsView, IBudgetChaptersView, IBudgetSourcesView, IBudgetKindItemsView, IFundStructuresView, IBanksView, IProjectsView, IBudgetItemsView, IAccountingObjectsView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmBUCommitmentRequests"/> class.
        /// </summary>
        public FrmBUCommitmentAdjustments()
        {
            InitializeComponent();

            _bUCommitmentAdjustmentsPresenter = new BUCommitmentAdjustmentsPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _fundStructuresPresenter = new FundStructuresPresenter(this);
            _banksPresenter = new BanksPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
            _budgetChaptersPresenter = new BudgetChaptersPresenter(this);
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
            _accountingObjectsPresenter = new AccountingObjectsPresenter(this);
            _model = new Model.Model();


            _parentBand2 = new GridBand();
            _parentBand2Child1 = new GridBand();
            _parentBand2Child2 = new GridBand();
            _parentBand2Child3 = new GridBand();
            _parentBand2Child4 = new GridBand();
            _parentBand2Child5 = new GridBand();
            _parentBand2Child6 = new GridBand();
            _parentBand2Child7 = new GridBand();

            _parentBand3 = new GridBand();
            _parentBand3Child1 = new GridBand();
            _parentBand3Child2 = new GridBand();
            _parentBand3Child3 = new GridBand();
            _parentBand3Child4 = new GridBand();
            _parentBand3Child5 = new GridBand();
            _parentBand3Child6 = new GridBand();
            _parentBand3Child7 = new GridBand();
        }
        #region Presenter
        /// <summary>
        /// The s u increment decrements presenter
        /// </summary>
        private readonly BUCommitmentAdjustmentsPresenter _bUCommitmentAdjustmentsPresenter;

        /// <summary>
        /// The accounts presenter
        /// </summary>
        private readonly AccountsPresenter _accountsPresenter;

        /// <summary>
        /// The budget sources presenter
        /// </summary>
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;

        /// <summary>
        /// The budget kind items presenter
        /// </summary>
        private readonly BudgetKindItemsPresenter _budgetKindItemsPresenter;

        /// <summary>
        /// The budget sub kind item models
        /// </summary>
        private List<BudgetKindItemModel> _budgetSubKindItemModels;

        /// <summary>
        /// The _fund structures presenter
        /// </summary>
        private readonly FundStructuresPresenter _fundStructuresPresenter;

        /// <summary>
        /// The _projects presenter
        /// </summary>
        private readonly ProjectsPresenter _projectsPresenter;

        /// <summary>
        /// The _banks presenter
        /// </summary>
        private readonly BanksPresenter _banksPresenter;

        /// <summary>
        /// The budget chapters presenter
        /// </summary>
        private readonly BudgetChaptersPresenter _budgetChaptersPresenter;

        /// <summary>
        /// The budget items presenter
        /// </summary>
        private readonly BudgetItemsPresenter _budgetItemsPresenter;
        private readonly AccountingObjectsPresenter _accountingObjectsPresenter;

        /// <summary>
        /// The model
        /// </summary>
        private readonly IModel _model;
        #endregion

        #region RepositoryItemLookUpEdit
        /// <summary>
        /// The grid look up edit account_gridLookUpEditAccount
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditAccount;

        /// <summary>
        /// The grid look up edit account view
        /// </summary>
        private GridView _gridLookUpEditAccountView;

        /// <summary>
        /// The grid look up edit budget source
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSource;

        /// <summary>
        /// The grid look up edit budget source view
        /// </summary>
        private GridView _gridLookUpEditBudgetSourceView;

        /// <summary>
        /// The grid look up edit budget sub kind item
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetKindItem;

        /// <summary>
        /// The grid look up edit budget sub kind item view
        /// </summary>
        private GridView _gridLookUpEditBudgetKindItemView;

        /// <summary>
        /// The grid look up edit cash withdraw type
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditFundStructure;

        /// <summary>
        /// The grid look up edit cash withdraw type view
        /// </summary>
        private GridView _gridLookUpEditFundStructureView;

        /// <summary>
        /// The grid look up edit cash withdraw type
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBank;

        /// <summary>
        /// The grid look up edit cash withdraw type view
        /// </summary>
        private GridView _gridLookUpEditBankView;

        /// <summary>
        /// The grid look up edit cash withdraw type
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditProject;

        /// <summary>
        /// The grid look up edit cash withdraw type view
        /// </summary>
        private GridView _gridLookUpEditProjectView;

        /// <summary>
        /// The grid look up edit cash withdraw type
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetChapter;

        /// <summary>
        /// The grid look up edit cash withdraw type view
        /// </summary>
        private GridView _gridLookUpEditBudgetChapterView;

        /// <summary>
        /// The grid look up edit budget item
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetItem;
        /// <summary>
        /// The grid look up edit budget item view
        /// </summary>
        private GridView _gridLookUpEditBudgetItemView;

        /// <summary>
        /// The grid look up edit budget sub item
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSubItem;
        /// <summary>
        /// The grid look up edit budget sub item view
        /// </summary>
        private GridView _gridLookUpEditBudgetSubItemView;

        /// <summary>
        /// The grid look up edit budget sub item
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditAccountingObject;
        /// <summary>
        /// The grid look up edit budget sub item view
        /// </summary>
        private GridView _gridLookUpEditAccountingObjectView;
        #endregion

        #region bands declare
        /// <summary>
        /// The description band
        /// </summary>
        private GridBand _descriptionBand;
        /// <summary>
        /// To amount band
        /// </summary>
        private GridBand _toAmountBand;
        /// <summary>
        /// The remain amount band
        /// </summary>
        private GridBand _remainAmountBand;
        /// <summary>
        /// The fund structure band
        /// </summary>
        private GridBand _fundStructureBand;

        private GridBand _currencyBand;
        private GridBand _exchangerate;

        private GridBand _amountOC;
        private GridBand _toAmountOC;

        /// <summary>
        /// The parent band2
        /// </summary>
        private GridBand _parentBand2;
        /// <summary>
        /// The parent band2 child1
        /// </summary>
        private readonly GridBand _parentBand2Child1;
        /// <summary>
        /// The parent band2 child2
        /// </summary>
        private readonly GridBand _parentBand2Child2;
        /// <summary>
        /// The parent band2 child3
        /// </summary>
        private readonly GridBand _parentBand2Child3;
        /// <summary>
        /// The parent band2 child4
        /// </summary>
        private readonly GridBand _parentBand2Child4;
        /// <summary>
        /// The parent band2 child5
        /// </summary>
        private readonly GridBand _parentBand2Child5;
        /// <summary>
        /// The parent band2 child6
        /// </summary>
        private readonly GridBand _parentBand2Child6;
        /// <summary>
        /// The parent band2 child7
        /// </summary>
        private readonly GridBand _parentBand2Child7;

        /// <summary>
        /// The parent band3
        /// </summary>
        private GridBand _parentBand3;
        /// <summary>
        /// The parent band3 child1
        /// </summary>
        private readonly GridBand _parentBand3Child1;
        /// <summary>
        /// The parent band3 child2
        /// </summary>
        private readonly GridBand _parentBand3Child2;
        /// <summary>
        /// The parent band3 child3
        /// </summary>
        private readonly GridBand _parentBand3Child3;
        /// <summary>
        /// The parent band3 child4
        /// </summary>
        private readonly GridBand _parentBand3Child4;
        /// <summary>
        /// The parent band3 child5
        /// </summary>
        private readonly GridBand _parentBand3Child5;
        /// <summary>
        /// The parent band3 child6
        /// </summary>
        private readonly GridBand _parentBand3Child6;
        /// <summary>
        /// The parent band3 child7
        /// </summary>
        private readonly GridBand _parentBand3Child7;


        #endregion bands declare

        #region override

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            InitRepositoryControlData();

            _accountsPresenter.DisplayActive();
            _budgetKindItemsPresenter.DisplayActive();
            _budgetSourcesPresenter.DisplayActive();
            _banksPresenter.DisplayActive(true);
            _projectsPresenter.DisplayActive();
            _fundStructuresPresenter.Display();
            _budgetItemsPresenter.DisplayActive(true);
            _bUCommitmentAdjustmentsPresenter.Display();
            bindingSource.AllowNew = true;
            _budgetChaptersPresenter.DisplayByIsActive(true);
            _accountingObjectsPresenter.DisplayByIsCustomerVendor(true);
        }
        private void LoadBandGridView()
        {
            if (bandedGridView.Bands.Count <= 0)
            {
                _descriptionBand = bandedGridView.Bands.AddBand("Description");
                _parentBand2 = bandedGridView.Bands.AddBand("Parent2");
                _parentBand3 = bandedGridView.Bands.AddBand("Parent3");
                _remainAmountBand = bandedGridView.Bands.AddBand("RemainAmount");
                _toAmountBand = bandedGridView.Bands.AddBand("ToAmount");
                _fundStructureBand = bandedGridView.Bands.AddBand("FundStructureId");
            }

            #region Diễn giải

            _descriptionBand.Caption = @"Diễn giải";
            _descriptionBand.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            _descriptionBand.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;
            bandedGridView.Columns["Description"].OwnerBand = _descriptionBand;
            bandedGridView.Columns["Description"].Visible = true;
            bandedGridView.Columns["Description"].VisibleIndex = 1;
            bandedGridView.Columns["Description"].OptionsColumn.AllowSort = DefaultBoolean.False;

            #endregion

            #region Thông tin đã hạch toán

            _parentBand2.Caption = @"Thông tin đã hạch toán";
            _parentBand2.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            _parentBand2.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;

            _parentBand2Child1.Caption = @"Nguồn";
            _parentBand2Child1.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            _parentBand2Child1.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;

            _parentBand2Child2.Caption = @"Chương";
            _parentBand2Child2.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            _parentBand2Child2.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;

            _parentBand2Child3.Caption = @"Khoản";
            _parentBand2Child3.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            _parentBand2Child3.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;

            _parentBand2Child4.Caption = @"Mục";
            _parentBand2Child4.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            _parentBand2Child4.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;

            _parentBand2Child5.Caption = @"Tiểu mục";
            _parentBand2Child5.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            _parentBand2Child5.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;

            _parentBand2Child6.Caption = @"CTMT, dự án";
            _parentBand2Child6.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            _parentBand2Child6.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;

            _parentBand2Child7.Caption = @"Số tiền";
            _parentBand2Child7.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            _parentBand2Child7.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;


            bandedGridView.Columns["BudgetSourceId"].OwnerBand = _parentBand2;
            bandedGridView.Columns["BudgetSourceId"].Visible = true;
            bandedGridView.Columns["BudgetSourceId"].VisibleIndex = 9;
            bandedGridView.Columns["BudgetSourceId"].OptionsColumn.AllowSort = DefaultBoolean.False;

            bandedGridView.Columns["BudgetChapterCode"].OwnerBand = _parentBand2;
            bandedGridView.Columns["BudgetChapterCode"].Visible = true;
            bandedGridView.Columns["BudgetChapterCode"].VisibleIndex = 10;
            bandedGridView.Columns["BudgetChapterCode"].OptionsColumn.AllowSort = DefaultBoolean.False;

            bandedGridView.Columns["BudgetKindItemCode"].OwnerBand = _parentBand2;
            bandedGridView.Columns["BudgetKindItemCode"].Visible = true;
            bandedGridView.Columns["BudgetKindItemCode"].VisibleIndex = 11;
            bandedGridView.Columns["BudgetKindItemCode"].OptionsColumn.AllowSort = DefaultBoolean.False;

            bandedGridView.Columns["BudgetSubItemCode"].OwnerBand = _parentBand2;
            bandedGridView.Columns["BudgetSubItemCode"].Visible = true;
            bandedGridView.Columns["BudgetSubItemCode"].VisibleIndex = 12;
            bandedGridView.Columns["BudgetSubItemCode"].OptionsColumn.AllowSort = DefaultBoolean.False;

            bandedGridView.Columns["BudgetItemCode"].OwnerBand = _parentBand2;
            bandedGridView.Columns["BudgetItemCode"].Visible = true;
            bandedGridView.Columns["BudgetItemCode"].VisibleIndex = 13;
            bandedGridView.Columns["BudgetItemCode"].OptionsColumn.AllowSort = DefaultBoolean.False;

            bandedGridView.Columns["ProjectId"].OwnerBand = _parentBand2;
            bandedGridView.Columns["ProjectId"].Visible = true;
            bandedGridView.Columns["ProjectId"].VisibleIndex = 14;
            bandedGridView.Columns["ProjectId"].OptionsColumn.AllowSort = DefaultBoolean.False;

            bandedGridView.Columns["Amount"].OwnerBand = _parentBand2;
            bandedGridView.Columns["Amount"].UnboundType = UnboundColumnType.Decimal;
            bandedGridView.Columns["Amount"].Visible = true;
            bandedGridView.Columns["Amount"].VisibleIndex = 15;
            bandedGridView.Columns["Amount"].OptionsColumn.AllowSort = DefaultBoolean.False;


            #endregion

            #region Thông tin đề nghị điều chỉnh

            _parentBand3.Caption = @"Thông tin đề nghị điều chỉnh";
            _parentBand3.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            _parentBand3.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;


            _parentBand3Child1.Caption = @"Nguồn";
            _parentBand3Child1.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            _parentBand3Child1.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;

            _parentBand3Child2.Caption = @"Chương";
            _parentBand3Child2.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            _parentBand3Child2.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;

            _parentBand3Child3.Caption = @"Khoản";
            _parentBand3Child3.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            _parentBand3Child3.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;

            _parentBand3Child4.Caption = @"Mục";
            _parentBand3Child4.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            _parentBand3Child4.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;

            _parentBand3Child5.Caption = @"tiểu mục";
            _parentBand3Child5.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            _parentBand3Child5.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;

            _parentBand3Child6.Caption = @"CTMT, dự án";
            _parentBand3Child6.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            _parentBand3Child6.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;



            bandedGridView.Columns["ToBudgetSourceId"].OwnerBand = _parentBand3;
            bandedGridView.Columns["ToBudgetSourceId"].Visible = true;
            bandedGridView.Columns["ToBudgetSourceId"].VisibleIndex = 2;
            bandedGridView.Columns["ToBudgetSourceId"].OptionsColumn.AllowSort = DefaultBoolean.False;

            bandedGridView.Columns["ToBudgetChapterCode"].OwnerBand = _parentBand3;
            bandedGridView.Columns["ToBudgetChapterCode"].Visible = true;
            bandedGridView.Columns["ToBudgetChapterCode"].VisibleIndex = 3;
            bandedGridView.Columns["ToBudgetChapterCode"].OptionsColumn.AllowSort = DefaultBoolean.False;

            bandedGridView.Columns["ToBudgetKindItemCode"].OwnerBand = _parentBand3;
            bandedGridView.Columns["ToBudgetKindItemCode"].Visible = true;
            bandedGridView.Columns["ToBudgetKindItemCode"].VisibleIndex = 4;
            bandedGridView.Columns["ToBudgetKindItemCode"].OptionsColumn.AllowSort = DefaultBoolean.False;

            bandedGridView.Columns["ToBudgetSubItemCode"].OwnerBand = _parentBand3;
            bandedGridView.Columns["ToBudgetSubItemCode"].Visible = true;
            bandedGridView.Columns["ToBudgetSubItemCode"].VisibleIndex = 5;
            bandedGridView.Columns["ToBudgetSubItemCode"].OptionsColumn.AllowSort = DefaultBoolean.False;

            bandedGridView.Columns["ToBudgetItemCode"].OwnerBand = _parentBand3;
            bandedGridView.Columns["ToBudgetItemCode"].Visible = true;
            bandedGridView.Columns["ToBudgetItemCode"].VisibleIndex = 6;
            bandedGridView.Columns["ToBudgetItemCode"].OptionsColumn.AllowSort = DefaultBoolean.False;



            bandedGridView.Columns["ToProjectId"].OwnerBand = _parentBand3;
            bandedGridView.Columns["ToProjectId"].Visible = true;
            bandedGridView.Columns["ToProjectId"].VisibleIndex = 7;
            bandedGridView.Columns["ToProjectId"].OptionsColumn.AllowSort = DefaultBoolean.False;
            #endregion

            #region Số tiền CKC sau điều chỉnh

            _remainAmountBand.Caption = @"Số tiền CKC sau điều chỉnh";
            _remainAmountBand.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            _remainAmountBand.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;

            bandedGridView.Columns["RemainAmount"].OwnerBand = _remainAmountBand;
            bandedGridView.Columns["RemainAmount"].Visible = true;
            bandedGridView.Columns["RemainAmount"].VisibleIndex = 25;
            bandedGridView.Columns["RemainAmount"].UnboundType = UnboundColumnType.Decimal;
            bandedGridView.Columns["RemainAmount"].OptionsColumn.AllowSort = DefaultBoolean.False;

            #endregion

            #region Số tiền CKC điều chỉnh
            _toAmountBand.Caption = @"Số tiền CKC điều chỉnh";
            _toAmountBand.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            _toAmountBand.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;

            bandedGridView.Columns["ToAmount"].OwnerBand = _toAmountBand;
            bandedGridView.Columns["ToAmount"].Visible = true;
            bandedGridView.Columns["ToAmount"].UnboundType = UnboundColumnType.Decimal;
            bandedGridView.Columns["ToAmount"].VisibleIndex = 26;
            bandedGridView.Columns["ToAmount"].OptionsColumn.AllowSort = DefaultBoolean.False;

            #endregion

            #region Khoản chi

            _fundStructureBand.Caption = @"Khoản chi";
            _fundStructureBand.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            _fundStructureBand.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;

            bandedGridView.Columns["FundStructureId"].OwnerBand = _fundStructureBand;
            bandedGridView.Columns["FundStructureId"].Visible = true;
            bandedGridView.Columns["FundStructureId"].VisibleIndex = 27;
            bandedGridView.Columns["FundStructureId"].OptionsColumn.AllowSort = DefaultBoolean.False;

            #endregion

            bandedGridView.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;
            bandedGridView.Appearance.HeaderPanel.TextOptions.WordWrap = WordWrap.Wrap;
            bandedGridView.OptionsView.AllowHtmlDrawHeaders = true;

            new GridBandPaintHelper(bandedGridView, new[] { _descriptionBand, _remainAmountBand, _toAmountBand, _fundStructureBand });

        }

        /// <summary>
        /// Initializes the repository control data.
        /// </summary>
        private void InitRepositoryControlData()
        {

        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new BUCommitmentAdjustmentPresenter(null).Delete(PrimaryKeyValue);
        }

        /// <summary>
        /// Loads the data into grid detail.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        protected override void LoadDataIntoGridDetail(string refId)
        {
            var bUCommitmentAdjustment = _model.GetBUCommitmentAdjustmentVoucher(refId, true);
            if (bUCommitmentAdjustment == null)
                return;
            bindingSourceDetail.DataSource = bUCommitmentAdjustment.BUCommitmentAdjustmentDetails;
            gridDetail.MainView = bandedGridView;
            gridDetail.ForceInitialize();
            bandedGridView.PopulateColumns(bUCommitmentAdjustment.BUCommitmentAdjustmentDetails);

            ColumnsCollection.Clear();
            ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDetailId", ColumnVisible = false });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Diễn giải", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 180, FixedColumn = FixedStyle.Left, AllowEdit = false, ToolTip = "Diễn giải" });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyId", ColumnVisible = false });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnVisible = false });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "Amount", ColumnCaption = "Số tiền", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = false, ToolTip = "Số tiền", ColumnType = UnboundColumnType.Decimal });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "AmountOC", ColumnVisible = false });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceId", ColumnCaption = "Nguồn", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = false, ToolTip = "Nguồn", RepositoryControl = _gridLookUpEditBudgetSource });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterCode", ColumnCaption = "Chương", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = false, ToolTip = "Chương", RepositoryControl = _gridLookUpEditBudgetChapter });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetKindItemCode", ColumnCaption = "Khoản", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = false, ToolTip = "Khoản" });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubKindItemCode", ColumnVisible = false });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubItemCode", ColumnCaption = "Tiểu mục", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = false, ToolTip = "Tiểu mục", RepositoryControl = _gridLookUpEditBudgetSubItem });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mục", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = false, ToolTip = "Mục", RepositoryControl = _gridLookUpEditBudgetItem });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetDetailItemCode", ColumnVisible = false });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "MethodDistributeId", ColumnVisible = false });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "CashWithDrawTypeId", ColumnVisible = false });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "ActivityId", ColumnVisible = false });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnCaption = "CTMT, dự án", ColumnPosition = 8, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = false, ToolTip = "CTMT, dự án", RepositoryControl = _gridLookUpEditProject });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectActivityId", ColumnVisible = false });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectExpenseId", ColumnVisible = false });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "TaskId", ColumnVisible = false });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "ListItemId", ColumnVisible = false });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "Approved", ColumnVisible = false });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "FundStructureId", ColumnCaption = "Khoản chi", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 180, FixedColumn = FixedStyle.Left, AllowEdit = false, ToolTip = "Khoản chi", RepositoryControl = _gridLookUpEditFundStructure });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "SortOrder", ColumnVisible = false });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnVisible = false });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetProvideCode", ColumnVisible = false });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "ToCurrencyId", ColumnVisible = false });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "ToExchangeRate", ColumnVisible = false });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "ToAmountOC", ColumnVisible = false });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "ToAmount", ColumnCaption = "Số tiền CKC điều chỉnh", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 120, FixedColumn = FixedStyle.Left, AllowEdit = false, ToolTip = "Số tiền CKC điều chỉnh", ColumnType = UnboundColumnType.Decimal });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetSourceId", ColumnCaption = "Nguồn", ColumnPosition = 9, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = false, ToolTip = "Nguồn", RepositoryControl = _gridLookUpEditBudgetSource });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetProvideCode", ColumnVisible = false });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetChapterCode", ColumnCaption = "Chương", ColumnPosition = 10, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = false, ToolTip = "Chương", RepositoryControl = _gridLookUpEditBudgetChapter });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetKindItemCode", ColumnCaption = "Khoản", ColumnPosition = 11, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = false, ToolTip = "Khoản" });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetSubKindItemCode", ColumnVisible = false });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetSubItemCode", ColumnCaption = "Tiểu mục", ColumnPosition = 12, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = false, ToolTip = "Tiểu mục", RepositoryControl = _gridLookUpEditBudgetSubItem });

            ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetItemCode", ColumnCaption = "Mục", ColumnPosition = 13, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = false, ToolTip = "Mục", RepositoryControl = _gridLookUpEditBudgetItem });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "ToProjectId", ColumnCaption = "CTMT, dự án", ColumnPosition = 14, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = false, ToolTip = "CTMT, dự án", RepositoryControl = _gridLookUpEditProject });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "RemainAmountOC", ColumnVisible = false });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "RemainAmount", ColumnCaption = "Số tiền CKC sau điều chỉnh", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 120, FixedColumn = FixedStyle.Left, AllowEdit = false, ToolTip = "Số tiền CKC sau điều chỉnh", ColumnType = UnboundColumnType.Decimal });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "RemainExchangeRate", ColumnVisible = false });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "RemainCurrencyId", ColumnVisible = false });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnVisible = false });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "RemainCurrencyCode", ColumnVisible = false });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "ToCurrencyCode", ColumnVisible = false });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "ContractId", ColumnVisible = false });
            ColumnsCollection.Add(new XtraColumn { ColumnName = "CapitalPlanId", ColumnVisible = false });
            ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BUCommitmentAdjustmentDetailModel.BUCommitmentRequestDetailId), ColumnVisible = false });

            foreach (var column in ColumnsCollection)
            {
                if (bandedGridView.Columns[column.ColumnName] != null)
                {
                    if (column.ColumnVisible)
                    {
                        bandedGridView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        bandedGridView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        bandedGridView.Columns[column.ColumnName].Width = column.ColumnWith;
                        bandedGridView.Columns[column.ColumnName].UnboundType = column.ColumnType; //dung de dinh dang so theo kieu du lieu
                        bandedGridView.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                        if (column.IsSummaryText)
                        {
                            bandedGridView.Columns[column.ColumnName].SummaryItem.SummaryType = SummaryItemType.Custom;
                            bandedGridView.Columns[column.ColumnName].SummaryItem.DisplayFormat = Properties.Resources.SummaryText;
                        }
                    }
                    else
                        bandedGridView.Columns[column.ColumnName].Visible = false;
                }

            }
            SetNumericFormatControl(bandedGridView, true);
            LoadBandGridView();
            bandedGridView.OptionsBehavior.AllowAddRows = DefaultBoolean.False;
            bandedGridView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            gridViewDetail.OptionsBehavior.AllowAddRows = DefaultBoolean.False;
            gridViewDetail.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
        }

        /// <summary>
        /// Initializes the grid layout.
        /// </summary>
        /// <param name="columnsCollection">The columns collection.</param>
        /// <param name="grdView">The GRD view.</param>
        /// <returns>GridView.</returns>
        private GridView InitGridLayout(List<XtraColumn> columnsCollection, GridView grdView)
        {
            foreach (var column in columnsCollection)
                if (grdView.Columns[column.ColumnName] != null)
                    if (column.ColumnVisible)
                    {
                        grdView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        grdView.Columns[column.ColumnName].Width = column.ColumnWith;
                        grdView.Columns[column.ColumnName].UnboundType = column.ColumnType;
                        grdView.Columns[column.ColumnName].Fixed = column.FixedColumn;
                        grdView.Columns[column.ColumnName].OptionsColumn.AllowEdit = column.AllowEdit;
                        grdView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                        grdView.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                        grdView.Columns[column.ColumnName].OptionsColumn.AllowSort = DefaultBoolean.False;
                        if (column.IsSummaryText)
                        {
                            grdView.Columns[column.ColumnName].SummaryItem.SummaryType = SummaryItemType.Custom;
                            grdView.Columns[column.ColumnName].SummaryItem.DisplayFormat =
                                Properties.Resources.SummaryText;
                        }
                    }
                    else
                    {
                        grdView.Columns[column.ColumnName].Visible = false;
                    }
            return grdView;
        }

        #endregion

        #region IView Extens

        /// <summary>
        /// Sets the accounts.
        /// </summary>
        /// <value>The accounts.</value>
        public IList<AccountModel> Accounts
        {
            set
            {
                try
                {
                    _gridLookUpEditAccountView = new GridView();
                    _gridLookUpEditAccountView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditAccount = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditAccountView,
                        TextEditStyle = TextEditStyles.Standard
                    };
                    _gridLookUpEditAccount.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditAccount.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditAccount.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditAccount.View.BestFitColumns();

                    _gridLookUpEditAccount.DataSource = value;
                    _gridLookUpEditAccountView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "AccountNumber",
                        ColumnCaption = "Số tài khoản",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "AccountName",
                        ColumnCaption = "Tên tài khỏan",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountCategoryId", ColumnVisible = false });
                    gridColumnsCollection.Add(
                        new XtraColumn { ColumnName = "AccountCategoryKind", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "AccountForeignName",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByBudgetSource",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByBudgetChapter",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByBudgetKindItem",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByBudgetItem",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByBudgetSubItem",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByMethodDistribute",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByAccountingObject",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByActivity", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByProject", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByTask", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailBySupply", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByInventoryItem",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByFixedAsset",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByFund", ColumnVisible = false });
                    gridColumnsCollection.Add(
                        new XtraColumn { ColumnName = "DetailByBankAccount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByProjectActivity",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByInvestor", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "IsDisplayOnAccountBalanceSheet",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "IsDisplayBalanceOnReport",
                        ColumnVisible = false
                    });

                    foreach (var column in gridColumnsCollection)
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditAccountView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditAccountView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditAccountView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
                            _gridLookUpEditAccountView.Columns[column.ColumnName].Visible = false;
                        }
                    _gridLookUpEditAccount.DisplayMember = "AccountNumber";
                    _gridLookUpEditAccount.ValueMember = "AccountNumber";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Sets the budget sources.
        /// </summary>
        /// <value>The budget sources.</value>
        public IList<BudgetSourceModel> BudgetSources
        {
            set
            {
                try
                {
                    _gridLookUpEditBudgetSourceView = new GridView();
                    _gridLookUpEditBudgetSourceView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditBudgetSource = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditBudgetSourceView,
                        TextEditStyle = TextEditStyles.Standard
                    };
                    _gridLookUpEditBudgetSource.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetSource.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetSource.PopupFormSize = new Size(368, 150);
                    _gridLookUpEditBudgetSource.View.BestFitColumns();

                    _gridLookUpEditBudgetSource.DataSource = value;
                    _gridLookUpEditBudgetSourceView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetSourceCode",
                        ColumnCaption = "Mã nguồn vốn",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnPosition = 1
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetSourceName",
                        ColumnCaption = "Tên nguồn vốn",
                        ColumnVisible = true,
                        ColumnWith = 250,
                        ColumnPosition = 2
                    });
                    XtraColumnCollectionHelper<BudgetSourceModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSourceView);
                    _gridLookUpEditBudgetSource.DisplayMember = "BudgetSourceCode";
                    _gridLookUpEditBudgetSource.ValueMember = "BudgetSourceId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Sets the budget kind items.
        /// </summary>
        /// <value>The budget kind items.</value>
        public IList<BudgetKindItemModel> BudgetKindItems
        {
            set
            {
                try
                {
                    _budgetSubKindItemModels = value.Where(v => !v.IsParent).ToList();

                    _gridLookUpEditBudgetKindItemView = new GridView();
                    _gridLookUpEditBudgetKindItemView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditBudgetKindItem = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditBudgetKindItemView,
                        TextEditStyle = TextEditStyles.Standard
                    };
                    _gridLookUpEditBudgetKindItem.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetKindItem.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetKindItem.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditBudgetKindItem.View.BestFitColumns();

                    _gridLookUpEditBudgetKindItem.DataSource = _budgetSubKindItemModels;
                    _gridLookUpEditBudgetKindItemView.PopulateColumns(_budgetSubKindItemModels);

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetKindItemId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetKindItemCode",
                        ColumnCaption = "Mã Khoản",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetKindItemName",
                        ColumnCaption = "Tên Khoản",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    foreach (var column in gridColumnsCollection)
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditBudgetKindItemView.Columns[column.ColumnName].Caption =
                                column.ColumnCaption;
                            _gridLookUpEditBudgetKindItemView.Columns[column.ColumnName].VisibleIndex =
                                column.ColumnPosition;
                            _gridLookUpEditBudgetKindItemView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
                            _gridLookUpEditBudgetKindItemView.Columns[column.ColumnName].Visible = false;
                        }
                    _gridLookUpEditBudgetKindItem.DisplayMember = "BudgetKindItemCode";
                    _gridLookUpEditBudgetKindItem.ValueMember = "BudgetKindItemCode";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Sets the banks.
        /// </summary>
        /// <value>The banks.</value>
        public IList<BankModel> Banks
        {
            set
            {
                if (value == null)
                    value = new List<BankModel>();

                _gridLookUpEditBankView = XtraColumnCollectionHelper<BankModel>.CreateGridViewReponsitory();
                _gridLookUpEditBank = XtraColumnCollectionHelper<BankModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBankView, value, "BankAccount", "BankId");

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnCaption = "Số TK", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankName", ColumnCaption = "Tên ngân hàng", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                XtraColumnCollectionHelper<BankModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBankView);
            }
        }

        /// <summary>
        /// Sets the projects.
        /// </summary>
        /// <value>The projects.</value>
        public IList<ProjectModel> Projects
        {
            set
            {
                try
                {
                    _gridLookUpEditProjectView = new GridView();
                    _gridLookUpEditProjectView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditProject = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditProjectView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditProject.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditProject.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditProject.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditProject.View.BestFitColumns();

                    _gridLookUpEditProject.DataSource = value;
                    _gridLookUpEditProjectView.PopulateColumns(value);
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "ProjectCode",
                        ColumnCaption = "Mã CTMT, dự án",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "ProjectName",
                        ColumnCaption = "Tên CTMT, dự án",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectNumber", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectEnglishName", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BUCACodeID", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "StartDate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "FinishDate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ExecutionUnit", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentID", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountApproved", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ParentID", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "IsDetailbyActivityAndExpense",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ObjectType", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContractorID", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContractorName", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContractorAddress", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectSize", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BuildLocation", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "InvestmentClass", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CDCActivityType", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Investment", ColumnVisible = false });
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditProjectView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditProjectView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditProjectView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditProjectView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditProject.DisplayMember = "ProjectCode";
                    _gridLookUpEditProject.ValueMember = "ProjectId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Sets the fund structures.
        /// </summary>
        /// <value>The fund structures.</value>
        public IList<FundStructureModel> FundStructures
        {
            set
            {
                try
                {
                    _gridLookUpEditFundStructureView = new GridView();
                    _gridLookUpEditFundStructureView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditFundStructure = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditFundStructureView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditFundStructure.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditFundStructure.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditFundStructure.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditFundStructure.View.BestFitColumns();

                    _gridLookUpEditFundStructure.DataSource = value;
                    _gridLookUpEditFundStructureView.PopulateColumns(value);
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "FundStructureId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "FundStructureCode",
                        ColumnCaption = "Mã Khoản chi",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "FundStructureName",
                        ColumnCaption = "Tên Khoản chi",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Inactive", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "InvestmentPeriod", ColumnVisible = false });
                    //foreach (var column in gridColumnsCollection)
                    //{
                    //    if (column.ColumnVisible)
                    //    {
                    //        _gridLookUpEditFundStructureView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    //        _gridLookUpEditFundStructureView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                    //        _gridLookUpEditFundStructureView.Columns[column.ColumnName].Width = column.ColumnWith;
                    //    }
                    //    else
                    //        _gridLookUpEditFundStructureView.Columns[column.ColumnName].Visible = false;
                    //}
                    XtraColumnCollectionHelper<FundStructureModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditFundStructureView);
                    _gridLookUpEditFundStructure.DisplayMember = "FundStructureCode";
                    _gridLookUpEditFundStructure.ValueMember = "FundStructureId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Sets the budget chapters.
        /// </summary>
        /// <value>The budget chapters.</value>
        public IList<BudgetChapterModel> BudgetChapters
        {
            set
            {
                try
                {
                    _gridLookUpEditBudgetChapterView = new GridView();
                    _gridLookUpEditBudgetChapterView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditBudgetChapter = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditBudgetChapterView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditBudgetChapter.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetChapter.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetChapter.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditBudgetChapter.View.BestFitColumns();

                    _gridLookUpEditBudgetChapter.DataSource = value;
                    _gridLookUpEditBudgetChapterView.PopulateColumns(value);
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetChapterCode",
                        ColumnCaption = "Mã chương",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetChapterName",
                        ColumnCaption = "Tên chương",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditBudgetChapter.DisplayMember = "BudgetChapterCode";
                    _gridLookUpEditBudgetChapter.ValueMember = "BudgetChapterId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        /// <summary>
        /// Sets the bu commitment requests.
        /// </summary>
        /// <value>The bu commitment requests.</value>
        public IList<BUCommitmentAdjustmentModel> BUCommitmentAdjustments
        {
            set
            {
                var bUCommitmentRequestModel = value;
                bindingSource.DataSource = (bUCommitmentRequestModel);
                gridView.PopulateColumns(bUCommitmentRequestModel);
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "RefDate",
                    ColumnCaption = "Ngày KBNN ghi sổ",
                    Alignment = HorzAlignment.Center,
                    ColumnType = UnboundColumnType.DateTime,
                    ColumnPosition = 1,
                    ColumnVisible = false,
                    ColumnWith = 50
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "RefNo",
                    ColumnCaption = "Số phiếu điều chỉnh",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 50
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    //ColumnName = "RefDate",
                    ColumnName = "PostedDate",
                    ColumnCaption = "Ngày đề nghị điều chỉnh CKC",
                    ColumnPosition = 3,
                    ColumnVisible = true,
                    ColumnWith = 50
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    //ColumnName = "ContractNo",
                    ColumnName = "RealContractNo",
                    ColumnCaption = "Số CKC điều chỉnh",
                    ColumnPosition = 4,
                    ColumnVisible = true,
                    ColumnWith = 50
                });

                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "ContractFrameNo",
                    ColumnCaption = "Số HĐK, CKC",
                    ColumnPosition = 5,
                    ColumnVisible = true,
                    ColumnWith = 50
                });

                //ColumnsCollection.Add(new XtraColumn
                //{
                //    ColumnName = "RealContractNo",
                //    ColumnCaption = "Số HĐ thực hiện, số CKC",
                //    ColumnPosition = 6,
                //    ColumnVisible = true,
                //    ColumnWith = 100
                //});

                //ColumnsCollection.Add(new XtraColumn
                //{
                //    ColumnName = "RefNo",
                //    ColumnCaption = "Số HĐ giấy",
                //    ColumnPosition = 7,
                //    ColumnVisible = true,
                //    ColumnType = UnboundColumnType.Decimal,
                //    ColumnWith = 40
                //});

                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "TotalAmount",
                    ColumnCaption = "Số tiền",
                    ColumnPosition = 8,
                    ColumnVisible = true,
                    ColumnType = UnboundColumnType.Decimal,
                    ColumnWith = 40
                });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                //ColumnsCollection.Add(new XtraColumn { ColumnName = "PostedDate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BUCommitmentRequestId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefType", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountOC", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsForeignCurrency", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Posted", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "EditVersion", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PostVersion", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsSuggestAdjustment", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsSuggestSupplement", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AdjustmentProviderBankAccount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AdjustmentProviderBankName", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankName", ColumnVisible = false });



                ColumnsCollection.Add(
                    new XtraColumn { ColumnName = "BUCommitmentAdjustmentDetails", ColumnVisible = false });

                XtraColumnCollectionHelper<BUCommitmentAdjustmentModel>.ShowXtraColumnInGridView(ColumnsCollection, gridView);
                SetNumericFormatControl(gridView, true);
            }
        }
        /// <summary>
        /// Sets the BudgetItems.
        /// </summary>
        /// <value>The BudgetItems.</value>
        public IList<BudgetItemModel> BudgetItems
        {
            set
            {
                try
                {
                    var budgetItemModels = value.Where(v => v.BudgetItemType == 2).ToList();
                    var budgetSubItemModels = value.Where(v => v.BudgetItemType == 3).ToList();

                    #region BudgetItem
                    _gridLookUpEditBudgetItemView = new GridView();
                    _gridLookUpEditBudgetItemView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditBudgetItem = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditBudgetItemView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditBudgetItem.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetItem.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetItem.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditBudgetItem.View.BestFitColumns();

                    _gridLookUpEditBudgetItem.DataSource = budgetItemModels;
                    _gridLookUpEditBudgetItemView.PopulateColumns(budgetItemModels);
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetItemCode",
                        ColumnCaption = "Mã Mục",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetItemName",
                        ColumnCaption = "Tên Mục",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemType", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetGroupItemCode", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditBudgetItemView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditBudgetItemView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditBudgetItemView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditBudgetItemView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditBudgetItem.DisplayMember = "BudgetItemCode";
                    _gridLookUpEditBudgetItem.ValueMember = "BudgetItemCode";
                    #endregion

                    #region BudgetSubItem
                    _gridLookUpEditBudgetSubItemView = new GridView();
                    _gridLookUpEditBudgetSubItemView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditBudgetSubItem = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditBudgetSubItemView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditBudgetSubItem.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetSubItem.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetSubItem.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditBudgetSubItem.View.BestFitColumns();

                    _gridLookUpEditBudgetSubItem.DataSource = budgetSubItemModels;
                    _gridLookUpEditBudgetSubItemView.PopulateColumns(budgetSubItemModels);
                    gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetItemCode",
                        ColumnCaption = "Mã tiểu mục",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetItemName",
                        ColumnCaption = "Tên tiểu mục",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemType", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetGroupItemCode", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditBudgetSubItemView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditBudgetSubItemView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditBudgetSubItemView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditBudgetSubItemView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditBudgetSubItem.DisplayMember = "BudgetItemCode";
                    _gridLookUpEditBudgetSubItem.ValueMember = "BudgetItemCode";
                    #endregion
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Sets the bu plan withdraw.
        /// </summary>
        /// <value>The bu plan withdraw.</value>
        public IList<BUPlanReceiptDetailModel> BUPlanWithdraw { set; private get; }

        public IList<AccountingObjectModel> AccountingObjects
        {
            set
            {

                var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn { ColumnName = "AccountingObjectBanks", ColumnVisible = false },
                    new XtraColumn
                    {
                        ColumnName = "AccountingObjectCode",
                        ColumnCaption = "Mã đối tượng",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        Alignment = HorzAlignment.Center
                    },
                    new XtraColumn
                    {
                        ColumnName = "AccountingObjectName",
                        ColumnCaption = "Tên đối tượng",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 250
                    },
                    new XtraColumn {ColumnName = "AccountingObjectId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AccountingObjectCategoryId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Address", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Tel", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Fax", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Website", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BankAccount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BankName", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CompanyTaxCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AreaCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Description", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContactName", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContactTitle", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContactSex", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContactMobile", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContactEmail", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContactOfficeTel", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContactHomeTel", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContactAddress", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsEmployee", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsPersonal", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IdentificationNumber", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IssueDate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IssueBy", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DepartmentId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SalaryScaleId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Insured", ColumnVisible = false},
                    new XtraColumn {ColumnName = "LabourUnionFee", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FamilyDeductionAmount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsCustomerVendor", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SalaryCoefficient", ColumnVisible = false},
                    new XtraColumn {ColumnName = "NumberFamilyDependent", ColumnVisible = false},
                    new XtraColumn {ColumnName = "EmployeeTypeId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SalaryForm", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SalaryPercentRate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SalaryAmount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsPayInsuranceOnSalary", ColumnVisible = false},
                    new XtraColumn {ColumnName = "InsuranceAmount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsUnEmploymentInsurance", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefTypeAO", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SalaryGrade", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CustomField1", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CustomField2", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CustomField3", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CustomField4", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CustomField5", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsPaidInsuranceForPayrollItem", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsBornLeave", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TaxDepartmentName", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TreasuryName", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsActive", ColumnVisible = false}
                };
                #region Lookup edit accounting objects

                _gridLookUpEditAccountingObjectView = new GridView();
                _gridLookUpEditAccountingObjectView.OptionsView.ColumnAutoWidth = false;
                _gridLookUpEditAccountingObject = new RepositoryItemGridLookUpEdit
                {
                    NullText = "",
                    View = _gridLookUpEditAccountingObjectView,
                    TextEditStyle = TextEditStyles.Standard,
                };
                _gridLookUpEditAccountingObject.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                _gridLookUpEditAccountingObject.View.OptionsView.ShowIndicator = false;
                _gridLookUpEditAccountingObject.PopupFormSize = new Size(368, 150);

                _gridLookUpEditAccountingObject.View.BestFitColumns();

                _gridLookUpEditAccountingObject.DataSource = value;
                _gridLookUpEditAccountingObjectView.PopulateColumns(value);

                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                        _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].Visible = false;
                }
                _gridLookUpEditAccountingObject.DisplayMember = "AccountingObjectName";
                _gridLookUpEditAccountingObject.ValueMember = "AccountingObjectId";

                #endregion
            }
        }



        #endregion
        protected override void ChangeFormDetail()
        {
            //if (string.IsNullOrEmpty(PrimaryKeyValue)) return;
            var obj = gridView.GetFocusedRow();
            if (obj == null)
            {
                SetFormDetail((int)RefType.BUCommitmentAdjustment);
                return;
            }

            var model = (BUCommitmentAdjustmentModel)obj;
            SetFormDetail(model.RefType);
        }
    }
}
