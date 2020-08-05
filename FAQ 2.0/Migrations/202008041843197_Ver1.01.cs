namespace FAQ_2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ver101 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FAQ", "UpdateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.FAQ", "DateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FAQ", "DateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.FAQ", "UpdateTime");
        }
    }
}
