using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ASPNETCoreWebApiGestionRecursos.Services;
using ASPNETCoreWebApiORAGestionRecursos.Models;

namespace ASPNETCoreWebApiGestionRecursos.Controllers
{
    [Authorize] [ApiController] [Route("Api/[controller]/[action]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService) {
            _userService = userService;
        }

        //POST: https://localhost:5001/Api/Users/Authenticate
        [AllowAnonymous] [HttpPost] [ActionName("Authenticate")]
        public IActionResult Authenticate([FromBody] Empleado userParam) {
            string token = _userService.Authenticate(userParam.id_empleado);
            if (token == null)
                return BadRequest(new { message = "Id Incorrect" });
            return Ok(token);
        }
    }
}