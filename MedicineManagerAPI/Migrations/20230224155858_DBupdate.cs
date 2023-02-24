using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicineManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class DBupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WhenToTake",
                table: "Treatments");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "MedicineCabinets");

            migrationBuilder.RenameColumn(
                name: "WasTaken",
                table: "Treatments",
                newName: "MedWasTaken");

            migrationBuilder.RenameColumn(
                name: "Medicine",
                table: "Treatments",
                newName: "MedName");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Treatments",
                newName: "MedAmount");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "MedicineCabinets",
                newName: "MedName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "MedicineCabinets",
                newName: "MedDescription");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "MedicineCabinets",
                newName: "MedAmount");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Diet",
                newName: "FoodName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Diet",
                newName: "FoodDescription");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Diet",
                newName: "FoodAmount");

            migrationBuilder.AddColumn<DateTime>(
                name: "MedWhenToTake",
                table: "Treatments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 24, 16, 58, 58, 347, DateTimeKind.Local).AddTicks(2112));

            migrationBuilder.AddColumn<DateTime>(
                name: "MedExpirationDate",
                table: "MedicineCabinets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 26, 16, 58, 58, 347, DateTimeKind.Local).AddTicks(2614));

            migrationBuilder.AlterColumn<DateTime>(
                name: "WhenToEat",
                table: "Diet",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 24, 16, 58, 58, 346, DateTimeKind.Local).AddTicks(5897),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 17, 20, 39, 42, 656, DateTimeKind.Local).AddTicks(7233));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MedWhenToTake",
                table: "Treatments");

            migrationBuilder.DropColumn(
                name: "MedExpirationDate",
                table: "MedicineCabinets");

            migrationBuilder.RenameColumn(
                name: "MedWasTaken",
                table: "Treatments",
                newName: "WasTaken");

            migrationBuilder.RenameColumn(
                name: "MedName",
                table: "Treatments",
                newName: "Medicine");

            migrationBuilder.RenameColumn(
                name: "MedAmount",
                table: "Treatments",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "MedName",
                table: "MedicineCabinets",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "MedDescription",
                table: "MedicineCabinets",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "MedAmount",
                table: "MedicineCabinets",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "FoodName",
                table: "Diet",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "FoodDescription",
                table: "Diet",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "FoodAmount",
                table: "Diet",
                newName: "Amount");

            migrationBuilder.AddColumn<DateTime>(
                name: "WhenToTake",
                table: "Treatments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 17, 20, 39, 42, 657, DateTimeKind.Local).AddTicks(3936));

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "MedicineCabinets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 19, 20, 39, 42, 657, DateTimeKind.Local).AddTicks(4487));

            migrationBuilder.AlterColumn<DateTime>(
                name: "WhenToEat",
                table: "Diet",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 17, 20, 39, 42, 656, DateTimeKind.Local).AddTicks(7233),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 24, 16, 58, 58, 346, DateTimeKind.Local).AddTicks(5897));
        }
    }
}
