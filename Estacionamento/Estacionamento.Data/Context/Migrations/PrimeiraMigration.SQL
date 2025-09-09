IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20250902011812_PrimeiraMigration')
BEGIN
    CREATE TABLE [Proprietario] (
        [Id] VARCHAR(50) NOT NULL,
        [Nome] VARCHAR(150) NOT NULL,
        [Cnh] BIGINT NOT NULL,
        [Telefone] CHAR(13) NOT NULL,
        [Celular] CHAR(13) NOT NULL,
        [Endereco] VARCHAR(200) NOT NULL,
        CONSTRAINT [PK_Proprietario] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20250902011812_PrimeiraMigration')
BEGIN
    CREATE TABLE [Veiculo] (
        [Id] VARCHAR(50) NOT NULL,
        [Marca] VARCHAR(25) NOT NULL,
        [Modelo] VARCHAR(50) NOT NULL,
        [Placa] CHAR(8) NOT NULL,
        [ProprietarioId] VARCHAR(50) NOT NULL,
        CONSTRAINT [PK_Veiculo] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Veiculo_Proprietario_ProprietarioId] FOREIGN KEY ([ProprietarioId]) REFERENCES [Proprietario] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20250902011812_PrimeiraMigration')
BEGIN
    CREATE INDEX [IX_Veiculo_ProprietarioId] ON [Veiculo] ([ProprietarioId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20250902011812_PrimeiraMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250902011812_PrimeiraMigration', N'3.1.32');
END;

GO

