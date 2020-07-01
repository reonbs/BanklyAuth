using System;
using System.Threading.Tasks;
using Bankly.IdentitySvr.Core.Dtos;
using Bankly.IdentitySvr.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bankly.IdentitySvr.Controllers
{
    
    [Route("/api/[controller]")]
    public class UserController:ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]UserReqDto userReqDto)
        {
            try
            {
                var user = await _userService.CreateUser(userReqDto);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
