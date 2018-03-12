CREATE TABLE [dbo].[Flights] (
    [FlightId]             INT            IDENTITY (1, 1) NOT NULL,
    [Flight Nr]            NVARCHAR (50)  NULL,
    [From]                 NVARCHAR (150) NULL,
    [To]                   NVARCHAR (150) NULL,
    [ArriveTime]           DATETIME       NULL,
    [ExpectedTime]         DATETIME       NULL,
    [StatusId]             INT            NOT NULL,
    [CompanyId]            INT            NOT NULL,
    [FlightType]           NVARCHAR (50)  NULL,
    [CreatedOnDate]        DATETIME       NULL,
    [LastModifiedOnDate]   DATETIME       NULL,
    [CreatedByUserId]      NVARCHAR (128) NULL,
    [LastModifiedByUserId] NVARCHAR (128) NULL,
    [IsDeleted]            BIT            CONSTRAINT [DF_Flights_IsDeleted] DEFAULT ((0)) NULL,
    CONSTRAINT [PK_Flights] PRIMARY KEY CLUSTERED ([FlightId] ASC),
    CONSTRAINT [FK_Flights_Companies] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Companies] ([Id]),
    CONSTRAINT [FK_Flights_Statuses] FOREIGN KEY ([StatusId]) REFERENCES [dbo].[Statuses] ([StatusId])
);

