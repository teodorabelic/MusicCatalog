using MusicCatalog.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Repository
{
    internal class VoteRepository
    {
        private static VoteRepository instance = null;
        private List<Vote> votes;

        private VoteRepository()
        {
            votes = LoadFromFile();
        }

        public static VoteRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new VoteRepository();
            }
            return instance;
        }

        public List<Vote> GetAll()
        {
            return votes;
        }

        public Vote GetById(int id)
        {
            foreach (Vote vote in votes)
            {
                if (vote.Id == id)
                {
                    return vote;
                }
            }
            return null;
        }

        private int GenerateId()
        {
            int maxId = 0;
            foreach (Vote vote in votes)
            {
                if (vote.Id > maxId)
                {
                    maxId = vote.Id;
                }
            }
            return maxId + 1;
        }

        public void Save()
        {
            try
            {
                StreamWriter file = new StreamWriter("../../../Data/VoteFile.csv", false);

                foreach (Vote vote in votes)
                {
                    file.WriteLine(vote.StringToCsv());
                }
                file.Flush();
                file.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public void Delete(int id)
        {
            Vote vote = GetById(id);
            if (vote == null)
            {
                return;
            }
            votes.Remove(vote);
            Save();
        }

        public void Update(Vote vote)
        {
            Vote oldVote = GetById(vote.Id);

            if (oldVote != null)
            {
                oldVote.Date = vote.Date;
                oldVote.ForWhoId = vote.ForWhoId;
                Save();
            }
        }

        public List<Vote> Create(Vote vote)
        {
            vote.Id = GenerateId();
            votes.Add(vote);
            Save();
            return votes;
        }

        public List<Vote> LoadFromFile()
        {
            List<Vote> votes = new List<Vote>();

            string filename = "../../../Data/VoteFile.csv";

            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] tokens = line.Split('|');

                    if (tokens.Length < 3)
                    {
                        continue;
                    }
                    Vote vote = new Vote(
                        id: Int32.Parse(tokens[0]),
                        date: DateTime.Parse(tokens[1]),
                        forWhoId: Int32.Parse(tokens[2])
                    );
                    votes.Add(vote);
                }
                return votes;
            }
        }
    }
}
