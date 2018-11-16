namespace Clase12.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class llenarDatosPeli : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO TipoPeliculas(Id,Nombre,costoDia) VALUES (1,'Terror',5)");
            Sql("INSERT INTO TipoPeliculas(Id,Nombre,costoDia) VALUES (2,'Comedia',1)");
            Sql("INSERT INTO TipoPeliculas(Id,Nombre,costoDia) VALUES (3,'Accion','3')");
        }
        
        public override void Down()
        {
        }
    }
}
