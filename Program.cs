using ConsoleTools;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace K2GUCM_ADT_2023241.Client
{
    class Program
    {
        private static HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:59196")
        };

        static async Task Main(string[] args)
        {
            // CastRequest, ReviewRequest, MovieRequest instances
            CastRequest cast = new(client);
            ReviewRequest review = new(client);
            MovieRequest movie = new(client);

            try
            {
                //sub-menus
                var MovieMenu = new ConsoleMenu(args, level: 1)
                    .Add(">> LIST ALL MOVIES", async () => await movie.GetAll())
                    .Add(">> GET BY ID", async () => await movie.GetById())
                    .Add(">> ADD NEW MOVIE", async () => await movie.Add())
                    .Add(">> REMOVE MOVIE BY ID", async () => await movie.Delete())
                    .Add(">> NUMBER OF MOVIES IN A GIVEN YEAR", async () => await movie.NumberOfMoviesInAGivenYear())
                    .Add(">> BACK", ConsoleMenu.Close);

                var ReviewMenu = new ConsoleMenu(args, level: 1)
                   .Add(">> LIST ALL REVIEWS", async () => await review.GetAll())
                   .Add(">> GET BY ID", async () => await review.GetById())
                   .Add(">> ADD NEW REVIEW", async () => await review.Add())
                   .Add(">> REMOVE REVIEW BY ID", async () => await review.Delete())
                   .Add(">> ALL REVIEWS FROM A MOVIE", async () => await review.GetAllFromAGivenMovie())
                   .Add(">> BACK", ConsoleMenu.Close);

                var CastMenu = new ConsoleMenu(args, level: 1)
                   .Add(">> LIST ALL CASTS", async () => await cast.GetAll())
                   .Add(">> GET BY ID", async () => await cast.GetById())
                   .Add(">> ADD NEW REVIEW", async () => await cast.Add())
                   .Add(">> REMOVE REVIEW BY ID", async () => await cast.Delete())
                   .Add(">> GET ALL CAST FROM A MOVIE", async () => await cast.GetAllFromAGivenMovie())
                   .Add(">> BACK", ConsoleMenu.Close);

                //main menus
                var menu = new ConsoleMenu(args, level: 0)
                .Add(">> MOVIES", () => MovieMenu.Show())
                .Add(">> REVIEWS", () => ReviewMenu.Show())
                .Add(">> CASTS", () => CastMenu.Show())
                .Add(">> EXIT", ConsoleMenu.Close);


                //displays menus
                menu.Show();

            }
            catch (Exception e)
            {
                Console.WriteLine("Err");
            }
        }

    }
}
