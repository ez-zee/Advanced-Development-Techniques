using K2GUCM_ADT_2023241.Models;
using System.Linq;

namespace K2GUCM_ADT_2023241.Logic.Interfaces
{
    //Declares methods for Movie class (add, delete, get, update)
    public interface IMovieLogic
    {
        void Add(Movie movie);
        void Delete(int movie);
        IQueryable<Movie> GetAll();
        Movie GetById(int id);
        int NumberOfMoviesInAGivenYear(int year);
        void Update(Movie movie);
    }
}