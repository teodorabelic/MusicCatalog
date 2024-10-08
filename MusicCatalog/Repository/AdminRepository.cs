﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicCatalog.Model;
using MusicCatalog.ModelEnum;

namespace MusicCatalog.Repository
{
    internal class AdminRepository
    {
        private static AdminRepository instance = null;
        private List<Admin> admins;

        private AdminRepository()
        {
            admins = LoadFromFile();
        }

        public static AdminRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new AdminRepository();
            }
            return instance;
        }

        public List<Admin> GetAll()
        {
            return admins;
        }

        public Admin GetById(int id)
        {
            return admins.FirstOrDefault(admin => admin.Id == id);
        }

        public int GenerateId()
        {
            return admins.Any() ? admins.Max(admin => admin.Id) + 1 : 1;
        }

        public void Save()
        {
            try
            {
                using (StreamWriter file = new StreamWriter("../../../Data/AdminFile.csv", false))
                {
                    foreach (Admin admin in admins)
                    {
                        file.WriteLine(admin.StringToCsv());
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
            Admin admin = GetById(id);
            if (admin == null)
            {
                return;
            }
            admins.Remove(admin);
            Save();
        }

        public void Update(Admin admin)
        {
            Admin oldAdmin = GetById(admin.Id);

            if (oldAdmin != null)
            {
                oldAdmin.Name = admin.Name;
                oldAdmin.Surname = admin.Surname;
                oldAdmin.Email = admin.Email;
                oldAdmin.Password = admin.Password;
                oldAdmin.Blocked = admin.Blocked;
                oldAdmin.GenreHistory = admin.GenreHistory;
                Save();
            }
        }

        public List<Admin> Create(Admin admin)
        {
            admin.Id = GenerateId();
            admins.Add(admin);
            Save();
            return admins;
        }

        private List<Admin> LoadFromFile()
        {
            List<Admin> admins = new List<Admin>();
            string filename = "../../../Data/AdminFile.csv";

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

                        Admin admin = new Admin(
                            id: int.Parse(tokens[0]),  
                            email: tokens[3],
                            password: tokens[4],
                            name: tokens[1],
                            surname: tokens[2],
                            genreHistory: genreHistory,
                            blocked: Boolean.Parse(tokens[5]),
                            role: (RoleEnum.Role)Enum.Parse(typeof(RoleEnum.Role), tokens[7])
                        );
                        admins.Add(admin);
                    }
                }
            }
            return admins;
        }


    }
}

