using K2GUCM_ADT_2023241.Models;

namespace K2GUCM_ADT_2023241.Repository.Interfaces
{
    //Employs the same features & logic as Cast- & MovieRepository
    public interface IReviewRepository
    {
        Review Read(int id);
        void Update(Review item);
    }
}