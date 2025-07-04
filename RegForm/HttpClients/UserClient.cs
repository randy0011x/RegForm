using RegForm.Models;
using System.Net.Http;
namespace RegForm.HttpClients
{
    public class UserClient
    {
      HttpClient _httpClient;
            public UserClient(HttpClient httpClient)
            {
                _httpClient = httpClient;
            }
        public async Task<IEnumerable<UserModel>> GetUsersAsync()
            {
                var response = await _httpClient.GetAsync("/api/customer/getusers");
                response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<UserModel>>();



        }

    }
}
