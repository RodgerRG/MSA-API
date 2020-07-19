using Microsoft.EntityFrameworkCore.Migrations;

namespace MSA_API.Migrations
{
    public partial class FixedRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Address_addressId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Address_addressId1",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_addressId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_addressId1",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "addressId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "addressId1",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "addressId2",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "addressId",
                table: "Address");

            migrationBuilder.AlterColumn<string>(
                name: "street",
                table: "Address",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "city",
                table: "Address",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "studentId",
                table: "Address",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "studentId1",
                table: "Address",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                columns: new[] { "streetNumber", "street", "studentId", "city" });

            migrationBuilder.CreateIndex(
                name: "IX_Address_studentId",
                table: "Address",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_studentId1",
                table: "Address",
                column: "studentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Student_studentId",
                table: "Address",
                column: "studentId",
                principalTable: "Student",
                principalColumn: "studentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Student_studentId1",
                table: "Address",
                column: "studentId1",
                principalTable: "Student",
                principalColumn: "studentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Student_studentId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Student_studentId1",
                table: "Address");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_studentId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_studentId1",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "studentId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "studentId1",
                table: "Address");

            migrationBuilder.AddColumn<int>(
                name: "addressId",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "addressId1",
                table: "Student",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "addressId2",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "city",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "street",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "addressId",
                table: "Address",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "addressId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_addressId",
                table: "Student",
                column: "addressId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_addressId1",
                table: "Student",
                column: "addressId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Address_addressId",
                table: "Student",
                column: "addressId",
                principalTable: "Address",
                principalColumn: "addressId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Address_addressId1",
                table: "Student",
                column: "addressId1",
                principalTable: "Address",
                principalColumn: "addressId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
