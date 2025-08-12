using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGMJ.Dados.Migrations
{
    /// <inheritdoc />
    public partial class TabelaDeCongregacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jovens_Setores_SetorId",
                table: "Jovens");

            migrationBuilder.DropColumn(
                name: "Congregacao",
                table: "Setores");

            migrationBuilder.CreateTable(
                name: "Congregacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SetorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Congregacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Congregacoes_Setores_SetorId",
                        column: x => x.SetorId,
                        principalTable: "Setores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Congregacoes_SetorId",
                table: "Congregacoes",
                column: "SetorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jovens_Setores_SetorId",
                table: "Jovens",
                column: "SetorId",
                principalTable: "Setores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jovens_Setores_SetorId",
                table: "Jovens");

            migrationBuilder.DropTable(
                name: "Congregacoes");

            migrationBuilder.AddColumn<string>(
                name: "Congregacao",
                table: "Setores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Jovens_Setores_SetorId",
                table: "Jovens",
                column: "SetorId",
                principalTable: "Setores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
