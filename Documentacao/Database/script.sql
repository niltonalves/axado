USE [db_axado]
GO
/****** Object:  User [usr_axado]    Script Date: 12/04/2016 02:47:01 ******/
CREATE USER [usr_axado] FOR LOGIN [usr_axado] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [usr_axado]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 12/04/2016 02:47:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuarioCadastro] [int] NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Transportadora]    Script Date: 12/04/2016 02:47:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transportadora](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[IdUsuarioCadastro] [int] NULL,
	[RazaoSocial] [nvarchar](100) NOT NULL,
	[NomeFantasia] [nvarchar](50) NOT NULL,
	[CNPJ] [nvarchar](18) NOT NULL,
	[DataCadastro] [datetime] NOT NULL CONSTRAINT [DF_Transportadora_DataCadastro]  DEFAULT (getdate()),
 CONSTRAINT [PK_Transportadora] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 12/04/2016 02:47:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Senha] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Categoria]  WITH CHECK ADD  CONSTRAINT [FK_Categoria_Usuario] FOREIGN KEY([IdUsuarioCadastro])
REFERENCES [dbo].[Usuario] ([ID])
GO
ALTER TABLE [dbo].[Categoria] CHECK CONSTRAINT [FK_Categoria_Usuario]
GO
ALTER TABLE [dbo].[Transportadora]  WITH CHECK ADD  CONSTRAINT [FK_Transportadora_Categoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([ID])
GO
ALTER TABLE [dbo].[Transportadora] CHECK CONSTRAINT [FK_Transportadora_Categoria]
GO
ALTER TABLE [dbo].[Transportadora]  WITH CHECK ADD  CONSTRAINT [FK_Transportadora_Usuario] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Usuario] ([ID])
GO
ALTER TABLE [dbo].[Transportadora] CHECK CONSTRAINT [FK_Transportadora_Usuario]
GO
