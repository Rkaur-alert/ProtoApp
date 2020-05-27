namespace ProtoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeGenreIDNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "GenreID", c => c.Byte());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "GenreID", c => c.Byte(nullable: false));
        }
    }
}
