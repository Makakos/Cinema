using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema.Migrations
{
    public partial class Tables_fields_changing_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Tickets",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Films",
                newName: "Runtime");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "AspNetUsers",
                newName: "Years");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "1ecb2735-7e2f-4df0-9d6e-971fe853979f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5d165fae-4f71-45f6-a950-4515f0082309", "AQAAAAEAACcQAAAAEJnVte+XH2FqMpiYfem8SSsh13CotcA4Bq4mgLwWh3OU6NUAbm5JURRYAdb6uWkoBw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Tickets",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Runtime",
                table: "Films",
                newName: "Time");

            migrationBuilder.RenameColumn(
                name: "Years",
                table: "AspNetUsers",
                newName: "Year");

            migrationBuilder.AddColumn<string>(
                name: "Cost",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "c589973b-bea0-4426-a600-0419479a5d29");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f0f8a91d-bf1d-4ec4-994b-1778bc4fa5d4", "AQAAAAEAACcQAAAAEN6QTrJjUyrZoAs0U9ND2V48YtBPQsjorj0llNCiHDQmoD/R9GiUHbkUKFTd9YGVmQ==" });
        }
    }
}
