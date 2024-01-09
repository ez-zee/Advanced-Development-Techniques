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
    //Encapsulates methods for server requests
    class CastRequest
    {
        static HttpClient httpClient; //instance for making HTTP requests

        public CastRequest(HttpClient client)
        {
            httpClient = client;
        }

        //Gets ALL cast members from the server asynchronously
        public async Task GetAll()
        {
            List<Cast> casts = await httpClient.GetFromJsonAsync<List<Cast>>("Cast");//Retrieves cast members asynchronously
            Thread.Sleep(1500);
            foreach (var item in casts) //prints cast members
            {
                Console.WriteLine(item.ToString());
            }
        }

        //User input & get items by ID
        public async Task GetById()
        {
            Console.WriteLine("Enter Id: "); //user-input by cast ID
            int id = int.Parse(Console.ReadLine());
            Cast cast = await httpClient.GetFromJsonAsync<Cast>($"Cast/{id}"); //retrieves items by cast ID
            Console.WriteLine(cast);
        }

        //Adds new cast details
        public async Task Add()
        {
            Console.WriteLine("Enter new cast's name: "); //user input
            string name = Console.ReadLine();
            Console.WriteLine("Enter new cast's nickname: ");
            string nick = Console.ReadLine();
            Console.WriteLine("Enter new cast's movie id: ");
            int id = int.Parse(Console.ReadLine());

            Cast cast = new Cast() { Cast_Name = name, Cast_Nick = nick, Cast_Movie_ID = id }; //new obj

            //POST request adding cast to server
            HttpResponseMessage message = await httpClient.PostAsJsonAsync("Cast", cast);
            Console.WriteLine($"{(message.IsSuccessStatusCode ? "Success" : "Err")} - {message.StatusCode}");
        }

        //Updates casts
        public async Task Update()
        {
            Console.WriteLine("Enter cast's id: "); //user input
            int castId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter nickname: ");
            string nickname = Console.ReadLine();
            Console.WriteLine("Enter movie id: ");
            int movieId = int.Parse(Console.ReadLine());

            //new obj
            Cast cast = new Cast() { Cast_ID = castId, Cast_Name = name, Cast_Nick = nickname, Cast_Movie_ID = movieId };

            //PATCH request updating cast on server
            using StringContent json = new(JsonSerializer.Serialize(cast), Encoding.UTF8, "application/json");
            HttpResponseMessage message = await httpClient.PatchAsync($"Cast", json);

            message.EnsureSuccessStatusCode();
            Console.WriteLine($"{(message.IsSuccessStatusCode ? "Success" : "Err")} - {message.StatusCode}");
        }
        //Deletes casts
        public async Task Delete()
        {
            Console.WriteLine("Enter the cast's Id: "); //user input
            int id = int.Parse(Console.ReadLine());

            //DELETE request removing cast from server
            using HttpResponseMessage message = await httpClient.DeleteAsync($"Cast/{id}");
            message.EnsureSuccessStatusCode();
            Console.WriteLine($"{(message.IsSuccessStatusCode ? "Success" : "Err")} - {message.StatusCode}");
        }

        //Gets ALL casts from a movie
        public async Task GetAllFromAGivenMovie()
        {
            Console.WriteLine("Enter a movie id: "); //user input
            int id = int.Parse(Console.ReadLine());

            //Listing all casts asynchronously
            List<Cast> message = await httpClient.GetFromJsonAsync<List<Cast>>($"Cast/Get-All-From-A-Movie/{id}");

            Console.WriteLine("Cast of this movie:");

            foreach (Cast cast in message)
            {
                Console.WriteLine(cast.ToString());
            }
        }
    }
}
