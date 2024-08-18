using MusicCatalog.Model;
using MusicCatalog.Repository;
using System;
using System.Collections.Generic;

namespace MusicCatalog.Service
{
    internal class GenreService
    {
        private GenreRepository genreRepository;

        public GenreService()
        {
            genreRepository = GenreRepository.GetInstance();
        }

        public List<Genre> GetAllGenres()
        {
            return genreRepository.GetAll();
        }

        public Genre GetGenreById(int id)
        {
            return genreRepository.GetById(id);
        }

        public void CreateGenre(Genre genre)
        {
            genreRepository.Create(genre);
        }

        public void UpdateGenre(Genre genre)
        {
            genreRepository.Update(genre);
        }

        public void DeleteGenre(int id)
        {
            genreRepository.Delete(id);
        }
    }
}
