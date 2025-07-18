﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGMJ.Dados.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaIdentityAoBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FotoPerfil",
                table: "Jovens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoPerfil",
                table: "Jovens");
        }
    }
}
