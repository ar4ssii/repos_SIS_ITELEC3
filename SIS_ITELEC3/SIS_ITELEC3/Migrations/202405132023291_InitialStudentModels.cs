namespace SIS_ITELEC3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialStudentModels : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Grades", t => t.GradeId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.GradeId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Rating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentModels", "GradeId", "dbo.Grades");
            DropForeignKey("dbo.StudentModels", "CourseId", "dbo.Courses");
            DropIndex("dbo.StudentModels", new[] { "GradeId" });
            DropIndex("dbo.StudentModels", new[] { "CourseId" });
            DropTable("dbo.Grades");
            DropTable("dbo.Courses");
            DropTable("dbo.StudentModels");
        }
    }
}
