namespace WebApplication_musicstore_codefirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_createdby_field : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "CreatedBy", c => c.String());
            AddColumn("dbo.Artists", "CreatedBy", c => c.String());
            AddColumn("dbo.Genres", "CreatedBy", c => c.String());
            DropColumn("dbo.Albums", "Image2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Albums", "Image2", c => c.String());
            DropColumn("dbo.Genres", "CreatedBy");
            DropColumn("dbo.Artists", "CreatedBy");
            DropColumn("dbo.Albums", "CreatedBy");
        }
    }
}
