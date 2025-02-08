using Microsoft.JSInterop;
using System.Net.Http;
using System.Security.Claims;
using System.Text.Json;

namespace BotControllerGIPresentation
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly IJSRuntime _jsRuntime;
        public CustomAuthStateProvider(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var cookie = await _jsRuntime.InvokeAsync<string>("eval", "document.cookie");

            ClaimsIdentity identity;

            if (!string.IsNullOrEmpty(cookie))
            {
                identity = new ClaimsIdentity(ParseClaimsFromJwt(cookie), "jwt");
            }
            else
            {
                identity = new ClaimsIdentity();
            }

            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);

            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;
        }
        public AuthenticationState AuthenticationStateAsync(string cookie)
        {
            ClaimsIdentity identity;

            if (!string.IsNullOrEmpty(cookie))
            {
                identity = new ClaimsIdentity(ParseClaimsFromJwt(cookie), "jwt");
            }
            else
            {
                identity = new ClaimsIdentity(); 
            }

            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);

            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;
        }

        public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}
