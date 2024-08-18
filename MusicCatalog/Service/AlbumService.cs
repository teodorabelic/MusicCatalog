using MusicCatalog.Model;
using MusicCatalog.Repository;
using System;
using System.Collections.Generic;

namespace MusicCatalog.Service
{
    internal class AlbumService
    {
        private AlbumRepository albumRepository;

        public AlbumService()
        {
            albumRepository = AlbumRepository.GetInstance();
        }

        public List<Album> GetAllAlbums()
        {
            return albumRepository.GetAll();
        }

        public Album GetAlbumById(int id)
        {
            return albumRepository.GetById(id);
        }

        public void CreateAlbum(Album album)
        {
            albumRepository.Create(album);
        }

        public void UpdateAlbum(Album album)
        {
            albumRepository.Update(album);
        }

        public void DeleteAlbum(int id)
        {
            albumRepository.Delete(id);
        }
    }
}
