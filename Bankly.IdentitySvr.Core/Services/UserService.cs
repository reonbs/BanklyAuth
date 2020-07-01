using System;
using System.Linq;
using System.Threading.Tasks;
using Bankly.IdentitySvr.Core.Dtos;
using Bankly.IdentitySvr.Core.Factory;
using Bankly.IdentitySvr.Respository.Models;
using Microsoft.AspNetCore.Identity;

namespace Bankly.IdentitySvr.Core.Services
{
    public interface IUserService
    {
        Task<ExecutionResponse<UserDto>> CreateUser(UserReqDto userReqDto);
    }

    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IResponseService _responseService;

        public UserService(
            UserManager<ApplicationUser> userManager,
            IResponseService responseService
            )
        {
            _userManager = userManager;
            _responseService = responseService;
        }


        public async Task<ExecutionResponse<UserDto>> CreateUser(UserReqDto userReqDto)
        {
            if (userReqDto == null)
                return _responseService.ExecutionResponse<UserDto>("invalid request");


            if (userReqDto == null)
                return _responseService.ExecutionResponse<UserDto>("invalid request");

            var user = new ApplicationUser
            {
                FirstName = userReqDto.FirstName,
                LastName = userReqDto.LastName,
                PhoneNumber = userReqDto.PhoneNumber,
                Email = userReqDto.Email,
                EmailConfirmed = true,
                UserName = userReqDto.Email

            };

            IdentityResult result = await _userManager.CreateAsync(user, userReqDto.Password);

            if (!result.Succeeded)
            {
                var errorMsg = string.Join(",", result.Errors.Select(x => x.Description));
                return _responseService.ExecutionResponse<UserDto>(errorMsg);
            }

            return _responseService.ExecutionResponse<UserDto>("user created successfully",null, true);
        }
    }
}
