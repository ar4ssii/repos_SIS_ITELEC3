namespace SIS_ITELEC3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsersViaSqlScript : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'64710687-9203-46ef-a225-fcc5f2f1ed07', N'registrar@hcc.com.ph', 0, N'AKvODWSOssYC/DTpbfZ9bgVf/IhNw5zldzZ+4G6SvoJhAiESSWCLwaO5l826aANjlQ==', N'cf11877d-fd48-4a28-a1b1-f1dc038980ec', NULL, 0, 0, NULL, 1, 0, N'registrar@hcc.com.ph')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'89960c9c-757a-4ddc-b639-29b215fc4d95', N'admin@hcc.com.ph', 0, N'AO/mVm1HMIKrtBgIxTqIRjUoJtRgXIfkmNDfu3/l5BZSifcksQX8Oqw/ZSR9bBpNKA==', N'2acfaba1-a691-4a59-8c13-1d6f7a936b63', NULL, 0, 0, NULL, 1, 0, N'admin@hcc.com.ph')

            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7791eebf-da9a-45ad-8325-03d2ae52d880', N'CanManageRole')

            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'89960c9c-757a-4ddc-b639-29b215fc4d95', N'7791eebf-da9a-45ad-8325-03d2ae52d880')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
