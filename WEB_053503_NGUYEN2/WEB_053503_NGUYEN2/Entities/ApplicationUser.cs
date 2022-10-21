using Microsoft.AspNetCore.Identity;

namespace WEB_053503_NGUYEN2.Entities
{
    public class ApplicationUser:IdentityUser
    {
        public byte[] AvatarImage { get; set;}
    }
}
