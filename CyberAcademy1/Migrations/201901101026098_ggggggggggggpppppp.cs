namespace CyberAcademy1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ggggggggggggpppppp : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cybers", "CourseId", "dbo.CourseOfStudies");
            DropIndex("dbo.Cybers", new[] { "CourseId" });
            AlterColumn("dbo.Cybers", "CourseId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cybers", "CourseId");
            AddForeignKey("dbo.Cybers", "CourseId", "dbo.CourseOfStudies", "CourseId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cybers", "CourseId", "dbo.CourseOfStudies");
            DropIndex("dbo.Cybers", new[] { "CourseId" });
            AlterColumn("dbo.Cybers", "CourseId", c => c.Int());
            CreateIndex("dbo.Cybers", "CourseId");
            AddForeignKey("dbo.Cybers", "CourseId", "dbo.CourseOfStudies", "CourseId");
        }
    }
}
