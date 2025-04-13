using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrendyT.DTO;
using TrendyT.Services.Interfaces;
using TrendyT.Services.ServiceClasses;

namespace TrendyT.Controllers
{
    [Authorize(Roles ="Admin")]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {

            _userService = userService;

        }
        [HttpPost]
        public async Task<ApiResponse> User([FromBody] UserDTO userDTO)
        {
            var result=await _userService.AddUser(userDTO);
            return result;
        }
        
        [HttpDelete]
        public async Task<ApiResponse> User([FromQuery] string userId)
        {

            return  await _userService.DeleteUser(userId);
        }
        [HttpPost]
        public async Task<ApiResponse> CheckLogin([FromBody] List<string> userData)
        {
            var result = await _userService.CheckLogin(userData.First(),userData.Last());
            return result;
        }
        [HttpGet]
        public async Task<ApiResponse> GetAllUsers()
        {
            var result = await _userService.GetAllUsers();
            return result;
        }

        [HttpGet]
        public async Task<ApiResponse> GetUsersPagedAsync(int pageIndex=0,int pageSize=10,string orderBy="",bool orderByAsc=true,string searchTerm="")
        {
            var result = await _userService.GetUsersPagedAsync(pageIndex,pageSize,orderBy,orderByAsc,searchTerm);
            return result;
        }
        [HttpPut]
        public async Task<ApiResponse> UpdateUser([FromBody] UserDTO userDTO)
        {
            var result = await _userService.UpdateUser(userDTO);
            return result;
        }
    }
}
