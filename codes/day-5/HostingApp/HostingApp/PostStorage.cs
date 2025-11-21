using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace HostingApp
{
    public class PostStorage : IStorage<Post>
    {
        //public Task<List<Product>> GetDataAsync()
        //{
        //    Task<List<Product>> productTask = Task<Product>.Run(() =>
        //    {
        //        return new List<Product> { new Product { Id = 1, Name = "dell" } };
        //    });
        //    return productTask;
        //}
        private readonly string _url;
        private readonly ILogger<PostStorage> _logger;
        public PostStorage(IOptions<ApiUrl> apiUrl, ILogger<PostStorage> postLogger)
        {
            this._url = apiUrl.Value.Url ?? throw new Exception("url not found");
            _logger = postLogger;
        }

        public async Task<List<Post>> GetDataAsync()
        {
            using HttpClient httpClient = new HttpClient();
            //httpClient.BaseAddress = new Uri(this._url);
            List<Post>? posts = await httpClient.GetFromJsonAsync<List<Post>>(_url);
            _logger.LogInformation($"Count={posts?.Count}");
            return posts ?? new();
        }
    }
}
