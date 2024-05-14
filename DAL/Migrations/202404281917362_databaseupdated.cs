namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databaseupdated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Orders", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentComments", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.StudentPosts", "PostedBy", "dbo.Students");
            DropForeignKey("dbo.StudentComments", "PostId", "dbo.StudentPosts");
            DropForeignKey("dbo.StudentMgs", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentMgs", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.Orders", new[] { "StudentId" });
            DropIndex("dbo.Orders", new[] { "CourseId" });
            DropIndex("dbo.StudentComments", new[] { "PostId" });
            DropIndex("dbo.StudentComments", new[] { "Student_Id" });
            DropIndex("dbo.StudentPosts", new[] { "PostedBy" });
            DropIndex("dbo.StudentMgs", new[] { "StudentId" });
            DropIndex("dbo.StudentMgs", new[] { "TeacherId" });
            DropTable("dbo.Courses");
            DropTable("dbo.Orders");
            DropTable("dbo.Students");
            DropTable("dbo.StudentComments");
            DropTable("dbo.StudentPosts");
            DropTable("dbo.StudentMgs");
            DropTable("dbo.Teachers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 100),
                        email = c.String(nullable: false),
                        gender = c.String(nullable: false),
                        profession = c.String(nullable: false, maxLength: 100),
                        universityName = c.String(nullable: false, maxLength: 100),
                        password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentMgs",
                c => new
                    {
                        MgsId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        Message = c.String(nullable: false),
                        Reply = c.String(),
                        DateOfMgsReply = c.DateTime(),
                    })
                .PrimaryKey(t => t.MgsId);
            
            CreateTable(
                "dbo.StudentPosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false),
                        Approve = c.Int(nullable: false),
                        PostedBy = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comment = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        CommentedBy = c.String(nullable: false),
                        PostId = c.Int(nullable: false),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        DateOfBirth = c.DateTime(nullable: false),
                        Phone = c.String(maxLength: 15),
                        InstitutionName = c.String(maxLength: 100),
                        Address = c.String(maxLength: 255),
                        Password = c.String(nullable: false, maxLength: 50),
                        Gender = c.String(nullable: false),
                        Active = c.Int(nullable: false),
                        DateOfAccount = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        DateOfBuying = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        ShortDescription = c.String(maxLength: 500),
                        InstructorName = c.String(nullable: false, maxLength: 100),
                        Price = c.Int(nullable: false),
                        Duration = c.Int(nullable: false),
                        VideoPath = c.String(nullable: false, maxLength: 200),
                        UploadTime = c.DateTime(nullable: false),
                        ApproveOrNot = c.Boolean(nullable: false),
                        SellCount = c.Int(nullable: false),
                        userId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.StudentMgs", "TeacherId");
            CreateIndex("dbo.StudentMgs", "StudentId");
            CreateIndex("dbo.StudentPosts", "PostedBy");
            CreateIndex("dbo.StudentComments", "Student_Id");
            CreateIndex("dbo.StudentComments", "PostId");
            CreateIndex("dbo.Orders", "CourseId");
            CreateIndex("dbo.Orders", "StudentId");
            AddForeignKey("dbo.StudentMgs", "TeacherId", "dbo.Teachers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentMgs", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentComments", "PostId", "dbo.StudentPosts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentPosts", "PostedBy", "dbo.Students", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentComments", "Student_Id", "dbo.Students", "Id");
            AddForeignKey("dbo.Orders", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
        }
    }
}
