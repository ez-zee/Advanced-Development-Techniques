using K2GUCM_ADT_2023241.Data;
using K2GUCM_ADT_2023241.Logic;
using K2GUCM_ADT_2023241.Logic.Interfaces;
using K2GUCM_ADT_2023241.Models;
using K2GUCM_ADT_2023241.Repository;
using System.Collections.Generic;
using System.Linq;

namespace K2GUCM_ADT_2023241.Endpoint.Services
{
    //Similar to Cast- and MovieService classes
    public class ReviewService
    {
        private MovieContext context;
        private IReviewLogic logic;

        public ReviewService(MovieContext context)
        {
            this.context = context;
            ReviewRepository reviewRepo = new ReviewRepository(context);
            this.logic = new ReviewLogic(reviewRepo);
        }

        //Methods handle Review items
        public void AddReview(Review review)
        {
            logic.Add(review);
        }

        public Review GetById(int id)
        {
            return logic.GetById(id);
        }

        public List<Review> GetAll()
        {
            return (List<Review>)logic.GetAll();
        }

        public void Update(Review review)
        {
            logic.Update(review);
        }

        public void Delete(int id)
        {
            logic.Delete(id);
        }

        public List<Review> GetAllFromAGivenMovie(int id)
        {
            return (List<Review>)logic.GetAllFromAGivenMovie(id);
        }
    }
}
