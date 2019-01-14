namespace CyberAcademy1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addinitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseOfStudies",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        Course_Name = c.String(),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.Cybers",
                c => new
                    {
                        CyberId = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        HigherId = c.Int(),
                        UserId = c.String(),
                        StateId = c.Int(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        OtherNames = c.String(),
                        Gender = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Address = c.String(),
                        ClassOfDigree = c.String(),
                        YearOfGraduation = c.String(),
                        NYSC_upload = c.String(),
                        Email = c.String(),
                        Qualification = c.String(),
                        Grade = c.String(),
                        Contact = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        NYSCFileName = c.String(),
                        Age = c.Int(nullable: false),
                        ContentType = c.String(),
                    })
                .PrimaryKey(t => t.CyberId)
                .ForeignKey("dbo.CourseOfStudies", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.HigherInstitutions", t => t.HigherId)
                .ForeignKey("dbo.States", t => t.StateId)
                .Index(t => t.CourseId)
                .Index(t => t.HigherId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.HigherInstitutions",
                c => new
                    {
                        HigherId = c.Int(nullable: false, identity: true),
                        Instit_Name = c.String(),
                    })
                .PrimaryKey(t => t.HigherId);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StateId = c.Int(nullable: false, identity: true),
                        State_Name = c.String(),
                    })
                .PrimaryKey(t => t.StateId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Cybers", "StateId", "dbo.States");
            DropForeignKey("dbo.Cybers", "HigherId", "dbo.HigherInstitutions");
            DropForeignKey("dbo.Cybers", "CourseId", "dbo.CourseOfStudies");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Cybers", new[] { "StateId" });
            DropIndex("dbo.Cybers", new[] { "HigherId" });
            DropIndex("dbo.Cybers", new[] { "CourseId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.States");
            DropTable("dbo.HigherInstitutions");
            DropTable("dbo.Cybers");
            DropTable("dbo.CourseOfStudies");
        }
    }
}
