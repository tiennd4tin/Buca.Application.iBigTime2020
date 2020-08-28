/***********************************************************************
 * <copyright file="FrmOpeningCommitmentDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, July 19, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BuCA.Enum;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Bank;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FundStructure;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObject;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetItem;
using Buca.Application.iBigTime2020.View.OpeningCommitment;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Opening;
using Buca.Application.iBigTime2020.Presenter.Opening;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.AccountingObject;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Project;
using BuCA.Application.iBigTime2020.Session;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Estimate
{
    /// <summary>
    /// Class FrmOpeningCommitmentDetail.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail.FrmXtraBaseVoucherDetail" />
    /// <seealso cref="IOpeningCommitmentView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IAccountsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetSourcesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetKindItemsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IFundStructuresView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBanksView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IProjectsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetChaptersView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IAccountingObjectsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetItemsView" />
    public partial class FrmOpeningCommitmentDetail : FrmXtraBaseVoucherDetail, IOpeningCommitmentView, IAccountsView, IBudgetSourcesView, IBudgetKindItemsView, IFundStructuresView, IBanksView, IProjectsView, IBudgetChaptersView, IAccountingObjectsView, IBudgetItemsView, ICurrenciesView
    {
        #region IBUPlanReceiptView
        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public string RefId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>The reference date.</value>
        public DateTime RefDate
        {
            get { return dtRefDate.EditValue == null ? DateTime.Parse("31/12/" + ((int)DateTime.Now.Year - 1).ToString()) : (DateTime)dtRefDate.EditValue; }
            set { dtRefDate.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>The posted date.</value>
        public DateTime PostedDate
        {
            get { return dtPostDate.EditValue == null ? DateTime.Parse("31/12/" + ((int)DateTime.Now.Year - 1).ToString()) : (DateTime)dtPostDate.EditValue; }
            set { dtPostDate.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>The reference no.</value>
        public string RefNo
        {
            get { return txtRefNo.Text.Trim(); }
            set { txtRefNo.Text = value; }
        }

        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>The type of the reference.</value>
        public int RefType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>The total amount.</value>
        public decimal TotalAmount
        {
            get { return OpeningCommitmentDetails.Sum(x => x.Amount); }
            set { }
        }

        /// <summary>
        /// Gets or sets the total amount oc.
        /// </summary>
        /// <value>The total amount oc.</value>
        public decimal TotalAmountOC
        {
            get { return OpeningCommitmentDetails.Sum(x => x.AmountOC); }
            set { }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate.OpeningCommitmentModel" /> is posted.
        /// </summary>
        /// <value><c>true</c> if posted; otherwise, <c>false</c>.</value>
        public bool Posted
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>The accounting object identifier.</value>
        public string AccountingObjectId
        {
            get { return lookupVendor.EditValue == null ? "" : lookupVendor.EditValue.ToString(); }

            set { lookupVendor.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the name of the accounting object.
        /// </summary>
        /// <value>The name of the accounting object.</value>
        public string AccountingObjectName
        {
            get { return txtVendorName.Text; }

            set { txtVendorName.Text = value; }
        }

        /// <summary>
        /// Gets or sets the tabmis code.
        /// </summary>
        /// <value>The tabmis code.</value>
        public string TABMISCode
        {
            get { return txtTABMISCode.Text; }

            set { txtTABMISCode.Text = value; }
        }

        /// <summary>
        /// Gets or sets the bank account.
        /// </summary>
        /// <value>The bank account.</value>
        public string BankAccount
        {
            get { return txtAccountNumber.Text; }

            set { txtAccountNumber.Text = value; }
        }

        /// <summary>
        /// Gets or sets the name of the bank.
        /// </summary>
        /// <value>The name of the bank.</value>
        public string BankName
        {
            get { return txtBankName.Text.Trim(); }
            set { txtBankName.Text = value; }
        }

        /// <summary>
        /// Gets or sets the contract no.
        /// </summary>
        /// <value>The contract no.</value>
        public string ContractNo
        {
            get { return txtContractNo.Text.Trim(); }
            set { txtContractNo.Text = value; }
        }

        /// <summary>
        /// Gets or sets the contract frame no.
        /// </summary>
        /// <value>The contract frame no.</value>
        public string ContractFrameNo
        {
            get { return txtContractFrameNo.Text.Trim(); }
            set { txtContractFrameNo.Text = value; }
        }

        /// <summary>
        /// Gets or sets the kind of the budget source.
        /// </summary>
        /// <value>The kind of the budget source.</value>
        public int BudgetSourceKind
        {
            get;

            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is foreign currency.
        /// </summary>
        /// <value><c>true</c> if this instance is foreign currency; otherwise, <c>false</c>.</value>
        public bool IsForeignCurrency
        {
            get { return checkIncurredCurrency.Checked; }
            set { checkIncurredCurrency.Checked = value; }
        }

        /// <summary>
        /// Gets or sets the edit version.
        /// </summary>
        /// <value>The edit version.</value>
        public int? EditVersion
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the post version.
        /// </summary>
        /// <value>The post version.</value>
        public int? PostVersion
        {
            get;

            set;
        }

        /// <summary>
        /// Gets or sets the project investment code.
        /// </summary>
        /// <value>The project investment code.</value>
        public string ProjectInvestmentCode
        {
            get
            {
                if (lookupProject.EditValue == null)
                    return null;
                return lookupProject.EditValue.ToString();
            }
            set { lookupProject.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the name of the project investment.
        /// </summary>
        /// <value>The name of the project investment.</value>
        public string ProjectInvestmentName
        {
            get { return txtProjectName.Text.Trim(); }
            set { txtProjectName.Text = value; }
        }

        /// <summary>
        /// Gets or sets the sign date.
        /// </summary>
        /// <value>The sign date.</value>
        public DateTime? SignDate
        {
            get { return dateSignDate.EditValue == null ? DateTime.Now : (DateTime)dateSignDate.EditValue; }
            set { dateSignDate.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the contract amount.
        /// </summary>
        /// <value>The contract amount.</value>
        public decimal? ContractAmount
        {
            get { return calContractAmount.EditValue == null ? 0 : (decimal)calContractAmount.EditValue; }
            set { calContractAmount.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the previous year commitment amount.
        /// </summary>
        /// <value>The previous year commitment amount.</value>
        public decimal? PrevYearCommitmentAmount
        {
            get { return calPrevYearCommitmentAmount.EditValue == null ? 0 : (decimal)calPrevYearCommitmentAmount.EditValue; }
            set { calPrevYearCommitmentAmount.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the bu plan receipt detail models.
        /// </summary>
        /// <value>The bu plan receipt detail models.</value>
        public IList<OpeningCommitmentDetailModel> OpeningCommitmentDetails
        {
            get
            {
                var bUCommitmentDetails = new List<OpeningCommitmentDetailModel>();
                if (grdAccountingView.DataSource != null && grdAccountingView.RowCount > 0)
                {
                    for (var i = 0; i < grdAccountingView.RowCount; i++)
                    {
                        var rowVoucher = (OpeningCommitmentDetailModel)grdAccountingView.GetRow(i);
                        if (rowVoucher != null)
                        {
                            var budgetKindItemCode = "";
                            if (!string.IsNullOrEmpty(rowVoucher.BudgetSubKindItemCode))
                            {
                                var budgetSubKindItem = _budgetSubKindItemModels.FirstOrDefault(b => b.BudgetKindItemCode == rowVoucher.BudgetSubKindItemCode);
                                if (budgetSubKindItem == null)
                                    budgetKindItemCode = null;
                                else
                                {
                                    var budgetKindItem = _budgetKindItemModels.FirstOrDefault(b => b.BudgetKindItemId == budgetSubKindItem.ParentId);
                                    budgetKindItemCode = budgetKindItem == null ? null : budgetKindItem.BudgetKindItemCode;
                                }
                            }
                            var item = new OpeningCommitmentDetailModel
                            {
                                Description = rowVoucher.Description == null ? "" : rowVoucher.Description.Trim(),
                                Amount = rowVoucher.Amount,
                                BudgetSourceId = rowVoucher.BudgetSourceId,
                                BudgetSubKindItemCode = rowVoucher.BudgetSubKindItemCode,
                                FundStructureId = rowVoucher.FundStructureId,
                                ProjectId = rowVoucher.ProjectId,
                                ActivityId = rowVoucher.ActivityId,
                                AmountOC = rowVoucher.AmountOC,
                                Approved = rowVoucher.Approved,
                                BankAccount = rowVoucher.BankAccount,
                                BudgetChapterCode = rowVoucher.BudgetChapterCode,
                                BudgetDetailItemCode = rowVoucher.BudgetDetailItemCode,
                                BudgetItemCode = rowVoucher.BudgetItemCode,
                                BudgetKindItemCode = budgetKindItemCode,
                                BudgetProvideCode = rowVoucher.BudgetProvideCode,
                                BudgetSubItemCode = rowVoucher.BudgetSubItemCode,
                                CashWithDrawTypeId = rowVoucher.CashWithDrawTypeId,
                                CurrencyId = rowVoucher.CurrencyId,
                                ProjectActivityId = rowVoucher.ProjectActivityId,
                                ExchangeRate = rowVoucher.ExchangeRate,
                                ListItemId = rowVoucher.ListItemId,
                                MethodDistributeId = rowVoucher.MethodDistributeId,
                                ProjectExpenseId = rowVoucher.ProjectExpenseId,
                                RefDetailId = rowVoucher.RefDetailId,
                                RefId = rowVoucher.RefId,
                                SortOrder = i
                            };
                            bUCommitmentDetails.Add(item);
                        }
                    }
                }
                return bUCommitmentDetails;
            }
            set
            {
                bindingSourceDetail.DataSource = value.OrderBy(c => c.SortOrder).ToList() ?? new List<OpeningCommitmentDetailModel>();
                grdAccountingView.PopulateColumns(value);

                #region columns for grdAccountingView

                if (checkIncurredCurrency.Checked == true)
                {
                    var columnsCollection = new List<XtraColumn>
                {
                 new XtraColumn
                {
                    ColumnName = "Description",
                    ColumnCaption = "Diễn giải",
                    Alignment = HorzAlignment.Center,
                    ColumnPosition = 0,
                    ColumnVisible = true,
                    ColumnWith = 400,AllowEdit = true
                },
                new XtraColumn
                {
                    ColumnName = "BudgetSourceId",
                    ColumnCaption = "Nguồn",
                    Alignment = HorzAlignment.Center,
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 100,
                    RepositoryControl = _gridLookUpEditBudgetSource,
                    AllowEdit = true
                },
                new XtraColumn
                {
                    ColumnName = "BudgetChapterCode",
                    ColumnCaption = "Chương",
                    Alignment = HorzAlignment.Center,
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    AllowEdit = true,
                    ColumnWith = 100,
                   RepositoryControl = _gridLookUpEditBudgetChapter
                },
                new XtraColumn
                {
                    ColumnName = "BudgetSubKindItemCode",
                    ColumnCaption = "Khoản",
                    Alignment = HorzAlignment.Center,
                    ColumnPosition = 3,
                    ColumnVisible = true,
                    AllowEdit = true,
                    ColumnWith = 100,
                    RepositoryControl = _gridLookUpEditBudgetSubKindItem
                },
                new XtraColumn
                {
                    ColumnName = "BudgetSubItemCode",
                    ColumnCaption = "Tiểu mục",
                    Alignment = HorzAlignment.Center,
                    ColumnPosition = 4,
                    ColumnVisible = true,
                    AllowEdit = true,
                    ColumnWith =100,
                    RepositoryControl = _gridLookUpEditBudgetSubItem
                },
                new XtraColumn
                {
                    ColumnName = "BudgetItemCode",
                    ColumnCaption = "Mục",
                    Alignment = HorzAlignment.Center,
                    ColumnPosition = 5,
                    ColumnVisible = true,
                    AllowEdit = true,
                    ColumnWith = 100,
                    RepositoryControl = _gridLookUpEditBudgetItem
                },
                new XtraColumn
                {
                    ColumnName = "AmountOC",
                    ColumnCaption = "Số tiền",
                    Alignment = HorzAlignment.Center,
                    ColumnPosition = 6,
                    ColumnVisible = true,
                    AllowEdit = true,
                    ColumnWith = 100,
                    ColumnType = UnboundColumnType.Decimal
                },
                 new XtraColumn
                {
                    ColumnName = "CurrencyId",
                    ColumnCaption = "Loại tiền",
                    Alignment = HorzAlignment.Center,
                    ColumnPosition = 7,
                    ColumnVisible = true,
                    AllowEdit = true,
                    ColumnWith =100,
                    RepositoryControl = _gridLookUpEditCurrency
                },

                  new XtraColumn
                {
                    ColumnName = "ExchangeRate",
                    ColumnCaption = "Tỷ giá",
                    Alignment = HorzAlignment.Center,
                    ColumnPosition = 8,
                    ColumnVisible = true,
                    AllowEdit = true,
                    ColumnWith =100,
                    ColumnType = UnboundColumnType.Decimal
                },
                    new XtraColumn
                {
                    ColumnName = "Amount",
                    ColumnCaption = "Quy đổi",
                    Alignment = HorzAlignment.Center,
                    ColumnPosition = 9,
                    ColumnVisible = true,
                    AllowEdit = true,
                    ColumnWith =100,
                    ColumnType = UnboundColumnType.Decimal
                },

                 new XtraColumn
                {
                    ColumnName = "ProjectId",
                    ColumnCaption = "CTMT, Dự án",
                    Alignment = HorzAlignment.Center,
                    ColumnPosition = 10,
                    ColumnVisible = true,
                    AllowEdit = true,
                    ColumnWith = 300,
                    RepositoryControl = _gridLookUpEditProject
                },
                      new XtraColumn
                {
                    ColumnName = "FundStructureId",
                    ColumnCaption = "Khoản chi",
                    Alignment = HorzAlignment.Center,
                    ColumnPosition = 11,
                    ColumnVisible = true,
                    AllowEdit = true,
                    ColumnWith = 100,
                    RepositoryControl = _gridLookUpEditFundStructure
                },
                               new XtraColumn
                {
                    ColumnName = "BankAccount",
                    ColumnCaption = "Tài khoản NH,KB",
                    Alignment = HorzAlignment.Center,
                    ColumnPosition =12,
                    ColumnVisible = true,
                    AllowEdit = true,
                    ColumnWith =200,
                    RepositoryControl = _gridLookUpEditBank
                },
    new XtraColumn { ColumnName = "RefDetailId", ColumnVisible = false },
   new XtraColumn { ColumnName = "RefId", ColumnVisible = false },
   new XtraColumn { ColumnName = "BudgetKindItemCode", ColumnVisible = false },
   new XtraColumn { ColumnName = "BudgetDetailItemCode", ColumnVisible = false },
   new XtraColumn { ColumnName = "MethodDistributeId", ColumnVisible = false },
   new XtraColumn { ColumnName = "CashWithDrawTypeId", ColumnVisible = false },
   new XtraColumn { ColumnName = "ActivityId", ColumnVisible = false },
   new XtraColumn { ColumnName = "ProjectActivityId", ColumnVisible = false },
   new XtraColumn { ColumnName = "ProjectExpenseId", ColumnVisible = false },
   new XtraColumn { ColumnName = "TaskId", ColumnVisible = false },
   new XtraColumn { ColumnName = "ListItemId", ColumnVisible = false },
   new XtraColumn { ColumnName = "Approved", ColumnVisible = false },
   new XtraColumn { ColumnName = "SortOrder", ColumnVisible = false },
   new XtraColumn { ColumnName = "BudgetProvideCode", ColumnVisible = false },
            };
                    grdAccountingView = InitGridLayout(columnsCollection, grdAccountingView);
                    SetNumericFormatControl(grdAccountingView, true);
                }

                else
                {

                    var columnsCollection = new List<XtraColumn>
                {
                 new XtraColumn
                {
                    ColumnName = "Description",
                    ColumnCaption = "Diễn giải",
                    Alignment = HorzAlignment.Center,
                    ColumnPosition = 0,
                    ColumnVisible = true,
                    ColumnWith = 400,AllowEdit = true
                },
                new XtraColumn
                {
                    ColumnName = "BudgetSourceId",
                    ColumnCaption = "Nguồn",
                    Alignment = HorzAlignment.Center,
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 100,
                    RepositoryControl = _gridLookUpEditBudgetSource,
                    AllowEdit = true
                },
                new XtraColumn
                {
                    ColumnName = "BudgetChapterCode",
                    ColumnCaption = "Chương",
                    Alignment = HorzAlignment.Center,
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    AllowEdit = true,
                    ColumnWith = 100,
                   RepositoryControl = _gridLookUpEditBudgetChapter
                },
                new XtraColumn
                {
                    ColumnName = "BudgetSubKindItemCode",
                    ColumnCaption = "Khoản",
                    Alignment = HorzAlignment.Center,
                    ColumnPosition = 3,
                    ColumnVisible = true,
                    AllowEdit = true,
                    ColumnWith = 100,
                    RepositoryControl = _gridLookUpEditBudgetSubKindItem
                },
                new XtraColumn
                {
                    ColumnName = "BudgetSubItemCode",
                    ColumnCaption = "Tiểu mục",
                    Alignment = HorzAlignment.Center,
                    ColumnPosition = 4,
                    ColumnVisible = true,
                    AllowEdit = true,
                    ColumnWith =100,
                    RepositoryControl = _gridLookUpEditBudgetSubItem
                },
                new XtraColumn
                {
                    ColumnName = "BudgetItemCode",
                    ColumnCaption = "Mục",
                    Alignment = HorzAlignment.Center,
                    ColumnPosition = 5,
                    ColumnVisible = true,
                    AllowEdit = true,
                    ColumnWith = 100,
                    RepositoryControl = _gridLookUpEditBudgetItem
                },
                 new XtraColumn
                {
                    ColumnName = "CurrencyId",
                    ColumnCaption = "Loại tiền",
                    Alignment = HorzAlignment.Center,
                    ColumnPosition = 6,
                    ColumnVisible = false,
                    AllowEdit = true,
                    ColumnWith =100,
                 //   RepositoryControl = _gr
                },

                  new XtraColumn
                {
                    ColumnName = "ExchangeRate",
                    ColumnCaption = "Tỷ giá",
                    Alignment = HorzAlignment.Center,
                    ColumnPosition = 7,
                    ColumnVisible = false,
                    AllowEdit = true,
                    ColumnWith =100,
                    ColumnType = UnboundColumnType.Decimal
                },
                    new XtraColumn
                {
                    ColumnName = "AmountOC",
                    ColumnCaption = "Số tiền",
                    Alignment = HorzAlignment.Center,
                    ColumnPosition = 8,
                    ColumnVisible = true,
                    AllowEdit = true,
                    ColumnWith =100,
                    ColumnType = UnboundColumnType.Decimal
                },

                new XtraColumn
                {
                    ColumnName = "Amount",
                    ColumnCaption = "Số tiền quy đổi",
                    Alignment = HorzAlignment.Center,
                    ColumnPosition = 9,
                    ColumnVisible = false,
                    AllowEdit = true,
                    ColumnWith = 100,
                    ColumnType = UnboundColumnType.Decimal
                },
                 new XtraColumn
                {
                    ColumnName = "ProjectId",
                    ColumnCaption = "CTMT, Dự án",
                    Alignment = HorzAlignment.Center,
                    ColumnPosition = 10,
                    ColumnVisible = true,
                    AllowEdit = true,
                    ColumnWith = 300,
                    RepositoryControl = _gridLookUpEditProject
                },
                      new XtraColumn
                {
                    ColumnName = "FundStructureId",
                    ColumnCaption = "Khoản chi",
                    Alignment = HorzAlignment.Center,
                    ColumnPosition = 11,
                    ColumnVisible = true,
                    AllowEdit = true,
                    ColumnWith = 100,
                    RepositoryControl = _gridLookUpEditFundStructure
                },
                               new XtraColumn
                {
                    ColumnName = "BankAccount",
                    ColumnCaption = "Tài khoản NH,KB",
                    Alignment = HorzAlignment.Center,
                    ColumnPosition =12,
                    ColumnVisible = true,
                    AllowEdit = true,
                    ColumnWith =510,
                    RepositoryControl = _gridLookUpEditBank
                },
    new XtraColumn { ColumnName = "RefDetailId", ColumnVisible = false },
   new XtraColumn { ColumnName = "RefId", ColumnVisible = false },
   new XtraColumn { ColumnName = "BudgetKindItemCode", ColumnVisible = false },
   new XtraColumn { ColumnName = "BudgetDetailItemCode", ColumnVisible = false },
   new XtraColumn { ColumnName = "MethodDistributeId", ColumnVisible = false },
   new XtraColumn { ColumnName = "CashWithDrawTypeId", ColumnVisible = false },
   new XtraColumn { ColumnName = "ActivityId", ColumnVisible = false },
   new XtraColumn { ColumnName = "ProjectActivityId", ColumnVisible = false },
   new XtraColumn { ColumnName = "ProjectExpenseId", ColumnVisible = false },
   new XtraColumn { ColumnName = "TaskId", ColumnVisible = false },
   new XtraColumn { ColumnName = "ListItemId", ColumnVisible = false },
   new XtraColumn { ColumnName = "Approved", ColumnVisible = false },
   new XtraColumn { ColumnName = "SortOrder", ColumnVisible = false },
   new XtraColumn { ColumnName = "BudgetProvideCode", ColumnVisible = false },
            };
                    grdAccountingView = InitGridLayout(columnsCollection, grdAccountingView);
                    SetNumericFormatControl(grdAccountingView, true);
                    grdAccountingView.OptionsView.ShowFooter = false;
                }



                #endregion
            }
        }
        #endregion

        #region Presenter
        /// <summary>
        /// The s u increment decrements presenter
        /// </summary>
        private readonly OpeningCommitmentPresenter _openingCommitmentPresenter;

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
        /// The _fund structures presenter
        /// </summary>
        private readonly FundStructuresPresenter _fundStructuresPresenter;

        /// <summary>
        /// The budget chapters presenter
        /// </summary>
        private readonly BudgetChaptersPresenter _budgetChaptersPresenter;

        /// <summary>
        /// The _projects presenter
        /// </summary>
        private readonly ProjectsPresenter _projectsPresenter;

        /// <summary>
        /// The budget items presenter
        /// </summary>
        private readonly BudgetItemsPresenter _budgetItemsPresenter;

        /// <summary>
        /// The _banks presenter
        /// </summary>
        private readonly BanksPresenter _banksPresenter;
        /// <summary>
        /// The accounting objects presenter
        /// </summary>
        private readonly AccountingObjectsPresenter _accountingObjectsPresenter;

        #endregion

        #region RepositoryItemGridLookUpEdit

        /// <summary>
        /// The grid look up edit budget source
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSource;
        /// <summary>
        /// The grid look up edit budget source view
        /// </summary>
        private GridView _gridLookUpEditBudgetSourceView;

        /// <summary>
        /// The grid look up edit debit account
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditDebitAccount;
        /// <summary>
        /// The grid look up edit debit account view
        /// </summary>
        private GridView _gridLookUpEditDebitAccountView;

        /// <summary>
        /// The grid look up edit budget sub kind item
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSubKindItem;
        /// <summary>
        /// The grid look up edit budget sub kind item view
        /// </summary>
        private GridView _gridLookUpEditBudgetSubKindItemView;

        /// <summary>
        /// The grid look up edit bank
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBank;
        /// <summary>
        /// The grid look up edit bank view
        /// </summary>
        private GridView _gridLookUpEditBankView;

        /// <summary>
        /// The grid look up edit project
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditProject;
        /// <summary>
        /// The grid look up edit project view
        /// </summary>
        private GridView _gridLookUpEditProjectView;

        /// <summary>
        /// The grid look up edit fund structure
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditFundStructure;
        /// <summary>
        /// The grid look up edit fund structure view
        /// </summary>
        private GridView _gridLookUpEditFundStructureView;

        /// <summary>
        /// The grid look up edit budget chapter
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetChapter;
        /// <summary>
        /// The grid look up edit budget chapter view
        /// </summary>
        private GridView _gridLookUpEditBudgetChapterView;

        /// <summary>
        /// The budget sub kind item models
        /// </summary>
        private List<BudgetKindItemModel> _budgetSubKindItemModels;

        /// <summary>
        /// The repository method distribute identifier
        /// </summary>
        private RepositoryItemLookUpEdit _repositoryMethodDistributeId;

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
        /// The grid look up edit budget item
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditCurrency;

        /// <summary>
        /// The grid look up edit budget item view
        /// </summary>
        private GridView _gridLookUpEditCurrencyView;

        /// <summary>
        /// The grid look up edit budget sub item view
        /// </summary>
        private GridView _gridLookUpEditBudgetSubItemView;
        private List<BudgetKindItemModel> _budgetKindItemModels;

        #endregion

        #region private helper

        /// <summary>
        /// Initializes the grid layout.
        /// </summary>
        /// <param name="columnsCollection">The columns collection.</param>
        /// <param name="grdView">The GRD view.</param>
        /// <returns>GridView.</returns>
        private GridView InitGridLayout(List<XtraColumn> columnsCollection, GridView grdView)
        {
            foreach (var column in columnsCollection)
            {
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
                        grdView.Columns[column.ColumnName].SummaryItem.DisplayFormat = Properties.Resources.SummaryText;
                    }
                }
                else
                {
                    grdView.Columns[column.ColumnName].Visible = false;
                }
            }
            return grdView;
        }

        /// <summary>
        /// Initializes the repository control data.
        /// </summary>
        private void InitRepositoryControlData()
        {
            var methodDistribute = typeof(MethodDistribute).ToList();
            _repositoryMethodDistributeId = new RepositoryItemLookUpEdit
            {
                DataSource = methodDistribute,
                AllowNullInput = DefaultBoolean.True,
                NullText = null,
                NullValuePrompt = null,
                DisplayMember = "Value",
                ValueMember = "Key",
                ShowHeader = false
            };
            _repositoryMethodDistributeId.PopulateColumns();
            _repositoryMethodDistributeId.Columns["Key"].Visible = false;
        }

        #endregion

        #region overrides
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmOpeningCommitmentDetail"/> class.
        /// </summary>
        public FrmOpeningCommitmentDetail()
        {
            InitializeComponent();
            _openingCommitmentPresenter = new OpeningCommitmentPresenter(this);
            _banksPresenter = new BanksPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
            _fundStructuresPresenter = new FundStructuresPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _budgetChaptersPresenter = new BudgetChaptersPresenter(this);
            _accountingObjectsPresenter = new AccountingObjectsPresenter(this);
            _budgetItemsPresenter = new BudgetItemsPresenter(this);

        }

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            grdMaster.Visible = false;
            tabMain.Location = new Point(6, 235);
            tabMain.Height += 58;
            tabMain.SelectedTabPage = tabInventoryItem;
            //tabMain.Size = new Size(998,290);

        }

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            _budgetSourcesPresenter.DisplayActive();
            _accountsPresenter.DisplayActive();
            _budgetKindItemsPresenter.DisplayActive();
            _projectsPresenter.DisplayActive();
            _fundStructuresPresenter.DisplayActive(true);
            _banksPresenter.DisplayActive(true);
            _budgetChaptersPresenter.DisplayByIsActive(true);
            _budgetItemsPresenter.DisplayActive(true);
            _accountingObjectsPresenter.DisplayByIsCustomerVendor(true);
            InitRepositoryControlData();
            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.Edit || ActionMode == ActionModeVoucherEnum.DuplicateVoucher)
                EnableControl();
            if (MasterBindingSource != null) if (MasterBindingSource.Current != null)
                KeyValue = ((OpeningCommitmentModel)MasterBindingSource.Current).RefId;
            _openingCommitmentPresenter.Display(KeyValue);
            //checkIncurredCurrency.Checked = false;

            if (RefType == 0)
                RefType = (int)BuCA.Enum.RefType.OpeningCommitment;
            //  rgRefTypeId.EditValue = RefType;

             AutoProjectId=(string)lookupProject.GetColumnValue("ProjectId");
        }

        /// <summary>
        /// Initializes the reference information.
        /// </summary>
        protected override void InitRefInfo()
        {
            // Fix tạm thời, khi có thiết lập thì sẽ lấy theo năm hạch toán - 1
            if (ActionMode == ActionModeVoucherEnum.AddNew)
            {
                dateSignDate.EditValue = DateTime.Now;
                PostedDate = DateTime.Parse("31/12/" + ((int)DateTime.Now.Year - 1).ToString());
                RefDate = DateTime.Parse("31/12/" + ((int)DateTime.Now.Year - 1).ToString());
            }
        }

        /// <summary>
        /// Enables the control.
        /// </summary>
        protected override void EnableControl()
        {
            lookupProject.Enabled = true;
            lookupVendor.Enabled = true;
            txtProjectName.Enabled = true;
            txtVendorName.Enabled = true;
            txtTABMISCode.Enabled = true;
            txtBankName.Enabled = true;
            txtAccountNumber.Enabled = true;
            txtContactName.Enabled = true;
            txtContractFrameNo.Enabled = true;
            txtContractNo.Enabled = true;
            txtDescription.Enabled = true;
            dateSignDate.Enabled = true;
            calContractAmount.Enabled = true;
            calPrevYearCommitmentAmount.Enabled = true;
            checkIncurredCurrency.Enabled = true;
            calContractAmount.Enabled = true;
            calPrevYearCommitmentAmount.Enabled = true;
        }

        protected override void RefreshNavigationButton()
        {
            base.RefreshNavigationButton();

            lookupProject.Enabled = false;
            lookupVendor.Enabled = false;
            txtProjectName.Enabled = false;
            txtVendorName.Enabled = false;
            txtTABMISCode.Enabled = false;
            txtBankName.Enabled = false;
            txtAccountNumber.Enabled = false;
            txtContactName.Enabled = false;
            txtContractFrameNo.Enabled = false;
            txtContractNo.Enabled = false;
            txtDescription.Enabled = false;
            dateSignDate.Enabled = false;
            calContractAmount.Enabled = false;
            calPrevYearCommitmentAmount.Enabled = false;
            checkIncurredCurrency.Enabled = false;
            calContractAmount.Enabled = false;
            calPrevYearCommitmentAmount.Enabled = false;
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected override bool ValidData()
        {
            var detailContent = ResourceHelper.GetResourceValueByName("ResDetailContent");

            if (string.IsNullOrEmpty(RefNo))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmptyCommitmentRefNo"), detailContent,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                txtRefNo.Focus();
                return false;
            }
            var faDepreciationDetails = OpeningCommitmentDetails;
            if (faDepreciationDetails.Count == 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResVoucherDetail"), detailContent,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        /// <summary>
        /// LinhMC
        /// Initializes the detail row.
        /// </summary>
        /// <param name="e">The <see cref="InitNewRowEventArgs" /> instance containing the event data.</param>
        /// <param name="view">The view.</param>
        protected override void InitDetailRow(InitNewRowEventArgs e, GridView view)
        {
            try
            {
                view.SetRowCellValue(e.RowHandle, "DebitAccount", "008");
                view.SetRowCellValue(e.RowHandle, "Amount", 0);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Initializes the detail row for acounting detail.
        /// </summary>
        /// <param name="e">The <see cref="InitNewRowEventArgs" /> instance containing the event data.</param>
        /// <param name="view">The view.</param>
        protected override void InitDetailRowForAcountingDetail(InitNewRowEventArgs e, GridView view)
        {
            try
            {
                //view.SetRowCellValue(e.RowHandle, "DebitAccount", "1111");
                //view.SetRowCellValue(e.RowHandle, "Amount", 0);
                //view.SetRowCellValue(e.RowHandle, "BudgetChapterCode", "423");
                //view.SetRowCellValue(e.RowHandle, "BudgetSubKindItemCode", "521");
                //view.SetRowCellValue(e.RowHandle, "MethodDistributeId", 0);
                //view.SetRowCellValue(e.RowHandle, "CashWithdrawTypeId", 0);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns>System.String.</returns>
        protected override string SaveData()
        {
            if (ActionMode == ActionModeVoucherEnum.Edit)
                RefId = KeyValue;
            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.DuplicateVoucher)
                RefId = null;
            return _openingCommitmentPresenter.Save();
        }

        /// <summary>
        /// Deletes the voucher.
        /// </summary>
        protected override void DeleteVoucher()
        {
            new OpeningCommitmentPresenter(null).Delete(KeyValue);
        }
        #endregion

        #region IView

        #region BudgetSources

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
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditBudgetSource.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetSource.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetSource.PopupFormSize = new Size(368, 150);
                    _gridLookUpEditBudgetSource.View.BestFitColumns();
                    _gridLookUpEditBudgetSource.TextEditStyle = TextEditStyles.Standard;
                    _gridLookUpEditBudgetSource.AllowNullInput = DefaultBoolean.True;
                    _gridLookUpEditBudgetSource.NullText = "";
                    _gridLookUpEditBudgetSource.KeyDown += _gridLookUpEditBudgetSourceView_KeyDown;

                    _gridLookUpEditBudgetSource.DataSource = value;
                    _gridLookUpEditBudgetSourceView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>
                        {
                            new XtraColumn {ColumnName = "BudgetSourceCode",ColumnCaption = "Mã nguồn vốn",ColumnVisible = true,ColumnWith = 100,ColumnPosition = 1},
                            new XtraColumn {ColumnName = "BudgetSourceName",ColumnCaption = "Tên nguồn vốn",ColumnVisible = true,ColumnWith = 250,ColumnPosition = 2}
                        };
                    //XtraColumnCollectionHelper<BudgetSourceModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSourceView);
                    //_gridLookUpEditBudgetSource.DisplayMember = "BudgetSourceCode";
                    //_gridLookUpEditBudgetSource.ValueMember = "BudgetSourceId";

                    _gridLookUpEditBudgetSourceView = XtraColumnCollectionHelper<BudgetSourceModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetSource = XtraColumnCollectionHelper<BudgetSourceModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSourceView, value, "BudgetSourceCode", "BudgetSourceId", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetSourceModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSourceView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region IAccountsView

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
                    AccountLists = value;
                    var debitAccounts = value;
                    var creditAccounts = value.Where(c => c.AccountNumber.IndexOf("0", StringComparison.Ordinal) == 0).ToList();
                    #region gridLookUpEditDebitAccountView
                    _gridLookUpEditDebitAccountView = new GridView();
                    _gridLookUpEditDebitAccountView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditDebitAccount = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditDebitAccountView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditDebitAccount.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditDebitAccount.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditDebitAccount.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditDebitAccount.View.BestFitColumns();
                    _gridLookUpEditDebitAccount.TextEditStyle = TextEditStyles.Standard;
                    _gridLookUpEditDebitAccount.AllowNullInput = DefaultBoolean.True;
                    _gridLookUpEditDebitAccount.NullText = "";
                    _gridLookUpEditDebitAccount.KeyDown += _gridLookUpEditDebitAccountView_KeyDown;


                    _gridLookUpEditDebitAccount.DataSource = debitAccounts;
                    _gridLookUpEditDebitAccountView.PopulateColumns(debitAccounts);

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
                        ColumnCaption = "Tên tài khoản",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountCategoryId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountCategoryKind", ColumnVisible = false, });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountForeignName", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetSource", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetChapter", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetKindItem", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetItem", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetSubItem", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByMethodDistribute", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByAccountingObject", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByActivity", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByProject", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByTask", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailBySupply", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByInventoryItem", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByFixedAsset", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByFund", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBankAccount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByProjectActivity", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByInvestor", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsDisplayOnAccountBalanceSheet", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsDisplayBalanceOnReport", ColumnVisible = false });

                    //foreach (var column in gridColumnsCollection)
                    //{
                    //    if (column.ColumnVisible)
                    //    {
                    //        _gridLookUpEditDebitAccountView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    //        _gridLookUpEditDebitAccountView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                    //        _gridLookUpEditDebitAccountView.Columns[column.ColumnName].Width = column.ColumnWith;
                    //    }
                    //    else
                    //        _gridLookUpEditDebitAccountView.Columns[column.ColumnName].Visible = false;
                    //}
                    //_gridLookUpEditDebitAccount.DisplayMember = "AccountNumber";
                    //_gridLookUpEditDebitAccount.ValueMember = "AccountNumber";

                    _gridLookUpEditDebitAccountView = XtraColumnCollectionHelper<AccountModel>.CreateGridViewReponsitory();
                    _gridLookUpEditDebitAccount = XtraColumnCollectionHelper<AccountModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditDebitAccountView, debitAccounts, "AccountNumber", "AccountNumber", gridColumnsCollection);
                    XtraColumnCollectionHelper<AccountModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditDebitAccountView);
                    #endregion
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region BudgetKindItems

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
                    _budgetKindItemModels = value.Where(v => v.IsParent).ToList();
                    _budgetSubKindItemModels = value.Where(v => !v.IsParent).ToList();

                    _gridLookUpEditBudgetSubKindItemView = new GridView();
                    _gridLookUpEditBudgetSubKindItemView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditBudgetSubKindItem = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditBudgetSubKindItemView,
                        TextEditStyle = TextEditStyles.Standard
                    };
                    _gridLookUpEditBudgetSubKindItem.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetSubKindItem.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetSubKindItem.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditBudgetSubKindItem.View.BestFitColumns();

                    _gridLookUpEditBudgetSubKindItem.DataSource = _budgetSubKindItemModels;
                    _gridLookUpEditBudgetSubKindItemView.PopulateColumns(_budgetSubKindItemModels);

                    var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn {ColumnName = "BudgetKindItemId", ColumnVisible = false},
                        new XtraColumn
                        {
                            ColumnName = "BudgetKindItemCode",
                            ColumnCaption = "Mã Khoản",
                            ColumnPosition = 1,
                            ColumnVisible = true,
                            ColumnWith = 100
                        },
                        new XtraColumn
                        {
                            ColumnName = "BudgetKindItemName",
                            ColumnCaption = "Tên Khoản",
                            ColumnPosition = 2,
                            ColumnVisible = true,
                            ColumnWith = 250
                        },
                        new XtraColumn {ColumnName = "ParentId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Grade", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsParent", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsActive", ColumnVisible = false}
                    };
                    //foreach (var column in gridColumnsCollection)
                    //    if (column.ColumnVisible)
                    //    {
                    //        _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].Caption =
                    //            column.ColumnCaption;
                    //        _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].VisibleIndex =
                    //            column.ColumnPosition;
                    //        _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].Width = column.ColumnWith;
                    //    }
                    //    else
                    //    {
                    //        _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].Visible = false;
                    //    }
                    //_gridLookUpEditBudgetSubKindItem.DisplayMember = "BudgetKindItemCode";
                    //_gridLookUpEditBudgetSubKindItem.ValueMember = "BudgetKindItemCode";


                    _gridLookUpEditBudgetSubKindItemView = XtraColumnCollectionHelper<BudgetKindItemModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetSubKindItem = XtraColumnCollectionHelper<BudgetKindItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSubKindItemView, _budgetSubKindItemModels, "BudgetKindItemCode", "BudgetKindItemCode", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetKindItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSubKindItemView);

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Banks

        /// <summary>
        /// Sets the banks.
        /// </summary>
        /// <value>The banks.</value>
        public IList<BankModel> Banks
        {
            set
            {
                try
                {
                    if (value == null)
                        value = new List<BankModel>();

                    var gridColumnsCollection = new List<XtraColumn>();

                    _gridLookUpEditBankView = XtraColumnCollectionHelper<BankModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBank = XtraColumnCollectionHelper<BankModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBankView, value, "BankAccount", "BankId");

                    gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnCaption = "Số TK", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankName", ColumnCaption = "Tên ngân hàng", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });


                    _gridLookUpEditBankView = XtraColumnCollectionHelper<BankModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBank = XtraColumnCollectionHelper<BankModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBankView, value, "BankAccount", "BankId", gridColumnsCollection);
                    XtraColumnCollectionHelper<BankModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBankView);
                    

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Projects
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
                    _gridLookUpEditProject.TextEditStyle = TextEditStyles.Standard;
                    _gridLookUpEditProject.AllowNullInput = DefaultBoolean.True;
                    _gridLookUpEditProject.NullText = "";
                    _gridLookUpEditProject.KeyDown += _gridLookUpEditProjectView_KeyDown;

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
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsDetailbyActivityAndExpense", ColumnVisible = false });
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
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ObjectTypeName", ColumnVisible = false });

                    //foreach (var column in gridColumnsCollection)
                    //{
                    //    if (column.ColumnVisible)
                    //    {
                    //        _gridLookUpEditProjectView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    //        _gridLookUpEditProjectView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                    //        _gridLookUpEditProjectView.Columns[column.ColumnName].Width = column.ColumnWith;
                    //    }
                    //    else
                    //        _gridLookUpEditProjectView.Columns[column.ColumnName].Visible = false;
                    //}
                    //_gridLookUpEditProject.DisplayMember = "ProjectCode";
                    //_gridLookUpEditProject.ValueMember = "ProjectId";

                    _gridLookUpEditProjectView = XtraColumnCollectionHelper<ProjectModel>.CreateGridViewReponsitory();
                    _gridLookUpEditProject = XtraColumnCollectionHelper<ProjectModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditProjectView, value, "ProjectCode", "ProjectId", gridColumnsCollection);
                    XtraColumnCollectionHelper<ProjectModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditProjectView);


                    #region Lookup InvestProject


                    lookupProject.Properties.DataSource = value;
                    lookupProject.Properties.PopulateColumns();

                    var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn
                    {
                        ColumnName = "ProjectCode",
                        ColumnCaption = "Mã dự án đầu tư",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 120,
                        Alignment = HorzAlignment.Center
                    },
                    new XtraColumn
                    {
                        ColumnName = "ProjectName",
                        ColumnCaption = "Tên dự án đầu tư",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 330
                    },
                    new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ProjectNumber", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ProjectEnglishName", ColumnVisible = false },
                    new XtraColumn { ColumnName = "BUCACodeID", ColumnVisible = false },
                    new XtraColumn { ColumnName = "StartDate", ColumnVisible = false },
                    new XtraColumn { ColumnName = "FinishDate", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ExecutionUnit", ColumnVisible = false },
                    new XtraColumn { ColumnName = "DepartmentID", ColumnVisible = false },
                    new XtraColumn { ColumnName = "TotalAmountApproved", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ParentID", ColumnVisible = false },
                    new XtraColumn { ColumnName = "Grade", ColumnVisible = false },
                    new XtraColumn { ColumnName = "IsParent", ColumnVisible = false },
                    new XtraColumn { ColumnName = "IsDetailbyActivityAndExpense", ColumnVisible = false },
                    new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false },
                    new XtraColumn { ColumnName = "IsActive", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ObjectType", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ContractorID", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ContractorName", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ContractorAddress", ColumnVisible = false },
                    new XtraColumn { ColumnName = "Description", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ProjectSize", ColumnVisible = false },
                    new XtraColumn { ColumnName = "BuildLocation", ColumnVisible = false },
                    new XtraColumn { ColumnName = "InvestmentClass", ColumnVisible = false },
                    new XtraColumn { ColumnName = "CDCActivityType", ColumnVisible = false },
                    new XtraColumn { ColumnName = "BankId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "Investment", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ObjectTypeName", ColumnVisible = false },
                };
                    foreach (var column in columnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            lookupProject.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            lookupProject.Properties.SortColumnIndex = column.ColumnPosition;
                            lookupProject.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
                            lookupProject.Properties.Columns[column.ColumnName].Visible = false;
                        }
                    }
                    lookupProject.Properties.DisplayMember = "ProjectCode";
                    lookupProject.Properties.ValueMember = "ProjectCode";

                    #endregion


                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region FundStructures
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
                    _gridLookUpEditFundStructure.TextEditStyle = TextEditStyles.Standard;
                    _gridLookUpEditFundStructure.AllowNullInput = DefaultBoolean.True;
                    _gridLookUpEditFundStructure.NullText = "";
                    _gridLookUpEditFundStructure.KeyDown += _gridLookUpEditFundStructureView_KeyDown;

                    _gridLookUpEditFundStructure.DataSource = value;
                    _gridLookUpEditFundStructureView.PopulateColumns(value);
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "FundStructureId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "FundStructureCode",
                        ColumnCaption = "Mã khoản chi",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "FundStructureName",
                        ColumnCaption = "Tên khoản chi",
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
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BUCACodeId", ColumnVisible = false });
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
                    //_gridLookUpEditFundStructure.DisplayMember = "FundStructureName";
                    //_gridLookUpEditFundStructure.ValueMember = "FundStructureId";

                    _gridLookUpEditFundStructureView = XtraColumnCollectionHelper<FundStructureModel>.CreateGridViewReponsitory();
                    _gridLookUpEditFundStructure = XtraColumnCollectionHelper<FundStructureModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditFundStructureView, value, "FundStructureCode", "FundStructureId", gridColumnsCollection);
                    XtraColumnCollectionHelper<FundStructureModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditFundStructureView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region BudgetChapters

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
                    _gridLookUpEditBudgetChapter.TextEditStyle = TextEditStyles.Standard;
                    _gridLookUpEditBudgetChapter.AllowNullInput = DefaultBoolean.True;
                    _gridLookUpEditBudgetChapter.NullText = "";
                    _gridLookUpEditBudgetChapter.KeyDown += lookUpEditBudgetChapterCode_KeyDown;

                    _gridLookUpEditBudgetChapter.DataSource = value;
                    _gridLookUpEditBudgetChapterView.PopulateColumns(value);
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetChapterCode",
                        ColumnCaption = "Mã Chương",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetChapterName",
                        ColumnCaption = "Tên Chương",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });

                    //foreach (var column in gridColumnsCollection)
                    //{
                    //    if (column.ColumnVisible)
                    //    {
                    //        _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    //        _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                    //        _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].Width = column.ColumnWith;
                    //    }
                    //    else
                    //        _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].Visible = false;
                    //}
                    //_gridLookUpEditBudgetChapter.DisplayMember = "BudgetChapterCode";
                    //_gridLookUpEditBudgetChapter.ValueMember = "BudgetChapterCode";

                    _gridLookUpEditBudgetChapterView = XtraColumnCollectionHelper<BudgetChapterModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetChapter = XtraColumnCollectionHelper<BudgetChapterModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetChapterView, value, "BudgetChapterCode", "BudgetChapterCode", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetChapterModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetChapterView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Sets the accounting objects.
        /// </summary>
        /// <value>The accounting objects.</value>
        public IList<AccountingObjectModel> AccountingObjects
        {
            set
            {
                lookupVendor.Properties.DataSource = value;
                lookupVendor.Properties.PopulateColumns();

                var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn
                    {
                        ColumnName = "AccountingObjectCode",
                        ColumnCaption = "Mã nhà cung cấp",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 113,
                        Alignment = HorzAlignment.Center
                    },
                    new XtraColumn
                    {
                        ColumnName = "AccountingObjectName",
                        ColumnCaption = "Tên nhà cung cấp",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 330
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
                    new XtraColumn {ColumnName = "IsActive", ColumnVisible = false},
                    new XtraColumn {ColumnName = "EmployeeTypeId", ColumnVisible = false},
                    new XtraColumn { ColumnName = "BudgetChapterId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "BudgetChapterCode", ColumnVisible = false },
                    new XtraColumn { ColumnName = "BudgetChapterName", ColumnVisible = false },
                    new XtraColumn { ColumnName = "FundStructureId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "OrganizationFeeCode", ColumnVisible = false },
                    new XtraColumn { ColumnName = "OrganizationManageFee", ColumnVisible = false },
                    new XtraColumn { ColumnName = "BudgetItemId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "TreasuryManageFee", ColumnVisible = false }
                };
                foreach (var column in columnsCollection)
                {
                    if (lookupVendor.Properties.Columns[column.ColumnName] != null)
                    {
                        if (column.ColumnVisible)
                        {
                            lookupVendor.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            lookupVendor.Properties.SortColumnIndex = column.ColumnPosition;
                            lookupVendor.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
                            lookupVendor.Properties.Columns[column.ColumnName].Visible = false;
                        }
                    }

                }
                lookupVendor.Properties.DisplayMember = "AccountingObjectCode";
                lookupVendor.Properties.ValueMember = "AccountingObjectId";
            }
        }
        #endregion

        #region Currency

        /// <summary>
        /// Sets the currencies.
        /// </summary>
        /// <value>The currencies.</value>
        public IList<CurrencyModel> Currencies
        {
            set
            {
                try
                {
                    _gridLookUpEditCurrencyView = new GridView();
                    _gridLookUpEditCurrencyView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditCurrency = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditCurrencyView,
                        TextEditStyle = TextEditStyles.Standard
                    };
                    _gridLookUpEditCurrency.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditCurrency.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditCurrency.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditCurrency.View.BestFitColumns();

                    _gridLookUpEditCurrency.DataSource = value;
                    _gridLookUpEditCurrencyView.PopulateColumns(value);
                    var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn {ColumnName = "CurrencyId", ColumnVisible = false},
                        new XtraColumn
                        {
                            ColumnName = "CurrencyCode",
                            ColumnCaption = "Mã tiền",
                            ColumnPosition = 1,
                            ColumnVisible = true,
                            ColumnWith = 100
                        },
                        new XtraColumn
                        {
                            ColumnName = "CurrencyName",
                            ColumnCaption = "Tiền tệ",
                            ColumnPosition = 2,
                            ColumnVisible = true,
                            ColumnWith = 250
                        },
                        new XtraColumn {ColumnName = "Prefix", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Suffix", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsMain", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsActive", ColumnVisible = false},
                    };
                    foreach (var column in gridColumnsCollection)
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditCurrencyView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditCurrencyView.Columns[column.ColumnName].VisibleIndex =
                                column.ColumnPosition;
                            _gridLookUpEditCurrencyView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
                            _gridLookUpEditCurrencyView.Columns[column.ColumnName].Visible = false;
                        }
                    _gridLookUpEditCurrency.DisplayMember = "CurrencyCode";
                    _gridLookUpEditCurrency.ValueMember = "CurrencyCode";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region BudgetItem

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
                    var budgetItemModels = value.Where(v => v.BudgetItemType == 2 && v.IsActive).ToList();
                    var budgetSubItemModels = value.Where(v => v.BudgetItemType == 3 && v.IsActive).ToList();

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
                    //foreach (var column in gridColumnsCollection)
                    //{
                    //    if (column.ColumnVisible)
                    //    {
                    //        _gridLookUpEditBudgetItemView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    //        _gridLookUpEditBudgetItemView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                    //        _gridLookUpEditBudgetItemView.Columns[column.ColumnName].Width = column.ColumnWith;
                    //    }
                    //    else
                    //        _gridLookUpEditBudgetItemView.Columns[column.ColumnName].Visible = false;
                    //}
                    //_gridLookUpEditBudgetItem.DisplayMember = "BudgetItemCode";
                    //_gridLookUpEditBudgetItem.ValueMember = "BudgetItemCode";

                    _gridLookUpEditBudgetItemView = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetItem = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetItemView, budgetItemModels, "BudgetItemCode", "BudgetItemCode", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetItemView);
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
                    //foreach (var column in gridColumnsCollection)
                    //{
                    //    if (column.ColumnVisible)
                    //    {
                    //        _gridLookUpEditBudgetSubItemView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    //        _gridLookUpEditBudgetSubItemView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                    //        _gridLookUpEditBudgetSubItemView.Columns[column.ColumnName].Width = column.ColumnWith;
                    //    }
                    //    else
                    //        _gridLookUpEditBudgetSubItemView.Columns[column.ColumnName].Visible = false;
                    //}
                    //_gridLookUpEditBudgetSubItem.DisplayMember = "BudgetItemCode";
                    //_gridLookUpEditBudgetSubItem.ValueMember = "BudgetItemCode";
                    _gridLookUpEditBudgetSubItemView = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetSubItem = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSubItemView, budgetSubItemModels, "BudgetItemCode", "BudgetItemCode", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSubItemView);
                    #endregion
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #endregion

        #region Control Events

        /// <summary>
        /// Grids the accounting cell value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs" /> instance containing the event data.</param>
        protected override void GridAccountingCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "BudgetSubItemCode")
            {
                var budgetSubItemCode = (string)grdAccountingView.GetRowCellValue(e.RowHandle, "BudgetSubItemCode");
                var budgetItem = _budgetItemsPresenter.GetBudgetItems().Where(x => x.BudgetItemCode == budgetSubItemCode);
                foreach (var item in budgetItem)
                {
                    var budgetItemCode = _budgetItemsPresenter.GetBudgetItem(item.ParentId);
                    grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetItemCode", budgetItemCode.BudgetItemCode);
                }
            }
        }

        /// <summary>
        /// Handles the KeyDown event of the _gridLookUpEditAccountView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        private void _gridLookUpEditDebitAccountView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var account = grdAccountingView.Columns["DebitAccount"];
            grdAccountingView.SetRowCellValue(grdAccountingView.FocusedRowHandle, account, null);
            e.Handled = true;
        }

        /// <summary>
        /// Handles the KeyDown event of the _gridLookUpEditBudgetSourceView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        private void _gridLookUpEditBudgetSourceView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var budgetSourceCode = grdAccountingView.Columns["BudgetSourceId"];
            grdAccountingView.SetRowCellValue(grdAccountingView.FocusedRowHandle, budgetSourceCode, null);
            e.Handled = true;
        }

        /// <summary>
        /// Handles the KeyDown event of the _gridLookUpEditBudgetSubKindItemView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        private void _gridLookUpEditBudgetSubKindItemView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var budgetSourceCode = grdAccountingView.Columns["BudgetKindItemCode"];
            grdAccountingView.SetRowCellValue(grdAccountingView.FocusedRowHandle, budgetSourceCode, null);
            e.Handled = true;
        }

        /// <summary>
        /// Handles the KeyDown event of the _gridLookUpEditProjectView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        private void _gridLookUpEditProjectView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var budgetSourceCode = grdAccountingView.Columns["ProjectId"];
            grdAccountingView.SetRowCellValue(grdAccountingView.FocusedRowHandle, budgetSourceCode, null);
            e.Handled = true;
        }

        /// <summary>
        /// Handles the KeyDown event of the _gridLookUpEditFundStructureView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        private void _gridLookUpEditFundStructureView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var budgetSourceCode = grdAccountingView.Columns["FundStructureId"];
            grdAccountingView.SetRowCellValue(grdAccountingView.FocusedRowHandle, budgetSourceCode, null);
            e.Handled = true;
        }
        /// <summary>
        /// Handles the KeyDown event of the lookUpEditBudgetChapterCode control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        private void lookUpEditBudgetChapterCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var budgetSourceCode = grdAccountingView.Columns["BudgetChapterCode"];
            grdAccountingView.SetRowCellValue(grdAccountingView.FocusedRowHandle, budgetSourceCode, null);
            e.Handled = true;
        }

        /// <summary>
        /// Handles the CellValueChanged event of the grdAccountingView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs" /> instance containing the event data.</param>
        private void grdAccountingView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                if (!e.Column.FieldName.Equals("DetailBy"))
                {
                    var debitAccount = grdDetailByInventoryItemView.GetFocusedRowCellValue("DebitAccount");
                    var accountNumberDetailBy = "";
                    if (debitAccount != null)
                    {
                        accountNumberDetailBy = GetAccountDetailBy(debitAccount.ToString());
                    }

                    var detailByArray = accountNumberDetailBy.Split(';').Distinct().ToArray();
                    var detail = string.Join(";", detailByArray);
                    grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "DetailBy", detail);
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the checkIncurredCurrency control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkIncurredCurrency_CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit check = sender as CheckEdit;
            if (check.IsEditorActive)
            {
                _openingCommitmentPresenter.DisplayNoIsForeignCurrency(KeyValue);
                InitRefInfo();
            }
        }

        /// <summary>
        /// Handles the EditValueChanged event of the lookupProject control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void lookupProject_EditValueChanged(object sender, EventArgs e)
        {
            if (lookupProject.EditValue == null)
                return;
            var projectName = (string)lookupProject.GetColumnValue("ProjectName");

            txtProjectName.Text = projectName;
            var projectId = (string)lookupProject.GetColumnValue("ProjectId");

            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.Edit)
            {
                AutoProjectId = projectId;
                SetDetailFromMaster(grdAccountingView, 3, AccountingObjectId, BankAccount, projectId);
            }


        }

        /// <summary>
        /// Handles the EditValueChanged event of the lookupVendor control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void lookupVendor_EditValueChanged(object sender, EventArgs e)
        {
            if (lookupVendor.EditValue == null)
                return;
            var projectName = (string)lookupVendor.GetColumnValue("AccountingObjectName");
            var bankAccount = (string)lookupVendor.GetColumnValue("BankAccount");
            var bankName = (string)lookupVendor.GetColumnValue("BankName");
            txtVendorName.Text = projectName;
            txtBankName.Text = bankName;
            txtAccountNumber.Text = bankAccount;
        }

        private void lookupProject_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                FrmProjectDetail frmProjectDetail = new FrmProjectDetail();
                frmProjectDetail.ShowDialog();
                if (frmProjectDetail.CloseBox)
                {
                    if (!string.IsNullOrEmpty(GlobalVariable.ProjectIDAccountingObjectDetailForm))
                    {
                        _projectsPresenter.Display();
                        lookupProject.EditValue = GlobalVariable.ProjectIDAccountingObjectDetailForm;
                    }
                }
            }
        }

        private void lookupVendor_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                using (var frmDetail = new FrmXtraAccountingObjectDetail())
                {
                    frmDetail.ShowDialog();
                    if (frmDetail.CloseBox)
                    {
                        if (!string.IsNullOrEmpty(GlobalVariable.AccountingObjectIDInventoryItemDetailForm))
                        {
                            _accountingObjectsPresenter.Display();
                            lookupVendor.EditValue = GlobalVariable.AccountingObjectIDInventoryItemDetailForm;
                        }
                    }
                }
            }
        }
        #endregion

    }
}
