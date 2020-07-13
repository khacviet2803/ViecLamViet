namespace WebDemo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebDemo.Data;

    internal sealed class Configuration : DbMigrationsConfiguration<WebDemo.Models.MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebDemo.Models.MyDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            DataSeeder.Seed(context);
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
