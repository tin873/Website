namespace cozaStore.DataAccessLayer.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class cozaStoreV8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Order", "EndDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Order", "EndDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}
