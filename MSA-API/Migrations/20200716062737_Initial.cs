using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MSA_API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    addressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    streetNumber = table.Column<int>(nullable: false),
                    street = table.Column<string>(nullable: false),
                    suburb = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: false),
                    postCode = table.Column<int>(nullable: false),
                    country = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.addressId);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    studentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(maxLength: 100, nullable: false),
                    middleName = table.Column<string>(nullable: true),
                    lastName = table.Column<string>(nullable: false),
                    emailAddress = table.Column<string>(nullable: true),
                    phoneNumber = table.Column<int>(nullable: false),
                    timeCreated = table.Column<DateTime>(nullable: false),
                    addressId = table.Column<int>(nullable: false),
                    addressId1 = table.Column<int>(nullable: true),
                    addressId2 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.studentId);
                    table.ForeignKey(
                        name: "FK_Student_Address_addressId",
                        column: x => x.addressId,
                        principalTable: "Address",
                        principalColumn: "addressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_Address_addressId1",
                        column: x => x.addressId1,
                        principalTable: "Address",
                        principalColumn: "addressId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_addressId",
                table: "Student",
                column: "addressId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_addressId1",
                table: "Student",
                column: "addressId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
