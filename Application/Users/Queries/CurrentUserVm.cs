namespace Application.Users.Queries
{
    public class CurrentUserVm
    {
        public string Username { get; set; }
        public string Token { get; set; }
        #nullable enable
        public string? Error { get; set; }
        #nullable disable
    }
}