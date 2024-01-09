using K2GUCM_ADT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace K2GUCM_ADT_2023241.Client
{
    class MovieRequest
    {
        static HttpClient httpClient;

        public MovieRequest(HttpClient client)
        {
            httpClient = client;
        }

        public async Task GetAll()
        {
            List<Movie> movies = await httpClient.GetFromJsonAsync<List<Movie>>("Movie");
            Thread.Sleep(1500);
            foreach (var item in movies)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public async Task GetById()
        {
            Console.WriteLine("Enter Id: ");
            int id = int.Parse(Console.ReadLine());
            Movie movie = await httpClient.GetFromJsonAsync<Movie>($"Movie/{id}");
            Console.WriteLine(movie);
        }

        public async Task Add()
        {
            Console.WriteLine("Enter new movie title: ");
            string title = Console.ReadLine();
            Console.WriteLine("Enter release year: ");
            int releaseYear = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter director: ");
            string director = Console.ReadLine();
            Movie movie = new Movie { Movie_ReleaseYear = releaseYear, Movie_Title = title, Movie_Director = director };

            HttpResponseMessage message = await httpClient.PostAsJsonAsync("Movie", movie);
            Console.WriteLine($"{(message.IsSuccessStatusCode ? "Success" : "Err")} - {message.StatusCode}");
        }

        public async Task Delete()
        {
            Console.WriteLine("Enter the movie's Id: ");
            int id = int.Parse(Console.ReadLine());
            using HttpResponseMessage message = await httpClient.DeleteAsync($"Movie/{id}");
            message.EnsureSuccessStatusCode();
            Console.WriteLine($"{(message.IsSuccessStatusCode ? "Success" : "Err")} - {message.StatusCode}");
        }

        public async Task Update()
        {
            Console.WriteLine("Enter movie id: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter title: ");
            string title = Console.ReadLine();
            Console.WriteLine("Enter release year: ");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter director: ");
            string director = Console.ReadLine();
            Movie movie = new Movie { Movie_ID = id, Movie_Director = director, Movie_Title = title, Movie_ReleaseYear = year };

            using StringContent json = new(JsonSerializer.Serialize(movie), Encoding.UTF8, "application/json");
            HttpResponseMessage message = await httpClient.PatchAsync($"Movie", json);

            message.EnsureSuccessStatusCode();

            Console.WriteLine($"{(message.IsSuccessStatusCode ? "Success" : "Err")} - {message.StatusCode}");
        }

        public async Task NumberOfMoviesInAGivenYear()
        {
            Console.WriteLine("Enter a year: ");
            int year = int.Parse(Console.ReadLine());

            var message = await httpClient.GetFromJsonAsync<int>($"Movie/Movies-In-A-Year/{year}");
            Console.WriteLine("Movies in the given year: " + message.ToString());
        }

    }
}