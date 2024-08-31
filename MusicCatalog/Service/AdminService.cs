using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicCatalog.Model;
using MusicCatalog.Repository;

namespace MusicCatalog.Service
{
    internal class AdminService
    {
        private AdminRepository adminRepository;

        public AdminService()
        {
            adminRepository = AdminRepository.GetInstance();
        }

        public List<Admin> GetAllAdmins()
        {
            return adminRepository.GetAll();
        }

        public Admin GetAdminById(int id)
        {
            return adminRepository.GetById(id);
        }

        public void CreateAdmin(Admin admin)
        {
            adminRepository.Create(admin);
        }

        public void UpdateAdmin(Admin admin)
        {
            adminRepository.Update(admin);
        }

        public void DeleteAdmin(int id)
        {
            adminRepository.Delete(id);
        }
        public int GenerateId()
        {
            int id = adminRepository.GenerateId();
            return id;
        }
    }
}
