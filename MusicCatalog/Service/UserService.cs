using MusicCatalog.Model;
using MusicCatalog.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Service
{
    internal class UserService
    {
        private UserRepository userRepository;

        public UserService()
        {
            userRepository = UserRepository.GetInstance();
        }

        public List<User> GetAllUsers()
        {
            return userRepository.GetAll();
        }

        public User GetUserById(int id)
        {
            return userRepository.GetById(id);
        }

        public void CreateUser(string name, string surname, string email, string password, List<Genre> genreHistory)
        {
            User user = new User
            {
                Name = name,
                Surname = surname,
                Email = email,
                Password = password,
                Blocked = false,
                GenreHistory = genreHistory
            };

            userRepository.Create(user);
        }

        public void UpdateUser(int id, string name, string surname, string email, string password, bool blocked, List<Genre> genreHistory)
        {
            User user = new User
            {
                Id = id,
                Name = name,
                Surname = surname,
                Email = email,
                Password = password,
                Blocked = blocked,
                GenreHistory = genreHistory
            };

            userRepository.Update(user);
        }

        public void DeleteUser(int id)
        {
            userRepository.Delete(id);
        }

        public void BlockUser(int id)
        {
            User user = userRepository.GetById(id);
            if (user != null)
            {
                user.Blocked = true;
                userRepository.Update(user);
            }
        }

        public void UnblockUser(int id)
        {
            User user = userRepository.GetById(id);
            if (user != null)
            {
                user.Blocked = false;
                userRepository.Update(user);
            }
        }
    }
}
