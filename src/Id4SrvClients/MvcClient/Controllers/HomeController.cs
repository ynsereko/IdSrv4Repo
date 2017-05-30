using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using IdentityModel.Client;
using System.Net.Http;
using Microsoft.AspNetCore.Authentication;
using Newtonsoft.Json.Linq;

namespace MvcClient.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [Authorize]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [Authorize]
        public IActionResult Claims()
        {
            ViewData["Message"] = "Your claims page.";
            var claims = (User as ClaimsPrincipal).Claims;


            return View(claims);
        }

        public IActionResult Error()
        {
            return View();
        }

       // [Authorize(Roles ="api1.read")]
        public async Task<IActionResult> CallApiUsingAccessToken()
        {
            var accessToken = await HttpContext.Authentication.GetTokenAsync("access_token");
            if (!string.IsNullOrWhiteSpace(accessToken))
            {
                var client = new HttpClient();
                client.SetBearerToken(accessToken);
                var response = await client.GetStringAsync("http://localhost:18069/api/identity");
                ViewBag.Json = JArray.Parse(response).ToString();
            }
            return View();

        }
        private async Task<string> RequestClientCredentialsAsync()
        {
            var disco = await DiscoveryClient.GetAsync(@"http://localhost:44322/");
            var tokenClient = new TokenClient(disco.TokenEndpoint, "api1", "superSecretPassword");
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");


            if (tokenResponse.IsError) {return tokenResponse.HttpStatusCode + " : " + tokenResponse.HttpStatusCode; }
            //call api
            var client = new HttpClient();
            client.SetBearerToken(tokenResponse.AccessToken);

            var response = await client.GetAsync("http://localhost:18069/api/identity");

            if (!response.IsSuccessStatusCode) { return response.StatusCode + " : " + response.ReasonPhrase; }
            var content = await response.Content.ReadAsStringAsync();

            return content;
        }
    }
}