using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace MusicCatalog.Model
{
    public class MusicWork
    {
        private int id;
        private String name;
        private String text;
        private String picture;
        private int genreId;
        private String format;
        private DateTime publicationDate;

        public MusicWork(int id, string name, string text, string picture, int genreId, string format, DateTime publicationDate)
        {
            this.id = id;
            this.name = name;
            this.text = text;
            this.picture = picture;
            this.genreId = genreId;
            this.format = format;
            this.publicationDate = publicationDate;
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

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public string Picture
        {
            get { return picture; }
            set { picture = value; }
        }

        public int GenreId
        {
            get { return genreId; }
            set { genreId = value; }
        }

        public string Format
        {
            get { return format; }
            set { format = value; }
        }

        public DateTime PublicationDate
        {
            get { return publicationDate; }
            set { publicationDate = value; }
        }

        public string StringToCsv()
        {
            return id + "|" + name + "|" + text + "|" + picture + "|" + genreId + "|" + format + "|" + publicationDate.ToString("yyyy-MM-dd");
        }
    }
}
