namespace ProtoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredToGenreIDInMovie : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "GenreID", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "GenreID", c => c.Byte());
        }
    }
}
