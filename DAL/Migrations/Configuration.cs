namespace DAL.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Models.EContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DAL.Models.EContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            /* for (int i = 1; i <= 10; i++)
             {
                 context.Admins.AddOrUpdate(new Models.Admin
                 {
                     Email = i + "@gmail.com",
                     Password = Guid.NewGuid().ToString().Substring(0, 10)
                 });
            */
        }
    }
}

