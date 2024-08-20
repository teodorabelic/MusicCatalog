using MusicCatalog.Model;
using MusicCatalog.Service;
using System;
using System.Collections.Generic;

namespace MusicCatalog.Controller
{
    internal class SoloController
    {
        private SoloService soloService;

        public SoloController(string soloFilePath)
        {
            soloService = SoloService.GetInstance(soloFilePath);
        }

        public List<Solo> GetAll()
        {
            return soloService.GetAll();
        }

        public Solo GetById(int id)
        {
            return soloService.GetById(id);
        }

        public List<Solo> Create(Solo solo)
        {
            return soloService.Create(solo);
        }

        public void Update(Solo solo)
        {
            soloService.Update(solo);
        }

        public void Delete(int id)
        {
            soloService.Delete(id);
        }

        public List<Solo> LoadFromFile()
        {
            return soloService.LoadFromFile();
        }
    }
}
