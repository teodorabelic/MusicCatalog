using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicCatalog.Model;
using MusicCatalog.ModelEnum;
using MusicCatalog.Service;

namespace MusicCatalog.Controller
{
    internal class AdminController
    {
        private AdminService adminService;

        public AdminController()
        {
            adminService = new AdminService();
        }

        public void CreateAdmin(string email, string password, string name, string surname, List<Genre> genreHistory, bool blocked)
        {
            RoleEnum.Role role = RoleEnum.Role.Admin;
            int id = adminService.GenerateId();
            Admin newAdmin = new Admin(id, name, surname, email, password, blocked, genreHistory, role);
            adminService.CreateAdmin(newAdmin);
        }

        public void UpdateAdmin(int id, string email, string password, string name, string surname, List<Genre> genreHistory, bool blocked)
        {
            Admin existingAdmin = adminService.GetAdminById(id);
            if (existingAdmin != null)
            {
                existingAdmin.Email = email;
                existingAdmin.Password = password;
                existingAdmin.Name = name;
                existingAdmin.Surname = surname;
                existingAdmin.GenreHistory = genreHistory;
                existingAdmin.Blocked = blocked;

                adminService.UpdateAdmin(existingAdmin);
                
            }
            else
            {
                Console.WriteLine("Admin not found.");
            }
        }

        public void DeleteAdmin(int id)
        {
            adminService.DeleteAdmin(id);
        }

        public void GetAllAdmins()
        {
            var admins = adminService.GetAllAdmins();
        }

        public Admin GetAdminById(int id)
        {
            Admin admin = adminService.GetAdminById(id);
            if (admin != null)
            {
                return admin;
            }
            else
            {
                return null;
            }
        }
    }
}

