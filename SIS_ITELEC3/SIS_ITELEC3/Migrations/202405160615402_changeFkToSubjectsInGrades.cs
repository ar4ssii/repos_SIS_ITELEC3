namespace SIS_ITELEC3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeFkToSubjectsInGrades : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Grades", "CourseId", "dbo.Courses");
            DropIndex("dbo.Grades", new[] { "CourseId" });
            AddColumn("dbo.Grades", "SubjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Grades", "SubjectId");
            AddForeignKey("dbo.Grades", "SubjectId", "dbo.Subjects", "Id");
            DropColumn("dbo.Grades", "CourseId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Grades", "CourseId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Grades", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.Grades", new[] { "SubjectId" });
            DropColumn("dbo.Grades", "SubjectId");
            CreateIndex("dbo.Grades", "CourseId");
            AddForeignKey("dbo.Grades", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
        }
    }
}
