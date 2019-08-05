namespace Teste_Partner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MeuContextv2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Marcas");
            DropColumn("dbo.Marcas", "MarcaId");
            AddColumn("dbo.Marcas", "MARCA_ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Marcas", "MARCA_ID");
            DropPrimaryKey("dbo.Patrimonios");
            DropColumn("dbo.Patrimonios", "PatrimonioId");
            AddColumn("dbo.Patrimonios", "PATRIMONIO_ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Patrimonios", "PATRIMONIO_ID");
            DropColumn("dbo.Patrimonios", "MarcaId");
            DropColumn("dbo.Patrimonios", "Descrição");
            DropColumn("dbo.Patrimonios", "N_Tombo");
            AddColumn("dbo.Patrimonios", "MARCA_ID", c => c.Int(nullable: false));
            AddColumn("dbo.Patrimonios", "DESCRICAO", c => c.String());
            AddColumn("dbo.Patrimonios", "NUM_TOMBO", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patrimonios", "N_Tombo", c => c.String());
            AddColumn("dbo.Patrimonios", "Descrição", c => c.String());
            AddColumn("dbo.Patrimonios", "MarcaId", c => c.Int(nullable: false));
            AddColumn("dbo.Patrimonios", "PatrimonioId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Marcas", "MarcaId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Patrimonios");
            DropPrimaryKey("dbo.Marcas");
            DropColumn("dbo.Patrimonios", "NUM_TOMBO");
            DropColumn("dbo.Patrimonios", "DESCRICAO");
            DropColumn("dbo.Patrimonios", "MARCA_ID");
            DropColumn("dbo.Patrimonios", "PATRIMONIO_ID");
            DropColumn("dbo.Marcas", "MARCA_ID");
            AddPrimaryKey("dbo.Patrimonios", "PatrimonioId");
            AddPrimaryKey("dbo.Marcas", "MarcaId");
        }
    }
}
