using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreSUS.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Survey",
                columns: table => new
                {
                    SurveyId = table.Column<Guid>(nullable: false),
                    ServiceName = table.Column<string>(nullable: true),
                    SurveyName = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survey", x => x.SurveyId);
                });

            migrationBuilder.CreateTable(
                name: "SurveyResponses",
                columns: table => new
                {
                    SurveyResponseId = table.Column<Guid>(nullable: false),
                    SurveyId = table.Column<Guid>(nullable: false),
                    Q1 = table.Column<int>(nullable: false),
                    Q2 = table.Column<int>(nullable: false),
                    Q3 = table.Column<int>(nullable: false),
                    Q4 = table.Column<int>(nullable: false),
                    Q5 = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyResponses", x => x.SurveyResponseId);
                    table.ForeignKey(
                        name: "FK_SurveyResponses_Survey_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Survey",
                        principalColumn: "SurveyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResponses_SurveyId",
                table: "SurveyResponses",
                column: "SurveyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SurveyResponses");

            migrationBuilder.DropTable(
                name: "Survey");
        }
    }
}
