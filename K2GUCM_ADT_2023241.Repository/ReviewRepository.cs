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
    //Employs the same logic & implementation as Cast- &MovieRepository
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {

        public ReviewRepository(MovieContext ctx) : base(ctx)
        {
        }

        public override Review Read(int id)
        {
            return ctx.Reviews.FirstOrDefault(t => t.Review_ID == id);
        }

        public override void Update(Review item)
        {
            var old = Read(item.Review_ID);
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
