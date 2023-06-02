﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GiveTheBookBack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddStateToTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Transactions");
        }
    }
}
