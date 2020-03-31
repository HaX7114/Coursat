namespace Coursat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class USERS_TABLE : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ADMINs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.USERs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        User_name = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.USERs");
            DropTable("dbo.ADMINs");
        }
    }
}
