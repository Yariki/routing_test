using Microsoft.AspNetCore.Authentication;

namespace WebApiRouting.Authentication
{
    public class WinAuthOptions : AuthenticationSchemeOptions
    {
        public bool AllowAnnonymous { get; set; } = true;
    }
}