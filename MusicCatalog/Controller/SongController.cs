using MusicCatalog.Model;
using MusicCatalog.Service;
using System.Collections.Generic;

namespace MusicCatalog.Controller
{
    internal class SongController
    {
        private SongService songService;

        public SongController()
        {
            songService = new SongService();
        }

        public List<Song> GetAllSongs()
        {
            return songService.GetAllSongs();
        }

        public Song GetSongById(int id)
        {
            return songService.GetSongById(id);
        }

        public void CreateSong(Song song)
        {
            songService.CreateSong(song);
        }

        public void UpdateSong(Song song)
        {
            songService.UpdateSong(song);
        }

        public void DeleteSong(int id)
        {
            songService.DeleteSong(id);
        }
    }
}
