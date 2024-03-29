using MalusAdmin.Servers;

namespace MalusAdmin.WebApi.Controllers
{
    public class SysUserController : ApiControllerBase
    {
        private readonly SysUserService _userService;

        public SysUserController(SysUserService userService)
        {
            _userService = userService;
        }

    }
}
