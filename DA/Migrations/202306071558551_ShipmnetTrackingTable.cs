namespace DA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShipmnetTrackingTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SourceId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Payment = c.Boolean(nullable: false),
                        ReceiverName = c.String(nullable: false),
                        ReceiverPhone = c.String(nullable: false),
                        DestinationId = c.Int(nullable: false),
                        TrackingId = c.String(nullable: false),
                        District_Id = c.Int(),
                        District_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: false)
                .ForeignKey("dbo.Districts", t => t.DestinationId, cascadeDelete: false)
                .ForeignKey("dbo.Districts", t => t.SourceId, cascadeDelete: false)
                .ForeignKey("dbo.Districts", t => t.District_Id)
                .ForeignKey("dbo.Districts", t => t.District_Id1)
                .Index(t => t.SourceId)
                .Index(t => t.CustomerId)
                .Index(t => t.DestinationId)
                .Index(t => t.District_Id)
                .Index(t => t.District_Id1);
            
            CreateTable(
                "dbo.Trackings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrackingId = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        BookingDate = c.DateTime(nullable: false),
                        DeliveryDate = c.DateTime(nullable: false),
                        ShipmnetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Shipments", t => t.ShipmnetId, cascadeDelete: true)
                .Index(t => t.ShipmnetId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trackings", "ShipmnetId", "dbo.Shipments");
            DropForeignKey("dbo.Shipments", "District_Id1", "dbo.Districts");
            DropForeignKey("dbo.Shipments", "District_Id", "dbo.Districts");
            DropForeignKey("dbo.Shipments", "SourceId", "dbo.Districts");
            DropForeignKey("dbo.Shipments", "DestinationId", "dbo.Districts");
            DropForeignKey("dbo.Shipments", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Trackings", new[] { "ShipmnetId" });
            DropIndex("dbo.Shipments", new[] { "District_Id1" });
            DropIndex("dbo.Shipments", new[] { "District_Id" });
            DropIndex("dbo.Shipments", new[] { "DestinationId" });
            DropIndex("dbo.Shipments", new[] { "CustomerId" });
            DropIndex("dbo.Shipments", new[] { "SourceId" });
            DropTable("dbo.Trackings");
            DropTable("dbo.Shipments");
        }
    }
}
