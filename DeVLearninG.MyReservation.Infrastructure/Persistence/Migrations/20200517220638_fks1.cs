using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeVLearninG.MyReservation.Infrastructure.Persistence.Migrations
{
    public partial class fks1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Customer_CustomerId1",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Customer_IdCustomer",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Event_IdEvent",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_CustomerId1",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_IdEvent",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "Reservation");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Reservation",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Customer_IdCustomer",
                table: "Reservation",
                column: "IdCustomer",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Customer_IdCustomer",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Reservation");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId1",
                table: "Reservation",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_CustomerId1",
                table: "Reservation",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_IdEvent",
                table: "Reservation",
                column: "IdEvent");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Customer_CustomerId1",
                table: "Reservation",
                column: "CustomerId1",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Customer_IdCustomer",
                table: "Reservation",
                column: "IdCustomer",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Event_IdEvent",
                table: "Reservation",
                column: "IdEvent",
                principalTable: "Event",
                principalColumn: "Id");
        }
    }
}
