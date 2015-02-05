CREATE TABLE dbo.Users (
    [Id] int NOT NULL identity(0,1) primary key,
    [UserName] varchar(50) NOT NULL,
	[Password] varbinary(255) NOT NULL,
	[SessionID] varchar(120) NULL
);
GO

-- Password hashing trigger
-- This trigger will automatically hash any password after insertion
CREATE TRIGGER HashPw
    ON dbo.Users
    FOR INSERT
    AS
	select HASHBYTES('SHA1', Password) from inserted

insert into Users(UserName, Password) values ('test', 123)