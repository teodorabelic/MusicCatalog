using MusicCatalog.Model;
using MusicCatalog.Repository;
using System;
using System.Collections.Generic;

namespace MusicCatalog.Service
{
    internal class SoloService
    {
        private static SoloService instance = null;
        private SoloRepository soloRepository;

        // Private constructor to initialize the SoloRepository with a file path
        private SoloService(string soloFilePath)
        {
            soloRepository = new SoloRepository();
        }

        public static SoloService GetInstance(string soloFilePath)
        {
            if (instance == null)
            {
                instance = new SoloService(soloFilePath);
            }
            return instance;
        }

        public Solo GetById(int id)
        {
            return soloRepository.GetById(id);
        }

        public List<Solo> GetAll()
        {
            return soloRepository.GetAll();
        }

        public List<Solo> Create(Solo solo)
        {
            return soloRepository.Create(solo);
        }

        public void Update(Solo solo)
        {
            soloRepository.Update(solo);
        }

        public void Delete(int id)
        {
            soloRepository.Delete(id);
        }

        public List<Solo> LoadFromFile()
        {
            return soloRepository.LoadFromFile();
        }
    }
}
