CREATE TABLE [dbo].[userdata] (
    [Id]       INT           NOT NULL IDENTITY(1, 1) ,
    [username] NVARCHAR (MAX) NULL,
    [password] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

