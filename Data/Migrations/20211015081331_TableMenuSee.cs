using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularFirst.Data.Migrations
{
    public partial class TableMenuSee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuSee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    menu_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuSee", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuSee");
        }
    }
}
