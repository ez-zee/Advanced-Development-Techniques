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
    [Route("[controller]")] //placeholder for Cast
    [ApiController] //class features API behavior
    public class CastController : ControllerBase
    {
        private readonly ICastLogic logic;
        private readonly IHubContext<SignalRHub> hub;

        //construtor
        public CastController(ICastLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        // ACTION methods
        // Return IActionResult instances for HTTP requests.
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Cast cast = logic.GetById(id);
            return Ok(cast);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Cast> casts = logic.GetAll().ToList();
            return Ok(casts);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Cast cast)
        {
            logic.Add(cast);
            this.hub.Clients.All.SendAsync("CastCreated", cast);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cast = logic.GetById(id);
            logic.Delete(id);
            this.hub.Clients.All.SendAsync("CastDeleted", cast);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Cast cast)
        {
            logic.Update(cast);
            this.hub.Clients.All.SendAsync("CastUpdated", cast);
            return Ok();
        }
    }
}
