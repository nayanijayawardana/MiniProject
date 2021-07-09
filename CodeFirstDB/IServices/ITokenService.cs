using CodeFirstDB.ViewModle;

namespace CodeFirstDB.IServices
{
    public interface ITokenService
    {
        string CreateToken(ApplicationUser appicationUser);
    }
}
