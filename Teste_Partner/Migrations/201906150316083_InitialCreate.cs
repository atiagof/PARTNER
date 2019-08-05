namespace Teste_Partner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        MarcaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MarcaId);
            
            CreateTable(
                "dbo.Patrimonios",
                c => new
                    {
                        PatrimonioId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        MarcaId = c.Int(nullable: false),
                        Descrição = c.String(),
                        N_Tombo = c.String(),
                    })
                .PrimaryKey(t => t.PatrimonioId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Patrimonios");
            DropTable("dbo.Marcas");
        }
    }
}
