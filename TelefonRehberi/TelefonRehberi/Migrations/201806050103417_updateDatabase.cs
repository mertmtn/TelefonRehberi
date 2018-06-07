namespace TelefonRehberi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDatabase : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Personel", "YoneticiID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Personel", "YoneticiID", c => c.Int());
        }
    }
}
