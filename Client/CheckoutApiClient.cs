using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CheckoutApi.Integration.Client
{
    public interface ICheckoutApiClient
    {
        Task<string> Get(string path);
        Task<HttpResponseMessage> Post(string path, HttpContent payload);
    }

    /// <summary>
    /// Class <c>CheckoutApiClient</c> Connection 2checkout Client
    /// </summary>
    public abstract class CheckoutApiClient : ICheckoutApiClient
    {
        public HttpClient Client { get; private set; }

        protected string ApiEndpoint;

        protected string MerchantCode;

        protected string MerchantSecret;

        protected Authenticator Authenticator;

        public CheckoutApiClient(string apiEndpoint, string merchantCode, string merchantSecret, HttpClient httpClient)
        {
            ApiEndpoint = apiEndpoint;
            MerchantCode = merchantCode;
            MerchantSecret = merchantSecret;
            this.Authenticator = new Authenticator(merchantCode, MerchantSecret);

            httpClient.BaseAddress = new Uri(ApiEndpoint);
            httpClient.DefaultRequestHeaders.Add("X-Avangate-Authentication", this.Authenticator.GetAuthToken());
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client = httpClient;
        }

        public async Task<string> Get(string path)
        {
            return await Client.GetStringAsync(path);
        }

        public async Task<HttpResponseMessage> Post(string path, HttpContent payload)
        {
            return await Client.PostAsync(path, payload);
        }
    }
}
