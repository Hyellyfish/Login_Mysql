using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Login_Mysql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            // SQL 서버 연결
            string cs = "Server=192.168.0.53;port=3306;Database=test_db;Uid=root;Pwd=1111;";
            var con = new MySqlConnection(cs);

            try
            {
                con.Open();
                // name : username 입력란, password : userpw 입력란
                string stm = $"select * from test1_hr where userid ='{name.Text}' AND userpw = '{password.Text}'";

                var cmd = new MySqlCommand(stm, con);
                MySqlDataReader rdr = cmd.ExecuteReader(); // F9키 : break

                if (rdr.HasRows) // boolean
                {
                    main_form();
                }
                else
                {
                    MessageBox.Show("로그인 실패");
                    richTextBox1.AppendText($"로그인 실패(ID: '{name.Text}' / PW: '{password.Text}')\n");
                    richTextBox1.ScrollToCaret();
                    name.Text = "";
                    password.Text = "";
                    //name.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        private void main_form()
        {
            this.Hide();
            main frm = new main();
            frm.ShowDialog();
            this.Close();
        }
    }
}
