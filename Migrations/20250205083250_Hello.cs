using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorPatientProject.Migrations
{
    /// <inheritdoc />
    public partial class Hello : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "patients");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "patients",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
