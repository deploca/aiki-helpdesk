using System;
using AIKI.CO.HelpDesk.WebAPI.Models.Entities;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AIKI.CO.HelpDesk.WebAPI.Models.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "AssetsView",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    companyid = table.Column<Guid>(nullable: true),
                    allowdelete = table.Column<bool>(nullable: true),
                    assetnumber = table.Column<string>(nullable: true),
                    title = table.Column<string>(nullable: true),
                    assetlocationid = table.Column<string>(nullable: true),
                    assettypeid = table.Column<string>(nullable: true),
                    deliverydate = table.Column<DateTime>(nullable: true),
                    customerid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Company",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    allowdelete = table.Column<bool>(nullable: true),
                    subdomain = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Last30Ticket",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    companyid = table.Column<Guid>(nullable: true),
                    allowdelete = table.Column<bool>(nullable: true),
                    da = table.Column<string>(nullable: true),
                    count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "OrganizeCharts_JsonView",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    companyid = table.Column<Guid>(nullable: true),
                    allowdelete = table.Column<bool>(nullable: true),
                    organizecharts = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizeCharts_JsonView", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TicketCountInfo",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    companyid = table.Column<Guid>(nullable: true),
                    allowdelete = table.Column<bool>(nullable: true),
                    tickettype = table.Column<Guid>(nullable: false),
                    count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TicketsView",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    companyid = table.Column<Guid>(nullable: true),
                    allowdelete = table.Column<bool>(nullable: true),
                    registerdate = table.Column<DateTime>(nullable: false),
                    enddate = table.Column<DateTime>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    tickettype = table.Column<string>(nullable: true),
                    ticketcategory = table.Column<string>(nullable: true),
                    tickettags = table.Column<string>(nullable: true),
                    asset = table.Column<string>(nullable: true),
                    ticketfriendlynumber = table.Column<string>(nullable: true),
                    agentname = table.Column<string>(nullable: true),
                    ticketrate = table.Column<double>(nullable: true),
                    mandays = table.Column<double>(nullable: true),
                    operateid = table.Column<Guid>(nullable: true),
                    requester = table.Column<string>(nullable: true),
                    requestpriority = table.Column<string>(nullable: true),
                    lasthistorycomment = table.Column<string>(nullable: true),
                    customerid = table.Column<Guid>(nullable: true),
                    customertitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "AppConstant",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    companyid = table.Column<Guid>(nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    allowdelete = table.Column<bool>(nullable: true),
                    title = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppConstant", x => new { x.id, x.companyid });
                    table.ForeignKey(
                        name: "FK_AppConstant_Company_companyid",
                        column: x => x.companyid,
                        principalSchema: "public",
                        principalTable: "Company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    companyid = table.Column<Guid>(nullable: true, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    allowdelete = table.Column<bool>(nullable: true),
                    title = table.Column<string>(maxLength: 200, nullable: false),
                    description = table.Column<string>(maxLength: 4000, nullable: true),
                    domains = table.Column<string>(maxLength: 1000, nullable: true),
                    schema = table.Column<byte?[]>(nullable: true),
                    disabled = table.Column<bool>(nullable: true, defaultValueSql: "false"),
                    operatinghourid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.id);
                    table.ForeignKey(
                        name: "FK_Customer_Company_companyid",
                        column: x => x.companyid,
                        principalSchema: "public",
                        principalTable: "Company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    companyid = table.Column<Guid>(nullable: true, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    allowdelete = table.Column<bool>(nullable: true),
                    title = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    operatinghourid = table.Column<Guid>(nullable: true),
                    agents = table.Column<string>(nullable: true),
                    leader = table.Column<string>(nullable: true),
                    supportemail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.id);
                    table.ForeignKey(
                        name: "FK_Group_Company_companyid",
                        column: x => x.companyid,
                        principalSchema: "public",
                        principalTable: "Company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    companyid = table.Column<Guid>(nullable: true, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    allowdelete = table.Column<bool>(nullable: true),
                    membername = table.Column<string>(nullable: true),
                    username = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    roles = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    disabled = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.id);
                    table.ForeignKey(
                        name: "FK_Member_Company_companyid",
                        column: x => x.companyid,
                        principalSchema: "public",
                        principalTable: "Company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OperatingHour",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    companyid = table.Column<Guid>(nullable: true, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    allowdelete = table.Column<bool>(nullable: true),
                    title = table.Column<string>(nullable: true),
                    timezone = table.Column<string>(nullable: true),
                    workdays = table.Column<Workday[]>(type: "jsonb", nullable: true),
                    holidays = table.Column<Holiday[]>(type: "jsonb", nullable: true),
                    isdefault = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatingHour", x => x.id);
                    table.ForeignKey(
                        name: "FK_OperatingHour_Company_companyid",
                        column: x => x.companyid,
                        principalSchema: "public",
                        principalTable: "Company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SLASetting",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    companyid = table.Column<Guid>(nullable: true, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    allowdelete = table.Column<bool>(nullable: true),
                    title = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    operatinghourid = table.Column<Guid>(nullable: true),
                    targetspriority = table.Column<TargetsPriority[]>(type: "jsonb", nullable: true),
                    requesttypepriority = table.Column<RequestTypePriority[]>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SLASetting", x => x.id);
                    table.ForeignKey(
                        name: "FK_SLASetting_Company_companyid",
                        column: x => x.companyid,
                        principalSchema: "public",
                        principalTable: "Company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppConstantItem",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    companyid = table.Column<Guid>(nullable: false),
                    allowdelete = table.Column<bool>(nullable: true),
                    appconstantid = table.Column<Guid>(nullable: false),
                    value1 = table.Column<string>(nullable: true),
                    value2 = table.Column<string>(nullable: true),
                    additionalinfo = table.Column<AdditionalInfo[]>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppConstantItem", x => new { x.id, x.companyid });
                    table.ForeignKey(
                        name: "FK_AppConstantItem_Company_companyid",
                        column: x => x.companyid,
                        principalSchema: "public",
                        principalTable: "Company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppConstantItem_AppConstant_appconstantid_companyid",
                        columns: x => new { x.appconstantid, x.companyid },
                        principalSchema: "public",
                        principalTable: "AppConstant",
                        principalColumns: new[] { "id", "companyid" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Asset",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    companyid = table.Column<Guid>(nullable: true, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    allowdelete = table.Column<bool>(nullable: true),
                    employeeid = table.Column<Guid>(nullable: true),
                    assetlocationid = table.Column<Guid>(nullable: true),
                    assettypeid = table.Column<Guid>(nullable: true),
                    assetnumber = table.Column<string>(nullable: true),
                    customerid = table.Column<Guid>(nullable: true),
                    deliverydate = table.Column<DateTime>(nullable: true),
                    assetadditionalinfo = table.Column<AssetAdditionalInfo[]>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asset", x => x.id);
                    table.ForeignKey(
                        name: "FK_Asset_Company_companyid",
                        column: x => x.companyid,
                        principalSchema: "public",
                        principalTable: "Company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Asset_Customer_customerid",
                        column: x => x.customerid,
                        principalSchema: "public",
                        principalTable: "Customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrganizeChart",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    companyid = table.Column<Guid>(nullable: true, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    allowdelete = table.Column<bool>(nullable: true),
                    parent_id = table.Column<Guid>(nullable: true),
                    title = table.Column<string>(nullable: true),
                    titletype = table.Column<string>(nullable: true),
                    customerid = table.Column<Guid>(nullable: false),
                    additionalinfo = table.Column<OrganizeChartAdditionalInfo[]>(type: "jsonb", nullable: true),
                    email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizeChart", x => x.id);
                    table.ForeignKey(
                        name: "FK_OrganizeChart_Company_companyid",
                        column: x => x.companyid,
                        principalSchema: "public",
                        principalTable: "Company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrganizeChart_Customer_customerid",
                        column: x => x.customerid,
                        principalSchema: "public",
                        principalTable: "Customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizeChart_OrganizeChart_parent_id",
                        column: x => x.parent_id,
                        principalSchema: "public",
                        principalTable: "OrganizeChart",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    companyid = table.Column<Guid>(nullable: true, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    allowdelete = table.Column<bool>(nullable: true),
                    registerdate = table.Column<DateTime>(nullable: false),
                    enddate = table.Column<DateTime>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    tickettype = table.Column<Guid>(nullable: false),
                    ticketcategory = table.Column<Guid>(nullable: false),
                    tickettags = table.Column<Guid>(nullable: false),
                    asset = table.Column<string>(nullable: true),
                    ticketrate = table.Column<double>(nullable: true),
                    mandays = table.Column<double>(nullable: true),
                    operateid = table.Column<Guid>(nullable: true),
                    requestpriority = table.Column<string>(nullable: true),
                    customerid = table.Column<Guid>(nullable: true),
                    requester = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.id);
                    table.ForeignKey(
                        name: "FK_Ticket_Company_companyid",
                        column: x => x.companyid,
                        principalSchema: "public",
                        principalTable: "Company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_Customer_customerid",
                        column: x => x.customerid,
                        principalSchema: "public",
                        principalTable: "Customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfilePicture",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    companyid = table.Column<Guid>(nullable: true, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    allowdelete = table.Column<bool>(nullable: true),
                    memberid = table.Column<Guid>(nullable: false),
                    filecontent = table.Column<byte[]>(type: "bytea", nullable: true),
                    filextension = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilePicture", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProfilePicture_Company_companyid",
                        column: x => x.companyid,
                        principalSchema: "public",
                        principalTable: "Company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfilePicture_Member_memberid",
                        column: x => x.memberid,
                        principalSchema: "public",
                        principalTable: "Member",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketHistory",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    companyid = table.Column<Guid>(nullable: true, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    allowdelete = table.Column<bool>(nullable: true),
                    ticketid = table.Column<Guid>(nullable: false),
                    historydate = table.Column<DateTime>(nullable: false),
                    historycomment = table.Column<string>(nullable: true),
                    agentname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketHistory", x => x.id);
                    table.ForeignKey(
                        name: "FK_TicketHistory_Company_companyid",
                        column: x => x.companyid,
                        principalSchema: "public",
                        principalTable: "Company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TicketHistory_Ticket_ticketid",
                        column: x => x.ticketid,
                        principalSchema: "public",
                        principalTable: "Ticket",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppConstant_companyid",
                schema: "public",
                table: "AppConstant",
                column: "companyid");

            migrationBuilder.CreateIndex(
                name: "IX_AppConstantItem_companyid",
                schema: "public",
                table: "AppConstantItem",
                column: "companyid");

            migrationBuilder.CreateIndex(
                name: "IX_AppConstantItem_appconstantid_companyid",
                schema: "public",
                table: "AppConstantItem",
                columns: new[] { "appconstantid", "companyid" });

            migrationBuilder.CreateIndex(
                name: "IX_Asset_companyid",
                schema: "public",
                table: "Asset",
                column: "companyid");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_customerid",
                schema: "public",
                table: "Asset",
                column: "customerid");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_companyid",
                schema: "public",
                table: "Customer",
                column: "companyid");

            migrationBuilder.CreateIndex(
                name: "IX_Group_companyid",
                schema: "public",
                table: "Group",
                column: "companyid");

            migrationBuilder.CreateIndex(
                name: "IX_Member_companyid",
                schema: "public",
                table: "Member",
                column: "companyid");

            migrationBuilder.CreateIndex(
                name: "IX_Member_email",
                schema: "public",
                table: "Member",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Member_username",
                schema: "public",
                table: "Member",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OperatingHour_companyid",
                schema: "public",
                table: "OperatingHour",
                column: "companyid");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizeChart_companyid",
                schema: "public",
                table: "OrganizeChart",
                column: "companyid");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizeChart_customerid",
                schema: "public",
                table: "OrganizeChart",
                column: "customerid");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizeChart_parent_id",
                schema: "public",
                table: "OrganizeChart",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProfilePicture_companyid",
                schema: "public",
                table: "ProfilePicture",
                column: "companyid");

            migrationBuilder.CreateIndex(
                name: "IX_ProfilePicture_memberid",
                schema: "public",
                table: "ProfilePicture",
                column: "memberid");

            migrationBuilder.CreateIndex(
                name: "IX_SLASetting_companyid",
                schema: "public",
                table: "SLASetting",
                column: "companyid");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_companyid",
                schema: "public",
                table: "Ticket",
                column: "companyid");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_customerid",
                schema: "public",
                table: "Ticket",
                column: "customerid");

            migrationBuilder.CreateIndex(
                name: "IX_TicketHistory_companyid",
                schema: "public",
                table: "TicketHistory",
                column: "companyid");

            migrationBuilder.CreateIndex(
                name: "IX_TicketHistory_ticketid",
                schema: "public",
                table: "TicketHistory",
                column: "ticketid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppConstantItem",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Asset",
                schema: "public");

            migrationBuilder.DropTable(
                name: "AssetsView",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Group",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Last30Ticket",
                schema: "public");

            migrationBuilder.DropTable(
                name: "OperatingHour",
                schema: "public");

            migrationBuilder.DropTable(
                name: "OrganizeChart",
                schema: "public");

            migrationBuilder.DropTable(
                name: "OrganizeCharts_JsonView",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ProfilePicture",
                schema: "public");

            migrationBuilder.DropTable(
                name: "SLASetting",
                schema: "public");

            migrationBuilder.DropTable(
                name: "TicketCountInfo",
                schema: "public");

            migrationBuilder.DropTable(
                name: "TicketHistory",
                schema: "public");

            migrationBuilder.DropTable(
                name: "TicketsView",
                schema: "public");

            migrationBuilder.DropTable(
                name: "AppConstant",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Member",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Ticket",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Company",
                schema: "public");
        }
    }
}
