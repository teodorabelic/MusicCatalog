using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Model
{
    internal class Advertisement
    {
        private string description;
        private string picture;
        private int genre;

        public Advertisement(string description, string picture, int genre)
        {
            this.description = description;
            this.picture = picture;
            this.genre = genre;
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Picture
        {
            get { return picture; }
            set { picture = value; }
        }

        public int Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        public string StringToCsv()
        {
            return $"{description}|{picture}|{genre}";
        }
    }
}
