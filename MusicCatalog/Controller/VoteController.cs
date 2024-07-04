using MusicCatalog.Model;
using MusicCatalog.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Controller
{
    internal class VoteController
    {
        private VoteService voteService;

        public VoteController()
        {
            voteService =VoteService.GetInstance();
        }

        public List<Vote> GetAll()
        {
            return voteService.GetAll();
        }

        public Vote GetById(int id)
        {
            return voteService.GetById(id);
        }

        public List<Vote> Create(Vote vote)
        {
            return voteService.Create(vote);
        }

        public void Update(Vote vote)
        {
            voteService.Update(vote);
        }

        public void Delete(int id)
        {
            voteService.Delete(id);
        }

        public List<Vote> LoadFromFile()
        {
            return voteService.LoadFromFile();
        }
    }
}
