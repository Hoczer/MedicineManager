using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicineManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class update4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MedicineCabinets_UserId",
                table: "MedicineCabinets");

            migrationBuilder.AlterColumn<DateTime>(
                name: "MedWhenToTake",
                table: "Treatments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 21, 54, 3, 744, DateTimeKind.Local).AddTicks(2100),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 25, 21, 6, 41, 27, DateTimeKind.Local).AddTicks(3297));

            migrationBuilder.AlterColumn<DateTime>(
                name: "MedExpirationDate",
                table: "MedicineCabinets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 27, 21, 54, 3, 744, DateTimeKind.Local).AddTicks(3216),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 27, 21, 6, 41, 27, DateTimeKind.Local).AddTicks(4603));

            migrationBuilder.AlterColumn<DateTime>(
                name: "WhenToEat",
                table: "Diet",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 21, 54, 3, 741, DateTimeKind.Local).AddTicks(4434),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 25, 21, 6, 41, 22, DateTimeKind.Local).AddTicks(5402));

            migrationBuilder.CreateIndex(
                name: "IX_MedicineCabinets_UserId",
                table: "MedicineCabinets",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MedicineCabinets_UserId",
                table: "MedicineCabinets");

            migrationBuilder.AlterColumn<DateTime>(
                name: "MedWhenToTake",
                table: "Treatments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 21, 6, 41, 27, DateTimeKind.Local).AddTicks(3297),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 25, 21, 54, 3, 744, DateTimeKind.Local).AddTicks(2100));

            migrationBuilder.AlterColumn<DateTime>(
                name: "MedExpirationDate",
                table: "MedicineCabinets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 27, 21, 6, 41, 27, DateTimeKind.Local).AddTicks(4603),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 27, 21, 54, 3, 744, DateTimeKind.Local).AddTicks(3216));

            migrationBuilder.AlterColumn<DateTime>(
                name: "WhenToEat",
                table: "Diet",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 21, 6, 41, 22, DateTimeKind.Local).AddTicks(5402),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 25, 21, 54, 3, 741, DateTimeKind.Local).AddTicks(4434));

            migrationBuilder.CreateIndex(
                name: "IX_MedicineCabinets_UserId",
                table: "MedicineCabinets",
                column: "UserId",
                unique: true);
        }
    }
}
