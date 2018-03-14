CREATE TABLE [dbo].[Cities] (
    [CityId]               INT            IDENTITY (1, 1) NOT NULL,
    [Name]                 NVARCHAR (150) NOT NULL,
    [Airport Name]         NVARCHAR (250) NULL,
    [Country]              NVARCHAR (150) NOT NULL,
    [CreatedOnDate]        DATETIME       NULL,
    [LastModifiedOnDate]   DATETIME       NULL,
    [CreatedByUserId]      NVARCHAR (128) NULL,
    [LastModifiedByUserId] NVARCHAR (128) NULL,
    [IsDeleted]            BIT            CONSTRAINT [DF_Cities_IsDeleted] DEFAULT ((0)) NULL,
    CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED ([CityId] ASC)
);



