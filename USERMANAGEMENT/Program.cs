using DataLayer;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using DataLayer;
using KHACHSAN;
namespace USERMANAGEMENT
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmMainAdmin());
            if (File.Exists("connectdb.dba"))
            {
                BinaryFormatter bf = new BinaryFormatter();  // tạo đối tượng chuyển đổi file
                FileStream fs = File.Open("connectdb.dba", FileMode.Open, FileAccess.Read);
                connect cp = (connect)bf.Deserialize(fs);    // đọc kết quả file thu được từ quá trình serialize bên connect.cs
                string servername;
                string username;
                string pass;
                string database;
                string conStr = "";
                try
                {
                    servername = Encryptor.Decrypt(cp.servername, "qwertyuiop@", true);
                    username = Encryptor.Decrypt(cp.username, "qwertyuiop@", true);
                    pass = Encryptor.Decrypt(cp.passwd, "qwertyuiop@", true);
                    database = Encryptor.Decrypt(cp.database, "qwertyuiop@", true);
                    conStr += "Data Source=" + servername + "; Initial Catalog=" + database + "; User ID=" + username + "; Password=" + pass + ";";
                    Friend._srv = servername;
                    Friend._us = username;
                    Friend._pw = pass;
                    Friend._db = database;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("lỗi" + ex.Message);
                }
                SqlConnection con = new SqlConnection(conStr);
                try
                {
                    con.Open();
                    //Application.Run(new frmMain());
                }
                catch
                {
                    MessageBox.Show("không thể kết nối  CSDL", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
                fs.Close();
                Application.Run(new frmLogin_admin());
            }
            else
            {
                Application.Run(new frmKetNoi());
            }


        }
    }
}
