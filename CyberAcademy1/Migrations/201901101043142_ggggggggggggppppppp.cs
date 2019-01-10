namespace CyberAcademy1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ggggggggggggppppppp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cybers", "NYSCFileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cybers", "NYSCFileName");
        }
    }
}
