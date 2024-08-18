﻿using MusicCatalog.Model;
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

        public List<MusicWork> GetAllMusicWorks()
        {
            return musicWorkService.GetAllMusicWorks();
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
    }
}
