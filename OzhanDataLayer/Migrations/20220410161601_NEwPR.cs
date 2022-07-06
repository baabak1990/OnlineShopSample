using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OzhanDataLayer.Migrations
{
    public partial class NEwPR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseProduct",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Price = table.Column<double>(type: "float", maxLength: 50, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OffSale = table.Column<double>(type: "float", maxLength: 50, nullable: false),
                    LongDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", maxLength: 200, nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    RGB = table.Column<int>(type: "int", nullable: false),
                    Group = table.Column<int>(type: "int", nullable: false),
                    SubGroup = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Creator = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Chipset = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CpuType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Format = table.Column<int>(type: "int", maxLength: 100, nullable: true),
                    CpuZipCount = table.Column<int>(type: "int", maxLength: 100, nullable: true),
                    CpuDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RamGeneration = table.Column<int>(type: "int", maxLength: 100, nullable: true),
                    RamCapacities = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DualChanel = table.Column<int>(type: "int", maxLength: 100, nullable: true),
                    RamDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DimmRam = table.Column<int>(type: "int", maxLength: 100, nullable: true),
                    HdimPorts = table.Column<int>(type: "int", nullable: true),
                    HdmiDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DVIPorts = table.Column<int>(type: "int", nullable: true),
                    DviDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RgbPorts = table.Column<int>(type: "int", nullable: true),
                    RgbDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayPorts = table.Column<int>(type: "int", nullable: true),
                    DisplayDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SliSupport = table.Column<int>(type: "int", nullable: true),
                    SliDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CrossFireSupport = table.Column<int>(type: "int", nullable: true),
                    CrossFireDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PCIe5_0_16 = table.Column<int>(type: "int", nullable: true),
                    PCIe5_0num = table.Column<int>(type: "int", nullable: true),
                    PCIe3_16 = table.Column<int>(type: "int", nullable: true),
                    PCIe3_16_0num = table.Column<int>(type: "int", nullable: true),
                    PCIe3_4 = table.Column<int>(type: "int", nullable: true),
                    PCIe3_4_0num = table.Column<int>(type: "int", nullable: true),
                    PCIe3_1 = table.Column<int>(type: "int", nullable: true),
                    PCIe3_1_0num = table.Column<int>(type: "int", nullable: true),
                    RearUsb3_2Gen2_2 = table.Column<int>(type: "int", nullable: true),
                    RearUsb3_2Gen = table.Column<int>(type: "int", nullable: true),
                    RearUsb3_1Gen = table.Column<int>(type: "int", nullable: true),
                    FrontUsb3_1Gen = table.Column<int>(type: "int", nullable: true),
                    FrontUsb3_2Gen = table.Column<int>(type: "int", nullable: true),
                    FrontUsb2Gen = table.Column<int>(type: "int", nullable: true),
                    CpuFanHeaders = table.Column<int>(type: "int", nullable: true),
                    CpuOPTFanHeaders = table.Column<int>(type: "int", nullable: true),
                    AIOFanHeaders = table.Column<int>(type: "int", nullable: true),
                    ChassisFanHeader = table.Column<int>(type: "int", nullable: true),
                    TwentyFourPinPowerConnector = table.Column<int>(type: "int", nullable: true),
                    Eight12VPinPowerConnector = table.Column<int>(type: "int", nullable: true),
                    Four12VPinPowerConnector = table.Column<int>(type: "int", nullable: true),
                    PortLan = table.Column<int>(type: "int", nullable: true),
                    PortLanDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wireless = table.Column<int>(type: "int", nullable: true),
                    WifiDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlueTooth = table.Column<int>(type: "int", nullable: true),
                    BlueToothDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    M2Prot = table.Column<int>(type: "int", nullable: true),
                    M2Protnum = table.Column<int>(type: "int", nullable: true),
                    Sata6Gb = table.Column<int>(type: "int", nullable: true),
                    Sata6Gbnum = table.Column<int>(type: "int", nullable: true),
                    Sata = table.Column<int>(type: "int", nullable: true),
                    AuraRgbHeader = table.Column<int>(type: "int", nullable: true),
                    ClearCmosBottom = table.Column<int>(type: "int", nullable: true),
                    Bios = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    M2Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    M2_2Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    M2_3Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    M2_4Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RaidSupport = table.Column<int>(type: "int", nullable: true),
                    RaidDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AudioDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseProduct_CourseGroups_Group",
                        column: x => x.Group,
                        principalTable: "CourseGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseProduct_CourseGroups_SubGroup",
                        column: x => x.SubGroup,
                        principalTable: "CourseGroups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Garanties",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseProduct_Id = table.Column<long>(type: "bigint", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garanties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdcutGaranties",
                columns: table => new
                {
                    PGA_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Garanty_Id = table.Column<byte>(type: "tinyint", nullable: false),
                    BaseProduct_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdcutGaranties", x => x.PGA_Id);
                    table.ForeignKey(
                        name: "FK_ProdcutGaranties_BaseProduct_BaseProduct_Id",
                        column: x => x.BaseProduct_Id,
                        principalTable: "BaseProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdcutGaranties_Garanties_Garanty_Id",
                        column: x => x.Garanty_Id,
                        principalTable: "Garanties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseProduct_Group",
                table: "BaseProduct",
                column: "Group");

            migrationBuilder.CreateIndex(
                name: "IX_BaseProduct_SubGroup",
                table: "BaseProduct",
                column: "SubGroup");

            migrationBuilder.CreateIndex(
                name: "IX_ProdcutGaranties_BaseProduct_Id",
                table: "ProdcutGaranties",
                column: "BaseProduct_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProdcutGaranties_Garanty_Id",
                table: "ProdcutGaranties",
                column: "Garanty_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdcutGaranties");

            migrationBuilder.DropTable(
                name: "BaseProduct");

            migrationBuilder.DropTable(
                name: "Garanties");
        }
    }
}
