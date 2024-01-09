USE [DBEmpleado]
GO
/****** Object:  Table [dbo].[Area]    Script Date: 1/9/2024 12:19:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Area](
	[IdArea] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[FechaCreacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdArea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 1/9/2024 12:19:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[IdEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](50) NULL,
	[Apellidos] [varchar](50) NULL,
	[Tipo_Documento] [varchar](50) NULL,
	[NumeroDocumento] [varchar](50) NULL,
	[Fecha_Contrato] [datetime] NULL,
	[Pais] [varchar](50) NULL,
	[IdArea] [int] NULL,
	[IdSubarea] [int] NULL,
	[FechaCreacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pais]    Script Date: 1/9/2024 12:19:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pais](
	[IdPais] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPais] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subarea]    Script Date: 1/9/2024 12:19:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subarea](
	[IdSubarea] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[FechaCreacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdSubarea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Area] ON 
GO
INSERT [dbo].[Area] ([IdArea], [Nombre], [FechaCreacion]) VALUES (1, N'Gerencia', CAST(N'2024-01-07T00:55:32.833' AS DateTime))
GO
INSERT [dbo].[Area] ([IdArea], [Nombre], [FechaCreacion]) VALUES (2, N'Finanzas', CAST(N'2024-01-07T00:55:32.833' AS DateTime))
GO
INSERT [dbo].[Area] ([IdArea], [Nombre], [FechaCreacion]) VALUES (3, N'Salud', CAST(N'2024-01-07T00:55:32.833' AS DateTime))
GO
INSERT [dbo].[Area] ([IdArea], [Nombre], [FechaCreacion]) VALUES (4, N'Ciencias Sociales', CAST(N'2024-01-07T00:55:32.833' AS DateTime))
GO
INSERT [dbo].[Area] ([IdArea], [Nombre], [FechaCreacion]) VALUES (5, N'Ciencias Naturales', CAST(N'2024-01-07T00:55:32.833' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Area] OFF
GO
SET IDENTITY_INSERT [dbo].[Empleado] ON 
GO
INSERT [dbo].[Empleado] ([IdEmpleado], [Nombres], [Apellidos], [Tipo_Documento], [NumeroDocumento], [Fecha_Contrato], [Pais], [IdArea], [IdSubarea], [FechaCreacion]) VALUES (1, N'Luisa', N'Arboleda', N'Cédula', N'2345167', CAST(N'2024-01-07T12:21:29.147' AS DateTime), N'Colombia', 1, 1, CAST(N'2024-01-07T12:21:29.147' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Empleado] OFF
GO
SET IDENTITY_INSERT [dbo].[Pais] ON 
GO
INSERT [dbo].[Pais] ([IdPais], [Nombre]) VALUES (1, N'Colombia')
GO
INSERT [dbo].[Pais] ([IdPais], [Nombre]) VALUES (2, N'Argentina')
GO
INSERT [dbo].[Pais] ([IdPais], [Nombre]) VALUES (3, N'Venezuela')
GO
INSERT [dbo].[Pais] ([IdPais], [Nombre]) VALUES (4, N'Panamá')
GO
INSERT [dbo].[Pais] ([IdPais], [Nombre]) VALUES (5, N'Perú')
GO
SET IDENTITY_INSERT [dbo].[Pais] OFF
GO
SET IDENTITY_INSERT [dbo].[Subarea] ON 
GO
INSERT [dbo].[Subarea] ([IdSubarea], [Nombre], [FechaCreacion]) VALUES (1, N'Gerencia', CAST(N'2024-01-07T00:57:08.700' AS DateTime))
GO
INSERT [dbo].[Subarea] ([IdSubarea], [Nombre], [FechaCreacion]) VALUES (2, N'Planeación', CAST(N'2024-01-07T00:57:08.700' AS DateTime))
GO
INSERT [dbo].[Subarea] ([IdSubarea], [Nombre], [FechaCreacion]) VALUES (3, N'Salud Humana', CAST(N'2024-01-07T00:57:08.700' AS DateTime))
GO
INSERT [dbo].[Subarea] ([IdSubarea], [Nombre], [FechaCreacion]) VALUES (4, N'Servicio jurídico', CAST(N'2024-01-07T00:57:08.700' AS DateTime))
GO
INSERT [dbo].[Subarea] ([IdSubarea], [Nombre], [FechaCreacion]) VALUES (5, N'Correo y mensajería', CAST(N'2024-01-07T00:57:08.700' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Subarea] OFF
GO
ALTER TABLE [dbo].[Area] ADD  DEFAULT (getdate()) FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[Empleado] ADD  DEFAULT (getdate()) FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[Subarea] ADD  DEFAULT (getdate()) FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD FOREIGN KEY([IdArea])
REFERENCES [dbo].[Area] ([IdArea])
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD FOREIGN KEY([IdSubarea])
REFERENCES [dbo].[Subarea] ([IdSubarea])
GO
