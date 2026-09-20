using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class dataseedingChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DailyLogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "WaterId", "WorkoutId" },
                values: new object[] { 4, 1 });

            migrationBuilder.UpdateData(
                table: "DailyLogs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "MoodId", "WaterId" },
                values: new object[] { 5, 3 });

            migrationBuilder.UpdateData(
                table: "DailyLogs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "MoodId", "WorkoutId" },
                values: new object[] { 5, 3 });

            migrationBuilder.UpdateData(
                table: "DailyLogs",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "MoodId", "WaterId", "WorkoutId" },
                values: new object[] { 4, 1, 4 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DailyLogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "WaterId", "WorkoutId" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "DailyLogs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "MoodId", "WaterId" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "DailyLogs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "MoodId", "WorkoutId" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "DailyLogs",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "MoodId", "WaterId", "WorkoutId" },
                values: new object[] { 1, 2, 2 });
        }
    }
}
