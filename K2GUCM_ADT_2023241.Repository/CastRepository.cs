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
    //Inherits generic Repository<T> class & implements associated interface 
    public class CastRepository : Repository<Cast>, ICastRepository
    {

        public CastRepository(MovieContext ctx) : base(ctx) //calls constr. of Repository<Cast> base class
        {
        }

        //Gets cast by id from DB using LINQ query 
        public override Cast Read(int id)
        {
            return ctx.Casts.FirstOrDefault(t => t.Cast_ID == id);
        }

        //Gets existing cast using Read()
        public override void Update(Cast item)
        {
            var old = Read(item.Cast_ID);
            foreach (var prop in old.GetType().GetProperties()) //iterates thru properties
            {
                try
                {
                    prop.SetValue(old, prop.GetValue(item)); //updates old values with new
                }
                catch { }
            }
            ctx.SaveChanges(); //saves changes to DB
        }
    }
}