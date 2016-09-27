namespace AppointmentReminders.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class x : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Appointments", name: "Custumer_CustumerId", newName: "Customer_CustumerId");
            RenameIndex(table: "dbo.Appointments", name: "IX_Custumer_CustumerId", newName: "IX_Customer_CustumerId");
            AddColumn("dbo.Appointments", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.Appointments", "NumOfNotifications", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "NumOfNotifications");
            DropColumn("dbo.Appointments", "CustomerId");
            RenameIndex(table: "dbo.Appointments", name: "IX_Customer_CustumerId", newName: "IX_Custumer_CustumerId");
            RenameColumn(table: "dbo.Appointments", name: "Customer_CustumerId", newName: "Custumer_CustumerId");
        }
    }
}
