using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema.Migrations
{
    public partial class Added_Poster_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PosterImagePath",
                table: "Films",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PosterImagePath",
                table: "Films");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "b556356c-c17e-48f4-bbf4-1aa7fe9ac92b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b3ca2dd0-ea13-464b-91c0-6d33d2af7417", "AQAAAAEAACcQAAAAEEqioOhP6megkm3TXnlLQi2ZRGE2kGeBxjk4IKRbl/iGwQYlQosg7mys+2K3G6x+RQ==" });
        }
    }
}
