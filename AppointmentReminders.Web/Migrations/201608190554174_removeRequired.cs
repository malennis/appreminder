namespace AppointmentReminders.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Appointments", "Name", c => c.String());
            AlterColumn("dbo.Appointments", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Appointments", "Timezone", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Appointments", "Timezone", c => c.String(nullable: false));
            AlterColumn("dbo.Appointments", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Appointments", "Name", c => c.String(nullable: false));
        }
    }
}
