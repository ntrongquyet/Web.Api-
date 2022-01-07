using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Api.Migrations
{
    public partial class initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cat_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    softDelete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.id);
                    table.ForeignKey(
                        name: "FK_Product_Category",
                        column: x => x.cat_id,
                        principalTable: "Category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_product = table.Column<int>(type: "int", nullable: true),
                    path = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.id);
                    table.ForeignKey(
                        name: "FK_Image_Product",
                        column: x => x.id_product,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "id", "name" },
                values: new object[] { 1, "Apple" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "id", "name" },
                values: new object[] { 2, "Samsung" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "id", "name" },
                values: new object[] { 3, "Xiaomi" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "id", "cat_id", "description", "name", "price", "softDelete" },
                values: new object[] { 1, 1, "iPhone 13 Pro Max 256GB được đánh giá là một trong những dòng iPhone có khả năng chụp ảnh siêu ấn tượng cùng với camera góc siêu rộng mang đến khả năng chụp ảnh thiếu sáng một cách đặc biệt. Không những thế, mà dòng iPhone này còn được đánh giá là có dung lượng bộ nhớ tốt, đáp ứng được đầy đủ các công việc hằng ngày Xem thêm thông tin iPhone 13 Pro Max 512GB thiết kế đẳng cấp, mang lại trải nghiệm vượt trội cho người dùng", "iPhone 13 Pro Max 256GB I Chính hãng VN/A", 33500000m, false });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "id", "cat_id", "description", "name", "price", "softDelete" },
                values: new object[] { 2, 3, "Làm chủ mọi khung hình - Bộ 3 camera sau 108 MP, camera selfie 20 MP\nHiệu năng vượt trội, xử lý cực nhanh - Chip Snapdragon 888 cao cấp, 8 GB RAM LPDDR5\nThiết kế thời thượng đi đầu xu hướng - Hoàn thiện thiết kế siêu mỏng từ kim loại và kính cường lực\nHiển thị rõ ràng, sắc nét - Màn hình tràn viền AMOLED 6.81 inch, 120Hz\nSáng tạo chuyên nghiệp mọi lúc, mọi nơi - Cụm 3 camera sau 108 MP, camera selfie 20 MP, chống rung quang học", "Xiaomi Mi 11 5G 128GB", 14200000m, false });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "id", "id_product", "path" },
                values: new object[,]
                {
                    { 1, 1, "1_1.jpg" },
                    { 2, 1, "1_2.jpg" },
                    { 3, 2, "2_1.jpg" },
                    { 4, 2, "2_1.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Image_id_product",
                table: "Image",
                column: "id_product");

            migrationBuilder.CreateIndex(
                name: "IX_Product_cat_id",
                table: "Product",
                column: "cat_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
