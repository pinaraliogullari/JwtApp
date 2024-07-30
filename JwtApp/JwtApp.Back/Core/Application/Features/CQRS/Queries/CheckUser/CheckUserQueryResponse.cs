namespace JwtApp.Back.Core.Application.Features.CQRS.Queries.CheckUser
{
    public class CheckUserQueryResponse
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Role { get; set; }
        public bool IsExist { get; set; }
    }
}
