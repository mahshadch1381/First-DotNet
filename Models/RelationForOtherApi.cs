namespace testing_easy_db.Models
{
    public interface IRelationForOtherApi
    {
        Task<string> GetSomeDataFromApi(string url);
    }

    public class RelationForOtherApi : IRelationForOtherApi
    {
        private readonly HttpClient _httpClient;

        public RelationForOtherApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7290/api/"); // Set the base address of the external API
        }

        public async Task<string> GetSomeDataFromApi(string url)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
