using MusicCatalog.Model;
using MusicCatalog.Repository;
using System;
using System.Collections.Generic;

namespace MusicCatalog.Service
{
    internal class BandService
    {
        private static BandService instance = null;
        private BandRepository bandRepository;

        // Private constructor to initialize the BandRepository with a file path
        private BandService(string bandFilePath)
        {
            bandRepository = new BandRepository(bandFilePath);
        }

        public static BandService GetInstance(string bandFilePath)
        {
            if (instance == null)
            {
                instance = new BandService(bandFilePath);
            }
            return instance;
        }

        public Band GetById(int id)
        {
            return bandRepository.GetById(id);
        }

        public List<Band> GetAll()
        {
            return bandRepository.GetAll();
        }

        public List<Band> Create(Band band)
        {
            return bandRepository.Create(band);
        }

        public void Update(Band band)
        {
            bandRepository.Update(band);
        }

        public void Delete(int id)
        {
            bandRepository.Delete(id);
        }

        public List<Band> LoadFromFile()
        {
            return bandRepository.LoadFromFile();
        }
    }
}
