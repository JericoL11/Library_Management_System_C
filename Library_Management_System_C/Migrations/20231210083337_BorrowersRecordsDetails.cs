using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library_Management_System_C.Migrations
{
    public partial class BorrowersRecordsDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Borrower",
                columns: table => new
                {
                    borrowerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "100000, 1"),
                    borrower_fname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    borrower_lname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    borrower_Course = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    borrower_PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    borrower_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_registered = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrower", x => x.borrowerId);
                });

            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    record_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "200000, 1"),
                    borrowerId = table.Column<int>(type: "int", nullable: false),
                    due_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    librarianId = table.Column<int>(type: "int", nullable: false),
                    transac_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.record_id);
                    table.ForeignKey(
                        name: "FK_Records_Borrower_borrowerId",
                        column: x => x.borrowerId,
                        principalTable: "Borrower",
                        principalColumn: "borrowerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Records_User_librarianId",
                        column: x => x.librarianId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    details_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "300000, 1"),
                    books_id = table.Column<int>(type: "int", nullable: false),
                    record_id = table.Column<int>(type: "int", nullable: false),
                    return_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.details_id);
                    table.ForeignKey(
                        name: "FK_Details_Books_books_id",
                        column: x => x.books_id,
                        principalTable: "Books",
                        principalColumn: "bookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Details_Records_record_id",
                        column: x => x.record_id,
                        principalTable: "Records",
                        principalColumn: "record_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Details_books_id",
                table: "Details",
                column: "books_id");

            migrationBuilder.CreateIndex(
                name: "IX_Details_record_id",
                table: "Details",
                column: "record_id");

            migrationBuilder.CreateIndex(
                name: "IX_Records_borrowerId",
                table: "Records",
                column: "borrowerId");

            migrationBuilder.CreateIndex(
                name: "IX_Records_librarianId",
                table: "Records",
                column: "librarianId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "Records");

            migrationBuilder.DropTable(
                name: "Borrower");
        }
    }
}
