using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class migmovementemp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Punishments_Employees_EmployeeId",
                table: "Punishments");

            migrationBuilder.DropIndex(
                name: "IX_Punishments_EmployeeId",
                table: "Punishments");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Punishments");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Movements",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movements_EmployeeId",
                table: "Movements",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movements_Employees_EmployeeId",
                table: "Movements",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movements_Employees_EmployeeId",
                table: "Movements");

            migrationBuilder.DropIndex(
                name: "IX_Movements_EmployeeId",
                table: "Movements");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Movements");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Punishments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Punishments_EmployeeId",
                table: "Punishments",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Punishments_Employees_EmployeeId",
                table: "Punishments",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
