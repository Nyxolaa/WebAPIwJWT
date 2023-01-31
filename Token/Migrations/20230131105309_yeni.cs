using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Token.Migrations
{
    public partial class yeni : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Kategoriler",
            //    columns: table => new
            //    {
            //        KategoriID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        KategoriAdi = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Kategoriler", x => x.KategoriID);
            //    });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    kullaniciID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.kullaniciID);
                });

            //migrationBuilder.CreateTable(
            //    name: "Kitaplar",
            //    columns: table => new
            //    {
            //        KitapID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        KitapAdi = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
            //        KategoriID = table.Column<int>(type: "int", nullable: false),
            //        Fiyat = table.Column<decimal>(type: "money", nullable: false),
            //        KapakResmi = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
                //constraints: table =>
                //{
                //    table.PrimaryKey("PK_Kitaplar", x => x.KitapID);
                //    table.ForeignKey(
                //        name: "FK_Kitaplar_Kategoriler_KategoriID",
                //        column: x => x.KategoriID,
                //        principalTable: "Kategoriler",
                //        principalColumn: "KategoriID",
                //        onDelete: ReferentialAction.Cascade);
                //});

            migrationBuilder.InsertData(
                table: "Kullanicilar",
                columns: new[] { "kullaniciID", "Sifre", "kullaniciAdi" },
                values: new object[] { 1, "cev123", "cevdo" });

            migrationBuilder.InsertData(
                table: "Kullanicilar",
                columns: new[] { "kullaniciID", "Sifre", "kullaniciAdi" },
                values: new object[] { 2, "sel123", "selo" });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Kitaplar_KategoriID",
            //    table: "Kitaplar",
            //    column: "KategoriID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kitaplar");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "Kategoriler");
        }
    }
}
