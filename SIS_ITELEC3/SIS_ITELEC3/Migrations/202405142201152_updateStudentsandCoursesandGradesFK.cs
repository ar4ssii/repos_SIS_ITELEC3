namespace SIS_ITELEC3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateStudentsandCoursesandGradesFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentModels", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.StudentModels", "GradeId", "dbo.Grades");
            DropIndex("dbo.StudentModels", new[] { "CourseId" });
            DropIndex("dbo.StudentModels", new[] { "GradeId" });
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false, maxLength: 255),
                        Year = c.String(nullable: false),
                        Section = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        Birthdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Courses", "StudentId", c => c.Int(nullable: false));
            AddColumn("dbo.Grades", "StudentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "StudentId");
            CreateIndex("dbo.Grades", "StudentId");
            AddForeignKey("dbo.Courses", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Grades", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
            DropTable("dbo.StudentModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.StudentModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false, maxLength: 255),
                        Year = c.String(nullable: false),
                        Section = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        Birthdate = c.DateTime(nullable: false),
                        CourseId = c.Int(nullable: false),
                        GradeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Grades", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Courses", "StudentId", "dbo.Students");
            DropIndex("dbo.Grades", new[] { "StudentId" });
            DropIndex("dbo.Courses", new[] { "StudentId" });
            DropColumn("dbo.Grades", "StudentId");
            DropColumn("dbo.Courses", "StudentId");
            DropTable("dbo.Students");
            CreateIndex("dbo.StudentModels", "GradeId");
            CreateIndex("dbo.StudentModels", "CourseId");
            AddForeignKey("dbo.StudentModels", "GradeId", "dbo.Grades", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentModels", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
        }
    }
}
