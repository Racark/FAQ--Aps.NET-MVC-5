namespace FAQ_2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FAQ",
                c => new
                    {
                        FAQID = c.Int(nullable: false, identity: true),
                        Pergunta = c.String(),
                        Resposta = c.String(),
                        Premium = c.Boolean(nullable: false),
                        Pos = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FAQID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FAQ");
        }
    }
}
