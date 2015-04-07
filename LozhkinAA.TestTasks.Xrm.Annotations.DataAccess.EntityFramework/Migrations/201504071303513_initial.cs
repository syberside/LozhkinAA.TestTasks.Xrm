using System.Data.Entity.Migrations;

namespace LozhkinAA.TestTasks.Xrm.Annotations.DataAccess.EntityFramework.Migrations
{
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnnotationDescriptions",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Comment = c.String(),
                    Author = c.String(),
                    Time = c.DateTime(nullable: false),
                    Assembly = c.String(),
                    MemberName = c.String(),
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.AnnotationDescriptions");
        }
    }
}