﻿using gcp_api.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace gcp_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<WeatherForecastController> _logger;
        private api apioptions;
        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IHttpClientFactory clientFactory,
            IOptions<api> options)
        {
            apioptions = options.Value;
            _logger = logger;
            _clientFactory = clientFactory;
            
        }

        

   

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> Get()
        {
            Console.WriteLine("---------------------------?");
            Console.WriteLine(apioptions.wf);
            var client = _clientFactory.CreateClient();
            WF.apiClient cl = new WF.apiClient(apioptions.wf, client);

            var r = await cl.ApiWeatherForecastGetAsync();
            return Ok(r);
        }
    }
}