using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MusicCatalog.Model
{
    public class Vote
    {
        private int id;
        private DateTime date;
        private int forWhoId;

        public Vote(int id,  DateTime date, int forWhoId)
        {
            this.id = id;
            this.date = date;
            this.forWhoId = forWhoId;
        }

        public int Id 
        {
            get { return id; }
            set { id = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public int ForWhoId
        {
            get { return forWhoId; }
            set { forWhoId = value; }
        }

        public String StringToCsv()
        {
            return $"{id}|{date}|{forWhoId}";
        }
    }
}
