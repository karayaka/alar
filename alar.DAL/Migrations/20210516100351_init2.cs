using Microsoft.EntityFrameworkCore.Migrations;

namespace alar.DAL.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerImageMedium",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductImageMedium",
                table: "ProductImage",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerImageMedium",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerImageMedium",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProductImageMedium",
                table: "ProductImage");

            migrationBuilder.DropColumn(
                name: "CustomerImageMedium",
                table: "Customers");
        }
    }
}
