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
            string login_status = "n";

            try {
                con.Open();
                string stm = "select * from test1_hr where userid =@Userid AND userpw =@Userpw";
                var cmd = new MySqlCommand(stm, con);

                Console.WriteLine("입력 ID : "+ name.Text);
                Console.WriteLine("입력 PW : "+ password.Text);
                cmd.Parameters.AddWithValue("@Userid", name.Text); // name : username 입력란
                cmd.Parameters.AddWithValue("@Userpw", password.Text); // password : userpw 입력란
                
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    login_status = "y";
                }
                rdr.Close();

                if (login_status.Equals("y"))
                { // 로그인 성공 시
                    Console.WriteLine("로그인 성공");
                    main_form();
                }
                else // 로그인 실패 시
                {
                    Console.WriteLine("로그인 실패");
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        private void main_form() {
            this.Hide();
            main frm = new main();
            frm.ShowDialog();
            this.Close();
        }
    }
}
