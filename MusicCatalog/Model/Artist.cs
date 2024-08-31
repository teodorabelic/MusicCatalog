using MusicCatalog.ModelEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Model
{
    public class Artist
    {
        private int id;
        private String name;
        private List<int> participants;
        private DateTime startDate;
        private ProfessionEnum.Profession profession;
        private String biography;
        private String picture;

        public Artist(int id, String name, List<int> participants, DateTime startDate, ProfessionEnum.Profession profession, String biography, String picture)
        {
            this.id = id;
            this.name = name;
            this.participants = participants;
            this.startDate = startDate;
            this.profession = profession;
            this.biography = biography;
            this.picture = picture;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual List<int> Participants
        {
            get { return participants; }
            set { participants = value; }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public ProfessionEnum.Profession Profession
        {
            get { return profession; }
            set { profession = value; }
        }

        public String Biography
        {
            get { return biography; }
            set { biography = value; }
        }

        public String Picture
        {
            get { return picture; }
            set { picture = value; }
        }

        public virtual String StringToCsv()
        {
            string participantsString = string.Join(",", participants);
            return $"{id}|{name}|{participantsString}|{startDate}|{profession}|{biography}|{picture}";
        }
    }
}
