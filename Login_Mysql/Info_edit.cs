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
    public partial class Info_edit : Form
    {
        MySqlConnection con;
        MySqlCommand cmd;
        Class1 clscon = new Class1();

        public Info_edit()
        {
            InitializeComponent();
            con = new MySqlConnection(clscon.dbconnect());
        }

        private void pb_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void Clear() {
            tb_eid.Clear();
            tb_lname.Clear();
            tb_fname.Clear();
            tb_mname.Clear();
            tp_bdate.Value = DateTime.Now;
            cb_gender.Text = ""; //ComboBox는 Clear() 사용 불가
            tb_address.Clear();
            tb_cno.Clear();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if ((tb_eid.Text.Equals("")) || (tb_address.Text.Equals("")) ||
                     (tb_cno.Text.Equals("")) || (tb_fname.Text.Equals("")) ||
                     (tb_lname.Text.Equals("")) || (tb_mname.Text.Equals("")))
                {
                    MessageBox.Show("빈 칸을 입력하세요!", "알림",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                con.Open();

                string bdate = tp_bdate.Value.ToString("yyyy-MM-dd");
                string stm = $"insert into tblemployee_hr(eid, lname, fname, mname, bdate, gender, address, cno) " +
                                $"values ('{tb_eid.Text}', '{tb_lname.Text}', '{tb_fname.Text}', '{tb_mname.Text}', " +
                                $"          '{bdate}', '{cb_gender.Text}', '{tb_address.Text}', '{tb_cno.Text}')";
                cmd = new MySqlCommand(stm, con);

                int count = cmd.ExecuteNonQuery(); // int 값 리턴
                if (count > 0)
                {
                    MessageBox.Show("등록되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("등록에 실패하였습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally {
                con.Close();
            }
        }
    }
}
