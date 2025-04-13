using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TrendyT.Data.Entities;
using TrendyT.DTO;

namespace TrendyT.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;


        public AuthenticationController(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, IMapper mapper,
            SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _configuration = configuration; _mapper = mapper;
        }
        [HttpPost]
        public async Task<ApiResponse> Register([FromBody] UserDTO userDTO, [FromQuery] string role)
        {
            ApiResponse apiResponse = new ApiResponse();

            //Check User Exist 
            var userExist = await _userManager.FindByEmailAsync(userDTO.Email);
            if (userExist != null)
            {
                return new ApiResponse ( null, "User already exists!",false);
            }
            try
            {
                //Add the User in the database
                ApplicationUser user = new()
                {
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName,
                    Gender = userDTO.Gender,
                    MobileNumber = userDTO.MobileNumber,
                    Email = userDTO.Email,
                    Address = _mapper.Map<Address>(userDTO.Address),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = userDTO.FirstName + "_" + userDTO.LastName
                };

                if (await _roleManager.RoleExistsAsync(role))
                {
                    var result = await _userManager.CreateAsync(user, userDTO.Password);
                    if (!result.Succeeded)
                    {
                        return new ApiResponse(null, "User Failed to Create", false);
                    }
                    //Add role to the user....
                    //Add role to the user....
                    await _userManager.AddToRoleAsync(user, role);
                    return new ApiResponse(null, "User created successfully...", true);

                }
            }
            catch (Exception ee)
            {
                apiResponse= new ApiResponse (null,ee.Message,false);
            }
            return apiResponse;


        }
        [HttpPost]
        public async Task<ApiResponse> CheckLogin([FromBody] List<string> userData)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                //Check User Exist 
                var user = await _userManager.FindByEmailAsync(userData.First());
                if (user == null)
                {
                    return new ApiResponse(null, "Wrong Email!", false);
                }
                if (user != null && await _userManager.CheckPasswordAsync(user, userData.Last()))
                {
                    var authClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    };
                    var userRoles = await _userManager.GetRolesAsync(user);
                    foreach (var role in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, role));
                    }

                    var jwtToken = GetToken(authClaims);
                    apiResponse = new ApiResponse(null, new JwtSecurityTokenHandler().WriteToken(jwtToken), true);

                }
            }
            catch (Exception ee)
            {
                apiResponse = new ApiResponse(null, ee.Message, false);

            }
           
            return apiResponse;
        }
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

    }
}
