﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotnetMarketplace.Migrations
{
    public partial class AddCreatedDateAndUpdatedDateTransactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "date",
                table: "Transactions",
                newName: "UpdatedDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Transactions",
                newName: "date");
        }
    }
}
