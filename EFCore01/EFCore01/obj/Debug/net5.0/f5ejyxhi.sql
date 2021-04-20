IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Employees] (
    [EmployrrId] int NOT NULL IDENTITY,
    [Name] varchar (225) NOT NULL,
    [PhoneNumber] varchar (12) NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY ([EmployrrId])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210419101010_initial', N'5.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[Employees].[EmployrrId]', N'EmployeeId', N'COLUMN';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210419101620_initial2', N'5.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Categories] (
    [CategoryId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([CategoryId])
);
GO

CREATE TABLE [Products] (
    [ProductId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [UnitPrice] nvarchar(max) NULL,
    [CategoryId] nvarchar(max) NULL,
    [CategoryId1] int NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([ProductId]),
    CONSTRAINT [FK_Products_Categories_CategoryId1] FOREIGN KEY ([CategoryId1]) REFERENCES [Categories] ([CategoryId]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_Products_CategoryId1] ON [Products] ([CategoryId1]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210419110611_newDbTables', N'5.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Products] DROP CONSTRAINT [FK_Products_Categories_CategoryId1];
GO

DROP INDEX [IX_Products_CategoryId1] ON [Products];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Products]') AND [c].[name] = N'CategoryId1');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Products] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Products] DROP COLUMN [CategoryId1];
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Products]') AND [c].[name] = N'CategoryId');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Products] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Products] ALTER COLUMN [CategoryId] int NOT NULL;
ALTER TABLE [Products] ADD DEFAULT 0 FOR [CategoryId];
GO

CREATE INDEX [IX_Products_CategoryId] ON [Products] ([CategoryId]);
GO

ALTER TABLE [Products] ADD CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([CategoryId]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210419111748_tableChanges', N'5.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [BCategory] (
    [CategoryId] int NOT NULL IDENTITY,
    [Name] varchar (50) NOT NULL,
    [RowVersion] rowversion NULL,
    CONSTRAINT [PK_BCategory] PRIMARY KEY ([CategoryId])
);
GO

CREATE TABLE [Books] (
    [BookId] int NOT NULL,
    [Name] varchar (50) NOT NULL,
    [Cid] int NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY ([BookId]),
    CONSTRAINT [FK_Books_BCategory_Cid] FOREIGN KEY ([Cid]) REFERENCES [BCategory] ([CategoryId]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Books_Cid] ON [Books] ([Cid]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210419144251_DataAnotations', N'5.0.5');
GO

COMMIT;
GO

