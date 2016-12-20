namespace MyBeerTap.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GlassEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TapId = c.Int(nullable: false),
                        AmountToPour = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Taps", t => t.TapId, cascadeDelete: true)
                .Index(t => t.TapId);
            
            CreateTable(
                "dbo.Taps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                        OfficeId = c.Int(nullable: false),
                        Keg_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kegs", t => t.Keg_Id)
                .ForeignKey("dbo.Offices", t => t.OfficeId, cascadeDelete: true)
                .Index(t => t.OfficeId)
                .Index(t => t.Keg_Id);
            
            CreateTable(
                "dbo.Kegs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Beer = c.Int(nullable: false),
                        Capacity = c.Double(nullable: false),
                        Size = c.Int(nullable: false),
                        Remaining = c.Double(nullable: false),
                        TapId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Taps", t => t.TapId)
                .Index(t => t.TapId);
            
            CreateTable(
                "dbo.Offices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Taps", "OfficeId", "dbo.Offices");
            DropForeignKey("dbo.Taps", "Keg_Id", "dbo.Kegs");
            DropForeignKey("dbo.Kegs", "TapId", "dbo.Taps");
            DropForeignKey("dbo.GlassEntities", "TapId", "dbo.Taps");
            DropIndex("dbo.Kegs", new[] { "TapId" });
            DropIndex("dbo.Taps", new[] { "Keg_Id" });
            DropIndex("dbo.Taps", new[] { "OfficeId" });
            DropIndex("dbo.GlassEntities", new[] { "TapId" });
            DropTable("dbo.Offices");
            DropTable("dbo.Kegs");
            DropTable("dbo.Taps");
            DropTable("dbo.GlassEntities");
        }
    }
}
