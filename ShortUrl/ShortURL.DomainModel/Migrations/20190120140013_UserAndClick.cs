using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShortURL.DomainModel.Migrations
{
    public partial class UserAndClick : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "id_user",
                table: "short_url",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "click",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    dt_created = table.Column<DateTime>(nullable: false),
                    dt_updated = table.Column<DateTime>(nullable: false),
                    txt_ip = table.Column<string>(nullable: true),
                    id_short_url = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_click", x => x.id);
                    table.ForeignKey(
                        name: "FK_click_short_url_id_short_url",
                        column: x => x.id_short_url,
                        principalTable: "short_url",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    dt_created = table.Column<DateTime>(nullable: false),
                    dt_updated = table.Column<DateTime>(nullable: false),
                    txt_ip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_short_url_id_user",
                table: "short_url",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_click_id_short_url",
                table: "click",
                column: "id_short_url");

            migrationBuilder.AddForeignKey(
                name: "FK_short_url_user_id_user",
                table: "short_url",
                column: "id_user",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_short_url_user_id_user",
                table: "short_url");

            migrationBuilder.DropTable(
                name: "click");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropIndex(
                name: "IX_short_url_id_user",
                table: "short_url");

            migrationBuilder.DropColumn(
                name: "id_user",
                table: "short_url");
        }
    }
}
