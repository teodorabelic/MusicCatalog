using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicCatalog.Model;
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
            Admin newAdmin = new Admin(0, name, surname, email, password, blocked, genreHistory);
            adminService.CreateAdmin(newAdmin);
            Console.WriteLine("Admin created successfully.");
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
                Console.WriteLine("Admin updated successfully.");
            }
            else
            {
                Console.WriteLine("Admin not found.");
            }
        }

        public void DeleteAdmin(int id)
        {
            adminService.DeleteAdmin(id);
            Console.WriteLine("Admin deleted successfully.");
        }

        public void GetAllAdmins()
        {
            var admins = adminService.GetAllAdmins();
            foreach (var admin in admins)
            {
                Console.WriteLine($"Admin: {admin.Name} {admin.Surname}");
            }
        }

        public void GetAdminById(int id)
        {
            var admin = adminService.GetAdminById(id);
            if (admin != null)
            {
                Console.WriteLine($"Admin found: {admin.Name} {admin.Surname}");
            }
            else
            {
                Console.WriteLine("Admin not found.");
            }
        }
    }
}

