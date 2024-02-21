using System.Threading.Tasks;
using RestSharp;

namespace TravelClient.Models
{
  public class ApiHelper
  {
    public static async Task<string> GetAll()
    {
      RestClient client = new RestClient("http://localhost:5232/");
      RestRequest request = new RestRequest($"api/v1/reviews", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

    public static async Task<string> GetDetails(int id)
    {
      RestClient client = new RestClient("http://localhost:5232/");
      RestRequest request = new RestRequest($"api/v1/reviews/{id}", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

    public static async void Post(string newReview)
    {
      RestClient client = new RestClient("http://localhost:5232/");
      RestRequest request = new RestRequest($"api/v1/reviews", Method.Post);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newReview);
      await client.PostAsync(request);
    }

    public static async void Put(int id, string newReview)
    {
      RestClient client = new RestClient("http://localhost:5232/");
      RestRequest request = new RestRequest($"api/v1/reviews/{id}", Method.Put);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newReview);
      await client.PutAsync(request);
    }

    public static async void Delete(int id)
    {
      RestClient client = new RestClient("http://localhost:5232/");
      RestRequest request = new RestRequest($"api/v1/reviews/{id}", Method.Delete);
      request.AddHeader("Content-Type", "application/json");
      await client.DeleteAsync(request);
    }

    public static async void Patch(int id, string newReview)
    {
      RestClient client = new RestClient("http://localhost:5232/");
      RestRequest request = new RestRequest($"api/reviews/{id}", Method.Patch);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newReview);
      await client.PatchAsync(request);
    }

    public static async Task<string> SignInUser(string _userId)
    {
      RestClient client = new RestClient("http://localhost:5232/");
      RestRequest request = new RestRequest($"api/v1/accounts/SignIn/{_userId}", Method.Get);
      //not sure if need to tack on {userId} and should we remove v1?
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

    public static async Task<string> RegisterUser(string user)
    {
      RestClient client = new RestClient("http://localhost:5232/");
      RestRequest request = new RestRequest($"api/v1/accounts/Register", Method.Post);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(user);
      RestResponse response = await client.PostAsync(request);
      return response.Content;
    }

    public static async Task<string> GetAllUsers()
    {
      RestClient client = new RestClient("http://localhost:5232/");
      RestRequest request = new RestRequest($"api/v1/accounts", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

    public static async void DeleteUser(int _userId)
    {
      RestClient client = new RestClient("http://localhost:5232/");
      RestRequest request = new RestRequest($"api/v1/accounts/{_userId}", Method.Delete);
      request.AddHeader("Content-Type", "application/json");
      await client.DeleteAsync(request);
    }
  }
}