/***********************************************************************
 * <copyright file="FrmXtraAuditingLog.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Wednesday, August 26, 2015
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
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AudittingLog;
using Buca.Application.iBigTime2020.Presenter.Dictionary.RefType;
using Buca.Application.iBigTime2020.Presenter.System.UserProfile;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.View.System;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using DateTimeRangeBlockDev.Helper;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using System.Globalization;
using System.Windows.Forms;
using BuCA.Application.iBigTime2020.Session;
using BuCA.Enum;
using Buca.Application.iBigTime2020.Model.BusinessObjects.System;
using DevExpress.XtraGrid.Views.Base;
using Microsoft.SqlServer.Management.Dmf;
using Microsoft.SqlServer.Management.Smo;
using DevExpress.XtraGrid.Views.Grid;

namespace Buca.Application.iBigTime2020.WindowsForm.FormSystem
{
    public partial class FrmXtraAuditingLog : XtraForm, IAudittingLogsView, IRefTypesView, IUserProfilesView
    {
        private readonly AudittingLogsPresenter _audittingLogsPresenter;
        private readonly RefTypesPresenter _refTypesPresenter;
        private readonly UserProfilesPresenter _userProfilesPresenter;
        private RepositoryItemGridLookUpEdit _rsAction;
        private GridView _rsActionView;

        public FrmXtraAuditingLog()
        {
            InitializeComponent();
            
            _audittingLogsPresenter = new AudittingLogsPresenter(this);
            _refTypesPresenter = new RefTypesPresenter(this);
            _userProfilesPresenter = new UserProfilesPresenter(this);
            _rsAction = new RepositoryItemGridLookUpEdit { ShowDropDown = ShowDropDown.SingleClick };
            _rsAction.Buttons[0].Visible = true;
            gridView.OptionsView.ShowAutoFilterRow = true;
         //   var commonVariable = new GlobalVariable();
            dateTimeRangeV.DateRangePeriodMode = DateRangeMode.All;
            dateTimeRangeV.InitSelectedIndex = 3;
            dateTimeRangeV.InitData(DateTime.Parse(GlobalVariable.PostedDate));
            // dateTimeRangeV.ToDate = (DateTime.ParseExact(GlobalVariable.PostedDate, "dd/MM/yyyy", CultureInfo.InvariantCulture));
        }

        private bool _firstTime = true;
        private IList<AudittingLogModel> _audittingLogs;

        #region IAudittingLogsView Members

        /// <summary>
        /// Sets the audittingLogs.
        /// </summary>
        /// <value>
        /// The audittingLogs.
        /// </value>
        public IList<AudittingLogModel> AudittingLogs
        {
            set
            {
                grdMain.DataSource = value;
                if (_firstTime)
                {
                    _audittingLogs = value;
                }
                
                var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "EventId", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "LoginName",
                        ColumnCaption = "Người dùng",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    },
                    new XtraColumn
                    {
                        ColumnName = "ComputerName",
                        ColumnCaption = "Tên máy tính",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 150
                    },
                    new XtraColumn
                    {
                        ColumnName = "EventTime",
                        ColumnCaption = "Thời gian thực hiện",
                        ColumnPosition = 3,
                        ColumnVisible = true,
                        ColumnWith = 150,
                        Alignment = HorzAlignment.Center,
                        ColumnType = UnboundColumnType.DateTime
                    },
                    new XtraColumn
                    {
                        ColumnName = "ComponentName", 
                         ColumnCaption = "Chức năng",
                        ColumnPosition = 4,
                        ColumnVisible = true,
                        ColumnWith = 250
                    },
                    new XtraColumn
                    {
                        ColumnName = "Reference",
                        ColumnCaption = "Tham chiếu",
                        ColumnPosition = 5,
                        ColumnVisible = true,
                        ColumnWith = 250
                    },
                    new XtraColumn
                    {
                        ColumnName = "EventAction",
                        ColumnCaption = "Thao tác",
                        ColumnPosition = 6,
                        ColumnVisible = true,
                        ColumnWith = 70,
                        RepositoryControl = _rsAction
                    },
                    new XtraColumn
                    {
                        ColumnName = "Amount",
                        ColumnCaption = "Số tiền",
                        ColumnPosition = 7,
                        ColumnVisible = false,
                        ColumnWith = 70
                    }
                };
                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {

                        gridView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        gridView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        gridView.Columns[column.ColumnName].Width = column.ColumnWith;
                        gridView.Columns[column.ColumnName].UnboundType = column.ColumnType;
                        gridView.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                    }
                    else
                        gridView.Columns[column.ColumnName].Visible = false;
                }
                gridView.Columns["EventTime"].DisplayFormat.FormatType = FormatType.DateTime;
                gridView.Columns["EventTime"].DisplayFormat.FormatString = "g";
            }
        }

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected void LoadDataIntoGrid()
        {
            IList<ActionForm> dataSource = new List<ActionForm>();
            dataSource.Add(new ActionForm(1, "Thêm mới"));
            dataSource.Add(new ActionForm(2, "Sửa"));
            dataSource.Add(new ActionForm(3, "Xóa"));
            dataSource.Add(new ActionForm(4, "Xem"));
            dataSource.Add(new ActionForm(5, "Nhân bản"));
            dataSource.Add(new ActionForm(6, "In"));
            dataSource.Add(new ActionForm(7, "Đăng nhập"));
            dataSource.Add(new ActionForm(8, "Đăng xuất"));


            _rsActionView = new GridView();
            _rsActionView.OptionsView.ColumnAutoWidth = false;
            _rsAction = new RepositoryItemGridLookUpEdit
            {
                NullText = "",
                View = _rsActionView,
                TextEditStyle = TextEditStyles.Standard,
            };
            _rsAction.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            _rsAction.View.OptionsView.ShowIndicator = false;
            _rsAction.PopupFormSize = new Size(10, 150);
            _rsAction.View.BestFitColumns();

            _rsAction.DataSource = dataSource;
            _rsActionView.PopulateColumns(dataSource);

            var gridColumnsCollection = new List<XtraColumn>();
            gridColumnsCollection.Add(new XtraColumn
            {
                ColumnName = "Id",
                ColumnCaption = "Mã nguồn vốn",
                ColumnVisible = false,
                ColumnPosition = 1
            });
            gridColumnsCollection.Add(new XtraColumn
            {
                ColumnName = "Name",
                ColumnCaption = "Thao tác",
                ColumnVisible = true,
                ColumnWith = 180,
                ColumnPosition = 2
            });

            XtraColumnCollectionHelper<ActionForm>.ShowXtraColumnInGridView(gridColumnsCollection, _rsActionView);


            _rsAction.DataSource = dataSource;
            _rsAction.DisplayMember = "Name";
            _rsAction.ValueMember = "Id";

            _audittingLogsPresenter.Display();
            _refTypesPresenter.Display();
            _userProfilesPresenter.Display();
        }
        /// </value>
        public IList<UserProfileModel> UserProfiles
        {
            set
            {
                lookUpUser.Properties.DataSource = value;
                lookUpUser.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in lookUpUser.Properties.Columns)
                {
                    if (column.FieldName != "UserName")
                    {
                        lookUpUser.Properties.Columns[column.FieldName].Visible = false;
                    }
                }
                lookUpUser.Properties.ShowHeader = false;
                lookUpUser.Properties.ShowFooter = false;
                lookUpUser.Properties.DisplayMember = "UserName";
            }
        }

        /// </value>
        public IList<RefTypeModel> RefTypes
        {
            set
            {
                grdLookUpRefType.Properties.DataSource = value.Where(c => c.RefTypeId != 63 && c.RefTypeId != 253 && c.RefTypeId != 206 && c.RefTypeId != 205 && c.RefTypeId != 603 && c.RefTypeId != 606).ToList(); //ẩn 6 chức năng không dùng đến!
                grdLookUpRefType.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdLookUpRefType.Properties.Columns)
                {
                    if (column.FieldName != "RefTypeName")
                    {
                        grdLookUpRefType.Properties.Columns[column.FieldName].Visible = false;
                    }
                }
                grdLookUpRefType.Properties.ShowHeader = false;
                grdLookUpRefType.Properties.ShowFooter = false;
                grdLookUpRefType.Properties.DisplayMember = "RefTypeName";
            }
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected void DeleteGrid()
        {
            //new AudittingLogPresenter(null).Delete(int.Parse(PrimaryKeyValue));
        }

        #endregion


        private void FilterData()
        {
            try
            {
                var list =
                      _audittingLogs.Where(c => c.EventTime.Date >= dateTimeRangeV.FromDate.Date && c.EventTime.Date <= dateTimeRangeV.ToDate.Date &&
                          ((checkEditAllUser.Checked || string.IsNullOrEmpty(lookUpUser.Text)) || c.LoginName == lookUpUser.Text) &&
                          ((checkEditAllRefType.Checked || string.IsNullOrEmpty(grdLookUpRefType.Text)) || c.ComponentName == grdLookUpRefType.Text))
                          .ToList();
                AudittingLogs = list;
                //var list =
                //    _audittingLogs.Where(c => c.EventTime >= dateTimeRangeV.FromDate && c.EventTime <= dateTimeRangeV.ToDate &&
                //        ((checkEditAllUser.Checked || string.IsNullOrEmpty(lookUpUser.Text)) || c.LoginName == lookUpUser.Text) &&
                //        ((checkEditAllRefType.Checked || string.IsNullOrEmpty(grdLookUpRefType.Text)) || c.ComponentName.ToUpper().Contains(grdLookUpRefType.Text.ToUpper())))
                //        .ToList();
                //AudittingLogs = list;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex + "Lỗi:" + ex.InnerException);
            }
        }

        /// <summary>

        private void FrmXtraAuditingLog_Load(object sender, EventArgs e)
        {
            checkEditAllRefType.Checked = true;
            checkEditAllUser.Checked = true;
            LoadDataIntoGrid();
            btnFilter.PerformClick();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            _firstTime = false;
            FilterData();
        }

        /// Sets the reference types.
        /// </summary>
        /// <value>
        /// The reference types.
    
        /// <summary>
        /// Sets the user profiles.
        /// </summary>
        /// <value>
        /// The user profiles.
    
        /// <summary>
        /// Handles the CheckedChanged event of the checkEditAllUser control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkEditAllUser_CheckedChanged(object sender, EventArgs e)
        {
            lookUpUser.Enabled = !checkEditAllUser.Checked;
            if (checkEditAllUser.Checked)
                lookUpUser.EditValue = "";
        }

        /// <summary>
        /// Handles the CheckedChanged event of the checkEditAllRefType control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkEditAllRefType_CheckedChanged(object sender, EventArgs e)
        {
            grdLookUpRefType.Enabled = !checkEditAllRefType.Checked;
            if (checkEditAllRefType.Checked)
                grdLookUpRefType.EditValue = "";
        }


        /// <summary>
        /// Handles the KeyDown event of the FrmXtraAuditingLog control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void FrmXtraAuditingLog_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
                Close();
        }
    }

    /// <summary>
    /// Các hành động với CSDL
    /// </summary>
    class ActionForm
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ActionForm(int id, string name)
        {
            Id = id;
            Name = name;
        } 
    }
}