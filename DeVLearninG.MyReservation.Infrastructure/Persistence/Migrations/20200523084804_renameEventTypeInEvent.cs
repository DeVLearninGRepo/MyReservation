using Microsoft.EntityFrameworkCore.Migrations;

namespace DeVLearninG.MyReservation.Infrastructure.Persistence.Migrations
{
    public partial class renameEventTypeInEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_EventPaymentType_IdEventType",
                table: "Event");

            //migrationBuilder.DropIndex(
            //    name: "IX_Event_IdEventType",
            //    table: "Event");

            migrationBuilder.DropColumn(
                name: "IdEventType",
                table: "Event");

            migrationBuilder.AddColumn<int>(
                name: "IdEventPaymentType",
                table: "Event",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Event_IdEventPaymentType",
                table: "Event",
                column: "IdEventPaymentType");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_EventPaymentType_IdEventPaymentType",
                table: "Event",
                column: "IdEventPaymentType",
                principalTable: "EventPaymentType",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_EventPaymentType_IdEventPaymentType",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_IdEventPaymentType",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "IdEventPaymentType",
                table: "Event");

            migrationBuilder.AddColumn<int>(
                name: "IdEventType",
                table: "Event",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Event_IdEventType",
                table: "Event",
                column: "IdEventType");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_EventPaymentType_IdEventType",
                table: "Event",
                column: "IdEventType",
                principalTable: "EventPaymentType",
                principalColumn: "Id");
        }
    }
}
