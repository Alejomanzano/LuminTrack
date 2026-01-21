namespace LuminTrack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUsuarioEmailToReporte : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reportes", "UsuarioEmail", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reportes", "UsuarioEmail");
        }
    }
}
