namespace Application.Common.Interfaces
{
    public interface IJwtGenerator
    {
        string CreateToken(IApplicationUser user);
    }
}