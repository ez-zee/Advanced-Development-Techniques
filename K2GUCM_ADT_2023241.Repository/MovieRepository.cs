using Microsoft.EntityFrameworkCore;
using K2GUCM_ADT_2023241.Data;
using K2GUCM_ADT_2023241.Models;
using K2GUCM_ADT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2GUCM_ADT_2023241.Repository
{
    //Structure, logic & implementation are identical to CastRepository class
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {

        public MovieRepository(MovieContext ctx) : base(ctx)
        {
        }

        public override Movie Read(int id)
        {
            return ctx.Movies.FirstOrDefault(t => t.Movie_ID == id);
        }

        public override void Update(Movie item)
        {
            var old = Read(item.Movie_ID);
            foreach (var prop in old.GetType().GetProperties())
            {
                try
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
                catch { }
            }
            ctx.SaveChanges();
        }
    }
}
