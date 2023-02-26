using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicineManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "MedWhenToTake",
                table: "Treatments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 20, 57, 45, 106, DateTimeKind.Local).AddTicks(7195),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 25, 17, 47, 58, 284, DateTimeKind.Local).AddTicks(9208));

            migrationBuilder.AlterColumn<DateTime>(
                name: "MedExpirationDate",
                table: "MedicineCabinets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 27, 20, 57, 45, 106, DateTimeKind.Local).AddTicks(8127),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 27, 17, 47, 58, 285, DateTimeKind.Local).AddTicks(218));

            migrationBuilder.AlterColumn<DateTime>(
                name: "WhenToEat",
                table: "Diet",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 20, 57, 45, 104, DateTimeKind.Local).AddTicks(1280),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 25, 17, 47, 58, 282, DateTimeKind.Local).AddTicks(2090));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "MedWhenToTake",
                table: "Treatments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 17, 47, 58, 284, DateTimeKind.Local).AddTicks(9208),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 25, 20, 57, 45, 106, DateTimeKind.Local).AddTicks(7195));

            migrationBuilder.AlterColumn<DateTime>(
                name: "MedExpirationDate",
                table: "MedicineCabinets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 27, 17, 47, 58, 285, DateTimeKind.Local).AddTicks(218),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 27, 20, 57, 45, 106, DateTimeKind.Local).AddTicks(8127));

            migrationBuilder.AlterColumn<DateTime>(
                name: "WhenToEat",
                table: "Diet",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 17, 47, 58, 282, DateTimeKind.Local).AddTicks(2090),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 25, 20, 57, 45, 104, DateTimeKind.Local).AddTicks(1280));
        }
    }
}
