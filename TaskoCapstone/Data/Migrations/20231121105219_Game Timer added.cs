using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskoCapstone.Data.Migrations
{
    public partial class GameTimeradded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountdownTimer",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountdownTimer",
                table: "Tasks");
        }
    }
}
