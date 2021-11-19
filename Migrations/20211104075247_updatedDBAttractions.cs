using Microsoft.EntityFrameworkCore.Migrations;

namespace christiansoe.Migrations
{
    public partial class updatedDBAttractions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Latitude", "Longitude", "Name" },
                values: new object[] { 55.320228121331631, 15.186290774370555, "Færgeteminal" });

            migrationBuilder.UpdateData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Latitude", "Longitude", "Name" },
                values: new object[] { 55.32056080268012, 15.186943327270084, "Store Tårn" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Latitude", "Longitude", "Name" },
                values: new object[] { 55.32056080268012, 15.186943327270084, "Store Tårn" });

            migrationBuilder.UpdateData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Latitude", "Longitude", "Name" },
                values: new object[] { 55.320228121331631, 15.186290774370555, "Færgeteminal" });
        }
    }
}
