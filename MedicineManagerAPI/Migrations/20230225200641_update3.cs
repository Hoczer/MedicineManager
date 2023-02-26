using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicineManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class update3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "MedWhenToTake",
                table: "Treatments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 21, 6, 41, 27, DateTimeKind.Local).AddTicks(3297),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 25, 20, 57, 45, 106, DateTimeKind.Local).AddTicks(7195));

            migrationBuilder.AlterColumn<DateTime>(
                name: "MedExpirationDate",
                table: "MedicineCabinets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 27, 21, 6, 41, 27, DateTimeKind.Local).AddTicks(4603),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 27, 20, 57, 45, 106, DateTimeKind.Local).AddTicks(8127));

            migrationBuilder.AlterColumn<DateTime>(
                name: "WhenToEat",
                table: "Diet",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 21, 6, 41, 22, DateTimeKind.Local).AddTicks(5402),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 25, 20, 57, 45, 104, DateTimeKind.Local).AddTicks(1280));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "MedWhenToTake",
                table: "Treatments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 20, 57, 45, 106, DateTimeKind.Local).AddTicks(7195),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 25, 21, 6, 41, 27, DateTimeKind.Local).AddTicks(3297));

            migrationBuilder.AlterColumn<DateTime>(
                name: "MedExpirationDate",
                table: "MedicineCabinets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 27, 20, 57, 45, 106, DateTimeKind.Local).AddTicks(8127),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 27, 21, 6, 41, 27, DateTimeKind.Local).AddTicks(4603));

            migrationBuilder.AlterColumn<DateTime>(
                name: "WhenToEat",
                table: "Diet",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 20, 57, 45, 104, DateTimeKind.Local).AddTicks(1280),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 25, 21, 6, 41, 22, DateTimeKind.Local).AddTicks(5402));
        }
    }
}
