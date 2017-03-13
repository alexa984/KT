namespace IS.Data.Migrations.ISDbContext
{
    using System.Data.Entity.Migrations;

    public class Configuration : DbMigrationsConfiguration<IS.Data.ISDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            // TODO: Remove in production
            AutomaticMigrationDataLossAllowed = true;

            MigrationsDirectory = @"Migrations\ISDbContext";
        }

        protected override void Seed(IS.Data.ISDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
