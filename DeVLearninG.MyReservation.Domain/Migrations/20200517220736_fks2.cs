using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeVLearninG.MyReservation.Domain.Migrations
{
    public partial class fks2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Event_EventId",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_EventId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Reservation");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_IdEvent",
                table: "Reservation",
                column: "IdEvent");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Event_IdEvent",
                table: "Reservation",
                column: "IdEvent",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Event_IdEvent",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_IdEvent",
                table: "Reservation");

            migrationBuilder.AddColumn<Guid>(
                name: "EventId",
                table: "Reservation",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_EventId",
                table: "Reservation",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Event_EventId",
                table: "Reservation",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
