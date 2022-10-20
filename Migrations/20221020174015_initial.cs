using Microsoft.EntityFrameworkCore.Migrations;

namespace Siemens_WEBAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cidade",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(nullable: true),
                    estado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidade", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(nullable: true),
                    sexo = table.Column<string>(nullable: true),
                    dataNasc = table.Column<string>(nullable: true),
                    idade = table.Column<int>(nullable: false),
                    CidadeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.id);
                    table.ForeignKey(
                        name: "FK_Cliente_Cidade_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidade",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cidade",
                columns: new[] { "id", "estado", "nome" },
                values: new object[,]
                {
                    { 1, "PR", "Curitiba" },
                    { 2, "SP", "Sao Paulo" },
                    { 3, "RJ", "Rio de Janeiro" },
                    { 4, "MG", "Belo Horizonte" },
                    { 5, "RS", "Porto Alegre" }
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "id", "CidadeId", "dataNasc", "idade", "nome", "sexo" },
                values: new object[,]
                {
                    { 1, 1, "29-12-1994", 28, "Paulo", "Masculino" },
                    { 2, 1, "21-02-1990", 32, "Henrique", "Masculino" },
                    { 3, 2, "12-04-1980", 42, "Guilherme", "Masculino" },
                    { 4, 3, "10-07-1996", 26, "Paula", "Feminino" },
                    { 5, 4, "09-10-1992", 30, "Mariana", "Feminino" },
                    { 6, 5, "15-03-1989", 33, "Francisca", "Feminino" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_CidadeId",
                table: "Cliente",
                column: "CidadeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Cidade");
        }
    }
}
