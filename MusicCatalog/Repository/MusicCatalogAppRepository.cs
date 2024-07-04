using MusicCatalog.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Repository
{
    internal class MusicCatalogAppRepository
    {
        private static MusicCatalogAppRepository instance = null;
        private List<MusicCatalogApp> musicCatalogApps;

        private MusicCatalogAppRepository()
        {
            musicCatalogApps = LoadFromFile();
        }

        public static MusicCatalogAppRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new MusicCatalogAppRepository();
            }
            return instance;
        }

        public List<MusicCatalogApp> GetAll()
        {
            return musicCatalogApps;
        }

        public MusicCatalogApp GetById(int id)
        {
            foreach (MusicCatalogApp app in musicCatalogApps)
            {
                if (app.Id == id)
                {
                    return app;
                }
            }
            return null;
        }

        private int GenerateId()
        {
            int maxId = 0;
            foreach (MusicCatalogApp app in musicCatalogApps)
            {
                if (app.Id > maxId)
                {
                    maxId = app.Id;
                }
            }
            return maxId + 1;
        }

        public void Save()
        {
            try
            {
                StreamWriter file = new StreamWriter("../../../Data/MusicCatalogAppFile.csv", false);

                foreach (MusicCatalogApp app in musicCatalogApps)
                {
                    file.WriteLine(app.StringToCsv());
                }
                file.Flush();
                file.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public void Delete(int id)
        {
            MusicCatalogApp app = GetById(id);
            if (app == null)
            {
                return;
            }
            musicCatalogApps.Remove(app);
            Save();
        }

        public void Update(MusicCatalogApp app)
        {
            MusicCatalogApp oldApp = GetById(app.Id);

            if (oldApp != null)
            {
                oldApp.Name = app.Name;
                oldApp.SongOfTheYear = app.SongOfTheYear;
                oldApp.AlbumOfTheYear = app.AlbumOfTheYear;
                oldApp.TopArtists = app.TopArtists;
                Save();
            }
        }

        public List<MusicCatalogApp> Create(MusicCatalogApp app)
        {
            app.Id = GenerateId();
            musicCatalogApps.Add(app);
            Save();
            return musicCatalogApps;
        }

        public List<MusicCatalogApp> LoadFromFile()
        {
            List<MusicCatalogApp> musicCatalogApps = new List<MusicCatalogApp>();

            string filename = "../../../Data/MusicCatalogAppFile.csv";

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
                    MusicCatalogApp app = new MusicCatalogApp(
                        id: Int32.Parse(tokens[0]),
                        name: tokens[1],
                        songOfTheYearId: Int32.Parse(tokens[2]),
                        albumOfTheYearId: Int32.Parse(tokens[3]),
                        topArtistsId: tokens[4].Split(',').Select(int.Parse).ToList()
                    );
                    musicCatalogApps.Add(app);
                }
                return musicCatalogApps;
            }
        }
    }
}