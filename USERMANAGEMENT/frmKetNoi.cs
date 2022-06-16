using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer;
using BusinessLayer;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace USERMANAGEMENT
{
    public partial class frmKetNoi : DevExpress.XtraEditors.XtraForm
    {
        public frmKetNoi()
        {
            InitializeComponent();
        }

        private void frmKetNoi_Load(object sender, EventArgs e)
        {
           
        }
        private SqlConnection GetCon(string server, string username, string pass, string database)
        {
            return new SqlConnection("Data Source=" + server + "; Initial Catalog=" + database + "; User ID=" + username + "; Password=" + pass + ";");
        }
        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            SqlConnection con = GetCon(txtServer.Text, txtUsername.Text, txtPassword.Text, cboDatabase.Text);
            try
            {
                con.Open();
                MessageBox.Show("Kết nối thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Kết nối thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDocfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Chọn tập tin";
            op.Filter = "Text Filse (*.dba)|*.dba|AllFiles(*.*)|*.*";
            if (op.ShowDialog() == DialogResult.OK)
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = File.Open(op.FileName, FileMode.Open, FileAccess.Read);
                connect con = (connect)bf.Deserialize(fs); ;
                string srv = Encryptor.Decrypt(con.servername, "qwertyuiop@", true);
                string us = Encryptor.Decrypt(con.username, "qwertyuiop@", true);
                string pa = Encryptor.Decrypt(con.passwd, "qwertyuiop@", true);
                string db = Encryptor.Decrypt(con.database, "qwertyuiop@", true);
                txtServer.Text = srv;
                txtUsername.Text = us;
                txtPassword.Text = pa;
                cboDatabase.Text = db;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string enCryptServ = Encryptor.Encrypt(txtServer.Text, "qwertyuiop@", true);
            string enCryptPass = Encryptor.Encrypt(txtPassword.Text, "qwertyuiop@", true);
            string enCryptData = Encryptor.Encrypt(cboDatabase.Text, "qwertyuiop@", true);
            string enCryptUser = Encryptor.Encrypt(txtUsername.Text, "qwertyuiop@", true);
            //SaveFileDialog sf = new SaveFileDialog();
            //sf.Title = "Chọn nơi lưu trữ";
            //sf.Filter = "Text Filse (*.dba)|*.dba|AllFiles(*.*)|*.*";
            //if(sf.ShowDialog()==DialogResult.OK)
            //{
            //    connect cn = new connect(enCryptServ, enCryptUser, enCryptPass, enCryptData);
            //    cn.SaveFile(sf.FileName);
            //    MessageBox.Show("Lưu file thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            connect cn = new connect(enCryptServ, enCryptUser, enCryptPass, enCryptData);
            cn.SaveFile();
            MessageBox.Show("Lưu file thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cboDatabase_MouseClick(object sender, MouseEventArgs e)
        {
            cboDatabase.Items.Clear();
            try
            {
                string Conn = "server=" + txtServer.Text + ";User Id=" + txtUsername.Text + ";pwd=" + txtPassword.Text + ";";
                SqlConnection con = new SqlConnection(Conn);
                con.Open();
                string sql = "select name from sys.databases WHERE name NOT IN ('master', 'tempdb', 'model', 'msdb')";
                SqlCommand cmd = new SqlCommand(sql, con);
                IDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cboDatabase.Items.Add(dr[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi : " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}