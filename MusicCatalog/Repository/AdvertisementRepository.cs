using MusicCatalog.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Repository
{
    internal class AdvertisementRepository
    {
        private static AdvertisementRepository instance = null;
        private List<Advertisement> advertisements;

        private AdvertisementRepository()
        {
            advertisements = LoadFromFile();
        }

        public static AdvertisementRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new AdvertisementRepository();
            }
            return instance;
        }

        public List<Advertisement> GetAll()
        {
            return advertisements;
        }

        public Advertisement GetById(int id)
        {
            return advertisements.ElementAtOrDefault(id);
        }

        public void Save()
        {
            try
            {
                using (StreamWriter file = new StreamWriter("../../../Data/AdvertisementFile.csv", false))
                {
                    foreach (Advertisement ad in advertisements)
                    {
                        file.WriteLine(ad.StringToCsv());
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
            if (id < 0 || id >= advertisements.Count)
            {
                return;
            }
            advertisements.RemoveAt(id);
            Save();
        }

        public void Update(int id, Advertisement advertisement)
        {
            if (id >= 0 && id < advertisements.Count)
            {
                advertisements[id] = advertisement;
                Save();
            }
        }

        public void Create(Advertisement advertisement)
        {
            advertisements.Add(advertisement);
            Save();
        }

        private List<Advertisement> LoadFromFile()
        {
            List<Advertisement> ads = new List<Advertisement>();

            string filename = "../../../Data/AdvertisementFile.csv";

            if (File.Exists(filename))
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] tokens = line.Split('|');
                        if (tokens.Length < 3)
                        {
                            continue;
                        }

                        Advertisement ad = new Advertisement(tokens[0], tokens[1], int.Parse(tokens[2]));
                        ads.Add(ad);
                    }
                }
            }
            return ads;
        }
    }
}
