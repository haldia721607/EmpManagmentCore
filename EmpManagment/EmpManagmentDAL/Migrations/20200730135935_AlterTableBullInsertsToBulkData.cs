using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpManagmentDAL.Migrations
{
    public partial class AlterTableBullInsertsToBulkData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BulkInserts_Bulk_BulkId",
                table: "BulkInserts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BulkInserts",
                table: "BulkInserts");

            migrationBuilder.RenameTable(
                name: "BulkInserts",
                newName: "BulkDatas");

            migrationBuilder.RenameIndex(
                name: "IX_BulkInserts_BulkId",
                table: "BulkDatas",
                newName: "IX_BulkDatas_BulkId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BulkDatas",
                table: "BulkDatas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BulkDatas_Bulk_BulkId",
                table: "BulkDatas",
                column: "BulkId",
                principalTable: "Bulk",
                principalColumn: "BulkId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BulkDatas_Bulk_BulkId",
                table: "BulkDatas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BulkDatas",
                table: "BulkDatas");

            migrationBuilder.RenameTable(
                name: "BulkDatas",
                newName: "BulkInserts");

            migrationBuilder.RenameIndex(
                name: "IX_BulkDatas_BulkId",
                table: "BulkInserts",
                newName: "IX_BulkInserts_BulkId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BulkInserts",
                table: "BulkInserts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BulkInserts_Bulk_BulkId",
                table: "BulkInserts",
                column: "BulkId",
                principalTable: "Bulk",
                principalColumn: "BulkId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
