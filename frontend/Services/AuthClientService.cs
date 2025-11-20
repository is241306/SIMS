using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace frontend.Services {
    public class AuthClientService {
        private readonly IJSRuntime _js;
        private const string TokenKey = "authToken";
        private const string UsernameKey = "authUsername";
        private const string RoleKey = "authRole";

        public string? Token { get; private set; }
        public string? Username { get; private set; }
        public string? Role { get; private set; }

        public bool IsAuthenticated => !string.IsNullOrEmpty(Token);

        public AuthClientService(IJSRuntime js) {
            _js = js;
        }
        
        public async Task InitializeAsync() {
            Token = await _js.InvokeAsync<string?>("auth.getToken");
            Username = await _js.InvokeAsync<string?>("auth.getUsername");
            Role = await _js.InvokeAsync<string?>("auth.getRole");
        }

        public async Task SetLoginAsync(string token, string username, string role) {
            Token = token;
            Username = username;
            Role = role;

            await _js.InvokeVoidAsync("auth.save", token, username, role);
        }

        public async Task LogoutAsync() {
            Token = null;
            Username = null;
            Role = null;

            await _js.InvokeVoidAsync("auth.clear");
        }
    }
}