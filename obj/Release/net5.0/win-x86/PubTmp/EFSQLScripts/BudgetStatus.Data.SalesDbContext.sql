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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912095612_migration2')
BEGIN
    CREATE TABLE [Bdgfixmonth] (
        [Counter] int NOT NULL IDENTITY,
        [Byear] int NOT NULL,
        [Bbudget] nvarchar(max) NULL,
        [Bmonth] int NOT NULL,
        [Blongmonth] nvarchar(max) NULL,
        [Closed] int NOT NULL,
        [Current] nvarchar(max) NULL,
        CONSTRAINT [PK_Bdgfixmonth] PRIMARY KEY ([Counter])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912095612_migration2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210912095612_migration2', N'5.0.9');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211031103750_hp')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Bdgfixmonth]') AND [c].[name] = N'Current');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Bdgfixmonth] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Bdgfixmonth] ALTER COLUMN [Current] nvarchar(max) NOT NULL;
    ALTER TABLE [Bdgfixmonth] ADD DEFAULT N'' FOR [Current];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211031103750_hp')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Bdgfixmonth]') AND [c].[name] = N'Blongmonth');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Bdgfixmonth] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Bdgfixmonth] ALTER COLUMN [Blongmonth] nvarchar(max) NOT NULL;
    ALTER TABLE [Bdgfixmonth] ADD DEFAULT N'' FOR [Blongmonth];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211031103750_hp')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Bdgfixmonth]') AND [c].[name] = N'Bbudget');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Bdgfixmonth] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Bdgfixmonth] ALTER COLUMN [Bbudget] nvarchar(max) NOT NULL;
    ALTER TABLE [Bdgfixmonth] ADD DEFAULT N'' FOR [Bbudget];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211031103750_hp')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211031103750_hp', N'5.0.9');
END;
GO

COMMIT;
GO

