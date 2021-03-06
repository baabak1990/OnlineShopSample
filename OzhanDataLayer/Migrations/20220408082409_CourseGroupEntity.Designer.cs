// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OzhanDataLayer.Context;

namespace OzhanDataLayer.Migrations
{
    [DbContext(typeof(OzhanContext))]
    [Migration("20220408082409_CourseGroupEntity")]
    partial class CourseGroupEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OzhanDomainLayer.Entities.Accounts.User.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("OzhanDomainLayer.Entities.Accounts.User.Role", b =>
                {
                    b.Property<byte>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("OzhanDomainLayer.Entities.Accounts.User.RolePermission", b =>
                {
                    b.Property<byte>("RP_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Permission_Id")
                        .HasColumnType("int");

                    b.Property<byte>("Role_Id")
                        .HasColumnType("tinyint");

                    b.HasKey("RP_Id");

                    b.HasIndex("Permission_Id");

                    b.HasIndex("Role_Id");

                    b.ToTable("RolePermissions");
                });

            modelBuilder.Entity("OzhanDomainLayer.Entities.Accounts.User.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActiveCode")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Family")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ImageName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long?>("UserDetai_Id")
                        .HasColumnType("bigint");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("UserDetai_Id")
                        .IsUnique()
                        .HasFilter("[UserDetai_Id] IS NOT NULL");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            ActiveCode = "1234",
                            CreateDate = new DateTime(2022, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = " baabakaghaei@gmail.com",
                            Family = "Aghaei",
                            ImageName = "default",
                            IsActive = false,
                            IsDeleted = false,
                            Name = "baabak",
                            Password = "1234",
                            UserDetai_Id = 1L,
                            UserName = "Admin"
                        });
                });

            modelBuilder.Entity("OzhanDomainLayer.Entities.Accounts.User.UserDetailes", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("City")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("State")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Urban")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("UserDetails");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Address = "teh",
                            CreateDate = new DateTime(2022, 3, 11, 12, 23, 30, 0, DateTimeKind.Unspecified),
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("OzhanDomainLayer.Entities.Accounts.User.UserRoles", b =>
                {
                    b.Property<long>("User_Id")
                        .HasColumnType("bigint");

                    b.Property<byte>("RoleP_Id")
                        .HasColumnType("tinyint");

                    b.HasKey("User_Id", "RoleP_Id");

                    b.HasIndex("RoleP_Id");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("OzhanDomainLayer.Entities.Products.Crouses.CourseGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("CourseGroups");
                });

            modelBuilder.Entity("OzhanDomainLayer.Entities.Accounts.User.Permission", b =>
                {
                    b.HasOne("OzhanDomainLayer.Entities.Accounts.User.Permission", null)
                        .WithMany("Permissions")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("OzhanDomainLayer.Entities.Accounts.User.RolePermission", b =>
                {
                    b.HasOne("OzhanDomainLayer.Entities.Accounts.User.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("Permission_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OzhanDomainLayer.Entities.Accounts.User.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("Role_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("OzhanDomainLayer.Entities.Accounts.User.User", b =>
                {
                    b.HasOne("OzhanDomainLayer.Entities.Accounts.User.UserDetailes", "UserDetails")
                        .WithOne("User")
                        .HasForeignKey("OzhanDomainLayer.Entities.Accounts.User.User", "UserDetai_Id");

                    b.Navigation("UserDetails");
                });

            modelBuilder.Entity("OzhanDomainLayer.Entities.Accounts.User.UserRoles", b =>
                {
                    b.HasOne("OzhanDomainLayer.Entities.Accounts.User.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleP_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OzhanDomainLayer.Entities.Accounts.User.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OzhanDomainLayer.Entities.Products.Crouses.CourseGroup", b =>
                {
                    b.HasOne("OzhanDomainLayer.Entities.Products.Crouses.CourseGroup", null)
                        .WithMany("CrouseGroups")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("OzhanDomainLayer.Entities.Accounts.User.Permission", b =>
                {
                    b.Navigation("Permissions");

                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("OzhanDomainLayer.Entities.Accounts.User.Role", b =>
                {
                    b.Navigation("RolePermissions");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("OzhanDomainLayer.Entities.Accounts.User.User", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("OzhanDomainLayer.Entities.Accounts.User.UserDetailes", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("OzhanDomainLayer.Entities.Products.Crouses.CourseGroup", b =>
                {
                    b.Navigation("CrouseGroups");
                });
#pragma warning restore 612, 618
        }
    }
}
