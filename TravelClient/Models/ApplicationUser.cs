using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using TravelClient.ViewModels;

namespace TravelClient.Models;

public class ApplicationUser : IdentityUser
{
    public static ApplicationUser SignInUser(string _userId) {
        var apiCallTask = ApiHelper.SignInUser(_userId);
        var result = apiCallTask.Result;

        JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
        ApplicationUser user = JsonConvert.DeserializeObject<ApplicationUser>(jsonResponse.ToString());

        return user;

    }

    public static List<ApplicationUser> GetUsers()
    {
        var apiCallTask = ApiHelper.GetAll();
        var result = apiCallTask.Result;

        JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
        List<ApplicationUser> userList = JsonConvert.DeserializeObject<List<ApplicationUser>>(jsonResponse.ToString());

        return userList;
    }

    public static async void RegisterUser(RegisterViewModel user)
    {
      string jsonUser = JsonConvert.SerializeObject(user);
      await ApiHelper.RegisterUser(jsonUser);
    }

    public static void DeleteUser(int _userId)
    {
      ApiHelper.Delete(_userId);
    }
}