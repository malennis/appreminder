namespace AppointmentReminders.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddefaulvalues : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assistants",
                c => new
                    {
                        AssistantId = c.Int(nullable: false, identity: true),
                        OperationCenterId = c.Int(nullable: false),
                        AsistantName = c.String(),
                        AsistantUser = c.String(),
                        AsistantPassword = c.String(),
                        Active = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AssistantId)
                .ForeignKey("dbo.OperationCenters", t => t.OperationCenterId, cascadeDelete: false)
                .Index(t => t.OperationCenterId);
            
            AddColumn("dbo.OperationCenters", "Active", c => c.Int(nullable: false));
            AddColumn("dbo.Custumers", "Active", c => c.Int(nullable: false));
            AddColumn("dbo.Physicians", "Active", c => c.Int(nullable: false));
            DropColumn("dbo.OperationCenters", "Ative");
            DropColumn("dbo.Custumers", "Ative");
            DropColumn("dbo.Physicians", "Ative");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Physicians", "Ative", c => c.Int(nullable: false));
            AddColumn("dbo.Custumers", "Ative", c => c.Int(nullable: false));
            AddColumn("dbo.OperationCenters", "Ative", c => c.Int(nullable: false));
            DropForeignKey("dbo.Assistants", "OperationCenterId", "dbo.OperationCenters");
            DropIndex("dbo.Assistants", new[] { "OperationCenterId" });
            DropColumn("dbo.Physicians", "Active");
            DropColumn("dbo.Custumers", "Active");
            DropColumn("dbo.OperationCenters", "Active");
            DropTable("dbo.Assistants");
        }
    }
}
