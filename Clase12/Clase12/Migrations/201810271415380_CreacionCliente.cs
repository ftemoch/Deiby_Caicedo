namespace Clase12.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreacionCliente : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipoClientes",
                c => new
                    {
                        id = c.Byte(nullable: false),
                        Nombre = c.String(),
                        costoSubcripcion = c.Short(nullable: false),
                        duracionSubEnMeses = c.Byte(nullable: false),
                        porcDescuento = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Clientes", "EstaInscritoRevista", c => c.Boolean(nullable: false));
            AddColumn("dbo.Clientes", "IdTipoCliente", c => c.Byte(nullable: false));
            AddColumn("dbo.Clientes", "tipoCliente_id", c => c.Byte());
            CreateIndex("dbo.Clientes", "tipoCliente_id");
            AddForeignKey("dbo.Clientes", "tipoCliente_id", "dbo.TipoClientes", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clientes", "tipoCliente_id", "dbo.TipoClientes");
            DropIndex("dbo.Clientes", new[] { "tipoCliente_id" });
            DropColumn("dbo.Clientes", "tipoCliente_id");
            DropColumn("dbo.Clientes", "IdTipoCliente");
            DropColumn("dbo.Clientes", "EstaInscritoRevista");
            DropTable("dbo.TipoClientes");
        }
    }
}
