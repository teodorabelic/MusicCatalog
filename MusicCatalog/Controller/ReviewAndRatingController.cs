using MusicCatalog.Model;
using MusicCatalog.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Controller
{
    internal class ReviewAndRatingController
    {
        private ReviewAndRatingService reviewAndRatingService;

        public ReviewAndRatingController()
        {
            reviewAndRatingService = ReviewAndRatingService.GetInstance();
        }

        public List<ReviewAndRating> GetAll()
        {
            return reviewAndRatingService.GetAll();
        }

        public ReviewAndRating GetById(int id)
        {
            return reviewAndRatingService.GetById(id);
        }

        public List<ReviewAndRating> Create(ReviewAndRating review)
        {
            return reviewAndRatingService.Create(review);
        }

        public void Update(ReviewAndRating review)
        {
            reviewAndRatingService.Update(review);
        }

        public void Delete(int id)
        {
            reviewAndRatingService.Delete(id);
        }

        public List<ReviewAndRating> LoadFromFile()
        {
            return reviewAndRatingService.LoadFromFile();
        }
    }
}
