namespace WarunkStream.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_V1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Certificates",
                c => new
                    {
                        IdCertificate = c.String(nullable: false, maxLength: 128),
                        UrlDocument = c.String(),
                        Created = c.DateTimeOffset(nullable: false, precision: 7),
                        Finished = c.DateTimeOffset(nullable: false, precision: 7),
                        IsTournament = c.Boolean(nullable: false),
                        IsFarisStore = c.Boolean(nullable: false),
                        IsSpotify = c.Boolean(nullable: false),
                        Team_IdTeam = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IdCertificate)
                .ForeignKey("dbo.Teams", t => t.Team_IdTeam)
                .Index(t => t.Team_IdTeam);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        IdTeam = c.String(nullable: false, maxLength: 128),
                        NameTeam = c.String(),
                        Categories = c.Int(nullable: false),
                        EmailTeam = c.String(),
                        PhoneTeam = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IdTeam)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.MemberTeams",
                c => new
                    {
                        IdMemberTeam = c.String(nullable: false, maxLength: 128),
                        Nick = c.String(),
                        ID = c.String(),
                        Team_IdTeam = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IdMemberTeam)
                .ForeignKey("dbo.Teams", t => t.Team_IdTeam)
                .Index(t => t.Team_IdTeam);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        IdEvent = c.String(nullable: false, maxLength: 128),
                        TitleEvent = c.String(),
                        IsPaid = c.Boolean(nullable: false),
                        Registered = c.DateTimeOffset(nullable: false, precision: 7),
                        Updated = c.DateTimeOffset(nullable: false, precision: 7),
                        Categories = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdEvent);
            
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
                        FullName = c.String(),
                        Logo = c.String(),
                        Address = c.String(),
                        Registered = c.DateTimeOffset(nullable: false, precision: 7),
                        Updated = c.DateTimeOffset(nullable: false, precision: 7),
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
            DropForeignKey("dbo.Teams", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Certificates", "Team_IdTeam", "dbo.Teams");
            DropForeignKey("dbo.MemberTeams", "Team_IdTeam", "dbo.Teams");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.MemberTeams", new[] { "Team_IdTeam" });
            DropIndex("dbo.Teams", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Certificates", new[] { "Team_IdTeam" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Events");
            DropTable("dbo.MemberTeams");
            DropTable("dbo.Teams");
            DropTable("dbo.Certificates");
        }
    }
}
