using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Model
{
    public class Song : MusicWork
    {
        public Song(int id, string name, string text, string picture, int genreId, string format, DateTime publicationDate) : base(id, name, text, picture, genreId, format, publicationDate)
        {
        }
        public string ToCSV()
        {
            string baseCsv = base.StringToCsv();
            return baseCsv;
        }
    }
}
