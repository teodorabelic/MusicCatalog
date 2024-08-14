using MusicCatalog.Model;
using MusicCatalog.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Service
{
    internal class AdvertisementService
    {
        private AdvertisementRepository advertisementRepository;

        public AdvertisementService()
        {
            advertisementRepository = AdvertisementRepository.GetInstance();
        }

        public List<Advertisement> GetAllAdvertisements()
        {
            return advertisementRepository.GetAll();
        }

        public Advertisement GetAdvertisementById(int id)
        {
            return advertisementRepository.GetById(id);
        }

        public void CreateAdvertisement(Advertisement ad)
        {
            advertisementRepository.Create(ad);
        }

        public void UpdateAdvertisement(int id, Advertisement ad)
        {
            advertisementRepository.Update(id, ad);
        }

        public void DeleteAdvertisement(int id)
        {
            advertisementRepository.Delete(id);
        }
    }
}
