using K2GUCM_ADT_2023241.Data;
using K2GUCM_ADT_2023241.Logic;
using K2GUCM_ADT_2023241.Logic.Interfaces;
using K2GUCM_ADT_2023241.Models;
using K2GUCM_ADT_2023241.Repository;
using System.Collections.Generic;
using System.Linq;

namespace K2GUCM_ADT_2023241.Endpoint.Services
{
    public class CastService
    {
        private MovieContext movieContext;
        private ICastLogic logic;

        public CastService(MovieContext movieContext)
        {
            this.movieContext = movieContext;
            //creates repos
            MovieRepository movieRepo = new MovieRepository(movieContext);
            CastRepository castRepo = new CastRepository(movieContext);

            this.logic = new CastLogic(castRepo);
        }

        public void AddCast(Cast cast)
        {
            logic.Add(cast);
        }

        public Cast GetById(int id)
        {
            return logic.GetById(id);
        }

        public List<Cast> GetAll()
        {
            return logic.GetAll().ToList();
        }

        public void Update(Cast cast)
        {
            logic.Update(cast);
        }

        public void Delete(int id)
        {
            logic.Delete(id);
        }

        public List<string> ListAllNicknames()
        {
            return logic.ListAllNicknames();
        }

        public List<Cast> ListAllMovieFromAGivenCast(int id)
        {
            return logic.ListAllMovieFromAGivenCast(id);
        }
    }
}
