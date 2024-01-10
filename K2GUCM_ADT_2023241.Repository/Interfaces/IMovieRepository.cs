using K2GUCM_ADT_2023241.Models;

namespace K2GUCM_ADT_2023241.Repository.Interfaces
{
    //Declares methods for MovieRepository class
    public interface IMovieRepository
    {
        Movie Read(int id); // same as in CastReposirory
        void Update(Movie item);
    }
}