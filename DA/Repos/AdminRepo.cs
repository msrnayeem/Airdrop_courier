using DA.Context;
using DA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Repos
{
    public class AdminRepo
    {
        static AirdropContext db;
        static AdminRepo()
        {
            db = new AirdropContext();
        }

        public static bool AddAdmin(Admin admin)
        {
            db.Admins.Add(admin);
            return db.SaveChanges()>0;
        }

        public static bool DeleteAdmin(int id)
        {
            var admin = db.Admins.Find(id);
            db.Admins.Remove(admin);
            return db.SaveChanges() > 0;
        }
        public static Admin GetAdmin(int id)
        {
            return db.Admins.Find(id);
        }
        public static List<Admin> GetAdmins()
        {
            return db.Admins.ToList();
        }

        public static bool UpdateAdmin(Admin admin)
        {
            var oldAdmin = db.Admins.Find(admin.Id);
            oldAdmin.Name = admin.Name;
            oldAdmin.Password = admin.Password;
            oldAdmin.Email = admin.Email;
            return db.SaveChanges() > 0;
        }
        public static int Login(string email, string password)
        {
            var admin = db.Admins.Where(a => a.Email == email && a.Password == password).FirstOrDefault();
            if (admin != null)
                return admin.Id;
            return 0;
        }

    }
}
