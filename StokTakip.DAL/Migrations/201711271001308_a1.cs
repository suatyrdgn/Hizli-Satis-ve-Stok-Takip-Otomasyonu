namespace StokTakip.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kategoriler",
                c => new
                    {
                        KategoriID = c.Int(nullable: false, identity: true),
                        KategoriAdi = c.String(nullable: false, maxLength: 40),
                        Aciklama = c.String(),
                        KDV = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KategoriID)
                .Index(t => t.KategoriAdi, unique: true);
            
            CreateTable(
                "dbo.Urunler",
                c => new
                    {
                        UrunID = c.Int(nullable: false, identity: true),
                        Barkod = c.String(nullable: false, maxLength: 20),
                        UrunAdi = c.String(nullable: false),
                        UrunResmi = c.Binary(),
                        KategoriID = c.Int(),
                        SatistaMi = c.Boolean(nullable: false),
                        Stok = c.Int(nullable: false),
                        IndirimOrani = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.UrunID)
                .ForeignKey("dbo.Kategoriler", t => t.KategoriID)
                .Index(t => t.Barkod, unique: true)
                .Index(t => t.KategoriID);
            
            CreateTable(
                "dbo.SatisDetaylar",
                c => new
                    {
                        SatisID = c.Int(nullable: false),
                        UrunID = c.Int(nullable: false),
                        Fiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Adet = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SatisID, t.UrunID })
                .ForeignKey("dbo.Satislar", t => t.SatisID, cascadeDelete: true)
                .ForeignKey("dbo.Urunler", t => t.UrunID, cascadeDelete: true)
                .Index(t => t.SatisID)
                .Index(t => t.UrunID);
            
            CreateTable(
                "dbo.Satislar",
                c => new
                    {
                        SatisID = c.Int(nullable: false, identity: true),
                        SatisTarihi = c.DateTime(nullable: false),
                        OdemeTipi = c.Int(nullable: false),
                        Indirim = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SatisID);
            
            CreateTable(
                "dbo.SiparisDetaylar",
                c => new
                    {
                        SiparisID = c.Int(nullable: false),
                        UrunID = c.Int(nullable: false),
                        Fiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Adet = c.Int(nullable: false),
                        Indirim = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SiparisID, t.UrunID })
                .ForeignKey("dbo.Siparisler", t => t.SiparisID, cascadeDelete: true)
                .ForeignKey("dbo.Urunler", t => t.UrunID, cascadeDelete: true)
                .Index(t => t.SiparisID)
                .Index(t => t.UrunID);
            
            CreateTable(
                "dbo.Siparisler",
                c => new
                    {
                        SiparisID = c.Int(nullable: false, identity: true),
                        TedarikciID = c.Int(nullable: false),
                        SiparisTarihi = c.DateTime(nullable: false),
                        SiparisNotu = c.String(),
                        TeslimAlindiMi = c.Boolean(nullable: false),
                        ToplamFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.SiparisID)
                .ForeignKey("dbo.Tedarikciler", t => t.TedarikciID, cascadeDelete: true)
                .Index(t => t.TedarikciID);
            
            CreateTable(
                "dbo.Tedarikciler",
                c => new
                    {
                        TedarikciID = c.Int(nullable: false, identity: true),
                        SirketAdi = c.String(nullable: false, maxLength: 40),
                        CalisanAdi = c.String(maxLength: 40),
                        SirketMail = c.String(maxLength: 30),
                        Adres = c.String(nullable: false),
                        Adres2 = c.String(),
                        Telefon = c.String(nullable: false),
                        CalisanTelefonu = c.String(),
                        Fax = c.String(),
                    })
                .PrimaryKey(t => t.TedarikciID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SiparisDetaylar", "UrunID", "dbo.Urunler");
            DropForeignKey("dbo.SiparisDetaylar", "SiparisID", "dbo.Siparisler");
            DropForeignKey("dbo.Siparisler", "TedarikciID", "dbo.Tedarikciler");
            DropForeignKey("dbo.SatisDetaylar", "UrunID", "dbo.Urunler");
            DropForeignKey("dbo.SatisDetaylar", "SatisID", "dbo.Satislar");
            DropForeignKey("dbo.Urunler", "KategoriID", "dbo.Kategoriler");
            DropIndex("dbo.Siparisler", new[] { "TedarikciID" });
            DropIndex("dbo.SiparisDetaylar", new[] { "UrunID" });
            DropIndex("dbo.SiparisDetaylar", new[] { "SiparisID" });
            DropIndex("dbo.SatisDetaylar", new[] { "UrunID" });
            DropIndex("dbo.SatisDetaylar", new[] { "SatisID" });
            DropIndex("dbo.Urunler", new[] { "KategoriID" });
            DropIndex("dbo.Urunler", new[] { "Barkod" });
            DropIndex("dbo.Kategoriler", new[] { "KategoriAdi" });
            DropTable("dbo.Tedarikciler");
            DropTable("dbo.Siparisler");
            DropTable("dbo.SiparisDetaylar");
            DropTable("dbo.Satislar");
            DropTable("dbo.SatisDetaylar");
            DropTable("dbo.Urunler");
            DropTable("dbo.Kategoriler");
        }
    }
}
