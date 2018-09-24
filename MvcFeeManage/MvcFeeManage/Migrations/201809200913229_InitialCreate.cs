namespace MvcFeeManage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblrooms",
                c => new
                {
                    RoomId = c.Int(nullable: false, identity: true),
                    room = c.String(),
                    status = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.RoomId);

        }

        public override void Down()
        {
            DropTable("dbo.tblrooms");
            DropTable("dbo.Student_Course");
        }
    }
}
