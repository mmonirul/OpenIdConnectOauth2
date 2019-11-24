using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WestPay.Access.MvcClient.Models;

namespace WestPay.Access.MvcClient.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            await WriteOutIdentityInformation();

            var userInfoResponse = await GetUserInfo();

            var address = userInfoResponse.Claims.FirstOrDefault(c => c.Type == "address")?.Value;

            return View();
        }

        private async Task<UserInfoResponse> GetUserInfo()
        {
            using (var client = new HttpClient())
            {
                var disco = await client.GetDiscoveryDocumentAsync("https://localhost:44346/");
                var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);

                var response = await client.GetUserInfoAsync(new UserInfoRequest
                {
                    Address = disco.UserInfoEndpoint,
                    Token = accessToken
                });

                if (response.IsError)
                {
                    throw new System.Exception("Problem accessing the userinfo endpoint", response.Exception);
                }

                return response;
            };
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize(Roles ="admin")]
        public IActionResult Secure()
        {
            return View();
        }

        //public IActionResult Logout()
        //{
        //    //return new SignOutResult(new string[] { "oidc", "Cookies" });
        //}
        public async Task Logout()
        {
            await HttpContext.SignOutAsync("Cookies");
            await HttpContext.SignOutAsync("oidc");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task WriteOutIdentityInformation()
        {
            var identityToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken);

            Debug.WriteLine($"Identity token: {identityToken}");
            foreach (var claim in User.Claims)
            {
                Debug.WriteLine($"Cliam type: {claim.Type} - Claim value: {claim.Value}");
            }
        }
    }
}
