namespace JwtApp.Front.Models
{
    public class JwtTokenResponseModel
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
