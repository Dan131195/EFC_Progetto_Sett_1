using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFC_Progetto_Sett_1.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trasgressori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Indirizzo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataRegistrazione = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trasgressori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Violazioni",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PuntiDecurtati = table.Column<int>(type: "int", nullable: false),
                    Importo = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Violazioni", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Verbali",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrasgressoreId = table.Column<int>(type: "int", nullable: false),
                    ViolazioneId = table.Column<int>(type: "int", nullable: false),
                    DataViolazione = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Importo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PuntiDecurtati = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verbali", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Verbali_Trasgressori_TrasgressoreId",
                        column: x => x.TrasgressoreId,
                        principalTable: "Trasgressori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Verbali_Violazioni_ViolazioneId",
                        column: x => x.ViolazioneId,
                        principalTable: "Violazioni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Verbali_TrasgressoreId",
                table: "Verbali",
                column: "TrasgressoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Verbali_ViolazioneId",
                table: "Verbali",
                column: "ViolazioneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Verbali");

            migrationBuilder.DropTable(
                name: "Trasgressori");

            migrationBuilder.DropTable(
                name: "Violazioni");
        }
    }
}
