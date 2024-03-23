using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AuctionService.Migrations
{
    /// <inheritdoc />
    public partial class Outbox : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("0e5a20b6-5702-4ce2-9629-704db8a50601"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("19749800-e6de-44cf-bbdf-f2cf3d6a4898"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("290fc4f1-3945-49e2-8d62-9c058ac1fc8d"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("4988b805-8acb-48bd-8d93-027a3a87592c"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("61be6da6-dfb2-42ac-9338-0c09a8b808a3"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("69857315-7f7b-40f1-be81-abdc3e28042b"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("83e4d264-c695-4082-9efe-9ed706e15478"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("9396b4b0-64ac-45f6-a4aa-9e565c333798"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("be60874b-b6f6-41ed-9a82-7e192ea3c59c"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("f53c5675-acf7-49f4-b9af-8dfbd8c3f7d0"));

            migrationBuilder.CreateTable(
                name: "InboxState",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MessageId = table.Column<Guid>(type: "uuid", nullable: false),
                    ConsumerId = table.Column<Guid>(type: "uuid", nullable: false),
                    LockId = table.Column<Guid>(type: "uuid", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    Received = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ReceiveCount = table.Column<int>(type: "integer", nullable: false),
                    ExpirationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Consumed = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Delivered = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastSequenceNumber = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InboxState", x => x.Id);
                    table.UniqueConstraint("AK_InboxState_MessageId_ConsumerId", x => new { x.MessageId, x.ConsumerId });
                });

            migrationBuilder.CreateTable(
                name: "OutboxMessage",
                columns: table => new
                {
                    SequenceNumber = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EnqueueTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SentTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Headers = table.Column<string>(type: "text", nullable: true),
                    Properties = table.Column<string>(type: "text", nullable: true),
                    InboxMessageId = table.Column<Guid>(type: "uuid", nullable: true),
                    InboxConsumerId = table.Column<Guid>(type: "uuid", nullable: true),
                    OutboxId = table.Column<Guid>(type: "uuid", nullable: true),
                    MessageId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContentType = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    MessageType = table.Column<string>(type: "text", nullable: false),
                    Body = table.Column<string>(type: "text", nullable: false),
                    ConversationId = table.Column<Guid>(type: "uuid", nullable: true),
                    CorrelationId = table.Column<Guid>(type: "uuid", nullable: true),
                    InitiatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    RequestId = table.Column<Guid>(type: "uuid", nullable: true),
                    SourceAddress = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    DestinationAddress = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ResponseAddress = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    FaultAddress = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ExpirationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutboxMessage", x => x.SequenceNumber);
                });

            migrationBuilder.CreateTable(
                name: "OutboxState",
                columns: table => new
                {
                    OutboxId = table.Column<Guid>(type: "uuid", nullable: false),
                    LockId = table.Column<Guid>(type: "uuid", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Delivered = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastSequenceNumber = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutboxState", x => x.OutboxId);
                });

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: new Guid("155225c1-4448-4066-9886-6786536e05ea"),
                columns: new[] { "AuctionEnd", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 7, 19, 2, 54, 28, DateTimeKind.Utc).AddTicks(4914), new DateTime(2024, 3, 17, 19, 2, 54, 28, DateTimeKind.Utc).AddTicks(4911), new DateTime(2024, 3, 17, 19, 2, 54, 28, DateTimeKind.Utc).AddTicks(4912) });

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: new Guid("3659ac24-29dd-407a-81f5-ecfe6f924b9b"),
                columns: new[] { "AuctionEnd", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 4, 19, 2, 54, 28, DateTimeKind.Utc).AddTicks(4934), new DateTime(2024, 3, 17, 19, 2, 54, 28, DateTimeKind.Utc).AddTicks(4932), new DateTime(2024, 3, 17, 19, 2, 54, 28, DateTimeKind.Utc).AddTicks(4932) });

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: new Guid("40490065-dac7-46b6-acc4-df507e0d6570"),
                columns: new[] { "AuctionEnd", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 6, 19, 2, 54, 28, DateTimeKind.Utc).AddTicks(4930), new DateTime(2024, 3, 17, 19, 2, 54, 28, DateTimeKind.Utc).AddTicks(4928), new DateTime(2024, 3, 17, 19, 2, 54, 28, DateTimeKind.Utc).AddTicks(4929) });

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: new Guid("466e4744-4dc5-4987-aae0-b621acfc5e39"),
                columns: new[] { "AuctionEnd", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 16, 19, 2, 54, 28, DateTimeKind.Utc).AddTicks(4917), new DateTime(2024, 3, 17, 19, 2, 54, 28, DateTimeKind.Utc).AddTicks(4915), new DateTime(2024, 3, 17, 19, 2, 54, 28, DateTimeKind.Utc).AddTicks(4915) });

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: new Guid("47111973-d176-4feb-848d-0ea22641c31a"),
                columns: new[] { "AuctionEnd", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 30, 19, 2, 54, 28, DateTimeKind.Utc).AddTicks(4925), new DateTime(2024, 3, 17, 19, 2, 54, 28, DateTimeKind.Utc).AddTicks(4923), new DateTime(2024, 3, 17, 19, 2, 54, 28, DateTimeKind.Utc).AddTicks(4924) });

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: new Guid("6a5011a1-fe1f-47df-9a32-b5346b289391"),
                columns: new[] { "AuctionEnd", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 5, 19, 2, 54, 28, DateTimeKind.Utc).AddTicks(4927), new DateTime(2024, 3, 17, 19, 2, 54, 28, DateTimeKind.Utc).AddTicks(4926), new DateTime(2024, 3, 17, 19, 2, 54, 28, DateTimeKind.Utc).AddTicks(4926) });

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: new Guid("afbee524-5972-4075-8800-7d1f9d7b0a0c"),
                columns: new[] { "AuctionEnd", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 27, 19, 2, 54, 28, DateTimeKind.Utc).AddTicks(4892), new DateTime(2024, 3, 17, 19, 2, 54, 28, DateTimeKind.Utc).AddTicks(4879), new DateTime(2024, 3, 17, 19, 2, 54, 28, DateTimeKind.Utc).AddTicks(4882) });

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: new Guid("bbab4d5a-8565-48b1-9450-5ac2a5c4a654"),
                columns: new[] { "AuctionEnd", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 21, 19, 2, 54, 28, DateTimeKind.Utc).AddTicks(4910), new DateTime(2024, 3, 17, 19, 2, 54, 28, DateTimeKind.Utc).AddTicks(4909), new DateTime(2024, 3, 17, 19, 2, 54, 28, DateTimeKind.Utc).AddTicks(4909) });

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: new Guid("c8c3ec17-01bf-49db-82aa-1ef80b833a9f"),
                columns: new[] { "AuctionEnd", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 16, 19, 2, 54, 28, DateTimeKind.Utc).AddTicks(4905), new DateTime(2024, 3, 17, 19, 2, 54, 28, DateTimeKind.Utc).AddTicks(4903), new DateTime(2024, 3, 17, 19, 2, 54, 28, DateTimeKind.Utc).AddTicks(4904) });

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: new Guid("dc1e4071-d19d-459b-b848-b5c3cd3d151f"),
                columns: new[] { "AuctionEnd", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 1, 19, 2, 54, 28, DateTimeKind.Utc).AddTicks(4922), new DateTime(2024, 3, 17, 19, 2, 54, 28, DateTimeKind.Utc).AddTicks(4921), new DateTime(2024, 3, 17, 19, 2, 54, 28, DateTimeKind.Utc).AddTicks(4921) });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "AuctionId", "Color", "ImageUrl", "Make", "Mileage", "Model", "Year" },
                values: new object[,]
                {
                    { new Guid("03bdbccb-9330-46df-a320-86a0594ecf95"), new Guid("40490065-dac7-46b6-acc4-df507e0d6570"), "Black", "https://cdn.pixabay.com/photo/2016/09/01/15/06/audi-1636320_960_720.jpg", "Audi", 25400, "TT", 2020 },
                    { new Guid("0720b68f-ecf1-4052-be2f-4202d76da414"), new Guid("afbee524-5972-4075-8800-7d1f9d7b0a0c"), "White", "https://cdn.pixabay.com/photo/2016/05/06/16/32/car-1376190_960_720.jpg", "Ford", 50000, "GT", 2020 },
                    { new Guid("0d752e09-133a-4240-ba77-9b28ec1e954f"), new Guid("bbab4d5a-8565-48b1-9450-5ac2a5c4a654"), "Black", "https://cdn.pixabay.com/photo/2012/11/02/13/02/car-63930_960_720.jpg", "Ford", 65125, "Mustang", 2023 },
                    { new Guid("22493770-9c44-483a-88c1-1d235bec3556"), new Guid("6a5011a1-fe1f-47df-9a32-b5346b289391"), "White", "https://cdn.pixabay.com/photo/2019/12/26/20/50/audi-r8-4721217_960_720.jpg", "Audi", 10050, "R8", 2021 },
                    { new Guid("26545af2-5d88-4f85-9b4f-53f863de673d"), new Guid("466e4744-4dc5-4987-aae0-b621acfc5e39"), "White", "https://cdn.pixabay.com/photo/2017/08/31/05/47/bmw-2699538_960_720.jpg", "BMW", 90000, "X1", 2017 },
                    { new Guid("38a90df5-9a95-45a5-8e2e-610284009221"), new Guid("3659ac24-29dd-407a-81f5-ecfe6f924b9b"), "Rust", "https://cdn.pixabay.com/photo/2017/08/02/19/47/vintage-2573090_960_720.jpg", "Ford", 150150, "Model T", 1938 },
                    { new Guid("4eb3359a-d9f2-416a-ae81-71a64d0df9b8"), new Guid("155225c1-4448-4066-9886-6786536e05ea"), "Silver", "https://cdn.pixabay.com/photo/2016/04/17/22/10/mercedes-benz-1335674_960_720.png", "Mercedes", 15001, "SLK", 2020 },
                    { new Guid("824cf5f4-5313-4f98-85ca-d5b5c7eec7d4"), new Guid("c8c3ec17-01bf-49db-82aa-1ef80b833a9f"), "Black", "https://cdn.pixabay.com/photo/2012/05/29/00/43/car-49278_960_720.jpg", "Bugatti", 15035, "Veyron", 2018 },
                    { new Guid("927cc1db-91c5-4f92-9cd3-a22834a2b5ec"), new Guid("dc1e4071-d19d-459b-b848-b5c3cd3d151f"), "Red", "https://cdn.pixabay.com/photo/2017/11/09/01/49/ferrari-458-spider-2932191_960_720.jpg", "Ferrari", 50000, "Spider", 2015 },
                    { new Guid("a24b5ad3-214c-4e36-8bb6-88361def9495"), new Guid("47111973-d176-4feb-848d-0ea22641c31a"), "Red", "https://cdn.pixabay.com/photo/2017/11/08/14/39/ferrari-f430-2930661_960_720.jpg", "Ferrari", 5000, "F-430", 2022 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InboxState_Delivered",
                table: "InboxState",
                column: "Delivered");

            migrationBuilder.CreateIndex(
                name: "IX_OutboxMessage_EnqueueTime",
                table: "OutboxMessage",
                column: "EnqueueTime");

            migrationBuilder.CreateIndex(
                name: "IX_OutboxMessage_ExpirationTime",
                table: "OutboxMessage",
                column: "ExpirationTime");

            migrationBuilder.CreateIndex(
                name: "IX_OutboxMessage_InboxMessageId_InboxConsumerId_SequenceNumber",
                table: "OutboxMessage",
                columns: new[] { "InboxMessageId", "InboxConsumerId", "SequenceNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OutboxMessage_OutboxId_SequenceNumber",
                table: "OutboxMessage",
                columns: new[] { "OutboxId", "SequenceNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OutboxState_Created",
                table: "OutboxState",
                column: "Created");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InboxState");

            migrationBuilder.DropTable(
                name: "OutboxMessage");

            migrationBuilder.DropTable(
                name: "OutboxState");

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("03bdbccb-9330-46df-a320-86a0594ecf95"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("0720b68f-ecf1-4052-be2f-4202d76da414"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("0d752e09-133a-4240-ba77-9b28ec1e954f"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("22493770-9c44-483a-88c1-1d235bec3556"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("26545af2-5d88-4f85-9b4f-53f863de673d"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("38a90df5-9a95-45a5-8e2e-610284009221"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("4eb3359a-d9f2-416a-ae81-71a64d0df9b8"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("824cf5f4-5313-4f98-85ca-d5b5c7eec7d4"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("927cc1db-91c5-4f92-9cd3-a22834a2b5ec"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("a24b5ad3-214c-4e36-8bb6-88361def9495"));

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: new Guid("155225c1-4448-4066-9886-6786536e05ea"),
                columns: new[] { "AuctionEnd", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4777), new DateTime(2024, 3, 16, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4775), new DateTime(2024, 3, 16, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4776) });

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: new Guid("3659ac24-29dd-407a-81f5-ecfe6f924b9b"),
                columns: new[] { "AuctionEnd", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 3, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4800), new DateTime(2024, 3, 16, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4798), new DateTime(2024, 3, 16, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4799) });

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: new Guid("40490065-dac7-46b6-acc4-df507e0d6570"),
                columns: new[] { "AuctionEnd", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 5, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4794), new DateTime(2024, 3, 16, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4792), new DateTime(2024, 3, 16, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4792) });

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: new Guid("466e4744-4dc5-4987-aae0-b621acfc5e39"),
                columns: new[] { "AuctionEnd", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 15, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4781), new DateTime(2024, 3, 16, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4779), new DateTime(2024, 3, 16, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4779) });

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: new Guid("47111973-d176-4feb-848d-0ea22641c31a"),
                columns: new[] { "AuctionEnd", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 29, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4789), new DateTime(2024, 3, 16, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4787), new DateTime(2024, 3, 16, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4788) });

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: new Guid("6a5011a1-fe1f-47df-9a32-b5346b289391"),
                columns: new[] { "AuctionEnd", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 4, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4791), new DateTime(2024, 3, 16, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4790), new DateTime(2024, 3, 16, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4790) });

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: new Guid("afbee524-5972-4075-8800-7d1f9d7b0a0c"),
                columns: new[] { "AuctionEnd", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 26, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4758), new DateTime(2024, 3, 16, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4743), new DateTime(2024, 3, 16, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4746) });

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: new Guid("bbab4d5a-8565-48b1-9450-5ac2a5c4a654"),
                columns: new[] { "AuctionEnd", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 20, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4774), new DateTime(2024, 3, 16, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4772), new DateTime(2024, 3, 16, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4772) });

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: new Guid("c8c3ec17-01bf-49db-82aa-1ef80b833a9f"),
                columns: new[] { "AuctionEnd", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 15, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4771), new DateTime(2024, 3, 16, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4769), new DateTime(2024, 3, 16, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4770) });

            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: new Guid("dc1e4071-d19d-459b-b848-b5c3cd3d151f"),
                columns: new[] { "AuctionEnd", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 30, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4787), new DateTime(2024, 3, 16, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4785), new DateTime(2024, 3, 16, 9, 10, 11, 328, DateTimeKind.Utc).AddTicks(4785) });

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
        }
    }
}
