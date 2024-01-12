using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CC.Data.Migrations
{
    /// <inheritdoc />
    public partial class Fixed_CharacterEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "wisdom",
                table: "Characters",
                newName: "Wisdom");

            migrationBuilder.RenameColumn(
                name: "vitatlity",
                table: "Characters",
                newName: "Vitatlity");

            migrationBuilder.RenameColumn(
                name: "strength",
                table: "Characters",
                newName: "Strength");

            migrationBuilder.RenameColumn(
                name: "perception",
                table: "Characters",
                newName: "Perception");

            migrationBuilder.RenameColumn(
                name: "intelligence",
                table: "Characters",
                newName: "Intelligence");

            migrationBuilder.RenameColumn(
                name: "agility",
                table: "Characters",
                newName: "Agility");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Characters");

            migrationBuilder.RenameColumn(
                name: "Wisdom",
                table: "Characters",
                newName: "wisdom");

            migrationBuilder.RenameColumn(
                name: "Vitatlity",
                table: "Characters",
                newName: "vitatlity");

            migrationBuilder.RenameColumn(
                name: "Strength",
                table: "Characters",
                newName: "strength");

            migrationBuilder.RenameColumn(
                name: "Perception",
                table: "Characters",
                newName: "perception");

            migrationBuilder.RenameColumn(
                name: "Intelligence",
                table: "Characters",
                newName: "intelligence");

            migrationBuilder.RenameColumn(
                name: "Agility",
                table: "Characters",
                newName: "agility");
        }
    }
}
