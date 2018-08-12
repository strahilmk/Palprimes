CREATE TABLE [dbo].[DecimalNumber]
(
	[Id]          INT            IDENTITY (1, 1) NOT NULL,
	[UniqueId]    UNIQUEIDENTIFIER CONSTRAINT [DecimalNumber_UniqueId] DEFAULT (newid()) NOT NULL,
	[Value]       NVARCHAR (256)   NOT NULL,
    [IsPrime]	  BIT              DEFAULT ((0)) NOT NULL,
    [IsPalindrom] BIT              DEFAULT ((0)) NOT NULL,
    [CreateDate]  DATETIME2 (7)    CONSTRAINT [DecimalNumber_CreateDate] DEFAULT (getdate()) NOT NULL,
    [LastUpdate]  DATETIME2 (7)    CONSTRAINT [DecimalNumber_LastUpdate] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_DecimalNumber] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UK_DecimalNumber_Value] UNIQUE NONCLUSTERED ([Value] ASC)
);
