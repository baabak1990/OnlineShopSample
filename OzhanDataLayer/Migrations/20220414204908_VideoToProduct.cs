using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OzhanDataLayer.Migrations
{
    public partial class VideoToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "baseProducts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "baseProducts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Video",
                table: "baseProducts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "baseProducts");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "baseProducts");

            migrationBuilder.DropColumn(
                name: "Video",
                table: "baseProducts");
        }
    }
}
