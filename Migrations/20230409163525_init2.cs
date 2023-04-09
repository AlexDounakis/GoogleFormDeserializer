using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoogleFormDeserializer.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Forms_formId",
                table: "Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.RenameTable(
                name: "Item",
                newName: "Items");

            migrationBuilder.RenameIndex(
                name: "IX_Item_formId",
                table: "Items",
                newName: "IX_Items_formId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "id");

            migrationBuilder.CreateTable(
                name: "ImageItems",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    itemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_ImageItems_Items_itemId",
                        column: x => x.itemId,
                        principalTable: "Items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionItems",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    itemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_QuestionItems_Items_itemId",
                        column: x => x.itemId,
                        principalTable: "Items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizSettings",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    settingsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    isQuiz = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizSettings", x => x.id);
                    table.ForeignKey(
                        name: "FK_QuizSettings_Settings_settingsId",
                        column: x => x.settingsId,
                        principalTable: "Settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    imageItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    contentUri = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.id);
                    table.ForeignKey(
                        name: "FK_Images_ImageItems_imageItemId",
                        column: x => x.imageItemId,
                        principalTable: "ImageItems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    questionItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    questionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    required = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Questions_QuestionItems_questionItemId",
                        column: x => x.questionItemId,
                        principalTable: "QuestionItems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChoiceQuestions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    questionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChoiceQuestions", x => x.id);
                    table.ForeignKey(
                        name: "FK_ChoiceQuestions_Questions_questionId",
                        column: x => x.questionId,
                        principalTable: "Questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    choiceQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.id);
                    table.ForeignKey(
                        name: "FK_Options_ChoiceQuestions_choiceQuestionId",
                        column: x => x.choiceQuestionId,
                        principalTable: "ChoiceQuestions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChoiceQuestions_questionId",
                table: "ChoiceQuestions",
                column: "questionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImageItems_itemId",
                table: "ImageItems",
                column: "itemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_imageItemId",
                table: "Images",
                column: "imageItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Options_choiceQuestionId",
                table: "Options",
                column: "choiceQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionItems_itemId",
                table: "QuestionItems",
                column: "itemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_questionItemId",
                table: "Questions",
                column: "questionItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuizSettings_settingsId",
                table: "QuizSettings",
                column: "settingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Forms_formId",
                table: "Items",
                column: "formId",
                principalTable: "Forms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Forms_formId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "QuizSettings");

            migrationBuilder.DropTable(
                name: "ImageItems");

            migrationBuilder.DropTable(
                name: "ChoiceQuestions");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "QuestionItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "Item");

            migrationBuilder.RenameIndex(
                name: "IX_Items_formId",
                table: "Item",
                newName: "IX_Item_formId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Forms_formId",
                table: "Item",
                column: "formId",
                principalTable: "Forms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
