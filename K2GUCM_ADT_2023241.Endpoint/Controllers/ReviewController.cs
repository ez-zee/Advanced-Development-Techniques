using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using K2GUCM_ADT_2023241.Data;
using K2GUCM_ADT_2023241.Endpoint.Services;
using K2GUCM_ADT_2023241.Logic;
using K2GUCM_ADT_2023241.Logic.Interfaces;
using K2GUCM_ADT_2023241.Models;
using System.Collections.Generic;
using System.Linq;


namespace K2GUCM_ADT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewLogic logic;
        private readonly IHubContext<SignalRHub> hub;

        public ReviewController(IReviewLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var review = logic.GetById(id);
            return Ok(review);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Review> reviews = logic.GetAll().ToList();
            return Ok(reviews);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Review review)
        {
            logic.Add(review);
            this.hub.Clients.All.SendAsync("ReviewCreated", review);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var review = this.logic.GetById(id);
            logic.Delete(id);
            this.hub.Clients.All.SendAsync("ReviewDeleted", review);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Review review)
        {
            logic.Update(review);
            this.hub.Clients.All.SendAsync("ReviewUpdated", review);
            return Ok();
        }

        [HttpGet("Review/Get-Reviews-From-Movie/{id}")]
        public IActionResult GetAllFromAGivenMovie(int id)
        {
            return Ok(logic.GetAllFromAGivenMovie(id));
        }
    }
}
