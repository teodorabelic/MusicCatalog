using MusicCatalog.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Repository
{
    internal class MusicWorkRepository
    {
        private static MusicWorkRepository instance = null;
        private List<MusicWork> musicWorks;

        private MusicWorkRepository()
        {
            musicWorks = LoadFromFile();
            Console.WriteLine($"Loaded {musicWorks.Count} music works.");
        }

        public static MusicWorkRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new MusicWorkRepository();
            }
            return instance;
        }

        public List<MusicWork> GetAll()
        {
            return musicWorks;
        }

        public MusicWork GetById(int id)
        {
            return musicWorks.FirstOrDefault(work => work.Id == id);
        }

        private int GenerateId()
        {
            return musicWorks.Any() ? musicWorks.Max(work => work.Id) + 1 : 1;
        }

        public void Save()
        {
            try
            {
                using (StreamWriter file = new StreamWriter("../../../Data/MusicWorkFile.csv", false))
                {
                    foreach (MusicWork work in musicWorks)
                    {
                        file.WriteLine(work.StringToCsv());
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
            MusicWork work = GetById(id);
            if (work == null)
            {
                return;
            }
            musicWorks.Remove(work);
            Save();
        }

        public void Update(MusicWork work)
        {
            MusicWork oldWork = GetById(work.Id);

            if (oldWork != null)
            {
                oldWork.Title = work.Title;
                oldWork.Lyrics = work.Lyrics;
                oldWork.Picture = work.Picture;
                oldWork.GenreId = work.GenreId;
                oldWork.Format = work.Format;
                oldWork.PublicationDate = work.PublicationDate;
                Save();
            }
        }

        public List<MusicWork> Create(MusicWork work)
        {
            work.Id = GenerateId();
            musicWorks.Add(work);
            Save();
            return musicWorks;
        }

        private List<MusicWork> LoadFromFile()
        {
            List<MusicWork> works = new List<MusicWork>();

            string filename = "../../../Data/MusicWorkFile.csv";

            if (File.Exists(filename))
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] tokens = line.Split('|');
                        if (tokens.Length != 8)
                        {
                            continue;
                        }

                        MusicWork work = new MusicWork(
                            id: int.Parse(tokens[0]),
                            title: tokens[1],
                            artist: tokens[2],
                            lyrics: tokens[3],
                            picture: tokens[4],
                            genreId: int.Parse(tokens[5]),
                            format: tokens[6],
                            publicationDate: DateTime.Parse(tokens[7])
                        );

                        works.Add(work);
                    }
                }
            }
            return works;
        }
        public string GetProjectDirectory()
        {
            string currentDir = AppDomain.CurrentDomain.BaseDirectory;

            string projectDir = System.IO.Path.GetFullPath(System.IO.Path.Combine(currentDir, @"..\..\.."));
            return projectDir;
        }
    }
}
