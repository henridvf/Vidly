using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.Migrations
{
    public partial class SeedMovies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "DateAdded", "GenreId", "Name", "NumberAvailable", "NumberInStock", "ReleaseDate" },
                values: new object[] { 1, new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)1, "Gladiator", (byte)3, (byte)2, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "DateAdded", "GenreId", "Name", "NumberAvailable", "NumberInStock", "ReleaseDate" },
                values: new object[] { 2, new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)3, "Despicable Me", (byte)5, (byte)2, new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "DateAdded", "GenreId", "Name", "NumberAvailable", "NumberInStock", "ReleaseDate" },
                values: new object[] { 3, new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)2, "Entrapment", (byte)3, (byte)3, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
