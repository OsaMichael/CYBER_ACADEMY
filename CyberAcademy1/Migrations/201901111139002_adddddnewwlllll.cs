namespace CyberAcademy1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddddnewwlllll : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cybers", "ContentType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cybers", "ContentType");
        }
    }
}
