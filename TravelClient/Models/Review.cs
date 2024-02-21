using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TravelClient.Models;

public class Review
{
    public int ReviewId { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public int Rating { get; set; }
    public string Description { get; set; }
    public int UserId { get; set; }

    public static List<Review> GetReviews()
    {
        var apiCallTask = ApiHelper.GetAll();
        var result = apiCallTask.Result;

        JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
        List<Review> reviewList = JsonConvert.DeserializeObject<List<Review>>(jsonResponse.ToString());

        return reviewList;
    }

    public static Review GetDetails(int id)
    {
        var apiCallTask = ApiHelper.GetDetails(id);
        var result = apiCallTask.Result;

        JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
        Review review = JsonConvert.DeserializeObject<Review>(jsonResponse.ToString());

        return review;
    }

    public static void Post(Review review)
    {
        string jsonReview = JsonConvert.SerializeObject(review);
        ApiHelper.Put(review.ReviewId, jsonReview);
    }

    public static void Put(Review review)
    {
        string jsonReview = JsonConvert.SerializeObject(review);
        ApiHelper.Put(review.ReviewId, jsonReview);
    }

    public static void Delete(int id)
    {
        ApiHelper.Delete(id);
    }

    public static void Patch(int id, Review patchedReview)
    {
        string jsonReview = JsonConvert.SerializeObject(patchedReview);
        ApiHelper.Patch(patchedReview.ReviewId, jsonReview);
    }

}