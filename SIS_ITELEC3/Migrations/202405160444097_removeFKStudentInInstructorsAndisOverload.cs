namespace SIS_ITELEC3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeFKStudentInInstructorsAndisOverload : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Instructors", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.Instructors", new[] { "SubjectId" });
            DropColumn("dbo.Instructors", "isOverload");
            DropColumn("dbo.Instructors", "SubjectId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Instructors", "SubjectId", c => c.Int(nullable: false));
            AddColumn("dbo.Instructors", "isOverload", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Instructors", "SubjectId");
            AddForeignKey("dbo.Instructors", "SubjectId", "dbo.Subjects", "Id", cascadeDelete: true);
        }
    }
}
