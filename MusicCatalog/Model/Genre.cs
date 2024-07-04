using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Model
{
    public class Genre
    {
        private int id;
        private String type;

        public Genre(int id, string type)
        {
            this.id = id;
            this.type = type;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string StringToCsv()
        {
            return id + "|" + type;
        }
    }
}
