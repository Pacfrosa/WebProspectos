namespace WebProspectos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablaDoc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Archivos", "Persona_Id", "dbo.Personas");
            DropIndex("dbo.Archivos", new[] { "Persona_Id" });
            AlterColumn("dbo.Archivos", "Persona_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Archivos", "Persona_Id");
            AddForeignKey("dbo.Archivos", "Persona_Id", "dbo.Personas", "Id", cascadeDelete: true);
            DropColumn("dbo.Archivos", "IdPersona");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Archivos", "IdPersona", c => c.Int(nullable: false));
            DropForeignKey("dbo.Archivos", "Persona_Id", "dbo.Personas");
            DropIndex("dbo.Archivos", new[] { "Persona_Id" });
            AlterColumn("dbo.Archivos", "Persona_Id", c => c.Int());
            CreateIndex("dbo.Archivos", "Persona_Id");
            AddForeignKey("dbo.Archivos", "Persona_Id", "dbo.Personas", "Id");
        }
    }
}
