namespace LuminTrack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reportes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Descripcion = c.String(nullable: false, maxLength: 500),
                        Categoria = c.String(nullable: false),
                        FotoURL = c.String(),
                        Latitud = c.Single(nullable: false),
                        Longitud = c.Single(nullable: false),
                        PrioridadIA = c.Int(nullable: false),
                        Estado = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Reportes");
        }
    }
}
