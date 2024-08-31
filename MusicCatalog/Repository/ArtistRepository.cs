using MusicCatalog.Model;
using MusicCatalog.ModelEnum;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Repository
{
    public class ArtistRepository
    {
        private static ArtistRepository instance = null;
        private List<Artist> artists;
        private readonly string filePath;

        public ArtistRepository(string filePath)
        {
            this.filePath = filePath;
            artists = LoadFromFile();
        }

        public static ArtistRepository GetInstance(string filePath)
        {
            if (instance == null)
            {
                instance = new ArtistRepository(filePath);
            }
            return instance;
        }

        public List<Artist> GetAll()
        {
            return artists;
        }

        public Artist GetById(int id)
        {
            foreach (Artist artist in artists)
            {
                if (artist.Id == id)
                {
                    return artist;
                }
            }
            return null;
        }

        private int GenerateId()
        {
            int maxId = 0;
            foreach (Artist artist in artists)
            {
                if (artist.Id > maxId)
                {
                    maxId = artist.Id;
                }
            }
            return maxId + 1;
        }

        public void Save()
        {
            try
            {
                StreamWriter file = new StreamWriter(filePath, false);

                foreach (Artist artist in artists)
                {
                    file.WriteLine(artist.StringToCsv());
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
            Artist artist = GetById(id);
            if (artist == null)
            {
                return;
            }
            artists.Remove(artist);
            Save();
        }

        public void Update(Artist artist)
        {
            Artist oldArtist = GetById(artist.Id);

            if (oldArtist != null)
            {
                oldArtist.Name = artist.Name;
                oldArtist.Participants = artist.Participants;
                oldArtist.StartDate = artist.StartDate;
                oldArtist.Profession = artist.Profession;
                oldArtist.Biography = artist.Biography;
                oldArtist.Picture = artist.Picture;
                Save();
            }
        }

        public List<Artist> Create(Artist artist)
        {
            artist.Id = GenerateId();
            artists.Add(artist);
            Save();
            return artists;
        }

        public List<Artist> LoadFromFile()
        {
            List<Artist> artists = new List<Artist>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] tokens = line.Split('|');

                    if (tokens.Length < 7)
                    {
                        continue;
                    }
                    Artist artist = new Artist(
                        id: Int32.Parse(tokens[0]),
                        name: tokens[1],
                        participants: StringToList(tokens[2]),
                        startDate: DateTime.Parse(tokens[3]),
                        profession: (ProfessionEnum.Profession)Enum.Parse(typeof(ProfessionEnum.Profession), tokens[4]),
                        biography: tokens[5],
                        picture: tokens[6]
                    );
                    artists.Add(artist);
                }
                return artists;
            }
        }

        private List<int> StringToList(string data)
        {
            List<int> dataList = new List<int>();
            string[] tokens = data.Split(',');

            foreach (string token in tokens)
            {
                string trimmedToken = token.Trim();

                if (int.TryParse(trimmedToken, out int value))
                {
                    dataList.Add(value);
                }
                else
                {
                    Console.WriteLine($"Failed to parse: {trimmedToken}");
                }
            }

            return dataList;
        }

    }
}
