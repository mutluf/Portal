using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portal.Persistence.Migrations
{
    public partial class mig_7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MessageId",
                table: "Workshops",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MessageId",
                table: "Seminars",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MessageId",
                table: "Educations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MessageId",
                table: "Blogs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MessageUser",
                columns: table => new
                {
                    MessagesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageUser", x => new { x.MessagesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_MessageUser_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessageUser_Messages_MessagesId",
                        column: x => x.MessagesId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workshops_MessageId",
                table: "Workshops",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Seminars_MessageId",
                table: "Seminars",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_MessageId",
                table: "Educations",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_MessageId",
                table: "Blogs",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageUser_UsersId",
                table: "MessageUser",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Messages_MessageId",
                table: "Blogs",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_Messages_MessageId",
                table: "Educations",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Seminars_Messages_MessageId",
                table: "Seminars",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Workshops_Messages_MessageId",
                table: "Workshops",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Messages_MessageId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Educations_Messages_MessageId",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_Seminars_Messages_MessageId",
                table: "Seminars");

            migrationBuilder.DropForeignKey(
                name: "FK_Workshops_Messages_MessageId",
                table: "Workshops");

            migrationBuilder.DropTable(
                name: "MessageUser");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Workshops_MessageId",
                table: "Workshops");

            migrationBuilder.DropIndex(
                name: "IX_Seminars_MessageId",
                table: "Seminars");

            migrationBuilder.DropIndex(
                name: "IX_Educations_MessageId",
                table: "Educations");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_MessageId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "MessageId",
                table: "Workshops");

            migrationBuilder.DropColumn(
                name: "MessageId",
                table: "Seminars");

            migrationBuilder.DropColumn(
                name: "MessageId",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "MessageId",
                table: "Blogs");
        }
    }
}
