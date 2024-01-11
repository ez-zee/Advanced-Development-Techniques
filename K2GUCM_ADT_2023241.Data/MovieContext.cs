using Microsoft.EntityFrameworkCore;
using K2GUCM_ADT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2GUCM_ADT_2023241.Data
{
    public class MovieContext : DBContext
    {
        public MovieContext()
        {
            this.Database.EnsureCreated();
        }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Cast> Casts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies()
                    .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True; MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                    new Movie
                    {
                        Movie_ID = 1,
                        Movie_ReleaseYear = 2022,
                        Movie_Title = "Prey",
                        Movie_Director = "Dan Trachtenberg"
                    },
                    new Movie
                    {
                        Movie_ID = 2,
                        Movie_ReleaseYear = 2022,
                        Movie_Title = "Doctor Strange in the Multiverse of Madness",
                        Movie_Director = "Sam Raimi"
                    },
                    new Movie
                    {
                        Movie_ID = 3,
                        Movie_ReleaseYear = 2017,
                        Movie_Title = "Thor: Ragnarok",
                        Movie_Director = "Taika Waititi"
                    },
                    new Movie
                    {
                        Movie_ID = 4,
                        Movie_ReleaseYear = 2018,
                        Movie_Title = "Avengers: Infinity War",
                        Movie_Director = "Anthony Russo"
                    },
                    new Movie
                    {
                        Movie_ID = 5,
                        Movie_ReleaseYear = 2015,
                        Movie_Title = "Guardians of the Galaxy",
                        Movie_Director = "James Gunn"
                    }
                );

            modelBuilder.Entity<Cast>().HasData(
                    new Cast
                    {
                        Cast_ID = 1,
                        Cast_Movie_ID = 1,
                        Cast_Name = "Amber Midthunder",
                        Cast_Nick = "Naru"
                    },
                    new Cast
                    {
                        Cast_ID = 2,
                        Cast_Movie_ID = 1,
                        Cast_Name = "Dakota Beavers",
                        Cast_Nick = "Taabe"
                    },
                    new Cast
                    {
                        Cast_ID = 3,
                        Cast_Movie_ID = 1,
                        Cast_Name = "Dane DiLiegro",
                        Cast_Nick = "Predator"
                    },
                    new Cast
                    {
                        Cast_ID = 4,
                        Cast_Movie_ID = 1,
                        Cast_Name = "Stormee Kipp",
                        Cast_Nick = "Wasape"
                    },
                    new Cast
                    {
                        Cast_ID = 5,
                        Cast_Movie_ID = 2,
                        Cast_Name = "Benedict Cumberbatch",
                        Cast_Nick = "Doctor Stephen Strange"
                    },
                    new Cast
                    {
                        Cast_ID = 6,
                        Cast_Movie_ID = 2,
                        Cast_Name = "Elizabeth Olsen",
                        Cast_Nick = "Wanda Maximoff"
                    },
                    new Cast
                    {
                        Cast_ID = 7,
                        Cast_Movie_ID = 2,
                        Cast_Name = "Chiwetel Ejiofor",
                        Cast_Nick = "Baron Mordo"
                    },
                    new Cast
                    {
                        Cast_ID = 8,
                        Cast_Movie_ID = 3,
                        Cast_Name = "Chris Hemsworth",
                        Cast_Nick = "Thor"
                    },
                    new Cast
                    {
                        Cast_ID = 9,
                        Cast_Movie_ID = 3,
                        Cast_Name = "Cate Blanchett",
                        Cast_Nick = "Hela"
                    },
                    new Cast
                    {
                        Cast_ID = 10,
                        Cast_Movie_ID = 3,
                        Cast_Name = "Tom Hiddleston",
                        Cast_Nick = "Loki"
                    },
                    new Cast
                    {
                        Cast_ID = 11,
                        Cast_Movie_ID = 3,
                        Cast_Name = "Mark Ruffalo",
                        Cast_Nick = "Bruce Banner"
                    },
                    new Cast
                    {
                        Cast_ID = 12,
                        Cast_Movie_ID = 4,
                        Cast_Name = "Robert Downey Jr.",
                        Cast_Nick = "Tony Stark"
                    },
                    new Cast
                    {
                        Cast_ID = 13,
                        Cast_Movie_ID = 4,
                        Cast_Name = "Chris Hemsworth",
                        Cast_Nick = "Thor"
                    },
                    new Cast
                    {
                        Cast_ID = 14,
                        Cast_Movie_ID = 4,
                        Cast_Name = "Mark Ruffalo",
                        Cast_Nick = "Bruce Banner"
                    },
                    new Cast
                    {
                        Cast_ID = 15,
                        Cast_Movie_ID = 4,
                        Cast_Name = "Scarlett Johansson",
                        Cast_Nick = "Natasha Romanoff"
                    },
                    new Cast
                    {
                        Cast_ID = 16,
                        Cast_Movie_ID = 4,
                        Cast_Name = "Benedict Cumberbatch",
                        Cast_Nick = "Doctor Stephen Strange"
                    },
                    new Cast
                    {
                        Cast_ID = 17,
                        Cast_Movie_ID = 5,
                        Cast_Name = "Chris Pratt",
                        Cast_Nick = "Peter Quill"
                    },
                    new Cast
                    {
                        Cast_ID = 18,
                        Cast_Movie_ID = 5,
                        Cast_Name = "Zoe Saldana",
                        Cast_Nick = "Gamora"
                    },
                    new Cast
                    {
                        Cast_ID = 19,
                        Cast_Movie_ID = 5,
                        Cast_Name = "Dave Bautista",
                        Cast_Nick = "Drax"
                    },
                    new Cast
                    {
                        Cast_ID = 20,
                        Cast_Movie_ID = 5,
                        Cast_Name = "Lee Pace",
                        Cast_Nick = "Ronan"
                    }

                );


            modelBuilder.Entity<Review>().HasData(
                    new Review
                    {
                        Review_ID = 1,
                        Review_Movie_ID = 1,
                        Review_Content = "Very well made, the cinematography is great. Acting is also very strong. Some great action sequences."
                    },
                    new Review
                    {
                        Review_ID = 2,
                        Review_Movie_ID = 1,
                        Review_Content = "A worthy prequel to the classic"
                    },
                    new Review
                    {
                        Review_ID = 3,
                        Review_Movie_ID = 1,
                        Review_Content = "Definitely worth your time!!"
                    },
                    new Review
                    {
                        Review_ID = 4,
                        Review_Movie_ID = 2,
                        Review_Content = "Well, it was shiny and colourful"
                    },
                    new Review
                    {
                        Review_ID = 5,
                        Review_Movie_ID = 2,
                        Review_Content = "Not enough multiverse and maybe too much madness"
                    },
                    new Review
                    {
                        Review_ID = 6,
                        Review_Movie_ID = 2,
                        Review_Content = "This was Wandavision 2, not Doctor Strange 2"
                    },
                    new Review
                    {
                        Review_ID = 7,
                        Review_Movie_ID = 3,
                        Review_Content = "The best Thor yet!"
                    },
                    new Review
                    {
                        Review_ID = 8,
                        Review_Movie_ID = 3,
                        Review_Content = "The best marvel movie of them all!! Humor and action!!"
                    },
                    new Review
                    {
                        Review_ID = 9,
                        Review_Movie_ID = 3,
                        Review_Content = "Simply epic"
                    },
                    new Review
                    {
                        Review_ID = 10,
                        Review_Movie_ID = 3,
                        Review_Content = "RagnaRock, Paper, Scissors?"
                    },
                    new Review
                    {
                        Review_ID = 11,
                        Review_Movie_ID = 4,
                        Review_Content = "Best Cliffhanger of all Time"
                    },
                    new Review
                    {
                        Review_ID = 12,
                        Review_Movie_ID = 4,
                        Review_Content = "EMOTIONAL ROLLER COASTER"
                    },
                    new Review
                    {
                        Review_ID = 13,
                        Review_Movie_ID = 4,
                        Review_Content = "Better than Endgame"
                    },
                    new Review
                    {
                        Review_ID = 14,
                        Review_Movie_ID = 4,
                        Review_Content = "A superior avengers sequel"
                    },
                    new Review
                    {
                        Review_ID = 15,
                        Review_Movie_ID = 4,
                        Review_Content = "It all led to this: superhero film at its best"
                    },
                    new Review
                    {
                        Review_ID = 16,
                        Review_Movie_ID = 4,
                        Review_Content = "To this day one of the most impossible films to pull off"
                    },
                    new Review
                    {
                        Review_ID = 17,
                        Review_Movie_ID = 5,
                        Review_Content = "One of the best mcu films"
                    },
                    new Review
                    {
                        Review_ID = 18,
                        Review_Movie_ID = 5,
                        Review_Content = "Fun, Exciting and Soulfull"
                    },
                    new Review
                    {
                        Review_ID = 19,
                        Review_Movie_ID = 5,
                        Review_Content = "I AM GROOT"
                    },
                    new Review
                    {
                        Review_ID = 20,
                        Review_Movie_ID = 5,
                        Review_Content = "Perfect Film Entertainment"
                    },
                    new Review
                    {
                        Review_ID = 21,
                        Review_Movie_ID = 5,
                        Review_Content = "One of my fav movie"
                    }

                );
        }

    }
}
