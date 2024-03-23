using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AuctionService.Migrations
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
                    { new Guid("155225c1-4448-4066-9886-6786536e05ea"), new DateTime(2024, 3, 6, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4777), new DateTime(2024, 3, 16, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4775), null, 50000, "tom", null, 2, new DateTime(2024, 3, 16, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4776), null },
                    { new Guid("3659ac24-29dd-407a-81f5-ecfe6f924b9b"), new DateTime(2024, 5, 3, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4800), new DateTime(2024, 3, 16, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4798), null, 20000, "bob", null, 0, new DateTime(2024, 3, 16, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4799), null },
                    { new Guid("40490065-dac7-46b6-acc4-df507e0d6570"), new DateTime(2024, 4, 5, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4794), new DateTime(2024, 3, 16, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4792), null, 20000, "tom", null, 0, new DateTime(2024, 3, 16, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4792), null },
                    { new Guid("466e4744-4dc5-4987-aae0-b621acfc5e39"), new DateTime(2024, 4, 15, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4781), new DateTime(2024, 3, 16, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4779), null, 20000, "alice", null, 0, new DateTime(2024, 3, 16, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4779), null },
                    { new Guid("47111973-d176-4feb-848d-0ea22641c31a"), new DateTime(2024, 3, 29, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4789), new DateTime(2024, 3, 16, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4787), null, 150000, "alice", null, 0, new DateTime(2024, 3, 16, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4788), null },
                    { new Guid("6a5011a1-fe1f-47df-9a32-b5346b289391"), new DateTime(2024, 4, 4, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4791), new DateTime(2024, 3, 16, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4790), null, 0, "bob", null, 0, new DateTime(2024, 3, 16, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4790), null },
                    { new Guid("afbee524-5972-4075-8800-7d1f9d7b0a0c"), new DateTime(2024, 3, 26, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4758), new DateTime(2024, 3, 16, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4743), null, 20000, "bob", null, 0, new DateTime(2024, 3, 16, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4746), null },
                    { new Guid("bbab4d5a-8565-48b1-9450-5ac2a5c4a654"), new DateTime(2024, 3, 20, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4774), new DateTime(2024, 3, 16, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4772), null, 0, "bob", null, 0, new DateTime(2024, 3, 16, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4772), null },
                    { new Guid("c8c3ec17-01bf-49db-82aa-1ef80b833a9f"), new DateTime(2024, 5, 15, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4771), new DateTime(2024, 3, 16, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4769), null, 90000, "alice", null, 0, new DateTime(2024, 3, 16, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4770), null },
                    { new Guid("dc1e4071-d19d-459b-b848-b5c3cd3d151f"), new DateTime(2024, 4, 30, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4787), new DateTime(2024, 3, 16, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4785), null, 20000, "bob", null, 0, new DateTime(2024, 3, 16, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4785), null }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "AuctionId", "Color", "ImageUrl", "Make", "Mileage", "Model", "Year" },
                values: new object[,]
                {
                    { new Guid("0e5a20b6-5702-4ce2-9629-704db8a50601"), new Guid("6a5011a1-fe1f-47df-9a32-b5346b289391"), "White", "https://cdn.pixabay.com/photo/2019/12/26/20/50/audi-r8-4721217_960_720.jpg", "Audi", 10050, "R8", 2021 },
                    { new Guid("19749800-e6de-44cf-bbdf-f2cf3d6a4898"), new Guid("dc1e4071-d19d-459b-b848-b5c3cd3d151f"), "Red", "https://cdn.pixabay.com/photo/2017/11/09/01/49/ferrari-458-spider-2932191_960_720.jpg", "Ferrari", 50000, "Spider", 2015 },
                    { new Guid("290fc4f1-3945-49e2-8d62-9c058ac1fc8d"), new Guid("47111973-d176-4feb-848d-0ea22641c31a"), "Red", "https://cdn.pixabay.com/photo/2017/11/08/14/39/ferrari-f430-2930661_960_720.jpg", "Ferrari", 5000, "F-430", 2022 },
                    { new Guid("4988b805-8acb-48bd-8d93-027a3a87592c"), new Guid("3659ac24-29dd-407a-81f5-ecfe6f924b9b"), "Rust", "https://cdn.pixabay.com/photo/2017/08/02/19/47/vintage-2573090_960_720.jpg", "Ford", 150150, "Model T", 1938 },
                    { new Guid("61be6da6-dfb2-42ac-9338-0c09a8b808a3"), new Guid("466e4744-4dc5-4987-aae0-b621acfc5e39"), "White", "https://cdn.pixabay.com/photo/2017/08/31/05/47/bmw-2699538_960_720.jpg", "BMW", 90000, "X1", 2017 },
                    { new Guid("69857315-7f7b-40f1-be81-abdc3e28042b"), new Guid("c8c3ec17-01bf-49db-82aa-1ef80b833a9f"), "Black", "https://cdn.pixabay.com/photo/2012/05/29/00/43/car-49278_960_720.jpg", "Bugatti", 15035, "Veyron", 2018 },
                    { new Guid("83e4d264-c695-4082-9efe-9ed706e15478"), new Guid("155225c1-4448-4066-9886-6786536e05ea"), "Silver", "https://cdn.pixabay.com/photo/2016/04/17/22/10/mercedes-benz-1335674_960_720.png", "Mercedes", 15001, "SLK", 2020 },
                    { new Guid("9396b4b0-64ac-45f6-a4aa-9e565c333798"), new Guid("40490065-dac7-46b6-acc4-df507e0d6570"), "Black", "https://cdn.pixabay.com/photo/2016/09/01/15/06/audi-1636320_960_720.jpg", "Audi", 25400, "TT", 2020 },
                    { new Guid("be60874b-b6f6-41ed-9a82-7e192ea3c59c"), new Guid("bbab4d5a-8565-48b1-9450-5ac2a5c4a654"), "Black", "https://cdn.pixabay.com/photo/2012/11/02/13/02/car-63930_960_720.jpg", "Ford", 65125, "Mustang", 2023 },
                    { new Guid("f53c5675-acf7-49f4-b9af-8dfbd8c3f7d0"), new Guid("afbee524-5972-4075-8800-7d1f9d7b0a0c"), "White", "https://cdn.pixabay.com/photo/2016/05/06/16/32/car-1376190_960_720.jpg", "Ford", 50000, "GT", 2020 }
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
