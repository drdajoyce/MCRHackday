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
        public IActionResult GetCrimes()
        {
        List<Crime> model = null;
        var client = new HttpClient();
        var task = client.GetAsync("https://data.police.uk/api/crimes-at-location?date=2020-03&lat=52.629729&lng=-1.131592")
          .ContinueWith((taskwithresponse) =>
          {
              var response = taskwithresponse.Result;
              var jsonString = response.Content.ReadAsStringAsync();
              jsonString.Wait();
              model = JsonSerializer.Deserialize<List<Crime>>(jsonString.Result);
          });
        task.Wait();

            return View(model);
        }

    }
}
