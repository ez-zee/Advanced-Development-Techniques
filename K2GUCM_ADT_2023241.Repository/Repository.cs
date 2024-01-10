using K2GUCM_ADT_2023241.Data;
using K2GUCM_ADT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2GUCM_ADT_2023241.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected MovieContext ctx; //DB context
        public Repository(MovieContext ctx)
        {
            this.ctx = ctx;
        }

        //CRUD
        public void Create(T item)
        {
            ctx.Set<T>().Add(item); //adds items of generic type to DB
            ctx.SaveChanges(); //saves changes to DB
        }

        public void Delete(int id)//same logic for deleting
        {
            ctx.Set<T>().Remove(Read(id));
            ctx.SaveChanges();
        }

        public abstract T Read(int id);

        public IQueryable<T> ReadAll()//gets all items as queryable collection
        {
            return ctx.Set<T>();
        }

        public abstract void Update(T item);
    }
}
