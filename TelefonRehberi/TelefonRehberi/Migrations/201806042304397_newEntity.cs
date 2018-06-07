namespace TelefonRehberi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Yonetici",
                c => new
                    {
                        YoneticiID = c.Int(nullable: false),
                        PersonelID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.YoneticiID)
                .ForeignKey("dbo.Personel", t => t.YoneticiID)
                .Index(t => t.YoneticiID);
            
            AddColumn("dbo.Personel", "YoneticiID", c => c.Int(nullable: false));
            DropColumn("dbo.Personel", "Yonetici");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Personel", "Yonetici", c => c.Int(nullable: false));
            DropForeignKey("dbo.Yonetici", "YoneticiID", "dbo.Personel");
            DropIndex("dbo.Yonetici", new[] { "YoneticiID" });
            DropColumn("dbo.Personel", "YoneticiID");
            DropTable("dbo.Yonetici");
        }
    }
}
