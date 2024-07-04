using MusicCatalog.Model;
using MusicCatalog.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Service
{
    internal class MusicCatalogAppService
    {
        private static MusicCatalogAppService instance = null;
        private MusicCatalogAppRepository musicCatalogAppRepository;
        private List<MusicCatalogApp> musicCatalogApps;

        private MusicCatalogAppService()
        {
            musicCatalogAppRepository = MusicCatalogAppRepository.GetInstance();
            this.musicCatalogApps = musicCatalogAppRepository.GetAll();
        }

        public static MusicCatalogAppService GetInstance()
        {
            if (instance == null)
            {
                instance = new MusicCatalogAppService();
            }
            return instance;
        }

        public MusicCatalogApp GetById(int id)
        {
            return musicCatalogAppRepository.GetById(id);
        }

        public List<MusicCatalogApp> GetAll()
        {
            return musicCatalogAppRepository.GetAll();
        }

        public List<MusicCatalogApp> Create(MusicCatalogApp app)
        {
            return musicCatalogAppRepository.Create(app);
        }

        public void Update(MusicCatalogApp app)
        {
            musicCatalogAppRepository.Update(app);
        }

        public void Delete(int id)
        {
            musicCatalogAppRepository.Delete(id);
        }

        public List<MusicCatalogApp> LoadFromFile()
        {

            return musicCatalogAppRepository.LoadFromFile();

        }
    }
}
