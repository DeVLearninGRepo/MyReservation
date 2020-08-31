using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeVLearninG.MyReservation.Infrastructure.Persistence.Migrations
{
    public partial class refactorinEventType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_EventType_IdEventType",
                table: "Event");

            migrationBuilder.DropTable(
                name: "EventType");

            migrationBuilder.CreateTable(
                name: "EventPaymentType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "sysdatetimeoffset()"),
                    UpdatedDate = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "sysdatetimeoffset()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPaymentType", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "EventPaymentType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "FreeEvent" });

            migrationBuilder.InsertData(
                table: "EventPaymentType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "PaidEvent" });

            migrationBuilder.AddForeignKey(
                name: "FK_Event_EventPaymentType_IdEventType",
                table: "Event",
                column: "IdEventType",
                principalTable: "EventPaymentType",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_EventPaymentType_IdEventType",
                table: "Event");

            migrationBuilder.DropTable(
                name: "EventPaymentType");

            migrationBuilder.CreateTable(
                name: "EventType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "sysdatetimeoffset()"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "sysdatetimeoffset()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventType", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "EventType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "FreeEvent" });

            migrationBuilder.InsertData(
                table: "EventType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "PaidEvent" });

            migrationBuilder.AddForeignKey(
                name: "FK_Event_EventType_IdEventType",
                table: "Event",
                column: "IdEventType",
                principalTable: "EventType",
                principalColumn: "Id");
        }
    }
}
