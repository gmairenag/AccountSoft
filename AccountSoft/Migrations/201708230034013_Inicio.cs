namespace AccountSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Anio_Fiscal",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        descripcion = c.String(),
                        fecha_inicio = c.DateTime(nullable: false),
                        fecha_fin = c.DateTime(nullable: false),
                        abierto = c.Int(nullable: false),
                        estado = c.String(),
                        usuario_reg = c.String(),
                        usuario_act = c.String(),
                        fecha_reg = c.DateTime(nullable: false),
                        fecha_act = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Anio_Fiscal");
        }
    }
}
