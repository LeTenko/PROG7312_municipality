CREATE TABLE [dbo].[EventClicks] (
    [ClickID]   INT              IDENTITY (1, 1) NOT NULL,
    [EventID]   INT              NOT NULL,
    [UserID]    UNIQUEIDENTIFIER NOT NULL,
    [ClickTime] DATETIME         DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([ClickID] ASC),
    FOREIGN KEY ([EventID]) REFERENCES [dbo].[Events] ([EventID])
);

CREATE TABLE [dbo].[EventLikes] (
    [LikeID]   INT              IDENTITY (1, 1) NOT NULL,
    [EventID]  INT              NOT NULL,
    [UserID]   UNIQUEIDENTIFIER NOT NULL,
    [LikeTime] DATETIME         DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([LikeID] ASC),
    FOREIGN KEY ([EventID]) REFERENCES [dbo].[Events] ([EventID])
);