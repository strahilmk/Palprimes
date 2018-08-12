/*************************************************************************************
	RUN LAST - ALL CHANGES ABOVE THIS SCRIPT - UPDATES THE DATABASE VERSIONING
*************************************************************************************/
IF NOT @DB_CurrentVersion = @DB_Version
	BEGIN
		PRINT 'SETTING DATABASE VERSION "' + @DB_CurrentVersion + '" TO "' + @DB_Version + '"';
		-- UPDATES OR SETS THE DB_Version
		IF NOT EXISTS (SELECT 0 FROM [dbo].[ConfigurationSetting]  WHERE [Category] = 'SYSTEM' AND [Name] = 'DB_Version')
			BEGIN
				INSERT INTO [dbo].[ConfigurationSetting]  
					([Category], [Name], [Value], [Units], [Description], [IsActive], [IsDefault], [DisplayOrder]) 
				VALUES 
					('SYSTEM', 'DB_Version', @DB_Version, 'Version', 'Database Version Tracking', 1, 1, 0)
			END
		ELSE
			BEGIN
				UPDATE [dbo].[ConfigurationSetting] 
				SET [Value] = @DB_Version
				WHERE [Category] = 'SYSTEM' AND [Name] = 'DB_Version'
			END

		-- UPDATES OR SETS THE DB_Version_Date
		IF NOT EXISTS (SELECT * FROM [dbo].[ConfigurationSetting]  WHERE [Category] = 'SYSTEM' AND [Name] = 'DB_Version_Date')
			BEGIN
				INSERT INTO [dbo].[ConfigurationSetting]  
					([Category], [Name], [Value], [Units], [Description], [IsActive], [IsDefault], [DisplayOrder]) 
				VALUES 
					('SYSTEM', 'DB_Version_Date', convert(varchar, getdate(), 120), 'Date', 'Database Version Tracking', 1, 1, 0)
			END
		ELSE
			BEGIN
				UPDATE [dbo].[ConfigurationSetting] 
				SET [Value] = convert(varchar, getdate(), 120)
				WHERE [Category] = 'SYSTEM' AND [Name] = 'DB_Version_Date'
			END

		-- LOG THE UPDATE
		INSERT INTO [dbo].[_Log]
			([Date], [Level], [Logger], [Message], [Exception], [Thread])
		VALUES
			(GETDATE(), 'INFO', 'DEPLOYMENT', 'UPDATED DATABASE VERSION "' + @DB_CurrentVersion + '" TO "' + @DB_Version + '"', '', 'DACPAC')
	END