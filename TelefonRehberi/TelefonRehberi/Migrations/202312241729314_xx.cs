namespace TelefonRehberi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class xx : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departman",
                c => new
                    {
                        DepartmanID = c.Int(nullable: false, identity: true),
                        DepartmanAdi = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmanID);
            
            CreateTable(
                "dbo.Personel",
                c => new
                    {
                        PersonelID = c.Int(nullable: false, identity: true),
                        PersonelAdi = c.String(nullable: false),
                        PersonelSoyadi = c.String(nullable: false),
                        PersonelTelefonNo = c.String(nullable: false),
                        YoneticiID = c.Int(nullable: false),
                        DepartmanID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonelID)
                .ForeignKey("dbo.Departman", t => t.DepartmanID, cascadeDelete: true)
                .Index(t => t.DepartmanID);
            
            CreateTable(
                "dbo.Login",
                c => new
                    {
                        LoginID = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.LoginID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personel", "DepartmanID", "dbo.Departman");
            DropIndex("dbo.Personel", new[] { "DepartmanID" });
            DropTable("dbo.Login");
            DropTable("dbo.Personel");
            DropTable("dbo.Departman");
        }
    }
}
