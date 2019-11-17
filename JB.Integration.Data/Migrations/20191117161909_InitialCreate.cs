using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JB.Integration.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Created", "Email", "LastUpdated", "Password", "UserName" },
                values: new object[,]
                {
                    { new Guid("d47b7038-4bee-4beb-90b5-8f424938c862"), new DateTime(2019, 11, 17, 17, 19, 9, 338, DateTimeKind.Local).AddTicks(6372), "johnnblade@hotmail.com", new DateTime(2019, 11, 17, 17, 19, 9, 342, DateTimeKind.Local).AddTicks(1146), "12345678", "John Doe1" },
                    { new Guid("2641a7b5-d60e-4188-9cef-43231d37649f"), new DateTime(2019, 11, 17, 17, 19, 9, 342, DateTimeKind.Local).AddTicks(2181), "johnnblade2@hotmail.com", new DateTime(2019, 11, 17, 17, 19, 9, 342, DateTimeKind.Local).AddTicks(2219), "12345678", "John Doe2" },
                    { new Guid("a1d76be3-29a7-4b0d-b967-9b60e07d098b"), new DateTime(2019, 11, 17, 17, 19, 9, 342, DateTimeKind.Local).AddTicks(2247), "johnnblade3@hotmail.com", new DateTime(2019, 11, 17, 17, 19, 9, 342, DateTimeKind.Local).AddTicks(2253), "12345678", "John Doe3" },
                    { new Guid("412a7aea-8019-4849-9d0c-9bd339dc3d70"), new DateTime(2019, 11, 17, 17, 19, 9, 342, DateTimeKind.Local).AddTicks(2261), "johnnblade4@hotmail.com", new DateTime(2019, 11, 17, 17, 19, 9, 342, DateTimeKind.Local).AddTicks(2266), "12345678", "John Doe4" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
