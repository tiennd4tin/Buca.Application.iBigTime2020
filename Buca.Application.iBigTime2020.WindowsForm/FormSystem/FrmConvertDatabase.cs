/***********************************************************************
 * <copyright file="FrmCreateNewDatabase.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 02 June 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Currency;
using Buca.Application.iBigTime2020.Presenter.Dictionary.DBOption;
using Buca.Application.iBigTime2020.View.Dictionary;
using System.Data.Sql;
using DevExpress.XtraEditors;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Buca.Application.iBigTime2020.Model;
using Buca.TransformData;
using BuCA.Application.iBigTime2020.Session;
using BuCA.Option;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Data.EntityClient;
using System.Configuration;
using System.Reflection;
using Buca.Application.iBigTime2020.WindowsForm.Code;
using Buca.Application.iBigTime2020.WindowsForm.Resources;

//using Microsoft.SqlServer.Dts.Runtime;



namespace Buca.Application.iBigTime2020.WindowsForm.FormSystem
{
    /// <summary>
    /// FrmCreateNewDatabase
    /// </summary>
    public partial class FrmConvertDatabase : XtraForm, IDBOptionsView
    {
        public class SourceServer
        {
            public string ServerName { get; set; }
            public string InstanceName { get; set; }
            public string ConnectString { get; set; }
            public int Id { get; set; }
        }



        public List<TreeNode> lstCheck = new List<TreeNode>();
        private const string DatabasePath = @"Data";
        private const string DatabaseTemplatePath = @"DataTemplate\aBigTimeBackup.bak";
        private int _typeOfCreateDatabase = 1;
        private const string XmlCompany = @"company.xml";
        private const string XmlCurrency = @"currency.xml";
        private readonly DBOptionsPresenter _dbOptionsPresenter;
        private readonly CurrencyPresenter _currencyPresenter;
        private ServerConnection _serverConnection;
        private Server _server;
        private readonly AccountPresenter _accountPresenter;
        private IList<PayItemModel> _payItems;
        private readonly Crypto Crypto = new Crypto(Crypto.SymmProvEnum.Rijndael);
        public List<SourceServer> lstSource = new List<SourceServer>();

        private bool _result = true;
        private bool isNewDB = true;
        Model.Model model = new Model.Model();




        #region PayItems

        /// <summary>
        /// Gets or sets the pay items.
        /// </summary>
        /// <value>
        /// The pay items.
        /// </value>
        public IList<PayItemModel> PayItems
        {
            set
            {
                _payItems = new List<PayItemModel>();
                _payItems = value;
            }
        }

        /// <summary>
        /// Gets or sets the pay item identifier.
        /// </summary>
        /// <value>
        /// The pay item identifier.
        /// </value>
        public int PayItemId { get; set; }
        /// <summary>
        /// Gets or sets the pay item code.
        /// </summary>
        /// <value>
        /// The pay item code.
        /// </value>
        public string PayItemCode { get; set; }
        /// <summary>
        /// Gets or sets the name of the pay item.
        /// </summary>
        /// <value>
        /// The name of the pay item.
        /// </value>
        public string PayItemName { get; set; }
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public int Type { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [is calculate ratio].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is calculate ratio]; otherwise, <c>false</c>.
        /// </value>
        public bool IsCalculateRatio { get; set; }
        /// <summary>
        /// Gets or sets the is social insurance.
        /// </summary>
        /// <value>
        /// The is social insurance.
        /// </value>
        public bool? IsSocialInsurance { get; set; }
        /// <summary>
        /// Gets or sets the is care insurance.
        /// </summary>
        /// <value>
        /// The is care insurance.
        /// </value>
        public bool? IsCareInsurance { get; set; }
        /// <summary>
        /// Gets or sets the is trade union fee.
        /// </summary>
        /// <value>
        /// The is trade union fee.
        /// </value>
        public bool? IsTradeUnionFee { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the debit account code.
        /// </summary>
        /// <value>
        /// The debit account code.
        /// </value>
        public string DebitAccountCode { get; set; }
        /// <summary>
        /// Gets or sets the credit account code.
        /// </summary>
        /// <value>
        /// The credit account code.
        /// </value>
        public string CreditAccountCode { get; set; }
        /// <summary>
        /// Gets or sets the budget chapter code.
        /// </summary>
        /// <value>
        /// The budget chapter code.
        /// </value>
        public string BudgetChapterCode { get; set; }

        /// <summary>
        /// Gets or sets the balanceside.
        /// </summary>
        /// <value>
        /// The balanceside.
        /// </value>
        public int BalanceSide { get; set; }

        /// <summary>
        /// Gets or sets the concomitant account.
        /// </summary>
        /// <value>
        /// The concomitant account.
        /// </value>
        public string ConcomitantAccount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is allowinputcts].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is allowinputcts]; otherwise, <c>false</c>.
        /// </value>
        public bool IsAllowinputcts { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is system.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is system; otherwise, <c>false</c>.
        /// </value>
        public bool IsSystem { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is project].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is project]; otherwise, <c>false</c>.
        /// </value>
        public bool IsProject { get; set; }

        /// <summary>
        /// Gets or sets the bank identifier.
        /// </summary>
        /// <value>
        /// The bank identifier.
        /// </value>
        public int? BankId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is chapter.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is chapter; otherwise, <c>false</c>.
        /// </value>
        public bool IsChapter { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is budget category.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is budget category; otherwise, <c>false</c>.
        /// </value>
        public bool IsBudgetCategory { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is budget item.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is budget item; otherwise, <c>false</c>.
        /// </value>
        public bool IsBudgetItem { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is budget group.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is budget group; otherwise, <c>false</c>.
        /// </value>
        public bool IsBudgetGroup { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is budget source.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is budget source; otherwise, <c>false</c>.
        /// </value>
        public bool IsBudgetSource { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is activity.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is activity; otherwise, <c>false</c>.
        /// </value>
        public bool IsActivity { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is currency.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is currency; otherwise, <c>false</c>.
        /// </value>
        public bool IsCurrency { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is customer.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is customer; otherwise, <c>false</c>.
        /// </value>
        public bool IsCustomer { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is vendor.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is vendor; otherwise, <c>false</c>.
        /// </value>
        public bool IsVendor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is employee.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is employee; otherwise, <c>false</c>.
        /// </value>
        public bool IsEmployee { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is accounting object.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is accounting object; otherwise, <c>false</c>.
        /// </value>
        public bool IsAccountingObject { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is inventory item.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is inventory item; otherwise, <c>false</c>.
        /// </value>
        public bool IsInventoryItem { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is fixedasset.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is fixedasset; otherwise, <c>false</c>.
        /// </value>
        public bool IsFixedAsset { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is capital allocate.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is capital allocate; otherwise, <c>false</c>.
        /// </value>
        public bool IsCapitalAllocate { get; set; }

        #endregion

        #region DBOption

        /// <summary>
        /// Gets or sets the database options.
        /// </summary>
        /// <value>
        /// The database options.
        /// </value>
        public IList<DBOptionModel> DBOptions
        {
            get
            {
                var dbOptions = new List<DBOptionModel>
                {
                    new DBOptionModel { OptionId = "DBStartDate", OptionValue = ((DateTime)dtStartDate.EditValue).ToShortDateString(), ValueType = 2,
                        Description = "Ngày bắt đầu hạch toán - chọn lúc setup", IsSystem = true },
                    new DBOptionModel { OptionId = "DBDateClosed", OptionValue = "31/12/" + ((DateTime)dtStartDate.EditValue).Year,
                        ValueType = 2, Description = "Ngày cuối cùng của năm tài chính - 31/12/năm posteddate", IsSystem = true },
                    //new DBOptionModel { OptionId = "FiscalMonth", OptionValue = (cboFinancialMonth.SelectedIndex + 1).ToString(CultureInfo.InvariantCulture), 
                    //    ValueType = 1, Description = "Tháng bắt đầu của năm tài chính - chọn lúc setup", IsSystem = true },
                    new DBOptionModel { OptionId = "DBPostedDate", OptionValue = ((DateTime)dtStartDate.EditValue).ToShortDateString(),
                        ValueType = 2, Description = "Ngày hạch toán", IsSystem = false },
                    new DBOptionModel { OptionId = "MainCurrencyID", OptionValue = "VND",
                        ValueType = 0, Description = "Tiền địa phương", IsSystem = true },
                    new DBOptionModel { OptionId = "CompanyCode", OptionValue = txtCompanyCode.Text, ValueType = 0, Description = "Mã số đơn vị",
                        IsSystem = false },
                    new DBOptionModel { OptionId = "CompanyName", OptionValue = txtUnitName.Text, ValueType = 0, Description = "Tên đơn vị", IsSystem = false },
                    new DBOptionModel { OptionId = "CompanyAdrress", OptionValue = txtUnitAddress.Text, ValueType = 0, Description = "Địa chỉ đơn vị", IsSystem = false }
                };
                return dbOptions;
            }
            set
            {
                var dbOptions = value;
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmCreateNewDatabase" /> class.
        /// </summary>
        public FrmConvertDatabase()
        {
            InitializeComponent();
            _dbOptionsPresenter = new DBOptionsPresenter(this);
            //_currencyPresenter = new CurrencyPresenter(this);
            //_accountPresenter = new AccountPresenter(this);
        }

        /// <summary>
        /// Handles the Click event of the btnExit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Handles the Click event of the btnPrevious control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            btnPrevious.Enabled = true;
            if (rExitsDatabase.Checked)
            {
                tabMain.SelectedTabPage = tabMain.TabPages[0];

            }
            else
            {
                tabMain.SelectedTabPage = tabMain.TabPages[tabMain.SelectedTabPage.TabIndex - 1];
            }


            btnNext.Enabled = true;

        }

        /// <summary>
        /// Handles the Click event of the btnNext control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            btnNext.Enabled = true;
            btnPrevious.Enabled = true;

            //valid data


            if (tabMain.SelectedTabPage.Name.Equals("tabTypeOfCreate") && !rExitsDatabase.Checked && !rCreateNewdatabase.Checked)
            {
                XtraMessageBox.Show("Bạn chưa chọn phương thức chuyển đổi !", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (tabMain.SelectedTabPage.Name.Equals("tabTypeOfCreate") && rExitsDatabase.Checked)
            {
                DialogResult dialogResult = XtraMessageBox.Show(
                    "Sau khi thực hiện thao tác này, tất cả các dữ liệu của CSDL hiện tại sẽ bị xóa và thay thế bằng dữ liệu mới!. Bạn có muốn tiếp tục không?",
                    "Cảnh báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    tabMain.SelectedTabPage = tabMain.TabPages[4];
                }
            }
            else
            {
                if (tabMain.SelectedTabPage.Name.Equals("tabSetupDatabase"))
                {
                    if (_server.Databases.Cast<Database>().Any(database => txtDatabaseName.Text.Trim().Equals(database.Name)))
                    {
                        txtDatabaseName.Focus();
                        XtraMessageBox.Show("Cơ sở dữ liệu đã tồn tại trong hệ thống. Vui lòng nhập lại tên cơ sở dữ liệu !", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                tabMain.SelectedTabPage = tabMain.TabPages[tabMain.SelectedTabPage.TabIndex + 1];
            }
        }

        /// <summary>
        /// Handles the SelectedPageChanged event of the tabMain control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraTab.TabPageChangedEventArgs" /> instance containing the event data.</param>
        private void tabMain_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            btnFinish.Enabled = false;
            if (tabMain.SelectedTabPage.Name.Equals("tabFinishSetup"))
            {
                btnNext.Enabled = false;
                btnFinish.Enabled = true;

            }
            if (tabMain.SelectedTabPage.Name.Equals("tabTypeOfCreate"))
                btnPrevious.Enabled = false;
            if (tabMain.SelectedTabPage.Name.Equals("tabSetupDatabase"))
                txtDatabaseName.Focus();
            if (tabMain.SelectedTabPage.Name.Equals("tabInfoCompany"))
                txtCompanyCode.Focus();
            if (tabMain.SelectedTabPage.Name.Equals("tabYearOfAccounting"))
                dtStartDate.Focus();
            //if (tabMain.SelectedTabPage.Name.Equals("tabSetupCurrency"))
            //    cboCurrencyAccounting.Focus();
        }

        private void btnSelectFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                var folderBrowserDialog = new FolderBrowserDialog
                {
                    SelectedPath = AppDomain.CurrentDomain.BaseDirectory + DatabasePath
                };
                if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;
                btnDatabasePath.Text = folderBrowserDialog.SelectedPath;
                System.Windows.Forms.Application.DoEvents();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
            /// Handles the Load event of the FrmCreateNewDatabase control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
            private void FrmConvertDatabase_Load(object sender, EventArgs e)
        {
            try
            {
                txtDatabaseName.EditValue = @"KETOAN_" + DateTime.Now.Year;
                var dataPath = RegistryHelperTransform.GetValueByRegistryKey("DatabasePath");
                btnDatabasePath.EditValue = dataPath.Substring(0, dataPath.LastIndexOf("\\", StringComparison.Ordinal));
                memoDescription.EditValue = @"Cơ sở dữ liệu kế toán cho các cơ quan đại diện";
                dtStartDate.EditValue = DateTime.Parse("01/01/" + DateTime.Now.Year);
                LoadServerConnection();


                SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
                DataTable dtDatabaseSources = instance.GetDataSources();

                int i = 0;
                foreach (DataRow dr in dtDatabaseSources.Rows)
                {
                    var obj = new SourceServer();
                    i = i + 1;
                    obj.Id = i;
                    obj.ServerName = dr["ServerName"].ToString();
                    obj.InstanceName = dr["InstanceName"].ToString();
                    obj.ConnectString = obj.ServerName + @"\" + obj.InstanceName;
                    lstSource.Add(obj);
                }
                cbSelectServer.DataSource = lstSource;

                cbSelectServer.DisplayMember = "ConnectString";
                cbSelectServer.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        /// <summary>
        /// Handles the ButtonClick event of the btnOldDatabasePath control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraEditors.Controls.ButtonPressedEventArgs"/> instance containing the event data.</param>

        /// <summary>
        /// Handles the Click event of the btnFinish control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView1.Nodes.Count > 0)
                {

                    Cursor = Cursors.WaitCursor;

                    lstCheck.Clear();
                    foreach (TreeNode node in treeView1.Nodes)
                    {
                        GetCheckNode(node);
                    }


                    progressBar1.Visible = true;
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = lstCheck.Count;
                    int i = 0;
                    var restore = new Restore
                    {
                        Action = RestoreActionType.Database,
                        Database = txtDatabaseName.Text.Trim(),
                        ReplaceDatabase = true,
                        ContinueAfterError = true
                    };

                    if (!System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + DatabaseTemplatePath))
                    {
                        XtraMessageBox.Show("Đường dẫn cơ sở dữ liệu mẫu không tồn tại", "Thông báo lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    var backupDeviceItem =
                        new BackupDeviceItem(AppDomain.CurrentDomain.BaseDirectory + DatabaseTemplatePath,
                            DeviceType.File);
                    restore.Devices.Add(backupDeviceItem);
                    var fileList = restore.ReadFileList(_server);

                    restore.RelocateFiles.Add(new RelocateFile(fileList.Rows[0][0].ToString().Trim(),
                        btnDatabasePath.Text + @"\" + txtDatabaseName.Text.Trim() + ".mdf"));
                    restore.RelocateFiles.Add(new RelocateFile(fileList.Rows[1][0].ToString().Trim(),
                        btnDatabasePath.Text + @"\" + txtDatabaseName.Text.Trim() + "_log.ldf"));

                    restore.SqlRestore(_server);
                    var database = _server.Databases[txtDatabaseName.Text.Trim()];
                    if (database != null)
                        database.SetOnline();



                    //update options
                    var message = _dbOptionsPresenter.Save();
                    if (message != null)
                    {
                        XtraMessageBox.Show(message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        progressBar1.Value = i;
                    }

                    //set connect string cho khởi tạo db mới hoặc db đang sử dụng

                   
                    //xu ly password
                    var password = RegistryHelperTransform.GetValueByRegistryKey("Password");
                    if (!string.IsNullOrEmpty(password)) password = Crypto.Decrypting(password, "@bgt1me");
                   if (isNewDB)
                    {

                        //add new connection string
                        var dataProvider = ConfigurationManager.AppSettings.Get("ConnectionStringName");
                        var appConfig =
                            ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
                        var connectionString = string.Format(
                            "Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}",
                            RegistryHelper.GetValueByRegistryKey("InstanceName"),
                            txtDatabaseName.Text.Trim(),
                            RegistryHelper.GetValueByRegistryKey("UserName"),
                            password);
                        if (appConfig.ConnectionStrings.ConnectionStrings[dataProvider] == null) //AnhNT: Thêm điều kiện check nếu chưa tồn tại connection thì mới add
                        {
                            appConfig.ConnectionStrings.ConnectionStrings.Add(
                                new ConnectionStringSettings(dataProvider, connectionString));
                        }
                        else//Nếu tồn tại thì modify
                        {
                            appConfig.ConnectionStrings.ConnectionStrings[dataProvider].ConnectionString =
                                connectionString;
                        }
                        appConfig.Save(ConfigurationSaveMode.Full);
                        ConfigurationManager.RefreshSection("connectionStrings");
                    }



                    //chuyển đổi dữ liệu
                    string connectString = BuildConnectionString(cbSelectServer.Text, cboSelectSourceDB.Text);
                    foreach (var check in lstCheck)
                    {
                        
                        var result = model.ConvertDB(connectString,check.Name.Substring(4));

                        if (result == null)
                        {
                            i = i + 1;
                            progressBar1.Value = i;
                            _result = true;
                        }
                        else
                        {
                            _result = false;

                            XtraMessageBox.Show(check.Text +":"+ result, "Thông báo ",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);       
                        }

                    }
                }

                if (_result == false)
                {
                    var databaseForDelete =
                        GlobalVariable.Server.Databases[txtDatabaseName.Text.Trim()];

                    databaseForDelete.Drop();


                }
                else
                {
                    DialogResult dialogResult = new DialogResult();
                    if (isNewDB)
                    {
                        dialogResult = XtraMessageBox.Show(
                            "Chuyển đổi cơ sở dữ liệu thành công!Bạn có muốn sử dụng cơ sở dữ liệu đã chuyển đổi",
                            "Thông báo ",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        Cursor = Cursors.Default;
                    }
                    else
                    {
                        dialogResult = XtraMessageBox.Show(
                            "Chuyển đổi cơ sở dữ liệu thành công!",
                            "Thông báo ",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cursor = Cursors.Default;

                    }
                    if (dialogResult == DialogResult.Yes)
                    {
                        ////update registry
                        RegistryHelperTransform.RemoveConnectionString();
                        RegistryHelperTransform.SetValueForRegistry("DatabaseName", txtDatabaseName.Text);
                        var dbPathLenght = btnDatabasePath.Text.LastIndexOf(@"\", StringComparison.Ordinal);
                        var dbPath = btnDatabasePath.Text;
                        if (dbPathLenght == -1)
                            dbPath = dbPath + @"\";
                        RegistryHelperTransform.SetValueForRegistry("DatabasePath", dbPath);
                        RegistryHelperTransform.SaveConfigFile();
                        System.Windows.Forms.Application.Restart();
                    }
                    else
                    {
                        if (isNewDB)
                        {
                            var dataProvider = ConfigurationManager.AppSettings.Get("ConnectionStringName");
                            var appConfig =
                                ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
                            //xu ly password
                            var password = RegistryHelperTransform.GetValueByRegistryKey("Password");
                            if (!string.IsNullOrEmpty(password)) password = Crypto.Decrypting(password, "@bgt1me");
                            var connectionString = string.Format(
                                "Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}",
                                RegistryHelperTransform.GetValueByRegistryKey("InstanceName"),
                                RegistryHelperTransform.GetValueByRegistryKey("DatabaseName"),
                                RegistryHelperTransform.GetValueByRegistryKey("UserName"),
                                password);
                            appConfig.ConnectionStrings.ConnectionStrings[dataProvider].ConnectionString =
                                connectionString;
                            appConfig.Save(ConfigurationSaveMode.Full);
                            ConfigurationManager.RefreshSection("connectionStrings");
                        }
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.ToString(),
                    "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

     
        #endregion

        #region Functions

        /// <summary>
        /// Loads the server connection.
        /// </summary>
        private void LoadServerConnection()
        {
            //connection
            _serverConnection = new ServerConnection(RegistryHelperTransform.GetValueByRegistryKey("InstanceName"))
            {
                LoginSecure = false,
                Login = RegistryHelperTransform.GetValueByRegistryKey("UserName"),
                Password = Crypto.Decrypting(RegistryHelperTransform.GetValueByRegistryKey("Password"), "@bgt1me")
            };
            //create server
            _server = new Server(_serverConnection);
        }

        #endregion

        private void btnHelp_Click(object sender, EventArgs e)
        {
            if (!File.Exists("BIGTIME.CHM"))
            {
                XtraMessageBox.Show("Không tìm thấy tệp trợ giúp!", "Lỗi thiếu file", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Help.ShowHelp(this, System.Windows.Forms.Application.StartupPath + @"\BIGTIME.CHM", HelpNavigator.TopicId, Convert.ToString(1090));
        }

        private void cbSelectServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSelectServer.SelectedItem == null) return;
            var source = cbSelectServer.SelectedItem as SourceServer;

            List<string> list = new List<string>();

            //Open connection to the database
            string conString = "Data Source=" + source.ConnectString + "; Integrated Security=True;";

            using (SqlConnection con = new SqlConnection(conString))
            {
                try
                {
                    con.Open();
                }
                catch (Exception exception)
                {
                    XtraMessageBox.Show("Bạn không thể kết nối với cơ sở dữ liệu này ", "");
                    cboSelectSourceDB.DataSource = list;
                    cboSelectSourceDB.Text = "";
                    return;
                }


                // Set up a command with the given query and associate
                // this with the current connection.
                using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases", con))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list.Add(dr[0].ToString());
                        }
                    }
                }
            }
            cboSelectSourceDB.DataSource = list;
        }

        private void cboSelectSourceDB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// check all child node
        /// </summary>
        /// <param name="treeNode"></param>
        /// <param name="nodeChecked"></param>
        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {

                node.Checked = nodeChecked;

                if (node.Nodes.Count > 0)
                {
                    this.CheckAllChildNodes(node, nodeChecked);
                }

                if (nodeChecked)
                {
                    lstCheck.Add(node);
                }
            }
        }

        private void CheckParentNodes(TreeNode treeNode, bool nodeChecked)
        {
            if (nodeChecked == false && treeNode.Parent != null)
            {
                treeNode.Parent.Checked = nodeChecked;

                if (treeNode.Parent.Parent != null)
                {
                    this.CheckParentNodes(treeNode.Parent, nodeChecked);
                }
            }
        }



        //getchecknote
        private void GetCheckNode(TreeNode treeNode)

        {
            if (!lstCheck.Contains(treeNode))
            {
                lstCheck.Add(treeNode);
            }
            foreach (TreeNode node in treeNode.Nodes)
            {             
                    lstCheck.Add(node);
                this.GetCheckNode(node);
            }
        }


        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Checked)
                {
                    this.CheckAllChildNodes(e.Node, e.Node.Checked);
                }
                else
                {
                    this.CheckParentNodes(e.Node, e.Node.Checked);
                }

               

            }
        }

        private string BuildConnectionString(string DataSource, string Database)
        {
            // Build the connection string from the provided datasource and database


            string connString = @"data source=" + DataSource + ";initial catalog=" +
                                Database + ";integrated security=True;MultipleActiveResultSets=True;App=EntityFramework;";

            // Build the MetaData... feel free to copy/paste it from the connection string in the config file.
            EntityConnectionStringBuilder esb = new EntityConnectionStringBuilder();
            esb.Metadata = "res://*/EntityConvertDB.ConvertDB.csdl|res://*/EntityConvertDB.ConvertDB.ssdl|res://*/EntityConvertDB.ConvertDB.msl";
            esb.Provider = "System.Data.SqlClient";
            esb.ProviderConnectionString = connString;

            // Generate the full string and return it
            return esb.ToString();
        }

        private void rCreateNewdatabase_CheckedChanged(object sender, EventArgs e)
        {
            if (rCreateNewdatabase.Checked)
            {
                rExitsDatabase.Checked = false;
                isNewDB = true;
            }
        }

        private void rExitsDatabase_CheckedChanged(object sender, EventArgs e)
        {
            if (rExitsDatabase.Checked)
            {
                rCreateNewdatabase.Checked = false;
                isNewDB = false;
            }

        }

       
    }
}