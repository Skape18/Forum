using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.EntityFramework.Migrations
{
    public partial class AddLikedBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "UserProfileUserProfile",
                columns: table => new
                {
                    LikedById = table.Column<int>(type: "int", nullable: false),
                    LikedToId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfileUserProfile", x => new { x.LikedById, x.LikedToId });
                    table.ForeignKey(
                        name: "FK_UserProfileUserProfile_UserProfiles_LikedById",
                        column: x => x.LikedById,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProfileUserProfile_UserProfiles_LikedToId",
                        column: x => x.LikedToId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ec0f40ba-9c65-4917-a04b-d0628d073e66", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4fbf864b-958f-4eb2-ac2c-17c19498f507", 0, "450beb83-c72b-4234-9698-ef68c98d75fd", "andrei.marinich@gmail.com", true, false, null, "ANDREI.MARINICH@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEP0BKfHypPI4z4YPC0O+h/D6T1SY8CAA87eTFvuvjAUjW1WCu4GRLpok9CSPK4PgVA==", null, false, "e34b36cd-e983-4e42-b42d-018c9cd97d70", false, "admin" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "PostDate",
                value: new DateTime(2022, 5, 12, 0, 6, 24, 797, DateTimeKind.Local).AddTicks(3258));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "PostDate",
                value: new DateTime(2022, 5, 12, 0, 6, 24, 797, DateTimeKind.Local).AddTicks(3759));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "PostDate",
                value: new DateTime(2022, 5, 12, 0, 6, 24, 797, DateTimeKind.Local).AddTicks(3904));

            migrationBuilder.UpdateData(
                table: "Threads",
                keyColumn: "Id",
                keyValue: 1,
                column: "ThreadOpenedDate",
                value: new DateTime(2022, 5, 12, 0, 6, 24, 797, DateTimeKind.Local).AddTicks(2445));

            migrationBuilder.UpdateData(
                table: "Threads",
                keyColumn: "Id",
                keyValue: 2,
                column: "ThreadOpenedDate",
                value: new DateTime(2022, 5, 12, 0, 6, 24, 797, DateTimeKind.Local).AddTicks(2837));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ec0f40ba-9c65-4917-a04b-d0628d073e66", "4fbf864b-958f-4eb2-ac2c-17c19498f507" });

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ApplicationUserId", "RegistrationDate" },
                values: new object[] { "4fbf864b-958f-4eb2-ac2c-17c19498f507", new DateTime(2022, 5, 12, 0, 6, 24, 795, DateTimeKind.Local).AddTicks(9878) });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileUserProfile_LikedToId",
                table: "UserProfileUserProfile",
                column: "LikedToId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProfileUserProfile");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ec0f40ba-9c65-4917-a04b-d0628d073e66", "4fbf864b-958f-4eb2-ac2c-17c19498f507" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec0f40ba-9c65-4917-a04b-d0628d073e66");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4fbf864b-958f-4eb2-ac2c-17c19498f507");

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
        }
    }
}
