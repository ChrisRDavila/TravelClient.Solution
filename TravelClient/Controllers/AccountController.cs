using TravelClient.Models;
using TravelClient.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace TravelClient.Controllers
{
  public class ReviewsController : Controller 
  {
    public IActionResult Index()
    {
      return View();
    }
    public ActionResult Register()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Register(RegisterViewModel model)
    {
      if (!ModelState.IsValid)
      {
        return View(model);
      }
      else
      {
        ApplicationUser.RegisterUser(model); 
        // if (result.Succeeded)
        // {
        //   return RedirectToAction("Index", "Home");
        // }
        // else 
        // {
        //   return View(model);
        // }
        return RedirectToAction("Index", "Home");
      }
    }

    public ActionResult SignIn(string userId)
    {
      ApplicationUser user = ApplicationUser.SignInUser(userId);
      return View(user);
    }

    public ActionResult Delete(int id)
    {
      ApplicationUser.DeleteUser(id);
      return RedirectToAction("Index");
    }


    public ActionResult AccessDenied()
    {
      return View();
    }
  }
}
