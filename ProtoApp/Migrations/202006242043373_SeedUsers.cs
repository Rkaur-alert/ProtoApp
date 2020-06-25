namespace ProtoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"

            INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'2aaa76ae-70b1-421f-9bc4-c1c6f4df21ff', N'guest@protoapp.com', 0, N'AEUim1/7yitW+YxHfWzEfuNBhxPI9mXMOm0K1qBH7OzIolFbFKoUueH/TRwac3DD8w==', N'1d6d68aa-36b1-4861-95ae-0fdc5c8a1d06', NULL, 0, 0, NULL, 1, 0, N'guest@protoapp.com')
            INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'b04ac5da-37cc-46e1-aac7-046ca8be3cfa', N'admin@protoapp.com', 0, N'AFqtA4pOaafViTiZeOm7C+YL6kn+x3PY2+2wCwDDGjRUPjgd3kyjUapuj/h1hv4UOA==', N'82d0b2e1-d45f-4941-8c0c-138773cfe9e0', NULL, 0, 0, NULL, 1, 0, N'admin@protoapp.com')

            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'bf4ed337-9093-4c1a-a6fa-bd5e1624f616', N'CanManageMovies')

            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b04ac5da-37cc-46e1-aac7-046ca8be3cfa', N'bf4ed337-9093-4c1a-a6fa-bd5e1624f616')


                ");    
        }

        public override void Down()
        {
        }
    }
}
