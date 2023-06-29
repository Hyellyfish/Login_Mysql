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
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader rdr;
        Class1 clscon = new Class1();

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
            con = new MySqlConnection(clscon.dbconnect());
            try
            {
                con.Open();
                // name : username 입력란, password : userpw 입력란
                string stm = $"select * from test1_hr where userid ='{name.Text}' AND userpw = '{password.Text}'";
                cmd = new MySqlCommand(stm, con);
                rdr = cmd.ExecuteReader(); // F9키 : break

                if (rdr.HasRows) // boolean
                {
                    info_form(); // 리스트 페이지로 이동
                }
                else
                {
                    MessageBox.Show("로그인에 실패하였습니다.", "로그인 실패", 
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void info_form()
        {
            this.Hide();
            Info_list list_form = new Info_list();
            list_form.ShowDialog();
            this.Close();
        }
    }
}
