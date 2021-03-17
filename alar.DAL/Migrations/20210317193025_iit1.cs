using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace alar.DAL.Migrations
{
    public partial class iit1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ObjectStatus = table.Column<byte>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateBy = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ComplaintTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ObjectStatus = table.Column<byte>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateBy = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    Name = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ObjectStatus = table.Column<byte>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateBy = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    CustomerOfficalName = table.Column<string>(nullable: false),
                    CustomerSingName = table.Column<string>(nullable: false),
                    TaxNo = table.Column<string>(nullable: false),
                    TaxOffice = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    CustomerImageMin = table.Column<string>(nullable: true),
                    CustomerImageLarge = table.Column<string>(nullable: true),
                    CustomerImageOrgin = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductNames",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ObjectStatus = table.Column<byte>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateBy = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductNames", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UnitDefinations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ObjectStatus = table.Column<byte>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateBy = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitDefinations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Brants",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ObjectStatus = table.Column<byte>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateBy = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brants", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Brants_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ObjectStatus = table.Column<byte>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateBy = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    SingName = table.Column<string>(nullable: false),
                    OfficalName = table.Column<string>(nullable: false),
                    Province = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    TaxNo = table.Column<string>(nullable: true),
                    TaxOffice = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Lat = table.Column<double>(nullable: false),
                    Long = table.Column<double>(nullable: false),
                    CustomerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Branches_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ObjectStatus = table.Column<byte>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateBy = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SurName = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    EmailToken = table.Column<string>(nullable: true),
                    EmailConfirme = table.Column<bool>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneToken = table.Column<string>(nullable: true),
                    PhoneConfirme = table.Column<bool>(nullable: false),
                    UserTypes = table.Column<byte>(nullable: false),
                    UserImageMin = table.Column<string>(nullable: true),
                    UserImageLarge = table.Column<string>(nullable: true),
                    UserImageOrjin = table.Column<string>(nullable: true),
                    CustomerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductModels",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ObjectStatus = table.Column<byte>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateBy = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    BrantID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModels", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductModels_Brants_BrantID",
                        column: x => x.BrantID,
                        principalTable: "Brants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BranchAuthorizeds",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ObjectStatus = table.Column<byte>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateBy = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    BranchID = table.Column<int>(nullable: false),
                    UserClassID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchAuthorizeds", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BranchAuthorizeds_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchAuthorizeds_Users_UserClassID",
                        column: x => x.UserClassID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerFallows",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ObjectStatus = table.Column<byte>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateBy = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    UserClassID = table.Column<int>(nullable: false),
                    CustomerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerFallows", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomerFallows_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerFallows_Users_UserClassID",
                        column: x => x.UserClassID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ObjectStatus = table.Column<byte>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateBy = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    BrantID = table.Column<int>(nullable: false),
                    ProductModelID = table.Column<int>(nullable: false),
                    Desc = table.Column<string>(nullable: false),
                    UnitDefinationID = table.Column<int>(nullable: false),
                    UnitQuantity = table.Column<decimal>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    ProductNameID = table.Column<int>(nullable: false),
                    WepUrl = table.Column<string>(nullable: true),
                    CustomerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_Brants_BrantID",
                        column: x => x.BrantID,
                        principalTable: "Brants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductModels_ProductModelID",
                        column: x => x.ProductModelID,
                        principalTable: "ProductModels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductNames_ProductNameID",
                        column: x => x.ProductNameID,
                        principalTable: "ProductNames",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_UnitDefinations_UnitDefinationID",
                        column: x => x.UnitDefinationID,
                        principalTable: "UnitDefinations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ObjectStatus = table.Column<byte>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateBy = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    DiscountType = table.Column<byte>(nullable: false),
                    OldPrice = table.Column<decimal>(nullable: false),
                    NewPrice = table.Column<decimal>(nullable: false),
                    LimitedByStocks = table.Column<bool>(nullable: false),
                    CustomerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Discounts_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Discounts_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ObjectStatus = table.Column<byte>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateBy = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImage",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ObjectStatus = table.Column<byte>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateBy = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    ProductImageMin = table.Column<string>(nullable: true),
                    ProductImageLarge = table.Column<string>(nullable: true),
                    ProductImageOrjin = table.Column<string>(nullable: true),
                    CoverImage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImage", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductImage_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DicountComments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ObjectStatus = table.Column<byte>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateBy = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    DicountID = table.Column<int>(nullable: false),
                    DiscountID = table.Column<int>(nullable: true),
                    UserClassID = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DicountComments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DicountComments_Discounts_DiscountID",
                        column: x => x.DiscountID,
                        principalTable: "Discounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DicountComments_Users_UserClassID",
                        column: x => x.UserClassID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiscountBranches",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ObjectStatus = table.Column<byte>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateBy = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    DicountID = table.Column<int>(nullable: false),
                    DiscountID = table.Column<int>(nullable: true),
                    BranchID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountBranches", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DiscountBranches_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscountBranches_Discounts_DiscountID",
                        column: x => x.DiscountID,
                        principalTable: "Discounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DiscountComplaints",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ObjectStatus = table.Column<byte>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateBy = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    DiscountID = table.Column<int>(nullable: false),
                    Complaint = table.Column<string>(nullable: false),
                    ComplaintTypesID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountComplaints", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DiscountComplaints_ComplaintTypes_ComplaintTypesID",
                        column: x => x.ComplaintTypesID,
                        principalTable: "ComplaintTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscountComplaints_Discounts_DiscountID",
                        column: x => x.DiscountID,
                        principalTable: "Discounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiscountViews",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ObjectStatus = table.Column<byte>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateBy = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    DiscountID = table.Column<int>(nullable: false),
                    UserClassID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountViews", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DiscountViews_Discounts_DiscountID",
                        column: x => x.DiscountID,
                        principalTable: "Discounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscountViews_Users_UserClassID",
                        column: x => x.UserClassID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiscountWepViews",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ObjectStatus = table.Column<byte>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateBy = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    DiscountID = table.Column<int>(nullable: false),
                    UserClassID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountWepViews", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DiscountWepViews_Discounts_DiscountID",
                        column: x => x.DiscountID,
                        principalTable: "Discounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscountWepViews_Users_UserClassID",
                        column: x => x.UserClassID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LikeDislikes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ObjectStatus = table.Column<byte>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateBy = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    DiscountID = table.Column<int>(nullable: false),
                    UserClassID = table.Column<int>(nullable: false),
                    LikeDislike = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikeDislikes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LikeDislikes_Discounts_DiscountID",
                        column: x => x.DiscountID,
                        principalTable: "Discounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LikeDislikes_Users_UserClassID",
                        column: x => x.UserClassID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBaskets",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ObjectStatus = table.Column<byte>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    LastUpdateBy = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    UserClassID = table.Column<int>(nullable: false),
                    DiscountID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBaskets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserBaskets_Discounts_DiscountID",
                        column: x => x.DiscountID,
                        principalTable: "Discounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBaskets_Users_UserClassID",
                        column: x => x.UserClassID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BranchAuthorizeds_BranchID",
                table: "BranchAuthorizeds",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_BranchAuthorizeds_UserClassID",
                table: "BranchAuthorizeds",
                column: "UserClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_CustomerID",
                table: "Branches",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Brants_CategoryID",
                table: "Brants",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFallows_CustomerID",
                table: "CustomerFallows",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFallows_UserClassID",
                table: "CustomerFallows",
                column: "UserClassID");

            migrationBuilder.CreateIndex(
                name: "IX_DicountComments_DiscountID",
                table: "DicountComments",
                column: "DiscountID");

            migrationBuilder.CreateIndex(
                name: "IX_DicountComments_UserClassID",
                table: "DicountComments",
                column: "UserClassID");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountBranches_BranchID",
                table: "DiscountBranches",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountBranches_DiscountID",
                table: "DiscountBranches",
                column: "DiscountID");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountComplaints_ComplaintTypesID",
                table: "DiscountComplaints",
                column: "ComplaintTypesID");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountComplaints_DiscountID",
                table: "DiscountComplaints",
                column: "DiscountID");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_CustomerID",
                table: "Discounts",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_ProductID",
                table: "Discounts",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountViews_DiscountID",
                table: "DiscountViews",
                column: "DiscountID");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountViews_UserClassID",
                table: "DiscountViews",
                column: "UserClassID");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountWepViews_DiscountID",
                table: "DiscountWepViews",
                column: "DiscountID");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountWepViews_UserClassID",
                table: "DiscountWepViews",
                column: "UserClassID");

            migrationBuilder.CreateIndex(
                name: "IX_LikeDislikes_DiscountID",
                table: "LikeDislikes",
                column: "DiscountID");

            migrationBuilder.CreateIndex(
                name: "IX_LikeDislikes_UserClassID",
                table: "LikeDislikes",
                column: "UserClassID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryID",
                table: "ProductCategories",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ProductID",
                table: "ProductCategories",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_ProductID",
                table: "ProductImage",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductModels_BrantID",
                table: "ProductModels",
                column: "BrantID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrantID",
                table: "Products",
                column: "BrantID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CustomerID",
                table: "Products",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductModelID",
                table: "Products",
                column: "ProductModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductNameID",
                table: "Products",
                column: "ProductNameID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UnitDefinationID",
                table: "Products",
                column: "UnitDefinationID");

            migrationBuilder.CreateIndex(
                name: "IX_UserBaskets_DiscountID",
                table: "UserBaskets",
                column: "DiscountID");

            migrationBuilder.CreateIndex(
                name: "IX_UserBaskets_UserClassID",
                table: "UserBaskets",
                column: "UserClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CustomerID",
                table: "Users",
                column: "CustomerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BranchAuthorizeds");

            migrationBuilder.DropTable(
                name: "CustomerFallows");

            migrationBuilder.DropTable(
                name: "DicountComments");

            migrationBuilder.DropTable(
                name: "DiscountBranches");

            migrationBuilder.DropTable(
                name: "DiscountComplaints");

            migrationBuilder.DropTable(
                name: "DiscountViews");

            migrationBuilder.DropTable(
                name: "DiscountWepViews");

            migrationBuilder.DropTable(
                name: "LikeDislikes");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "ProductImage");

            migrationBuilder.DropTable(
                name: "UserBaskets");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "ComplaintTypes");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "ProductModels");

            migrationBuilder.DropTable(
                name: "ProductNames");

            migrationBuilder.DropTable(
                name: "UnitDefinations");

            migrationBuilder.DropTable(
                name: "Brants");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
