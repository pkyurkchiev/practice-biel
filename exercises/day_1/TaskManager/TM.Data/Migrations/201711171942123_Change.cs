namespace TM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "Description", c => c.String());
            AddColumn("dbo.Tasks", "StartedBy", c => c.Int());
            AddColumn("dbo.Tasks", "StartedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tasks", "EndedOn", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Tasks", "StartedBy");
            AddForeignKey("dbo.Tasks", "StartedBy", "dbo.Users", "Id");
            DropColumn("dbo.Tasks", "StartBy");
            DropColumn("dbo.Tasks", "StartOn");
            DropColumn("dbo.Tasks", "EndOn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tasks", "EndOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tasks", "StartOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tasks", "StartBy", c => c.String());
            DropForeignKey("dbo.Tasks", "StartedBy", "dbo.Users");
            DropIndex("dbo.Tasks", new[] { "StartedBy" });
            DropColumn("dbo.Tasks", "EndedOn");
            DropColumn("dbo.Tasks", "StartedOn");
            DropColumn("dbo.Tasks", "StartedBy");
            DropColumn("dbo.Tasks", "Description");
        }
    }
}
