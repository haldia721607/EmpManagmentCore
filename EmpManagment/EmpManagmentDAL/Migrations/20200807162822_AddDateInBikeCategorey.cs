using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpManagmentDAL.Migrations
{
    public partial class AddDateInBikeCategorey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "BikeCategories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "BikeCategories");
        }
    }
}
