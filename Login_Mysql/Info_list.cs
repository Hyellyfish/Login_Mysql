using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Mysql
{
    public partial class Info_list : Form
    {
        MySqlConnection cn;
        MySqlCommand cmd;
        MySqlDataReader rdr;

        public Info_list()
        {
            InitializeComponent();
        }

        private void Info_list_Load(object sender, EventArgs e)
        {
            //Debug.WriteLine("-----------------------------------------");
            //Debug.WriteLine("-----------------------------------------");
        }

        private void pb_add_Click(object sender, EventArgs e)
        {
            Info_edit edit_form = new Info_edit();
            edit_form.ShowDialog();
        }

        private void pb_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
