using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book_Libirary_Api.DAL.Migrations
{
    public partial class AlterAboutEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Sliders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 1, 15, 32, 43, 988, DateTimeKind.Utc).AddTicks(4280),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 3, 1, 15, 29, 53, 525, DateTimeKind.Utc).AddTicks(4560));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Settings",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 1, 15, 32, 43, 988, DateTimeKind.Utc).AddTicks(4030),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 3, 1, 15, 29, 53, 525, DateTimeKind.Utc).AddTicks(4300));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Abouts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 1, 15, 32, 43, 988, DateTimeKind.Utc).AddTicks(3610),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 3, 1, 15, 29, 53, 525, DateTimeKind.Utc).AddTicks(3920));

            migrationBuilder.AddColumn<string>(
                name: "MainPublicId",
                table: "Abouts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SubPublicId",
                table: "Abouts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainPublicId",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "SubPublicId",
                table: "Abouts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Sliders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 1, 15, 29, 53, 525, DateTimeKind.Utc).AddTicks(4560),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 3, 1, 15, 32, 43, 988, DateTimeKind.Utc).AddTicks(4280));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Settings",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 1, 15, 29, 53, 525, DateTimeKind.Utc).AddTicks(4300),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 3, 1, 15, 32, 43, 988, DateTimeKind.Utc).AddTicks(4030));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Abouts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 1, 15, 29, 53, 525, DateTimeKind.Utc).AddTicks(3920),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 3, 1, 15, 32, 43, 988, DateTimeKind.Utc).AddTicks(3610));
        }
    }
}
