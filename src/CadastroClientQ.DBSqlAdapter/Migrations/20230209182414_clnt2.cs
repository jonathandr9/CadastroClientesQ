using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroClientQ.DBSqlAdapter.Migrations
{
    /// <inheritdoc />
    public partial class clnt2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "State",
                table: "Clients",
                newName: "StateDescription");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Clients",
                newName: "CityDescription");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StateDescription",
                table: "Clients",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "CityDescription",
                table: "Clients",
                newName: "City");
        }
    }
}
