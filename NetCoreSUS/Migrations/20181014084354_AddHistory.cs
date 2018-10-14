using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreSUS.Migrations
{
    public partial class AddHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceHistory",
                columns: table => new
                {
                    ServiceHistoryId = table.Column<Guid>(nullable: false),
                    ServiceId = table.Column<Guid>(nullable: false),
                    When = table.Column<DateTime>(nullable: false),
                    Lede = table.Column<string>(nullable: true),
                    What = table.Column<string>(nullable: true),
                    SurveyId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceHistory", x => x.ServiceHistoryId);
                    table.ForeignKey(
                        name: "FK_ServiceHistory_Survey_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Survey",
                        principalColumn: "SurveyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHistory_SurveyId",
                table: "ServiceHistory",
                column: "SurveyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceHistory");
        }
    }
}
