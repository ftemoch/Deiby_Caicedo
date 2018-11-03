namespace Clase12.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreacionPelicula : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipoPeliculas",
                c => new
                {
                    id = c.Byte(nullable: false),
                    Nombre = c.String(),
                    costoDia = c.Short(nullable: false),

                })
                .PrimaryKey(t => t.id);


            AddColumn("dbo.Movies", "IdTipoPelicula", c => c.Byte(nullable: false));
            AddColumn("dbo.Movies", "tipoPelicula_id", c => c.Byte());
            CreateIndex("dbo.Movies", "tipoPelicula_id");
            AddForeignKey("dbo.Movies", "tipoPelicula_id", "dbo.TipoPeliculas", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "tipoPelicula_id", "dbo.TipoPeliculas");
            DropIndex("dbo.Movies", new[] { "tipoPelicula_id" });
            DropColumn("dbo.Movies", "tipoPelicula_id");
            DropColumn("dbo.Movies", "IdTipoPelicula");
            DropTable("dbo.TipoPeliculas");
        }
    }
}
