using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MusicCatalog.Model
{
    public class ReviewAndRating
    {
        private int id;
        private int reviewerId;
        private string text;
        private int grade;
        private int musicWorkId;
        private bool approved;

        public ReviewAndRating(int id, int reviewerId, string text, int grade, int musicWorkId, bool approved)
        {
            this.id = id;
            this.reviewerId = reviewerId;
            this.text = text;
            this.grade = grade;
            this.musicWorkId = musicWorkId;
            this.approved = approved;
        }
        public ReviewAndRating(int reviewerId, string text, int grade, int musicWorkId, bool approved)
        {
            this.id = 0; 
            this.reviewerId = reviewerId;
            this.text = text;
            this.grade = grade;
            this.musicWorkId = musicWorkId;
            this.approved = approved;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int ReviewerId
        {
            get { return reviewerId; }
            set { reviewerId = value; }
        }
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        public int Grade
        {
            get { return grade; }
            set { grade = value; }
        }
        public int MusicWorkId
        {
            get { return musicWorkId; }
            set { musicWorkId = value; }
        }
        public bool Approved
        {
            get { return approved; }
            set { approved = value; }
        }

        public String StringToCsv()
        {
            return $"{id}|{reviewerId}|{text}|{grade}|{musicWorkId}|{approved}";
        }
    }
}
