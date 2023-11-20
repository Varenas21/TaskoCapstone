using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskoCapstone.Data.Migrations
{
    public partial class AddingCompletion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CompletionofTask",
                table: "Tasks",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletionofTask",
                table: "Tasks");
        }
    }
}
