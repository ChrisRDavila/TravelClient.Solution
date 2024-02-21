using Microsoft.AspNetCore.Mvc;
using TravelClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;
using System.Diagnostics;


namespace TravelClient.Controllers;

public class ReviewsController : Controller 
{
  // public IActionResult Index()
  // {
  //   List<Review> reviews = Review.GetReviews();
  //   return View(reviews);
  // }

  public async Task<IActionResult> Index(int page = 1)
  {
    // Review review = new Review();
    List<Review> reviewList = new List<Review> { };
    ReviewPage reviewPage = new() { };
    using (var httpClient = new HttpClient())
    {
      using (var response = await httpClient.GetAsync($"http://localhost:5232/api/v1/reviews?page={page}"))
      // &pagesize={pageSize}
      {
        var reviewContent = await response.Content.ReadAsStringAsync();
        JArray reviewArray = JArray.Parse(reviewContent);
        reviewList = reviewArray.ToObject<List<Review>>();
        reviewPage.ReviewPages = reviewList;
        reviewPage.Page = page;
      }
    }
    

    // ViewBag.TotalPages = reviewList.Count();
    //page number inside the url
    // ViewBag.CurrentPage = page;
    //amnt of items on the page
    // ViewBag.PageSize = pageSize;
    //the amount of destinations returned from our database
    // ViewBag.Pages = pageCount;

    return View(reviewPage);
  }

  public IActionResult Details(int id)
  {
    Review review = Review.GetDetails(id);
    return View(review);
  }

  public ActionResult Create()
  {
    return View();
  }

  [HttpPost]
  public ActionResult Create(Review review)
  {
    Review.Post(review);
    return RedirectToAction("Index");
  }

  public ActionResult Edit(int id)
  {
    Review review = Review.GetDetails(id);
    return View(review);
  }

  [HttpPost]
  public ActionResult Edit(Review review)
  {
    Review.Put(review);
    return View(review);
  }

  public ActionResult Delete(int id)
  {
    Review review = Review.GetDetails(id);
    return View(review);
  }

  [HttpPost, ActionName("Delete")]
  public ActionResult DeleteConfirmed(int id)
  {
    Review.Delete(id);
    return RedirectToAction("Index");
  }
}