using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularFirst.Data.Migrations
{
    public partial class MenuHierarchy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    menu_code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    menu_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    parent_menu_code = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.menu_code);
                    table.ForeignKey(
                        name: "FK_Menu_Menu_parent_menu_code",
                        column: x => x.parent_menu_code,
                        principalTable: "Menu",
                        principalColumn: "menu_code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menu_parent_menu_code",
                table: "Menu",
                column: "parent_menu_code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menu");
        }
    }
}
