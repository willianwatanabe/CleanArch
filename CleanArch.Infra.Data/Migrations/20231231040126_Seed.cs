using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArch.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Products (Name, Description, Price, Stock, Image, CategoryId)" +
                "VALUES ('Caderno Espiral', 'Caderno espiral 100 folhas', 7.45, 50, 'caderno.jpg', 1)");

            migrationBuilder.Sql("INSERT INTO Products (Name, Description, Price, Stock, Image, CategoryId)" +
                "VALUES ('Estojo', 'Estojo cinza', 5.65, 70, 'estojo.jpg', 1)");

            migrationBuilder.Sql("INSERT INTO Products (Name, Description, Price, Stock, Image, CategoryId)" +
                "VALUES ('Borracha', 'Borracha branca pequena', 2.00, 80, 'borracha.jpg', 1)");

            migrationBuilder.Sql("INSERT INTO Products (Name, Description, Price, Stock, Image, CategoryId)" +
                "VALUES ('Calculadora', 'Calculadora simples', 15.39, 20, 'calculadora.jpg', 2)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Eletronicos");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Acessorios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Material Escolar");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Material Escolar");
        }
    }
}
