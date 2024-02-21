using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

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

    public static async void Register(ApplicationUser user)
    {
        string jsonUser = JsonConvert.SerializeObject(user);
        await ApiHelper.Post(jsonUser);
    }

    public static void DeleteUser(int _userId)
    {
        ApiHelper.Delete(_userId);
    }
}