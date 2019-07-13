USE [DouDou]
GO

DROP TYPE [dbo].[Array]
GO

CREATE TYPE [dbo].[Array] AS TABLE(
	[value_str] [nvarchar](max) NULL,
	[value_int] [int]
)
GO



