using MusicCatalog.ModelEnum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Model
{
    public class Admin : User
    {
        public Admin()
        {
        }

        public Admin(int id, string name, string surname, string email, string password, bool blocked, List<Genre> genreHistory, RoleEnum.Role role)
            : base(id, name, surname, email, password, blocked, genreHistory, role)
        {
        }
        public string ToCSV()
        {
            string baseCsv = base.StringToCsv();
            return baseCsv;
        }
    }
}
