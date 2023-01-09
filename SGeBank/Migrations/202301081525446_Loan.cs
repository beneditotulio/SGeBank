namespace SGeBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Loan : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LOAN",
                c => new
                    {
                        LID = c.String(nullable: false, maxLength: 128),
                        CID = c.String(nullable: false),
                        WID = c.String(nullable: false),
                        LOAN_VALUE = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LPARCEL_TYPE = c.String(nullable: false),
                        LPARCEL_NUM = c.Int(nullable: false),
                        LTAX = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LPAYMENT_VALUE = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LPARCEL_VALUE = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LINCOME = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LDATE = c.DateTime(nullable: false),
                        LBALANCE = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LEXPIRED_DATE = c.DateTime(nullable: false),
                        LPAYMENT_DATE = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LID);
            
            CreateTable(
                "dbo.PARCEL",
                c => new
                    {
                        LID = c.String(nullable: false, maxLength: 128),
                        PORDER = c.Int(nullable: false),
                        PDATE = c.DateTime(nullable: false),
                        PVALUE = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PSTATUS = c.Int(nullable: false),
                        PPENALTY = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.LID, t.PORDER });
            
            CreateTable(
                "dbo.vwLoans",
                c => new
                    {
                        LID = c.String(nullable: false, maxLength: 128),
                        CID = c.String(),
                        WID = c.String(),
                        LOAN_VALUE = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LPARCEL_TYPE = c.String(),
                        LPARCEL_NUM = c.Int(nullable: false),
                        LTAX = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LPAYMENT_VALUE = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LPARCEL_VALUE = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LINCOME = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LDATE = c.DateTime(nullable: false),
                        LBALANCE = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LEXPIRED_DATE = c.DateTime(nullable: false),
                        LPAYMENT_DATE = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LID);
            
            CreateTable(
                "dbo.vwParcels",
                c => new
                    {
                        LID = c.String(nullable: false, maxLength: 128),
                        PORDER = c.Int(nullable: false),
                        PDATE = c.DateTime(nullable: false),
                        PVALUE = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PSTATUS = c.Int(nullable: false),
                        PPENALTY = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.LID, t.PORDER });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.vwParcels");
            DropTable("dbo.vwLoans");
            DropTable("dbo.PARCEL");
            DropTable("dbo.LOAN");
        }
    }
}
