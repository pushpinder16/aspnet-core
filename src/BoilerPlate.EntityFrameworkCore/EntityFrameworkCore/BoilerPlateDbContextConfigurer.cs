using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace BoilerPlate.EntityFrameworkCore
{
    public static class BoilerPlateDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<BoilerPlateDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<BoilerPlateDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
