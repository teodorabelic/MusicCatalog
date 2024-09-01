using MusicCatalog.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Repository
{
    internal class ReviewAndRatingRepository
    {
        private static ReviewAndRatingRepository instance = null;
        private List<ReviewAndRating> reviews;

        private ReviewAndRatingRepository()
        {
            reviews = LoadFromFile();
        }

        public static ReviewAndRatingRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new ReviewAndRatingRepository();
            }
            return instance;
        }

        public List<ReviewAndRating> GetAll()
        {
            return reviews;
        }

        public ReviewAndRating GetById(int id)
        {
            foreach (ReviewAndRating review in reviews)
            {
                if (review.Id == id)
                {
                    return review;
                }
            }
            return null;
        }

        private int GenerateId()
        {
            int maxId = 0;
            foreach (ReviewAndRating review in reviews)
            {
                if (review.Id > maxId)
                {
                    maxId = review.Id;
                }
            }
            return maxId + 1;
        }

        public void Save()
        {
            try
            {
                StreamWriter file = new StreamWriter("../../../Data/ReviewAndRaitingFile.csv", false);

                foreach (ReviewAndRating review in reviews)
                {
                    file.WriteLine(review.StringToCsv());
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
            ReviewAndRating review = GetById(id);
            if (review == null)
            {
                return;
            }
            reviews.Remove(review);
            Save();
        }

        public void Update(ReviewAndRating review)
        {
            ReviewAndRating oldReview = GetById(review.Id);

            if (oldReview != null)
            {
                oldReview.Text = review.Text;
                oldReview.Grade = review.Grade;
                oldReview.MusicWorkId = review.MusicWorkId;
                oldReview.Approved = review.Approved;
                Save();
            }
        }

        public List<ReviewAndRating> Create(ReviewAndRating review)
        {
            review.Id = GenerateId();
            reviews.Add(review);
            Save();
            return reviews;
        }

        public List<ReviewAndRating> LoadFromFile()
        {
            List<ReviewAndRating> reviews = new List<ReviewAndRating>();

            string filename = "../../../Data/ReviewAndRatingFile.csv";

            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] tokens = line.Split('|');

                    if (tokens.Length != 6)
                    {
                        continue;
                    }
                    ReviewAndRating review = new ReviewAndRating(
                        id: Int32.Parse(tokens[0]),
                        reviewerId: Int32.Parse(tokens[1]),
                        text: tokens[2],
                        grade: Int32.Parse(tokens[3]),
                        musicWorkId: Int32.Parse(tokens[4]),
                        approved: bool.Parse(tokens[5])
                    );
                    reviews.Add(review);
                }
                return reviews;
            }
        }
    }
}
