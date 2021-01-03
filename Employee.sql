CREATE TABLE [dbo].[Employee] (
    [Id]          INT           NOT NULL,
    [firstName]   VARCHAR (MAX) NULL,
    [lastName]    VARCHAR (MAX) NULL,
    [phoneNumber] VARCHAR (MAX) NULL,
    [emailId]     VARCHAR (MAX) NULL,
    [age]         INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


INSERT INTO [dbo].[Employee] ([Id], [firstName], [lastName], [phoneNumber], [emailId], [age]) VALUES (2, N'Barack', N'Obama', N'235235', N'barack.obama@gmail.com', 50)
INSERT INTO [dbo].[Employee] ([Id], [firstName], [lastName], [phoneNumber], [emailId], [age]) VALUES (3, N'Tim', N'Johns', N'34135', N'tim.johns@gmail.com', 30)
INSERT INTO [dbo].[Employee] ([Id], [firstName], [lastName], [phoneNumber], [emailId], [age]) VALUES (4, N'Jane', N'Daniels', N'8482656', N'jane.daniels@gmail.com', 45)
INSERT INTO [dbo].[Employee] ([Id], [firstName], [lastName], [phoneNumber], [emailId], [age]) VALUES (5, N'Liz', N'John', N'43664656', N'liz.john@gmail.com', 18)
INSERT INTO [dbo].[Employee] ([Id], [firstName], [lastName], [phoneNumber], [emailId], [age]) VALUES (6, N'test1', N'test1', N'123456789', N'test1@gmail.com', 6)
