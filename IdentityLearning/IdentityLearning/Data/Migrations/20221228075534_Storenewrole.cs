using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityLearning.Data.Migrations
{
    public partial class Storenewrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert INTO [dbo].[AspNetUserRoles](UserId,RoleId) SELECT 'a26d14fc-5c30-435d-be93-d907df36f674',Id FROM [dbo].[AspNetRoles] ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FORM [dbo].[AspNetUserRoles] WHERE UserId='a26d14fc-5c30-435d-be93-d907df36f674'");
        }
    }
}
