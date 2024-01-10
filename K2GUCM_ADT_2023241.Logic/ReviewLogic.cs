using K2GUCM_ADT_2023241.Logic.Interfaces;
using K2GUCM_ADT_2023241.Models;
using K2GUCM_ADT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2GUCM_ADT_2023241.Logic
{
    public class ReviewLogic : IReviewLogic //Same logic as in the Cast & Movie classes
    {
        private readonly IRepository<Review> repository;

        public ReviewLogic(IRepository<Review> repository)
        {
            this.repository = repository;
        }

        // CRUD

        public void Add(Review cast)
        {
            repository.Create(cast);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public IQueryable<Review> GetAll()
        {
            return repository.ReadAll();
        }

        public Review GetById(int id)
        {
            return repository.Read(id);
        }

        public void Update(Review cast)
        {
            repository.Update(cast);
        }

        // Non CRUD

        public IList<Review> GetAllFromAGivenMovie(int id)
        {
            return repository.ReadAll().Where(x => x.Review_Movie_ID == id).ToList(); //LINQ to get all reviews for a movie
        }
    }
}
