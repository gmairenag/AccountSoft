namespace AccountSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ini04092017 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Anio_Fiscal",
                c => new
                    {
                        id_anio_fiscal = c.Int(nullable: false),
                        descripcion = c.String(maxLength: 100),
                        fecha_inicio = c.DateTime(nullable: false),
                        fecha_fin = c.DateTime(nullable: false),
                        abierto = c.Boolean(nullable: false),
                        estado = c.String(),
                        usuario_reg = c.String(),
                        usuario_act = c.String(),
                        fecha_reg = c.DateTime(),
                        fecha_act = c.DateTime(),
                    })
                .PrimaryKey(t => t.id_anio_fiscal);
            
            CreateTable(
                "dbo.Periodo",
                c => new
                    {
                        id_periodo = c.Int(nullable: false, identity: true),
                        fecha_inicio = c.DateTime(nullable: false),
                        fecha_fin = c.DateTime(nullable: false),
                        abierto = c.Boolean(nullable: false),
                        tipo_periodo = c.Int(nullable: false),
                        id_anio_fiscal = c.Int(nullable: false),
                        estado = c.String(),
                        usuario_reg = c.String(),
                        usuario_act = c.String(),
                        fecha_reg = c.DateTime(),
                        fecha_act = c.DateTime(),
                    })
                .PrimaryKey(t => t.id_periodo)
                .ForeignKey("dbo.Anio_Fiscal", t => t.id_anio_fiscal, cascadeDelete: true)
                .Index(t => t.id_anio_fiscal);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Periodo", "id_anio_fiscal", "dbo.Anio_Fiscal");
            DropIndex("dbo.Periodo", new[] { "id_anio_fiscal" });
            DropTable("dbo.Periodo");
            DropTable("dbo.Anio_Fiscal");
        }
    }
}
