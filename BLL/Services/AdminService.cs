using BLL.DTO;
using DA.Models;
using DA.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AdminService
    {
        public static int Login(string email, string password)
        {
            return AdminRepo.Login(email, password);
        }
        public static bool AddAdmin(AdminDTO admin)
        {
            var data = Convert(admin);
            return AdminRepo.AddAdmin(data);
        }
        public static bool DeleteAdmin(int id)
        {
            return AdminRepo.DeleteAdmin(id);
        }
        public static AdminDTO GetAdmin(int id)
        {
            var data = AdminRepo.GetAdmin(id);
            if (data != null)
                return Convert(data);
            return null;
        }
        public static List<AdminDTO> GetAdmins()
        {
            var data = AdminRepo.GetAdmins();
            if (data != null)
                return Convert(data);
            return null;
        }
        public static bool UpdateAdmin(AdminDTO admin)
        {
            return true;
        }

        //convert 
        public static AdminDTO Convert(Admin admin)
        {
            return new AdminDTO()
            {
                Id= admin.Id,
                Name = admin.Name,
                Email = admin.Email,
                Password = admin.Password,
                Phone = admin.Phone
            };
        }
        public static Admin Convert(AdminDTO admin)
        {
            return new Admin()
            {
                Id= admin.Id,
                Name = admin.Name,
                Email = admin.Email,
                Password = admin.Password,
                Phone = admin.Phone
            };
        }
        static List<AdminDTO> Convert(List<Admin> admin)
        {
            return admin.Select(x => Convert(x)).ToList();
        }
    }
}
