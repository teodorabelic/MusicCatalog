using MusicCatalog.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MusicCatalog.Repository
{
    internal class GenreRepository
    {
        private static GenreRepository instance = null;
        private List<Genre> genres;

        private GenreRepository()
        {
            genres = LoadFromFile();
        }

        public static GenreRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new GenreRepository();
            }
            return instance;
        }

        public List<Genre> GetAll()
        {
            return genres;
        }

        public Genre GetById(int id)
        {
            return genres.FirstOrDefault(genre => genre.Id == id);
        }

        private int GenerateId()
        {
            return genres.Any() ? genres.Max(genre => genre.Id) + 1 : 1;
        }

        public void Save()
        {
            try
            {
                using (StreamWriter file = new StreamWriter("../../../Data/GenreFile.csv", false))
                {
                    foreach (Genre genre in genres)
                    {
                        file.WriteLine(genre.StringToCsv());
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
            Genre genre = GetById(id);
            if (genre == null)
            {
                return;
            }
            genres.Remove(genre);
            Save();
        }

        public void Update(Genre genre)
        {
            Genre oldGenre = GetById(genre.Id);

            if (oldGenre != null)
            {
                oldGenre.Type = genre.Type;
                Save();
            }
        }

        public List<Genre> Create(Genre genre)
        {
            genre.Id = GenerateId();
            genres.Add(genre);
            Save();
            return genres;
        }

        private List<Genre> LoadFromFile()
        {
            List<Genre> genres = new List<Genre>();

            string filename = "../../../Data/GenreFile.csv";

            if (File.Exists(filename))
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] tokens = line.Split('|');
                        if (tokens.Length < 2)
                        {
                            continue;
                        }

                        Genre genre = new Genre(
                            id: int.Parse(tokens[0]),
                            type: tokens[1]
                        );

                        genres.Add(genre);
                    }
                }
            }
            return genres;
        }
    }
}
