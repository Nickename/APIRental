using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverLicenceNr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    RentalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    PickUpDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingMade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    ReadyForPickUp = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.RentalId);
                });

            migrationBuilder.CreateTable(
                name: "VehicleCategories",
                columns: table => new
                {
                    VehicleCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    PricePerDay = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleCategories", x => x.VehicleCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleCategoryId = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PlateNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_Cars_VehicleCategories_VehicleCategoryId",
                        column: x => x.VehicleCategoryId,
                        principalTable: "VehicleCategories",
                        principalColumn: "VehicleCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "Address", "City", "DriverLicenceNr", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "123 Main St", "Anytown", 123456789, "johndoe@gmail.com", "John", "Doe" },
                    { 2, "456 Maple Ave", "Othertown", 987654321, "janedoe@gmail.com", "Jane", "Doe" },
                    { 3, "789 Oak St", "Somewhere", 456123789, "bobsmith@gmail.com", "Bob", "Smith" },
                    { 4, "456 Elm St", "Anywhere", 789123456, "alicejones@gmail.com", "Alice", "Jones" },
                    { 5, "789 Pine St", "Nowhere", 123789456, "michaeljohnson@gmail.com", "Michael", "Johnson" },
                    { 6, "123 Cedar St", "Someplace", 987654321, "emilydavis@gmail.com", "Emily", "Davis" },
                    { 7, "456 Oak St", "Anywhere", 654321789, "davidbrown@gmail.com", "David", "Brown" },
                    { 8, "789 Cedar St", "Somewhere", 321456987, "oliviamiller@gmail.com", "Olivia", "Miller" },
                    { 9, "123 Pine St", "Nowhere", 789456123, "jameswilson@gmail.com", "James", "Wilson" },
                    { 10, "456 Elm St", "Someplace", 654789321, "sophiamoore@gmail.com", "Sophia", "Moore" },
                    { 11, "789 Cedar St", "Anywhere", 123456789, "williamtaylor@gmail.com", "William", "Taylor" },
                    { 12, "123 Oak St", "Somewhere", 321789456, "emmaanderson@gmail.com", "Emma", "Anderson" },
                    { 13, "456 Pine St", "Nowhere", 987654321, "charlesjohnson@gmail.com", "Charles", "Johnson" },
                    { 14, "789 Cedar St", "Someplace", 456789123, "avawilson@gmail.com", "Ava", "Wilson" },
                    { 15, "123 Elm St", "Anywhere", 789123456, "alexandermartin@gmail.com", "Alexander", "Martin" },
                    { 16, "456 Cedar St", "Somewhere", 123789456, "miaclark@gmail.com", "Mia", "Clark" }
                });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "RentalId", "BookingMade", "CarId", "CustomerId", "PickUpDate", "ReadyForPickUp", "ReturnDate", "TotalPrice" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 18, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2066), 1, 1, new DateTime(2023, 4, 19, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2111), false, new DateTime(2023, 4, 23, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2114), 245.0 },
                    { 2, new DateTime(2023, 4, 18, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2118), 2, 2, new DateTime(2023, 4, 20, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2120), false, new DateTime(2023, 4, 24, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2121), 354.0 },
                    { 3, new DateTime(2023, 4, 18, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2124), 3, 3, new DateTime(2023, 4, 21, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2126), false, new DateTime(2023, 4, 25, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2128), 483.0 },
                    { 4, new DateTime(2023, 4, 18, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2130), 1, 1, new DateTime(2023, 7, 27, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2132), false, new DateTime(2023, 7, 28, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2133), 483.0 },
                    { 5, new DateTime(2023, 4, 18, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2135), 2, 2, new DateTime(2023, 11, 4, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2137), false, new DateTime(2023, 11, 5, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2139), 483.0 },
                    { 6, new DateTime(2023, 4, 18, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2141), 3, 3, new DateTime(2023, 4, 22, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2142), false, new DateTime(2023, 4, 26, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2144), 531.0 },
                    { 7, new DateTime(2023, 4, 18, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2146), 4, 4, new DateTime(2023, 4, 23, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2148), false, new DateTime(2023, 4, 27, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2150), 608.0 },
                    { 8, new DateTime(2023, 4, 18, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2152), 5, 5, new DateTime(2023, 4, 24, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2154), false, new DateTime(2023, 4, 28, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2155), 704.0 },
                    { 9, new DateTime(2023, 4, 18, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2157), 6, 6, new DateTime(2023, 4, 25, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2159), false, new DateTime(2023, 4, 29, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2161), 846.0 },
                    { 10, new DateTime(2023, 4, 18, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2163), 7, 7, new DateTime(2023, 4, 26, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2164), false, new DateTime(2023, 4, 30, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2166), 923.0 },
                    { 11, new DateTime(2023, 4, 18, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2168), 8, 8, new DateTime(2023, 4, 27, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2170), false, new DateTime(2023, 5, 1, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2172), 1020.0 },
                    { 12, new DateTime(2023, 4, 18, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2174), 9, 9, new DateTime(2023, 4, 28, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2175), false, new DateTime(2023, 5, 2, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2177), 1162.0 },
                    { 13, new DateTime(2023, 4, 18, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2179), 10, 10, new DateTime(2023, 4, 29, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2181), false, new DateTime(2023, 5, 3, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2182), 1239.0 },
                    { 14, new DateTime(2023, 4, 18, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2184), 11, 11, new DateTime(2023, 4, 30, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2186), false, new DateTime(2023, 5, 4, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2188), 1381.0 },
                    { 15, new DateTime(2023, 4, 18, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2190), 12, 12, new DateTime(2023, 5, 1, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2191), false, new DateTime(2023, 5, 5, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2193), 1484.0 },
                    { 16, new DateTime(2023, 4, 18, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2195), 13, 13, new DateTime(2023, 5, 2, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2197), false, new DateTime(2023, 5, 6, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2198), 1626.0 },
                    { 17, new DateTime(2023, 4, 18, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2200), 14, 14, new DateTime(2023, 5, 3, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2202), false, new DateTime(2023, 5, 7, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2204), 1852.0 },
                    { 18, new DateTime(2023, 4, 18, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2206), 15, 15, new DateTime(2023, 5, 4, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2208), false, new DateTime(2023, 5, 8, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2209), 2019.0 },
                    { 19, new DateTime(2023, 4, 18, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2211), 16, 16, new DateTime(2023, 5, 5, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2213), false, new DateTime(2023, 5, 9, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2215), 2186.0 },
                    { 20, new DateTime(2023, 4, 18, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2217), 1, 2, new DateTime(2023, 5, 6, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2218), false, new DateTime(2023, 5, 10, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2220), 189.0 },
                    { 21, new DateTime(2023, 4, 18, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2222), 2, 3, new DateTime(2023, 5, 7, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2224), false, new DateTime(2023, 5, 11, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2225), 327.0 },
                    { 22, new DateTime(2023, 4, 18, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2227), 3, 4, new DateTime(2023, 5, 8, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2229), false, new DateTime(2023, 5, 12, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2231), 453.0 },
                    { 23, new DateTime(2023, 4, 18, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2233), 4, 5, new DateTime(2023, 5, 9, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2235), false, new DateTime(2023, 5, 13, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2236), 571.0 },
                    { 24, new DateTime(2023, 4, 18, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2238), 5, 6, new DateTime(2023, 5, 10, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2240), false, new DateTime(2023, 5, 14, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2241), 708.0 },
                    { 25, new DateTime(2023, 4, 18, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2243), 6, 7, new DateTime(2023, 5, 11, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2245), false, new DateTime(2023, 5, 15, 12, 40, 1, 330, DateTimeKind.Local).AddTicks(2247), 835.0 }
                });

            migrationBuilder.InsertData(
                table: "VehicleCategories",
                columns: new[] { "VehicleCategoryId", "Description", "Name", "PricePerDay" },
                values: new object[,]
                {
                    { 1, "desc", "SUV", 5000.0 },
                    { 2, "desc", "Sedan", 5000.0 },
                    { 3, "desc", "Sport", 5000.0 },
                    { 4, "desc", "Pickup Truck", 5000.0 },
                    { 5, "desc", "Minivan", 5000.0 }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "Brand", "Description", "ImgUrl", "Model", "PlateNumber", "VehicleCategoryId" },
                values: new object[,]
                {
                    { 1, "Kia", "Car description", "https://assets-clean.local-car-finder.com/images/15316/15316_st1280_089.png", "Sorento", "abc123", 1 },
                    { 2, "Kia", "Car description", "https://www.motortrend.com/uploads/izmo/kia/cadenza/2020/cadenza.png", "Cadenza", "abc123", 2 },
                    { 3, "Toyota", "Car description", "https://imgd.aeplcdn.com/1200x900/n/cw/ec/110233/2022-camry-exterior-right-front-three-quarter.jpeg?isig=0&q=75", "Camry", "abc123", 2 },
                    { 4, "Kia", "Car description", "https://m.atcdn.co.uk/vms/media/e3821c59c01441719e67442360718ecf.jpg", "Stinger", "abc123", 3 },
                    { 5, "GMC", "Car description", "https://inv.assets.sincrod.com/RTT/GMC/2023/5959513/default/ext_GAZ_deg02.jpg", "Canyon", "abc123", 4 },
                    { 6, "Kia", "Car description", "https://di-uploads-pod12.dealerinspire.com/beavertonkiaredesign/uploads/2019/04/white-kia-sedona-cc0998a8.jpg", "Sedona", "abc123", 5 },
                    { 7, "Toyota", "Car description", "https://cdni.autocarindia.com/utils/imageresizer.ashx?n=https://cms.haymarketindia.net/model/uploads/modelimages/Toyota-Fortuner-110120211829.jpg", "Fortuner", "abc123", 1 },
                    { 8, "Audi", "Car description", "https://inventory.dealersocket.com/api/photo/ZAltwpW4/1024x0/1675973999/u/ecl/RU1k/dCe4/c1eG/6Z1Q/1kKv/cQ.jpg", "Q3 Quattro", "abc123", 1 },
                    { 9, "Hummer", "Car description", "https://stimg.cardekho.com/images/carexteriorimages/930x620/Hummer/Hummer-H2/321/1561092676445/front-left-side-47.jpg", "H2", "abc123", 1 },
                    { 10, "Porsche", "Car description", "https://imgd.aeplcdn.com/1280x720/cw/ec/32951/Porsche-Cayenne-Exterior-138359.jpg?wm=0&q=75", "Cayenne", "abc123", 1 },
                    { 11, "Honda", "Car description", "https://imgd.aeplcdn.com/0x0/cw/ec/21613/Honda-Accord-Right-Front-Three-Quarter-82683.jpg?v=201711021421", "Accord", "abc123", 2 },
                    { 12, "Mercedes-Benz", "Car description", "https://www.mercedes-benz.se/passengercars/mercedes-benz-cars/s-class/range-overview/_jcr_content/swipeableteaserbox/par/swipeableteaser/asset.MQ6.12.20210602153015.jpeg", "S-Class", "abc123", 2 },
                    { 13, "BMW", "Car description", "https://www.bmw.in/content/dam/bmw/marketIN/bmw_in/all-models/5-series/2020/Interior-andexterior/530d-M-Sport-Front-Quarter.jpg.asset.1623071674609.jpg", "5-Series", "abc123", 2 },
                    { 14, "Porsche", "Car description", "https://tdrresearch.azureedge.net/photos/chrome/Expanded/White/2021PRC010103/2021PRC01010301.jpg", "911", "abc123", 3 },
                    { 15, "Chevrolet", "Car description", "https://www.chevrolet.com.mx/content/dam/chevrolet/na/mx/es/index/performance/2023-corvette-stingray/colorizer/jellys/black.jpg?imwidth=960", "Corvette", "abc123", 3 },
                    { 16, "Audi", "Car description", "https://mediaservice.audi.com/media/fast/H4sIAAAAAAAAAFvzloG1tIiBOTrayfuvpGh6-m1zJgaGigIGBgZGoDhTtNOaz-I_2DhCHkCFmZQZWMpTkwoYgSrcmLgycxPTU_VBArz____nZ-QustBNrSjRzUvNzWcHKhHkiZsfe9Uw6_id7Q-9vswPcnnBfueZOAOP5I12FrNLew-2znNlmMC35scXWVYfBh4zex33VgEGr7gsDulu9xl7Hy6oZWbg4TW-PefHP5aZep8faqne937GscFNm4GnVCPogbFQwfYPGpHX08-uzWD6YTeLgefYQuU3z-9lz7BZlM9wmm_Jvw_P_gLNPWW3dm-h6SrFcv1NL7ZpNVZ2lnyZDRR1mn31tOCp33K3n23XmLfm_gmWKCEGnh-taY8Y_cOTDgioMH91rql2WjYtl4GnXUGyQu7CH6-ENxdffdr5nrln8ROgGx7dWV_Cxbpjq0tetNre7_7Ol-WehzHwHLW7m2XMH80we60ZQ9XfLrM-kRdTGXj2Vij-ZomzELj55MTlzr8nZdOvWwgy8Bhlq3z6UJ0htC89XDRI4dsuj_feTgw8c45a_p6440W6hirHZ52PJu8rE5awMPAwPNDLqtdewTRZz-jLdqVll3aHLH_OwNN51f1lSnDMTB5pniyPd5PnxTAtPcfACowept1AgiUOSPA8ARIcNgxgEhRxG4AE40IQn7WemYGB24GBgS2EAQT4hEuLcgoSixJz9YpSiwvy84ozy1IFNQyIBMKsPo6RrkEAFfedMlYCAAA?mimetype=image/png", "R8", "abc123", 3 },
                    { 17, "Nissan", "Car description", "https://www.nissan.se/content/dam/Nissan/nissan_europe/experience_nissan/performance/18tdieu-helios317.jpg", "GTR", "abc123", 3 },
                    { 18, "Ford", "Car description", "https://di-uploads-pod14.dealerinspire.com/kingsford/uploads/2020/06/2021-Ford-F-150-left-1.jpg", "F-150", "abc123", 4 },
                    { 19, "Chevrolet", "Car description", "https://www.hsv.com.au/images/see/silverado/Silverado-2500HD-LTZ-Midnight-Edition-Black.jpg", "Silverado", "abc123", 4 },
                    { 20, "RAM", "Car description", "https://aeceurope.com/wp-content/uploads/2022/07/ram_trx_flame_red_x_black.jpg", "1500", "abc123", 4 },
                    { 21, "Toyota ", "Car description", "https://www.toyotaofnewbern.com/assets/stock/colormatched_01/transparent/1280/cc_2023tot09_01_1280/cc_2023tot090074_01_1280_040.png?bg-color=FFFFFF", "Tacoma", "abc123", 4 },
                    { 22, "Chrysler", "Car description", "https://medias.fcacanada.ca/jellies/renditions/2023/800x510/CC23_RUCS53_2DS_PAU_APA_XXX_XXX_XXX.ec6a769ba13c51aaf9074a442629fe4c.png", "Pacifica", "abc123", 5 },
                    { 23, "Honda", "Car description", "https://www.honda.ca/-/media/Brands/Honda/Models/ODYSSEY/2023/Overview/03_Key-Features/desktop/Honda_Odyssey_key-features_desktop_1036x520.png?h=520&iar=0&w=1036&rev=fb3f14bd71a94de697e91e783024600a&hash=33043FE0D7B4FD01D4C775BD095CFEED", "Odyssey", "abc123", 5 },
                    { 24, "Toyota", "Car description", "https://di-uploads-pod28.dealerinspire.com/colonialtoyota/uploads/2021/11/2022-Toyota-Sienna-LE-.jpg", "Sienna", "abc123", 5 },
                    { 25, "Dodge ", "Car description", "https://images.hgmsites.net/lrg/2010-dodge-grand-caravan-4-door-wagon-sxt-angular-front-exterior-view_100252340_l.jpg", "Grand Caravan", "abc123", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_VehicleCategoryId",
                table: "Cars",
                column: "VehicleCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "VehicleCategories");
        }
    }
}
