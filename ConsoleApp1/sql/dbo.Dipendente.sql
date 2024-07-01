CREATE TABLE [dbo].[Dipendente] (
    [IdDipendente]      INT          IDENTITY (1, 1) NOT NULL,
    [Nome]              NCHAR (40)   NOT NULL,
    [Cognome]           NCHAR (40)   NOT NULL,
    [CodiceFiscale]     CHAR (16)    NOT NULL,
    [FigliACarico]      INT          DEFAULT ((0)) NOT NULL,
    [Sposato]           BIT          DEFAULT ((0)) NOT NULL,
    [LivelloLavorativo] NCHAR (10)   NOT NULL,
    [Descrizione]       NCHAR (140)  NOT NULL,
    [Salario]           DECIMAL (18) DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([IdDipendente] ASC)
);

