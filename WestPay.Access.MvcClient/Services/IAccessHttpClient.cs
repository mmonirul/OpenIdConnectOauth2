using System.Net.Http;
using System.Threading.Tasks;

namespace WestPay.Access.MvcClient.Services
{
    public interface IAccessHttpClient
    {
        Task<HttpClient> GetClient();
    }
}