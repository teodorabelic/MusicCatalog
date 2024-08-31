using MusicCatalog.Model;
using MusicCatalog.Repository;
using System;
using System.Collections.Generic;

namespace MusicCatalog.Service
{
    internal class MusicWorkService
    {
        private MusicWorkRepository musicWorkRepository;

        public MusicWorkService()
        {
            musicWorkRepository = MusicWorkRepository.GetInstance();
        }

        public List<MusicWork> GetAll()
        {
            return musicWorkRepository.GetAll();
        }

        public MusicWork GetMusicWorkById(int id)
        {
            return musicWorkRepository.GetById(id);
        }

        public void CreateMusicWork(MusicWork work)
        {
            musicWorkRepository.Create(work);
        }

        public void UpdateMusicWork(MusicWork work)
        {
            musicWorkRepository.Update(work);
        }

        public void DeleteMusicWork(int id)
        {
            musicWorkRepository.Delete(id);
        }

        public string GetProjectDirectory()
        {
            return musicWorkRepository.GetProjectDirectory();
        }
    }
}
