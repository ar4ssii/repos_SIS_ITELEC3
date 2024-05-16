namespace SIS_ITELEC3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Subjects", "Instructors_Id", "dbo.Instructors");
            DropIndex("dbo.Subjects", new[] { "Instructors_Id" });
            AddColumn("dbo.Instructors", "SubjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Instructors", "SubjectId");
            AddForeignKey("dbo.Instructors", "SubjectId", "dbo.Subjects", "Id", cascadeDelete: true);
            DropColumn("dbo.Subjects", "Instructors_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subjects", "Instructors_Id", c => c.Int());
            DropForeignKey("dbo.Instructors", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.Instructors", new[] { "SubjectId" });
            DropColumn("dbo.Instructors", "SubjectId");
            CreateIndex("dbo.Subjects", "Instructors_Id");
            AddForeignKey("dbo.Subjects", "Instructors_Id", "dbo.Instructors", "Id");
        }
    }
}
