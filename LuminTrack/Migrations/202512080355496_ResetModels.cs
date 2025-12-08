namespace LuminTrack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResetModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrdenTrabajoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaCreacion = c.DateTime(nullable: false),
                        Descripcion = c.String(nullable: false, maxLength: 500),
                        Estado = c.String(nullable: false),
                        FotoEvidenciaURL = c.String(),
                        TecnicoAsignado = c.String(),
                        ReporteId = c.Int(),
                        LuminariaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Apellido = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 100),
                        PasswordHash = c.String(nullable: false, maxLength: 200),
                        Rol = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuarios");
            DropTable("dbo.OrdenTrabajoes");
        }
    }
}
