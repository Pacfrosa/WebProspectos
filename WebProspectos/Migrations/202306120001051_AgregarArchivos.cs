namespace WebProspectos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregarArchivos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Archivos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdPersona = c.Int(nullable: false),
                        Nombre = c.String(nullable: false),
                        DatosArchivo = c.Binary(nullable: false),
                        Persona_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personas", t => t.Persona_Id)
                .Index(t => t.Persona_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Archivos", "Persona_Id", "dbo.Personas");
            DropIndex("dbo.Archivos", new[] { "Persona_Id" });
            DropTable("dbo.Archivos");
        }
    }
}
