using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicineManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MedicineCabinets");

            migrationBuilder.AlterColumn<DateTime>(
                name: "MedWhenToTake",
                table: "Treatments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 17, 47, 58, 284, DateTimeKind.Local).AddTicks(9208),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 25, 14, 51, 8, 47, DateTimeKind.Local).AddTicks(6017));

            migrationBuilder.AlterColumn<DateTime>(
                name: "MedExpirationDate",
                table: "MedicineCabinets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 27, 17, 47, 58, 285, DateTimeKind.Local).AddTicks(218),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 27, 14, 51, 8, 47, DateTimeKind.Local).AddTicks(6580));

            migrationBuilder.AlterColumn<DateTime>(
                name: "WhenToEat",
                table: "Diet",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 17, 47, 58, 282, DateTimeKind.Local).AddTicks(2090),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 25, 14, 51, 8, 46, DateTimeKind.Local).AddTicks(2917));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "MedWhenToTake",
                table: "Treatments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 14, 51, 8, 47, DateTimeKind.Local).AddTicks(6017),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 25, 17, 47, 58, 284, DateTimeKind.Local).AddTicks(9208));

            migrationBuilder.AlterColumn<DateTime>(
                name: "MedExpirationDate",
                table: "MedicineCabinets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 27, 14, 51, 8, 47, DateTimeKind.Local).AddTicks(6580),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 27, 17, 47, 58, 285, DateTimeKind.Local).AddTicks(218));

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "MedicineCabinets",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "WhenToEat",
                table: "Diet",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 14, 51, 8, 46, DateTimeKind.Local).AddTicks(2917),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 25, 17, 47, 58, 282, DateTimeKind.Local).AddTicks(2090));
        }
    }
}
