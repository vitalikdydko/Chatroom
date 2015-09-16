namespace ChatRoom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ImageData", c => c.Binary());
            AddColumn("dbo.Users", "ImageMimeType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "ImageMimeType");
            DropColumn("dbo.Users", "ImageData");
        }
    }
}
