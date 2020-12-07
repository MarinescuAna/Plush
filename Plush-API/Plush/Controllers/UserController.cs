using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Plush.BusinessLogicLayer.Service.Implementation;
using Plush.BusinessLogicLayer.Service.Interface;
using Plush.DataAccessLayer.Domain.Domain;
using Plush.DataAccessLayer.Domain.Models;
using Plush.Utils;
using System;
using System.Threading.Tasks;

namespace Plush.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        public UserController(IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IUserService user):base(configuration,httpContextAccessor)
        {
            _userService = user;
        }

        [HttpPost]
        [Route("/api/User/Login")]
        public async Task<IActionResult> Login(UserLoginModel credentials)
        {
            if (credentials == null || string.IsNullOrEmpty(credentials.Email))
            {
                return StatusCode(Codes.Number_204, Messages.NoContent_204NoContent);
            }

            User user = await _userService.GetUserByEmailAsync(credentials.Email);

            if (user == null)
            {
                return StatusCode(Codes.Number_404, Messages.NoContent_204NoContent);
            }
            if (user.Password != credentials.Password)
            {
                return StatusCode(Codes.Number_404, Messages.NoContent_204NoContent);
            }

            TokenResponse jWToken = new TokenResponse
            {
                AccessToken = user.AccessToken = GenerateAccessToken( user.Email, user.Role.ToString()),
                AccessTokenExpiration = DateTime.Now.AddMinutes(Codes.Number_2).ToString()
            };

            user.AccessTokenExp = DateTime.Parse(jWToken.AccessTokenExpiration);
            HttpContext.Session.SetString(ConstantString.Token, user.AccessToken);

            if (await _userService.UpdateUserInformationAsync(user)==true)
            {
                return StatusCode(Codes.Number_201, jWToken);
            }

            return StatusCode(Codes.Number_400, Messages.SthWentWrong_400BadRequest);

        }

        [HttpPost]
        [Route("/api/User/Register")]
        public async Task<IActionResult> Register(UserRegisterModel userCredentials)
        {
            if (userCredentials == null || String.IsNullOrEmpty(userCredentials.Email))
            {
                return StatusCode(Codes.Number_204, Messages.NoContent_204NoContent);
            }

            if (await _userService.GetUserByEmailAsync(userCredentials.Email) != null)
            {
                return StatusCode(Codes.Number_409, Messages.AlreadyExist_409Conflict);
            }

            User user = new User
            {
                Email = userCredentials.Email,
                Fullname = userCredentials.Fullname,
                Phone = userCredentials.Phone,
                Birthdate = DateTime.Parse(userCredentials.Birthday),
                Password = userCredentials.Password,
                Address = userCredentials.Address,
                Role = Role.user,
                UserID = Guid.NewGuid()
            };

            TokenResponse jWToken = new TokenResponse();

            user.AccessToken = jWToken.AccessToken = GenerateAccessToken(user.Email, user.Role.ToString());
            user.AccessTokenExp= DateTime.Now.AddHours(Codes.Number_2);
            jWToken.AccessTokenExpiration = DateTime.Now.AddHours(Codes.Number_2).ToString();
            HttpContext.Session.SetString(ConstantString.Token, user.AccessToken);

            if (await _userService.InsertUserAsync(user) == true)
            {
                return StatusCode(Codes.Number_201, jWToken);
            }

            return StatusCode(Codes.Number_400, Messages.SthWentWrong_400BadRequest);
        }

        [HttpPut]
        [Route("/api/User/RefreshToken")]
        public async Task<IActionResult> RefreshToken(string token)
        {
            var user = await _userService.GetUserByEmailAsync(ExtractEmailFromJWT());

            if (user.AccessToken == token)
            {
                return StatusCode(Codes.Number_400, Messages.SthWentWrong_400BadRequest);
            }

            user.AccessToken = GenerateAccessToken(user.Email, user.Role.ToString());
            user.AccessTokenExp = DateTime.Today.AddMinutes(Codes.Number_2);

            if(await _userService.UpdateUserInformationAsync(user) == false)
            {
                return StatusCode(Codes.Number_400, Messages.SthWentWrong_400BadRequest);
            }

            return StatusCode(Codes.Number_201, new TokenResponse
            { 
                AccessToken=user.AccessToken,
                AccessTokenExpiration=user.AccessTokenExp.ToString()
                
            });
        }
    }

 
}