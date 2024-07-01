CREATE TABLE [dbo].[Cantiere] (
    [IdCantiere]            INT           IDENTITY (1, 1) NOT NULL,
    [DenominazioneCantiere] NCHAR (10)    NOT NULL,
    [Indirizzo]             NCHAR (10)    NOT NULL,
    [Citta]                 NCHAR (10)    NOT NULL,
    [Cap]                   CHAR (5)      NOT NULL,
    [PersonaRifeimento]     NCHAR (100)   NOT NULL,
    [DataInizioLavori]      DATETIME2 (7) NOT NULL,
    [DataFineLavori]        DATETIME2 (7) NOT NULL,
    [LavoriTerminati]       BIT           NOT NULL,
    [Dipendente_FK]         INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([IdCantiere] ASC)
);

