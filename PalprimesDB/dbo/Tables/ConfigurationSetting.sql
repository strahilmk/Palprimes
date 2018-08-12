CREATE TABLE [dbo].[ConfigurationSetting]
(
	[Id]           BIGINT           IDENTITY (1, 1) NOT NULL,
    [UniqueId]     UNIQUEIDENTIFIER CONSTRAINT [DF_configurationsetting_UniqueId] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [Category]     NVARCHAR (50)    NOT NULL,
    [Name]         NVARCHAR (50)    NOT NULL,
    [Value]        NVARCHAR (MAX)   NOT NULL,
    [Units]        NVARCHAR (MAX)   NULL,
    [Description]  NVARCHAR (MAX)   NULL,
    [IsActive]     BIT              NOT NULL,
    [IsDefault]    BIT              NOT NULL,
    [DisplayOrder] INT              NOT NULL,
    CONSTRAINT [PK_ConfigurationSetting] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UK_ConfigurationSetting] UNIQUE NONCLUSTERED ([UniqueId] ASC)
)
