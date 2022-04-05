namespace LoginAndRegister.Migrations
{
    using LoginAndRegister.Data.Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LoginAndRegister.Data.DataContext.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LoginAndRegister.Data.DataContext.DataContext context)
        {
            context.Users.AddOrUpdate(x => x.Email, new ApplicationUser
            {
                FirstName = "admin",
                LastName="admin",
                Email = "admin@admin.com",
                Password = "123"
            });
        }
    }
}
