using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Text;

namespace PetDeskApp.Services.ApiService
{
    public abstract class ApiService : IApiService
    {
        protected readonly HttpClient HttpClient;

        public ApiService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<T> Request<T>(
            HttpMethod method, 
            string endpoint, 
            object? body = null, 
            Dictionary<string, string>? queryParameters = null
        ) where T : class, new()
        {
            if (queryParameters != null)
                endpoint = QueryHelpers.AddQueryString(endpoint, queryParameters);

            HttpContent? content = null;
            if (body != null)
                content = new StringContent(
                    JsonConvert.SerializeObject(body),
                    Encoding.UTF8,
                    "application/json"
                );

            HttpResponseMessage? response = null;
            if (method == HttpMethod.Get)
                response = await HttpClient.GetAsync(endpoint);

            else if (method == HttpMethod.Post)
                response = await HttpClient.PostAsync(endpoint, content);

            else if (method == HttpMethod.Put)
                response = await HttpClient.PutAsync(endpoint, content);

            else if (method == HttpMethod.Patch)
                response = await HttpClient.PatchAsync(endpoint, content);

            else if (method == HttpMethod.Delete)
                response = await HttpClient.DeleteAsync(endpoint);

            else
                throw new ApplicationException("Invalid HttpMethod");

            return await HandleResponse<T>(response);
        }

        private async Task<T> HandleResponse<T>(HttpResponseMessage response) where T : class, new()
        {
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                T? typedResponse = JsonConvert.DeserializeObject<T>(responseBody);
                if (typedResponse == null)
                    throw new ApplicationException("Invalid Response");

                return typedResponse;
            }
            else
                throw new ApplicationException($"Unable to make request! {response.StatusCode}: {response.ReasonPhrase}");
        }
    }
}
