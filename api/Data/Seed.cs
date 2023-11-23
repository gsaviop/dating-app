using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using api.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Data;

public class Seed
{
    public static async Task SeedUsers(DataContext context)
    {
        if (await context.Users.AnyAsync()) return;

        var userData = await File.ReadAllTextAsync("Data/userseed.json");
        var options = new JsonSerializerOptions{PropertyNameCaseInsensitive = true};
    
        var users = JsonSerializer.Deserialize<List<AppUser>>(userData, options);

        foreach(var user in users)
        {
            using var hmac = new HMACSHA512();
            
            user.UserName = user.UserName.ToLower();
            //im only making this the password because these are users made from seed data 
            //so it doesnt matter if they use the password 
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("s3Nh4123"));
            user.PasswordSalt = hmac.Key;

            context.Users.Add(user);
        }

        await context.SaveChangesAsync();
    }
}
