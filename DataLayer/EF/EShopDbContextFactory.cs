using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataLayer.EF
{
    public class EShopDbContextFactory : IDesignTimeDbContextFactory<EShopDbContext>
    {
        private static string ConStringSqlServer = "Server=.;Database=Eshopping;Trusted_Connection=True;";
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
