using Microsoft.EntityFrameworkCore.Migrations;

namespace ScriptureJournal.Migrations
{
    public partial class Verse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Verse",
                table: "Entry",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Verse",
                table: "Entry");
        }
    }
}
