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
        var apiCallTask = APiHelper.GetAll();
        var result = apiCallTask.Result;

        JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
        List<Review> reviewList = JsonConvert.DeserializeObject<List<Review>>(jsonResponse.ToString());

        return reviewList;
    }

    public static Review GetDetails(int id)
    {
        var apiCallTask = APiHelper.GetDetails(id);
        var result = apiCallTask.Result;

        JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
        Review review = JsonConvert.DeserializeObject<Review>(jsonResponse.ToString());

        return review;
    }

    public static void Post(Review review)
    {
        string jsonReview = JsonConvert.SerializeObject(review);
        APiHelper.Put(review.ReviewId, jsonReview);
    }

    public static void Delete(int id)
    {
        APiHelper.Delete(id);
    }

    public static void Patch(int id, Review patchedReview)
    {
        string jsonReview = JsonConvert.SerializeObject(patchedReview);
        APiHelper.Patch(patchedReview.ReviewId, jsonReview);
    }

}