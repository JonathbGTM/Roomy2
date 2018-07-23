namespace RoomyLeRetour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModelRoomFile : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RoomFiles", "Content", c => c.Binary(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RoomFiles", "Content", c => c.Byte(nullable: false));
        }
    }
}
