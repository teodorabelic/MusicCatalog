using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Model
{
    internal class MusicEditor : User
    {
        private int rank;
        private Genre genre;
        private List<ReviewAndRating> toDoList;

        public MusicEditor(int id, string name, string surname, string email, string password, List<Genre> genreHistory, bool blocked, int rank, Genre genre, List<ReviewAndRating> toDoList)
            : base(id, name, surname, email, password, blocked, genreHistory)
        {
            this.rank = rank;
            this.genre = genre;
            this.toDoList = toDoList;

        }

        public int Rank
        {
            get { return rank; }
            set { rank = value; }
        }

        public Genre Genre
        {   get { return genre; }
            set {  genre = value; }
        }

        public List<ReviewAndRating> ToDoList
        {
            get { return toDoList; }
            set { toDoList = value; }
        }

        public string StringToCsv()
        {
            return $"{Id}|{Name}|{Surname}|{Email}|{Password}|{Blocked}|{string.Join(",", GenreHistory.ConvertAll(g => $"{g.Id}-{g.Type}"))}|{Rank}|{Genre.Id}-{Genre.Type}|{string.Join(",", ToDoList.ConvertAll(r => r.StringToCsv()))}";
        }

    }
}
