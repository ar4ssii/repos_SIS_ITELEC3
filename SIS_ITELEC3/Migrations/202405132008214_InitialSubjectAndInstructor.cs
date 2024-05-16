namespace SIS_ITELEC3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSubjectAndInstructor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Year = c.String(),
                        Semester = c.String(),
                        InstructorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Instructors", t => t.InstructorId, cascadeDelete: true)
                .Index(t => t.InstructorId);
            
            CreateTable(
                "dbo.Instructors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        isOverload = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subjects", "InstructorId", "dbo.Instructors");
            DropIndex("dbo.Subjects", new[] { "InstructorId" });
            DropTable("dbo.Instructors");
            DropTable("dbo.Subjects");
        }
    }
}
