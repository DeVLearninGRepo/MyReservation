using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeVLearninG.MyReservation.Domain.Migrations
{
    public partial class eventFk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Location_LocationId",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_LocationId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Event");

            migrationBuilder.CreateIndex(
                name: "IX_Event_IdLocation",
                table: "Event",
                column: "IdLocation");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Location_IdLocation",
                table: "Event",
                column: "IdLocation",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Location_IdLocation",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_IdLocation",
                table: "Event");

            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                table: "Event",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Event_LocationId",
                table: "Event",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Location_LocationId",
                table: "Event",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
