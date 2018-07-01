namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5eed6a45-0653-4cb6-8623-d4c4adea1c60', N'user1@vidly.com', 0, N'AEb5s5PaszjsOS4gRNJNdl5Q4Pvnbt9afjEl8RlVXHctzzU6WzaYn2ddHGWkbG8LXw==', N'96d55414-5321-4076-92cf-da71238988b3', NULL, 0, 0, NULL, 1, 0, N'user1@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'97635f42-5ba6-4717-8c79-3eaea0ddcd2e', N'manager@vidly.com', 0, N'AF7CbZNs1vpojpLYd5XY66er2/bXrgb+kFKuGhn7rVlq5gOX1ER3EYP5X94HMTz/IA==', N'd51a470c-fc90-4a55-bb4a-ce9b37be5448', NULL, 0, 0, NULL, 1, 0, N'manager@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e3340875-a254-4bdb-9525-bff160452b3e', N'guest@vidly.com', 0, N'AFMHuYwffsZnEYx44MNjI/6PZCLyI3RC3rw0CZ6QN45keYBgYZCYp0h5kkVxkFmZLg==', N'd01448ba-0a85-41a9-a679-c7dd960aef0a', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'162ee445-5984-4975-96c5-7ba8a99708a1', N'CanManageMovies')
        
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'97635f42-5ba6-4717-8c79-3eaea0ddcd2e', N'162ee445-5984-4975-96c5-7ba8a99708a1')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
