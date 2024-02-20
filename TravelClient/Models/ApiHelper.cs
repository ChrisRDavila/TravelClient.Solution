using System.Threading.Tasks;
using RestSharp;

namespace TravelClient.Models
{
  public class APiHelper
  {
    public static async Task<string> GetAll()
    {
      RestClient client = new RestClient("http://localhost:5232/");
      RestRequest request = new RestRequest($"api/reviews", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

    public static async Task<string> GetDetails(int id)
    {
      RestClient client = new RestClient("http://localhost:5232/");
      RestRequest request = new RestRequest($"api/reviews/{id}", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

    public static async Task Post(string newReview)
    {
      RestClient client = new RestClient("http://localhost:5232/");
      RestRequest request = new RestRequest($"api/reviews", Method.Post);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newReview);
      await client.PostAsync(request);
    }

    public static async void Put(int id, string newReview)
    {
      RestClient client = new RestClient("http://localhost:5232/");
      RestRequest request = new RestRequest($"api/reviews/{id}", Method.Put);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newReview);
      await client.PutAsync(request);
    }

    public static async void Delete(int id)
    {
      RestClient client = new RestClient("http://localhost:5232/");
      RestRequest request = new RestRequest($"api/reviews/{id}", Method.Delete);
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
  }
}