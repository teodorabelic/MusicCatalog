using MusicCatalog.Model;
using MusicCatalog.Service;
using System;
using System.Collections.Generic;

namespace MusicCatalog.Controller
{
    internal class MusicWorkController
    {
        private MusicWorkService musicWorkService;

        public MusicWorkController()
        {
            musicWorkService = new MusicWorkService();
        }

        public List<MusicWork> GetAll()
        {
            return musicWorkService.GetAll();
        }

        public MusicWork GetMusicWorkById(int id)
        {
            return musicWorkService.GetMusicWorkById(id);
        }

        public void CreateMusicWork(MusicWork work)
        {
            musicWorkService.CreateMusicWork(work);
        }

        public void UpdateMusicWork(MusicWork work)
        {
            musicWorkService.UpdateMusicWork(work);
        }

        public void DeleteMusicWork(int id)
        {
            musicWorkService.DeleteMusicWork(id);
        }

        public string GetProjectDirectory()
        {
            return musicWorkService.GetProjectDirectory();
        }
    }
}
