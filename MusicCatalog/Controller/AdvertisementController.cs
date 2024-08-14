using MusicCatalog.Model;
using MusicCatalog.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Controller
{
    internal class AdvertisementController
    {
        private AdvertisementService advertisementService;

        public AdvertisementController()
        {
            advertisementService = new AdvertisementService();
        }

        public List<Advertisement> GetAllAdvertisements()
        {
            return advertisementService.GetAllAdvertisements();
        }

        public Advertisement GetAdvertisementById(int id)
        {
            return advertisementService.GetAdvertisementById(id);
        }

        public void CreateAdvertisement(string description, string picture, int genre)
        {
            Advertisement ad = new Advertisement(description, picture, genre);
            advertisementService.CreateAdvertisement(ad);
        }

        public void UpdateAdvertisement(int id, string description, string picture, int genre)
        {
            Advertisement ad = new Advertisement(description, picture, genre);
            advertisementService.UpdateAdvertisement(id, ad);
        }

        public void DeleteAdvertisement(int id)
        {
            advertisementService.DeleteAdvertisement(id);
        }
    }
}
