/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
/*************************************************************************************
	RUN FIRST - ALL CHANGES BELOW THIS SCRIPT - FETCHES THE DATABASE VERSION
*************************************************************************************/
:r .\RunFirst.sql

PRINT 'DB Version ' + @DB_Version
/*
PRINT 'PRE-------'
IF (@DB_Version != 'EMPTY')
BEGIN

/*************************************************************************************
PRE DEPLOYMENT REVISION SCRIPTS
*************************************************************************************/
END
*/