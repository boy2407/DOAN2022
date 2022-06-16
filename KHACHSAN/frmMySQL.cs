using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace KHACHSAN
{
    public partial class frmMySQL : DevExpress.XtraEditors.XtraForm
    {
        public frmMySQL()
        {
            InitializeComponent();
        }
        private void frmMySQL_Load(object sender, EventArgs e)
        {
          
        }  
        private MySqlConnection GetCon(string server, string username, string pass, string database)
        {
            return new MySqlConnection("Data Source=" + server + "; Initial Catalog=" + database + "; User ID=" + username + "; Password=" + pass + ";");
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {

            string enCryptServ = Encryptor.Encrypt(txtServer.Text, "nghiadeptraiqua@", true);
            string enCryptPass = Encryptor.Encrypt(txtPassword.Text, "nghiadeptraiqua@", true);
            string enCryptData = Encryptor.Encrypt(cboDatabase.Text, "nghiadeptraiqua@", true);
            string enCryptUser = Encryptor.Encrypt(txtUsername.Text, "nghiadeptraiqua@", true);  
            connect cn = new connect(enCryptServ, enCryptUser, enCryptPass, enCryptData);
            cn.SaveFileMySql();
            MessageBox.Show("Lưu file thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            MySqlConnection con = GetCon(txtServer.Text, txtUsername.Text, txtPassword.Text, cboDatabase.Text);
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
                string srv = Encryptor.Decrypt(con.servername, "nghiadeptraiqua@", true);
                string us = Encryptor.Decrypt(con.username, "nghiadeptraiqua@", true);
                string pa = Encryptor.Decrypt(con.passwd, "nghiadeptraiqua@", true);
                string db = Encryptor.Decrypt(con.database, "nghiadeptraiqua@", true);
                txtServer.Text = srv;
                txtUsername.Text = us;
                txtPassword.Text = pa;
                cboDatabase.Text = db;
            }
        }

        private void cboDatabase_MouseClick(object sender, MouseEventArgs e)
        {
            cboDatabase.Items.Clear();
            try
            {
                string Conn = "server=" + txtServer.Text + ";User Id=" + txtUsername.Text + ";pwd=" + txtPassword.Text + ";";
                MySqlConnection con = new MySqlConnection(Conn);
                con.Open();
                string sql = "SHOW DATABASES;";
                MySqlCommand cmd = new MySqlCommand(sql, con);
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