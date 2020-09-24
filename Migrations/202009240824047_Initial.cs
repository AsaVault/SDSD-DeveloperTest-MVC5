namespace SDSD_DeveloperTest_MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserDetails",
                c => new
                    {
                        UserDetailId = c.Guid(nullable: false, identity: true),
                        TransactionId = c.String(),
                        Name = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.UserDetailId);
            
            CreateTable(
                "dbo.UserUploads",
                c => new
                    {
                        UserUploadId = c.Guid(nullable: false, identity: true),
                        TransactionId = c.String(),
                        FilePath = c.String(),
                        FileName = c.String(),
                        UserDetailId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.UserUploadId)
                .ForeignKey("dbo.UserDetails", t => t.UserDetailId, cascadeDelete: true)
                .Index(t => t.UserDetailId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserUploads", "UserDetailId", "dbo.UserDetails");
            DropIndex("dbo.UserUploads", new[] { "UserDetailId" });
            DropTable("dbo.UserUploads");
            DropTable("dbo.UserDetails");
        }
    }
}
