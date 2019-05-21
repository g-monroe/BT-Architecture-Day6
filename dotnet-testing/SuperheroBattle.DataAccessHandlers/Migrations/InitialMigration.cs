using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperheroBattle.DataAccessHandlers.Migrations
{
    public class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable("Superheroes",
                columns: table => new
                {
                    SuperheroID = table.Column<int>(nullable: false)
                                       .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SuperheroName = table.Column<string>(nullable: false),
                    SecretIdentity = table.Column<string>(nullable: true),
                    AgeAtOrigin = table.Column<int>(nullable: true),
                    YearOfAppearance = table.Column<int>(nullable: false),
                    IsAlien = table.Column<bool>(nullable: false),
                    PlanetOfOrigin = table.Column<int>(nullable: true),
                    OriginStory = table.Column<string>(nullable: false),
                    Universe = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Superheroes", x => x.SuperheroID);
                });

            migrationBuilder.CreateTable("Abilities",
                columns: table => new
                {
                    AbilityID = table.Column<int>(nullable: false)
                                     .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.AbilityID);
                });

            migrationBuilder.CreateTable("SuperheroAbilities",
                 columns: table => new
                 {
                     SuperheroID = table.Column<int>(nullable: false),
                     AbilityID = table.Column<int>(nullable: false)
                 },
                 constraints: table =>
                 {
                     table.ForeignKey("PK_SuperheroAbilities_Superheroes__SuperheroID", x => x.SuperheroID, "Superheroes", "SuperheroID");
                     table.ForeignKey("PK_SuperheroAbilities_Abilities__AbilityID", x => x.AbilityID, "Abilities", "AbilityID");
                 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Superheroes");
        }
    }
}
