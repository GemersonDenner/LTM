USE [LTM]
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tb_produto](
	[pro_idt_produto] [uniqueidentifier] NOT NULL,
	[pro_des_descricao] [nvarchar](max) NULL,
	[pro_des_especificacoes] [nvarchar](max) NULL,
	[pro_num_itens_estoque] [int] NOT NULL,
	[pro_des_nome] [nvarchar](max) NULL,
 CONSTRAINT [PK_tb_produto] PRIMARY KEY CLUSTERED 
(
	[pro_idt_produto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


USE [LTM]
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tb_usuario](
	[usr_idt_usuario] [uniqueidentifier] NOT NULL,
	[usr_des_email] [nvarchar](max) NULL,
	[usr_des_login] [nvarchar](max) NULL,
	[usr_des_nome] [nvarchar](max) NULL,
	[usr_des_password] [nvarchar](max) NULL,
 CONSTRAINT [PK_tb_usuario] PRIMARY KEY CLUSTERED 
(
	[usr_idt_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


