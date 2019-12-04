using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using CheapAwesomeTravel.Models;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using CheapAwesomeTravel.Repositories;

namespace CheapAwesomeTravel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheapAwesomeApiController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private IConsumeAPI _consumeAPI;
        public CheapAwesomeApiController(IConfiguration configuration)
        {
            _configuration = configuration;
            _consumeAPI = new ConsumeAPI(_configuration.GetValue<string>("WebBedsURL"));
        }
        public async Task<IActionResult> GetHotels(int destinationid, int nights, string code)
        {
            return Ok(await _consumeAPI.GetHotelsFromApi(destinationid, nights, code));
        }
    }
}