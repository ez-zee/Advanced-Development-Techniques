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
    public class MovieLogic : IMovieLogic //Same logic as in the Cast class
    {
        private readonly IRepository<Movie> repository;

        public MovieLogic(IRepository<Movie> repository)
        {
            this.repository = repository;
        }

        //CRUD
        public void Add(Movie movie)
        {
            repository.Create(movie);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public IQueryable<Movie> GetAll()
        {
            return repository.ReadAll();
        }

        public Movie GetById(int id)
        {
            return repository.Read(id);
        }

        public void Update(Movie movie)
        {
            repository.Update(movie);
        }

        // Non CRUD

        public int NumberOfMoviesInAGivenYear(int year)
        {
            return repository.ReadAll().Where(x => x.Movie_ReleaseYear == year).Count(); //LINQ to count total movies
        }
    }
}
