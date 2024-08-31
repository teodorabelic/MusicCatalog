using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MusicCatalog.Model;

namespace MusicCatalog.Repository
{
    internal class PerformanceRepository
    {
        private static PerformanceRepository instance = null;
        private List<Performance> performances;

        private PerformanceRepository()
        {
            performances = LoadFromFile();
        }

        public static PerformanceRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new PerformanceRepository();
            }
            return instance;
        }

        public List<Performance> GetAll()
        {
            return performances;
        }

        public Performance GetById(int id)
        {
            return performances.FirstOrDefault(performance => performance.Id == id);
        }

        private int GenerateId()
        {
            return performances.Any() ? performances.Max(performance => performance.Id) + 1 : 1;
        }

        public void Save()
        {
            try
            {
                using (StreamWriter file = new StreamWriter("../../../Data/PerformanceFile.csv", false))
                {
                    foreach (Performance performance in performances)
                    {
                        file.WriteLine(performance.ToCSV());
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
            Performance performance = GetById(id);
            if (performance == null)
            {
                return;
            }
            performances.Remove(performance);
            Save();
        }

        public void Update(Performance performance)
        {
            Performance oldPerformance = GetById(performance.Id);

            if (oldPerformance != null)
            {
                oldPerformance.Title = performance.Title;
                oldPerformance.Lyrics = performance.Lyrics;
                oldPerformance.Picture = performance.Picture;
                oldPerformance.GenreId = performance.GenreId;
                oldPerformance.Format = performance.Format;
                oldPerformance.PublicationDate = performance.PublicationDate;
                Save();
            }
        }

        public List<Performance> Create(Performance performance)
        {
            performance.Id = GenerateId();
            performances.Add(performance);
            Save();
            return performances;
        }

        private List<Performance> LoadFromFile()
        {
            List<Performance> performances = new List<Performance>();
            string filename = "../../../Data/PerformanceFile.csv";

            if (File.Exists(filename))
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] tokens = line.Split('|');
                        if (tokens.Length < 7)
                        {
                            continue;
                        }

                        Performance performance = new Performance(
                            id: int.Parse(tokens[0]),
                            name: tokens[1],
                            artist: tokens[2],
                            lyrics: tokens[3],
                            picture: tokens[4],
                            genreId: int.Parse(tokens[5]),
                            format: tokens[6],
                            publicationDate: DateTime.Parse(tokens[7])
                        );

                        performances.Add(performance);
                    }
                }
            }
            return performances;
        }
    }
}
