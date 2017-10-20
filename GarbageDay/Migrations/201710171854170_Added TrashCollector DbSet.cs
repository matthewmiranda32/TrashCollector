namespace GarbageDay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTrashCollectorDbSet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrashCollectors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Customerid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Customers", t => t.Customerid, cascadeDelete: true)
                .Index(t => t.Customerid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrashCollectors", "Customerid", "dbo.Customers");
            DropIndex("dbo.TrashCollectors", new[] { "Customerid" });
            DropTable("dbo.TrashCollectors");
        }
    }
}
