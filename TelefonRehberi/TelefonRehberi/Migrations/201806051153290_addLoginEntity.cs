namespace TelefonRehberi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addLoginEntity : DbMigration
    {
        public override void Up()
        {
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
            
        }
    }
}
