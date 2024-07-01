CREATE TABLE [dbo].[Cliente] (
    [IdCliente]   INT           IDENTITY (1, 1) NOT NULL,
    [Nome]        NCHAR (30)    NOT NULL,
    [Cognome]     NCHAR (30)    NOT NULL,
    [DataNascita] DATETIME2 (7) NOT NULL,
    [Sesso]       CHAR (1)      NOT NULL,
    [CF]          CHAR (16)     NOT NULL,
    [P.IVA]       CHAR (11)     NOT NULL,
    [Attivo]      BIT           NOT NULL,
    [Saldo]       DECIMAL (18)  NOT NULL,
    PRIMARY KEY CLUSTERED ([IdCliente] ASC)
);

