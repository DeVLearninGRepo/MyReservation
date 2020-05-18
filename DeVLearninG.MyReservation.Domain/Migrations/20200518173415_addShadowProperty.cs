using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeVLearninG.MyReservation.Domain.Migrations
{
    public partial class addShadowProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Date",
                table: "Reservation",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Reservation",
                nullable: false,
                defaultValueSql: "sysdatetimeoffset()");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "Reservation",
                nullable: false,
                defaultValueSql: "sysdatetimeoffset()");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Location",
                nullable: false,
                defaultValueSql: "sysdatetimeoffset()");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "Location",
                nullable: false,
                defaultValueSql: "sysdatetimeoffset()");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "EventType",
                nullable: false,
                defaultValueSql: "sysdatetimeoffset()");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "EventType",
                nullable: false,
                defaultValueSql: "sysdatetimeoffset()");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Event",
                nullable: false,
                defaultValueSql: "sysdatetimeoffset()");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "Event",
                nullable: false,
                defaultValueSql: "sysdatetimeoffset()");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Customer",
                nullable: false,
                defaultValueSql: "sysdatetimeoffset()");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "Customer",
                nullable: false,
                defaultValueSql: "sysdatetimeoffset()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "EventType");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "EventType");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Customer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Reservation",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset));
        }
    }
}
