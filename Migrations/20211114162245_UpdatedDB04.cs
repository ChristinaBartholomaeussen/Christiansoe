using Microsoft.EntityFrameworkCore.Migrations;

namespace christiansoe.Migrations
{
    public partial class UpdatedDB04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Christiansø Kirke");

            migrationBuilder.InsertData(
                table: "Attractions",
                columns: new[] { "Id", "IsChecked", "Latitude", "Longitude", "Name" },
                values: new object[,]
                {
                    { 7, false, 55.322008050936837, 15.190067317667005, "Hertugindens Bastion" },
                    { 8, false, 55.32316277540636, 15.188298239819762, "Rantzaus Bastion" },
                    { 9, false, 55.320439999999998, 15.18939, "Mindet" },
                    { 10, false, 55.32199, 15.19008, "Christiansø Teltplads" },
                    { 11, false, 55.320239999999998, 15.186489999999999, "101 Trappen" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.UpdateData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Christians Ø Kirke");
        }
    }
}
