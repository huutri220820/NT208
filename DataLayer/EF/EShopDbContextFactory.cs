//Vo Huu Tri - 18521531 UIT
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataLayer.EF
{
    public class EShopDbContextFactory : IDesignTimeDbContextFactory<EShopDbContext>
    {
        //private static string ConStringSqlServer = "Server=.;Database=Eshopping;Trusted_Connection=True;";
        //private static string ConStringSqlServer = "Server=tcp:shin.database.windows.net,1433;Initial Catalog=Eshopping;Persist Security Info=False;User ID=shin;Password=Tri22082000@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private static string ConStringSqlServer = "workstation id=bookstore-nt208.mssql.somee.com;packet size=4096;user id=huutrimega_SQLLogin_1;pwd=wbbmfabw76;data source=bookstore-nt208.mssql.somee.com;persist security info=False;initial catalog=bookstore-nt208";

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