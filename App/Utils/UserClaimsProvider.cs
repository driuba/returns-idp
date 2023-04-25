using System.Security.Claims;
using OrchardCore.Users;
using OrchardCore.Users.Models;
using OrchardCore.Users.Services;

namespace App.Utils;

public class UserClaimsProvider : IUserClaimsProvider
{
    private const string _customerIdPath = "Properties.CustomerId.UserProfile.CustomerId.Text";

    public Task GenerateAsync(IUser user, ClaimsIdentity claims)
    {
        if (user is not User userCurrent)
        {
            return Task.CompletedTask;
        }

        var customerId = userCurrent.Properties["CustomerId"]?["CustomerId"]?["CustomerId"]?["Text"]?.ToObject<string>();

        if (!string.IsNullOrEmpty(customerId))
        {
            claims.AddClaim(new Claim("customer_id", customerId));
        }

        return Task.CompletedTask;
    }
}
