using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataLayer.EF
{
    public class EShopDbContextFactory : IDesignTimeDbContextFactory<EShopDbContext>
    {
        //private static string ConStringSqlServer = "Server=.;Database=Eshopping;Trusted_Connection=True;";
        private static string ConStringSqlServer = "Server=tcp:shin.database.windows.net,1433;Initial Catalog=NT208;Persist Security Info=False;User ID=shin;Password=Tri22082000@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        //private static string ConStringSqlite = "Filename=Eshop.db";
        public EShopDbContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<EShopDbContext>();
            optionBuilder.UseSqlServer(ConStringSqlServer);

            //optionBuilder.UseSqlite(ConStringSqlite);

            return new EShopDbContext(optionBuilder.Options);
        }
    }
}
