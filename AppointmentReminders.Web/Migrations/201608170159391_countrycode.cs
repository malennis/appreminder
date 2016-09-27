namespace AppointmentReminders.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class countrycode : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CountryCodes",
                c => new
                    {
                        CountryCodeId = c.Int(nullable: false, identity: true),
                        Country = c.String(),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.CountryCodeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CountryCodes");
        }
    }
}
