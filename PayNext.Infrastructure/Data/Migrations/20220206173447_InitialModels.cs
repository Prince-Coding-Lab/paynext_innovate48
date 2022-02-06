using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PayNext.Infrastructure.Data.Migrations
{
    public partial class InitialModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsActiveAtApp = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardId = table.Column<int>(type: "int", nullable: false),
                    OutstandingBill = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BillingCycleDay = table.Column<int>(type: "int", nullable: true),
                    NextBillDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bills_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CardId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "CardNumber", "CreatedBy", "CreatedDate", "IsActive", "IsActiveAtApp", "IssueDate", "ModifiedBy", "ModifiedDate", "ValidDate" },
                values: new object[,]
                {
                    { 1, "5421765209285822", null, new DateTime(2022, 2, 6, 23, 4, 46, 135, DateTimeKind.Local).AddTicks(2733), true, false, new DateTime(2022, 2, 6, 23, 4, 46, 133, DateTimeKind.Local).AddTicks(5612), null, null, new DateTime(2025, 2, 6, 23, 4, 46, 135, DateTimeKind.Local).AddTicks(64) },
                    { 2, "5383249064902017", null, new DateTime(2022, 2, 6, 23, 4, 46, 135, DateTimeKind.Local).AddTicks(3680), true, false, new DateTime(2022, 2, 6, 23, 4, 46, 135, DateTimeKind.Local).AddTicks(3593), null, null, new DateTime(2025, 2, 6, 23, 4, 46, 135, DateTimeKind.Local).AddTicks(3621) },
                    { 3, "5547240944242164", null, new DateTime(2022, 2, 6, 23, 4, 46, 135, DateTimeKind.Local).AddTicks(3704), true, false, new DateTime(2022, 2, 6, 23, 4, 46, 135, DateTimeKind.Local).AddTicks(3697), null, null, new DateTime(2025, 2, 6, 23, 4, 46, 135, DateTimeKind.Local).AddTicks(3700) },
                    { 4, "5537555179872381", null, new DateTime(2022, 2, 6, 23, 4, 46, 135, DateTimeKind.Local).AddTicks(3714), true, false, new DateTime(2022, 2, 6, 23, 4, 46, 135, DateTimeKind.Local).AddTicks(3707), null, null, new DateTime(2025, 2, 6, 23, 4, 46, 135, DateTimeKind.Local).AddTicks(3710) },
                    { 5, "5447906631230792", null, new DateTime(2022, 2, 6, 23, 4, 46, 135, DateTimeKind.Local).AddTicks(3723), true, false, new DateTime(2022, 2, 6, 23, 4, 46, 135, DateTimeKind.Local).AddTicks(3717), null, null, new DateTime(2025, 2, 6, 23, 4, 46, 135, DateTimeKind.Local).AddTicks(3719) },
                    { 6, "4064087200235085", null, new DateTime(2022, 2, 6, 23, 4, 46, 135, DateTimeKind.Local).AddTicks(3732), true, false, new DateTime(2022, 2, 6, 23, 4, 46, 135, DateTimeKind.Local).AddTicks(3726), null, null, new DateTime(2025, 2, 6, 23, 4, 46, 135, DateTimeKind.Local).AddTicks(3728) },
                    { 7, "4556610932416767", null, new DateTime(2022, 2, 6, 23, 4, 46, 135, DateTimeKind.Local).AddTicks(3741), true, false, new DateTime(2022, 2, 6, 23, 4, 46, 135, DateTimeKind.Local).AddTicks(3735), null, null, new DateTime(2025, 2, 6, 23, 4, 46, 135, DateTimeKind.Local).AddTicks(3737) },
                    { 8, "4024007173812818", null, new DateTime(2022, 2, 6, 23, 4, 46, 135, DateTimeKind.Local).AddTicks(3750), true, false, new DateTime(2022, 2, 6, 23, 4, 46, 135, DateTimeKind.Local).AddTicks(3744), null, null, new DateTime(2025, 2, 6, 23, 4, 46, 135, DateTimeKind.Local).AddTicks(3746) },
                    { 9, "4024007180147869", null, new DateTime(2022, 2, 6, 23, 4, 46, 135, DateTimeKind.Local).AddTicks(3758), true, false, new DateTime(2022, 2, 6, 23, 4, 46, 135, DateTimeKind.Local).AddTicks(3753), null, null, new DateTime(2025, 2, 6, 23, 4, 46, 135, DateTimeKind.Local).AddTicks(3755) },
                    { 10, "4024007199373613", null, new DateTime(2022, 2, 6, 23, 4, 46, 135, DateTimeKind.Local).AddTicks(3767), true, false, new DateTime(2022, 2, 6, 23, 4, 46, 135, DateTimeKind.Local).AddTicks(3761), null, null, new DateTime(2025, 2, 6, 23, 4, 46, 135, DateTimeKind.Local).AddTicks(3764) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bills_CardId",
                table: "Bills",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CardId",
                table: "Users",
                column: "CardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cards");
        }
    }
}
