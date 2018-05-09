



CREATE TABLE [dbo].[PaymentType] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Product] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (50) NOT NULL,
    [Price]         INT           NOT NULL,
    [IsPromational] BIT           NOT NULL,
    [FK_Category]   INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([FK_Category]) REFERENCES [dbo].[Category] ([Id])
);

CREATE TABLE [dbo].[Role] (
    [Id]   INT           NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Status] (
    [Id]   INT           NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[User] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (100) NOT NULL,
    [Password] NVARCHAR (50)  NOT NULL,
    [FK_Role]  INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([FK_Role]) REFERENCES [dbo].[Role] ([Id])
);
CREATE TABLE [dbo].[Order] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [Description]    NVARCHAR (500) NOT NULL,
    [Date]           DATETIME       NOT NULL,
    [DeliveryDate]   DATETIME       NULL,
    [Street]         NVARCHAR (100) NULL,
    [TotalPrice]     INT            NOT NULL,
    [CardMessage]    NVARCHAR (500) NULL,
    [FK_Customer]    INT            NOT NULL,
    [FK_PaymentType] INT            NULL,
    [FK_City]        INT            NULL,
    [FK_Status]      INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([FK_Customer]) REFERENCES [dbo].[Customer] ([Id]),
    FOREIGN KEY ([FK_PaymentType]) REFERENCES [dbo].[PaymentType] ([Id]),
    FOREIGN KEY ([FK_Status]) REFERENCES [dbo].[Status] ([Id]),
    FOREIGN KEY ([FK_City]) REFERENCES [dbo].[City] ([PostalCode])
);

CREATE TABLE [dbo].[OrderedProduct] (
    [FK_Order]   INT NOT NULL,
    [FK_Product] INT NOT NULL,
    [Quantity]   INT NOT NULL,
    FOREIGN KEY ([FK_Order]) REFERENCES [dbo].[Order] ([Id]),
    FOREIGN KEY ([FK_Product]) REFERENCES [dbo].[Product] ([Id])
);