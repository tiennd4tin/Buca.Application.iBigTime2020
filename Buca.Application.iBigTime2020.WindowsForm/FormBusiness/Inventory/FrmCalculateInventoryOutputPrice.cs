/***********************************************************************
 * <copyright file="FrmCalculateInventoryOutputPrice.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Friday, May 25, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Inventory;
using Buca.Application.iBigTime2020.Presenter.Dictionary.InventoryItem;
using Buca.Application.iBigTime2020.Presenter.Inventory;
using Buca.Application.iBigTime2020.View.Inventory;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Account;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using BuCA.Application.iBigTime2020.Session;
using DateTimeRangeBlockDev.Helper;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Inventory
{
    /// <summary>
    /// Class FrmCalculateInventoryOutputPrice.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.View.Inventory.IINInwardOutwardsView" />
    /// <seealso cref="DevExpress.XtraEditors.XtraForm" />
    public partial class FrmCalculateInventoryOutputPrice : XtraForm, IINInwardOutwardsView
    {
        /// <summary>
        /// The i n inward outwards presenter
        /// </summary>
        readonly INInwardOutwardsPresenter _iNInwardOutwardsPresenter;

        #region Variable
        /// <summary>
        /// Gets or sets the default debit account category identifier.
        /// </summary>
        /// <value>
        /// The default debit account category identifier.
        /// </value>
        public static string InventoryItems { get; set; }
        #endregion 

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmCalculateInventoryOutputPrice" /> class.
        /// </summary>
        public FrmCalculateInventoryOutputPrice()
        {
            InitializeComponent();
            _iNInwardOutwardsPresenter = new INInwardOutwardsPresenter(this);
            dateTimeRangeV1.DateRangePeriodMode = DateRangeMode.Reduce;
            dateTimeRangeV1.InitSelectedIndex = GlobalVariable.DateRangeSelectedIndex;
            dateTimeRangeV1.InitData(DateTime.ParseExact(GlobalVariable.PostedDate, "dd/MM/yyyy", CultureInfo.InvariantCulture));
            dateTimeRangeV1.FromDate = (DateTime.ParseExact(GlobalVariable.PostedDate, "dd/MM/yyyy", CultureInfo.InvariantCulture));
            dateTimeRangeV1.ToDate = (DateTime.ParseExact(GlobalVariable.PostedDate, "dd/MM/yyyy", CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Shows the account detail.
        /// </summary>
        private void ShowInventoryItems()
        {
            try
            {
                var frmDetail = new FrmInventoryItemList();
                if (frmDetail.ShowDialog() == DialogResult.OK)
                {
                    InventoryItems = frmDetail.InventoryItemCodes;
                }

            }
            catch (Exception ex) { XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        /// <summary>
        /// Handles the Click event of the btnCalculatePrice control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnCalculatePrice_Click(object sender, EventArgs e)
        {
            // check chứng từ xuất kho
            if (!_iNInwardOutwardsPresenter.CheckExistVoucher(dateTimeRangeV1.FromDate, dateTimeRangeV1.ToDate,
                InventoryItems))
            {
                XtraMessageBox.Show("Không có chứng từ xuất kho vật tư nào trong khoảng thời gian bạn chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                IModel model = new Model.Model();
                string message;
                var lockCheck = model.GetLock();
                if(lockCheck.IsLock && ((dateTimeRangeV1.FromDate >= Convert.ToDateTime(GlobalVariable.LockVoucherDateFrom) && dateTimeRangeV1.ToDate <= Convert.ToDateTime(GlobalVariable.LockVoucherDateTo))))
                {
                    XtraMessageBox.Show("Không thể thực hiện tính giá trong kỳ khóa sổ! Vui lòng chọn khoảng thời gian ngoài kỳ khóa sổ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {

                        message = new InventoryItemPresenter(null).CalculateOutwardPrice(dateTimeRangeV1.FromDate, dateTimeRangeV1.ToDate, InventoryItems);
                        if (message == null)
                        {
                            XtraMessageBox.Show("Tính giá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Dispose();
                        }
                        else
                            XtraMessageBox.Show("Tính giá không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                }
            }

        }

        /// <summary>
        /// Handles the Click event of the btnSelectInventoryItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnSelectInventoryItem_Click(object sender, EventArgs e)
        {
            ShowInventoryItems();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the radSelectAll control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void radSelectAll_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radSelectAll.SelectedIndex == 0)
            {
                radOptional.SelectedIndex = -1;
                btnSelectInventoryItem.Enabled = false;
            }

        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the radOptional control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void radOptional_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radOptional.SelectedIndex == 0)
            {
                radSelectAll.SelectedIndex = -1;
                btnSelectInventoryItem.Enabled = true;
            }
        }

        /// <summary>
        /// Sets the in inward outwards.
        /// </summary>
        /// <value>
        /// The in inward outwards.
        /// </value>
        public IList<INInwardOutwardModel> INInwardOutwards { get; set; }
    }
}
