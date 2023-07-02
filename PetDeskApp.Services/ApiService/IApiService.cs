namespace PetDeskApp.Services.ApiService
{
    public interface IApiService
    {
        Task<T> Request<T>(
            HttpMethod method,
            string endpoint,
            object? body = null,
            Dictionary<string, string>? queryParameters = null
        ) where T : class, new();
    }
}
