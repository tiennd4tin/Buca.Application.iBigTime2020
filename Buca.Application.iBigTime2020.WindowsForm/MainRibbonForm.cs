/***********************************************************************
 * <copyright file="MainRibbonForm.cs" company="Linh Khang">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Author:   LinhMC
 * Email:    linhmc.vn@gmail.comFrmCAReceiptDetail
 * Website:
 * Create Date: Sunday, February 09, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.Presenter.Dictionary.AudittingLog;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.CAPayment;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.FixedAsset;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.General;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.AccountTransfer;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.AccountingObject;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.AutoBusiness;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.BudgetItem;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.BudgetKindItem;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.BudgetSource;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Employee;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.InvoiceFormNumber;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.VoucherList;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using Buca.Application.iBigTime2020.WindowsForm.UserControl.DiagramDesktop;
using BuCA.Application.iBigTime2020.Report.MainReport;
using BuCA.Application.iBigTime2020.Report.ReportClass;
using BuCA.Application.iBigTime2020.Session;
using BuCA.Enum;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.BusinessEntities.System;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.System;
using Buca.Application.iBigTime2020.Presenter.System.Permission;
using Buca.Application.iBigTime2020.View.System;
using Buca.Application.iBigTime2020.WindowsForm.Code;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.BADeposit;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.BAWithDraw;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.CAReceipt;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Estimate;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.IncrementDecrement;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Inventory;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.OpeningAccount;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Account;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.AccountCategory;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.FixedAssetCategory;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.BudgetChapter;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.InventoryItem;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.RefType;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Stock;
using Buca.Application.iBigTime2020.WindowsForm.FormSystem;
using AssemblyInfomation = Buca.Application.iBigTime2020.WindowsForm.Code.AssemblyInfomation;
using Timer = System.Windows.Forms.Timer;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Activity;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.AutoBusinessParallel;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.BudgetExpense;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Currency;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.FixedAsset;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Project;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Tool;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.FundStructure;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.EmployeeType;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Department;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.PurchasePurpose;
using Buca.Application.iBigTime2020.WindowsForm.FormSystem.UserProfile;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness;
using DevExpress.XtraBars.Ribbon;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.PUInvoice;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using Buca.Application.iBigTime2020.DataHelpers;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Bank;
using BuCA.Option;
using Buca.AutoUpdater.Core;
using DevExpress.LookAndFeel;
//using Buca.TransformData;
using PerpetuumSoft.Framework.Model.Design;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Cash;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.CapitalPlan;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Contract;
using Microsoft.Win32;
using Microsoft.SqlServer.Management.Smo.Broker;
using Microsoft.SqlServer.Replication;

//using Buca.Application.iBigTime2020.WindowsForm.FormSystem;

namespace Buca.Application.iBigTime2020.WindowsForm
{
    /// <summary>
    /// Main form application
    /// </summary>
    public partial class MainRibbonForm : DevExpress.XtraBars.Ribbon.RibbonForm, IAudittingLogView, IFeaturesView
    {
        private bool _loginState;
        private bool _autoUpdateClicked = false;
        public ActionModeVoucherEnum ActionMode;
        //public static MainRibbonForm _frmMain;

        /// <summary>
        /// The _auditting log presenter
        /// </summary>
        private readonly AudittingLogPresenter _audittingLogPresenter;
        private readonly FeaturesPresenter _featuresPresenter;
        private readonly Crypto Crypto = new Crypto(Crypto.SymmProvEnum.Rijndael);
        private IList<UserFeaturePermisionModel> _listPermissionMapingModels;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainRibbonForm"/> class.
        /// </summary>
        public MainRibbonForm()
        {
            InitializeComponent();
            CommonFunction.CommonUserControl = new XtraUserControl();
            //_audittingLogPresenter = new AudittingLogPresenter(this);
            _featuresPresenter = new FeaturesPresenter(this);
        }

        /// <summary>
        /// Sets the state of the close data.
        /// </summary>
        /// <param name="flag">if set to <c>true</c> [flag].</param>
        void SetCloseDataState(bool flag)
        {
            if (flag)
            {
                navBarMainLeft.Visible = false;
                ribbonPageGroup2.Visible = false;
                barButtonChangePassword.Visibility = BarItemVisibility.Never;
                if (mainPanelControl != null)
                {
                    mainPanelControl.MainPanel.Controls.Clear();
                }
            }
            else
            {
                navBarMainLeft.Visible = true;
                ribbonPageGroup2.Visible = true;
                barButtonChangePassword.Visibility = BarItemVisibility.Never;
            }
        }

        /// <summary>
        /// Handles the ItemClick event of the ribbonMainMenu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ItemClickEventArgs"/> instance containing the event data.</param>
        private void ribbonMainMenu_ItemClick(object sender, ItemClickEventArgs e)
        {
            var validForInitGlobalVariable = false;
            try
            {
                Cursor.Current = Cursors.WaitCursor; //barButtonSearch
                switch (e.Item.Name)
                {
                    case "barButtonBUTransfersPayInsurrance":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmBUTransfersPayInsurrance))
                        {
                            var userControl = new FrmBUTransfersPayInsurrance { Dock = DockStyle.Fill, HelpTopicId = 92 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResBUTransfersPayInsurrance");
                        }
                        break;
                    case "barButtonBUTransfersPayWage":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmBUTransfersPayWage))
                        {
                            var userControl = new FrmBUTransfersPayWage { Dock = DockStyle.Fill, HelpTopicId = 91 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResBUTransfersPayWage");
                        }
                        break;
                    case "barButtonBUPlanWithdrawTransferInsurrance":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmBUPlanWithdrawTransferInsurrance))
                        {
                            var userControl = new FrmBUPlanWithdrawTransferInsurrance { Dock = DockStyle.Fill, HelpTopicId = 80 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResBUPlanWithdrawTransferInsurrance");
                        }
                        break;
                    case "barButtonPerformancResults": // xác định kết quả hoạt động
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmGLVouchersPerformanceResults))
                        {
                            var userControl = new FrmGLVouchersPerformanceResults { Dock = DockStyle.Fill, HelpTopicId = 137 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResGLVouchersPerformanceResults");
                        }
                        break;
                    case "barButtonGLVouchersEarlyYear": // Chi phí ĐTXDCB chờ quyết toán
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmGLVouchersEarlyYear))
                        {
                            var userControl = new FrmGLVouchersEarlyYear { Dock = DockStyle.Fill, HelpTopicId = 135 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResGLVouchersEarlyYear");
                        }
                        break;
                    case "barButtonTransferLastYear": // Quyết toán dự án hoàn thành
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmGLVouchersLastYear))
                        {
                            var userControl = new FrmGLVouchersLastYear { Dock = DockStyle.Fill, HelpTopicId = 136 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResGLVouchersLastYear");
                        }
                        break;
                    //case "barButtonTransferItem":
                    //    if (CommonFunction.CommonUserControl != null &&
                    //        CommonFunction.CommonUserControl.GetType() != typeof(FrmGLVoucherList))
                    //    {
                    //        var userControl = new FrmGLVoucherList { Dock = DockStyle.Fill, HelpTopicId = 1010 };
                    //        CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                    //        mainPanelControl.FeatureCaption.Text =
                    //            ResourceHelper.GetResourceValueByName("ResFrmGLVouchers");
                    //    }
                    //    break;
                    case "barButtonBUPlanWithdrawDeposit":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmBUPlanWithDrawDeposits))
                        {
                            var userControl = new FrmBUPlanWithDrawDeposits { Dock = DockStyle.Fill, HelpTopicId = 78 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResBUPlanWithDrawDepositCaption");
                        }
                        break;
                    case "barButtonBUPlanCancel":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmBUPlanCancels))
                        {
                            var userControl = new FrmBUPlanCancels { Dock = DockStyle.Fill, HelpTopicId = 83 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResBUPlanCanclesCaption");
                        }
                        break;
                    case "barButtonBUBudgetReserve":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmBUBudgetReserves))
                        {
                            var userControl = new FrmBUBudgetReserves { Dock = DockStyle.Fill, HelpTopicId = 82 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResBUBudgetReservesCaption");
                        }
                        break;
                    case "barButtonBUVoucherList":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmBUVoucherLists))
                        {
                            var userControl = new FrmBUVoucherLists { Dock = DockStyle.Fill, HelpTopicId = 94 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResBUVoucherListCaption");
                        }
                        break;
                    case "barButtonBUNoEstimateVoucherList":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmBUNoEstimateVoucherLists))
                        {
                            var userControl = new FrmBUNoEstimateVoucherLists { Dock = DockStyle.Fill, HelpTopicId = 95 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResBUNoEstimateVoucherListCaption");
                        }
                        break;
                    case "barButtonBUCashBasicVoucherList":    //Bảng kê chứng từ thanh toán thực chi
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmBUCashBasicVoucherLists))
                        {
                            var userControl = new FrmBUCashBasicVoucherLists { Dock = DockStyle.Fill, HelpTopicId = 95 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResBUCashBasicVoucherListCaption");
                        }
                        break;
                    case "barButtonGLPaymentList":    //Phân bổ thanh toán tạm ứng
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmGLPaymentList))
                        {
                            var userControl = new FrmGLPaymentList { Dock = DockStyle.Fill, HelpTopicId = 95 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResGLPaymentList");
                        }
                        break;
                    case "barButtonBUPlanReceipt":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmBUplanReceipts))
                        {
                            var userControl = new FrmBUplanReceipts() { Dock = DockStyle.Fill, HelpTopicId = 75 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResbarButtonBUPlanReceiptCaption");
                        }
                        break;
                    case "barButtonBUPlanAdjustment": //Chứng từ điều chỉnh dự toán
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmBUPlanAdjustment))
                        {
                            var userControl = new FrmBUPlanAdjustment() { Dock = DockStyle.Fill, HelpTopicId = 81 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResbarButtonBUPlanAdjustmentCaption");
                        }
                        break;

                    case "barButtonCommitmentRequest":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmBUCommitmentRequests))
                        {
                            var userControl = new FrmBUCommitmentRequests() { Dock = DockStyle.Fill, HelpTopicId = 85 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResbarButtonBUCommitmentRequestCaption");
                        }
                        break;


                    case "barButtonCommitmentAdjustment":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmBUCommitmentAdjustments))
                        {
                            var userControl = new FrmBUCommitmentAdjustments() { Dock = DockStyle.Fill, HelpTopicId = 86 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResbarButtonCommitmentAdjustmentCaption");
                        }
                        break;
                    case "barButtonBUTransfer":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmBUTransfers))
                        {
                            var userControl = new FrmBUTransfers() { Dock = DockStyle.Fill, HelpTopicId = 89 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResbarButtonBUTransferCaption");
                        }
                        break;
                    case "barButtonBUTransferDeposits":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmBUTransferDeposits))
                        {
                            var userControl = new FrmBUTransferDeposits() { Dock = DockStyle.Fill, HelpTopicId = 90 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResbarButtonBUTransferDepositsCaption");
                        }
                        break;

                    case "barButtonBUTransferPurchase":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmBUTransferPurchases))
                        {
                            var userControl = new FrmBUTransferPurchases() { Dock = DockStyle.Fill, HelpTopicId = 113 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text = "Nhập mua bằng chuyển khoản";
                        }
                        break;

                    case "barButtonBUTransferFixedAsset":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmBUTransferFixedAssets))
                        {
                            var userControl = new FrmBUTransferFixedAssets() { Dock = DockStyle.Fill, HelpTopicId = 125 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text = "Mua TSCĐ bằng chuyển khoản";
                        }
                        break;

                    case "barButtonOpeningCommitment":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmOpeningCommitments))
                        {
                            var userControl = new FrmOpeningCommitments() { Dock = DockStyle.Fill, HelpTopicId = 87 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResbarButtonOpeningCommitmentsCaption");
                        }
                        break;

                    case "barButtonSUIncrement":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmSUIncrements))
                        {
                            var userControl = new FrmSUIncrements { Dock = DockStyle.Fill, HelpTopicId = 118 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResSUIncrementCaption");
                        }
                        break;
                    case "barButtonSUDecrement":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmSUDecrements))
                        {
                            var userControl = new FrmSUDecrements { Dock = DockStyle.Fill, HelpTopicId = 119 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResSUDecrementCaption");
                        }
                        break;
                    case "barButtonSUTransfer"://CCDC
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmSUTransfers))
                        {
                            var userControl = new FrmSUTransfers { Dock = DockStyle.Fill, HelpTopicId = 120 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResSUTransferCaption");
                        }
                        break;
                    case "barButtonAccountDefault":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmRefTypes))
                        {
                            var userControl = new FrmRefTypes { Dock = DockStyle.Fill, HelpTopicId = 38 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResrefTypeCaption");
                        }
                        break;
                    case "barButtonBAWithDraw":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmBAWithDraws))
                        {
                            var userControl = new FrmBAWithDraws { Dock = DockStyle.Fill, HelpTopicId = 106 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResBAWithDrawsCaption");
                        }
                        break;
                    case "barButtonBAWithDrawPurchase":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmBAWithDrawPurchases))
                        {
                            var userControl = new FrmBAWithDrawPurchases { Dock = DockStyle.Fill, HelpTopicId = 112 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResBAWithDrawPurchasesCaption");
                        }
                        break;
                    case "barButtonPurchasePurpose":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmPurchasePurposes))
                        {
                            var userControl = new FrmPurchasePurposes { Dock = DockStyle.Fill, HelpTopicId = 57 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("RespurchasePurposeCaption");
                        }
                        break;
                    case "barButtonBADeposit":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmBADeposits))
                        {
                            var userControl = new FrmBADeposits { Dock = DockStyle.Fill, HelpTopicId = 105 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResBADepositCaption");
                        }
                        break;

                    case "barButtonBABankTransfers":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmBABankTransfers))
                        {
                            var userControl = new FrmBABankTransfers { Dock = DockStyle.Fill, HelpTopicId = 107 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResBABankTransfersCaption");
                        }
                        break;
                    case "barButtonINInward":
                        if (CommonFunction.CommonUserControl != null &&
                           CommonFunction.CommonUserControl.GetType() != typeof(FrmINInward))
                        {
                            var userControl = new FrmINInward() { Dock = DockStyle.Fill, HelpTopicId = 110 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResINInwardCaption");
                        }
                        break;
                    case "barButtonBAWithDrawFixedAsset":
                        if (CommonFunction.CommonUserControl != null &&
                        CommonFunction.CommonUserControl.GetType() != typeof(FrmBAWithDrawFixedAsset))
                        {
                            var userControl = new FrmBAWithDrawFixedAsset() { Dock = DockStyle.Fill, HelpTopicId = 124 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResBAWithDrawFixedAsset");
                        }
                        break;
                    case "barButtonUpdateDatabase":
                        using (var frmXtraUpdateDatabase = new FrmXtraUpdateDatabase())
                        {
                            frmXtraUpdateDatabase.ShowDialog();
                        }
                        break;
                    case "barItemRestoreData":
                        using (var frmXtraRestoreData = new FrmXtraRestoreData())
                        {
                            frmXtraRestoreData.ShowDialog();
                        }
                        break;

                    case "barButtonOpeningSupplyEntry":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmOpeningSupplyEntries))
                        {
                            var userControl = new FrmOpeningSupplyEntries { Dock = DockStyle.Fill, HelpTopicId = 117 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text = ResourceHelper.GetResourceValueByName("ResOpeningSupplyEntryCaption");
                        }
                        break;

                    case "barItemBackUpData":
                        using (var frmXtraBackUpData = new FrmXtraBackUpData())
                        {
                            frmXtraBackUpData.ShowDialog();
                        }
                        break;

                    case "barButtonHelpItem":
                        if (File.Exists("BIGTIME.CHM"))
                            Process.Start("BIGTIME.CHM");
                        break;

                    case "barButtonHelpOnline":
                        //  var info = new ProcessStartInfo(@"C:\Program Files (x86)\UltraViewer\UltraViewer_Desktop.exe");
                        //  Process.Start(info);
                        //Process.Start(System.Windows.Forms.Application.StartupPath + @"\TeamViewer.exe");
                        Process.Start(System.Windows.Forms.Application.StartupPath + @"\TeamViewer\TeamViewer.exe");
                        break;

                    case "barButtonCloseData":
                        pageCategory.Visible = false;
                        pageTreasury.Visible = false;
                        barButtonLoginItem.Visibility = BarItemVisibility.Always;
                        barButtonCloseData.Visibility = BarItemVisibility.Never;
                        SetCloseDataState(true);
                        GlobalVariable.Server.ConnectionContext.SqlConnectionObject.Close();
                        break;
                    case "barButtonLoginItem":
                        pageCategory.Visible = false;
                        pageTreasury.Visible = false;
                        if (RegistryHelper.GetValueByRegistryKey("DatabaseName").Equals("master"))
                        {
                            using (var frmCreateNewDatabase = new FrmCreateNewDatabase())
                            {
                                if (frmCreateNewDatabase.ShowDialog() == DialogResult.OK)
                                {
                                    validForInitGlobalVariable = true;
                                }
                            }
                        }
                        else
                        {
                            using (var frmLogin = new FrmLogin())
                            {
                                frmLogin.PostLoginState += MainRibbonForm_GetLoginState;
                                if (frmLogin.ShowDialog() == DialogResult.OK)
                                {
                                    validForInitGlobalVariable = true;
                                }
                            }
                            if (!_loginState)
                                return;
                            barButtonLoginItem.Visibility = BarItemVisibility.Never;
                            barButtonCloseData.Visibility = BarItemVisibility.Always;
                            pageCategory.Visible = true;
                            pageTreasury.Visible = true;
                            pageHelp.Visible = true;
                            SetCloseDataState(false);
                            if (new FrmXtraPostedDate().ShowDialog() == DialogResult.OK)
                            {
                                validForInitGlobalVariable = true;
                            }
                        }
                        break;
                    case "barButtonRegisterItem":
                        using (var frmRegister = new FrmXtraRegister())
                        {
                            frmRegister.ShowDialog();
                        }
                        break;
                    case "barButtonAboutItem":
                        using (var frmAbout = new XtraAboutForm())
                        {
                            frmAbout.ShowDialog();
                        }
                        break;

                    case "barButtonAutoUpdateItem":
                        if (IsExpried())
                            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("IsExpriedForUpdate"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        else
                        {
                            CheckForNewVersion(false);
                        }
                        break;

                    //case "barButtonOpeningInventory":
                    //    if (CommonFunction.CommonUserControl != null &&
                    //        CommonFunction.CommonUserControl.GetType() != typeof(UserControlOpeningInventoryList))
                    //    {
                    //        var userControl = new UserControlOpeningInventoryList { Dock = DockStyle.Fill, HelpTopicId = 3050 };
                    //        CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                    //    }
                    //    break;
                    //case "barButtonOpeningFixedAssetEntry":
                    //    if (CommonFunction.CommonUserControl != null &&
                    //        CommonFunction.CommonUserControl.GetType() != typeof(UserControlOpeningFixedAssetList))
                    //    {
                    //        var userControl = new UserControlOpeningFixedAssetList { Dock = DockStyle.Fill, HelpTopicId = 3060 };
                    //        CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                    //    }
                    //    break;
                    case "barButtonCreateNewDatabase":
                        using (var frmCreateNewDatabase = new FrmCreateNewDatabase())
                        {
                            frmCreateNewDatabase.ShowDialog();
                        }
                        break;
                    case "barButtonOpenData":
                        var frmXtraOpenDatabase = new FrmXtraOpenDatabase();
                        if (frmXtraOpenDatabase.ShowDialog() == DialogResult.OK)
                            validForInitGlobalVariable = true;
                        break;

                    case "barButtonUser":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlUserProfileList))
                        {
                            var userControl = new UserControlUserProfileList { Dock = DockStyle.Fill, HelpTopicId = 1010 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResUserProfileCaption");
                        }
                        break;
                    case "barConvertDataItem":
                        using (var formConvertTool = new FrmConvertDatabase())
                        {
                            formConvertTool.ShowDialog();
                        }

                        break;

                    case "barButtonSearch":
                        var frmXtraSearchVoucher = new FrmXtraSearchVoucher();
                        frmXtraSearchVoucher.ShowDialog();
                        break;
                    //case "barInputInventory":
                    //    if (CommonFunction.CommonUserControl != null &&
                    //        CommonFunction.CommonUserControl.GetType() != typeof(UserControlInputInventoryList))
                    //    {
                    //        var userControl = new UserControlInputInventoryList { Dock = DockStyle.Fill, HelpTopicId = 5010 };

                    //        CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                    //        mainPanelControl.FeatureCaption.Text =
                    //            ResourceHelper.GetResourceValueByName("ResInputInventoryListCaption");
                    //    }
                    //    break;
                    //case "barSalaryItem":
                    //    if (CommonFunction.CommonUserControl != null &&
                    //        CommonFunction.CommonUserControl.GetType() != typeof(UserControlSalaryList))
                    //    {
                    //        _globalVariable = new GlobalVariable();
                    //        var userControl = new UserControlSalaryList { Dock = DockStyle.Fill, HelpTopicId = 5070 };
                    //        CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                    //        mainPanelControl.FeatureCaption.Text = ResourceHelper.GetResourceValueByName("ResSalaryListCaption") + @" năm " +
                    //        DateTime.Parse(_globalVariable.PostedDate).Year;
                    //    }
                    //    break;
                    case "barButtonBUPlanWithdrawTransfer":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmBUPlanWithDrawTransfers))
                        {
                            var userControl = new FrmBUPlanWithDrawTransfers { Dock = DockStyle.Fill, HelpTopicId = 79 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResBUPlanWithDrawTransferCaption");
                        }
                        break;
                    //case "barCurrencyItem":
                    //    if (CommonFunction.CommonUserControl != null &&
                    //        CommonFunction.CommonUserControl.GetType() != typeof(UserControlCurrencyList))
                    //    {
                    //        var userControl = new UserControlCurrencyList { Dock = DockStyle.Fill, HelpTopicId = 2030 };
                    //        CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                    //        mainPanelControl.FeatureCaption.Text =
                    //            ResourceHelper.GetResourceValueByName("ResCurrencyCaption");
                    //    }
                    //    break;
                    //case "barButtonAccountItem":
                    //    if (CommonFunction.CommonUserControl != null &&
                    //        CommonFunction.CommonUserControl.GetType() != typeof(UserControlAccountList))
                    //    {
                    //        var userControl = new UserControlAccountList { Dock = DockStyle.Fill, HelpTopicId = 1010 };
                    //        CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                    //        mainPanelControl.FeatureCaption.Text =
                    //            ResourceHelper.GetResourceValueByName("ResAccountCaption");
                    //    }
                    //    break;
                    case "barButtonCAReceipt":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmCAReceipts))
                        {
                            var userControl = new FrmCAReceipts { Dock = DockStyle.Fill, HelpTopicId = 98 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResCashReceiptCaption");
                        }
                        break;
                    case "barButtonPaymentItem":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmCAReceiptTreasuries))
                        {
                            var userControl = new FrmCAReceiptTreasuries { Dock = DockStyle.Fill, HelpTopicId = 99 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResCashReceiptTreasuriesCaption");
                        }
                        break;
                    case "barButtonCAPaymentInward":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmCAPaymentInwards))
                        {
                            var userControl = new FrmCAPaymentInwards { Dock = DockStyle.Fill, HelpTopicId = 111 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text = ResourceHelper.GetResourceValueByName("ResCAPaymentInwardCaption");
                        }
                        break;
                    case "barButtonCAReceiptEstimate": //Phieu thu tu ngan sach nha nuoc
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmCAReceiptEstimates))
                        {
                            var userControl = new FrmCAReceiptEstimates { Dock = DockStyle.Fill, HelpTopicId = 100 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResCashReceiptEstimateCaption");
                        }
                        break;

                    case "barButtonCAPaymentTreasury":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmCAPaymentTreasuries))
                        {
                            var userControl = new FrmCAPaymentTreasuries { Dock = DockStyle.Fill, HelpTopicId = 103 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResCAPaymentTreasuryCaption");
                        }

                        break;
                    case "barButtonCAPayment":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmCAPayment))
                        {
                            var userControl = new FrmCAPayment { Dock = DockStyle.Fill, HelpTopicId = 102 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResCAPaymentCaption");
                        }

                        break;
                         
                    case "barButtonDepartment":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmDepartments))
                        {
                            var userControl = new FrmDepartments { Dock = DockStyle.Fill, HelpTopicId = 49 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResDepartmentCaption");
                        }
                        break;
                    case "barButtonEmployeeType":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmEmployeeTypes))
                        {
                            var userControl = new FrmEmployeeTypes { Dock = DockStyle.Fill, HelpTopicId = 51 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResEmployeeTypeCaption");
                        }
                        break;
                    case "barButtonFixedAssetCategory":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmFixedAssetCategories))
                        {
                            var userControl = new FrmFixedAssetCategories { Dock = DockStyle.Fill, HelpTopicId = 59 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResFixedAssetCategoryCaption");
                        }
                        break;
                    case "barButtonFixedAsset":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmFixedAssets))
                        {
                            var userControl = new FrmFixedAssets() { Dock = DockStyle.Fill, HelpTopicId = 60 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResFixedAssetCaption");
                        }
                        break;
                    case "barBudgetItem":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmBudgetItems))
                        {
                            var userControl = new FrmBudgetItems { Dock = DockStyle.Fill, HelpTopicId = 47 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResBudgetItemCaption");
                        }
                        break;
                    case "barBudgetKindItem":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmBudgetKindItems))
                        {
                            var userControl = new FrmBudgetKindItems { Dock = DockStyle.Fill, HelpTopicId = 46 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResBudgetKindItemCaption");
                        }
                        break;
                    //case "barButtonPayItem":
                    //    if (CommonFunction.CommonUserControl != null &&
                    //        CommonFunction.CommonUserControl.GetType() != typeof(UserControlPayItemList))
                    //    {
                    //        var userControl = new UserControlPayItemList { Dock = DockStyle.Fill, HelpTopicId = 2060 };
                    //        CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                    //        mainPanelControl.FeatureCaption.Text =
                    //            ResourceHelper.GetResourceValueByName("ResPayItemCaption");
                    //    }
                    //    break;
                    case "barButtonAccount":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmAccounts))
                        {
                            var userControl = new FrmAccounts { Dock = DockStyle.Fill, HelpTopicId = 36 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text = ResourceHelper.GetResourceValueByName("ResAccountCaption");
                        }
                        break;
                    case "barButtonAccountCategory":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmAccountingCategories))
                        {
                            var userControl = new FrmAccountingCategories { Dock = DockStyle.Fill, HelpTopicId = 35 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text = ResourceHelper.GetResourceValueByName("ResAccountCategoryCaption");
                        }
                        break;
                    //case "barCustomers":
                    //    if (CommonFunction.CommonUserControl != null &&
                    //        CommonFunction.CommonUserControl.GetType() != typeof(UserControlCustomerList))
                    //    {
                    //        var userControl = new UserControlCustomerList { Dock = DockStyle.Fill, HelpTopicId = 1010 };
                    //        CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                    //        mainPanelControl.FeatureCaption.Text =
                    //            ResourceHelper.GetResourceValueByName("ResCustomer");
                    //    }
                    //    break;
                    //case "barVendor":
                    //    if (CommonFunction.CommonUserControl != null &&
                    //        CommonFunction.CommonUserControl.GetType() != typeof(UserControlVendorList))
                    //    {
                    //        var userControl = new UserControlVendorList { Dock = DockStyle.Fill, HelpTopicId = 2080 };
                    //        CommonFunction.RunUserControl(userControl, mainPanelControl.MaibarButtonBUPlanWithdrawCashnPanel);
                    //        mainPanelControl.FeatureCaption.Text =
                    //            ResourceHelper.GetResourceValueByName("ResVendor");
                    //    }
                    //    break;
                    case "barButtonAccountingObject":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmAccountingObjects))
                        {
                            var userControl = new FrmAccountingObjects { Dock = DockStyle.Fill, HelpTopicId = 50 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResAccountingObject");
                        }
                        break;
                    case "barButtonCareerWork":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmActivitys))
                        {
                            var userControl = new FrmActivitys { Dock = DockStyle.Fill, HelpTopicId = 67 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResActivity");
                        }
                        break;
                    case "barVoucherList":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmVoucherLists))
                        {
                            var userControl = new FrmVoucherLists { Dock = DockStyle.Fill, HelpTopicId = 1010 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResVoucherList");
                        }
                        break;
                    case "barButtonBudgetChapter":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmBudgetChapters))
                        {
                            var userControl = new FrmBudgetChapters { Dock = DockStyle.Fill, HelpTopicId = 45 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text = ResourceHelper.GetResourceValueByName("ResBudgetChapterCaption");
                        }
                        break;
                    //case "barButtonBudgetCategory":
                    //    if (CommonFunction.CommonUserControl != null &&
                    //        CommonFunction.CommonUserControl.GetType() != typeof(UserControlBudgetCategoryList))
                    //    {
                    //        var userControl = new UserControlBudgetCategoryList { Dock = DockStyle.Fill, HelpTopicId = 1010 };
                    //        CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                    //        mainPanelControl.FeatureCaption.Text =
                    //            ResourceHelper.GetResourceValueByName("ResBudgetCategoryCaption");
                    //    }
                    //    break;
                    //case "barMergerFundItem":
                    //    if (CommonFunction.CommonUserControl != null &&
                    //        CommonFunction.CommonUserControl.GetType() != typeof(UserControlMergerFundList))
                    //    {
                    //        var userControl = new UserControlMergerFundList { Dock = DockStyle.Fill, HelpTopicId = 1010 };
                    //        CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                    //        mainPanelControl.FeatureCaption.Text =
                    //            ResourceHelper.GetResourceValueByName("ResMergerFundCaption");
                    //    }
                    //    break;
                    case "barButtonBudgetSource":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmBudgetSources))
                        {
                            var userControl = new FrmBudgetSources { Dock = DockStyle.Fill, HelpTopicId = 43 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResBudgetSourceCaption");
                        }
                        break;

                    #region Project
                    case "barButtonProject":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmProjects))
                        {
                            var userControl = new FrmProjects { Dock = DockStyle.Fill, HelpTopicId = 64 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResProjectCaption");
                        }
                        break;
                    case "barButtonContracts":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmContracts))
                        {
                            var userControl = new FrmContracts { Dock = DockStyle.Fill, HelpTopicId = 64 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResContractCaption");
                        }
                        break;
                    case "barButtonCapitalPlans":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmCapitalPlans))
                        {
                            var userControl = new FrmCapitalPlans { Dock = DockStyle.Fill, HelpTopicId = 64 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResProjectCaption");
                        }
                        break;
                    case "barButtonTargetProgram":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmTargetPrograms))
                        {
                            var userControl = new FrmTargetPrograms { Dock = DockStyle.Fill, HelpTopicId = 63 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);

                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResTargetProgramCaption");
                        }
                        break;
                    case "barButtonSubProject":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmSubprojects))
                        {
                            var userControl = new FrmSubprojects { Dock = DockStyle.Fill, HelpTopicId = 65 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResSubProjectCaption");
                        }
                        break;

                    case "barButtonSyntheticProject":
                        if (CommonFunction.CommonUserControl != null &&
                           CommonFunction.CommonUserControl.GetType() != typeof(FrmAllProject))
                        {
                            var userControl = new FrmAllProject { Dock = DockStyle.Fill, HelpTopicId = 66 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResAllProjectCaption");
                        }
                        break;
                    #endregion
                    case "barButtonStaff":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmEmployees))
                        {
                            var userControl = new FrmEmployees { Dock = DockStyle.Fill, HelpTopicId = 52 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResEmployeeCaption");
                        }
                        break;
                    case "barBudgetExpense":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmBudgetExpenses))
                        {
                            var userControl = new FrmBudgetExpenses { Dock = DockStyle.Fill, HelpTopicId = 70 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResBudgetExpenseCaption");
                        }
                        break;
                    case "barButtonStock":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmStocks))
                        {
                            var userControl = new FrmStocks { Dock = DockStyle.Fill, HelpTopicId = 54 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResStockCaption");
                        }
                        break;
                    case "barButtonBank":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmBanks))
                        {
                            var userControl = new FrmBanks { Dock = DockStyle.Fill, HelpTopicId = 68 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResBankCaption");
                        }
                        break;
                    //case "barButtonPaymentItem":
                    //    if (CommonFunction.CommonUserControl != null &&
                    //        CommonFunction.CommonUserControl.GetType() != typeof(UserControlPaymentVoucherList))
                    //    {
                    //        var userControl = new UserControlPaymentVoucherList { Dock = DockStyle.Fill, HelpTopicId = 4070 };
                    //        CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                    //        mainPanelControl.FeatureCaption.Text =
                    //            ResourceHelper.GetResourceValueByName("ResPaymentVoucher");
                    //    }
                    //    break;
                    case "barButtonAccountTranfer":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmAccountTransfers))
                        {
                            var userControl = new FrmAccountTransfers { Dock = DockStyle.Fill, HelpTopicId = 37 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResAccountTranferCaption");
                        }
                        break;

                    case "barButtonFundStructure":
                        if (CommonFunction.CommonUserControl != null &&
                          CommonFunction.CommonUserControl.GetType() != typeof(FrmFundStructures))
                        {
                            var userControl = new FrmFundStructures { Dock = DockStyle.Fill, HelpTopicId = 44 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResFundStructureCaption");
                        }
                        break;
                    case "barButtonInvoiceFormNumber":
                        if (CommonFunction.CommonUserControl != null &&
                          CommonFunction.CommonUserControl.GetType() != typeof(FrmInvoiceFormNumbers))
                        {
                            var userControl = new FrmInvoiceFormNumbers { Dock = DockStyle.Fill, HelpTopicId = 69 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResInvoiceFormNumberCaption");
                        }
                        break;
                    case "barButtonBUPlanWithdrawCash":// Rút dự toán tiền mặt
                        if (CommonFunction.CommonUserControl != null &&
                          CommonFunction.CommonUserControl.GetType() != typeof(FrmBUPlanWithdrawCashs))
                        {
                            var userControl = new FrmBUPlanWithdrawCashs { Dock = DockStyle.Fill, HelpTopicId = 77 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResBUPlanWithdrawCashCaption");
                        }
                        break;


                    case "barButtonCAPaymentFixedAsset":
                        if (CommonFunction.CommonUserControl != null &&
                          CommonFunction.CommonUserControl.GetType() != typeof(FrmCAPaymentFixedAssets))
                        {
                            var userControl = new FrmCAPaymentFixedAssets { Dock = DockStyle.Fill, HelpTopicId = 123 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResCAPaymentFixedAssetCaption");
                        }
                        break;
                    case "barButtonAudittingLog":
                        var frmAuditingLog = new FrmXtraAuditingLog();
                        frmAuditingLog.ShowDialog();
                        break;
                    //case "barButtonAudittingLog":
                    //    /* LINHMC
                    //    if (CommonFunction.CommonUserControl != null &&
                    //        CommonFunction.CommonUserControl.GetType() != typeof(UserControlAudittingLogList))
                    //    {
                    //        var userControl = new UserControlAudittingLogList { Dock = DockStyle.Fill };
                    //        CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                    //        mainPanelControl.FeatureCaption.Text =
                    //            ResourceHelper.GetResourceValueByName("ResAudittingLogCaption");
                    //    }*/
                    //    var frmAuditingLog = new FrmXtraAuditingLog();
                    //    frmAuditingLog.Show();
                    //    break;
                    //case "barButtonReceiptEstimateItem":
                    //    if (CommonFunction.CommonUserControl != null &&
                    //        CommonFunction.CommonUserControl.GetType() != typeof(UserControlReceiptEstimateList))
                    //    {
                    //        var userControl = new UserControlReceiptEstimateList { Dock = DockStyle.Fill, HelpTopicId = 7000 };
                    //        CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                    //        mainPanelControl.FeatureCaption.Text =
                    //            ResourceHelper.GetResourceValueByName("ResReceiptEstimateCaption");
                    //    }
                    //    break;
                    //case "barButtonPaymentEstimateItem":
                    //    if (CommonFunction.CommonUserControl != null &&
                    //        CommonFunction.CommonUserControl.GetType() != typeof(UserControlPaymentEstimateList))
                    //    {
                    //        var userControl = new UserControlPaymentEstimateList { Dock = DockStyle.Fill, HelpTopicId = 7000 };
                    //        CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                    //        mainPanelControl.FeatureCaption.Text =
                    //            ResourceHelper.GetResourceValueByName("ResPaymentEstimateCaption");
                    //    }
                    //    break;
                    //case "barButtonPaymentDepositItem":
                    //    if (CommonFunction.CommonUserControl != null &&
                    //        CommonFunction.CommonUserControl.GetType() != typeof(UserControlPaymentDepositList))
                    //    {
                    //        var userControl = new UserControlPaymentDepositList { Dock = DockStyle.Fill, HelpTopicId = 5000 };
                    //        CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                    //        mainPanelControl.FeatureCaption.Text =
                    //            ResourceHelper.GetResourceValueByName("ResPaymentDepositCaption");
                    //    }
                    //    break;
                    //case "barButtonReceiptDepositItem":
                    //    if (CommonFunction.CommonUserControl != null &&
                    //        CommonFunction.CommonUserControl.GetType() != typeof(UserControlReceiptDepositList))
                    //    {
                    //        var userControl = new UserControlReceiptDepositList { Dock = DockStyle.Fill, HelpTopicId = 4090 };
                    //        CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                    //        mainPanelControl.FeatureCaption.Text =
                    //            ResourceHelper.GetResourceValueByName("ResReceiptDepositCaption");
                    //    }
                    //    break;
                    case "barButtonAutoBusiness":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmAutoBusinesses))
                        {
                            var userControl = new FrmAutoBusinesses { Dock = DockStyle.Fill, HelpTopicId = 40 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResAutoBusinessCaption");
                        }
                        break;
                    case "barButtonAutoBusinessParallel":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmAutoBusinessParallels))
                        {
                            var userControl = new FrmAutoBusinessParallels { Dock = DockStyle.Fill, HelpTopicId = 41 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResAutoBusinessParallelCaption");
                        }
                        break;
                    case "barButtonInventoryItem":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmInventoryItems))
                        {
                            var userControl = new FrmInventoryItems { Dock = DockStyle.Fill, HelpTopicId = 55 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResInventoryItemCaption");
                        }
                        break;
                    case "barButtonTool":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmTools))
                        {
                            var userControl = new FrmTools { Dock = DockStyle.Fill, HelpTopicId = 56 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResToolCaption");
                        }
                        break;
                    case "barBtnCurrency": // tiền tệ
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmCurrencies))
                        {
                            var userControl = new FrmCurrencies { Dock = DockStyle.Fill, HelpTopicId = 71 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResCurrencyCaption");
                        }
                        break;
                    //case "barButtonBudgetSourceCategory":
                    //    if (CommonFunction.CommonUserControl != null &&
                    //        CommonFunction.CommonUserControl.GetType() != typeof(UserControlBudgetSourceCategoryList))
                    //    {
                    //        var userControl = new UserControlBudgetSourceCategoryList { Dock = DockStyle.Fill, HelpTopicId = 1010 };
                    //        CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                    //        mainPanelControl.FeatureCaption.Text =
                    //            ResourceHelper.GetResourceValueByName("ResBudgetSourceCategory");
                    //    }
                    //    break;
                    //case "barButtonFAIncrement":
                    //    if (CommonFunction.CommonUserControl != null &&
                    //        CommonFunction.CommonUserControl.GetType() != typeof(FrmFAIncrements))
                    //    {
                    //        var userControl = new FrmFAIncrements { Dock = DockStyle.Fill, HelpTopicId = 6000 };
                    //        CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                    //        mainPanelControl.FeatureCaption.Text =
                    //            ResourceHelper.GetResourceValueByName("ResFAIncrementsCaption");
                    //    }
                    //    break;
                    case "barButtonFADecrement": // ghi giảm TSCĐ
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmFADecrements))
                        {
                            var userControl = new FrmFADecrements { Dock = DockStyle.Fill, HelpTopicId = 131 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResFADecrementCaption");
                        }
                        break;
                    case "barButtonRevaluationOfFixedAssets": // đánh giá lại TSCĐ
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmRevaluationOfFixedAssets))
                        {
                            var userControl = new FrmRevaluationOfFixedAssets { Dock = DockStyle.Fill, HelpTopicId = 131 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                            ResourceHelper.GetResourceValueByName("ResRevaluationOfFixedAssets");
                        }
                        break;
                    case "barButtonFADepreciation": // hao mòn
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmFADepreciations))
                        {
                            var userControl = new FrmFADepreciations { Dock = DockStyle.Fill, HelpTopicId = 128 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResFADepreciationCaption");
                        }
                        break;
                    case "barButtonItemFADevaluation": //điều chỉnh
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmFADevaluations))
                        {
                            var userControl = new FrmFADevaluations { Dock = DockStyle.Fill, HelpTopicId = 129 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResFADevaluationCaption");
                        }
                        break;
                    case "barButtonGeneral": // chứng từ chung
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmGLVouchers))
                        {
                            var userControl = new FrmGLVouchers { Dock = DockStyle.Fill, HelpTopicId = 133 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResGeneralVoucherCaption");
                        }
                        break;

                    case "barButtonGLVoucherList":
                        if (CommonFunction.CommonUserControl != null &&
                           CommonFunction.CommonUserControl.GetType() != typeof(FrmGLVoucherList))
                        {
                            var userControl = new FrmGLVoucherList { Dock = DockStyle.Fill, HelpTopicId = 6050 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResGeneralVoucherListCaption");
                        }
                        break;

                    case "barButtonOutputInventory":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmINOutwards))
                        {
                            var userControl = new FrmINOutwards { Dock = DockStyle.Fill, HelpTopicId = 114 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResOutputInventoryCaption");
                        }

                        break;

                    case "barButtonCalcInventoryOutputPrice":
                        var frmCalculateInventoryOutputPrice = new FrmCalculateInventoryOutputPrice();
                        frmCalculateInventoryOutputPrice.ShowDialog();
                        break;

                    //case "barbtnCaptitalAllocateVoucher":
                    //    if (CommonFunction.CommonUserControl != null &&
                    //        CommonFunction.CommonUserControl.GetType() != typeof(UserControlGeneralVoucherCapitalAllocateList))
                    //    {
                    //        var userControl = new UserControlGeneralVoucherCapitalAllocateList { Dock = DockStyle.Fill, HelpTopicId = 6040 };
                    //        CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                    //        mainPanelControl.FeatureCaption.Text =
                    //            ResourceHelper.GetResourceValueByName("ResGeneralVouchersCapitalAllocateCaption");
                    //    }
                    //    break;
                    //case "barButtonBuildingItem":
                    //    if (CommonFunction.CommonUserControl != null &&
                    //        CommonFunction.CommonUserControl.GetType() != typeof(UserControlBuildingList))
                    //    {
                    //        var userControl = new UserControlBuildingList { Dock = DockStyle.Fill, HelpTopicId = 1010 };
                    //        CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                    //        mainPanelControl.FeatureCaption.Text =
                    //            ResourceHelper.GetResourceValueByName("ResBuildingCaption");
                    //    }
                    //break;

                    case "barButtonDbOption":
                        var frmXtraFormDbOption = new FrmXtraFormDbOption();
                        frmXtraFormDbOption.ShowDialog();
                        break;




                    //case "barButtonDbOption":
                    //    if (CommonFunction.CommonUserControl != null &&
                    //        CommonFunction.CommonUserControl.GetType() != typeof(FrmPermission))
                    //    {
                    //        var userControl = new FrmPermission { Dock = DockStyle.Fill, HelpTopicId = 1010 };
                    //        CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                    //        mainPanelControl.FeatureCaption.Text =
                    //            ResourceHelper.GetResourceValueByName("ResBuildingCaption");
                    //    }
                    //    break;

                    case "barButtonPostedDate":
                        var frmXtraPostedDate = new FrmXtraPostedDate();
                        frmXtraPostedDate.ShowDialog();
                        if (frmXtraPostedDate.CloseBox)//AnhNT: trường hợp thay đổi ngày hạch toán khi đang mở Dashboard => update Dashboard
                        {
                            if (CommonFunction.CommonUserControl != null &&
                                CommonFunction.CommonUserControl.GetType().Equals(typeof(UserControlMainDesktop)))
                            {
                                CommonFunction.CommonUserControl = null;
                                var userControl = new UserControlMainDesktop { Dock = DockStyle.Fill };
                                CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                                mainPanelControl.FeatureCaption.Text =
                                    ResourceHelper.GetResourceValueByName("ResDashboardCaption");
                            }
                        }
                        break;

                    case "barButtonDbInfo":
                        var frmXtraDbInfo = new FrmXtraDbInfo();
                        frmXtraDbInfo.ShowDialog();
                        break;

                    case "barUnlockBook":
                        var frmUnlockBook = new FrmUnlockBook();
                        frmUnlockBook.ShowDialog();
                        break;
                    case "barExportXml":
                        var frmExportXml = new FrmXtraExportXML();
                        frmExportXml.ShowDialog();
                        break;
                    case "barExportBCTC":
                        var frmExportBCTC = new FrmXtraExportBCTC();
                        frmExportBCTC.ShowDialog();
                        break;
                    case "barExportTreasury":
                        var frmExportTreasury = new FrmXtraExportXMLToTreasury();
                        frmExportTreasury.UnitName = GlobalVariable.CompanyName;
                        frmExportTreasury.CreatedBy = GlobalVariable.CompanyReportPreparer;
                        frmExportTreasury.SignedBy = GlobalVariable.CompanyDirector;
                        frmExportTreasury.ControlBy = GlobalVariable.CompanyDirector;
                        frmExportTreasury.ShowDialog();
                        break;
                    //case "barButtonUpdateAmountExchangeItem":
                    //    var frmXtraUpdateAmountExchange = new FrmXtraUpdateAmountExchange();
                    //    frmXtraUpdateAmountExchange.ShowDialog();repor
                    //    break;

                    //case "barButtonTransferItem":
                    //    if (CommonFunction.CommonUserControl != null &&
                    //        CommonFunction.CommonUserControl.GetType() !=
                    //        typeof(UserControlAccountTranferVoucherList))
                    //    {
                    //        var userControl = new UserControlAccountTranferVoucherList { Dock = DockStyle.Fill, HelpTopicId = 6060 };
                    //        CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                    //        mainPanelControl.FeatureCaption.Text =
                    //        ResourceHelper.GetResourceValueByName("ResTransferVoucherCaption");
                    //    }
                    //    break;
                    case "barButtonOpeningAccountEntry": // số dư đầu kỳ tài khoản
                        if (CommonFunction.CommonUserControl != null &&
                           CommonFunction.CommonUserControl.GetType() != typeof(FrmOpeningAccountEntry))
                        {
                            var userControl = new FrmOpeningAccountEntry { Dock = DockStyle.Fill, HelpTopicId = 138 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text = "Số dư đầu kỳ tài khoản";
                        }
                        break;
                    //case "barButtonEmployeeLeasingItem":
                    //    if (CommonFunction.CommonUserControl != null &&
                    //        CommonFunction.CommonUserControl.GetType() != typeof(UserControlEmployeeLeasingList))
                    //    {
                    //        var userControl = new UserControlEmployeeLeasingList { Dock = DockStyle.Fill, HelpTopicId = 3010 };
                    //        CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                    //        mainPanelControl.FeatureCaption.Text =
                    //            ResourceHelper.GetResourceValueByName("ResEmployeeLeasingCaption");
                    //    }
                    //    break;
                    //case "barButtonEmployeeContractItem":
                    //    if (CommonFunction.CommonUserControl != null &&
                    //        CommonFunction.CommonUserControl.GetType() != typeof(UserControlEmployeeContractList))
                    //    {
                    //        var userControl = new UserControlEmployeeContractList { Dock = DockStyle.Fill, HelpTopicId = 3020 };
                    //        CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                    //        mainPanelControl.FeatureCaption.Text =
                    //            ResourceHelper.GetResourceValueByName("ResEmployeeContractCaption");
                    //    }
                    //    break;
                    //case "barButtonItemMutual":
                    //    if (CommonFunction.CommonUserControl != null &&
                    //        CommonFunction.CommonUserControl.GetType() != typeof(UserControlMutualList))
                    //    {
                    //        var userControl = new UserControlMutualList { Dock = DockStyle.Fill, HelpTopicId = 3040 };
                    //        CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                    //        mainPanelControl.FeatureCaption.Text = @"Nhà hỗ tương";
                    //    }
                    //    break;
                    //case "barButtonExchangeRateItem":
                    //    if (CommonFunction.CommonUserControl != null &&
                    //        CommonFunction.CommonUserControl.GetType() != typeof(UserControlExchangeRateList))
                    //    {
                    //        var userControl = new UserControlExchangeRateList { Dock = DockStyle.Fill, HelpTopicId = 1010 };
                    //        CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                    //        mainPanelControl.FeatureCaption.Text = @"Tỷ giá";
                    //    }
                    //    break;

                    case nameof(barButtonPUDetailFixedAsset): // Mua TSCĐ chưa thanh toán
                        if (CommonFunction.CommonUserControl != null && CommonFunction.CommonUserControl.GetType() != typeof(frmPUInvoices))
                        {
                            var userControl = new frmPUInvoices() { Dock = DockStyle.Fill, HelpTopicId = 126 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text = userControl.FormCaption;
                        }
                        break;

                    case nameof(barButtonFAIncrementDecrement): // Tăng TSCĐ nhận bằng hiện vật
                        if (CommonFunction.CommonUserControl != null && CommonFunction.CommonUserControl.GetType() != typeof(frmFAIncrementDecrements))
                        {
                            var userControl = new frmFAIncrementDecrements() { Dock = DockStyle.Fill, HelpTopicId = 127 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text = userControl.FormCaption;
                        }
                        break;
                }
                //if (validForInitGlobalVariable)
                //    _globalVariable = new GlobalVariable();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the MouseDown event of the navBarMainLeft control. 
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void navBarMainLeft_MouseDown(object sender, MouseEventArgs e)
        {
            var navBar = sender as NavBarControl;
            if (navBar == null)
                return;
            var hitInfo = navBar.CalcHitInfo(new Point(e.X, e.Y));
            if (!hitInfo.InLink)
                return;
            switch (hitInfo.Link.ItemName)
            {
                case "navBarTreasuryItem":
                    if (CommonFunction.CommonUserControl != null &&
                        CommonFunction.CommonUserControl.GetType() != typeof(UserControlEstimateDesktop))
                    {
                        var userControl = new UserControlTreasuryDesktop() { Dock = DockStyle.Fill };
                        CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                        mainPanelControl.FeatureCaption.Text =
                            ResourceHelper.GetResourceValueByName("ResTreasuryCaption");
                        userControl.GetRefTypeTreasury += RefTreasuryEvent;
                    }
                    break;
                case "navBarCashItem":
                    if (CommonFunction.CommonUserControl != null &&
                        CommonFunction.CommonUserControl.GetType() != typeof(UserControlCashDesktop))
                    {
                        var userControl = new UserControlCashDesktop { Dock = DockStyle.Fill };
                        CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                        mainPanelControl.FeatureCaption.Text =
                            ResourceHelper.GetResourceValueByName("ResCashCaption");
                        userControl.GetRefCash += RefCashItemEvent;
                    }
                    break;
                case "navBarDepositItem":
                    if (CommonFunction.CommonUserControl != null &&
                        CommonFunction.CommonUserControl.GetType() != typeof(UserControlDepositDesktop))
                    {
                        var userControl = new UserControlDepositDesktop { Dock = DockStyle.Fill };
                        CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                        mainPanelControl.FeatureCaption.Text =
                            ResourceHelper.GetResourceValueByName("ResDepositCaption");
                        userControl.GetRefDeposit += RefDepositItemEvent;
                    }
                    break;
                case "navBarInventoryItem":
                    if (CommonFunction.CommonUserControl != null &&
                        CommonFunction.CommonUserControl.GetType() != typeof(UserControlInventoryDesktop))
                    {
                        var userControl = new UserControlInventoryDesktop { Dock = DockStyle.Fill };
                        CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                        mainPanelControl.FeatureCaption.Text =
                            ResourceHelper.GetResourceValueByName("ResInventoryCaption");
                        userControl.GetRefInventory += RefInventoryItemEvent;
                    }
                    break;
                case "navBarFixedAssetItem":
                    if (CommonFunction.CommonUserControl != null &&
                        CommonFunction.CommonUserControl.GetType() != typeof(UserControlFixedAssetDesktop))
                    {
                        var userControl = new UserControlFixedAssetDesktop { Dock = DockStyle.Fill };
                        CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                        mainPanelControl.FeatureCaption.Text =
                            ResourceHelper.GetResourceValueByName("ResFixedAssetCaption");
                        userControl.GetRefFixedAsset += RefFixedAssetEvent;
                    }
                    break;
                case "navBarSalaryItem":
                    if (CommonFunction.CommonUserControl != null &&
                        CommonFunction.CommonUserControl.GetType() != typeof(UserControlSalaryDesktop))
                    {

                        var userControl = new UserControlSalaryDesktop { Dock = DockStyle.Fill };
                        CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                        mainPanelControl.FeatureCaption.Text =
                            ResourceHelper.GetResourceValueByName("ResSalaryCaption");
                        userControl.GetRefSalary += RefSalaryItemEvent;
                    }
                    break;
                case "navBarTool":
                    if (CommonFunction.CommonUserControl != null &&
                        CommonFunction.CommonUserControl.GetType() != typeof(UserControlItemsDesktop))
                    {
                        var userControl = new UserControlItemsDesktop { Dock = DockStyle.Fill };
                        CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                        mainPanelControl.FeatureCaption.Text =
                            ResourceHelper.GetResourceValueByName("ResToolsCaption");
                        userControl.GetRefTypeTool += RefToolsEvent;
                    }
                    break;
                case "navBarReportItem":
                    using (var frmXtraReport = new FrmXtraReportList())
                    {
                        ReportTool.DrilldownVoucherEvent += ReportTool_DrilldownVoucherEvent;
                        frmXtraReport.ShowDialog();
                    }
                    break;
                case "navBarDashBoard":
                    if (CommonFunction.CommonUserControl != null &&
                        CommonFunction.CommonUserControl.GetType() != typeof(UserControlMainDesktop))
                    {
                        var userControl = new UserControlMainDesktop { Dock = DockStyle.Fill };
                        CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                        mainPanelControl.FeatureCaption.Text =
                            ResourceHelper.GetResourceValueByName("ResDashboardCaption");
                    }
                    break;
            }
        }

        /// <summary>
        /// References the fixed asset event.
        /// </summary>
        /// <param name="refTypeFixedAsset">The reference type fixed asset.</param>
        void RefFixedAssetEvent(int refTypeFixedAsset, bool isDetail)
        {

            switch (refTypeFixedAsset)
            {

                case 252: // nhận bằng hiện vật
                    if (!CheckRole("barButtonFAIncrementDecrement", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var userFAIncrementDecrements = new frmFAIncrementDecrements() { Dock = DockStyle.Fill };
                    userFAIncrementDecrements.RefTypeId = RefType.FAIncrementDecrement;
                    CommonFunction.RunUserControl(userFAIncrementDecrements, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = userFAIncrementDecrements.FormCaption;
                    if (isDetail)
                    {
                        userFAIncrementDecrements.AddData();
                    }

                    break;
                case 108: // mua TSCĐ bằng tiền mặt

                    if (!CheckRole("barButtonCAPaymentFixedAsset", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var userCAPaymentFixedAssets = new FrmCAPaymentFixedAssets() { Dock = DockStyle.Fill };
                    userCAPaymentFixedAssets.RefTypeId = RefType.CAPaymentDetailFixedAsset;
                    CommonFunction.RunUserControl(userCAPaymentFixedAssets, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = userCAPaymentFixedAssets.FormCaption;
                    userCAPaymentFixedAssets.AddData();
                    break;
                case 159: // mua TSCĐ bằng tiền gửi

                    if (!CheckRole("barButtonBAWithDrawFixedAsset", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var userBAWithDrawFixedAsset = new FrmBAWithDrawFixedAsset() { Dock = DockStyle.Fill };
                    userBAWithDrawFixedAsset.RefTypeId = RefType.BAWithDrawFixedAsset;
                    CommonFunction.RunUserControl(userBAWithDrawFixedAsset, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = userBAWithDrawFixedAsset.FormCaption;
                    userBAWithDrawFixedAsset.AddData();
                    break;



                case 58: // mua TSCĐ bằng chuyển khoản kho bạc

                    if (!CheckRole("barButtonBUTransferPurchase", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var useBUTransferFixedAssets = new FrmBUTransferFixedAssets() { Dock = DockStyle.Fill };
                    useBUTransferFixedAssets.RefTypeId = RefType.BUTransferFixedAsset;
                    CommonFunction.RunUserControl(useBUTransferFixedAssets, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = useBUTransferFixedAssets.FormCaption;
                    useBUTransferFixedAssets.AddData();
                    break;
                case 251: // mua TSCĐ chưa thanh toán

                    if (!CheckRole("barButtonPUDetailFixedAsset", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var usePUInvoices = new frmPUInvoices() { Dock = DockStyle.Fill };
                    usePUInvoices.RefTypeId = RefType.PUInvoiceFixedAsset;
                    CommonFunction.RunUserControl(usePUInvoices, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = usePUInvoices.FormCaption;
                    usePUInvoices.AddData();
                    break;

                case 254: // đánh giá lại tài sản

                    if (!CheckRole("barButtonRevaluationOfFixedAssets", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var useRevaluationOfFixedAssets = new FrmRevaluationOfFixedAssets() { Dock = DockStyle.Fill };
                    useRevaluationOfFixedAssets.RefTypeId = RefType.RevaluationOfFixedAsset;
                    CommonFunction.RunUserControl(useRevaluationOfFixedAssets, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = useRevaluationOfFixedAssets.FormCaption;
                    if (isDetail)
                    {
                        useRevaluationOfFixedAssets.AddData();
                    }
                    break;
                case 253: // đánh giá lại tài sản

                    if (!CheckRole("barButtonFADecrement", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var useFADecrements = new FrmFADecrements() { Dock = DockStyle.Fill };
                    useFADecrements.RefTypeId = RefType.FADecrement;
                    CommonFunction.RunUserControl(useFADecrements, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = useFADecrements.FormCaption;
                    if (isDetail)
                    {
                        useFADecrements.AddData();
                    }
                    break;
                case 419: // Khấu hao TSCĐ

                    if (!CheckRole("barButtonItemFADevaluation", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var useFADevaluations = new FrmFADevaluations() { Dock = DockStyle.Fill };
                    useFADevaluations.RefTypeId = RefType.FADevaluation;
                    CommonFunction.RunUserControl(useFADevaluations, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = useFADevaluations.FormCaption;
                    if (isDetail)
                    {
                        useFADevaluations.AddData();
                    }
                    break;
                case 255: //hao mòn TSCĐ

                    if (!CheckRole("barButtonFADepreciation", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var useFADepreciations = new FrmFADepreciations() { Dock = DockStyle.Fill };
                    useFADepreciations.RefTypeId = RefType.FADepreciation;
                    CommonFunction.RunUserControl(useFADepreciations, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = useFADepreciations.FormCaption;
                    if (isDetail)
                    {
                        useFADepreciations.AddData();
                    }
                    break;
                case 500: //báo cáo tồn kho
                    using (var frmXtraReport = new FrmXtraReportList())
                    {
                        ReportTool.DrilldownVoucherEvent += ReportTool_DrilldownVoucherEvent;
                        frmXtraReport.LoadData();
                        frmXtraReport.ViewReport(false, "S24H");
                        break;
                    }


                case 1: // phòng ban

                    if (!CheckRole("barButtonDepartment", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var userDepartments = new FrmDepartments() { Dock = DockStyle.Fill };
                    CommonFunction.RunUserControl(userDepartments, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = userDepartments.FormCaption;
                    //userControlAccountingObject.AddData();
                    break;
                case 2: // nhóm tài sản

                    if (!CheckRole("barButtonFixedAssetCategory", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var userFaCategories = new FrmFixedAssetCategories() { Dock = DockStyle.Fill };
                    CommonFunction.RunUserControl(userFaCategories, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = userFaCategories.FormCaption;
                    //userControlStaff.AddData();
                    break;
                case 3: // Tài sản

                    if (!CheckRole("barButtonFixedAsset", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var userFA = new FrmFixedAssets() { Dock = DockStyle.Fill };
                    CommonFunction.RunUserControl(userFA, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = userFA.FormCaption;

                    break;

            }
        }


        void RefTreasuryEvent(int refTypeTreasury, bool isDetail)
        {

            switch (refTypeTreasury)
            {

                case 51: // nhận dự toán
                    if (!CheckRole("barButtonBUPlanReceipt", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }
                    var userBUPlanReceipt = new FrmBUplanReceipts() { Dock = DockStyle.Fill };
                    userBUPlanReceipt.RefTypeId = RefType.BUPlanReceiptEarlyYear;
                    CommonFunction.RunUserControl(userBUPlanReceipt, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text =
                        ResourceHelper.GetResourceValueByName("ResbarButtonBUPlanReceiptCaption");
                    //var userBUPlanReceipt = new FrmBUPlanReceipt() { Dock = DockStyle.Fill };
                    //userBUPlanReceipt.RefTypeId = RefType.BUPlanReceiptEarlyYear;
                    //CommonFunction.RunUserControl(userBUPlanReceipt, mainPanelControl.MainPanel);
                    //mainPanelControl.FeatureCaption.Text = userBUPlanReceipt.FormCaption;
                    if (isDetail)
                    {
                        userBUPlanReceipt.AddData();
                    }

                    break;
                case 53: // điều chỉnh dự toán

                    if (!CheckRole("barButtonBUPlanAdjustment", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var userBUPlanAdjustment = new FrmBUPlanAdjustment() { Dock = DockStyle.Fill };
                    userBUPlanAdjustment.RefTypeId = RefType.BUPlanAdjustment;
                    CommonFunction.RunUserControl(userBUPlanAdjustment, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = userBUPlanAdjustment.FormCaption;
                    if (isDetail)
                    {
                        userBUPlanAdjustment.AddData();
                    }
                    break;
                case 69: // hủy dự toán

                    if (!CheckRole("barButtonBAWithDrawFixedAsset", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var userBUPlanCancel = new FrmBUPlanCancels() { Dock = DockStyle.Fill };
                    userBUPlanCancel.RefTypeId = RefType.BUPlanCancel;
                    CommonFunction.RunUserControl(userBUPlanCancel, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = userBUPlanCancel.FormCaption;
                    if (isDetail)
                    {
                        userBUPlanCancel.AddData();
                    }
                    break;



                case 54: // rút dự toán tiền mặt

                    if (!CheckRole("barButtonBUPlanWithdrawCash", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var useBUCash = new FrmBUPlanWithdrawCashs() { Dock = DockStyle.Fill };
                    useBUCash.RefTypeId = RefType.BUPlanWithDrawCash;
                    CommonFunction.RunUserControl(useBUCash, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = useBUCash.FormCaption;
                    useBUCash.AddData();
                    break;
                case 562: // rút dự toán tiên gửi

                    if (!CheckRole("barButtonBUPlanWithdrawDeposit", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var userBuDeposit = new FrmBUPlanWithDrawDeposits() { Dock = DockStyle.Fill };
                    userBuDeposit.RefTypeId = RefType.BUPlanWithDrawDeposit;
                    CommonFunction.RunUserControl(userBuDeposit, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = userBuDeposit.FormCaption;
                    userBuDeposit.AddData();
                    break;

                case 55: // rút dự toán chuyển khoản

                    if (!CheckRole("barButtonBUPlanWithdrawTransfer", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var useBuTransfer = new FrmBUPlanWithDrawTransfers() { Dock = DockStyle.Fill };
                    useBuTransfer.RefTypeId = RefType.BUPlanWithDrawTransfer;
                    CommonFunction.RunUserControl(useBuTransfer, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = useBuTransfer.FormCaption;
                    if (isDetail)
                    {
                        useBuTransfer.AddData();
                    }
                    break;
                case 563: // rút dư jtoán trả lương

                    if (!CheckRole("barButtonBUPlanWithdrawTransferInsurrance", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var useBUInsure = new FrmBUPlanWithdrawTransferInsurrance() { Dock = DockStyle.Fill };
                    useBUInsure.RefTypeId = RefType.BUPlanWithdrawTransferInsurrance;
                    CommonFunction.RunUserControl(useBUInsure, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = useBUInsure.FormCaption;
                    if (isDetail)
                    {
                        useBUInsure.AddData();
                    }
                    break;
                case 56: // Chuyển khoản kho bạc

                    if (!CheckRole("barButtonBUTransfer", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var useBuplanTransfer = new FrmBUTransfers() { Dock = DockStyle.Fill };
                    useBuplanTransfer.RefTypeId = RefType.BUTransfer;
                    CommonFunction.RunUserControl(useBuplanTransfer, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = useBuplanTransfer.FormCaption;
                    if (isDetail)
                    {
                        useBuplanTransfer.AddData();
                    }
                    break;
                case 561: //chuyển khoản kho bạc vào tài khoản tiền gửi

                    if (!CheckRole("barButtonBUTransferDeposits", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var useBUTransferDeposits = new FrmBUTransferDeposits() { Dock = DockStyle.Fill };
                    useBUTransferDeposits.RefTypeId = RefType.BUTransferDeposits;
                    CommonFunction.RunUserControl(useBUTransferDeposits, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = useBUTransferDeposits.FormCaption;
                    if (isDetail)
                    {
                        useBUTransferDeposits.AddData();
                    }
                    break;

                case 60: //chuyển khoản trả lương

                    if (!CheckRole("barButtonBUTransfersPayWage", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var useBUTransfersPayWage = new FrmBUTransfersPayWage() { Dock = DockStyle.Fill };
                    useBUTransfersPayWage.RefTypeId = RefType.BUTransferPayWage;
                    CommonFunction.RunUserControl(useBUTransfersPayWage, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = useBUTransfersPayWage.FormCaption;
                    if (isDetail)
                    {
                        useBUTransfersPayWage.AddData();
                    }
                    break;
                case 61: //chuyển khoản trả bảo hiểm

                    if (!CheckRole("barButtonBUTransfersPayInsurrance", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var useBuTransfersPayInsurrance = new FrmBUTransfersPayInsurrance() { Dock = DockStyle.Fill };
                    useBuTransfersPayInsurrance.RefTypeId = RefType.BUTransferPayInsurrance;
                    CommonFunction.RunUserControl(useBuTransfersPayInsurrance, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = useBuTransfersPayInsurrance.FormCaption;
                    if (isDetail)
                    {
                        useBuTransfersPayInsurrance.AddData();
                    }
                    break;
                case 73: //dự toán giữ lại

                    if (!CheckRole("barButtonBUBudgetReserve", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var useBUBudgetReserves = new FrmBUBudgetReserves() { Dock = DockStyle.Fill };
                    useBUBudgetReserves.RefTypeId = RefType.BUBudgetReserve;
                    CommonFunction.RunUserControl(useBUBudgetReserves, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = useBUBudgetReserves.FormCaption;
                    if (isDetail)
                    {
                        useBUBudgetReserves.AddData();
                    }
                    break;

                case 71: //đề nghị cam kết chi

                    if (!CheckRole("barButtonCommitmentRequest", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var useCommitmentRequest = new FrmBUCommitmentRequests() { Dock = DockStyle.Fill };
                    useCommitmentRequest.RefTypeId = RefType.BUCommitmentRequest;
                    CommonFunction.RunUserControl(useCommitmentRequest, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = useCommitmentRequest.FormCaption;
                    if (isDetail)
                    {
                        useCommitmentRequest.AddData();
                    }
                    break;
                case 72: //điều chỉnh cam kết chi

                    if (!CheckRole("barButtonCommitmentAdjustment", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var useCommitmentAdjustment = new FrmBUCommitmentAdjustments() { Dock = DockStyle.Fill };
                    useCommitmentAdjustment.RefTypeId = RefType.BUCommitmentAdjustment;
                    CommonFunction.RunUserControl(useCommitmentAdjustment, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = useCommitmentAdjustment.FormCaption;
                    if (isDetail)
                    {
                        useCommitmentAdjustment.AddData();
                    }
                    break;
                case 606: //cam két chi ban đầu

                    if (!CheckRole("barButtonOpeningCommitment", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var useOpeningCommitment = new FrmOpeningCommitments() { Dock = DockStyle.Fill };
                    useOpeningCommitment.RefTypeId = RefType.OpeningCommitment;
                    CommonFunction.RunUserControl(useOpeningCommitment, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = useOpeningCommitment.FormCaption;
                    if (isDetail)
                    {
                        useOpeningCommitment.AddData();
                    }
                    break;
                case 500: //báo cáo tồn kho
                    using (var frmXtraReport = new FrmXtraReportList())
                    {
                        ReportTool.DrilldownVoucherEvent += ReportTool_DrilldownVoucherEvent;
                        frmXtraReport.LoadData();
                        if (isDetail)
                            frmXtraReport.ViewReport(false, "N01_SDKP_DVDT");

                        else
                            frmXtraReport.ViewReport(false, "N02_SDKP_DVDT");
                        break;
                    }


                case 1: // nguồn

                    if (!CheckRole("barButtonBudgetSource", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var userBudgetSource = new FrmBudgetSources() { Dock = DockStyle.Fill };
                    CommonFunction.RunUserControl(userBudgetSource, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = userBudgetSource.FormCaption;
                    //userControlAccountingObject.AddData();
                    break;
                case 2: // chương

                    if (!CheckRole("barButtonBudgetChapter", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var userBudgetChapter = new FrmBudgetChapters() { Dock = DockStyle.Fill };
                    CommonFunction.RunUserControl(userBudgetChapter, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = userBudgetChapter.FormCaption;
                    //userControlStaff.AddData();
                    break;
                case 3: // Loại khoản

                    if (!CheckRole("barBudgetKindItem", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var userBudgetKindItems = new FrmBudgetKindItems() { Dock = DockStyle.Fill };
                    CommonFunction.RunUserControl(userBudgetKindItems, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = userBudgetKindItems.FormCaption;

                    break;
                case 4: // mục tiểu mục

                    if (!CheckRole("barBudgetKindItem", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var userBudgetItems = new FrmBudgetItems() { Dock = DockStyle.Fill };
                    CommonFunction.RunUserControl(userBudgetItems, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = userBudgetItems.FormCaption;

                    break;
                case 5: //tài khoản ngân hàng kho bạc

                    if (!CheckRole("barButtonBank", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var userBank = new FrmBanks() { Dock = DockStyle.Fill };
                    CommonFunction.RunUserControl(userBank, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = userBank.FormCaption;

                    break;

            }
        }


        void RefToolsEvent(int refTypeTool, bool isDetail)
        {

            switch (refTypeTool)
            {

                case 206: // ghi giảm CCDC
                    if (!CheckRole("barButtonSUDecrement", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var userSuDecrements = new FrmSUDecrements() { Dock = DockStyle.Fill };
                    userSuDecrements.RefTypeId = RefType.SUDecrement;
                    CommonFunction.RunUserControl(userSuDecrements, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = userSuDecrements.FormCaption;
                    if (isDetail)
                    {
                        userSuDecrements.AddData();
                    }

                    break;
                case 602: // số dư đầu kỳ CCDC

                    if (!CheckRole("barButtonOpeningSupplyEntry", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var userOpeningSupply = new FrmOpeningSupplyEntries() { Dock = DockStyle.Fill };
                    userOpeningSupply.RefTypeId = RefType.OpeningSupplyEntry;
                    CommonFunction.RunUserControl(userOpeningSupply, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = userOpeningSupply.FormCaption;
                    if (isDetail)
                    {
                        userOpeningSupply.AddData();
                    }
                    break;
                case 205: // ghi tăng CCDC

                    if (!CheckRole("barButtonSUIncrement", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var userSUInCre = new FrmSUIncrements() { Dock = DockStyle.Fill };
                    userSUInCre.RefTypeId = RefType.SUIncrement;
                    CommonFunction.RunUserControl(userSUInCre, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = userSUInCre.FormCaption;
                    if (isDetail)
                    {
                        userSUInCre.AddData();

                    }
                    break;



                case 207: //điều chuyển công cụ dụng cụ

                    if (!CheckRole("barButtonSUTransfer", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var useSUTransfer = new FrmSUTransfers() { Dock = DockStyle.Fill };
                    useSUTransfer.RefTypeId = RefType.SUTransfer;
                    CommonFunction.RunUserControl(useSUTransfer, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = useSUTransfer.FormCaption;
                    if (isDetail)
                    {
                        useSUTransfer.AddData();

                    }
                    break;





                case 500: //báo cáo CCDC
                    using (var frmXtraReport = new FrmXtraReportList())
                    {
                        ReportTool.DrilldownVoucherEvent += ReportTool_DrilldownVoucherEvent;
                        frmXtraReport.LoadData();
                        frmXtraReport.ViewReport(false, "S26HSupply");
                        break;
                    }


                case 2: // phòng ban

                    if (!CheckRole("barButtonDepartment", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var userDepartments = new FrmDepartments() { Dock = DockStyle.Fill };
                    CommonFunction.RunUserControl(userDepartments, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = userDepartments.FormCaption;
                    //userControlAccountingObject.AddData();
                    break;
                case 1: //cán bộ

                    if (!CheckRole("barButtonStaff", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var userStaff = new FrmEmployees() { Dock = DockStyle.Fill };
                    CommonFunction.RunUserControl(userStaff, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = userStaff.FormCaption;

                    break;
                case 3: // công cụ dụng cụ

                    if (!CheckRole("barButtonTool", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var userTool = new FrmTools() { Dock = DockStyle.Fill };
                    CommonFunction.RunUserControl(userTool, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = userTool.FormCaption;

                    break;
            }
        }

        /// <summary>
        /// Reports the tool_ drilldown voucher event.
        /// </summary>
        /// <param name="refType">Type of the reference.</param>
        /// <param name="refId">The reference identifier.</param>
        static void ReportTool_DrilldownVoucherEvent(string refType, string refId)
        {
            if (!GlobalVariable.IsViewVoucher)
            {
                GlobalVariable.IsViewVoucher = true;
                var refTypeId = int.Parse(refType);
                var frmDetail = GetDetailForm.GetForm(refType);
                frmDetail.ActionMode = ActionModeVoucherEnum.None;
                //frmDetail.RefID = long.Parse(refId);
                frmDetail.KeyValue = refId;
                frmDetail.BaseRefTypeId = (RefType)refTypeId;
                frmDetail.MasterBindingSource = new BindingSource();
                frmDetail.CurrentPosition = 1;
                frmDetail.ShowDialog();
            }
        }

        /// <summary>
        /// Handles the Load event of the MainRibbonForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void MainRibbonForm_Load(object sender, EventArgs e)
        {
            Text += @" (" + System.Windows.Forms.Application.ProductVersion + @")";
            RefreshDateTime();
            SetCloseDataState(true);
            //hidden control
            pageCategory.Visible = false;
            pageTreasury.Visible = false;
            barButtonCapitalPlans.Visibility = BarItemVisibility.Never;

            //pageCash.Visible = false;
            //pageFixedAsset.Visible = false;
            //PageInventory.Visible = false;
            //PageSummary.Visible = false;
            pageHelp.Visible = false;
            _autoUpdateClicked = false;
            if (RegistryHelper.GetValueByRegistryKey("DatabaseName").Equals("master"))
            {
                using (var frmCreateNewDatabase = new FrmCreateNewDatabase())
                {
                    if (frmCreateNewDatabase.ShowDialog() == DialogResult.OK)
                    {
                    }
                    else return;
                }
            }
            else
            {

                CommonFunction.GetLicenseInfo();
                DateTime thistime = DateTime.Now;
                if (thistime > GlobalVariable.TimeExpried)
                {
                    MessageBox.Show(@"Bản quyền của chương trình đã hết hạn, vui lòng đăng ký bản quyền mới hoặc liên hệ với nhà cung cấp để được hỗ trợ!", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //An cac menu truoc khi dang nhap
                    ribbonPage1.Visible = false;
                    pageCash.Visible = false;
                    PageInventory.Visible = false;
                    pageFixedAsset.Visible = false;
                    PageSummary.Visible = false;
                    pageTreasury.Visible = false;
                    pageCategory.Visible = false;
                    //Luon mo menu tro giup
                    pageHelp.Visible = true;
                    barButtonRegisterItem.Visibility = BarItemVisibility.Always;
                    barButtonAboutItem.Visibility = BarItemVisibility.Always;
                    barButtonHelpOnline.Visibility = BarItemVisibility.Always;
                    barButtonAutoUpdateItem.Visibility = BarItemVisibility.Never;
                    barButtonHelpItem.Visibility = BarItemVisibility.Never;
                    return;
                }

                using (var frmLogin = new FrmLogin())
                {
                    frmLogin.PostLoginState += MainRibbonForm_GetLoginState;
                    if (frmLogin.ShowDialog() == DialogResult.OK)
                    { }
                }
                if (!_loginState) return;
                _featuresPresenter.DisPlayIsParent();
                PermissionUse();
                barButtonLoginItem.Visibility = BarItemVisibility.Never;
                barButtonCloseData.Visibility = BarItemVisibility.Always;
                SetCloseDataState(false);

                // Visible chứng từ ghi sổ
                barButtonGLVoucherList.Visibility = GlobalVariable.AccountingBooksType == 2 ? BarItemVisibility.Always : BarItemVisibility.Never;

                //load server connection
                //connection
                if (GlobalVariable.ServerConnection == null)
                {
                    GlobalVariable.ServerConnection = new ServerConnection(RegistryHelper.GetValueByRegistryKey("InstanceName"))
                    {
                        LoginSecure = false,
                        Login = RegistryHelper.GetValueByRegistryKey("UserName"),
                        Password = Crypto.Decrypting(RegistryHelper.GetValueByRegistryKey("Password"), "@bgt1me")
                    };
                }
                //create server
                if (GlobalVariable.Server == null) GlobalVariable.Server = new Server(GlobalVariable.ServerConnection);
                using (var frmXtraPostedDate = new FrmXtraPostedDate())
                {
                    if (frmXtraPostedDate.ShowDialog() == DialogResult.OK)
                    { }
                }
            }


            // Không phải admin thì ẩn mennu người dùng
            if (!GlobalVariable.LoginName.ToLower().Equals("admin"))
                barButtonUser.Visibility = BarItemVisibility.Never;

            // TinTv: Không phải admin thì ẩn mennu Khóa sổ/Bỏ khóa sổ
            if (!GlobalVariable.LoginName.ToLower().Equals("admin"))
                barUnlockBook.Visibility = BarItemVisibility.Never;

            ////TUDT - Doan nay hien thi man hinh dashboard, chua lam den nen tam thoi comment lai
            if (CommonFunction.CommonUserControl != null &&
                        CommonFunction.CommonUserControl.GetType() != typeof(UserControlMainDesktop))
            {
                var userControl = new UserControlMainDesktop { Dock = DockStyle.Fill };
                CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                mainPanelControl.FeatureCaption.Text =
                    ResourceHelper.GetResourceValueByName("ResDashboardCaption");
            }

            //Config autoupdate
            AutoUpdaterConfiguration();
            //Auto check update
            if (!IsExpried())//Nếu còn license mới thực hiện check update
            {
                Thread thr = new Thread(() => CheckForNewVersion(true));
                thr.SetApartmentState(ApartmentState.STA);
                thr.Start();
            }
            //Update SQL nếu có lệnh
            CheckAndUpdateSQL();
        }

        /// <summary>
        /// Check and update SQL
        /// </summary>
        private void CheckAndUpdateSQL()
        {
            if (GlobalVariable.IsAutoUpdateSQL && !String.IsNullOrEmpty(GlobalVariable.FileListSQLUpdate))
            {
                var formupdatedb = new FrmXtraUpdateDatabase();
                formupdatedb.ShowDialog();
            }
        }

        /// <summary>
        /// Mains the state of the ribbon form_ get login.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="data">if set to <c>true</c> [data].</param>
        public void MainRibbonForm_GetLoginState(object sender, bool data)
        {
            _loginState = data;
            if (!_loginState)
                return;
            barStaticServerName.Caption = ResourceHelper.GetResourceValueByName("ResInstanceNameCaption");
            barStaticUserName.Caption = ResourceHelper.GetResourceValueByName("ResUserNameCaption");
            barStaticServerDatabaseName.Caption = ResourceHelper.GetResourceValueByName("ResDatabaseNameCaption");
            barStaticServerName.Caption += RegistryHelper.GetValueByRegistryKey("InstanceName");
            barStaticUserName.Caption += RegistryHelper.GetValueByRegistryKey("UserLogin");
            barStaticServerDatabaseName.Caption += RegistryHelper.GetValueByRegistryKey("DatabaseName");
        }

        /// <summary>
        /// Refreshes the date time.
        /// </summary>
        private void RefreshDateTime()
        {
            var timer = new Timer { Enabled = true };
            timer.Tick += timer_Tick;
        }

        /// <summary>
        /// Handles the Tick event of the timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void timer_Tick(object sender, EventArgs e)
        {
            barStaticDateItem.Caption = DateTime.Now.ToString("dd/MM/yyyy", Thread.CurrentThread.CurrentCulture);
            barStaticTimeItem.Caption = DateTime.Now.ToString("T");
        }

        /// <summary>
        /// Handles the Paint event of the mainPanelControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void mainPanelControl_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// Handles the FormClosing event of the MainRibbonForm control.
        /// LINHMC bỏ dialog hỏi sao lưu, không cần hỏi cứ sao lưu thôi
        /// var dialogResult = XtraMessageBox.Show("Bạn có muốn sao lưu trước khi thoát hệ thống !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        ///if (dialogResult == DialogResult.No)
        ///    System.Windows.Forms.Application.Exit();
        ///else
        ///{
        ///sao luu CSDL
        ///CommonFunction.BackupDatabase(splashScreenManager, "", true);
        /// System.Windows.Forms.Application.Exit();
        ///}
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void MainRibbonForm_Closed(object sender, EventArgs e)
        {
            if (AutoUpdaterPlugin.IsAutoUpdate)
            {
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                if (RegistryHelper.GetValueByRegistryKey("DatabaseName").Equals("master")) System.Windows.Forms.Application.Exit();
                if (!_loginState)
                {
                    System.Windows.Forms.Application.Exit();
                }
                else
                {
                    if (GlobalVariable.AutoBackup)
                    {
                        //Sao lưu dữ liệu
                        CommonFunction.BackupDatabase(splashScreenManager, "", true);
                        System.Windows.Forms.Application.Exit();
                    }
                    else
                    {
                        var skin = new UserLookAndFeel(this)
                        {
                            SkinName = "Office 2010 Blue",
                            UseDefaultLookAndFeel = false
                        };
                        var dialogResult = XtraMessageBox.Show(skin, "Bạn có muốn sao lưu trước khi thoát hệ thống ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.No)
                            System.Windows.Forms.Application.Exit();
                        else
                        {
                            //sao luu CSDL
                            try
                            {
                                var databaseNameForBackup = RegistryHelper.GetValueByRegistryKey("DatabaseName");
                                var databaseForBackup = GlobalVariable.Server.Databases[databaseNameForBackup];
                                var backup = new Backup
                                {
                                    //option for backup
                                    Action = BackupActionType.Database,
                                    BackupSetDescription = "Sao lưu CSDL, ngày " + DateTime.Now,
                                    BackupSetName = databaseNameForBackup + " Backup",
                                    Database = databaseForBackup.Name
                                };

                                //create backupdevice
                                var fileBackup = GlobalVariable.DailyBackupPath;
                                if (string.IsNullOrEmpty(fileBackup))
                                {
                                    fileBackup = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                                }
                                if (!Directory.Exists(fileBackup))
                                {
                                    try
                                    {
                                        Directory.CreateDirectory(fileBackup);

                                    }
                                    catch (Exception ex)
                                    {
                                        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBackUpDatabaseNotExist"), ResourceHelper.GetResourceValueByName("Notice"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                                var dateTimeString = DateTime.Now.Year.ToString(CultureInfo.InvariantCulture) +
                                                     DateTime.Now.Month.ToString(CultureInfo.InvariantCulture) +
                                                     DateTime.Now.Day.ToString(CultureInfo.InvariantCulture) +
                                                     DateTime.Now.Hour.ToString(CultureInfo.InvariantCulture) +
                                                     DateTime.Now.Minute.ToString(CultureInfo.InvariantCulture) +
                                                     DateTime.Now.Second.ToString(CultureInfo.InvariantCulture);
                                var databaseName = RegistryHelper.GetValueByRegistryKey("DatabaseName") + "_" + dateTimeString + ".bak";

                                if (File.Exists(fileBackup))
                                {
                                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResFileBackupExits"),
                                        ResourceHelper.GetResourceValueByName("Notice"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                var backupDevice = new BackupDeviceItem(fileBackup + @"\" + databaseName, DeviceType.File);

                                backup.Devices.Add(backupDevice);
                                backup.Incremental = false;
                                backup.SqlBackup(GlobalVariable.Server);

                                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBackupSucess"),
                                   ResourceHelper.GetResourceValueByName("Notice"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                                Process.Start(fileBackup);
                            }
                            catch (Exception ex)
                            {
                                XtraMessageBox.Show(ex.ToString(),
                                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            System.Windows.Forms.Application.Exit();
                        }
                    }
                }
            }
        }

        #region AuditingLog Member

        /// <summary>
        /// Gets or sets the event identifier.
        /// </summary>
        /// <value>
        /// The event identifier.
        /// </value>
        public string EventId { get; set; }

        /// <summary>
        /// Gets or sets the name of the login.
        /// </summary>
        /// <value>
        /// The name of the login.
        /// </value>
        public string LoginName
        {
            get { return string.IsNullOrEmpty(GlobalVariable.LoginName) ? "UNKNOW" : GlobalVariable.LoginName; }
            set { }
        }

        /// <summary>
        /// Gets or sets the name of the computer.
        /// </summary>
        /// <value>
        /// The name of the computer.
        /// </value>
        public string ComputerName
        {
            get { return Environment.MachineName; }
            set { }
        }

        /// <summary>
        /// Gets or sets the event time.
        /// </summary>
        /// <value>
        /// The event time.
        /// </value>
        public DateTime EventTime
        {
            get { return DateTime.Now; }
            set { }
        }

        /// <summary>
        /// Gets or sets the name of the component.
        /// </summary>
        /// <value>
        /// The name of the component.
        /// </value>
        public string ComponentName
        {
            get { return "Đăng xuất"; }
            set { }
        }

        /// <summary>
        /// Gets or sets the event action.
        /// </summary>
        /// <value>
        /// The event action.
        /// </value>
        public int EventAction
        {
            get
            {
                return 8;
            }
            set { }
        }

        /// <summary>
        /// Gets or sets the reference.
        /// </summary>
        /// <value>
        /// The reference.
        /// </value>
        public string Reference
        {
            get
            {
                return "Đăng xuất";
            }
            set { }
        }

        /// <summary>
        /// Gets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public decimal Amount { get; set; }

        #endregion

        private void barButtonAccountDefault_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        //private IList<PermissionMapingModel> _listPermissionMapingModels;

        /// <summary>
        /// Permissions the use.
        /// </summary>
        private void PermissionUse()
        {
            IModel _model = new Model.Model();
            // Phân quyền tại đây TUNGDQ
            var userProfile = _model.GetUserProfileByUserName(LoginName);
            if (userProfile != null && !userProfile.IsSystem && LoginName != "admin")
            {
                foreach (RibbonPage currentPage in ribbonMainMenu.Pages)
                {
                    var featurePage = Features.FirstOrDefault(x => x.MenuItemCode == currentPage.Name);
                    var userFeaturePermisions = new List<UserFeaturePermisionModel>();
                    if (featurePage != null)
                        userFeaturePermisions =
                            _model.GetUserFeaturePermisionsByUserProfileIdAndFeatureId(userProfile?.UserProfileId,
                                featurePage.FeatureID).ToList();
                    _listPermissionMapingModels = userFeaturePermisions;
                    // Luon de Page He Thong hien thi
                    if (currentPage.Name == "ribbonPage1")
                    {
                        currentPage.Visible = true;
                    }
                    else
                    {
                        currentPage.Visible = userFeaturePermisions.Any();
                    }
                    if (currentPage.Visible)
                    {
                        foreach (RibbonPageGroup currentGroup in currentPage.Groups)
                        {
                            var countcurrenLink = 0;
                            foreach (BarItemLink currenLink in currentGroup.ItemLinks)
                            {
                                var countmSubLink = 0;
                                BarItem mCurrentItem = currenLink.Item;
                                if (mCurrentItem.GetType().FullName == "DevExpress.XtraBars.BarSubItem")
                                {
                                    var mBarSubItem = (BarSubItem)mCurrentItem;
                                    foreach (BarItemLink mSubLink in mBarSubItem.ItemLinks)
                                    {
                                        var userFeaturePermisionBarSubItem = userFeaturePermisions.Where(x =>
                                            mSubLink != null &&
                                            x.FeaturesModel.MenuItemCode.ToLower()
                                                .Equals(mSubLink.Item.Name.ToLower()));
                                        mSubLink.Visible =
                                            userFeaturePermisionBarSubItem.Any() ||
                                            mSubLink.Item.Name == "barButtonLoginItem";
                                        if (mSubLink.Visible)
                                            countmSubLink++;
                                    }
                                    if (mBarSubItem.Name == "barButtonLoginItem")
                                    {
                                        currenLink.Visible = true;
                                    }
                                    mBarSubItem.Visibility = countmSubLink > 0
                                        ? BarItemVisibility.Always
                                        : BarItemVisibility.Never;
                                    mCurrentItem.Visibility =
                                        countmSubLink > 0 ? BarItemVisibility.Always : BarItemVisibility.Never;
                                }
                                else
                                {
                                    var userFeaturePermision = userFeaturePermisions.Where(x => mCurrentItem != null &&
                                                                                                x.FeaturesModel
                                                                                                    .MenuItemCode
                                                                                                    .ToLower().Equals(
                                                                                                        mCurrentItem
                                                                                                            .Name
                                                                                                            .ToLower()));
                                    currenLink.Visible =
                                        userFeaturePermision.Any() || currenLink.Item.Name == "barButtonLoginItem";
                                }
                                if (countmSubLink > 0)
                                    currenLink.Visible = true;
                                if (currenLink.Visible)
                                    countcurrenLink++;
                            }
                            currentGroup.Visible = countcurrenLink > 0;
                        }
                    }
                }
            }
            else
            {
                pageCategory.Visible = true;
                pageTreasury.Visible = true;
                pageHelp.Visible = true;
            }
        }

        /// <summary>
        /// Inserts the feature.
        /// </summary>
        private void InsertFeature()
        {
            List<FeaturesModel> featuresModels = new List<FeaturesModel>();
            foreach (RibbonPage currentPage in ribbonMainMenu.Pages)
            {
                var listRibbonPage = new FeaturesModel
                {
                    IsActive = true,
                    FeatureID = Guid.NewGuid().ToString(),
                    MenuItemCode = currentPage.Name,
                    Name = currentPage.Text,
                    ParentID = null
                };
                featuresModels.Add(listRibbonPage);
                foreach (RibbonPageGroup currentGroup in currentPage.Groups)
                {
                    var listRibbonPageGroup = new FeaturesModel
                    {
                        IsActive = true,
                        FeatureID = Guid.NewGuid().ToString(),
                        MenuItemCode = currentGroup.Name,
                        Name = currentGroup.Text,
                        ParentID = listRibbonPage.FeatureID
                    };
                    featuresModels.Add(listRibbonPageGroup);
                    foreach (BarItemLink currenLink in currentGroup.ItemLinks)
                    {
                        BarItem mCurrentItem = currenLink.Item;
                        var listBarItemLink = new FeaturesModel
                        {
                            IsActive = true,
                            FeatureID = Guid.NewGuid().ToString(),
                            MenuItemCode = mCurrentItem.Name,
                            Name = mCurrentItem.Caption,
                            ParentID = listRibbonPageGroup.FeatureID
                        };
                        featuresModels.Add(listBarItemLink);
                        if (mCurrentItem.GetType().FullName == "DevExpress.XtraBars.BarSubItem")
                        {
                            var mBarSubItem = (BarSubItem)mCurrentItem;
                            foreach (BarItemLink mSubLink in mBarSubItem.ItemLinks)
                            {
                                BarItem mSubCurrentItem = mSubLink.Item;
                                var listSubBarItemLink = new FeaturesModel
                                {
                                    IsActive = true,
                                    FeatureID = Guid.NewGuid().ToString(),
                                    MenuItemCode = mSubCurrentItem.Name,
                                    Name = mSubCurrentItem.Caption,
                                    ParentID = listBarItemLink.FeatureID
                                };
                                featuresModels.Add(listSubBarItemLink);
                            }
                        }
                    }
                }
            }
            var _model = new Model.Model();
            _model.InsertFeatures(featuresModels);
        }

        public IList<FeaturesModel> Features { get; set; }

        #region Update và Auto Update

        /// <summary>
        /// Checks for update.
        /// </summary>
       


        /// <summary>
        /// Kiểm tra bản cập nhật
        /// </summary>
        /// <param name="type">0 = auto check, 1 = manual check</param>
        private void CheckForNewVersion(bool isAutoUpdate)
        {
            if (AutoUpdaterPlugin.CheckForNewVersion(GlobalVariable.LinkServerUpdate, GlobalVariable.LicenseLimit,isAutoUpdate))
                CheckForUpdate();
        }
        private void CheckForUpdate()
        {
            //Tudt comment ngày 17.10.2018
            ////Uncomment below lines to select download path where update is saved.
            //var folderBrowserDialog = new FolderBrowserDialog();
            //folderBrowserDialog.Description = ResourceHelper.GetResourceValueByName("SelectFolderForUpdate");
            //if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;
            //AutoUpdaterPlugin.DownloadPath = folderBrowserDialog.SelectedPath; //sau nay dua vao dboption
            _autoUpdateClicked = true;
            AutoUpdaterPlugin.Mandatory = true;
            AutoUpdaterPlugin.Start(GlobalVariable.LinkServerUpdate, null, GlobalVariable.LicenseLimit);
        }

        /// <summary>
        /// Kiểm tra hết hạn license
        /// </summary>
        /// <returns></returns>
        private bool IsExpried()
        {
            //GlobalVariable.TimeExpried = Convert.ToDateTime("01-01-2050");//AntNT: Sau này get trong file license
            DateTime thistime = DateTime.Now;//AnhNT: Sau này get time onilne trên server
            if (thistime > GlobalVariable.TimeExpried)
                return true;
            return false;
        }

        /// <summary>
        /// Automatics the updater configuration.
        /// </summary>
        private void AutoUpdaterConfiguration()
        {
            //Tudt comment ngày 17.10.2018
            //Uncomment below lines to handle parsing logic of non XML AppCast file.
            //AutoUpdaterPlugin.ParseUpdateInfoEvent += AutoUpdaterOnParseUpdateInfoEvent;
            //AutoUpdaterPlugin.Start("http://10.0.0.241:1000/abigtime_auto_updater.json");

            //Uncomment below line to run update process using non administrator account.
            //AutoUpdaterPlugin.RunUpdateAsAdmin = false;

            //If you want to open download page when user click on download button uncomment below line.
            AutoUpdaterPlugin.OpenDownloadPage = false;

            //Don't want user to select remind later time in AutoUpdater notification window then uncomment 3 lines below so default remind later time will be set to 2 days.
            AutoUpdaterPlugin.LetUserSelectRemindLater = false;
            AutoUpdaterPlugin.RemindLaterTimeSpan = RemindLaterFormat.Minutes;
            AutoUpdaterPlugin.RemindLaterAt = 1;

            //Don't want to show Skip button then uncomment below line.
            AutoUpdaterPlugin.ShowSkipButton = false;

            //Don't want to show Remind Later button then uncomment below line.
            AutoUpdaterPlugin.ShowRemindLaterButton = false;

            //Want to show errors then uncomment below line.
            AutoUpdaterPlugin.ReportErrors = true;

            //Want to handle how your application will exit when application finished downloading then uncomment below line.
            AutoUpdaterPlugin.ApplicationExitEvent += AutoUpdater_ApplicationExitEvent;

            //Want to handle update logic yourself then uncomment below line.
            //AutoUpdaterPlugin.CheckForUpdateEvent += AutoUpdaterOnCheckForUpdateEvent;

            //Want to use XML and Update file served only through Proxy.
            //var proxy = new WebProxy("localproxyIP:8080", true) {Credentials = new NetworkCredential("domain\\user", "password")};
            //AutoUpdater.Proxy = proxy;

            //Want to check for updates frequently then uncomment following lines.
            //System.Timers.Timer timer = new System.Timers.Timer
            //{
            //    Interval = 2 * 60 * 1000,
            //    SynchronizingObject = this
            //};
            //timer.Elapsed += delegate
            //{
            //    AutoUpdaterPlugin.Start("http://10.0.0.241:1000/abigtime_auto_updater.xml");
            //};
            //timer.Start();
        }

        /// <summary>
        /// Automatics the updater application exit event.
        /// </summary>
        private void AutoUpdater_ApplicationExitEvent()
        {
            //Text = @"BUCA A-BIGTIME.NET 2018 is Closing application...";
            Thread.Sleep(1000);
            System.Windows.Forms.Application.Exit();
            _autoUpdateClicked = false;
        }

        #endregion

        /// <summary>
        /// Form closing (Yes/No chưa được xử lý)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainRibbonForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult message = XtraMessageBox.Show("Bạn có muốn sao lưu dữ liệu trước khi thoát chương trình không?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            //yes/no chưa được xử lý
            if (message == DialogResult.Yes) //Sao lưu trước khi thoát
            {
                CommonFunction.BackupDatabase(splashScreenManager, "", true);
                System.Windows.Forms.Application.Exit();
            }
            if (message == DialogResult.No) //Không sao lưu trước khi thoát
            {
                System.Windows.Forms.Application.Exit();
            }
            if (message == DialogResult.Cancel) //Không thoát chương trình
            {
                e.Cancel = true;
            }
        }

        #region Delegate Functions
        void RefDepositItemEvent(int refTypeDepositItem)
        {

            switch (refTypeDepositItem)
            {

                case 153: // Thu tien gui

                    if (!CheckRole("barButtonBADeposit", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var userControlCashItem = new FrmBADeposits { Dock = DockStyle.Fill };
                    userControlCashItem.RefTypeId = RefType.BADeposit;
                    CommonFunction.RunUserControl(userControlCashItem, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = ResourceHelper.GetResourceValueByName("ResBADepositCaption");
                    userControlCashItem.AddData();
                    break;
                case 157: // chi tien gui

                    if (!CheckRole("barButtonBAWithDraw", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var userControlBAWithDraw = new FrmBAWithDraws { Dock = DockStyle.Fill };
                    userControlBAWithDraw.RefTypeId = RefType.BAWithDraw;
                    CommonFunction.RunUserControl(userControlBAWithDraw, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = ResourceHelper.GetResourceValueByName("ResBAWithDrawsCaption");
                    userControlBAWithDraw.AddData();
                    break;
                case 162: // Chuyen tien noi bo

                    if (!CheckRole("barButtonBABankTransfers", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var userControlBABankTransfer = new FrmBABankTransfers { Dock = DockStyle.Fill };
                    userControlBABankTransfer.RefTypeId = RefType.BABankTransfer;
                    CommonFunction.RunUserControl(userControlBABankTransfer, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = ResourceHelper.GetResourceValueByName("ResBABankTransfersCaption");
                    userControlBABankTransfer.AddData();
                    break;
                case 500: // Sổ tiền gửi
                    using (var frmXtraReport = new FrmXtraReportList())
                    {
                        ReportTool.DrilldownVoucherEvent += ReportTool_DrilldownVoucherEvent;
                        frmXtraReport.LoadData();
                        frmXtraReport.ViewReport(false, "S12-H");
                        break;
                    }

                case 1: // Đối tượng

                    if (!CheckRole("barButtonAccountingObject", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var userControlAccountingObject = new FrmAccountingObjects { Dock = DockStyle.Fill };
                    CommonFunction.RunUserControl(userControlAccountingObject, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = ResourceHelper.GetResourceValueByName("ResAccountingObject");
                    //userControlAccountingObject.AddData();
                    break;
                case 2: // Can bo

                    if (!CheckRole("barButtonStaff", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var userControlStaff = new FrmEmployees { Dock = DockStyle.Fill };
                    CommonFunction.RunUserControl(userControlStaff, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = ResourceHelper.GetResourceValueByName("ResEmployeeCaption");
                    //userControlStaff.AddData();
                    break;
                case 3: // TK ngan hang, kho bac

                    if (!CheckRole("barButtonBank", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var userControlBank = new FrmBanks { Dock = DockStyle.Fill };
                    CommonFunction.RunUserControl(userControlBank, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = ResourceHelper.GetResourceValueByName("ResBankCaption");
                    //userControlBank.AddData();
                    break;
                case 4: // formlist thu tien gui
                    if (!CheckRole("barButtonBADeposit", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var userControlCashItems = new FrmBADeposits { Dock = DockStyle.Fill };
                    userControlCashItems.RefTypeId = RefType.BADeposit;
                    CommonFunction.RunUserControl(userControlCashItems, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = ResourceHelper.GetResourceValueByName("ResBADepositCaption");
                    break;
                case 5: // formlist chuyen tien noi bo
                    if (!CheckRole("barButtonBABankTransfers", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var userControlBABankTransfers = new FrmBABankTransfers { Dock = DockStyle.Fill };
                    userControlBABankTransfers.RefTypeId = RefType.BABankTransfer;
                    CommonFunction.RunUserControl(userControlBABankTransfers, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = ResourceHelper.GetResourceValueByName("ResBABankTransfersCaption");
                    break;
                case 6: // formlist chi tien gui
                    if (!CheckRole("barButtonBAWithDraw", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var userControlBAWithDraws = new FrmBAWithDraws { Dock = DockStyle.Fill };
                    userControlBAWithDraws.RefTypeId = RefType.BAWithDraw;
                    CommonFunction.RunUserControl(userControlBAWithDraws, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = ResourceHelper.GetResourceValueByName("ResBAWithDrawsCaption");
                    break;
            }
        }


        void RefInventoryItemEvent(int refTypeInventoryItem, bool isDetail)
        {

            switch (refTypeInventoryItem)
            {

                case 107: // nhập mua bằng tiền mặt
                    if (!CheckRole("barButtonCAPaymentInward", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var userCapaymentInventory = new FrmCAPaymentInwards() { Dock = DockStyle.Fill };
                    userCapaymentInventory.RefTypeId = RefType.CAPaymentInventoryItem;
                    CommonFunction.RunUserControl(userCapaymentInventory, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = userCapaymentInventory.FormCaption;
                    userCapaymentInventory.AddData();


                    break;
                case 158: // nhập mua bằng tiền gửi

                    if (!CheckRole("barButtonBAWithDrawPurchase", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var userBAWithDrawPurchases = new FrmBAWithDrawPurchases() { Dock = DockStyle.Fill };
                    userBAWithDrawPurchases.RefTypeId = RefType.BAWithDrawPurchase;
                    CommonFunction.RunUserControl(userBAWithDrawPurchases, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = userBAWithDrawPurchases.FormCaption;
                    userBAWithDrawPurchases.AddData();
                    break;
                case 57: // nhập mua bằng chuyển khoản

                    if (!CheckRole("barButtonBUTransferPurchase", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var userButranferpurchase = new FrmBUTransferPurchases() { Dock = DockStyle.Fill };
                    userButranferpurchase.RefTypeId = RefType.BUTransferPurchase;
                    CommonFunction.RunUserControl(userButranferpurchase, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = userButranferpurchase.FormCaption;
                    userButranferpurchase.AddData();
                    break;



                case 201: // nhập mua chưa thanh toán

                    if (!CheckRole("barButtonINInward", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var useInward = new FrmINInward() { Dock = DockStyle.Fill };
                    useInward.RefTypeId = RefType.INInward;
                    CommonFunction.RunUserControl(useInward, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = useInward.FormCaption;
                    useInward.AddData();
                    break;
                case 202: // xuất kho

                    if (!CheckRole("barButtonINward", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var useInOutward = new FrmINOutwards() { Dock = DockStyle.Fill };
                    useInOutward.RefTypeId = RefType.INOutward;
                    CommonFunction.RunUserControl(useInOutward, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = useInOutward.FormCaption;
                    if (isDetail)
                        useInOutward.AddData();
                    break;

                case 500: //báo cáo tồn kho
                    using (var frmXtraReport = new FrmXtraReportList())
                    {
                        ReportTool.DrilldownVoucherEvent += ReportTool_DrilldownVoucherEvent;
                        frmXtraReport.LoadData();
                        frmXtraReport.ViewReport(false, "S21-H");
                        break;
                    }
                case 6: // tính giá 

                    if (!CheckRole("barButtonAccountingObject", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var frmCalculateInventoryOutputPrice = new FrmCalculateInventoryOutputPrice();
                    frmCalculateInventoryOutputPrice.ShowDialog();
                    break;

                case 1: // Đối tượng

                    if (!CheckRole("barButtonAccountingObject", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var userControlAccountingObject = new FrmAccountingObjects { Dock = DockStyle.Fill };
                    CommonFunction.RunUserControl(userControlAccountingObject, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = ResourceHelper.GetResourceValueByName("ResAccountingObject");
                    //userControlAccountingObject.AddData();
                    break;
                case 2: // Can bo

                    if (!CheckRole("barButtonStaff", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var userControlStaff = new FrmEmployees { Dock = DockStyle.Fill };
                    CommonFunction.RunUserControl(userControlStaff, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = ResourceHelper.GetResourceValueByName("ResEmployeeCaption");
                    //userControlStaff.AddData();
                    break;
                case 3: // Kho

                    if (!CheckRole("barButtonStock", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var userControlStock = new FrmStocks() { Dock = DockStyle.Fill };
                    CommonFunction.RunUserControl(userControlStock, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = ResourceHelper.GetResourceValueByName("ResStockCaption");

                    break;
                case 4: // Vật tư hàng hóa

                    if (!CheckRole("barButtonInventoryItem", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var userControlInventory = new FrmInventoryItems() { Dock = DockStyle.Fill };
                    CommonFunction.RunUserControl(userControlInventory, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = ResourceHelper.GetResourceValueByName("ResInventoryItemCaption");

                    break;
                case 5: // công cụ dụng c

                    if (!CheckRole("barButtonTool", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var userControlTool = new FrmTools() { Dock = DockStyle.Fill };
                    CommonFunction.RunUserControl(userControlTool, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = ResourceHelper.GetResourceValueByName("ResToolCaption");

                    break;
            }
        }
        void RefSalaryItemEvent(int refTypeSalary, bool isDetail)
        {

            switch (refTypeSalary)
            {

                case 2: // phòng ban

                    if (!CheckRole("barButtonDepartment", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var userDepartments = new FrmDepartments() { Dock = DockStyle.Fill };
                    CommonFunction.RunUserControl(userDepartments, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = userDepartments.FormCaption;
                    //userControlAccountingObject.AddData();
                    break;
                case 1: //cán bộ

                    if (!CheckRole("barButtonStaff", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var userStaff = new FrmEmployees() { Dock = DockStyle.Fill };
                    CommonFunction.RunUserControl(userStaff, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = userStaff.FormCaption;

                    break;

            }
        }

        void RefCashItemEvent(int refTypeCashItem)
        {
            switch (refTypeCashItem)
            {
                case 101: // Phiếu thu
                    if (!CheckRole("barButtonCAReceipt", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }
                    var userControlCAReceipt = new FrmCAReceipts { Dock = DockStyle.Fill };
                    userControlCAReceipt.RefTypeId = RefType.CAReceipt;
                    CommonFunction.RunUserControl(userControlCAReceipt, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = ResourceHelper.GetResourceValueByName("ResCashReceiptCaption");
                    userControlCAReceipt.AddData();
                    break;
                case 114: // Phiếu rút tiền gửi NH, KB
                    if (!CheckRole("barButtonPaymentItem", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }
                    var userControlPaymentItem = new FrmCAReceiptTreasuries { Dock = DockStyle.Fill };
                    userControlPaymentItem.RefTypeId = RefType.CAReceiptTreasury;
                    CommonFunction.RunUserControl(userControlPaymentItem, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text =
                        ResourceHelper.GetResourceValueByName("ResCashReceiptTreasuriesCaption");
                    userControlPaymentItem.AddData();
                    break;
                case 105: // Phiếu thu từ ngân sách nhà nước
                    if (!CheckRole("barButtonCAReceiptEstimate", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }
                    var userControlCAReceiptEstimate = new FrmCAReceiptEstimates { Dock = DockStyle.Fill };
                    userControlCAReceiptEstimate.RefTypeId = RefType.CAReceiptEstimate;
                    CommonFunction.RunUserControl(userControlCAReceiptEstimate, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text =
                        ResourceHelper.GetResourceValueByName("ResCashReceiptEstimateCaption");
                    userControlCAReceiptEstimate.AddData();
                    break;
                case 106: // Phiếu chi
                    if (!CheckRole("barButtonCAPayment", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }
                    var userControlCAPayment = new FrmCAPayment { Dock = DockStyle.Fill };
                    userControlCAPayment.RefTypeId = RefType.CAPayment;
                    CommonFunction.RunUserControl(userControlCAPayment, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text =
                        ResourceHelper.GetResourceValueByName("ResCAPaymentCaption");
                    userControlCAPayment.AddData();

                    break;
                case 113: // Phiếu chi nộp tiền vào NH, KB
                    if (!CheckRole("barButtonCAPaymentTreasury", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }
                    var userControlCAPaymentTreasury = new FrmCAPaymentTreasuries { Dock = DockStyle.Fill };
                    userControlCAPaymentTreasury.RefTypeId = RefType.CAPaymentTreasury;
                    CommonFunction.RunUserControl(userControlCAPaymentTreasury, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text =
                        ResourceHelper.GetResourceValueByName("ResCAPaymentTreasuryCaption");
                    userControlCAPaymentTreasury.AddData();
                    break;
                case 500: //Sổ quỹ tiền mặt
                    using (var frmXtraReport = new FrmXtraReportList())
                    {
                        ReportTool.DrilldownVoucherEvent += ReportTool_DrilldownVoucherEvent;
                        frmXtraReport.LoadData();
                        frmXtraReport.ViewReport(false, "S11-H");
                        break;
                    }


                case 1: // Đối tượng

                    if (!CheckRole("barButtonAccountingObject", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var userControlAccountingObject = new FrmAccountingObjects { Dock = DockStyle.Fill };
                    CommonFunction.RunUserControl(userControlAccountingObject, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = ResourceHelper.GetResourceValueByName("ResAccountingObject");
                    //userControlAccountingObject.AddData();
                    break;
                case 2: // Can bo

                    if (!CheckRole("barButtonStaff", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var userControlStaff = new FrmEmployees { Dock = DockStyle.Fill };
                    CommonFunction.RunUserControl(userControlStaff, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = ResourceHelper.GetResourceValueByName("ResEmployeeCaption");
                    //userControlStaff.AddData();
                    break;
                case 3: // TK ngan hang, kho bac

                    if (!CheckRole("barButtonBank", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    var userControlBank = new FrmBanks { Dock = DockStyle.Fill };
                    CommonFunction.RunUserControl(userControlBank, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = ResourceHelper.GetResourceValueByName("ResBankCaption");
                    //userControlBank.AddData();
                    break;
                case 4: // formlist phieu thu
                    if (!CheckRole("barButtonCAReceipt", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }
                    var userControlCAReceipts = new FrmCAReceipts { Dock = DockStyle.Fill };
                    userControlCAReceipts.RefTypeId = RefType.CAReceipt;
                    CommonFunction.RunUserControl(userControlCAReceipts, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text = ResourceHelper.GetResourceValueByName("ResCashReceiptCaption");
                    break;
                case 5: // formlist phieu chi
                    if (!CheckRole("barButtonCAPayment", "Add"))
                    {
                        MessageBox.Show(@"Bạn không có quyền", @"Thông báo", MessageBoxButtons.OK);
                        return;
                    }
                    var userControlCAPayments = new FrmCAPayment { Dock = DockStyle.Fill };
                    userControlCAPayments.RefTypeId = RefType.CAPayment;
                    CommonFunction.RunUserControl(userControlCAPayments, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text =
                        ResourceHelper.GetResourceValueByName("ResCAPaymentCaption");
                    break;
            }



        }

        private bool CheckRole(string menuId, string eventId)
        {
            if (_listPermissionMapingModels == null)
            {
                return true;
            }
            var it =
                _listPermissionMapingModels.Where(x => x.FeatureID == menuId && x.UserPermisionID == eventId)
                                           .FirstOrDefault();
            if (it == null)
            {
                return false;
            }
            return it.IsActive;

        }
        #endregion


        private void barButtonCreateNewDatabase_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonBAWithDrawFixedAsset_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonCommitmentAdjustment_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItemFADevaluation_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barBtnCurrency_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void bbtnEmployeeType_ItemClick(object sender, ItemClickEventArgs e)
        {
            // 
        }

        private void barBudgetExpense_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}