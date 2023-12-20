using Microsoft.EntityFrameworkCore.Migrations;

namespace Joker.SmartPacking.Server.EFCore.Migrations
{
    public partial class userinfoid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "sys_user_info",
                newName: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "sys_user_info",
                newName: "user_id");
        }
    }
}
