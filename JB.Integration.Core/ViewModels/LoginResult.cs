namespace JB.Integration.Core.ViewModels
{
    public class LoginResult
    {
        public string Token { get; set; }
        public bool Success { get { return !string.IsNullOrWhiteSpace(Token); } }
    }
}
