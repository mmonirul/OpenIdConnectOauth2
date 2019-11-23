using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WestPay.Access.DAL.Database.Migrations
{
    public partial class TarminalEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalTerminals_TerminalModelId",
                table: "PhysicalTerminals",
                column: "TerminalModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OperationSetting");

            migrationBuilder.DropTable(
                name: "PhysicalTerminals");

            migrationBuilder.DropTable(
                name: "TerminalOperationModes");

            migrationBuilder.DropTable(
                name: "TerminalOperationSetting");

            migrationBuilder.DropTable(
                name: "TerminalModels");
        }
    }
}
