using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shopsruscase.Infrastructure.Migrations
{
    public partial class firstcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");
        }

       
    }
}
