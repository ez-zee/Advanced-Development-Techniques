using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using K2GUCM_ADT_2023241.Data;
using K2GUCM_ADT_2023241.Endpoint.Services;
using K2GUCM_ADT_2023241.Logic.Interfaces;
using K2GUCM_ADT_2023241.Models;
using System.Collections.Generic;
using System.Linq;


namespace K2GUCM_ADT_2023241.Endpoint.Controllers
{
    [Route("[controller]")] //placeholder for Movie
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieLogic logic;
        private IHubContext<SignalRHub> hub;

        public MovieController(IMovieLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        //ACTION methods
        // Return IActionResult instances for HTTP requests.
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var movie = logic.GetById(id);
            return Ok(movie);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Movie> movies = logic.GetAll().ToList();
            return Ok(movies);
        }


        [HttpPost]
        public IActionResult Post([FromBody] Movie movie)
        {
            logic.Add(movie);
            this.hub.Clients.All.SendAsync("MovieCreated", movie);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Movie movie)
        {
            logic.Update(movie);
            this.hub.Clients.All.SendAsync("MovieUpdated", movie);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movie = this.logic.GetById(id);
            logic.Delete(id);
            this.hub.Clients.All.SendAsync("MovieDeleted", movie);
            return Ok();
        }

        [HttpGet("Movies-In-A-Year/{year}")]
        public IActionResult NumberOfMoviesInAGivenYear(int year)
        {
            return Ok(logic.NumberOfMoviesInAGivenYear(year));
        }
    }
}
