using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trinity.Infra.Data.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    Title = table.Column<string>(type: "VarChar", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bands",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    Name = table.Column<string>(type: "VarChar", maxLength: 150, nullable: false),
                    FoundationYear = table.Column<short>(type: "SmallInt", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Musics",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    Title = table.Column<string>(type: "VarChar", maxLength: 150, nullable: false),
                    DurationTicks = table.Column<long>(type: "BigInt", nullable: false),
                    AlbumId = table.Column<long>(nullable: true),
                    BandId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Musics_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Musics_Bands_BandId",
                        column: x => x.BandId,
                        principalTable: "Bands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Musics_AlbumId",
                table: "Musics",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Musics_BandId",
                table: "Musics",
                column: "BandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Musics");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Bands");
        }
    }
}
