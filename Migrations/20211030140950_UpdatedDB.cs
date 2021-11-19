using Microsoft.EntityFrameworkCore.Migrations;

namespace christiansoe.Migrations
{
    public partial class UpdatedDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Latitude", "Longitude", "Name" },
                values: new object[] { 55.320205000000001, 15.192849000000001, "Østerkær - Danmarks østligeste punkt" });

            migrationBuilder.UpdateData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Latitude", "Longitude", "Name" },
                values: new object[] { 55.322264877099769, 15.187511167143466, "Hestehytten" });

            migrationBuilder.UpdateData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Latitude", "Longitude", "Name" },
                values: new object[] { 55.321274614803706, 15.187012128055752, "Christians Ø Kirke" });

            migrationBuilder.UpdateData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Latitude", "Longitude", "Name" },
                values: new object[] { 55.320439, 15.186107, "Broen mellem Christians Ø og Frederiks Ø" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Latitude", "Longitude", "Name" },
                values: new object[] { 55.322358296440449, 15.187498428676713, "Test2" });

            migrationBuilder.UpdateData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Latitude", "Longitude", "Name" },
                values: new object[] { 55.320211820087565, 15.192855386557753, "Test3" });

            migrationBuilder.UpdateData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Latitude", "Longitude", "Name" },
                values: new object[] { 55.320571989523117, 15.186922340149591, "Test4" });

            migrationBuilder.UpdateData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Latitude", "Longitude", "Name" },
                values: new object[] { 55.321184404696957, 15.188906945432864, "Test5" });
        }
    }
}
