using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auctions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ReservePrice = table.Column<int>(type: "integer", nullable: false),
                    Seller = table.Column<string>(type: "text", nullable: false),
                    Winner = table.Column<string>(type: "text", nullable: true),
                    SoldAmount = table.Column<int>(type: "integer", nullable: true),
                    CurrentHighBid = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AuctionEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auctions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Make = table.Column<string>(type: "text", nullable: true),
                    Model = table.Column<string>(type: "text", nullable: true),
                    Year = table.Column<int>(type: "integer", nullable: true),
                    Color = table.Column<string>(type: "text", nullable: true),
                    Mileage = table.Column<int>(type: "integer", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    AuctionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_Auctions_AuctionId",
                        column: x => x.AuctionId,
                        principalTable: "Auctions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Auctions",
                columns: new[] { "Id", "AuctionEnd", "CreatedAt", "CurrentHighBid", "ReservePrice", "Seller", "SoldAmount", "Status", "UpdatedAt", "Winner" },
                values: new object[,]
                {
                    { new Guid("155225c1-4448-4066-9886-6786536e05ea"), new DateTime(2024, 3, 5, 20, 42, 33, 130, DateTimeKind.Utc).AddTicks(5124), new DateTime(2024, 3, 15, 20, 42, 33, 130, DateTimeKind.Utc).AddTicks(5122), null, 50000, "tom", null, 2, new DateTime(2024, 3, 15, 20, 42, 33, 130, DateTimeKind.Utc).AddTicks(5123), null },
                    { new Guid("3659ac24-29dd-407a-81f5-ecfe6f924b9b"), new DateTime(2024, 5, 2, 20, 42, 33, 130, DateTimeKind.Utc).AddTicks(5140), new DateTime(2024, 3, 15, 20, 42, 33, 130, DateTimeKind.Utc).AddTicks(5139), null, 20000, "bob", null, 0, new DateTime(2024, 3, 15, 20, 42, 33, 130, DateTimeKind.Utc).AddTicks(5139), null },
                    { new Guid("40490065-dac7-46b6-acc4-df507e0d6570"), new DateTime(2024, 4, 4, 20, 42, 33, 130, DateTimeKind.Utc).AddTicks(5137), new DateTime(2024, 3, 15, 20, 42, 33, 130, DateTimeKind.Utc).AddTicks(5136), null, 20000, "tom", null, 0, new DateTime(2024, 3, 15, 20, 42, 33, 130, DateTimeKind.Utc).AddTicks(5136), null },
                    { new Guid("466e4744-4dc5-4987-aae0-b621acfc5e39"), new DateTime(2024, 4, 14, 20, 42, 33, 130, DateTimeKind.Utc).AddTicks(5126), new DateTime(2024, 3, 15, 20, 42, 33, 130, DateTimeKind.Utc).AddTicks(5125), null, 20000, "alice", null, 0, new DateTime(2024, 3, 15, 20, 42, 33, 130, DateTimeKind.Utc).AddTicks(5125), null },
                    { new Guid("47111973-d176-4feb-848d-0ea22641c31a"), new DateTime(2024, 3, 28, 20, 42, 33, 130, DateTimeKind.Utc).AddTicks(5133), new DateTime(2024, 3, 15, 20, 42, 33, 130, DateTimeKind.Utc).AddTicks(5132), null, 150000, "alice", null, 0, new DateTime(2024, 3, 15, 20, 42, 33, 130, DateTimeKind.Utc).AddTicks(5132), null },
                    { new Guid("6a5011a1-fe1f-47df-9a32-b5346b289391"), new DateTime(2024, 4, 3, 20, 42, 33, 130, DateTimeKind.Utc).AddTicks(5135), new DateTime(2024, 3, 15, 20, 42, 33, 130, DateTimeKind.Utc).AddTicks(5134), null, 0, "bob", null, 0, new DateTime(2024, 3, 15, 20, 42, 33, 130, DateTimeKind.Utc).AddTicks(5134), null },
                    { new Guid("afbee524-5972-4075-8800-7d1f9d7b0a0c"), new DateTime(2024, 3, 25, 20, 42, 33, 130, DateTimeKind.Utc).AddTicks(5111), new DateTime(2024, 3, 15, 20, 42, 33, 130, DateTimeKind.Utc).AddTicks(5096), null, 20000, "bob", null, 0, new DateTime(2024, 3, 15, 20, 42, 33, 130, DateTimeKind.Utc).AddTicks(5097), null },
                    { new Guid("bbab4d5a-8565-48b1-9450-5ac2a5c4a654"), new DateTime(2024, 3, 19, 20, 42, 33, 130, DateTimeKind.Utc).AddTicks(5122), new DateTime(2024, 3, 15, 20, 42, 33, 130, DateTimeKind.Utc).AddTicks(5120), null, 0, "bob", null, 0, new DateTime(2024, 3, 15, 20, 42, 33, 130, DateTimeKind.Utc).AddTicks(5121), null },
                    { new Guid("c8c3ec17-01bf-49db-82aa-1ef80b833a9f"), new DateTime(2024, 5, 14, 20, 42, 33, 130, DateTimeKind.Utc).AddTicks(5119), new DateTime(2024, 3, 15, 20, 42, 33, 130, DateTimeKind.Utc).AddTicks(5118), null, 90000, "alice", null, 0, new DateTime(2024, 3, 15, 20, 42, 33, 130, DateTimeKind.Utc).AddTicks(5118), null },
                    { new Guid("dc1e4071-d19d-459b-b848-b5c3cd3d151f"), new DateTime(2024, 4, 29, 20, 42, 33, 130, DateTimeKind.Utc).AddTicks(5131), new DateTime(2024, 3, 15, 20, 42, 33, 130, DateTimeKind.Utc).AddTicks(5129), null, 20000, "bob", null, 0, new DateTime(2024, 3, 15, 20, 42, 33, 130, DateTimeKind.Utc).AddTicks(5129), null }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "AuctionId", "Color", "ImageUrl", "Make", "Mileage", "Model", "Year" },
                values: new object[,]
                {
                    { new Guid("13610ad9-1a31-4962-86a3-ccd3930f1f35"), new Guid("6a5011a1-fe1f-47df-9a32-b5346b289391"), "White", "https://cdn.pixabay.com/photo/2019/12/26/20/50/audi-r8-4721217_960_720.jpg", "Audi", 10050, "R8", 2021 },
                    { new Guid("2feed3f2-8404-4a73-9aad-f6ce78464f31"), new Guid("40490065-dac7-46b6-acc4-df507e0d6570"), "Black", "https://cdn.pixabay.com/photo/2016/09/01/15/06/audi-1636320_960_720.jpg", "Audi", 25400, "TT", 2020 },
                    { new Guid("3bce1564-78be-4224-9cd8-4d977c8f54ed"), new Guid("afbee524-5972-4075-8800-7d1f9d7b0a0c"), "White", "https://cdn.pixabay.com/photo/2016/05/06/16/32/car-1376190_960_720.jpg", "Ford", 50000, "GT", 2020 },
                    { new Guid("4b0371fa-d648-4dc6-8ca1-4f78d8fd5da6"), new Guid("466e4744-4dc5-4987-aae0-b621acfc5e39"), "White", "https://cdn.pixabay.com/photo/2017/08/31/05/47/bmw-2699538_960_720.jpg", "BMW", 90000, "X1", 2017 },
                    { new Guid("54e89752-a65a-4401-b2c2-8277c0dad1bb"), new Guid("47111973-d176-4feb-848d-0ea22641c31a"), "Red", "https://cdn.pixabay.com/photo/2017/11/08/14/39/ferrari-f430-2930661_960_720.jpg", "Ferrari", 5000, "F-430", 2022 },
                    { new Guid("8a646784-3d57-44e3-84f7-c5b2c1b25e8b"), new Guid("155225c1-4448-4066-9886-6786536e05ea"), "Silver", "https://cdn.pixabay.com/photo/2016/04/17/22/10/mercedes-benz-1335674_960_720.png", "Mercedes", 15001, "SLK", 2020 },
                    { new Guid("9c84c8e2-f615-436c-b160-d84a6b20b0ee"), new Guid("dc1e4071-d19d-459b-b848-b5c3cd3d151f"), "Red", "https://cdn.pixabay.com/photo/2017/11/09/01/49/ferrari-458-spider-2932191_960_720.jpg", "Ferrari", 50000, "Spider", 2015 },
                    { new Guid("c3a84bb9-a2d2-452f-8e32-dacfae34119c"), new Guid("3659ac24-29dd-407a-81f5-ecfe6f924b9b"), "Rust", "https://cdn.pixabay.com/photo/2017/08/02/19/47/vintage-2573090_960_720.jpg", "Ford", 150150, "Model T", 1938 },
                    { new Guid("dc545b37-0b34-4e24-8de0-b0d171549c10"), new Guid("466e4744-4dc5-4987-aae0-b621acfc5e39"), "White", "https://cdn.pixabay.com/photo/2017/08/31/05/47/bmw-2699538_960_720.jpg", "BMW", 90000, "X1", 2017 },
                    { new Guid("e8645886-60eb-4863-b4c4-ed4d77ddd632"), new Guid("c8c3ec17-01bf-49db-82aa-1ef80b833a9f"), "Black", "https://cdn.pixabay.com/photo/2012/05/29/00/43/car-49278_960_720.jpg", "Bugatti", 15035, "Veyron", 2018 },
                    { new Guid("f0c5592d-06e2-449d-84ed-4ee70dd672f6"), new Guid("bbab4d5a-8565-48b1-9450-5ac2a5c4a654"), "Black", "https://cdn.pixabay.com/photo/2012/11/02/13/02/car-63930_960_720.jpg", "Ford", 65125, "Mustang", 2023 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_AuctionId",
                table: "Subjects",
                column: "AuctionId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Auctions");
        }
    }
}
