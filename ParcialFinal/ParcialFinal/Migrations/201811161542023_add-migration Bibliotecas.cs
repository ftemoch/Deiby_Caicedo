namespace ParcialFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigrationBibliotecas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Libros",
                c => new
                {
                    ID_Libro = c.Int(nullable: false, identity: true),
                    Titulo_Libro = c.String(),
                    Autor_Libro = c.String(),
                    ISB_Libro = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ID_Libro);
        }
        
        public override void Down()
        {
            DropTable("dbo.Biblioteca");
        }
    }
}
