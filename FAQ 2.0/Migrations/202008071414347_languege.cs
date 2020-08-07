namespace FAQ_2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class languege : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FAQ", "Language", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FAQ", "Language");
        }
    }
}
