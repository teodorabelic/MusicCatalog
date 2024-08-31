using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Model
{
    public class Album : MusicWork
    {
        public Album(int id, string name, string artist, string text, string picture, int genreId, string format, DateTime publicationDate) : base(id, name, artist, text, picture, genreId, format, publicationDate)
        {
        }
        public string ToCSV()
        {
            string baseCsv = base.StringToCsv();
            return baseCsv;
        }
    }
}
