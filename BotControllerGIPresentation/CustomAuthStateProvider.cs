using Microsoft.JSInterop;
using System.Security.Claims;
using System.Text.Json;

namespace BotControllerGIPresentation
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly HttpClient _httpClient;
        public CustomAuthStateProvider(IJSRuntime jsRuntime, HttpClient httpClient)
        {
            _jsRuntime = jsRuntime;
            _httpClient = httpClient;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var cookie = await _httpClient.GetStringAsync($"api/User/GetTEST");

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
            if (keyValuePairs != null) 
            {
                return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()!));
            }
            return new List<Claim>();
            
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
