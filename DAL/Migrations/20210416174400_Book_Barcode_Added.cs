using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookush.DAL.Migrations
{
    public partial class Book_Barcode_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Barcode",
                table: "Books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Barcode",
                table: "Books");
        }
    }
}
