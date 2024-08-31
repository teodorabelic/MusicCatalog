using MusicCatalog.Model;
using MusicCatalog.ModelEnum;
using MusicCatalog.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Service
{
    public class UserService
    {
        private UserRepository userRepository;
        private List<User> users;

        public UserService()
        {
            userRepository = UserRepository.GetInstance();
            this.users = userRepository.GetAll();
        }

        public List<User> GetAllUsers()
        {
            return userRepository.GetAll();
        }

        public User GetUserById(int id)
        {
            return userRepository.GetById(id);
        }

        public void CreateUser(string name, string surname, string email, string password, List<Genre> genreHistory, RoleEnum.Role role)
        {
            User user = new User
            {
                Name = name,
                Surname = surname,
                Email = email,
                Password = password,
                Blocked = false,
                GenreHistory = genreHistory,
                Role = role
            };

            userRepository.Create(user);
        }

        public void UpdateUser(int id, string name, string surname, string email, string password, bool blocked, List<Genre> genreHistory, RoleEnum.Role role)
        {
            User user = new User
            {
                Id = id,
                Name = name,
                Surname = surname,
                Email = email,
                Password = password,
                Blocked = blocked,
                GenreHistory = genreHistory,
                Role = role
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

        public (object, string) IsLoggedIn(string email, string password)
        {

            foreach (User user in users)
            {
                if (user.Email == email && user.Password == password)
                {
                    return (user, user.Role.ToString());
                }
            }

            return (null, "");
        }

       
    }
}
