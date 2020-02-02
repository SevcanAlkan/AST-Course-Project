namespace MovieStore.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class T172 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Genre", "Description", c => c.String(maxLength: 1000));
        }

        public override void Down()
        {
            AlterColumn("dbo.Genre", "Description", c => c.String(maxLength: 500));
        }
    }
}
