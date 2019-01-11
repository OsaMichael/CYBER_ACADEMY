namespace CyberAcademy1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddddneww : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cybers", "NewCourse", c => c.String());
            AddColumn("dbo.Cybers", "NewHigher", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cybers", "NewHigher");
            DropColumn("dbo.Cybers", "NewCourse");
        }
    }
}
