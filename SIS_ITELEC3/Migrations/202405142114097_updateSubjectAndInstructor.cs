namespace SIS_ITELEC3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateSubjectAndInstructor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Subjects", "InstructorId", "dbo.Instructors");
            DropIndex("dbo.Subjects", new[] { "InstructorId" });
            AddColumn("dbo.Instructors", "SubjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Instructors", "SubjectId");
            AddForeignKey("dbo.Instructors", "SubjectId", "dbo.Subjects", "Id", cascadeDelete: true);
            DropColumn("dbo.Subjects", "InstructorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subjects", "InstructorId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Instructors", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.Instructors", new[] { "SubjectId" });
            DropColumn("dbo.Instructors", "SubjectId");
            CreateIndex("dbo.Subjects", "InstructorId");
            AddForeignKey("dbo.Subjects", "InstructorId", "dbo.Instructors", "Id", cascadeDelete: true);
        }
    }
}
