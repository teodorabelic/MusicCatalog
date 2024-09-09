using MusicCatalog.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Repository
{
    internal class UserRepository
    {
        private static UserRepository instance = null;
        private List<User> users;

        private UserRepository()
        {
            users = LoadFromFile();
        }

        public static UserRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new UserRepository();
            }
            return instance;
        }

        public List<User> GetAll()
        {
            return users;
        }

        public User GetById(int id)
        {
            return users.FirstOrDefault(user => user.Id == id);
        }

        public int GenerateId()
        {
            return users.Any() ? users.Max(user => user.Id) + 1 : 1;
        }

        public void Save()
        {
            try
            {
                using (StreamWriter file = new StreamWriter("../../../Data/UserFile.csv", false))
                {
                    foreach (User user in users)
                    {
                        file.WriteLine(user.StringToCsv());
                    }
                    file.Flush();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public void Delete(int id)
        {
            User user = GetById(id);
            if (user == null)
            {
                return;
            }
            users.Remove(user);
            Save();
        }

        public void Update(User user)
        {
            User oldUser = GetById(user.Id);

            if (oldUser != null)
            {
                oldUser.Name = user.Name;
                oldUser.Surname = user.Surname;
                oldUser.Email = user.Email;
                oldUser.Password = user.Password;
                oldUser.Blocked = user.Blocked;
                oldUser.GenreHistory = user.GenreHistory;
                oldUser.Role = user.Role;
                Save();
            }
        }

        public List<User> Create(User user)
        {
            //user.Id = GenerateId();
            users.Add(user);
            Save();
            return users;
        }

        public List<User> LoadFromFile()
        {
            List<User> users = new List<User>();

            string filename = "../../../Data/UserFile.csv";

            if (File.Exists(filename))
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] tokens = line.Split('|');

                        if (tokens.Length < 8)
                        {
                            continue;
                        }

                        List<Genre> genreHistory = new List<Genre>();
                        string[] genreTokens = tokens[6].Split(',');
                        foreach (var genreToken in genreTokens)
                        {
                            string[] genreData = genreToken.Split('-');
                            if (genreData.Length == 2 && int.TryParse(genreData[0], out int genreId))
                            {
                                genreHistory.Add(new Genre(genreId, genreData[1]));
                            }
                        }

                        User user = new User(
                            id: Int32.Parse(tokens[0]),
                            name: tokens[1],
                            surname: tokens[2],
                            email: tokens[3],
                            password: tokens[4],
                            blocked: Boolean.Parse(tokens[5]),
                            genreHistory: genreHistory,
                            role: (ModelEnum.RoleEnum.Role)Enum.Parse(typeof(ModelEnum.RoleEnum.Role), tokens[7]));
                        users.Add(user);
                    }
                }
            }
            return users;
        }
    }
}
