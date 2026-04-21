using Perfume.Models;
using Perfume.Services;

namespace Perfume.Services
{
    public interface ITokenService
    {
        string CreateToken(AppUser user, IList<string> roles);
    }
}
