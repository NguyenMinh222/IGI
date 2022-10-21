using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WEB_053503_NGUYEN2.Entities;
using Microsoft.AspNetCore.Identity;

namespace WEB_053503_NGUYEN2.Controllers
{
    public class ImageController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private IWebHostEnvironment _env;

        public ImageController(UserManager<ApplicationUser> userManager, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _env = env;
        }

        public async Task<FileResult> GetAvatar()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user.AvatarImage != null)
                return File(user.AvatarImage, "image/...");
            else
            {
                //var avatarPath = "/Images/26belorusskiy-pisatel-vladimir-semenovich-korotkevich.jpg";
                var avatarPath = "Images/D0R7CVFWsAUie7y.jpg";
                return File(_env.WebRootFileProvider
                    .GetFileInfo(avatarPath)
                    .CreateReadStream(), "image/...");
            }
        }
    }
}
