-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectWOL]
    (
      @UserId INT ,
      @PageSize INT = 10 ,
      @StartRecord INT = 1 ,
      @OrderBy NVARCHAR(20) = 'WOLID' ,
      @WOLName NVARCHAR(50)
    )
AS 
    BEGIN
        DECLARE @TotalRecords INT

        DECLARE @EndRecord INT   
        IF ( ISNULL(@OrderBy, '') = '' ) 
            BEGIN
                SET @OrderBy = 'WOLID'
            END  



        SET @StartRecord = @StartRecord + 1
        SET @EndRecord = @StartRecord + @PageSize - 1   
        


        CREATE TABLE #Res_OrderBy
            (
              RowID BIGINT ,
              [WOLID] [int] ,
              [UserId] [int] ,
              [WOLName] [nvarchar](50) ,
              [MACAddress] [nvarchar](20) ,
              [SubnetMask] [nvarchar](20) ,
              [HostName] [nvarchar](50) ,
              [Port] [int] ,
              [Protocol] [nvarchar](20) ,
              TotalRecords INT
            )

    --Main Query
   
        SELECT  --ROW_NUMBER() OVER ( ORDER BY [WOLID] ) AS RowID ,
                [WOLID] ,
                [UserId] ,
                [WOLName] ,
                [MACAddress] ,
                [SubnetMask] ,
                [HostName] ,
                [Port] ,
                [Protocol] ,
                COUNT(*) OVER ( PARTITION BY WOL.UserId ) AS TotalRecords
        INTO    #Res
        FROM    dbo.WOL WOL
        WHERE   UserId = @UserId
                AND ( ISNULL(@WOLName, '') = ''
                      OR WOLName LIKE '%' + @WOLName + '%'
                    )
 


        DECLARE @SQL NVARCHAR(MAX) = 'INSERT INTO #Res_OrderBy SELECT 
		ROW_NUMBER() OVER ( ORDER BY @OrderBy ) AS RowID,
		*  FROM  #Res'
        SET @SQL = REPLACE(@SQL, '@OrderBy', @OrderBy)
        EXECUTE(@SQL)




        SELECT  *
        FROM    #Res_OrderBy
        WHERE   RowID BETWEEN @StartRecord AND @EndRecord


	   
        DROP TABLE #Res_OrderBy
        DROP TABLE #Res
    END