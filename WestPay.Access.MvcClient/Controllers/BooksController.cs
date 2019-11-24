using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WestPay.Access.MvcClient.Dtos.Books;
using WestPay.Access.MvcClient.Models;
using WestPay.Access.MvcClient.Services;

namespace WestPay.Access.MvcClient.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private readonly IAccessHttpClient _accessHttpClient;

        public BooksController(IAccessHttpClient accessHttpClient)
        {
            _accessHttpClient = accessHttpClient;
        }
        public async Task<IActionResult> Index()
        {
            var httpClient = await _accessHttpClient.GetClient();

            var response = await httpClient.GetAsync("api/books").ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var bookAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var bookIndexViewModel = new BookIndexViewModel(JsonConvert.DeserializeObject<IList<Book>>(bookAsString).ToList());

                return View(bookIndexViewModel);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                return RedirectToAction("AccessDenied", "Authorization");
            }
            throw new Exception($"An error occure while calling the API: { response.ReasonPhrase }");
        }
    }
}
