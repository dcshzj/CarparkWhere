using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarparkWhere.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarparkWhere.Controllers
{
    [Route("api/carpark")]
    [ApiController]
    public class CarparkAvailabilityController : ControllerBase
    {
        // GET: api/<CarparkAvailabilityController>
        [HttpGet]
        public IEnumerable<Carpark> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(x => new Carpark
            {
                Number = x.ToString(),
                TotalLots = 1,
                AvailableLots = 0,
                LotType = "C"
            }).ToArray();
        }

        // GET api/<CarparkAvailabilityController>/5
        [HttpGet("{id}")]
        public Carpark Get(string id)
        {
            return new Carpark
            {
                Number = id,
                TotalLots = 1,
                AvailableLots = 0,
                LotType = "C"
            };
        }
    }
}
