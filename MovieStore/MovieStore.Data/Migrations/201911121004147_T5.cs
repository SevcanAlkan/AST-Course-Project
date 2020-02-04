namespace MovieStore.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class T5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Collection", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.MovieContent", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.MovieReview", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.Collection", "UserId", "dbo.User");
            DropForeignKey("dbo.MovieReview", "UserId", "dbo.User");
            DropIndex("dbo.Collection", new[] { "UserId" });
            DropIndex("dbo.Collection", new[] { "MovieId" });
            DropIndex("dbo.MovieContent", new[] { "MovieId" });
            DropIndex("dbo.MovieReview", new[] { "UserId" });
            DropIndex("dbo.MovieReview", new[] { "MovieId" });
            CreateTable(
                "dbo.ProjectCast",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    ProjectId = c.Guid(nullable: false),
                    PersonId = c.Guid(nullable: false),
                    EnglishText = c.String(nullable: false),
                    LocalLanguageText = c.String(nullable: false),
                    Status = c.Short(nullable: false),
                    IsDeleted = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Person", t => t.PersonId)
                .ForeignKey("dbo.Project", t => t.ProjectId)
                .Index(t => t.ProjectId)
                .Index(t => t.PersonId);

            CreateTable(
                "dbo.Project",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    MovieId = c.Guid(nullable: false),
                    Status = c.Short(nullable: false),
                    DueDate = c.DateTime(),
                    Code = c.String(nullable: false, maxLength: 10),
                    Subject = c.String(nullable: false, maxLength: 100),
                    Notes = c.String(maxLength: 500),
                    TranslateLanguageId = c.Guid(nullable: false),
                    CreatedBy = c.Guid(nullable: false),
                    CreateDateTime = c.DateTime(nullable: false),
                    UpdateBy = c.Guid(),
                    UpdateDateTime = c.DateTime(),
                    IsDeleted = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movie", t => t.MovieId)
                .ForeignKey("dbo.Language", t => t.TranslateLanguageId)
                .Index(t => t.MovieId)
                .Index(t => t.TranslateLanguageId);

            CreateTable(
                "dbo.Language",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Code = c.String(nullable: false, maxLength: 5),
                    Name = c.String(nullable: false, maxLength: 100),
                    NativeName = c.String(nullable: false, maxLength: 100),
                    IsDeleted = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.Movie", "LanguageId", c => c.Guid(nullable: false));
            AddColumn("dbo.Movie", "CreatedBy", c => c.Guid(nullable: false));
            AddColumn("dbo.Movie", "CreateDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movie", "UpdateBy", c => c.Guid());
            AddColumn("dbo.Movie", "UpdateDateTime", c => c.DateTime());
            CreateIndex("dbo.Movie", "LanguageId");
            AddForeignKey("dbo.Movie", "LanguageId", "dbo.Language", "Id");
            DropColumn("dbo.Movie", "Rate");
            DropColumn("dbo.Movie", "SoldAmount");
            DropColumn("dbo.Movie", "Price");
            DropTable("dbo.Collection");
            DropTable("dbo.MovieContent");
            DropTable("dbo.MovieReview");
        }

        public override void Down()
        {
            CreateTable(
                "dbo.MovieReview",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Rate = c.Short(nullable: false),
                    Comment = c.String(maxLength: 500),
                    Date = c.DateTime(nullable: false),
                    UserId = c.Guid(nullable: false),
                    MovieId = c.Guid(nullable: false),
                    IsDeleted = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.MovieContent",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Type = c.Short(nullable: false),
                    Content = c.String(nullable: false, maxLength: 1000),
                    AddDate = c.DateTime(nullable: false),
                    MovieId = c.Guid(nullable: false),
                    IsDeleted = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);

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

            AddColumn("dbo.Movie", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Movie", "SoldAmount", c => c.Int(nullable: false));
            AddColumn("dbo.Movie", "Rate", c => c.Short(nullable: false));
            DropForeignKey("dbo.Project", "TranslateLanguageId", "dbo.Language");
            DropForeignKey("dbo.Movie", "LanguageId", "dbo.Language");
            DropForeignKey("dbo.Project", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.ProjectCast", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.ProjectCast", "PersonId", "dbo.Person");
            DropIndex("dbo.Project", new[] { "TranslateLanguageId" });
            DropIndex("dbo.Project", new[] { "MovieId" });
            DropIndex("dbo.ProjectCast", new[] { "PersonId" });
            DropIndex("dbo.ProjectCast", new[] { "ProjectId" });
            DropIndex("dbo.Movie", new[] { "LanguageId" });
            DropColumn("dbo.Movie", "UpdateDateTime");
            DropColumn("dbo.Movie", "UpdateBy");
            DropColumn("dbo.Movie", "CreateDateTime");
            DropColumn("dbo.Movie", "CreatedBy");
            DropColumn("dbo.Movie", "LanguageId");
            DropTable("dbo.Language");
            DropTable("dbo.Project");
            DropTable("dbo.ProjectCast");
            CreateIndex("dbo.MovieReview", "MovieId");
            CreateIndex("dbo.MovieReview", "UserId");
            CreateIndex("dbo.MovieContent", "MovieId");
            CreateIndex("dbo.Collection", "MovieId");
            CreateIndex("dbo.Collection", "UserId");
            AddForeignKey("dbo.MovieReview", "UserId", "dbo.User", "Id");
            AddForeignKey("dbo.Collection", "UserId", "dbo.User", "Id");
            AddForeignKey("dbo.MovieReview", "MovieId", "dbo.Movie", "Id");
            AddForeignKey("dbo.MovieContent", "MovieId", "dbo.Movie", "Id");
            AddForeignKey("dbo.Collection", "MovieId", "dbo.Movie", "Id");
        }
    }
}
