using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using BusinessLayer;
namespace BusinessLayer
{
    public class SYS_USER
    {
        Entities db;
     
        public SYS_USER()
        {
            db = Entities.CreateEntities();
        }

        public bool checkUserExist_admin( string name)
        {
            var us = db.tb_Admin.FirstOrDefault(x => x.USERNAM == name);
        
            if (us != null)
            {
                return true;
            }
            else return false;
        }
        public List<tb_SYS_USER> getAll()
        {
            return db.tb_SYS_USER.ToList();
        }
        public tb_SYS_USER getItem(int idUser)
        {
            return db.tb_SYS_USER.FirstOrDefault(x => x.IDUSER == idUser);
        }
        public tb_SYS_USER getItem(string usernam,string macty,string madvi)
       
        {
            return db.tb_SYS_USER.FirstOrDefault(x => x.DISABLED == false&&x.MACTY==macty&&x.MADVI==madvi&&x.USERNAME==usernam);
        }
        public List<tb_SYS_USER> getUserByDVI(string macty,string madvi)
        {
            return db.tb_SYS_USER.Where(x=>x.MACTY==macty&&x.MADVI==madvi).ToList();
        }
        Double Strcmp(string s1, string s2)
        {
            int i;            
            int Min =s1.Length <s2.Length ? s1.Length : s2.Length;
            for (i = 0; i < Min; i++)
            {
                if (s1[i] < s2[i])
                {
                    return -1;
                }
                else if (s1[i] > s2[i])
                {
                    return 1;
                }
            }
            if (s1[i] == '\0')
            {
                if (s2[i] == '\0')
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            if (s2[i] == '\0')
            {
                if (s1[i] == '\0')
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            return 0;
        }
       
        public List<tb_SYS_USER> getUserByDVIFunc(string macty, string madvi)
        {
            return db.tb_SYS_USER.Where(x => x.MACTY == macty && x.MADVI == madvi&&x.DISABLED==false).OrderByDescending(x=>x.ISGROUP).ToList();
        }
        public bool checkUserExist(string macty,string madvi,string username)
        {
            var us = db.tb_SYS_USER.FirstOrDefault(x => x.MACTY == macty && x.MADVI == madvi &&x.USERNAME==username);
            if (us != null)
            {
                return true;
            }
            else return false;
        }
        public tb_SYS_USER add(tb_SYS_USER us)
        {
            try
            {
                db.tb_SYS_USER.Add(us);
                db.SaveChanges();
                return us;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi:" +ex.Message);
            }
        }
        public tb_SYS_USER update(tb_SYS_USER us)
        {
            var _us = db.tb_SYS_USER.FirstOrDefault(x => x.IDUSER == us.IDUSER);
            _us.USERNAME = us.USERNAME;
            _us.FULLNAME = us.FULLNAME;
            _us.ISGROUP = us.ISGROUP;
            _us.IDUSER = us.IDUSER;
            _us.MACTY = us.MACTY;
            _us.MADVI = us.MADVI;
            _us.PASSWD = us.PASSWD;

            _us.LAST_PWD_CHANGED = DateTime.Now;
            try
            {
                
                db.SaveChanges();
                return us;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi:" + ex.Message);
            }
        }
        public void delete (int iduser)
        {
            tb_SYS_USER _us = db.tb_SYS_USER.FirstOrDefault(x => x.IDUSER == iduser);
            try
            {
                db.tb_SYS_USER.Remove(_us);
                db.SaveChanges();              
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi:" + ex.Message);
            }
        }
    }
}
