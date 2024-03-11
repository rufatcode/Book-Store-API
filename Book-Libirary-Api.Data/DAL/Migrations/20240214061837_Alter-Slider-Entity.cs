using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book_Libirary_Api.DAL.Migrations
{
    public partial class AlterSliderEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Sliders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 14, 10, 18, 37, 33, DateTimeKind.Utc).AddTicks(4830),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 2, 13, 15, 31, 53, 289, DateTimeKind.Utc).AddTicks(9240));

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Sliders",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Sliders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Sliders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 13, 15, 31, 53, 289, DateTimeKind.Utc).AddTicks(9240),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 2, 14, 10, 18, 37, 33, DateTimeKind.Utc).AddTicks(4830));
        }
    }
}
