using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quiz.Migrations
{
    /// <inheritdoc />
    public partial class Update_incorrect_history_become_user_history : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IncorrectHistories_Answers_CorrectAnswerId",
                table: "IncorrectHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_IncorrectHistories_Answers_UserAnswerId",
                table: "IncorrectHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_IncorrectHistories_Quizzes_QuizId",
                table: "IncorrectHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_IncorrectHistories_Users_UserId",
                table: "IncorrectHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IncorrectHistories",
                table: "IncorrectHistories");

            migrationBuilder.RenameTable(
                name: "IncorrectHistories",
                newName: "UserHistories");

            migrationBuilder.RenameIndex(
                name: "IX_IncorrectHistories_UserAnswerId",
                table: "UserHistories",
                newName: "IX_UserHistories_UserAnswerId");

            migrationBuilder.RenameIndex(
                name: "IX_IncorrectHistories_QuizId",
                table: "UserHistories",
                newName: "IX_UserHistories_QuizId");

            migrationBuilder.RenameIndex(
                name: "IX_IncorrectHistories_CorrectAnswerId",
                table: "UserHistories",
                newName: "IX_UserHistories_CorrectAnswerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserHistories",
                table: "UserHistories",
                columns: new[] { "UserId", "QuizId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserHistories_Answers_CorrectAnswerId",
                table: "UserHistories",
                column: "CorrectAnswerId",
                principalTable: "Answers",
                principalColumn: "AnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserHistories_Answers_UserAnswerId",
                table: "UserHistories",
                column: "UserAnswerId",
                principalTable: "Answers",
                principalColumn: "AnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserHistories_Quizzes_QuizId",
                table: "UserHistories",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "QuizId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserHistories_Users_UserId",
                table: "UserHistories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserHistories_Answers_CorrectAnswerId",
                table: "UserHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_UserHistories_Answers_UserAnswerId",
                table: "UserHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_UserHistories_Quizzes_QuizId",
                table: "UserHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_UserHistories_Users_UserId",
                table: "UserHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserHistories",
                table: "UserHistories");

            migrationBuilder.RenameTable(
                name: "UserHistories",
                newName: "IncorrectHistories");

            migrationBuilder.RenameIndex(
                name: "IX_UserHistories_UserAnswerId",
                table: "IncorrectHistories",
                newName: "IX_IncorrectHistories_UserAnswerId");

            migrationBuilder.RenameIndex(
                name: "IX_UserHistories_QuizId",
                table: "IncorrectHistories",
                newName: "IX_IncorrectHistories_QuizId");

            migrationBuilder.RenameIndex(
                name: "IX_UserHistories_CorrectAnswerId",
                table: "IncorrectHistories",
                newName: "IX_IncorrectHistories_CorrectAnswerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IncorrectHistories",
                table: "IncorrectHistories",
                columns: new[] { "UserId", "QuizId" });

            migrationBuilder.AddForeignKey(
                name: "FK_IncorrectHistories_Answers_CorrectAnswerId",
                table: "IncorrectHistories",
                column: "CorrectAnswerId",
                principalTable: "Answers",
                principalColumn: "AnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_IncorrectHistories_Answers_UserAnswerId",
                table: "IncorrectHistories",
                column: "UserAnswerId",
                principalTable: "Answers",
                principalColumn: "AnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_IncorrectHistories_Quizzes_QuizId",
                table: "IncorrectHistories",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "QuizId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IncorrectHistories_Users_UserId",
                table: "IncorrectHistories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
