using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiForIonic.Migrations
{
    public partial class PaymentHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreditUnionId = table.Column<long>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    PaymentMadeOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentHistories_CreditUnions_CreditUnionId",
                        column: x => x.CreditUnionId,
                        principalTable: "CreditUnions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentHistories_CreditUnionId",
                table: "PaymentHistories",
                column: "CreditUnionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentHistories");
        }
    }
}
