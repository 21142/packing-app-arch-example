using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PackingApp.Infrastructure.Migrations
{
    public partial class InitialMigration_Read : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "packing");

            migrationBuilder.CreateTable(
                name: "Suitcases",
                schema: "packing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suitcases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuitcaseItems",
                schema: "packing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IsPacked = table.Column<bool>(type: "bit", nullable: false),
                    SuitcaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuitcaseItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuitcaseItems_Suitcases_SuitcaseId",
                        column: x => x.SuitcaseId,
                        principalSchema: "packing",
                        principalTable: "Suitcases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SuitcaseItems_SuitcaseId",
                schema: "packing",
                table: "SuitcaseItems",
                column: "SuitcaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SuitcaseItems",
                schema: "packing");

            migrationBuilder.DropTable(
                name: "Suitcases",
                schema: "packing");
        }
    }
}
