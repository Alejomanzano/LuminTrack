namespace LuminTrack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFechaYFotoOrden : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrdenTrabajoes", "FechaCreacion", c => c.DateTime(nullable: false));
            AlterColumn("dbo.OrdenTrabajoes", "Descripcion", c => c.String(nullable: false));
            AlterColumn("dbo.OrdenTrabajoes", "Estado", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrdenTrabajoes", "Estado", c => c.String());
            AlterColumn("dbo.OrdenTrabajoes", "Descripcion", c => c.String());
            DropColumn("dbo.OrdenTrabajoes", "FechaCreacion");
        }
    }
}
