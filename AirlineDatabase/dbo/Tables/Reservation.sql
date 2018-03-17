CREATE TABLE [dbo].[Reservation] (
    [ReservationId]        INT            IDENTITY (1, 1) NOT NULL,
    [From]                 NVARCHAR (150) NULL,
    [Destination]          NVARCHAR (150) NULL,
    [DateFrom]             DATE           NULL,
    [DateTo]               DATE           NULL,
    [FlighType]            INT            NULL,
    [NoChildren]           INT            NULL,
    [CreatedOnDate]        DATETIME       NULL,
    [LastModifiedOnDate]   DATETIME       NULL,
    [CreatedByUserId]      NVARCHAR (128) NULL,
    [LastModifiedByUserId] NVARCHAR (128) NULL,
    [IsDeleted]            BIT            CONSTRAINT [DF_Reservation_IsDeleted] DEFAULT ((0)) NULL,
    CONSTRAINT [PK_Reservation] PRIMARY KEY CLUSTERED ([ReservationId] ASC)
);

