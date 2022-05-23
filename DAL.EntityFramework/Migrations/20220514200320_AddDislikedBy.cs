using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.EntityFramework.Migrations
{
    public partial class AddDislikedBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "UserProfileUserProfile1",
                columns: table => new
                {
                    DislikedById = table.Column<int>(type: "int", nullable: false),
                    DislikedToId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfileUserProfile1", x => new { x.DislikedById, x.DislikedToId });
                    table.ForeignKey(
                        name: "FK_UserProfileUserProfile1_UserProfiles_DislikedById",
                        column: x => x.DislikedById,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProfileUserProfile1_UserProfiles_DislikedToId",
                        column: x => x.DislikedToId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3c0584e7-fffa-4d35-bb53-136dfeb3cb20", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ba64dce4-2074-4edf-a416-3e820243d4fe", 0, "ee12c43c-4c3b-491c-9c85-e14292890836", "andrei.marinich@gmail.com", true, false, null, "ANDREI.MARINICH@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEPDKu6u7PqrJgHTMZGp9QWYJinbxLakHy6y06Sz3bZc2Mn3Hweumk6217ro/IvT60Q==", null, false, "ba5a9287-abc3-44fe-b4f0-98f7636fe9db", false, "admin" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "PostDate",
                value: new DateTime(2022, 5, 14, 23, 3, 19, 563, DateTimeKind.Local).AddTicks(7210));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "PostDate",
                value: new DateTime(2022, 5, 14, 23, 3, 19, 563, DateTimeKind.Local).AddTicks(7836));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "PostDate",
                value: new DateTime(2022, 5, 14, 23, 3, 19, 563, DateTimeKind.Local).AddTicks(7987));

            migrationBuilder.UpdateData(
                table: "Threads",
                keyColumn: "Id",
                keyValue: 1,
                column: "ThreadOpenedDate",
                value: new DateTime(2022, 5, 14, 23, 3, 19, 563, DateTimeKind.Local).AddTicks(6077));

            migrationBuilder.UpdateData(
                table: "Threads",
                keyColumn: "Id",
                keyValue: 2,
                column: "ThreadOpenedDate",
                value: new DateTime(2022, 5, 14, 23, 3, 19, 563, DateTimeKind.Local).AddTicks(6530));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3c0584e7-fffa-4d35-bb53-136dfeb3cb20", "ba64dce4-2074-4edf-a416-3e820243d4fe" });

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ApplicationUserId", "RegistrationDate" },
                values: new object[] { "ba64dce4-2074-4edf-a416-3e820243d4fe", new DateTime(2022, 5, 14, 23, 3, 19, 561, DateTimeKind.Local).AddTicks(9606) });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileUserProfile1_DislikedToId",
                table: "UserProfileUserProfile1",
                column: "DislikedToId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProfileUserProfile1");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3c0584e7-fffa-4d35-bb53-136dfeb3cb20", "ba64dce4-2074-4edf-a416-3e820243d4fe" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c0584e7-fffa-4d35-bb53-136dfeb3cb20");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba64dce4-2074-4edf-a416-3e820243d4fe");

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
        }
    }
}
