using Models.OnlineShop;
using RestSharp;
using Services.Abstraction;

namespace Services.Implementation;

public class UserService: IUserService
{
    public async Task<List<User>> GetAllUsersAsync()
    {
        var restClient = new RestClient();
        await CallApiAndSaveResult(restClient, "http://localhost:3001/api/users", "a.json");
        return new List<User>();
    }
    static async Task CallApiAndSaveResult(RestClient restClient, string apiUrl, string fileName)
    {
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        try
        {
            var request = new RestRequest(apiUrl, Method.Get);
            var response = await restClient.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                var content = response.Content;
                File.WriteAllText(fileName, content);
            }
            else
            {
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        finally
        {
            stopwatch.Stop();
        }
    }
}