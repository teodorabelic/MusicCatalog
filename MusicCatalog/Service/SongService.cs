using MusicCatalog.Model;
using MusicCatalog.Repository;
using System.Collections.Generic;

namespace MusicCatalog.Service
{
    internal class SongService
    {
        private SongRepository songRepository;

        public SongService()
        {
            songRepository = SongRepository.GetInstance();
        }

        public List<Song> GetAllSongs()
        {
            return songRepository.GetAll();
        }

        public Song GetSongById(int id)
        {
            return songRepository.GetById(id);
        }

        public void CreateSong(Song song)
        {
            songRepository.Create(song);
        }

        public void UpdateSong(Song song)
        {
            songRepository.Update(song);
        }

        public void DeleteSong(int id)
        {
            songRepository.Delete(id);
        }
    }
}
