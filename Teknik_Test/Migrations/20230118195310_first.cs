using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeknikTest.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Firmalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FAdi = table.Column<string>(name: "F_Adi", type: "nvarchar(max)", nullable: false),
                    OnayDurumu = table.Column<bool>(name: "Onay_Durumu", type: "bit", nullable: false),
                    SIBasSaati = table.Column<DateTime>(name: "S_I_Bas_Saati", type: "datetime2", nullable: false),
                    SIBitSaati = table.Column<DateTime>(name: "S_I_Bit_Saati", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firmalar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Urunler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UAdi = table.Column<string>(name: "U_Adi", type: "nvarchar(max)", nullable: false),
                    Stok = table.Column<int>(type: "int", nullable: false),
                    Fiyati = table.Column<int>(type: "int", nullable: false),
                    FirmaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urunler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Urunler_Firmalar_FirmaID",
                        column: x => x.FirmaID,
                        principalTable: "Firmalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Siparisler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SVerenAdi = table.Column<string>(name: "S_Veren_Adi", type: "nvarchar(max)", nullable: false),
                    STarihi = table.Column<DateTime>(name: "S_Tarihi", type: "datetime2", nullable: false),
                    FirmaID = table.Column<int>(type: "int", nullable: false),
                    UrunID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparisler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Siparisler_Firmalar_FirmaID",
                        column: x => x.FirmaID,
                        principalTable: "Firmalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Siparisler_Urunler_UrunID",
                        column: x => x.UrunID,
                        principalTable: "Urunler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_FirmaID",
                table: "Siparisler",
                column: "FirmaID");

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_UrunID",
                table: "Siparisler",
                column: "UrunID");

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_FirmaID",
                table: "Urunler",
                column: "FirmaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Siparisler");

            migrationBuilder.DropTable(
                name: "Urunler");

            migrationBuilder.DropTable(
                name: "Firmalar");
        }
    }
}
