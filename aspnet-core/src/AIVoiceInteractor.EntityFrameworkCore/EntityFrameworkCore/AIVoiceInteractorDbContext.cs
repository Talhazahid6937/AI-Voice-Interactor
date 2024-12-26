using Abp.Zero.EntityFrameworkCore;
using AIVoiceInteractor.Authorization.Roles;
using AIVoiceInteractor.Authorization.Users;
using AIVoiceInteractor.MultiTenancy;
using Microsoft.EntityFrameworkCore;

namespace AIVoiceInteractor.EntityFrameworkCore;

public class AIVoiceInteractorDbContext : AbpZeroDbContext<Tenant, Role, User, AIVoiceInteractorDbContext>
{
    /* Define a DbSet for each entity of the application */

    public AIVoiceInteractorDbContext(DbContextOptions<AIVoiceInteractorDbContext> options)
        : base(options)
    {
    }
}
