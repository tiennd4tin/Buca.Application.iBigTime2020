using Buca.Application.iBigTime2020.View.System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.System;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.Presenter.System.Permission;
using DevExpress.XtraTreeList.Data;
using DevExpress.XtraTreeList;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using Buca.Application.iBigTime2020.WindowsForm.Resources;

namespace Buca.Application.iBigTime2020.WindowsForm.FormSystem.UserProfile
{
    public partial class FrmPermiss : FrmXtraBaseTreeDetail, IFeaturesView, IUserPermisionsView, IFeaturePermisionView, IUserFeaturePermisionView
    {

        private readonly UserFeaturePermisionPresenter _userfeaturePermisionPresenter;
        private readonly FeaturePermisionPresenter _featurePermisionPresenter;
        private readonly UserPermisionsPresenter _userPermisionsPresenter;
        private readonly FeaturesPresenter _featuresPresenter;
        [Category("BaseProperty")]
        public bool ExpandAll { get; set; }
        public string UserFeaturePermisionID { get; set; }

        public string FeaturePermisionID { get; set; }
        public string UserPermisionID { get; set; }
        public string FeatureID { get; set; }
        public bool IsActive { get; set; }
        public string UserProfileID { get; set; }

        public FrmPermiss()
        {
            InitializeComponent();
            _featuresPresenter = new FeaturesPresenter(this);
            _userPermisionsPresenter = new UserPermisionsPresenter(this);
            _featurePermisionPresenter = new FeaturePermisionPresenter(this);
            _userfeaturePermisionPresenter = new UserFeaturePermisionPresenter(this);
        }

        public List<XtraColumn> ColumnsCollection = new List<XtraColumn>();
        public List<XtraColumn> ColumnsCollection2 = new List<XtraColumn>();
        private void FrmPermiss_Load(object sender, EventArgs e)
        {
            _featuresPresenter.Display();
            _userPermisionsPresenter.Display(null);
            InitializeTreeMain();
            LoadGridLayout();
            LoadTreeList();

        }
        public IList<FeaturesModel> Features
        {
            set
            {
                treeList.DataSource = value;
                treeList.PopulateColumns();
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FeatureID", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Code", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ParentID", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "MenuItemCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FormMasterName", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FormDetailName", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "SortOrder", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Name",
                    ColumnCaption = "Tên chức năng",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
            }
        }
        public IList<UserPermisionModel> UserPermisions
        {
            set
            {
                gridPermission.DataSource = value;
                gridViewPermission.PopulateColumns(value);
                ColumnsCollection2.Add(new XtraColumn { ColumnName = "UserPermisionID", ColumnVisible = false });
                ColumnsCollection2.Add(new XtraColumn { ColumnName = "Code", ColumnVisible = false });
                ColumnsCollection2.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                ColumnsCollection2.Add(new XtraColumn
                {
                    ColumnName = "IsActive",
                    ColumnCaption = "Chọn",
                    ColumnVisible = true,
                    ColumnWith = 50
                });
                ColumnsCollection2.Add(new XtraColumn
                {
                    ColumnName = "Name",
                    ColumnCaption = "Tên",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 120
                });
            }
        }
        public IList<UserPermisionModel> UserPermisionsByFeatureID
        {
            set
            {
                gridPermission.DataSource = value;
                gridViewPermission.PopulateColumns(value);
                ColumnsCollection2.Add(new XtraColumn { ColumnName = "UserPermisionID", ColumnVisible = false });
                ColumnsCollection2.Add(new XtraColumn { ColumnName = "Code", ColumnVisible = false });
                ColumnsCollection2.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                ColumnsCollection2.Add(new XtraColumn
                {
                    ColumnName = "IsActive",
                    ColumnCaption = "Chọn",
                    ColumnVisible = true,
                    ColumnWith = 50,
                });
                ColumnsCollection2.Add(new XtraColumn
                {
                    ColumnName = "Name",
                    ColumnCaption = "Tên",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 120
                });
            }
        }

        public void LoadTreeList()
        {
            if (ColumnsCollection != null)
            {
                foreach (var column in ColumnsCollection)
                {
                    if (treeList.Columns[column.ColumnName] != null)
                    {
                        if (column.ColumnVisible)
                        {
                            treeList.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            treeList.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            treeList.Columns[column.ColumnName].Width = column.ColumnWith;
                            treeList.Columns[column.ColumnName].AppearanceHeader.TextOptions.HAlignment = column.Alignment;
                            treeList.Columns[column.ColumnName].UnboundType = (UnboundColumnType)column.ColumnType;
                            treeList.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                        }
                        else treeList.Columns[column.ColumnName].Visible = false;
                    }
                }
            }
            if (ExpandAll) treeList.ExpandAll();
            else treeList.CollapseAll();
        }

        public void LoadGridLayout()
        {
            if (ColumnsCollection2 == null) return;
            foreach (var column in ColumnsCollection2)
            {
                if (gridViewPermission.Columns[column.ColumnName] == null) continue;
                if (column.ColumnVisible)
                {
                    gridViewPermission.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    gridViewPermission.Columns[column.ColumnName].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                    gridViewPermission.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                    gridViewPermission.Columns[column.ColumnName].Width = column.ColumnWith;
                    gridViewPermission.Columns[column.ColumnName].AppearanceCell.TextOptions.HAlignment = column.Alignment;
                    gridViewPermission.Columns[column.ColumnName].UnboundType = column.ColumnType;
                    gridViewPermission.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                    gridViewPermission.Columns[column.ColumnName].ToolTip = column.ToolTip;
                    gridViewPermission.Columns[column.ColumnName].DisplayFormat.FormatString = column.DisplayFormat;
                }
                else
                    gridViewPermission.Columns[column.ColumnName].Visible = false;
            }
        }

        private void InitializeTreeMain()
        {
            treeList.ParentFieldName = "ParentID";
            treeList.KeyFieldName = "FeatureID";
        }
        private void treeList_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {
            e.Appearance.Font = e.Node.HasChildren || e.Node.Level == 0
               ? new Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold)
               : new Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Regular);
        }

        private void treeList_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                var featureId = treeList.FocusedNode[treeList.KeyFieldName].ToString();
                _userPermisionsPresenter.Display(featureId, UserProfileID);
                radioButtonALL.Checked = false;
                radioButtonSelect.Checked = false;
                gridViewPermission.RefreshData();
                LoadGridLayout();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"));
            }
        }
        protected override string SaveData()
        {
            var userFeaturePermisions = new List<UserFeaturePermisionModel>();
            FeatureID = treeList.FocusedNode[treeList.KeyFieldName].ToString();
            for (var i = 0; i < gridViewPermission.RowCount; i++)
            {
                UserPermisionID = gridViewPermission.GetRowCellValue(i, "UserPermisionID").ToString();
                IsActive = Convert.ToBoolean(gridViewPermission.GetRowCellValue(i, "IsActive").ToString());
                //if (IsActive)
                //{
                    userFeaturePermisions.Add(new UserFeaturePermisionModel
                    {
                        FeatureID = FeatureID,
                        UserFeaturePermisionID = null,
                        UserProfileID = UserProfileID,
                        UserPermisionID = UserPermisionID,
                        IsActive=IsActive
                    });
                //}
            }
            var message = _userfeaturePermisionPresenter.Save(userFeaturePermisions);
            radioButtonALL.Checked = false;
            radioButtonSelect.Checked = false;
            return "ok";
 
        }
        private void radioButtonSelect_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (var i = 0; i < gridViewPermission.RowCount; i++)
                {
                    gridViewPermission.SetRowCellValue(i, "IsActive", false);

                }
            }
            catch { }
        }

        private void radioButtonALL_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (var i = 0; i < gridViewPermission.RowCount; i++)
                {
                    gridViewPermission.SetRowCellValue(i, "IsActive", true);
                }
            }
            catch { }

        }
    }

}
    



