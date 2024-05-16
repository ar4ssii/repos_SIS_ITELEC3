namespace SIS_ITELEC3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateInstructor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Instructors", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.Instructors", new[] { "SubjectId" });
            AddColumn("dbo.Subjects", "Instructors_Id", c => c.Int());
            CreateIndex("dbo.Subjects", "Instructors_Id");
            AddForeignKey("dbo.Subjects", "Instructors_Id", "dbo.Instructors", "Id");
            DropColumn("dbo.Instructors", "SubjectId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Instructors", "SubjectId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Subjects", "Instructors_Id", "dbo.Instructors");
            DropIndex("dbo.Subjects", new[] { "Instructors_Id" });
            DropColumn("dbo.Subjects", "Instructors_Id");
            CreateIndex("dbo.Instructors", "SubjectId");
            AddForeignKey("dbo.Instructors", "SubjectId", "dbo.Subjects", "Id", cascadeDelete: true);
        }
    }
}
