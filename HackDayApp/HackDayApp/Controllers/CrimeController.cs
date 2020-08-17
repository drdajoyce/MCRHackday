using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace HackDayApp.Controllers
{
    public class CrimeController :Controller
    {

        public IActionResult GetCrimes(string latitude, string longitude)
        {
        CrimeList model = new CrimeList();
        var client = new HttpClient();
            var task = client.GetAsync($"https://data.police.uk/api/crimes-street/all-crime?lat={latitude}&lng={longitude}&date=2020-06")
              .ContinueWith((taskwithresponse) =>
          {
              var response = taskwithresponse.Result;
              var jsonString = response.Content.ReadAsStringAsync();
              jsonString.Wait();
              model.crimes = JsonSerializer.Deserialize<List<Crime>>(jsonString.Result);
              model.centralLatitude = latitude;
              model.centralLongitude = longitude;
          });
        task.Wait();

            return View(model);
        }

    }
}
