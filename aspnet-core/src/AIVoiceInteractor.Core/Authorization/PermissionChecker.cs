using Abp.Authorization;
using AIVoiceInteractor.Authorization.Roles;
using AIVoiceInteractor.Authorization.Users;

namespace AIVoiceInteractor.Authorization;

public class PermissionChecker : PermissionChecker<Role, User>
{
    public PermissionChecker(UserManager userManager)
        : base(userManager)
    {
    }
}
