using K2GUCM_ADT_2023241.Models;
using System.Collections.Generic;
using System.Linq;

namespace K2GUCM_ADT_2023241.Logic.Interfaces
{
    //Declarese methods for Cast class (add, delete, get, update)
    public interface ICastLogic
    {
        void Add(Cast cast);
        void Delete(int id);
        IQueryable<Cast> GetAll();
        Cast GetById(int id);
        List<Cast> ListAllMovieFromAGivenCast(int id); //gets a list of movies by id
        List<string> ListAllNicknames(); //same but by nicknames
        void Update(Cast cast);
    }
}