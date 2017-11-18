namespace TM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewOne : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tasks", "CreatedBy", c => c.Int());
            AlterColumn("dbo.Tasks", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.Tasks", "UpdatedBy", c => c.Int());
            AlterColumn("dbo.Tasks", "UpdatedOn", c => c.DateTime());
            AlterColumn("dbo.Users", "CreatedBy", c => c.Int());
            AlterColumn("dbo.Users", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.Users", "UpdatedBy", c => c.Int());
            AlterColumn("dbo.Users", "UpdatedOn", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "UpdatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "UpdatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Tasks", "UpdatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tasks", "UpdatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Tasks", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tasks", "CreatedBy", c => c.Int(nullable: false));
        }
    }
}
