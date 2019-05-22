using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperheroBattle.DataAccessHandlers.Migrations
{
    public class AddAbilityLevelMigration : Migration
    {
        protected override void Up( MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>("StrengthLevel", "Abilities", "int", null, 100);
            migrationBuilder.AddColumn<int>("AbilityModifier", "Superheroes", "int", null, 100);
        }
    }
}
