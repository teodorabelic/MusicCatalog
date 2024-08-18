using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MusicCatalog.Model;

namespace MusicCatalog.Repository
{
    internal class AlbumRepository
    {
        private static AlbumRepository instance = null;
        private List<Album> albums;

        private AlbumRepository()
        {
            albums = LoadFromFile();
        }

        public static AlbumRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new AlbumRepository();
            }
            return instance;
        }

        public List<Album> GetAll()
        {
            return albums;
        }

        public Album GetById(int id)
        {
            return albums.FirstOrDefault(album => album.Id == id);
        }

        private int GenerateId()
        {
            return albums.Any() ? albums.Max(album => album.Id) + 1 : 1;
        }

        public void Save()
        {
            try
            {
                using (StreamWriter file = new StreamWriter("../../../Data/AlbumFile.csv", false))
                {
                    foreach (Album album in albums)
                    {
                        file.WriteLine(album.ToCSV());
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
            Album album = GetById(id);
            if (album == null)
            {
                return;
            }
            albums.Remove(album);
            Save();
        }

        public void Update(Album album)
        {
            Album oldAlbum = GetById(album.Id);

            if (oldAlbum != null)
            {
                oldAlbum.Name = album.Name;
                oldAlbum.Text = album.Text;
                oldAlbum.Picture = album.Picture;
                oldAlbum.GenreId = album.GenreId;
                oldAlbum.Format = album.Format;
                oldAlbum.PublicationDate = album.PublicationDate;
                Save();
            }
        }

        public List<Album> Create(Album album)
        {
            album.Id = GenerateId();
            albums.Add(album);
            Save();
            return albums;
        }

        private List<Album> LoadFromFile()
        {
            List<Album> albums = new List<Album>();
            string filename = "../../../Data/AlbumFile.csv";

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

                        Album album = new Album(
                            id: int.Parse(tokens[0]),
                            name: tokens[1],
                            text: tokens[2],
                            picture: tokens[3],
                            genreId: int.Parse(tokens[4]),
                            format: tokens[5],
                            publicationDate: DateTime.Parse(tokens[6])
                        );

                        albums.Add(album);
                    }
                }
            }
            return albums;
        }
    }
}
