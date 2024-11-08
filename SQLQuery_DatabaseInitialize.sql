-- Create User Table
CREATE TABLE [dbo].[User] (
    [Id]        UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Username]  NVARCHAR(50)     NOT NULL,
    [Password]  NVARCHAR(100)    NOT NULL,
    [FirstName] NVARCHAR(50)     NOT NULL,
    [LastName]  NVARCHAR(50)     NOT NULL,
    [Email]     NVARCHAR(100)    NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Username] ASC),
    UNIQUE NONCLUSTERED ([Email] ASC)
);

-- Create Report Table
CREATE TABLE [dbo].[Report] (
    [Id]          UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Location]    NVARCHAR(100)    NULL,
    [Description] NVARCHAR(500)    NULL,
    [Category]    NVARCHAR(50)     NULL,
    [FilePath]    NVARCHAR(255)    NULL,
    [CreatedAt]   DATETIME         DEFAULT (getdate()) NULL,
    [UserId]      UNIQUEIDENTIFIER NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

-- Insert initial data into User table
INSERT INTO [dbo].[User] (Username, Password, FirstName, LastName, Email)
VALUES 
('Admin', 'AdminPass123', 'Admin', 'User', 'admin@example.com'),
('user1', 'User1Pass123', 'First1', 'Last1', 'user1@example.com'),
('user2', 'User2Pass123', 'First2', 'Last2', 'user2@example.com'),
('user3', 'User3Pass123', 'First3', 'Last3', 'user3@example.com');