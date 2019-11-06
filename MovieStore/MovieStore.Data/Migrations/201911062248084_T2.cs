namespace MovieStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class T2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Collection",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        MovieId = c.Guid(nullable: false),
                        AddDate = c.DateTime(nullable: false),
                        BoughtPrice = c.Double(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MovieCast",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MovieId = c.Guid(nullable: false),
                        PersonId = c.Guid(nullable: false),
                        Role = c.Short(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MovieContent",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Type = c.Short(nullable: false),
                        Content = c.String(),
                        AddDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MovieGenre",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        GenreId = c.Guid(nullable: false),
                        MovieId = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MovieReview",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Rate = c.Short(nullable: false),
                        Comment = c.String(),
                        Date = c.DateTime(nullable: false),
                        UserId = c.Guid(nullable: false),
                        MovieId = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PublisherId = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Year = c.Int(nullable: false),
                        Rate = c.Short(nullable: false),
                        SoldAmount = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MovieTag",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TagId = c.Guid(nullable: false),
                        MovieId = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Bio = c.String(),
                        Age = c.Short(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Publisher",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserName = c.String(),
                        DisplayName = c.String(),
                        Password = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.User");
            DropTable("dbo.Tag");
            DropTable("dbo.Publisher");
            DropTable("dbo.Person");
            DropTable("dbo.MovieTag");
            DropTable("dbo.Movie");
            DropTable("dbo.MovieReview");
            DropTable("dbo.MovieGenre");
            DropTable("dbo.MovieContent");
            DropTable("dbo.MovieCast");
            DropTable("dbo.Genre");
            DropTable("dbo.Collection");
        }
    }
}
