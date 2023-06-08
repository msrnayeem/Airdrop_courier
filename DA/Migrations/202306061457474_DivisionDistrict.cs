namespace DA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DivisionDistrict : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DistrictName = c.String(nullable: false),
                        DivisionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Divisions", t => t.DivisionId, cascadeDelete: true)
                .Index(t => t.DivisionId);
            
            AddColumn("dbo.Divisions", "DivisionName", c => c.String(nullable: false));
            DropColumn("dbo.Divisions", "DivName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Divisions", "DivName", c => c.String(nullable: false));
            DropForeignKey("dbo.Districts", "DivisionId", "dbo.Divisions");
            DropIndex("dbo.Districts", new[] { "DivisionId" });
            DropColumn("dbo.Divisions", "DivisionName");
            DropTable("dbo.Districts");
        }
    }
}
