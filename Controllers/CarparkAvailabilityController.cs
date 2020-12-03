using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using CarparkWhere.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarparkWhere.Controllers
{
    [Route("api/carpark")]
    [ApiController]
    public class CarparkAvailabilityController : ControllerBase
    {
        public readonly string REQUEST_URL = "https://api.data.gov.sg/v1/transport/carpark-availability";

        // GET: api/<CarparkAvailabilityController>
        [HttpGet]
        public IActionResult Get()
        {
            var data = GetData().Result;
            List<Carpark> carparks = new List<Carpark>();

            using (JsonDocument document = JsonDocument.Parse(data))
            {
                var items = document.RootElement.GetProperty("items").EnumerateArray().First<JsonElement>();
                var carparksData = items.GetProperty("carpark_data").EnumerateArray();

                foreach (JsonElement element in carparksData)
                {
                    var carparkInfo = element.GetProperty("carpark_info").EnumerateArray().First<JsonElement>();
                    Carpark carpark = new Carpark
                    {
                        Number = element.GetProperty("carpark_number").GetString(),
                        TotalLots = carparkInfo.GetProperty("total_lots").GetString(),
                        AvailableLots = carparkInfo.GetProperty("lots_available").GetString(),
                        LotType = carparkInfo.GetProperty("lot_type").GetString()
                    };
                    carparks.Add(carpark);
                }
            }

            return Ok(carparks);
        }

        // GET api/<CarparkAvailabilityController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var data = GetData().Result;
            List<Carpark> carparks = new List<Carpark>();

            using (JsonDocument document = JsonDocument.Parse(data))
            {
                var items = document.RootElement.GetProperty("items").EnumerateArray().First<JsonElement>();
                var carparksData = items.GetProperty("carpark_data").EnumerateArray();

                foreach (JsonElement element in carparksData)
                {
                    if (element.GetProperty("carpark_number").GetString().Equals(id))
                    {
                        var carparkInfo = element.GetProperty("carpark_info").EnumerateArray().First<JsonElement>();
                        Carpark carpark = new Carpark
                        {
                            Number = element.GetProperty("carpark_number").GetString(),
                            TotalLots = carparkInfo.GetProperty("total_lots").GetString(),
                            AvailableLots = carparkInfo.GetProperty("lots_available").GetString(),
                            LotType = carparkInfo.GetProperty("lot_type").GetString()
                        };
                        return Ok(carpark);
                    }
                }
            }

            return BadRequest(new { message = "The carpark with the given ID cannot be found." });
        }

        private async Task<string> GetData()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(REQUEST_URL);
            HttpContent content = response.Content;
            string data = await content.ReadAsStringAsync();
            return data;
        }
    }
}
