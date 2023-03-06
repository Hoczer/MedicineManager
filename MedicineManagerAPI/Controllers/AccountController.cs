using Microsoft.AspNetCore.Mvc;
using MedicineManagerAPI.Service;
using MedicineManagerAPI.Models;

namespace MedicineManagerAPI.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody] RegisterUserDto dto)
        {
            _accountService.RegisterUser(dto);
            return Ok();
        }
        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginDto dto)
        {
            var logedUser = _accountService.LoginUser(dto);
            return Ok(logedUser);
        }
    }
}

