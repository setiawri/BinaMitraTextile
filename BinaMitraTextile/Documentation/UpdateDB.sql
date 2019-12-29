CREATE TABLE [dbo].[Kontrabons]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [No] VARCHAR(MAX) NOT NULL, 
    [Amount] DECIMAL(12, 2) NOT NULL, 
    [Customers_Id] UNIQUEIDENTIFIER NOT NULL, 
    [Create_Timestamp] DATETIME NOT NULL, 
    [Sent_Timestamp] DATETIME NULL, 
    [DueDate] DATETIME NULL, 
    [FollowUpDate] DATETIME NULL,
    [Notes] VARCHAR(MAX) NULL
)
GO







