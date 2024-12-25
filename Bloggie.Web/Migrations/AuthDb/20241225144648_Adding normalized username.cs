using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bloggie.Web.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class Addingnormalizedusername : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd24c75f-f7d2-4212-9334-25e0f9f40e42",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e0f8211f-c6b0-48fd-a520-5140245c47a3", "SUPERADMIN@BLOGGIE.COM", "superadmin@bloggie.com", "AQAAAAIAAYagAAAAEFh7zjeQjk2Yr9qoB0sUv3EzYGw/MIdIHf9Augc77R2OitCg9OkPr/Z6z2y2+NrnWw==", "e35e32b0-333c-43c8-b654-e53b1c53cbc9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd24c75f-f7d2-4212-9334-25e0f9f40e42",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee7e28c2-f981-495f-9f07-f0085adc07cd", null, null, "AQAAAAIAAYagAAAAEBemCSt4mRBHGRGZMpvXeyMg1VEU5Io6u8L/t/Lg/fiusY//PFmxCl6m3nmcSyvlog==", "61734ef4-ba8b-498a-a20e-cdb7ef70ca27" });
        }
    }
}
