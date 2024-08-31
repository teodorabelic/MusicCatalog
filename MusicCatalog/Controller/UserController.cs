using MusicCatalog.Model;
using MusicCatalog.ModelEnum;
using MusicCatalog.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Controller
{
    internal class UserController
    {
        private UserService userService;

        public UserController()
        {
            userService = new UserService();
        }

        public List<User> GetAllUsers()
        {
            return userService.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            User user = userService.GetUserById(id);
            if (user == null)
            {
                Console.WriteLine($"User with ID {id} not found.");
            }
            return user;
        }

        public void CreateUser(string name, string surname, string email, string password, List<Genre> genreHistory, RoleEnum.Role role)
        {
            userService.CreateUser(name, surname, email, password, genreHistory, role);
            Console.WriteLine("User successfully created.");
        }

        public void UpdateUser(int id, string name, string surname, string email, string password, bool blocked, List<Genre> genreHistory, RoleEnum.Role role)
        {
            userService.UpdateUser(id, name, surname, email, password, blocked, genreHistory, role);
            Console.WriteLine("User successfully updated.");
        }

        public void DeleteUser(int id)
        {
            userService.DeleteUser(id);
            Console.WriteLine("User successfully deleted.");
        }

        public void BlockUser(int id)
        {
            userService.BlockUser(id);
            Console.WriteLine($"User with ID {id} has been blocked.");
        }

        public void UnblockUser(int id)
        {
            userService.UnblockUser(id);
            Console.WriteLine($"User with ID {id} has been unblocked.");
        }

        public (object, string) IsLoggedIn(string email, string password)
        {
            return userService.IsLoggedIn(email, password);
        }

       
    }
}
