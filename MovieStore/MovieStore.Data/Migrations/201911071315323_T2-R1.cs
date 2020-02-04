namespace MovieStore.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class T2R1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieContent", "MovieId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Genre", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Genre", "Description", c => c.String(maxLength: 500));
            AlterColumn("dbo.MovieContent", "Content", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.MovieReview", "Comment", c => c.String(maxLength: 500));
            AlterColumn("dbo.Movie", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Movie", "Description", c => c.String(maxLength: 500));
            AlterColumn("dbo.Person", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Person", "Bio", c => c.String(maxLength: 500));
            AlterColumn("dbo.Publisher", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Tag", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.User", "UserName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.User", "DisplayName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Collection", "UserId");
            CreateIndex("dbo.Collection", "MovieId");
            CreateIndex("dbo.Movie", "PublisherId");
            CreateIndex("dbo.MovieCast", "MovieId");
            CreateIndex("dbo.MovieCast", "PersonId");
            CreateIndex("dbo.MovieContent", "MovieId");
            CreateIndex("dbo.MovieGenre", "GenreId");
            CreateIndex("dbo.MovieGenre", "MovieId");
            CreateIndex("dbo.MovieReview", "UserId");
            CreateIndex("dbo.MovieReview", "MovieId");
            CreateIndex("dbo.MovieTag", "TagId");
            CreateIndex("dbo.MovieTag", "MovieId");
            AddForeignKey("dbo.MovieCast", "MovieId", "dbo.Movie", "Id");
            AddForeignKey("dbo.MovieCast", "PersonId", "dbo.Person", "Id");
            AddForeignKey("dbo.Collection", "MovieId", "dbo.Movie", "Id");
            AddForeignKey("dbo.MovieContent", "MovieId", "dbo.Movie", "Id");
            AddForeignKey("dbo.MovieGenre", "GenreId", "dbo.Genre", "Id");
            AddForeignKey("dbo.MovieGenre", "MovieId", "dbo.Movie", "Id");
            AddForeignKey("dbo.Movie", "PublisherId", "dbo.Publisher", "Id");
            AddForeignKey("dbo.MovieReview", "MovieId", "dbo.Movie", "Id");
            AddForeignKey("dbo.Collection", "UserId", "dbo.User", "Id");
            AddForeignKey("dbo.MovieReview", "UserId", "dbo.User", "Id");
            AddForeignKey("dbo.MovieTag", "MovieId", "dbo.Movie", "Id");
            AddForeignKey("dbo.MovieTag", "TagId", "dbo.Tag", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.MovieTag", "TagId", "dbo.Tag");
            DropForeignKey("dbo.MovieTag", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.MovieReview", "UserId", "dbo.User");
            DropForeignKey("dbo.Collection", "UserId", "dbo.User");
            DropForeignKey("dbo.MovieReview", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.Movie", "PublisherId", "dbo.Publisher");
            DropForeignKey("dbo.MovieGenre", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.MovieGenre", "GenreId", "dbo.Genre");
            DropForeignKey("dbo.MovieContent", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.Collection", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.MovieCast", "PersonId", "dbo.Person");
            DropForeignKey("dbo.MovieCast", "MovieId", "dbo.Movie");
            DropIndex("dbo.MovieTag", new[] { "MovieId" });
            DropIndex("dbo.MovieTag", new[] { "TagId" });
            DropIndex("dbo.MovieReview", new[] { "MovieId" });
            DropIndex("dbo.MovieReview", new[] { "UserId" });
            DropIndex("dbo.MovieGenre", new[] { "MovieId" });
            DropIndex("dbo.MovieGenre", new[] { "GenreId" });
            DropIndex("dbo.MovieContent", new[] { "MovieId" });
            DropIndex("dbo.MovieCast", new[] { "PersonId" });
            DropIndex("dbo.MovieCast", new[] { "MovieId" });
            DropIndex("dbo.Movie", new[] { "PublisherId" });
            DropIndex("dbo.Collection", new[] { "MovieId" });
            DropIndex("dbo.Collection", new[] { "UserId" });
            AlterColumn("dbo.User", "Password", c => c.String());
            AlterColumn("dbo.User", "DisplayName", c => c.String());
            AlterColumn("dbo.User", "UserName", c => c.String());
            AlterColumn("dbo.Tag", "Name", c => c.String());
            AlterColumn("dbo.Publisher", "Name", c => c.String());
            AlterColumn("dbo.Person", "Bio", c => c.String());
            AlterColumn("dbo.Person", "Name", c => c.String());
            AlterColumn("dbo.Movie", "Description", c => c.String());
            AlterColumn("dbo.Movie", "Name", c => c.String());
            AlterColumn("dbo.MovieReview", "Comment", c => c.String());
            AlterColumn("dbo.MovieContent", "Content", c => c.String());
            AlterColumn("dbo.Genre", "Description", c => c.String());
            AlterColumn("dbo.Genre", "Name", c => c.String());
            DropColumn("dbo.MovieContent", "MovieId");
        }
    }
}
