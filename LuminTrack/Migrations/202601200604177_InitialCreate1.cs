namespace LuminTrack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrdenTrabajoes", "TecnicoEmail", c => c.String());
            AlterColumn("dbo.OrdenTrabajoes", "Descripcion", c => c.String());
            AlterColumn("dbo.OrdenTrabajoes", "Estado", c => c.String());
            DropColumn("dbo.OrdenTrabajoes", "FechaCreacion");
            DropColumn("dbo.OrdenTrabajoes", "TecnicoAsignado");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrdenTrabajoes", "TecnicoAsignado", c => c.String());
            AddColumn("dbo.OrdenTrabajoes", "FechaCreacion", c => c.DateTime(nullable: false));
            AlterColumn("dbo.OrdenTrabajoes", "Estado", c => c.String(nullable: false));
            AlterColumn("dbo.OrdenTrabajoes", "Descripcion", c => c.String(nullable: false, maxLength: 500));
            DropColumn("dbo.OrdenTrabajoes", "TecnicoEmail");
        }
    }
}
