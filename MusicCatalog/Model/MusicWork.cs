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
        private String title;
        private String artist;
        private String text;
        private String picture;
        private int genreId;
        private String format;
        private DateTime publicationDate;

        public MusicWork(int id, string title, string artist, string text, string picture, int genreId, string format, DateTime publicationDate)
        {
            this.id = id;
            this.title = title;
            this.artist = artist;
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

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Artist
        {
            get { return artist; }
            set { artist = value; }
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
            return id + "|" + title + "|" + artist + "|" + text + "|" + picture + "|" + genreId + "|" + format + "|" + publicationDate.ToString("yyyy-MM-dd");
        }
    }
}
