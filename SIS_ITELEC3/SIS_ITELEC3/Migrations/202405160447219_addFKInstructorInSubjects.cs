namespace SIS_ITELEC3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFKInstructorInSubjects : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subjects", "isOverload", c => c.Boolean(nullable: false));
            AddColumn("dbo.Subjects", "InstructorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Subjects", "InstructorId");
            AddForeignKey("dbo.Subjects", "InstructorId", "dbo.Instructors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subjects", "InstructorId", "dbo.Instructors");
            DropIndex("dbo.Subjects", new[] { "InstructorId" });
            DropColumn("dbo.Subjects", "InstructorId");
            DropColumn("dbo.Subjects", "isOverload");
        }
    }
}
