using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using alar.BLL.Interfaces;
using alar.DAL.Classes.UserClasses;
using alar.DAL.Enums;
using alar.WepApi.Models.AppModels;
using alar.WepApi.Models.UserModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace alar.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private IConfiguration configuration;
        public SecurityController(IUnitOfWork _uow, IMapper _mapper, IConfiguration _configuration)
        {
            uow = _uow;
            mapper = _mapper;
            configuration = _configuration;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] UserCreateDataModel model)
        {
            try
            {
                var img = uow.BaseRepositoriys.SaveImage(model.File, "UserImage", "");
                var cusromerUser = mapper.Map<UserClass>(model);
                cusromerUser.CustomerImageMedium = img.ImageMedium;
                cusromerUser.UserImageLarge = img.ImageLarge;
                cusromerUser.UserImageMin = img.ImageMin;
                cusromerUser.UserImageMin = img.ImageMin;
                cusromerUser.UserImageOrjin = img.ImageOrjin;
                await uow.SecurityRepository.AddUser(cusromerUser);
                await uow.SaveChangesAsync();
                return Ok(new ResultModel<int>(_Data:1));
            }
            catch (Exception)
            {
                return Ok(new ResultModel<int>(_Data: 1,_Type:ResultType.danger,_Message:"Hata Oluştu"));
            }
            
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm]LoginModel model)
        {
            try
            {
                var user = await uow.SecurityRepository.Login(model.UserName, model.Password);
                if (user == null)
                    return Unauthorized(new ResultModel<int>(_Data: -1, _Type: ResultType.danger, _Message: "Kullanıcı adı veya şifre hatalı "+DateTime.Now.Second.ToString()));

                var tokenHandler = new JwtSecurityTokenHandler();

                var key = Encoding.ASCII.GetBytes(configuration.GetSection("AppSettings:Token").Value);

                var tokenDecriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim(ClaimTypes.Surname, user.SurName),
                        new Claim(ClaimTypes.Email, user.Email),
                    }),
                    Expires = DateTime.Now.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
                };
                var token = tokenHandler.CreateToken(tokenDecriptor);
                var tokenstring = tokenHandler.WriteToken(token);

                var resultModel = new LoginResultModel()
                {
                    CustomerImageMedium = user.CustomerImageMedium,
                    Email = user.Email,
                    ID = user.ID,
                    Name = user.Name,
                    SurName = user.SurName,
                    Token = tokenstring,
                    UserImageLarge = user.UserImageLarge,
                    UserImageMin = user.UserImageMin,
                    UserImageOrjin = user.UserImageOrjin,
                    CustomerID = user.CustomerID,
                    UserTypes = user.UserTypes,
                };
                return Ok(new ResultModel<LoginResultModel>(_Data: resultModel));
            }
            catch (Exception)
            {
                return Ok(new ResultModel<int>(_Data: -1, _Type: ResultType.danger,_Message:"Giriş İşleminde Bir Hata Oluştu"));
            }
            

        }
    }
}
