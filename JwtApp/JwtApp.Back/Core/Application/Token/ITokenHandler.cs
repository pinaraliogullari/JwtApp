namespace JwtApp.Back.Core.Application.Token
{
    public interface ITokenHandler
    {
      DTOs.Token CreateAccessToken(int minute);
    }
}
