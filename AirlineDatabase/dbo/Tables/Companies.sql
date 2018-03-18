CREATE TABLE [dbo].[Companies] (
    [Id]                   INT            IDENTITY (1, 1) NOT NULL,
    [Name]                 NVARCHAR (150) NOT NULL,
    [Description]          NVARCHAR (500) NULL,
    [CountryId]            INT            NULL,
    [CreatedOnDate]        DATETIME       NULL,
    [LastModifiedOnDate]   DATETIME       NULL,
    [CreatedByUserId]      NVARCHAR (128) NULL,
    [LastModifiedByUserId] NVARCHAR (128) NULL,
    [IsDeleted]            BIT            CONSTRAINT [DF_dbo.Companies_IsDeleted] DEFAULT ((0)) NULL,
    CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Companies_Country] FOREIGN KEY ([CountryId]) REFERENCES [dbo].[Country] ([CountryId])
);







