namespace TelefonRehberi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDtabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Yonetici", "YoneticiID", "dbo.Personel");
            DropIndex("dbo.Yonetici", new[] { "YoneticiID" });
            DropTable("dbo.Yonetici");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Yonetici",
                c => new
                    {
                        YoneticiID = c.Int(nullable: false),
                        PersonelID = c.Int(),
                    })
                .PrimaryKey(t => t.YoneticiID);
            
            CreateIndex("dbo.Yonetici", "YoneticiID");
            AddForeignKey("dbo.Yonetici", "YoneticiID", "dbo.Personel", "PersonelID");
        }
    }
}
