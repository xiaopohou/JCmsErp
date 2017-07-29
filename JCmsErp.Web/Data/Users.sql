

IF EXISTS ( SELECT  *
            FROM    dbo.sysobjects
            WHERE   id = OBJECT_ID(N'[dbo].[Users]')
                    AND OBJECTPROPERTY(id, N'IsTable') = 1 )
    DROP TABLE [dbo].[Users];
CREATE TABLE [dbo].[Users]
    (
      [Id] [INT] IDENTITY(1, 1)
                 NOT NULL ,
      [UserName] [NVARCHAR](20) NOT NULL ,
      [Password] [NVARCHAR](32) NOT NULL ,
      [Email] [NVARCHAR](50) NOT NULL ,
      [Phone] [NVARCHAR](50) NULL ,
      [Address] [NVARCHAR](300) NULL ,
      [UpdateDate] [DATETIME] NOT NULL ,
      [TrueName] [NVARCHAR](20) NOT NULL ,
      [Enabled] [BIT] NOT NULL,
	);