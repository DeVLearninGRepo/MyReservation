using Microsoft.EntityFrameworkCore.Migrations;

namespace DeVLearninG.MyReservation.Infrastructure.Persistence.Migrations
{
    public partial class addEventType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdEventType",
                table: "Event",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EventType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_IdEventType",
                table: "Event",
                column: "IdEventType");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_EventType_IdEventType",
                table: "Event",
                column: "IdEventType",
                principalTable: "EventType",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_EventType_IdEventType",
                table: "Event");

            migrationBuilder.DropTable(
                name: "EventType");

            migrationBuilder.DropIndex(
                name: "IX_Event_IdEventType",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "IdEventType",
                table: "Event");
        }
    }
}
