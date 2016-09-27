namespace AppointmentReminders.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblsopcencustphysi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OperationCenters",
                c => new
                    {
                        OperationCenterId = c.Int(nullable: false, identity: true),
                        OperationCenterName = c.String(),
                        OperationCenterType = c.String(),
                        Ative = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OperationCenterId);
            
            CreateTable(
                "dbo.Custumers",
                c => new
                    {
                        CustumerId = c.Int(nullable: false, identity: true),
                        OperationCenterId = c.Int(nullable: false),
                        Ative = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        CountryCode = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustumerId)
                .ForeignKey("dbo.OperationCenters", t => t.OperationCenterId, cascadeDelete: true)
                .Index(t => t.OperationCenterId);
            
            CreateTable(
                "dbo.Physicians",
                c => new
                    {
                        PhysicianId = c.Int(nullable: false, identity: true),
                        PhysicianName = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        OperationCenterId = c.Int(nullable: false),
                        Ative = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PhysicianId)
                .ForeignKey("dbo.OperationCenters", t => t.OperationCenterId, cascadeDelete: true)
                .Index(t => t.OperationCenterId);
            
            AddColumn("dbo.Appointments", "OperationCenterId", c => c.Int(nullable: false));
            AddColumn("dbo.Appointments", "PhysicianId", c => c.Int(nullable: false));
            AddColumn("dbo.Appointments", "CountryCode", c => c.String());
            AddColumn("dbo.Appointments", "Status", c => c.String());
            AddColumn("dbo.Appointments", "Custumer_CustumerId", c => c.Int());
            CreateIndex("dbo.Appointments", "OperationCenterId");
            CreateIndex("dbo.Appointments", "PhysicianId");
            CreateIndex("dbo.Appointments", "Custumer_CustumerId");
            AddForeignKey("dbo.Appointments", "OperationCenterId", "dbo.OperationCenters", "OperationCenterId", cascadeDelete: true);
            AddForeignKey("dbo.Appointments", "Custumer_CustumerId", "dbo.Custumers", "CustumerId");
            AddForeignKey("dbo.Appointments", "PhysicianId", "dbo.Physicians", "PhysicianId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Physicians", "OperationCenterId", "dbo.OperationCenters");
            DropForeignKey("dbo.Appointments", "PhysicianId", "dbo.Physicians");
            DropForeignKey("dbo.Custumers", "OperationCenterId", "dbo.OperationCenters");
            DropForeignKey("dbo.Appointments", "Custumer_CustumerId", "dbo.Custumers");
            DropForeignKey("dbo.Appointments", "OperationCenterId", "dbo.OperationCenters");
            DropIndex("dbo.Physicians", new[] { "OperationCenterId" });
            DropIndex("dbo.Custumers", new[] { "OperationCenterId" });
            DropIndex("dbo.Appointments", new[] { "Custumer_CustumerId" });
            DropIndex("dbo.Appointments", new[] { "PhysicianId" });
            DropIndex("dbo.Appointments", new[] { "OperationCenterId" });
            DropColumn("dbo.Appointments", "Custumer_CustumerId");
            DropColumn("dbo.Appointments", "Status");
            DropColumn("dbo.Appointments", "CountryCode");
            DropColumn("dbo.Appointments", "PhysicianId");
            DropColumn("dbo.Appointments", "OperationCenterId");
            DropTable("dbo.Physicians");
            DropTable("dbo.Custumers");
            DropTable("dbo.OperationCenters");
        }
    }
}
