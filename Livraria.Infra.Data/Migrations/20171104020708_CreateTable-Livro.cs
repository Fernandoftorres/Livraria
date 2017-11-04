using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Livraria.Infra.Data.Migrations
{
    public partial class CreateTableLivro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnoPublicacao = table.Column<int>(type: "int", nullable: false),
                    Autor = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livros");
        }
    }
}
