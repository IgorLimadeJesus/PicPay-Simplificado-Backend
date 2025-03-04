using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Desafio_PicPay_Back_end.Migrations
{
    /// <inheritdoc />
    public partial class SecondDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "transacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    ReciverId = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataTransacao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_transacao_carteiras_ReciverId",
                        column: x => x.ReciverId,
                        principalTable: "carteiras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_transacao_carteiras_SenderId",
                        column: x => x.SenderId,
                        principalTable: "carteiras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_transacao_ReciverId",
                table: "transacao",
                column: "ReciverId");

            migrationBuilder.CreateIndex(
                name: "IX_transacao_SenderId",
                table: "transacao",
                column: "SenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transacao");
        }
    }
}
