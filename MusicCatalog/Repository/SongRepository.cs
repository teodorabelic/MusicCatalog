using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MusicCatalog.Model;

namespace MusicCatalog.Repository
{
    internal class SongRepository
    {
        private static SongRepository instance = null;
        private List<Song> songs;

        private SongRepository()
        {
            songs = LoadFromFile();
        }

        public static SongRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new SongRepository();
            }
            return instance;
        }

        public List<Song> GetAll()
        {
            return songs;
        }

        public Song GetById(int id)
        {
            return songs.FirstOrDefault(song => song.Id == id);
        }

        private int GenerateId()
        {
            return songs.Any() ? songs.Max(song => song.Id) + 1 : 1;
        }

        public void Save()
        {
            try
            {
                using (StreamWriter file = new StreamWriter("../../../Data/SongFile.csv", false))
                {
                    foreach (Song song in songs)
                    {
                        file.WriteLine(song.ToCSV());
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
            Song song = GetById(id);
            if (song == null)
            {
                return;
            }
            songs.Remove(song);
            Save();
        }

        public void Update(Song song)
        {
            Song oldSong = GetById(song.Id);

            if (oldSong != null)
            {
                oldSong.Title = song.Title;
                oldSong.Lyrics = song.Lyrics;
                oldSong.Picture = song.Picture;
                oldSong.GenreId = song.GenreId;
                oldSong.Format = song.Format;
                oldSong.PublicationDate = song.PublicationDate;
                Save();
            }
        }

        public List<Song> Create(Song song)
        {
            song.Id = GenerateId();
            songs.Add(song);
            Save();
            return songs;
        }

        private List<Song> LoadFromFile()
        {
            List<Song> songs = new List<Song>();
            string filename = "../../../Data/SongFile.csv";

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

                        Song song = new Song(
                            id: int.Parse(tokens[0]),
                            name: tokens[1],
                            artist: tokens[2],
                            lyrics: tokens[3],
                            picture: tokens[4],
                            genreId: int.Parse(tokens[5]),
                            format: tokens[6],
                            publicationDate: DateTime.Parse(tokens[7])
                        );

                        songs.Add(song);
                    }
                }
            }
            return songs;
        }
    }
}
