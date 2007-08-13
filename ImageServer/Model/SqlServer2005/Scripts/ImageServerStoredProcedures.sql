USE [ImageServer]
GO
/****** Object:  StoredProcedure [dbo].[ReadSopClasses]    Script Date: 08/13/2007 17:47:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Steve Wranovsky
-- Create date: August 13, 2007
-- Description:	Procedure for returning all SopClasses supported by the server
-- =============================================
CREATE PROCEDURE [dbo].[ReadSopClasses] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from SopClass
END
GO
/****** Object:  StoredProcedure [dbo].[ReadFilesystemTiers]    Script Date: 08/13/2007 17:47:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Steve Wranovsky
-- Create date: 7/30/2007
-- Description:	Return the FilesystemTier table entries
-- =============================================
CREATE PROCEDURE [dbo].[ReadFilesystemTiers] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT GUID, Description, TierId from FilesystemTier;
END
GO
/****** Object:  StoredProcedure [dbo].[SelectStudyStorageLocation]    Script Date: 08/13/2007 17:47:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Steve Wranovsky
-- Create date: 7/30/2007
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[SelectStudyStorageLocation] 
	-- Add the parameters for the stored procedure here
	@ServerPartitionGUID uniqueidentifier, 
	@StudyInstanceUid varchar(64) 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT  StudyStorage.StudyInstanceUid, StudyStorage.ServerPartitionGUID, StudyStorage.LastAccessedTime, StudyStorage.StatusEnum,
			Filesystem.FilesystemPath, ServerPartition.PartitionFolder, StorageFilesystem.StudyFolder, Filesystem.Enabled, Filesystem.ReadOnly, Filesystem.WriteOnly
		FROM StudyStorage
		JOIN ServerPartition on StudyStorage.ServerPartitionGUID = ServerPartition.GUID
		JOIN StorageFilesystem on StudyStorage.GUID = StorageFilesystem.StudyStorageGUID
		JOIN Filesystem on StorageFilesystem.FilesystemGUID = Filesystem.GUID
		WHERE StudyStorage.ServerPartitionGuid = @ServerPartitionGUID and StudyStorage.StudyInstanceUid = @StudyInstanceUid
END
GO
/****** Object:  StoredProcedure [dbo].[ReadServerPartitions]    Script Date: 08/13/2007 17:47:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Steve Wranovsky
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[ReadServerPartitions] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT GUID, Enabled, Description, AeTitle, Port, PartitionFolder from ServerPartition
END
GO
/****** Object:  StoredProcedure [dbo].[InsertServerPartition]    Script Date: 08/13/2007 17:47:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Steve Wranovsky
-- Create date: August 13, 2007
-- Description:	Insert a ServerPartition row
-- =============================================
CREATE PROCEDURE [dbo].[InsertServerPartition] 
	-- Add the parameters for the stored procedure here
	@Enabled bit, 
	@Description nvarchar(128),
	@AeTitle varchar(16),
	@Port int,
	@PartitionFolder nvarchar(16)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @SopClassGUID uniqueidentifier
	DECLARE @ServerPartitionGUID uniqueidentifier

	SET @ServerPartitionGUID = newid()

    -- Insert statements for procedure here
	INSERT INTO [ImageServer].[dbo].[ServerPartition] 
		([GUID],[Enabled],[Description],[AeTitle],[Port],[PartitionFolder])
	VALUES (@ServerPartitionGUID, @Enabled, @Description, @AeTitle, @Port, @PartitionFolder)


	DECLARE cur_sopclass CURSOR FOR 
		SELECT GUID FROM SopClass;

	OPEN cur_sopclass;

	FETCH NEXT FROM cur_sopclass INTO @SopClassGUID;
	WHILE @@FETCH_STATUS = 0
	BEGIN
		INSERT INTO [ImageServer].[dbo].[PartitionSopClass]
			([GUID],[ServerPartitionGUID],[SopClassGUID],[Enabled])
		VALUES (newid(), @ServerPartitionGUID, @SopClassGUID, 1)

		FETCH NEXT FROM cur_sopclass INTO @SopClassGUID;	
	END 

	CLOSE cur_sopclass;
	DEALLOCATE cur_sopclass;

	SELECT GUID, Enabled, Description, AeTitle, Port, PartitionFolder from ServerPartition

END
GO
/****** Object:  StoredProcedure [dbo].[ReadFilesystems]    Script Date: 08/13/2007 17:47:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Steve Wranovsky
-- Create date: 7/20/2007
-- Description:	This procedure retrieves all rows in the Filesystem table
-- =============================================
CREATE PROCEDURE [dbo].[ReadFilesystems] 
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT GUID, FilesystemTierGUID as FilesystemTierRef, FilesystemPath, Enabled, ReadOnly, WriteOnly, Description from Filesystem
END
GO
/****** Object:  StoredProcedure [dbo].[SelectServerPartitionSopClasses]    Script Date: 08/13/2007 17:47:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Steve Wranovsky
-- Create date: August 13, 2007
-- Description:	Select all the SOP Classes for a Partition
-- =============================================
CREATE PROCEDURE [dbo].[SelectServerPartitionSopClasses] 
	-- Add the parameters for the stored procedure here
	@ServerPartitionGUID uniqueidentifier 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT	PartitionSopClass.GUID,
			PartitionSopClass.ServerPartitionGUID, 
			PartitionSopClass.SopClassGUID,
			PartitionSopClass.Enabled,
			SopClass.SopClassUid,
			SopClass.Description,
			SopClass.NonImage
	FROM PartitionSopClass
	JOIN SopClass on PartitionSopClass.SopClassGUID = SopClass.GUID
	WHERE PartitionSopClass.ServerPartitionGUID = @ServerPartitionGUID
END
GO
/****** Object:  StoredProcedure [dbo].[InsertStudyStorage]    Script Date: 08/13/2007 17:47:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Steve Wranovsky
-- Create date: 7/30/2007
-- Description:	Called when a new study is received.
-- =============================================
CREATE PROCEDURE [dbo].[InsertStudyStorage] 
	-- Add the parameters for the stored procedure here
	@ServerPartitionGUID uniqueidentifier, 
	@StudyInstanceUid varchar(64),
	@FilesystemGUID uniqueidentifier,
	@Folder varchar(8),
	@ExpirationTime datetime,
	@ScheduledTime datetime 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @StudyStorageGUID as uniqueidentifier
	declare @WorkQueueGUID as uniqueidentifier
	declare @StorageFilesystemFolder as varchar(8)

	declare @OnlineStatusEnum as int
	declare @PendingStatusEnum as int
	declare @StudyProcessTypeEnum as int

	select @OnlineStatusEnum = StatusEnum from StatusEnum where Lookup = 'Online'
	select @PendingStatusEnum = StatusEnum from StatusEnum where Lookup = 'Pending'
	select @StudyProcessTypeEnum = TypeEnum from TypeEnum where Lookup = 'StudyProcess'


    -- Check for Insert into StudyStorageGUID
	SELECT @StudyStorageGUID = StudyStorage.GUID, @StorageFilesystemFolder = StorageFilesystem.StudyFolder from StudyStorage
		JOIN StorageFilesystem ON StudyStorage.GUID = StorageFilesystem.StudyStorageGUID 
		where ServerPartitionGUID = @ServerPartitionGUID and StudyInstanceUid = @StudyInstanceUid;
	if @@ROWCOUNT = 0
	BEGIN
		set @StudyStorageGUID = NEWID()
		set @StorageFilesystemFolder = @Folder

		INSERT into StudyStorage(GUID, ServerPartitionGUID, StudyInstanceUid, Lock, StatusEnum) 
			values (@StudyStorageGUID, @ServerPartitionGUID, @StudyInstanceUid, 0, @PendingStatusEnum)

		INSERT into StorageFilesystem(StudyStorageGUID, FilesystemGUID, StudyFolder)
			values (@StudyStorageGUID, @FilesystemGUID, @StorageFilesystemFolder)
	END

	-- Finally check the WorkQueue
	SELECT @WorkQueueGUID = GUID from WorkQueue 
		where StudyStorageGUID = @StudyStorageGUID
	if @@ROWCOUNT = 0
	BEGIN
		set @WorkQueueGUID = NEWID();

		INSERT into WorkQueue (GUID, StudyStorageGUID, TypeEnum, StatusEnum, ExpirationTime, ScheduledTime)
			values  (@WorkQueueGUID, @StudyStorageGUID, @StudyProcessTypeEnum, @PendingStatusEnum, @ExpirationTime, @ScheduledTime)
	END
	ELSE
	BEGIN
		UPDATE WorkQueue set ExpirationTime = @ExpirationTime, ScheduledTime = @ScheduledTime
			where GUID = @WorkQueueGUID
	END

	declare @RC int

	EXECUTE @RC = [ImageServer].[dbo].[SelectStudyStorageLocation] 
		@ServerPartitionGUID,@StudyInstanceUid
END
GO
