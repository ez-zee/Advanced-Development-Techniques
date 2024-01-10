using K2GUCM_ADT_2023241.Models;
using System.Collections.Generic;
using System.Linq;

namespace K2GUCM_ADT_2023241.Logic.Interfaces
{
    //Declares methods for Review class (add, delete, get, update)
    public interface IReviewLogic
    {
        void Add(Review cast);
        void Delete(int id);
        IQueryable<Review> GetAll();
        IList<Review> GetAllFromAGivenMovie(int id);
        Review GetById(int id);
        void Update(Review cast);
    }
}