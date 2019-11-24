using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WestPay.Access.DAL.Database.Migrations
{
    public partial class UpdateAuthorApplicationDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Biographies_AuthorBiographyId",
                table: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_Authors_AuthorBiographyId",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "AuthorBiographyId",
                table: "Authors");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Biographies",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Biographies_Authors_Id",
                table: "Biographies",
                column: "Id",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Biographies_Authors_Id",
                table: "Biographies");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Biographies",
                nullable: false,
                oldClrType: typeof(Guid))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "AuthorBiographyId",
                table: "Authors",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Authors_AuthorBiographyId",
                table: "Authors",
                column: "AuthorBiographyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Biographies_AuthorBiographyId",
                table: "Authors",
                column: "AuthorBiographyId",
                principalTable: "Biographies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
