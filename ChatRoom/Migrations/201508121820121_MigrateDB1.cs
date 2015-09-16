namespace ChatRoom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "ImageData");
            DropColumn("dbo.Users", "ImageMimeType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "ImageMimeType", c => c.String());
            AddColumn("dbo.Users", "ImageData", c => c.Binary());
        }
    }
}
