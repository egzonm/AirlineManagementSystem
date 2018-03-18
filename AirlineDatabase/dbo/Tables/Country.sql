CREATE TABLE [dbo].[Country] (
    [CountryId]            INT            IDENTITY (1, 1) NOT NULL,
    [Name]                 NVARCHAR (150) NOT NULL,
    [Description]          NVARCHAR (250) NULL,
    [CreatedOnDate]        DATETIME       NULL,
    [LastModifiedOnDate]   DATETIME       NULL,
    [CreatedByUserId]      NVARCHAR (128) NULL,
    [LastModifiedByUserId] NVARCHAR (128) NULL,
    [IsDeleted]            BIT            CONSTRAINT [DF_Country_IsDeleted] DEFAULT ((0)) NULL,
    CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED ([CountryId] ASC)
);

