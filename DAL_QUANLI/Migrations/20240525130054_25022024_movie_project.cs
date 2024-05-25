using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quanliapp.Migrations.Data
{
    /// <inheritdoc />
    public partial class _25022024_movie_project : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nameVN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nameCN = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    genres_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    thumbnail_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trailer_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    movie_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    create_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    national_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    language_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    release_year = table.Column<int>(type: "int", nullable: true),
                    duration = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MovieComment",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    movie_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false),
                    movie_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_parent = table.Column<bool>(type: "bit", nullable: true),
                    parent_id = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieComment", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MovieFavorites",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    movie_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false),
                    movie_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    movie_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    movie_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    movie_thumbnail_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    delete_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieFavorites", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MovieGenres",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    create_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    genres_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_parent = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenres", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MovieReactionToComment",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    reaction_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    comment_id = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieReactionToComment", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MovieReactionToMovie",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    reaction_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    movie_id = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieReactionToMovie", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MovieReivew",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rating = table.Column<double>(type: "float", nullable: true),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    movie_id = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieReivew", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MovieWatchHistory",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    create_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    movie_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    movie_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    movie_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    movie_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    movie_thumbnail_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    time_view = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieWatchHistory", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "MovieComment");

            migrationBuilder.DropTable(
                name: "MovieFavorites");

            migrationBuilder.DropTable(
                name: "MovieGenres");

            migrationBuilder.DropTable(
                name: "MovieReactionToComment");

            migrationBuilder.DropTable(
                name: "MovieReactionToMovie");

            migrationBuilder.DropTable(
                name: "MovieReivew");

            migrationBuilder.DropTable(
                name: "MovieWatchHistory");
        }
    }
}
