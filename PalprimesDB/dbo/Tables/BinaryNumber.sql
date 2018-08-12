CREATE TABLE [dbo].[BinaryNumber]
(
	[Id]          INT            IDENTITY (1, 1) NOT NULL,
	[UniqueId]    UNIQUEIDENTIFIER CONSTRAINT [BinaryNumber_UniqueId] DEFAULT (newid()) NOT NULL,
	[Value]       NVARCHAR (256)   NOT NULL,
    [IsPrime]	  BIT              DEFAULT ((0)) NOT NULL,
    [IsPalindrom] BIT              DEFAULT ((0)) NOT NULL,
    [CreateDate]  DATETIME2 (7)    CONSTRAINT [BinaryNumber_CreateDate] DEFAULT (getdate()) NOT NULL,
    [LastUpdate]  DATETIME2 (7)    CONSTRAINT [BinaryNumber_LastUpdate] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_BinaryNumber] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UK_BinaryNumber_Value] UNIQUE NONCLUSTERED ([Value] ASC)
)
