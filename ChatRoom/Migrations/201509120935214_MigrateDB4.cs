namespace ChatRoom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Messages", "UserId", "dbo.Users");
            DropIndex("dbo.Messages", new[] { "UserId" });
            RenameColumn(table: "dbo.Messages", name: "UserId", newName: "User_Id");
            AlterColumn("dbo.Messages", "User_Id", c => c.Int());
            CreateIndex("dbo.Messages", "User_Id");
            AddForeignKey("dbo.Messages", "User_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "User_Id", "dbo.Users");
            DropIndex("dbo.Messages", new[] { "User_Id" });
            AlterColumn("dbo.Messages", "User_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Messages", name: "User_Id", newName: "UserId");
            CreateIndex("dbo.Messages", "UserId");
            AddForeignKey("dbo.Messages", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
