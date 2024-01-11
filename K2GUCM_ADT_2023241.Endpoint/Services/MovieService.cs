using K2GUCM_ADT_2023241.Data;
using K2GUCM_ADT_2023241.Logic;
using K2GUCM_ADT_2023241.Logic.Interfaces;
using K2GUCM_ADT_2023241.Models;
using K2GUCM_ADT_2023241.Repository;
using System.Collections.Generic;
using System.Linq;

namespace K2GUCM_ADT_2023241.Endpoint.Services
{
    //Similar structure, logic, and implementation applies in CastService class
    public class MovieService
    {
        MovieContext context;
        IMovieLogic logic;

        public MovieService(MovieContext context)
        {
            this.context = context;
            MovieRepository movieRepo = new MovieRepository(context);
            CastRepository castRepo = new CastRepository(context);
            ReviewRepository reviewRepo = new ReviewRepository(context);
            this.logic = new MovieLogic(movieRepo);

        }

        public void AddMovie(Movie movie)
        {
            logic.Add(movie);
        }

        public List<Movie> GetAll()
        {
            return (List<Movie>)logic.GetAll();
        }

        public Movie GetById(int id)
        {
            return logic.GetById(id);
        }

        public void Update(Movie movie)
        {
            logic.Update(movie);
        }

        public void Delete(int id)
        {
            logic.Delete(id);
        }

        public int NumberOfMoviesInAGivenYear(int year)
        {
            return logic.NumberOfMoviesInAGivenYear(year);
        }
    }
}
