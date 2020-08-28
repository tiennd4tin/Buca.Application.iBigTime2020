using System.Collections.Generic;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.System;
using Buca.Application.iBigTime2020.View.System;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.XtraEditors;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;
using Buca.Application.iBigTime2020.Presenter.System.UserProfile;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;

namespace Buca.Application.iBigTime2020.WindowsForm.FormSystem.UserProfile
{
    public partial class UserControlUserProfileList : FrmBaseList, IUserProfilesView
    {
        private readonly UserProfilesPresenter _userProfilesPresenter;

        public UserControlUserProfileList()
        {
            InitializeComponent();
            _userProfilesPresenter = new UserProfilesPresenter(this);
        }

        private void UserControlUserProfileList_Load(object sender, System.EventArgs e)
        {
            //_userProfilesPresenter.Display();
        }

        protected override void LoadDataIntoGrid()
        {
            _userProfilesPresenter.Display();
        }

        public IList<UserProfileModel> UserProfiles
        {
            set
            {
                ListBindingSource.DataSource = value;
                gridView.PopulateColumns(value);

                ColumnsCollection.Add(new XtraColumn { ColumnName = "UserName", ColumnCaption = "Tên đăng nhập", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 200 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FullName", ColumnCaption = "Tên người dùng", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 300 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "JobTitle", ColumnCaption = "Chức danh", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 300 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 100 });

                XtraColumnCollectionHelper<UserProfileModel>.ShowXtraColumnInGridView(ColumnsCollection, gridView);
            }
        }

        protected override void DeleteGrid()
        {
            new UserProfilePresenter(null).Delete(PrimaryKeyValue);
        }

        public override void GridViewFocusedRowChanged()
        {
            var item = gridView.GetFocusedRow();
            if (item == null)
                return;

            var model = (UserProfileModel)item;
            var bEqual = model.UserName == null ? false : model.UserName.Equals("admin");
            barButtonDeleteItem.Enabled = !bEqual;
            barButtonItemRole.Enabled = !bEqual;
        }
    }
}
