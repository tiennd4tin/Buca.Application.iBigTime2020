/***********************************************************************
 * <copyright file="FrmXtraAccountTransferDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 07 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountTransfer;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.XtraEditors;

namespace Buca.Application.iBigTime2020.WindowsForm.FormDictionary
{
    public class FrmXtraAccountTransferDetail : FrmXtraBaseCategoryDetail, IAccountTransferView, IAccountsView
    {
        //private readonly AccountsPresenter _accountsPresenter;
        private readonly AccountTransferPresenter _accountTransferPresenter;

        #region AccountTransfer

        /// <summary>
        /// Gets or sets the account tranfer identifier.
        /// </summary>
        /// <value>
        /// The account tranfer identifier.
        /// </value>
        public string AccountTransferId { get; set; }

        /// <summary>
        /// Gets or sets the account tranfer code.
        /// </summary>
        /// <value>
        /// The account tranfer code.
        /// </value>
        public string AccountTransferCode
        {
            get { return txtAccountTransferCode.Text; }
            set { txtAccountTransferCode.Text = value; }
        }

        public string ReferentAccount
        {
            get { return string.IsNullOrEmpty(grdLookUpEditReferentAccount.Text) ? null : (string)grdLookUpEditFromAccount.GetColumnValue("AccountCode"); }
            set { grdLookUpEditReferentAccount.Text = value; }
        }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>
        /// The sort order.
        /// </value>
        public int TransferOrder
        {
            get { return (int)spinTransferOrder.Value; }
            set { spinTransferOrder.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the account source code.
        /// </summary>
        /// <value>
        /// The account source code.
        /// </value>
        public string FromAccount
        {
            get { return string.IsNullOrEmpty(grdLookUpEditFromAccount.Text) ? null : (string)grdLookUpEditFromAccount.GetColumnValue("AccountCode"); }
            set { grdLookUpEditFromAccount.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the account destination code.
        /// </summary>
        /// <value>
        /// The account destination code.
        /// </value>
        public string ToAccount
        {
            get { return string.IsNullOrEmpty(grdLookUpEditToAccount.Text) ? null : (string)grdLookUpEditToAccount.GetColumnValue("AccountCode"); }
            set { grdLookUpEditToAccount.Text = value; }
        }

        /// <summary>
        /// Gets or sets the side of tranfer.
        /// </summary>
        /// <value>
        /// The side of tranfer.
        /// </value>
        public int TransferSide
        {
            get { return cboTransferSide.SelectedIndex; }
            set { cboTransferSide.SelectedIndex = value; }
        }

        public string BudgetSourceId
        {
            //get { return string.IsNullOrEmpty(grdLookUpEditBudgetSource.Text) ? null : (string)grdLookUpEditBudgetSource.GetColumnValue("BudgetSourceID"); }
            //set { grdLookUpEditBudgetSource.Text = value; }
            get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public int BusinessType
        {
            get { return cboBusinessType.SelectedIndex; }
            set { cboBusinessType.SelectedIndex = value; }
        }

        //public string AccountTransferId { get; set; }
        //public string AccountTransferCode { get; set; }
        //public int BusinessType { get; set; }
        //public string ReferentAccount { get; set; }
        //public int TransferOrder { get; set; }
        //public string FromAccount { get; set; }
        //public string ToAccount { get; set; }
        //public int TransferSide { get; set; }
        //public string BudgetSourceId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description
        {
            get { return memoDescription.Text; }
            set { memoDescription.Text = value; }
        }

        public bool IsSystem { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive
        {
            get { return chkIsActive.Checked; }
            set { chkIsActive.Checked = value; }
        }

        #endregion

        #region Combobox

        /// <summary>
        /// Sets the accounts.
        /// </summary>
        /// <value>
        /// The accounts.
        /// </value>
        public IList<AccountModel> Accounts
        {
            set
            {
                grdLookUpEditToAccount.Properties.DataSource = value;
                grdLookUpEditFromAccount.Properties.DataSource = value;
                grdLookUpEditReferentAccount.Properties.DataSource = value;
                grdLookUpEditToAccount.Properties.PopulateColumns();
                grdLookUpEditFromAccount.Properties.PopulateColumns();
                grdLookUpEditReferentAccount.Properties.PopulateColumns();
                var gridgridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn { ColumnName = "AccountId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "AccountCode", ColumnCaption = "Mã tài khoản", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100 },
                        new XtraColumn { ColumnName = "AccountCategoryId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "AccountName", ColumnCaption = "Tên tài khoản", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 300 },
                        new XtraColumn { ColumnName = "Description", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsActive", ColumnVisible = false },
                        new XtraColumn { ColumnName = "ForeignName", ColumnVisible = false },
                        new XtraColumn { ColumnName = "Grade", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsDetail", ColumnVisible = false },
                        new XtraColumn { ColumnName = "BalanceSide", ColumnVisible = false },
                        new XtraColumn { ColumnName = "ConcomitantAccount", ColumnVisible = false },
                        new XtraColumn { ColumnName = "BankId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsChapter", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsBudgetCategory", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsBudgetItem", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsBudgetGroup", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsBudgetSource", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsActivity", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsCurrency", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsCustomer", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsVendor", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsEmployee", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsAccountingObject", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsInventoryItem", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsFixedAsset", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsCapitalAllocate", ColumnVisible = false },
                        new XtraColumn { ColumnName = "ParentId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsCurrency", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsAllowinputcts", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsProject", ColumnVisible = false },
                        new XtraColumn { ColumnName = "CurrencyCode", ColumnVisible = false }
                    };

                foreach (var column in gridgridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        grdLookUpEditToAccount.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdLookUpEditToAccount.Properties.SortColumnIndex = column.ColumnPosition;
                        grdLookUpEditToAccount.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                        grdLookUpEditFromAccount.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdLookUpEditFromAccount.Properties.SortColumnIndex = column.ColumnPosition;
                        grdLookUpEditFromAccount.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                    {
                        grdLookUpEditToAccount.Properties.Columns[column.ColumnName].Visible = false;
                        grdLookUpEditFromAccount.Properties.Columns[column.ColumnName].Visible = false;
                    }
                }
                grdLookUpEditToAccount.Properties.DisplayMember = "AccountCode";
                grdLookUpEditToAccount.Properties.ValueMember = "AccountCode";
                grdLookUpEditFromAccount.Properties.DisplayMember = "AccountCode";
                grdLookUpEditFromAccount.Properties.ValueMember = "AccountCode";
                grdLookUpEditReferentAccount.Properties.DisplayMember = "AccountCode";
                grdLookUpEditReferentAccount.Properties.ValueMember = "AccountCode";
            }
        }

        /// <summary>
        /// Sets the accounts.
        /// </summary>
        /// <value>
        /// The accounts.
        /// </value>
        public IList<AccountModel> BudgetSource
        {
            set
            {
                grdLookUpEditToAccount.Properties.DataSource = value;
                grdLookUpEditFromAccount.Properties.DataSource = value;
                grdLookUpEditToAccount.Properties.PopulateColumns();
                grdLookUpEditFromAccount.Properties.PopulateColumns();
                var gridgridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn { ColumnName = "BudgetSourceId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "BudgetSourceCode", ColumnCaption = "Mã tài khoản", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100 },
                        new XtraColumn { ColumnName = "BudgetSourceName", ColumnVisible = false },
                        new XtraColumn { ColumnName = "ParentID", ColumnCaption = "Tên tài khoản", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 300 },
                        new XtraColumn { ColumnName = "IsParent", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsSavingExpenses", ColumnVisible = false },
                        new XtraColumn { ColumnName = "BudgetSourceCategoryId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "BudgetSourceProperty", ColumnVisible = false },
                        new XtraColumn { ColumnName = "BankAccount", ColumnVisible = false },
                        new XtraColumn { ColumnName = "BankName", ColumnVisible = false },
                        new XtraColumn { ColumnName = "PayableBankAccount", ColumnVisible = false },
                        new XtraColumn { ColumnName = "PayableBankName", ColumnVisible = false },
                        new XtraColumn { ColumnName = "TargetCode", ColumnVisible = false },
                        new XtraColumn { ColumnName = "TargetName", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsSelfControl", ColumnVisible = false }
                    };

                foreach (var column in gridgridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        grdLookUpEditToAccount.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdLookUpEditToAccount.Properties.SortColumnIndex = column.ColumnPosition;
                        grdLookUpEditToAccount.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                        grdLookUpEditFromAccount.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdLookUpEditFromAccount.Properties.SortColumnIndex = column.ColumnPosition;
                        grdLookUpEditFromAccount.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                    {
                        grdLookUpEditToAccount.Properties.Columns[column.ColumnName].Visible = false;
                        grdLookUpEditFromAccount.Properties.Columns[column.ColumnName].Visible = false;
                    }
                }
                grdLookUpEditToAccount.Properties.DisplayMember = "AccountCode";
                grdLookUpEditToAccount.Properties.ValueMember = "AccountCode";
                grdLookUpEditFromAccount.Properties.DisplayMember = "AccountCode";
                grdLookUpEditFromAccount.Properties.ValueMember = "AccountCode";
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraAccountTransferDetail"/> class.
        /// </summary>
        public FrmXtraAccountTransferDetail()
        {
            InitializeComponent();
            //_accountsPresenter = new AccountsPresenter(this);
            //_AccountTransferPresenter = new AccountTransferPresenter(this);
        }

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            //_accountTransferPresenter.DisplayActive();
            if (KeyValue != null)
                _accountTransferPresenter.Display(KeyValue);
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidData()
        {
            //if (string.IsNullOrEmpty(AccountTransferCode))
            //{
            //    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountTransferCode"),
            //                        ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtAccountTransferCode.Focus();
            //    return false;
            //}
            //if (string.IsNullOrEmpty(AccountSourceCode))
            //{
            //    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountSourceCode"),
            //                        ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    grdLookUpEditFromAccount.Focus();
            //    return false;
            //}
            //if (string.IsNullOrEmpty(AccountDestinationCode))
            //{
            //    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountDestinationCode"),
            //                        ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    grdLookUpEditToAccount.Focus();
            //    return false;
            //}
            //if (AccountSourceCode == AccountDestinationCode)
            //{
            //    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountSourceCodeSameAccountDestinationCode"),
            //                        ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    grdLookUpEditFromAccount.Focus();
            //    return false;
            //}
            return false;
        }

        ///// <summary>
        ///// Saves the data.
        ///// </summary>
        ///// <returns></returns>
        //protected override string SaveData()
        //{
        //    //return _AccountTransferPresenter.Save();
        //}

        /// <summary>
        /// Handles the KeyDown event of the grdLookUpEditAccountSourceCode control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void grdLookUpEditAccountSourceCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLookUpEditFromAccount.SelectionLength == grdLookUpEditFromAccount.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                grdLookUpEditFromAccount.EditValue = null;
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the KeyDown event of the grdLookUpEditAccountDestinationCode control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void grdLookUpEditAccountDestinationCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLookUpEditToAccount.SelectionLength == grdLookUpEditToAccount.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                grdLookUpEditToAccount.EditValue = null;
                e.Handled = true;
            }
        }

        #endregion

        private LabelControl labelControl8;
        private LabelControl labelControl5;
        private LookUpEdit grdLookUpEditReferentAccount;
        private ComboBoxEdit grdLookUpEditBudgetSource;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtAccountTransferCode = new DevExpress.XtraEditors.TextEdit();
            this.spinTransferOrder = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.grdLookUpEditFromAccount = new DevExpress.XtraEditors.LookUpEdit();
            this.grdLookUpEditToAccount = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboTransferSide = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cboBusinessType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.memoDescription = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.grdLookUpEditReferentAccount = new DevExpress.XtraEditors.LookUpEdit();
            this.grdLookUpEditBudgetSource = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountTransferCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinTransferOrder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpEditFromAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpEditToAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTransferSide.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBusinessType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpEditReferentAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpEditBudgetSource.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(277, 296);
            this.btnSave.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(353, 296);
            this.btnExit.TabIndex = 3;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(8, 296);
            this.btnHelp.TabIndex = 4;
            // 
            // groupboxMain
            // 
            this.groupboxMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupboxMain.Controls.Add(this.memoDescription);
            this.groupboxMain.Controls.Add(this.labelControl16);
            this.groupboxMain.Controls.Add(this.labelControl4);
            this.groupboxMain.Controls.Add(this.cboBusinessType);
            this.groupboxMain.Controls.Add(this.labelControl8);
            this.groupboxMain.Controls.Add(this.labelControl5);
            this.groupboxMain.Controls.Add(this.labelControl2);
            this.groupboxMain.Controls.Add(this.grdLookUpEditToAccount);
            this.groupboxMain.Controls.Add(this.labelControl6);
            this.groupboxMain.Controls.Add(this.labelControl7);
            this.groupboxMain.Controls.Add(this.spinTransferOrder);
            this.groupboxMain.Controls.Add(this.labelControl3);
            this.groupboxMain.Controls.Add(this.txtAccountTransferCode);
            this.groupboxMain.Controls.Add(this.labelControl1);
            this.groupboxMain.Controls.Add(this.grdLookUpEditReferentAccount);
            this.groupboxMain.Controls.Add(this.grdLookUpEditFromAccount);
            this.groupboxMain.Controls.Add(this.grdLookUpEditBudgetSource);
            this.groupboxMain.Controls.Add(this.cboTransferSide);
            this.groupboxMain.ShowCaption = true;
            this.groupboxMain.Size = new System.Drawing.Size(414, 259);
            this.groupboxMain.Text = "Thông tin chung";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(87, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "&Mã kết chuyển (*)";
            // 
            // txtAccountTransferCode
            // 
            this.txtAccountTransferCode.Location = new System.Drawing.Point(104, 24);
            this.txtAccountTransferCode.Name = "txtAccountTransferCode";
            this.txtAccountTransferCode.Size = new System.Drawing.Size(104, 20);
            this.txtAccountTransferCode.TabIndex = 1;
            // 
            // spinTransferOrder
            // 
            this.spinTransferOrder.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinTransferOrder.Location = new System.Drawing.Point(304, 24);
            this.spinTransferOrder.Name = "spinTransferOrder";
            this.spinTransferOrder.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinTransferOrder.Properties.IsFloatValue = false;
            this.spinTransferOrder.Properties.Mask.EditMask = "N00";
            this.spinTransferOrder.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.spinTransferOrder.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinTransferOrder.Size = new System.Drawing.Size(48, 20);
            this.spinTransferOrder.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(216, 28);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(46, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "&Số thứ tự";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(216, 52);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(84, 13);
            this.labelControl6.TabIndex = 6;
            this.labelControl6.Text = "Đế&n tài khoản (*)";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(8, 52);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(77, 13);
            this.labelControl7.TabIndex = 4;
            this.labelControl7.Text = "&Từ tài khoản (*)";
            // 
            // grdLookUpEditFromAccount
            // 
            this.grdLookUpEditFromAccount.EditValue = true;
            this.grdLookUpEditFromAccount.Location = new System.Drawing.Point(104, 48);
            this.grdLookUpEditFromAccount.Name = "grdLookUpEditFromAccount";
            this.grdLookUpEditFromAccount.Properties.AutoHeight = false;
            this.grdLookUpEditFromAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.grdLookUpEditFromAccount.Properties.NullText = "";
            this.grdLookUpEditFromAccount.Properties.PopupWidth = 450;
            this.grdLookUpEditFromAccount.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.grdLookUpEditFromAccount.Size = new System.Drawing.Size(104, 20);
            this.grdLookUpEditFromAccount.TabIndex = 5;
            this.grdLookUpEditFromAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdLookUpEditAccountSourceCode_KeyDown);
            // 
            // grdLookUpEditToAccount
            // 
            this.grdLookUpEditToAccount.EditValue = true;
            this.grdLookUpEditToAccount.Location = new System.Drawing.Point(304, 48);
            this.grdLookUpEditToAccount.Name = "grdLookUpEditToAccount";
            this.grdLookUpEditToAccount.Properties.AutoHeight = false;
            this.grdLookUpEditToAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.grdLookUpEditToAccount.Properties.NullText = "";
            this.grdLookUpEditToAccount.Properties.PopupWidth = 450;
            this.grdLookUpEditToAccount.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.grdLookUpEditToAccount.Size = new System.Drawing.Size(104, 20);
            this.grdLookUpEditToAccount.TabIndex = 7;
            this.grdLookUpEditToAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdLookUpEditAccountDestinationCode_KeyDown);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(8, 100);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(74, 13);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "&Bên kết chuyển";
            // 
            // cboTransferSide
            // 
            this.cboTransferSide.EditValue = "Cả hai bên";
            this.cboTransferSide.Location = new System.Drawing.Point(104, 96);
            this.cboTransferSide.Name = "cboTransferSide";
            this.cboTransferSide.Properties.AutoHeight = false;
            this.cboTransferSide.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTransferSide.Properties.Items.AddRange(new object[] {
            "Cả hai bên",
            "Bên nợ",
            "Bên có"});
            this.cboTransferSide.Properties.PopupSizeable = true;
            this.cboTransferSide.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboTransferSide.Size = new System.Drawing.Size(304, 20);
            this.cboTransferSide.TabIndex = 9;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(8, 124);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(75, 13);
            this.labelControl4.TabIndex = 10;
            this.labelControl4.Text = "&Loại kết chuyển";
            // 
            // cboBusinessType
            // 
            this.cboBusinessType.EditValue = "Kết chuyển cuối năm";
            this.cboBusinessType.Location = new System.Drawing.Point(104, 120);
            this.cboBusinessType.Name = "cboBusinessType";
            this.cboBusinessType.Properties.AutoHeight = false;
            this.cboBusinessType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboBusinessType.Properties.Items.AddRange(new object[] {
            "Kết chuyển cuối năm",
            "Kết chuyển đầu năm"});
            this.cboBusinessType.Properties.PopupSizeable = true;
            this.cboBusinessType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboBusinessType.Size = new System.Drawing.Size(304, 20);
            this.cboBusinessType.TabIndex = 11;
            // 
            // memoDescription
            // 
            this.memoDescription.Location = new System.Drawing.Point(104, 169);
            this.memoDescription.Name = "memoDescription";
            this.memoDescription.Size = new System.Drawing.Size(304, 80);
            this.memoDescription.TabIndex = 13;
            // 
            // labelControl16
            // 
            this.labelControl16.Location = new System.Drawing.Point(9, 203);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(40, 13);
            this.labelControl16.TabIndex = 12;
            this.labelControl16.Text = "&Diễn giải";
            // 
            // chkIsActive
            // 
            this.chkIsActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkIsActive.EditValue = true;
            this.chkIsActive.Location = new System.Drawing.Point(5, 272);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Properties.Caption = "Được sử dụng";
            this.chkIsActive.Size = new System.Drawing.Size(96, 19);
            this.chkIsActive.TabIndex = 1;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(10, 76);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(67, 13);
            this.labelControl5.TabIndex = 8;
            this.labelControl5.Text = "TK tham chiếu";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(9, 149);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(52, 13);
            this.labelControl8.TabIndex = 8;
            this.labelControl8.Text = "Nguồn vốn";
            // 
            // grdLookUpEditReferentAccount
            // 
            this.grdLookUpEditReferentAccount.EditValue = true;
            this.grdLookUpEditReferentAccount.Location = new System.Drawing.Point(104, 69);
            this.grdLookUpEditReferentAccount.Name = "grdLookUpEditReferentAccount";
            this.grdLookUpEditReferentAccount.Properties.AutoHeight = false;
            this.grdLookUpEditReferentAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.grdLookUpEditReferentAccount.Properties.NullText = "";
            this.grdLookUpEditReferentAccount.Properties.PopupWidth = 450;
            this.grdLookUpEditReferentAccount.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.grdLookUpEditReferentAccount.Size = new System.Drawing.Size(104, 20);
            this.grdLookUpEditReferentAccount.TabIndex = 5;
            this.grdLookUpEditReferentAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdLookUpEditAccountSourceCode_KeyDown);
            // 
            // grdLookUpEditBudgetSource
            // 
            this.grdLookUpEditBudgetSource.EditValue = "Cả hai bên";
            this.grdLookUpEditBudgetSource.Location = new System.Drawing.Point(104, 145);
            this.grdLookUpEditBudgetSource.Name = "grdLookUpEditBudgetSource";
            this.grdLookUpEditBudgetSource.Properties.AutoHeight = false;
            this.grdLookUpEditBudgetSource.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.grdLookUpEditBudgetSource.Properties.Items.AddRange(new object[] {
            "Cả hai bên",
            "Bên nợ",
            "Bên có"});
            this.grdLookUpEditBudgetSource.Properties.PopupSizeable = true;
            this.grdLookUpEditBudgetSource.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.grdLookUpEditBudgetSource.Size = new System.Drawing.Size(304, 20);
            this.grdLookUpEditBudgetSource.TabIndex = 9;
            // 
            // FrmXtraAccountTransferDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 328);
            this.ComponentName = "Tài khoản kết chuyển";
            this.Controls.Add(this.chkIsActive);
            this.EventTime = new System.DateTime(2019, 4, 2, 16, 22, 24, 129);
            this.FormCaption = "tài khoản kết chuyển";
            this.Name = "FrmXtraAccountTransferDetail";
            this.Reference = "THÊM TÀI KHOẢN KẾT CHUYỂN - ID ";
            this.Text = "FrmXtraAccountTranfer";
            this.Controls.SetChildIndex(this.btnPrintFixAsset, 0);
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            this.Controls.SetChildIndex(this.chkIsActive, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountTransferCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinTransferOrder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpEditFromAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpEditToAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTransferSide.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBusinessType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpEditReferentAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpEditBudgetSource.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtAccountTransferCode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SpinEdit spinTransferOrder;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit grdLookUpEditToAccount;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LookUpEdit grdLookUpEditFromAccount;
        private DevExpress.XtraEditors.ComboBoxEdit cboTransferSide;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ComboBoxEdit cboBusinessType;
        private DevExpress.XtraEditors.MemoEdit memoDescription;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.CheckEdit chkIsActive;
    }
}