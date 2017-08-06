namespace AccountSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Periodo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Periodos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        c_empresa = c.String(),
                        c_anio_fiscal = c.Int(nullable: false),
                        c_periodo = c.String(),
                        f_inicio = c.DateTime(nullable: false),
                        f_fin = c.DateTime(nullable: false),
                        b_periodo_abierto = c.Int(nullable: false),
                        c_usuario_creo = c.String(),
                        f_creado = c.DateTime(nullable: false),
                        c_usuario_modifico = c.String(),
                        f_modificado = c.DateTime(nullable: false),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Periodos");
        }
    }
}
