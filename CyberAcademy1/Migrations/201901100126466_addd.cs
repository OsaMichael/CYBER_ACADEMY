namespace CyberAcademy1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cybers", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Cybers", new[] { "UserId" });
            AlterColumn("dbo.Cybers", "UserId", c => c.String());
            DropColumn("dbo.Cybers", "SchoolAttended");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cybers", "SchoolAttended", c => c.String());
            AlterColumn("dbo.Cybers", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Cybers", "UserId");
            AddForeignKey("dbo.Cybers", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
