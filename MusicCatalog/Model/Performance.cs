using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Model
{
    public class Performance : MusicWork
    {
        public Performance(int id, string name, string artist, string lyrics, string picture, int genreId, string format, DateTime publicationDate) : base(id, name, artist, lyrics, picture, genreId, format, publicationDate)
        {
        }
        public string ToCSV()
        {
            string baseCsv = base.StringToCsv();
            return baseCsv;
        }
    }
}
