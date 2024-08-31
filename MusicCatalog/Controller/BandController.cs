using MusicCatalog.Model;
using MusicCatalog.Service;
using System;
using System.Collections.Generic;

namespace MusicCatalog.Controller
{
    internal class BandController
    {
        private BandService bandService;

        public BandController(string bandFilePath)
        {
            bandService = BandService.GetInstance(bandFilePath);
        }

        public List<Band> GetAll()
        {
            return bandService.GetAll();
        }

        public Band GetById(int id)
        {
            return bandService.GetById(id);
        }

        public List<Band> Create(Band band)
        {
            return bandService.Create(band);
        }

        public void Update(Band band)
        {
            bandService.Update(band);
        }

        public void Delete(int id)
        {
            bandService.Delete(id);
        }

        public List<Band> LoadFromFile()
        {
            return bandService.LoadFromFile();
        }
    }
}
