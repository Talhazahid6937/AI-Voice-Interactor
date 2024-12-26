using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Zero.Configuration;
using AIVoiceInteractor.Authorization.Roles;
using AIVoiceInteractor.Authorization.Users;
using AIVoiceInteractor.MultiTenancy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AIVoiceInteractor.Authorization;

public class LogInManager : AbpLogInManager<Tenant, Role, User>
{
    private readonly IRepository<User, long> _userRepository;

    public LogInManager(
        UserManager userManager,
        IMultiTenancyConfig multiTenancyConfig,
        IRepository<Tenant> tenantRepository,
        IUnitOfWorkManager unitOfWorkManager,
        ISettingManager settingManager,
        IRepository<UserLoginAttempt, long> userLoginAttemptRepository,
        IUserManagementConfig userManagementConfig,
        IIocResolver iocResolver,
        IPasswordHasher<User> passwordHasher,
        RoleManager roleManager,
        UserClaimsPrincipalFactory claimsPrincipalFactory,
        IRepository<User, long> userRepository)
        : base(
              userManager,
              multiTenancyConfig,
              tenantRepository,
              unitOfWorkManager,
              settingManager,
              userLoginAttemptRepository,
              userManagementConfig,
              iocResolver,
              passwordHasher,
              roleManager,
              claimsPrincipalFactory)
    {
        _userRepository = userRepository;
    }

    public async Task<Tuple<User, string>> VerifyUserCredentials(string username, string password, string emailAddress)
    {
       var user = await _userRepository.GetAll().Where(u => u.EmailAddress.ToUpper() == emailAddress.ToUpper()
                                                    && u.UserName.ToUpper() == username.ToUpper()
                                                    && u.Password == password)
                                                .FirstOrDefaultAsync();
        var message = "Authetication Fail! User not found.";
        if (user.IsNullOrDeleted() && await UserManager.CheckPasswordAsync(user, password))
        {
            message = "Authetication Successful.";
            return  new Tuple<User, string>(user, message);
          
        }
        else
        {
            return new Tuple<User, string>(user, message);
        }
    }
}
