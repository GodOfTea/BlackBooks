namespace BlackBooks.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class abc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbBookDeteils",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Title = c.String(),
                    Author = c.String(),
                    Genre = c.Int(nullable: false),
                    DbBookRequest_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbRideRequests", t => t.DbBookRequest_Id)
                .Index(t => t.DbBookRequest_Id);

            CreateTable(
                "dbo.DbRideRequests",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Filled = c.DateTime(nullable: false),
                    FullName = c.String(),
                    Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Adress = c.String(),
                    Delivery = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.DbBookDeteils", "DbBookRequest_Id", "dbo.DbBookRequests");
            DropIndex("dbo.DbdookDeteils", new[] { "DbBookRequest_Id" });
            DropTable("dbo.DbBookRequests");
            DropTable("dbo.DbBookDeteils");
        }
    }
}
