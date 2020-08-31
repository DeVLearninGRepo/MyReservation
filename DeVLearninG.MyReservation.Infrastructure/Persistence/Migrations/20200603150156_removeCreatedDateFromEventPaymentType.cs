using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeVLearninG.MyReservation.Infrastructure.Persistence.Migrations
{
    public partial class removeCreatedDateFromEventPaymentType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "EventPaymentType");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "EventPaymentType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "EventPaymentType",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "sysdatetimeoffset()");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "EventPaymentType",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "sysdatetimeoffset()");
        }
    }
}
