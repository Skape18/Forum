using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.EntityFramework.Migrations
{
    public partial class SecurityStampGenerationUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "c2a4aab0-40d5-4fc3-b9a3-37dabac6d21c", "101976fb-b9f5-4f19-95fc-8222a583d7d3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "101976fb-b9f5-4f19-95fc-8222a583d7d3", null });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "c2a4aab0-40d5-4fc3-b9a3-37dabac6d21c", "79eb5331-6b3d-47b5-a617-e3c8c65625bb" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "812a55c0-2fcd-47ef-9794-0447b1f60dfc", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1ca5a133-49d0-4124-9060-ebb66bac22fa", 0, "4cbee816-f74b-4ad2-b183-945e17856c67", "andrei.marinich@gmail.com", true, false, null, "ANDREI.MARINICH@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAELb/nDHEHgQJ6uisuviKbC6hDwQJjM4v65bjX72CXyJe4hIp0+x4irzIhNlpCsom5A==", null, false, "c3d66479-50e5-4bd4-8528-557e01b13da8", false, "admin" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "PostDate",
                value: new DateTime(2019, 4, 7, 21, 4, 3, 667, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "PostDate",
                value: new DateTime(2019, 4, 7, 21, 4, 3, 667, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "PostDate",
                value: new DateTime(2019, 4, 7, 21, 4, 3, 667, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Threads",
                keyColumn: "Id",
                keyValue: 1,
                column: "ThreadOpenedDate",
                value: new DateTime(2019, 4, 7, 21, 4, 3, 666, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Threads",
                keyColumn: "Id",
                keyValue: 2,
                column: "ThreadOpenedDate",
                value: new DateTime(2019, 4, 7, 21, 4, 3, 666, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "1ca5a133-49d0-4124-9060-ebb66bac22fa", "812a55c0-2fcd-47ef-9794-0447b1f60dfc" });

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ApplicationUserId", "RegistrationDate" },
                values: new object[] { "1ca5a133-49d0-4124-9060-ebb66bac22fa", new DateTime(2019, 4, 7, 21, 4, 3, 664, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "1ca5a133-49d0-4124-9060-ebb66bac22fa", "812a55c0-2fcd-47ef-9794-0447b1f60dfc" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "812a55c0-2fcd-47ef-9794-0447b1f60dfc", null });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "1ca5a133-49d0-4124-9060-ebb66bac22fa", "4cbee816-f74b-4ad2-b183-945e17856c67" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "101976fb-b9f5-4f19-95fc-8222a583d7d3", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c2a4aab0-40d5-4fc3-b9a3-37dabac6d21c", 0, "79eb5331-6b3d-47b5-a617-e3c8c65625bb", "andrei.marinich@gmail.com", true, false, null, "ANDREI.MARINICH@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEIh15Wx1vNkVwXDkdccUPxqlbQkCg4t3QC4huuNdK5kWNmRAtskAx8MAfYQDC1YyCA==", null, false, "", false, "admin" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "PostDate",
                value: new DateTime(2019, 4, 6, 15, 53, 40, 514, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "PostDate",
                value: new DateTime(2019, 4, 6, 15, 53, 40, 514, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "PostDate",
                value: new DateTime(2019, 4, 6, 15, 53, 40, 514, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Threads",
                keyColumn: "Id",
                keyValue: 1,
                column: "ThreadOpenedDate",
                value: new DateTime(2019, 4, 6, 15, 53, 40, 513, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Threads",
                keyColumn: "Id",
                keyValue: 2,
                column: "ThreadOpenedDate",
                value: new DateTime(2019, 4, 6, 15, 53, 40, 513, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "c2a4aab0-40d5-4fc3-b9a3-37dabac6d21c", "101976fb-b9f5-4f19-95fc-8222a583d7d3" });

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ApplicationUserId", "RegistrationDate" },
                values: new object[] { "c2a4aab0-40d5-4fc3-b9a3-37dabac6d21c", new DateTime(2019, 4, 6, 15, 53, 40, 510, DateTimeKind.Local) });
        }
    }
}
