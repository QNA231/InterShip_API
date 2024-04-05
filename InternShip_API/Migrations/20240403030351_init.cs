using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternShipAPI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillStatus_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillStatus_tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cinema_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameOfCinema = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinema_tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Food_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameOfFood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food_tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieType_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieType_tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RankCustomer_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Point = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RankCustomer_tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rate_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rate_tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role_tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeatStatus_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatStatus_tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeatType_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatType_tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserStatus_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStatus_tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Room_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CinemaId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_tbl_Cinema_tbl_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinema_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Promotion_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Percent = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RankCustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotion_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promotion_tbl_RankCustomer_tbl_RankCustomerId",
                        column: x => x.RankCustomerId,
                        principalTable: "RankCustomer_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movie_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieDuration = table.Column<int>(type: "int", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PremiereDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeroImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovieTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RateId = table.Column<int>(type: "int", nullable: false),
                    Traler = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movie_tbl_MovieType_tbl_MovieTypeId",
                        column: x => x.MovieTypeId,
                        principalTable: "MovieType_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movie_tbl_Rate_tbl_RateId",
                        column: x => x.RateId,
                        principalTable: "Rate_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Point = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumBer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RankCustomerId = table.Column<int>(type: "int", nullable: false),
                    UserStatusId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_tbl_RankCustomer_tbl_RankCustomerId",
                        column: x => x.RankCustomerId,
                        principalTable: "RankCustomer_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_tbl_Role_tbl_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_tbl_UserStatus_tbl_UserStatusId",
                        column: x => x.UserStatusId,
                        principalTable: "UserStatus_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seat_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    SeatStatusId = table.Column<int>(type: "int", nullable: false),
                    Line = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SeatTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seat_tbl_Room_tbl_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seat_tbl_SeatStatus_tbl_SeatStatusId",
                        column: x => x.SeatStatusId,
                        principalTable: "SeatStatus_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seat_tbl_SeatType_tbl_SeatTypeId",
                        column: x => x.SeatTypeId,
                        principalTable: "SeatType_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedule_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    StartAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedule_tbl_Movie_tbl_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedule_tbl_Room_tbl_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bill_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalMoney = table.Column<double>(type: "float", nullable: false),
                    TradingCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PromotionId = table.Column<int>(type: "int", nullable: false),
                    BillStatusId = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bill_tbl_BillStatus_tbl_BillStatusId",
                        column: x => x.BillStatusId,
                        principalTable: "BillStatus_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bill_tbl_Promotion_tbl_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "Promotion_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bill_tbl_User_tbl_UserId",
                        column: x => x.UserId,
                        principalTable: "User_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConfirmEmail_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ExpireTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConfirmCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsConfirm = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfirmEmail_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfirmEmail_tbl_User_tbl_UserId",
                        column: x => x.UserId,
                        principalTable: "User_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpireTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_tbl_User_tbl_UserId",
                        column: x => x.UserId,
                        principalTable: "User_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ticket_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduleId = table.Column<int>(type: "int", nullable: false),
                    SeatId = table.Column<int>(type: "int", nullable: false),
                    PriceTicket = table.Column<double>(type: "float", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_tbl_Schedule_tbl_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedule_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_tbl_Seat_tbl_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seat_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BillFood_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: false),
                    FoodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillFood_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillFood_tbl_Bill_tbl_BillId",
                        column: x => x.BillId,
                        principalTable: "Bill_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillFood_tbl_Food_tbl_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Food_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillTicket_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillTicket_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillTicket_tbl_Bill_tbl_BillId",
                        column: x => x.BillId,
                        principalTable: "Bill_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillTicket_tbl_Ticket_tbl_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Ticket_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bill_tbl_BillStatusId",
                table: "Bill_tbl",
                column: "BillStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_tbl_PromotionId",
                table: "Bill_tbl",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_tbl_UserId",
                table: "Bill_tbl",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BillFood_tbl_BillId",
                table: "BillFood_tbl",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_BillFood_tbl_FoodId",
                table: "BillFood_tbl",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_BillTicket_tbl_BillId",
                table: "BillTicket_tbl",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_BillTicket_tbl_TicketId",
                table: "BillTicket_tbl",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfirmEmail_tbl_UserId",
                table: "ConfirmEmail_tbl",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_tbl_MovieTypeId",
                table: "Movie_tbl",
                column: "MovieTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_tbl_RateId",
                table: "Movie_tbl",
                column: "RateId");

            migrationBuilder.CreateIndex(
                name: "IX_Promotion_tbl_RankCustomerId",
                table: "Promotion_tbl",
                column: "RankCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_tbl_UserId",
                table: "RefreshToken_tbl",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_tbl_CinemaId",
                table: "Room_tbl",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_tbl_MovieId",
                table: "Schedule_tbl",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_tbl_RoomId",
                table: "Schedule_tbl",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_tbl_RoomId",
                table: "Seat_tbl",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_tbl_SeatStatusId",
                table: "Seat_tbl",
                column: "SeatStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_tbl_SeatTypeId",
                table: "Seat_tbl",
                column: "SeatTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_tbl_ScheduleId",
                table: "Ticket_tbl",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_tbl_SeatId",
                table: "Ticket_tbl",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_User_tbl_RankCustomerId",
                table: "User_tbl",
                column: "RankCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_User_tbl_RoleId",
                table: "User_tbl",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_User_tbl_UserStatusId",
                table: "User_tbl",
                column: "UserStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillFood_tbl");

            migrationBuilder.DropTable(
                name: "BillTicket_tbl");

            migrationBuilder.DropTable(
                name: "ConfirmEmail_tbl");

            migrationBuilder.DropTable(
                name: "RefreshToken_tbl");

            migrationBuilder.DropTable(
                name: "Food_tbl");

            migrationBuilder.DropTable(
                name: "Bill_tbl");

            migrationBuilder.DropTable(
                name: "Ticket_tbl");

            migrationBuilder.DropTable(
                name: "BillStatus_tbl");

            migrationBuilder.DropTable(
                name: "Promotion_tbl");

            migrationBuilder.DropTable(
                name: "User_tbl");

            migrationBuilder.DropTable(
                name: "Schedule_tbl");

            migrationBuilder.DropTable(
                name: "Seat_tbl");

            migrationBuilder.DropTable(
                name: "RankCustomer_tbl");

            migrationBuilder.DropTable(
                name: "Role_tbl");

            migrationBuilder.DropTable(
                name: "UserStatus_tbl");

            migrationBuilder.DropTable(
                name: "Movie_tbl");

            migrationBuilder.DropTable(
                name: "Room_tbl");

            migrationBuilder.DropTable(
                name: "SeatStatus_tbl");

            migrationBuilder.DropTable(
                name: "SeatType_tbl");

            migrationBuilder.DropTable(
                name: "MovieType_tbl");

            migrationBuilder.DropTable(
                name: "Rate_tbl");

            migrationBuilder.DropTable(
                name: "Cinema_tbl");
        }
    

    }
}
