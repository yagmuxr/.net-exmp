using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApplication.Migrations
{
    /// <inheritdoc />
    public partial class expireeklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Expire",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Expire",
                table: "Products");
        }
    }
}
