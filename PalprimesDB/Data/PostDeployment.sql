/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
/*************************************************************************************
	RUN FIRST - ALL CHANGES BELOW THIS SCRIPT - FETCHES THE DATABASE VERSION
*************************************************************************************/
PRINT 'POST-------'
:r .\RunFirst.sql

/*************************************************************************************
	POST DEPLOYMENT REVISION SCRIPTS
*************************************************************************************/
:r .\1.0\PostDeployment.sql





/*************************************************************************************
	RUN LAST - ALL CHANGES ABOVE THIS SCRIPT - UPDATES THE DATABASE VERSION
*************************************************************************************/
:r .\RunLast.sql

PRINT 'DB Version ' + @DB_Version