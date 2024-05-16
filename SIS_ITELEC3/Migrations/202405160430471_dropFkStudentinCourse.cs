namespace SIS_ITELEC3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropFkStudentinCourse : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "StudentId", "dbo.Students");
            DropIndex("dbo.Courses", new[] { "StudentId" });
            DropColumn("dbo.Courses", "StudentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "StudentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "StudentId");
            AddForeignKey("dbo.Courses", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
        }
    }
}
