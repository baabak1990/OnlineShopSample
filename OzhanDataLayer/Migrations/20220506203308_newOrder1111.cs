using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OzhanDataLayer.Migrations
{
    public partial class newOrder1111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_Permissions_Permission_Id",
                table: "RolePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_roles_Role_Id",
                table: "RolePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserDetails_UserDetai_Id",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_RolePermissions_Permission_Id",
                table: "RolePermissions");

            migrationBuilder.DropIndex(
                name: "IX_RolePermissions_Role_Id",
                table: "RolePermissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDetails",
                table: "UserDetails");

            migrationBuilder.RenameTable(
                name: "UserDetails",
                newName: "UserDetailes");

            migrationBuilder.AddColumn<int>(
                name: "PermissionId",
                table: "RolePermissions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "RoleId",
                table: "RolePermissions",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDetailes",
                table: "UserDetailes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderSum = table.Column<double>(type: "float", nullable: false),
                    IsFinaly = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetailes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    BaseProductId = table.Column<long>(type: "bigint", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetailes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetailes_baseProducts_BaseProductId",
                        column: x => x.BaseProductId,
                        principalTable: "baseProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetailes_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_RoleId",
                table: "RolePermissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailes_BaseProductId",
                table: "OrderDetailes",
                column: "BaseProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailes_OrderId",
                table: "OrderDetailes",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_Permissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_roles_RoleId",
                table: "RolePermissions",
                column: "RoleId",
                principalTable: "roles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserDetailes_UserDetai_Id",
                table: "Users",
                column: "UserDetai_Id",
                principalTable: "UserDetailes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_Permissions_PermissionId",
                table: "RolePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_roles_RoleId",
                table: "RolePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserDetailes_UserDetai_Id",
                table: "Users");

            migrationBuilder.DropTable(
                name: "OrderDetailes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_RolePermissions_PermissionId",
                table: "RolePermissions");

            migrationBuilder.DropIndex(
                name: "IX_RolePermissions_RoleId",
                table: "RolePermissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDetailes",
                table: "UserDetailes");

            migrationBuilder.DropColumn(
                name: "PermissionId",
                table: "RolePermissions");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "RolePermissions");

            migrationBuilder.RenameTable(
                name: "UserDetailes",
                newName: "UserDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDetails",
                table: "UserDetails",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_Permission_Id",
                table: "RolePermissions",
                column: "Permission_Id");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_Role_Id",
                table: "RolePermissions",
                column: "Role_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_Permissions_Permission_Id",
                table: "RolePermissions",
                column: "Permission_Id",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_roles_Role_Id",
                table: "RolePermissions",
                column: "Role_Id",
                principalTable: "roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserDetails_UserDetai_Id",
                table: "Users",
                column: "UserDetai_Id",
                principalTable: "UserDetails",
                principalColumn: "Id");
        }
    }
}
