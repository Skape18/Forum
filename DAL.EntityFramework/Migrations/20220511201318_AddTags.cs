using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.EntityFramework.Migrations
{
    public partial class AddTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "dbe1c9bf-e0b1-445b-b6dc-19c7c1f6b586", "75ea6112-8d79-4870-9ba4-ad241707e477" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dbe1c9bf-e0b1-445b-b6dc-19c7c1f6b586");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75ea6112-8d79-4870-9ba4-ad241707e477");

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TagUserProfile",
                columns: table => new
                {
                    TagsId = table.Column<int>(type: "int", nullable: false),
                    UserProfilesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagUserProfile", x => new { x.TagsId, x.UserProfilesId });
                    table.ForeignKey(
                        name: "FK_TagUserProfile_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagUserProfile_UserProfiles_UserProfilesId",
                        column: x => x.UserProfilesId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "625ef846-c80e-46e0-a363-884f2c99067e", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "23bd5e5b-6528-4f2c-960a-1466e705e75e", 0, "2200ba9c-c75e-4489-a5d0-750c6ae552bb", "andrei.marinich@gmail.com", true, false, null, "ANDREI.MARINICH@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEN9verbcjkqo9Ed/J/3YyWakJUpVmXFDo8lgIHMd8C9JEUin9+1IfcVCogfa7RXMPw==", null, false, "49996aaa-a9fd-47d1-9265-b1e381d4f97b", false, "admin" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "PostDate",
                value: new DateTime(2022, 5, 11, 23, 13, 17, 627, DateTimeKind.Local).AddTicks(8328));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "PostDate",
                value: new DateTime(2022, 5, 11, 23, 13, 17, 627, DateTimeKind.Local).AddTicks(8847));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "PostDate",
                value: new DateTime(2022, 5, 11, 23, 13, 17, 627, DateTimeKind.Local).AddTicks(8993));

            migrationBuilder.UpdateData(
                table: "Threads",
                keyColumn: "Id",
                keyValue: 1,
                column: "ThreadOpenedDate",
                value: new DateTime(2022, 5, 11, 23, 13, 17, 627, DateTimeKind.Local).AddTicks(7498));

            migrationBuilder.UpdateData(
                table: "Threads",
                keyColumn: "Id",
                keyValue: 2,
                column: "ThreadOpenedDate",
                value: new DateTime(2022, 5, 11, 23, 13, 17, 627, DateTimeKind.Local).AddTicks(7891));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "625ef846-c80e-46e0-a363-884f2c99067e", "23bd5e5b-6528-4f2c-960a-1466e705e75e" });

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ApplicationUserId", "RegistrationDate" },
                values: new object[] { "23bd5e5b-6528-4f2c-960a-1466e705e75e", new DateTime(2022, 5, 11, 23, 13, 17, 626, DateTimeKind.Local).AddTicks(455) });

            migrationBuilder.CreateIndex(
                name: "IX_TagUserProfile_UserProfilesId",
                table: "TagUserProfile",
                column: "UserProfilesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TagUserProfile");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "625ef846-c80e-46e0-a363-884f2c99067e", "23bd5e5b-6528-4f2c-960a-1466e705e75e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "625ef846-c80e-46e0-a363-884f2c99067e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "23bd5e5b-6528-4f2c-960a-1466e705e75e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dbe1c9bf-e0b1-445b-b6dc-19c7c1f6b586", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "75ea6112-8d79-4870-9ba4-ad241707e477", 0, "bc5b6e5e-cfbe-49af-8e98-bebe8f718178", "andrei.marinich@gmail.com", true, false, null, "ANDREI.MARINICH@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEKGkkrFXQz1N7nVHcJW3zgYUarbMHc8bPIQR0Z+J6Y7VbFdrs/QRzE32jf70bXRLtw==", null, false, "16eba243-9caf-4812-acfb-6d41aa739616", false, "admin" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "PostDate",
                value: new DateTime(2019, 4, 17, 3, 15, 47, 310, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "PostDate",
                value: new DateTime(2019, 4, 17, 3, 15, 47, 310, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "PostDate",
                value: new DateTime(2019, 4, 17, 3, 15, 47, 311, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Threads",
                keyColumn: "Id",
                keyValue: 1,
                column: "ThreadOpenedDate",
                value: new DateTime(2019, 4, 17, 3, 15, 47, 310, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Threads",
                keyColumn: "Id",
                keyValue: 2,
                column: "ThreadOpenedDate",
                value: new DateTime(2019, 4, 17, 3, 15, 47, 310, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "dbe1c9bf-e0b1-445b-b6dc-19c7c1f6b586", "75ea6112-8d79-4870-9ba4-ad241707e477" });

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ApplicationUserId", "RegistrationDate" },
                values: new object[] { "75ea6112-8d79-4870-9ba4-ad241707e477", new DateTime(2019, 4, 17, 3, 15, 47, 306, DateTimeKind.Local) });
        }
    }
}
