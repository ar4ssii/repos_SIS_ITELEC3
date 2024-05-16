namespace SIS_ITELEC3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSubjects : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Subjects", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Subjects", "Year", c => c.String(nullable: false));
            AlterColumn("dbo.Subjects", "Semester", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Subjects", "Semester", c => c.String());
            AlterColumn("dbo.Subjects", "Year", c => c.String());
            AlterColumn("dbo.Subjects", "Name", c => c.String());
        }
    }
}
