using Microsoft.EntityFrameworkCore.Migrations;

namespace DeVLearninG.MyReservation.Infrastructure.Persistence.Migrations
{
    public partial class addReservationStored : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(MigrationUtility.ReadSql(typeof(addReservationStored), MigrationUtility.MigrationType.Up));
		}

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(MigrationUtility.ReadSql(typeof(addReservationStored), MigrationUtility.MigrationType.Down));
        }
    }
}
