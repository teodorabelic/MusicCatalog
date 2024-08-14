using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Model
{
    internal class User
    {
        private int id;
        private string name;
        private string surname;
        private string email;
        private string password;
        private Boolean blocked;
        private List<Genre> genreHistory;

        public User()
        {
            genreHistory = new List<Genre>();
        }

        // Konstruktor sa parametrima
        public User(int id, string name, string surname, string email, string password, bool blocked, List<Genre> genreHistory)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.password = password;
            this.blocked = blocked;
            this.genreHistory = genreHistory ?? new List<Genre>();
        }

        // Getteri i setteri za sve privatne atribute
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

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public bool Blocked
        {
            get { return blocked; }
            set { blocked = value; }
        }

        public List<Genre> GenreHistory
        {
            get { return genreHistory; }
            set { genreHistory = value; }
        }

        public string StringToCsv()
        {
            string genres = string.Join(",", genreHistory);
            return id + "|" + name + "|" + surname + "|" + email + "|" + password + "|" + blocked + "|" + genres;
        }
    }
}
