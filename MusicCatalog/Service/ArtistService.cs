using MusicCatalog.Model;
using MusicCatalog.Repository;
using System;
using System.Collections.Generic;

namespace MusicCatalog.Service
{
    internal class ArtistService
    {
        private static ArtistService instance = null;
        private ArtistRepository artistRepository;
        private SoloRepository soloRepository;
        private BandRepository bandRepository;
        private WorkerRepository workerRepository;

        // Private constructor to initialize repositories with file paths
        private ArtistService(string artistFilePath, string soloFilePath, string bandFilePath, string workerFilePath)
        {
            artistRepository = new ArtistRepository(artistFilePath);
            soloRepository = new SoloRepository(soloFilePath);
            bandRepository = new BandRepository(bandFilePath);
            workerRepository = new WorkerRepository(workerFilePath);
        }

        public static ArtistService GetInstance(
            string artistFilePath,
            string soloFilePath,
            string bandFilePath,
            string workerFilePath)
        {
            if (instance == null)
            {
                instance = new ArtistService(artistFilePath, soloFilePath, bandFilePath, workerFilePath);
            }
            return instance;
        }

        public Artist GetById(int id)
        {
            return artistRepository.GetById(id);
        }

        public List<Artist> GetAll()
        {
            return artistRepository.GetAll();
        }

        public List<Artist> Create(Artist artist)
        {
            return artistRepository.Create(artist);
        }

        public void Update(Artist artist)
        {
            artistRepository.Update(artist);
        }

        public void Delete(int id)
        {
            artistRepository.Delete(id);
        }

        public List<Artist> LoadFromFile()
        {
            return artistRepository.LoadFromFile();
        }

        // Methods specific to Solo, Band, and Worker repositories if needed
        public List<Solo> GetAllSolos()
        {
            return soloRepository.GetAll();
        }

        public List<Band> GetAllBands()
        {
            return bandRepository.GetAll();
        }

        public List<Worker> GetAllWorkers()
        {
            return workerRepository.GetAll();
        }
    }
}
