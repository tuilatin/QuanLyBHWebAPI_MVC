using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QUANLYBANHANG.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentityTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "APPLICATIONS",
                columns: table => new
                {
                    ID_APPLICATION = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    APPLICATION_NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APPLICATIONS", x => x.ID_APPLICATION);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GENDER_TYPE",
                columns: table => new
                {
                    GENDER_TYPE_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    GENDER_TYPE_NAME = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__GENDER_TYPE__3D9E16F4", x => x.GENDER_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "GROUP_USER",
                columns: table => new
                {
                    ID_GROUP = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GROUP_NAME = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GROUP_USER", x => x.ID_GROUP);
                });

            migrationBuilder.CreateTable(
                name: "MENU_FORM",
                columns: table => new
                {
                    ID_MENU_FORM = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MENU_FORM_NAME = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    MENU_FORM_URL = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MOTA = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SORT_PARENT = table.Column<byte>(type: "tinyint", nullable: true),
                    SORT = table.Column<byte>(type: "tinyint", nullable: true),
                    ID_MENU_FORM_PARENT = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    DANH_MUC = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    VISIBLE = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MENU_FORM", x => x.ID_MENU_FORM);
                    table.ForeignKey(
                        name: "FK_MENU_FORM_MENU_FORM",
                        column: x => x.ID_MENU_FORM_PARENT,
                        principalTable: "MENU_FORM",
                        principalColumn: "ID_MENU_FORM");
                });

            migrationBuilder.CreateTable(
                name: "PARTY",
                columns: table => new
                {
                    PARTY_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TYPE_OF_PARTY = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DEPARTMENT_ID = table.Column<int>(type: "int", nullable: true),
                    USERNAME = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PASSWORD = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    USERNAME_H = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    PASSWORD_H = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PARTY_1", x => x.PARTY_ID);
                });

            migrationBuilder.CreateTable(
                name: "tbDANHMUC",
                columns: table => new
                {
                    MADANHMUC = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TENDANHMUC = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DANHMUCCHA = table.Column<int>(type: "int", nullable: true),
                    MOTA = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbDANHMU__804E2884FBEE3276", x => x.MADANHMUC);
                });

            migrationBuilder.CreateTable(
                name: "tbGIOHANG",
                columns: table => new
                {
                    MAGIOHANG = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MAKHACHHANG = table.Column<int>(type: "int", nullable: false),
                    NGAYTAO = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    TRANGTHAI = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, defaultValue: "CHUA_THANH_TOAN")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbGIOHAN__559F5534E34A6024", x => x.MAGIOHANG);
                });

            migrationBuilder.CreateTable(
                name: "tbKHANHHANG",
                columns: table => new
                {
                    MAKHACHHANG = table.Column<int>(type: "int", nullable: false),
                    HOTEN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NGAYSINH = table.Column<DateOnly>(type: "date", nullable: true),
                    GIOITINH = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    EMAIL = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true),
                    DIACHI = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TAIKHOAN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MATKHAU = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbKHANHHANG", x => x.MAKHACHHANG);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GENDER",
                columns: table => new
                {
                    PARTY_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    GENDER_TYPE_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    FROM_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    THRU_DATE = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__GENDER__3F865F66", x => new { x.PARTY_ID, x.GENDER_TYPE_ID, x.FROM_DATE });
                    table.ForeignKey(
                        name: " FK__GENDER__GENDER_T__416EA7D8",
                        column: x => x.GENDER_TYPE_ID,
                        principalTable: "GENDER_TYPE",
                        principalColumn: "GENDER_TYPE_ID");
                });

            migrationBuilder.CreateTable(
                name: "APPLICATIONS_MENU_FORM_RELATIONS",
                columns: table => new
                {
                    ID_MENU_FORM = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    ID_APPLICATION = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APPLICATIONS_MENU_FORM_RELATIONS", x => new { x.ID_MENU_FORM, x.ID_APPLICATION });
                    table.ForeignKey(
                        name: "FK_APPLICATIONS_MENU_FORM_RELATIONS_APPLICATIONS",
                        column: x => x.ID_APPLICATION,
                        principalTable: "APPLICATIONS",
                        principalColumn: "ID_APPLICATION");
                    table.ForeignKey(
                        name: "FK_APPLICATIONS_MENU_FORM_RELATIONS_MENU_FORM",
                        column: x => x.ID_MENU_FORM,
                        principalTable: "MENU_FORM",
                        principalColumn: "ID_MENU_FORM");
                });

            migrationBuilder.CreateTable(
                name: "GROUP_USER_RELATIONSHIP_USER",
                columns: table => new
                {
                    PARTY_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    ID_GROUP = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GROUP_USER_RELATIONSHIP_USER_1", x => new { x.PARTY_ID, x.ID_GROUP });
                    table.ForeignKey(
                        name: "FK_GROUP_USER_RELATIONSHIP_USER_GROUP_USER",
                        column: x => x.ID_GROUP,
                        principalTable: "GROUP_USER",
                        principalColumn: "ID_GROUP",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GROUP_USER_RELATIONSHIP_USER_PARTY",
                        column: x => x.PARTY_ID,
                        principalTable: "PARTY",
                        principalColumn: "PARTY_ID");
                });

            migrationBuilder.CreateTable(
                name: "PERSON",
                columns: table => new
                {
                    PARTY_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    CURRENT_LAST_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CURRENT_FIRST_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CURRENT_MIDDLE_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CURRENT_NICKNAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CURRENT_GENDER_TYPE_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    BIRTH_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    PEOPLE_ID_NUMBER = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PEOPLE_ID_ISSUE_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    PEOPLE_ID_ISSUE_PLACE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CURRENT_PHONE_NUMBER = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CURRENT_EMAIL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PERSON_IMAGE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSON", x => x.PARTY_ID);
                    table.ForeignKey(
                        name: "FK_PERSON_PARTY",
                        column: x => x.PARTY_ID,
                        principalTable: "PARTY",
                        principalColumn: "PARTY_ID");
                });

            migrationBuilder.CreateTable(
                name: "tbSANPHAM",
                columns: table => new
                {
                    MASANPHAM = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TENSANPHAM = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DONGIA = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    SOLUONG = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    HINHANH = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MOTA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MADANHMUC = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbSANPHA__9534C892800073C7", x => x.MASANPHAM);
                    table.ForeignKey(
                        name: "FK_tbSANPHAM_tbDANHMUC",
                        column: x => x.MADANHMUC,
                        principalTable: "tbDANHMUC",
                        principalColumn: "MADANHMUC");
                });

            migrationBuilder.CreateTable(
                name: "tbHOADON",
                columns: table => new
                {
                    MAHOADON = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MAKHACHHANG = table.Column<int>(type: "int", nullable: true),
                    NGAY = table.Column<DateTime>(type: "datetime", nullable: true),
                    TONGTIEN = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    TRANGTHAI = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, defaultValue: "DA_DAT_HANG"),
                    NGAYDUYET = table.Column<DateTime>(type: "datetime", nullable: true),
                    NGUOIDUYET = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbHOADON", x => x.MAHOADON);
                    table.ForeignKey(
                        name: "FK_tbHOADON_tbKHANHHANG",
                        column: x => x.MAKHACHHANG,
                        principalTable: "tbKHANHHANG",
                        principalColumn: "MAKHACHHANG");
                });

            migrationBuilder.CreateTable(
                name: "GROUP_RELATIONSHIP_MENU_FORM",
                columns: table => new
                {
                    PARTY_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    ID_GROUP = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    ID_MENU_FORM = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GROUP_RELATIONSHIP_MENU_FORM", x => new { x.PARTY_ID, x.ID_GROUP, x.ID_MENU_FORM });
                    table.ForeignKey(
                        name: "FK_GROUP_RELATIONSHIP_MENU_FORM_GROUP_USER_RELATIONSHIP_USER",
                        columns: x => new { x.PARTY_ID, x.ID_GROUP },
                        principalTable: "GROUP_USER_RELATIONSHIP_USER",
                        principalColumns: new[] { "PARTY_ID", "ID_GROUP" });
                    table.ForeignKey(
                        name: "FK_GROUP_RELATIONSHIP_MENU_FORM_MENU_FORM",
                        column: x => x.ID_MENU_FORM,
                        principalTable: "MENU_FORM",
                        principalColumn: "ID_MENU_FORM",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbCHITIETGIOHANG",
                columns: table => new
                {
                    MAGIOHANG = table.Column<int>(type: "int", nullable: false),
                    MASANPHAM = table.Column<int>(type: "int", nullable: false),
                    SOLUONG = table.Column<int>(type: "int", nullable: false),
                    DONGIA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    THANHTIEN = table.Column<decimal>(type: "decimal(29,2)", nullable: true, computedColumnSql: "([SOLUONG]*[DONGIA])", stored: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCHITIETGIOHANG", x => new { x.MAGIOHANG, x.MASANPHAM });
                    table.ForeignKey(
                        name: "FK_GH_GIOHANG",
                        column: x => x.MAGIOHANG,
                        principalTable: "tbGIOHANG",
                        principalColumn: "MAGIOHANG",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GH_SANPHAM",
                        column: x => x.MASANPHAM,
                        principalTable: "tbSANPHAM",
                        principalColumn: "MASANPHAM");
                });

            migrationBuilder.CreateTable(
                name: "tbCHITIETHOADON",
                columns: table => new
                {
                    MACHITIET = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MASANPHAM = table.Column<int>(type: "int", nullable: true),
                    SOLUONG = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    DONGIA = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    MAHOADON = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCHITIETHOADON", x => x.MACHITIET);
                    table.ForeignKey(
                        name: "FK_tbCHITIETHOADON_tbHOADON",
                        column: x => x.MAHOADON,
                        principalTable: "tbHOADON",
                        principalColumn: "MAHOADON");
                    table.ForeignKey(
                        name: "FK_tbCHITIETHOADON_tbSANPHAM",
                        column: x => x.MASANPHAM,
                        principalTable: "tbSANPHAM",
                        principalColumn: "MASANPHAM");
                });

            migrationBuilder.CreateIndex(
                name: "IX_APPLICATIONS_MENU_FORM_RELATIONS_ID_APPLICATION",
                table: "APPLICATIONS_MENU_FORM_RELATIONS",
                column: "ID_APPLICATION");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GENDER_GENDER_TYPE_ID",
                table: "GENDER",
                column: "GENDER_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_GROUP_RELATIONSHIP_MENU_FORM_ID_MENU_FORM",
                table: "GROUP_RELATIONSHIP_MENU_FORM",
                column: "ID_MENU_FORM");

            migrationBuilder.CreateIndex(
                name: "IX_GROUP_USER_RELATIONSHIP_USER_ID_GROUP",
                table: "GROUP_USER_RELATIONSHIP_USER",
                column: "ID_GROUP");

            migrationBuilder.CreateIndex(
                name: "IX_MENU_FORM_ID_MENU_FORM_PARENT",
                table: "MENU_FORM",
                column: "ID_MENU_FORM_PARENT");

            migrationBuilder.CreateIndex(
                name: "IX_tbCHITIETGIOHANG_MASANPHAM",
                table: "tbCHITIETGIOHANG",
                column: "MASANPHAM");

            migrationBuilder.CreateIndex(
                name: "IX_tbCHITIETHOADON_MAHOADON",
                table: "tbCHITIETHOADON",
                column: "MAHOADON");

            migrationBuilder.CreateIndex(
                name: "IX_tbCHITIETHOADON_MASANPHAM",
                table: "tbCHITIETHOADON",
                column: "MASANPHAM");

            migrationBuilder.CreateIndex(
                name: "IX_tbHOADON_MAKHACHHANG",
                table: "tbHOADON",
                column: "MAKHACHHANG");

            migrationBuilder.CreateIndex(
                name: "IX_tbSANPHAM_MADANHMUC",
                table: "tbSANPHAM",
                column: "MADANHMUC");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APPLICATIONS_MENU_FORM_RELATIONS");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "GENDER");

            migrationBuilder.DropTable(
                name: "GROUP_RELATIONSHIP_MENU_FORM");

            migrationBuilder.DropTable(
                name: "PERSON");

            migrationBuilder.DropTable(
                name: "tbCHITIETGIOHANG");

            migrationBuilder.DropTable(
                name: "tbCHITIETHOADON");

            migrationBuilder.DropTable(
                name: "APPLICATIONS");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "GENDER_TYPE");

            migrationBuilder.DropTable(
                name: "GROUP_USER_RELATIONSHIP_USER");

            migrationBuilder.DropTable(
                name: "MENU_FORM");

            migrationBuilder.DropTable(
                name: "tbGIOHANG");

            migrationBuilder.DropTable(
                name: "tbHOADON");

            migrationBuilder.DropTable(
                name: "tbSANPHAM");

            migrationBuilder.DropTable(
                name: "GROUP_USER");

            migrationBuilder.DropTable(
                name: "PARTY");

            migrationBuilder.DropTable(
                name: "tbKHANHHANG");

            migrationBuilder.DropTable(
                name: "tbDANHMUC");
        }
    }
}
