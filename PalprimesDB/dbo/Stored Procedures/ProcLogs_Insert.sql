CREATE PROCEDURE [dbo].[ProcLogs_Insert]
  @log_date datetime2, 
  @log_thread varchar(50), 
  @log_level varchar(50), 
  @log_message varchar(4000), 
  @exception varchar(4000)
AS
BEGIN
	SET NOCOUNT ON;

  insert into dbo._Log ([Date], Thread, [Level], Logger, Exception)
  values (@log_date, @log_thread, @log_level, @log_message, @exception)

END
GO