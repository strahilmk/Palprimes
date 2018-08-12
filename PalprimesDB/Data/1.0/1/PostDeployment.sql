/*************************************************************************************
	PostDeployment Script
	REVISION VERSION:	1.0.1r1
	UPDATES VERSION:	EMPTY
	SCRIPT PURPOSE:		Seeds Database
*************************************************************************************/
IF @DB_Version = 'EMPTY'
BEGIN

	:r .\PostDeployment\insert_number.sql
	

	SET @DB_Version = '1.0.1r1';
END