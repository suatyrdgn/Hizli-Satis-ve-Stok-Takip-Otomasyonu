namespace StokTakip.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class z1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Urunler", "UrunSatisFiyati", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Urunler", "UrunSatisFiyati");
        }
    }
}
