namespace SIS_ITELEC3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFKCourseAndFKStudentInGrades : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Grades", "StudentId", c => c.Int(nullable: false));
            AddColumn("dbo.Grades", "CourseId", c => c.Int(nullable: false));
            CreateIndex("dbo.Grades", "StudentId");
            CreateIndex("dbo.Grades", "CourseId");
            AddForeignKey("dbo.Grades", "CourseId", "dbo.Courses", "Id");
            AddForeignKey("dbo.Grades", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Grades", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Grades", "CourseId", "dbo.Courses");
            DropIndex("dbo.Grades", new[] { "CourseId" });
            DropIndex("dbo.Grades", new[] { "StudentId" });
            DropColumn("dbo.Grades", "CourseId");
            DropColumn("dbo.Grades", "StudentId");
        }
    }
}
