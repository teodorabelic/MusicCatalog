using MusicCatalog.Model;
using MusicCatalog.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Controller
{
    internal class MusicCatalogAppController
    {
        private MusicCatalogAppService musicCatalogAppService;

        public MusicCatalogAppController()
        {
            musicCatalogAppService = MusicCatalogAppService.GetInstance();
        }

        public List<MusicCatalogApp> GetAll()
        {
            return musicCatalogAppService.GetAll();
        }

        public MusicCatalogApp GetById(int id)
        {
            return musicCatalogAppService.GetById(id);
        }

        public List<MusicCatalogApp> Create(MusicCatalogApp app)
        {
            return musicCatalogAppService.Create(app);
        }

        public void Update(MusicCatalogApp app)
        {
            musicCatalogAppService.Update(app);
        }

        public void Delete(int id)
        {
            musicCatalogAppService.Delete(id);
        }

        public List<MusicCatalogApp> LoadFromFile()
        {
            return musicCatalogAppService.LoadFromFile();
        }
    }
}