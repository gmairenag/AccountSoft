namespace AccountSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _050917_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tipo_Partida",
                c => new
                    {
                        id_tipo_partida = c.String(nullable: false, maxLength: 2),
                        descripcion = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.id_tipo_partida);
            
            CreateTable(
                "dbo.Enc_Partida",
                c => new
                    {
                        id_partida = c.Int(nullable: false, identity: true),
                        fecha_partida = c.DateTime(nullable: false),
                        concepto = c.String(maxLength: 200),
                        usuario_ingreso = c.String(maxLength: 50),
                        usuario_autorizo = c.String(maxLength: 50),
                        fecha_ingreso = c.DateTime(nullable: false),
                        fecha_autorizo = c.DateTime(nullable: false),
                        cuadrada = c.Boolean(nullable: false),
                        autorizada = c.Boolean(nullable: false),
                        id_anio_fiscal = c.Int(nullable: false),
                        id_periodo = c.Int(nullable: false),
                        id_tipo_partida = c.String(maxLength: 2),
                    })
                .PrimaryKey(t => t.id_partida)
                .ForeignKey("dbo.Anio_Fiscal", t => t.id_anio_fiscal, cascadeDelete: false)
                .ForeignKey("dbo.Periodo", t => t.id_periodo, cascadeDelete: false)
                .ForeignKey("dbo.Tipo_Partida", t => t.id_tipo_partida)
                .Index(t => t.id_anio_fiscal)
                .Index(t => t.id_periodo)
                .Index(t => t.id_tipo_partida);
            
            CreateTable(
                "dbo.Det_Partida",
                c => new
                    {
                        id_correlativo = c.Int(nullable: false, identity: true),
                        id_cuenta = c.String(maxLength: 20),
                        concepto = c.String(maxLength: 200),
                        cargo = c.Boolean(nullable: false),
                        monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        id_partida = c.Int(nullable: false),
                        id_cta = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.id_correlativo)
                .ForeignKey("dbo.Cta_Cat", t => t.id_cta)
                .ForeignKey("dbo.Enc_Partida", t => t.id_partida, cascadeDelete: false)
                .Index(t => t.id_partida)
                .Index(t => t.id_cta);
            
            CreateTable(
                "dbo.Cta_Cat",
                c => new
                    {
                        id_cta = c.String(nullable: false, maxLength: 20),
                        descripcion = c.String(maxLength: 100),
                        nat_cta = c.String(maxLength: 2),
                        acept_mov = c.Boolean(nullable: false),
                        activa = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id_cta);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enc_Partida", "id_tipo_partida", "dbo.Tipo_Partida");
            DropForeignKey("dbo.Enc_Partida", "id_periodo", "dbo.Periodo");
            DropForeignKey("dbo.Det_Partida", "id_partida", "dbo.Enc_Partida");
            DropForeignKey("dbo.Det_Partida", "id_cta", "dbo.Cta_Cat");
            DropForeignKey("dbo.Enc_Partida", "id_anio_fiscal", "dbo.Anio_Fiscal");
            DropIndex("dbo.Det_Partida", new[] { "id_cta" });
            DropIndex("dbo.Det_Partida", new[] { "id_partida" });
            DropIndex("dbo.Enc_Partida", new[] { "id_tipo_partida" });
            DropIndex("dbo.Enc_Partida", new[] { "id_periodo" });
            DropIndex("dbo.Enc_Partida", new[] { "id_anio_fiscal" });
            DropTable("dbo.Cta_Cat");
            DropTable("dbo.Det_Partida");
            DropTable("dbo.Enc_Partida");
            DropTable("dbo.Tipo_Partida");
        }
    }
}
