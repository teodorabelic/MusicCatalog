using MusicCatalog.ModelEnum;
using System;
using System.Collections.Generic;

namespace MusicCatalog.Model
{
    public class Solo : Artist
    {
        public Solo(int id, string name, DateTime startDate, ProfessionEnum profession, string biography, string picture)
            : base(id, name, new List<int>(), startDate, profession, biography, picture)
        {
        }

        // Override Participants property to prevent adding participants
        public override List<int> Participants
        {
            get { return new List<int>(); } // Return an empty list
            set { throw new InvalidOperationException("A solo artist cannot have participants."); }
        }

        // Optionally, you can override the StringToCsv method if needed
        public override string StringToCsv()
        {
            // Since there are no participants, we don't need to include them in the CSV string
            return $"{Id}|{Name}|Solo|{StartDate}|{Profession}|{Biography}|{Picture}";
        }
    }
}
