namespace Clase12.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creacionTarif : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tarifas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Monto = c.Double(nullable: false),
                        Descuento = c.Double(nullable: false),
                        Fecha = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tarifas");
        }
    }
}
