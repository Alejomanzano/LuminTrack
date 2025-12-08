namespace LuminTrack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Luminarias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tipo = c.String(nullable: false),
                        Latitud = c.Single(nullable: false),
                        Longitud = c.Single(nullable: false),
                        Potencia = c.Int(nullable: false),
                        TienePanelSolar = c.Boolean(nullable: false),
                        Estado = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Luminarias");
        }
    }
}
