using MusicCatalog.Model;
using MusicCatalog.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Service
{
    internal class ReviewAndRatingService
    {
        private static ReviewAndRatingService instance = null;
        private ReviewAndRatingRepository reviewAndRatingRepository;
        private List<ReviewAndRating> reviews;

        private ReviewAndRatingService()
        {
            reviewAndRatingRepository = ReviewAndRatingRepository.GetInstance();
            this.reviews = reviewAndRatingRepository.GetAll();
        }

        public static ReviewAndRatingService GetInstance()
        {
            if (instance == null)
            {
                instance = new ReviewAndRatingService();
            }
            return instance;
        }

        public ReviewAndRating GetById(int id)
        {
            return reviewAndRatingRepository.GetById(id);
        }

        public List<ReviewAndRating> GetAll()
        {
            return reviewAndRatingRepository.GetAll();
        }

        public List<ReviewAndRating> Create(ReviewAndRating review)
        {
            return reviewAndRatingRepository.Create(review);
        }

        public void Update(ReviewAndRating review)
        {
            reviewAndRatingRepository.Update(review);
        }

        public void Delete(int id)
        {
            reviewAndRatingRepository.Delete(id);
        }

        public List<ReviewAndRating> LoadFromFile()
        {

            return reviewAndRatingRepository.LoadFromFile();

        }
    }
}
