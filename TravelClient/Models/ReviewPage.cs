namespace TravelClient.Models;

public class ReviewPage 
{
    public List<Review> ReviewPages { get; set; }
    public int Page { get; set;}
    public int CurrentPage { get; set; }
}