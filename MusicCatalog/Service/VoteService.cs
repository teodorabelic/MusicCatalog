using MusicCatalog.Model;
using MusicCatalog.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Service
{
    internal class VoteService
    {
        private static VoteService instance = null;
        private VoteRepository voteRepository;
        private List<Vote> votes;

        private VoteService()
        {
            voteRepository = VoteRepository.GetInstance();
            this.votes = voteRepository.GetAll();
        }

        public static VoteService GetInstance()
        {
            if (instance == null)
            {
                instance = new VoteService();
            }
            return instance;
        }

        public Vote GetById(int id)
        {
            return voteRepository.GetById(id);
        }

        public List<Vote> GetAll()
        {
            return voteRepository.GetAll();
        }

        public List<Vote> Create(Vote vote)
        {
            return voteRepository.Create(vote);
        }

        public void Update(Vote vote)
        {
            voteRepository.Update(vote);
        }

        public void Delete(int id)
        {
            voteRepository.Delete(id);
        }

        public List<Vote> LoadFromFile()
        {

            return voteRepository.LoadFromFile();

        }
    }
}
