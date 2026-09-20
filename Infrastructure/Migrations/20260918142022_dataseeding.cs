using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class dataseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Age", "Birthday", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), 0, 28, new DateOnly(1997, 10, 20), "00000000-0000-0000-0000-000000000001", "hej@info.com", false, "Anna", "Andersson", false, null, "HEJ@INFO.COM", "HEJ@INFO.COM", null, null, false, "00000000-0000-0000-0000-000000000001", false, "hej@info.com" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), 0, 25, new DateOnly(2005, 12, 10), "00000000-0000-0000-0000-000000000002", "tja@info.com", false, "Bertil", "Bertilsson", false, null, "TJA@INFO.COM", "TJA@INFO.COM", null, null, false, "00000000-0000-0000-0000-000000000002", false, "tja@info.com" }
                });

            migrationBuilder.InsertData(
                table: "DailyLogs",
                columns: new[] { "Id", "LogDate", "MoodId", "UserInfoId", "WaterId", "WorkoutId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("11111111-1111-1111-1111-111111111111"), 2, 2 },
                    { 2, new DateTime(2026, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("11111111-1111-1111-1111-111111111111"), 2, 2 },
                    { 3, new DateTime(2026, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("22222222-2222-2222-2222-222222222222"), 2, 2 },
                    { 4, new DateTime(2026, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("22222222-2222-2222-2222-222222222222"), 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Waters",
                columns: new[] { "Id", "DailyLogId", "WaterChecked", "WaterConsumed" },
                values: new object[,]
                {
                    { 1, 1, true, 3 },
                    { 2, 2, true, 5 },
                    { 3, 3, false, 0 },
                    { 4, 4, true, 10 }
                });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "DailyLogId", "Description", "WorkoutCompleted" },
                values: new object[,]
                {
                    { 1, 1, "Walk", true },
                    { 2, 2, "Yoga", true },
                    { 3, 3, "Running", true },
                    { 4, 4, "Gym", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Waters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Waters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Waters",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Waters",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DailyLogs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DailyLogs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DailyLogs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DailyLogs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));
        }
    }
}
