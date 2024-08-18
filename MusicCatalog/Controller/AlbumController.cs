using MusicCatalog.Model;
using MusicCatalog.Service;
using System;
using System.Collections.Generic;

namespace MusicCatalog.Controller
{
    internal class AlbumController
    {
        private AlbumService albumService;

        public AlbumController()
        {
            albumService = new AlbumService();
        }

        public List<Album> GetAllAlbums()
        {
            return albumService.GetAllAlbums();
        }

        public Album GetAlbumById(int id)
        {
            return albumService.GetAlbumById(id);
        }

        public void CreateAlbum(Album album)
        {
            albumService.CreateAlbum(album);
        }

        public void UpdateAlbum(Album album)
        {
            albumService.UpdateAlbum(album);
        }

        public void DeleteAlbum(int id)
        {
            albumService.DeleteAlbum(id);
        }
    }
}
