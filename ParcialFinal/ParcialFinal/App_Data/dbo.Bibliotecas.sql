CREATE TABLE [dbo].[Bibliotecas] (
    [ID_Libro]     INT            IDENTITY (1, 1) NOT NULL,
    [Titulo_Libro] NVARCHAR (255) NOT NULL,
    [Autor_Libro]  NVARCHAR (MAX) NOT NULL,
    [ISB_Libro]    INT            NOT NULL,
    CONSTRAINT [PK_dbo.Bibliotecas] PRIMARY KEY CLUSTERED ([ID_Libro] ASC)
);

