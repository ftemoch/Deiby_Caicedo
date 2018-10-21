namespace Clase12.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cilo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "Salario", c => c.Double(nullable: false));
            AddColumn("dbo.Clientes", "Activo", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clientes", "Activo");
            DropColumn("dbo.Clientes", "Salario");
        }
    }
}
