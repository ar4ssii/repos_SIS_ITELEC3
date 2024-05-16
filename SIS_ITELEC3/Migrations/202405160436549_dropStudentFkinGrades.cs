namespace SIS_ITELEC3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropStudentFkinGrades : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Grades", "StudentId", "dbo.Students");
            DropIndex("dbo.Grades", new[] { "StudentId" });
            DropColumn("dbo.Grades", "Name");
            DropColumn("dbo.Grades", "StudentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Grades", "StudentId", c => c.Int(nullable: false));
            AddColumn("dbo.Grades", "Name", c => c.String());
            CreateIndex("dbo.Grades", "StudentId");
            AddForeignKey("dbo.Grades", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
        }
    }
}
