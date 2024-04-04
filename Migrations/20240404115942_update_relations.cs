using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBase.Migrations
{
    /// <inheritdoc />
    public partial class update_relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Loans",
                newName: "LoanDate");

            migrationBuilder.RenameColumn(
                name: "IBSN",
                table: "Books",
                newName: "Genre");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnDate",
                table: "Loans",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BookLoansJournal",
                columns: table => new
                {
                    BookBoockID = table.Column<int>(type: "int", nullable: false),
                    LoansID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookLoansJournal", x => new { x.BookBoockID, x.LoansID });
                    table.ForeignKey(
                        name: "FK_BookLoansJournal_Books_BookBoockID",
                        column: x => x.BookBoockID,
                        principalTable: "Books",
                        principalColumn: "BoockID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookLoansJournal_Loans_LoansID",
                        column: x => x.LoansID,
                        principalTable: "Loans",
                        principalColumn: "LoansID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookLoansJournal_LoansID",
                table: "BookLoansJournal",
                column: "LoansID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookLoansJournal");

            migrationBuilder.DropColumn(
                name: "ReturnDate",
                table: "Loans");

            migrationBuilder.RenameColumn(
                name: "LoanDate",
                table: "Loans",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "Genre",
                table: "Books",
                newName: "IBSN");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
