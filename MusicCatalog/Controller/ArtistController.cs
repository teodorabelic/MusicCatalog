using MusicCatalog.Model;
using MusicCatalog.Service;
using System;
using System.Collections.Generic;

namespace MusicCatalog.Controller
{
    internal class ArtistController
    {
        private ArtistService artistService;

        public ArtistController(string artistFilePath, string soloFilePath, string bandFilePath, string workerFilePath)
        {
            artistService = ArtistService.GetInstance(artistFilePath, soloFilePath, bandFilePath, workerFilePath);
        }

        public List<Artist> GetAll()
        {
            return artistService.GetAll();
        }

        public Artist GetById(int id)
        {
            return artistService.GetById(id);
        }

        public List<Artist> Create(Artist artist)
        {
            return artistService.Create(artist);
        }

        public void Update(Artist artist)
        {
            artistService.Update(artist);
        }

        public void Delete(int id)
        {
            artistService.Delete(id);
        }

        public List<Artist> LoadFromFile()
        {
            return artistService.LoadFromFile();
        }
    }
}
