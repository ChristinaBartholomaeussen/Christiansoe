using Microsoft.EntityFrameworkCore.Migrations;

namespace christiansoe.Migrations
{
    public partial class AddStatCord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Broen mellem Christiansø og Frederiksø");

            migrationBuilder.InsertData(
                table: "Attractions",
                columns: new[] { "Id", "Latitude", "Longitude", "Name" },
                values: new object[] { 6, 55.320228121331631, 15.186290774370555, "Færgeteminal" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Broen mellem Christians Ø og Frederiks Ø");
        }
    }
}
