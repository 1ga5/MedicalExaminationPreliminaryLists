using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;

namespace MedicalExaminationPreliminaryLists.UI
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _http;

        public CustomAuthStateProvider(ILocalStorageService localStorage, HttpClient http)
        {
            _localStorage = localStorage;
            _http = http;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string token = await _localStorage.GetItemAsStringAsync("token");

            var identity = new ClaimsIdentity();
            _http.DefaultRequestHeaders.Authorization = null;

            if (!string.IsNullOrEmpty(token))
            {
                try
                {
                    identity = (ClaimsIdentity)ValidateToken(token.Replace("\"", "")).Identity;

                    _http.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", token.Replace("\"", ""));
                }
                catch
                {
                    identity = new ClaimsIdentity();
                }
            }

            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);

            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;
        }

        public static ClaimsPrincipal ValidateToken(string jwt)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Jj2N0agh4jkS862Lh64s70ahhgfDFFGDFg456wP54yewf")),
                ValidateIssuer = true,
                ValidIssuer = "https://localhost:5260",
                ValidateAudience = true,
                ValidAudience = "https://localhost:5260",
                ValidateLifetime = true, 
                ClockSkew = TimeSpan.Zero 
            };

            var principal = tokenHandler.ValidateToken(jwt, validationParameters, out _);
            return principal;
        }
    }
}
