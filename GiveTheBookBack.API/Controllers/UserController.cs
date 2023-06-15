using AutoMapper.Configuration.Annotations;
using GiveTheBookBack.Application.Interface;
using GiveTheBookBack.Application.ViewModel;
using GiveTheBookBack.Domain.Enums;
using GiveTheBookBack.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace GiveTheBookBack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _config;

        public UserController(IUserService service, IConfiguration config)
        {
            _userService = service;
            _config = config;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            var success = _userService.Authenticate(loginModel);

            if(success)
            {
                var tokenString = GenerateJsonWebToken(loginModel);
                return Ok(new { token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }

        private string GenerateJsonWebToken(LoginModel loginModel)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Issuer"], null, expires: DateTime.Now.AddMinutes(60), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost("Registration")]
        public IActionResult Registration(NewUserVm newUser)
        {
            var result = _userService.Registration(newUser);
            if(result == RegistrationResult.UserAdded)
            {
                return Ok();
            }
            else
            {
                return Forbid();                
            }
        }

        [HttpGet("Address/{id}")]
        public ActionResult<AddressForEditVm> GetAddressForEdit(int id)
        {
            var address = _userService.GetAddressForEdit(id);
            if(address != null)
            {
                return Ok(address);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("Address")]
        public IActionResult AddAdress(NewAddressVm newAddressVm)
        {
            _userService.AddAddress(newAddressVm);
            return Ok();
        }

        [HttpPatch("Address")]
        public IActionResult EditAddress(AddressForEditVm addressVm)
        {
            _userService.EditAddress(addressVm);
            return Ok();
        }
    }
}
