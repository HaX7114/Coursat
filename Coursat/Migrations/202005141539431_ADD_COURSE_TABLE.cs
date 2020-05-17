namespace Coursat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADD_COURSE_TABLE : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.COURSEs",
                c => new
                    {
                        Course_ID = c.Int(nullable: false),
                        Course_Name = c.String(nullable: false, maxLength: 50),
                        Course_Hours = c.Int(nullable: false),
                        Course_Min = c.Int(nullable: false),
                        Course_Day = c.String(nullable: false, maxLength: 20),
                        Course_Place = c.String(nullable: false, maxLength: 50),
                        Max_Students_Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Course_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.COURSEs");
        }
    }
}
