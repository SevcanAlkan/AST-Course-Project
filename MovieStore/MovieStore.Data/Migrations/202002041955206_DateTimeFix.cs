namespace MovieStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeFix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movie", "CreateDateTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Movie", "UpdateDateTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Project", "DueDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Project", "CreateDateTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Project", "UpdateDateTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Project", "UpdateDateTime", c => c.DateTime());
            AlterColumn("dbo.Project", "CreateDateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Project", "DueDate", c => c.DateTime());
            AlterColumn("dbo.Movie", "UpdateDateTime", c => c.DateTime());
            AlterColumn("dbo.Movie", "CreateDateTime", c => c.DateTime(nullable: false));
        }
    }
}
