using K2GUCM_ADT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace K2GUCM_ADT_2023241.Client
{
    class ReviewRequest
    {
        static HttpClient httpClient;

        public ReviewRequest(HttpClient client)
        {
            httpClient = client;
        }

        public async Task GetAll()
        {
            List<Review> reviews = await httpClient.GetFromJsonAsync<List<Review>>("Review");
            Thread.Sleep(1500);
            foreach (var item in reviews)
            {
                Console.WriteLine(item.ToString());
            }
        }
        public async Task GetById()
        {
            Console.WriteLine("Enter Id: ");
            int id = int.Parse(Console.ReadLine());
            Review review = await httpClient.GetFromJsonAsync<Review>($"Review/{id}");
            Console.WriteLine(review);
        }

        public async Task Add()
        {
            Console.WriteLine("Enter review's movie id: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter content: ");
            string content = Console.ReadLine();
            Review review = new Review() { Review_Movie_ID = id, Review_Content = content };

            HttpResponseMessage message = await httpClient.PostAsJsonAsync("Review", review);
            Console.WriteLine($"{(message.IsSuccessStatusCode ? "Success" : "Err")} - {message.StatusCode}");
        }

        public async Task Delete()
        {
            Console.WriteLine("Enter the review's Id: ");
            int id = int.Parse(Console.ReadLine());
            using HttpResponseMessage message = await httpClient.DeleteAsync($"Review/{id}");
            message.EnsureSuccessStatusCode();
            Console.WriteLine($"{(message.IsSuccessStatusCode ? "Success" : "Err")} - {message.StatusCode}");
        }

        public async Task GetAllFromAGivenMovie()
        {
            Console.WriteLine("Enter a movie id: ");
            int id = int.Parse(Console.ReadLine());

            List<Review> message = await httpClient.GetFromJsonAsync<List<Review>>($"Review/Get-Reviews-From-Movie/{id}");
            Console.WriteLine("All reviews of this movie: ");
            foreach (Review review in message)
            {
                Console.WriteLine(review.ToString());
            }
        }
    }
}