using System.Linq;

namespace K2GUCM_ADT_2023241.Repository.Interfaces
{
    //Declares CRUD methods for items of generic type
    public interface IRepository<T>
    {
        void Create(T item);
        IQueryable<T> ReadAll(); //Gets all items as queryable collection
        T Read(int id); //Gets by id
        void Update(T item);
        void Delete(int id);
    }
}