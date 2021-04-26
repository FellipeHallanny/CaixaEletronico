using Microsoft.EntityFrameworkCore.Migrations;

namespace CaixaEletronico.API.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notas",
                columns: table => new
                {
                    NotaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Valor = table.Column<int>(type: "INTEGER", nullable: false),
                    QtdNota = table.Column<int>(type: "INTEGER", nullable: false),
                    QrtCriticaNota = table.Column<int>(type: "INTEGER", nullable: false),
                    ImagemURl = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notas", x => x.NotaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notas");
        }
    }
}
