using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ASPNETCoreWebApiGestionRecursos.Services;
using ASPNETCoreWebApiORAGestionRecursos.Models;
using System.Threading.Tasks;

namespace ASPNETCoreWebApiGestionRecursos.Controllers
{
    [ApiController] [Route("Api/[controller]/[action]")]
    public class UsersController : ControllerBase
    {
        private IUserService userService;

        public UsersController(IUserService userService) {
            this.userService = userService;
        }

        //POST: https://localhost:5001/Api/Users/GetTokenAuthentication/
        [HttpPost] [ActionName("GetTokenAuthentication")]
        public Task<string> TokenAuthentication([FromBody] Empleado user) {
            string token = userService.GetTokenAuthentication(user.id_empleado);
            if (token == null)
                return Task.FromResult("Id Incorrect.");
            return Task.FromResult(token);
        }
    }
}