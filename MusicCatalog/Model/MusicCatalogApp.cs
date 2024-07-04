using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Model
{
    public class MusicCatalogApp
    {
        private int id;
        private string name;
        private int songOfTheYearId;
        private int albumOfTheYearId;
        private List<int> topArtistsId;

        public MusicCatalogApp(int id, string name, int songOfTheYearId, int albumOfTheYearId, List<int> topArtistsId) 
        { 
            this.id = id;
            this.name = name;
            this.songOfTheYearId = songOfTheYearId;
            this.albumOfTheYearId = albumOfTheYearId;
            this.topArtistsId = topArtistsId;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int SongOfTheYear
        {
            get { return songOfTheYearId; }
            set { songOfTheYearId = value; }
        }
        public int AlbumOfTheYear
        {
            get { return albumOfTheYearId; }
            set { albumOfTheYearId = value; }
        }
        public List<int> TopArtists
        {
            get { return topArtistsId; }
            set { topArtistsId = value; }
        }

        public String StringToCsv()
        {
            return $"{name}|{songOfTheYearId}|{albumOfTheYearId}|{topArtistsId}";
        }
    }
}
