namespace TelefonRehberi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Personel", "YoneticiID", c => c.Int());
            AlterColumn("dbo.Yonetici", "PersonelID", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Yonetici", "PersonelID", c => c.Int(nullable: false));
            AlterColumn("dbo.Personel", "YoneticiID", c => c.Int(nullable: false));
        }
    }
}
