using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using Buca.TransformData.UserControl;


namespace Buca.TransformData
{
    public partial class FormConvertTool : Form
    {
        public FormConvertTool()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var FormSelectList = new FormSelectList())
            {
                FormSelectList.ShowDialog();
            }
        }

        private void FormConvertTool_Load(object sender, EventArgs e)
        {
            var user =  new UserSelectSourceDatabase{Dock = DockStyle.Fill};
            panelUserControl.Controls.Add(user);
        }
    }
}
