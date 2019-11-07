namespace MovieStore.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MovieStoreDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MovieStoreDbContext context)
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

            try
            {
                #region SysParameters

                //context.SysParameterGroups.AddOrUpdate(p => p.Code, new SysParameterGroup() { Id = Guid.NewGuid(), Code = "SYS01", Name = "Genel", OrderIndex = 1, IsDeleted = false, CreateDT = DateTime.Now, CreateBy = Guid.Empty });

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
