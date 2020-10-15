///////////////////////////////////////////////////////////////////
//
// MINIMO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using $safeprojectname$.Models.Api.RestCountries;

namespace $safeprojectname$.Controllers
{
    public class ApiController : Controller
    {
        /// <summary>
        /// Sample list of countries in the world
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Countries()
        {
            var url = "https://restcountries.eu/rest/v2/all";

            // Prepare the call
            var client = new HttpClient();
            var json = await client.GetStringAsync(url);
            var list = JsonConvert.DeserializeObject<IList<CountryContainer>>(json); 

            return Json(list);
        }
    }
}