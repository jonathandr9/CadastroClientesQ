using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroClientQ.DBSqlAdapter.Migrations
{
    /// <inheritdoc />
    public partial class alterClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Clients",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Clients",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Clients");
        }
    }
}
