using Microsoft.AspNetCore.Mvc;
using TravelClient.Models;

namespace TravelCLient.Controllers;

public class ReviewsController : Controller 
{
  public IActionResult Index()
  {
    List<Review> Reviews = Review.GetReviews();
  }  
}