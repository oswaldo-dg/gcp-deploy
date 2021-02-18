using gcp_api.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
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
            
            Console.WriteLine("00001");
            Console.WriteLine("---------------------------HEADERS");
            Request.Headers.ToList().ForEach(h =>
           {
               Console.WriteLine($"{h.Key}::{h.Value}");
           });

            try
            {
                Console.WriteLine("---------------------------fORM");

                Request.Form.Keys.ToList().ForEach(k =>
                {
                    Console.WriteLine($"{k}::{Request.Form[k]}");
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }


            try
            {
                Console.WriteLine("---------------------------BODY");
                var bodyStr = "";
                // Arguments: Stream, Encoding, detect encoding, buffer size 
                // AND, the most important: keep stream opened
                using (StreamReader reader
                          = new StreamReader(Request.Body, Encoding.UTF8, true, 1024, true))
                {
                    bodyStr = reader.ReadToEnd();
                }
                Console.WriteLine(bodyStr);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            


            var client = _clientFactory.CreateClient();
            WF.apiClient cl = new WF.apiClient(apioptions.wf, client);

            var r = await cl.ApiWeatherForecastGetAsync();
            return Ok(r);
        }
    }
}
