namespace truYum1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class truYum : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.carts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        price = c.Int(nullable: false),
                        free = c.Boolean(nullable: false),
                        total = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.menus",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        price = c.Int(nullable: false),
                        date = c.String(),
                        category = c.String(),
                        active = c.Boolean(nullable: false),
                        free = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.menus");
            DropTable("dbo.carts");
        }
    }
}
