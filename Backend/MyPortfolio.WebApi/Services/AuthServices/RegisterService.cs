using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MyPortfolio.WebApi.Entites.Identity;

namespace MyPortfolio.WebApi.Services.AuthServices
{
    public class RegisterService : IRegisterService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;
        public RegisterService(UserManager<User> userManager, RoleManager<Role> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task Register(RegisterModel registerModel)
        {
            User user = new User()
            {
                FullName = registerModel.Email,
                UserName = registerModel.FullName,
                Email = registerModel.Email,
                PasswordHash = registerModel.Password
            };
            user.UserName = registerModel.Email;
            user.SecurityStamp = Guid.NewGuid().ToString();

            IdentityResult identityResult = await _userManager.CreateAsync(user,registerModel.Password);
            if (identityResult.Succeeded)
            {
                if(!await _roleManager.RoleExistsAsync("Admin"))
                {
                    await _roleManager.CreateAsync(new Role
                    {
                        Id = Guid.NewGuid(),
                        Name = "Admin",
                        NormalizedName = "ADMIN",
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                    });
                }
                await _userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
