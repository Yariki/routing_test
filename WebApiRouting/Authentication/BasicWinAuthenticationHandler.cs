using System;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace WebApiRouting.Authentication
{
    public class BasicWinAuthenticationHandler : AuthenticationHandler<WinAuthOptions>
    {
        [System.Runtime.InteropServices.DllImport("advapi32.dll")]
        private static extern bool LogonUser(string userName, string domainName, string password, int LogonType, int LogonProvider, ref IntPtr phToken);

        
        private const string AuthorizationHeaderName = "Authorization";
        private const string BasicSchemeName = "Basic";
        
        public BasicWinAuthenticationHandler(IOptionsMonitor<WinAuthOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            
            if (!Request.Headers.ContainsKey(AuthorizationHeaderName) && !Options.AllowAnnonymous)
            {
                return AuthenticateResult.Fail("There is no Authentication information.");
            }

            if (!AuthenticationHeaderValue.TryParse(Request.Headers[AuthorizationHeaderName],
                out AuthenticationHeaderValue headerValue) && !Options.AllowAnnonymous)
                
            {
                return AuthenticateResult.Fail("There is no Authentication information.");
            }
            
            if(!BasicSchemeName.Equals(headerValue.Scheme,StringComparison.OrdinalIgnoreCase) && !Options.AllowAnnonymous)
            {
                return AuthenticateResult.Fail("The Authentication scheme is wrong.");
            }

            byte[] headerValueBytes = Convert.FromBase64String(headerValue.Parameter);
            var userAndPassword = Encoding.UTF8.GetString(headerValueBytes);
            var parts = userAndPassword.Split(':');
            if (parts.Length != 2)
            {
                return AuthenticateResult.Fail("Invalid Basic authentication header");
            }

            var user = parts[0];
            var password = parts[1];

            var credentionals = IsValidCred(user, password, ".");

            if (!credentionals.Item1)
            {
                return AuthenticateResult.Fail("Invalid User name or Password");
            }

            var claims = new[] {new Claim(ClaimTypes.Name, user)};
            var winUser = new WindowsIdentity(credentionals.Item2);
            var identity = new ClaimsIdentity(claims,Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal,Scheme.Name);
            
            return AuthenticateResult.Success(ticket);


        }

        private (bool,IntPtr) IsValidCred(string user, string password, string domain)
        {
            var token = IntPtr.Zero;
            var result = LogonUser(user, domain, password, 3, 0, ref token);

            if (!result)
            {
                var err = Marshal.GetLastWin32Error();
                throw new System.ComponentModel.Win32Exception(err);
            }
            
            return (result, token);
        }
        
    }
}