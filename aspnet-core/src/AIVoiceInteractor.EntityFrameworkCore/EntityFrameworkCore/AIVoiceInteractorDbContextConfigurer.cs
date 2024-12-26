using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace AIVoiceInteractor.EntityFrameworkCore;

public static class AIVoiceInteractorDbContextConfigurer
{
    public static void Configure(DbContextOptionsBuilder<AIVoiceInteractorDbContext> builder, string connectionString)
    {
        builder.UseSqlServer(connectionString);
    }

    public static void Configure(DbContextOptionsBuilder<AIVoiceInteractorDbContext> builder, DbConnection connection)
    {
        builder.UseSqlServer(connection);
    }
}
