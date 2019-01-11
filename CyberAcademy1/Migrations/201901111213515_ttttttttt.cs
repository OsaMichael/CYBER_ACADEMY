namespace CyberAcademy1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ttttttttt : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Cybers", "NewCourse");
            DropColumn("dbo.Cybers", "NewHigher");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cybers", "NewHigher", c => c.String());
            AddColumn("dbo.Cybers", "NewCourse", c => c.String());
        }
    }
}
