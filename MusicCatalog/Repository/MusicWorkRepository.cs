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
                oldWork.Name = work.Name;
                oldWork.Text = work.Text;
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
                        if (tokens.Length < 7)
                        {
                            continue;
                        }

                        MusicWork work = new MusicWork(
                            id: int.Parse(tokens[0]),
                            name: tokens[1],
                            text: tokens[2],
                            picture: tokens[3],
                            genreId: int.Parse(tokens[4]),
                            format: tokens[5],
                            publicationDate: DateTime.Parse(tokens[6])
                        );

                        works.Add(work);
                    }
                }
            }
            return works;
        }
    }
}
