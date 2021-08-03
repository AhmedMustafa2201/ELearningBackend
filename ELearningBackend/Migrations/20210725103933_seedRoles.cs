using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ELearningBackend.Migrations
{
    public partial class seedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
           table: "AspNetRoles"
           , columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" }
           , values: new object[] { Guid.NewGuid().ToString(), "Bronze", "Bronze".ToUpper(), Guid.NewGuid().ToString() }
           );
            migrationBuilder.InsertData(
           table: "AspNetRoles"
           , columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" }
           , values: new object[] { Guid.NewGuid().ToString(), "Silver", "Silver".ToUpper(), Guid.NewGuid().ToString() }
           );
            migrationBuilder.InsertData(
           table: "AspNetRoles"
           , columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" }
           , values: new object[] { Guid.NewGuid().ToString(), "Gold", "Gold".ToUpper(), Guid.NewGuid().ToString() }
           );
            migrationBuilder.InsertData(
                table: "AspNetRoles"
                , columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" }
                , values: new object[] { Guid.NewGuid().ToString(), "Admin", "Admin".ToUpper(), Guid.NewGuid().ToString() }
                );

            //inserting new user
           // migrationBuilder.InsertData(
           //table: "AspNetUsers"
           //, columns: new[] { "Id", "FirstName", "LastName", "EmailConfirmed", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnabled", "AccessFailedCount" }
           //, values: new object[] { Guid.NewGuid().ToString(), "Ahmed", "Mustafa",false, false, false, false, 0  }
           //);
           // migrationBuilder.InsertData(
           //table: "AspNetUsers"
           //, columns: new[] { "Id", "FirstName", "LastName", "EmailConfirmed", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnabled", "AccessFailedCount" }
           //, values: new object[] { Guid.NewGuid().ToString(), "Ali", "Gamal", false, false, false, false, 0 }
           //);
           // migrationBuilder.InsertData(
           //table: "AspNetUsers"
           //, columns: new[] { "Id", "FirstName", "LastName", "EmailConfirmed", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnabled", "AccessFailedCount" }
           //, values: new object[] { Guid.NewGuid().ToString(), "Abudallah", "hamdo", false, false, false, false, 0 }
           //);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
