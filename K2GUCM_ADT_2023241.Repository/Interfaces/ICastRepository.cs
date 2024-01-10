using K2GUCM_ADT_2023241.Models;

namespace K2GUCM_ADT_2023241.Repository.Interfaces
{
    //Declares methods for CastRepository class
    public interface ICastRepository
    {
        Cast Read(int id); //gets cast by id
        void Update(Cast item); //updates cast
    }
}