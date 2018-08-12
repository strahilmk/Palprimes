/*************************************************************************************
	QUERY DATABASE VERSION
*************************************************************************************/
DECLARE @DB_Version AS VARCHAR(20), @DB_CurrentVersion AS VARCHAR(20);

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ConfigurationSetting]') AND type in (N'U'))
BEGIN
	-- IS Database Seeded?
	DECLARE @DB_Seeded bit;
	SELECT TOP 1 @DB_Seeded = 1 FROM [dbo].[ConfigurationSetting];

	IF @DB_Seeded = 1
	BEGIN
		SELECT @DB_Version = VALUE FROM [dbo].[ConfigurationSetting]  WHERE [Category] = 'SYSTEM' AND [Name] = 'DB_Version';
		IF @DB_Version IS NULL SET @DB_Version = '1.0.1r1';
	END
	ELSE
	BEGIN
		SET @DB_Version = 'EMPTY';
	END
END
ELSE
BEGIN
	SET @DB_Version = 'EMPTY';
END
SET @DB_CurrentVersion = @DB_Version;