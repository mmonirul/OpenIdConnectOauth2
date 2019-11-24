using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WestPay.Access.DAL.Database.Migrations
{
    public partial class InitApplicationDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Biographies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Biography = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    PlaceOfBirth = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biographies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "OperationSetting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PhysicalTerminalId = table.Column<string>(maxLength: 40, nullable: false),
                    TerminalModelId = table.Column<string>(nullable: false),
                    TerminalOperationModeId = table.Column<string>(nullable: false),
                    TerminalidOrderId = table.Column<int>(nullable: false),
                    ReceiptMerchantName = table.Column<string>(maxLength: 100, nullable: true),
                    ReceiptPhoneNumber = table.Column<string>(maxLength: 30, nullable: true),
                    Signature = table.Column<bool>(nullable: false),
                    Tipping = table.Column<bool>(nullable: false),
                    ChipXpress = table.Column<bool>(nullable: false),
                    LastEvent = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TerminalModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    SerialPrefix = table.Column<string>(nullable: true),
                    IsTerminal = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerminalModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TerminalOperationModes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: true),
                    RawName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerminalOperationModes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TerminalOperationSetting",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TerminalidId = table.Column<int>(nullable: false),
                    TerminalId = table.Column<int>(nullable: false),
                    TerminalOperatingModeId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    FirstTransactionTime = table.Column<DateTime>(nullable: true),
                    LastTransactionTime = table.Column<DateTime>(nullable: true),
                    PAVersion = table.Column<string>(maxLength: 20, nullable: true),
                    ReceivedParameters = table.Column<string>(maxLength: 220, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerminalOperationSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    AuthorBiographyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authors_Biographies_AuthorBiographyId",
                        column: x => x.AuthorBiographyId,
                        principalTable: "Biographies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalTerminals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LastEvent = table.Column<int>(nullable: false),
                    TimeCreated = table.Column<DateTime>(nullable: true),
                    TimeModified = table.Column<DateTime>(nullable: true),
                    Serial = table.Column<string>(nullable: true),
                    TerminalModelId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    TerminalId = table.Column<string>(nullable: true),
                    MerchantPassword = table.Column<string>(nullable: true),
                    TerminalOperationSettingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalTerminals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhysicalTerminals_TerminalModels_TerminalModelId",
                        column: x => x.TerminalModelId,
                        principalTable: "TerminalModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdatedBy = table.Column<string>(nullable: true),
                    ISBN = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    Pages = table.Column<int>(nullable: false),
                    PublisherId = table.Column<Guid>(nullable: false),
                    AuthorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookCategory",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategory", x => new { x.BookId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_BookCategory_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_AuthorBiographyId",
                table: "Authors",
                column: "AuthorBiographyId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCategory_CategoryId",
                table: "BookCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_ISBN",
                table: "Books",
                column: "ISBN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalTerminals_TerminalModelId",
                table: "PhysicalTerminals",
                column: "TerminalModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookCategory");

            migrationBuilder.DropTable(
                name: "OperationSetting");

            migrationBuilder.DropTable(
                name: "PhysicalTerminals");

            migrationBuilder.DropTable(
                name: "TerminalOperationModes");

            migrationBuilder.DropTable(
                name: "TerminalOperationSetting");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "TerminalModels");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "Biographies");
        }
    }
}
