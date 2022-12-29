using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityLearning.Data.Migrations
{
    public partial class StoredUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirtName], [Picture], [SecoundName]) VALUES (N'a26d14fc-5c30-435d-be93-d907df36f674', N'khaledhelwane2@gmail.com', N'KHALEDHELWANE2@GMAIL.COM', N'khaledhelwane2@gmail.com', N'KHALEDHELWANE2@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEJV+UaR1/mpz5+coWWc9y3dfF6w21qwx4esZp1nCiHd9Ypos9cQgbyqLeOuroD/vVw==', N'HIQ6P7MTC5WBB673433RH7IEGWVEF2YH', N'bf42554d-b72e-4695-9897-2ab23ad89850', NULL, 0, 0, NULL, 1, 0, N'khaledadmin', null, N'helwane')\r\n");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete From [dbo].[AspNetUsers] where id='a26d14fc-5c30-435d-be93-d907df36f674'");
        }
    }
}
