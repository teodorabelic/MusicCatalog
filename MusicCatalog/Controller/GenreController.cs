using MusicCatalog.Model;
using MusicCatalog.Service;
using System;
using System.Collections.Generic;

namespace MusicCatalog.Controller
{
    internal class GenreController
    {
        private GenreService genreService;

        public GenreController()
        {
            genreService = new GenreService();
        }

        public List<Genre> GetAllGenres()
        {
            return genreService.GetAllGenres();
        }

        public Genre GetGenreById(int id)
        {
            return genreService.GetGenreById(id);
        }

        public void CreateGenre(Genre genre)
        {
            genreService.CreateGenre(genre);
        }

        public void UpdateGenre(Genre genre)
        {
            genreService.UpdateGenre(genre);
        }

        public void DeleteGenre(int id)
        {
            genreService.DeleteGenre(id);
        }
    }
}
