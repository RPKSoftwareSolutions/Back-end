using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO dbo.SekaniLevels (  [Notes] , [Title], [UpdateTime])
            VALUES
                (N'', N'1', N'2018-07-18T03:01:53.37'),
            (N'', N'2', N'2018-07-18T03:01:53.37'), 
            (N'', N'3', N'2018-07-18T03:01:53.37' ), 
            (N'', N'4', N'2018-07-18T03:01:53.37' ), 
            (N'', N'5', N'2018-07-18T03:01:53.37' ), 
            (N'', N'6', N'2018-07-18T03:01:53.37' ), 
            (N'', N'7', N'2018-07-18T03:01:53.37' ), 
            (N'', N'8', N'2018-07-18T03:01:53.37' ), 
            (N'', N'9', N'2018-07-18T03:01:53.37' ), 
            (N'', N'10', N'2018-07-18T03:01:53.37' )");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
