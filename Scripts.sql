
--1)
CREATE DATABASE Prueba;
--2)
USE [Prueba]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 22/5/2023 12:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[nombres] [varchar](100) NULL,
	[apellidos] [varchar](100) NULL,
	[fechaNacimiento] [date] NULL,
	[cuit] [varchar](100) NULL,
	[domicilio] [varchar](200) NULL,
	[telefono] [varchar](100) NULL,
	[mail] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 
GO
INSERT [dbo].[Clientes] ([ID], [nombres], [apellidos], [fechaNacimiento], [cuit], [domicilio], [telefono], [mail]) VALUES (7, N'Nombre1', N'Apellido1', CAST(N'2000-03-02' AS Date), N'11-11111111-1', N'Domicilio1', N'(111)11111111', N'aaa@aaaa.com')
GO
INSERT [dbo].[Clientes] ([ID], [nombres], [apellidos], [fechaNacimiento], [cuit], [domicilio], [telefono], [mail]) VALUES (8, N'Nombre2', N'Apellido2', CAST(N'2023-05-15' AS Date), N'22-22222222-2', N'Domicilio2', N'(222)222222222', N'bbb@bbbbb.com')
GO
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
