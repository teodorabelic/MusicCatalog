using MusicCatalog.ModelEnum;
using System;
using System.Collections.Generic;

namespace MusicCatalog.Model
{
    public class Band : Artist
    {
        public Band(int id, string name, List<int> participants, DateTime startDate, ProfessionEnum.Profession profession, string biography, string picture)
            : base(id, name, participants, startDate, profession, biography, picture)
        {
        }

        // The Band class can have its own methods or properties specific to a band if needed

        // Optionally, you can override the StringToCsv method if needed
        public override string StringToCsv()
        {
            string participantsString = string.Join(",", Participants);
            return $"{Id}|{Name}|{participantsString}|{StartDate}|{Profession}|{Biography}|{Picture}";
        }
    }
}
