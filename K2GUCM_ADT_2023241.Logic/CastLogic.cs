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
    public class CastLogic : ICastLogic //implements the interface
    {
        private readonly IRepository<Cast> repository;

        public CastLogic(IRepository<Cast> repository) //constructor
        {
            this.repository = repository;
        }

        // CRUD
        public void Add(Cast cast)
        {
            repository.Create(cast);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public IQueryable<Cast> GetAll()
        {
            return repository.ReadAll();
        }

        public Cast GetById(int id)
        {
            return repository.Read(id);
        }

        public void Update(Cast cast)
        {
            repository.Update(cast);
        }

        // Non CRUD
        public List<Cast> ListAllMovieFromAGivenCast(int id) //LINQ to get a list of movies by id
        {
            return repository.ReadAll().Where(x => x.Cast_ID == id).ToList();
        }

        public List<string> ListAllNicknames() //LINQ group & select to get a list of movies
        {
            var result = repository.ReadAll().GroupBy(g => g.Cast_Nick).Select(s => s.Key).ToList();
            return result;
        }
    }
}
