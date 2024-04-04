using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBase.Migrations
{
    /// <inheritdoc />
    public partial class AddReferensToBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookLoansJournal");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_BookID",
                table: "Loans",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_UserID",
                table: "Loans",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Books_BookID",
                table: "Loans",
                column: "BookID",
                principalTable: "Books",
                principalColumn: "BoockID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Users_UserID",
                table: "Loans",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Books_BookID",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Users_UserID",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_BookID",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_UserID",
                table: "Loans");

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
    }
}
