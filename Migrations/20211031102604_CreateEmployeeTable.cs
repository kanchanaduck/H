using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularFirst.Migrations
{
    public partial class CreateEmployeeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EMP_NO = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BAND = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DEPT_ABB_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DEPT_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DEPT_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DIV_ABB_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DIV_CLS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DIV_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMAIL_ACTIVE_DATE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FNAME_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FNAME_THA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GNAME_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GNAME_THA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OLD_EMP_NO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    POSN_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    POSN_ENAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PROB_DATE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RESN_DATE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SNAME_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SNAME_THAI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WC_ABB_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WC_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WC_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EMP_NO);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
