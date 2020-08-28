using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using DevExpress.XtraEditors;


namespace Buca.TransformData.UserControl
{
    public partial class UserSelectSourceDatabase : DevExpress.XtraEditors.XtraUserControl
    {
        public UserSelectSourceDatabase()
        {
            InitializeComponent();
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
        public List<SourceServer> lstSource = new List<SourceServer>();
        private void UserSelectSourceDatabase_Load(object sender, EventArgs e)
        {
         
            //cbSelectServer.SelectedValue =null;
        }


        public class SourceServer
        {
            public string ServerName { get; set; }
            public string InstanceName { get; set; }
            public string ConnectString { get; set; }
            public int Id { get; set; }
        }

        private void cbSelectServer_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void cbSelectServer_SelectedValueChanged(object sender, EventArgs e)
        {

            if (cbSelectServer.SelectedItem == null) return;
            var  source  = cbSelectServer.SelectedItem as SourceServer;

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
                   XtraMessageBox.Show("Bạn không thể kết nối với cơ sở dữ liệu này ","");
                    cboSelectSourceDB.DataSource =list;
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
    }
}
