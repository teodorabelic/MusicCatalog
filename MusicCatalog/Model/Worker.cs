using MusicCatalog.ModelEnum;
using System;

namespace MusicCatalog.Model
{
    public class Worker : Artist
    {
        public Worker(int id, string name, DateTime startDate, ProfessionEnum.Profession profession, string biography, string picture)
            : base(id, name, new List<int>(), startDate, profession, biography, picture)
        {
        }

        // Hide Participants property from the base class, similar to Solo class
        public new List<int> Participants
        {
            get { return new List<int>(); } // Return an empty list
            set { throw new InvalidOperationException("A worker cannot have participants."); }
        }

        // Optionally, you can override the StringToCsv method if needed
        public override string StringToCsv()
        {
            // Since there are no participants, we don't need to include them in the CSV string
            return $"{Id}|{Name}|Worker|{StartDate}|{Profession}|{Biography}|{Picture}";
        }
    }
}
