USE [master]
GO
/****** Object:  Database [Blog]    Script Date: 29/04/2022 7:03:58 p. m. ******/
CREATE DATABASE [Blog]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Blog', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Blog.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Blog_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Blog_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Blog] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Blog].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Blog] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Blog] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Blog] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Blog] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Blog] SET ARITHABORT OFF 
GO
ALTER DATABASE [Blog] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Blog] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Blog] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Blog] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Blog] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Blog] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Blog] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Blog] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Blog] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Blog] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Blog] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Blog] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Blog] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Blog] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Blog] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Blog] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Blog] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Blog] SET RECOVERY FULL 
GO
ALTER DATABASE [Blog] SET  MULTI_USER 
GO
ALTER DATABASE [Blog] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Blog] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Blog] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Blog] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Blog] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Blog', N'ON'
GO
ALTER DATABASE [Blog] SET QUERY_STORE = OFF
GO
USE [Blog]
GO
/****** Object:  User [prueba]    Script Date: 29/04/2022 7:03:59 p. m. ******/
CREATE USER [prueba] FOR LOGIN [prueba] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Asigna_Cliente]    Script Date: 29/04/2022 7:03:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asigna_Cliente](
	[ac_Identificacion] [varchar](20) NOT NULL,
	[ac_Numero_Patio] [int] NOT NULL,
	[ac_Fecha_Asignacion] [datetime] NOT NULL,
	[ac_ID_asigna_cliente] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Automovil]    Script Date: 29/04/2022 7:03:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Automovil](
	[au_Placa] [varchar](20) NOT NULL,
	[au_Modelo] [varchar](100) NOT NULL,
	[au_Numero_Chasis] [varchar](100) NOT NULL,
	[au_Codigo_Marca] [int] NOT NULL,
	[au_Tipo] [varchar](100) NULL,
	[au_Cilindraje] [decimal](18, 0) NOT NULL,
	[au_Avaluo] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[au_Placa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 29/04/2022 7:03:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[cl_Identificacion] [varchar](20) NOT NULL,
	[cl_Nombres] [varchar](255) NOT NULL,
	[cl_Edad] [int] NOT NULL,
	[cl_Fecha_Nacimiento] [datetime] NOT NULL,
	[cl_Apellidos] [varchar](255) NOT NULL,
	[cl_Direccion] [varchar](255) NOT NULL,
	[cl_Telefono] [varchar](20) NOT NULL,
	[cl_Estado_Civil] [varchar](50) NOT NULL,
	[cl_Identificacion_Conyuge] [varchar](20) NOT NULL,
	[cl_Nombre_Conyuge] [varchar](255) NOT NULL,
	[cl_Sujeto_Credito] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cl_Identificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ejecutivo]    Script Date: 29/04/2022 7:03:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ejecutivo](
	[e_Identificacion] [varchar](20) NOT NULL,
	[e_Nombres] [varchar](255) NOT NULL,
	[e_Apellidos] [varchar](255) NOT NULL,
	[e_Direccion] [varchar](255) NOT NULL,
	[e_Telefono_Convencional] [varchar](20) NOT NULL,
	[e_Celular] [varchar](20) NOT NULL,
	[e_Numero_Patio] [int] NOT NULL,
	[e_Edad] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[e_Identificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marca]    Script Date: 29/04/2022 7:03:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marca](
	[ma_Codigo] [int] IDENTITY(1,1) NOT NULL,
	[ma_Nombre_Marca] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patio_Autos]    Script Date: 29/04/2022 7:03:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patio_Autos](
	[pa_Numero_Patio] [int] IDENTITY(1,1) NOT NULL,
	[pa_Nombre] [varchar](255) NOT NULL,
	[pa_Direccion] [varchar](255) NOT NULL,
	[pa_Telefono] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[pa_Numero_Patio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Solicitud_Credito]    Script Date: 29/04/2022 7:03:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Solicitud_Credito](
	[sc_ID_Solicitud_Credito] [int] IDENTITY(1,1) NOT NULL,
	[sc_Fecha_Elaboracion] [datetime] NOT NULL,
	[sc_Identificacion_Cliente] [varchar](20) NOT NULL,
	[sc_Numero_Patio] [int] NOT NULL,
	[sc_Placa] [varchar](20) NOT NULL,
	[sc_Meses_Plazo] [int] NOT NULL,
	[sc_Cuotas] [int] NOT NULL,
	[sc_Entrada] [money] NOT NULL,
	[sc_Identificacion_Ejecutivo] [varchar](20) NOT NULL,
	[sc_Observacion] [varchar](255) NULL,
	[sc_Solicitud_activa] [bit] NULL,
	[sc_Estado_Solicitud] [varchar](255) NULL,
 CONSTRAINT [pk_history] PRIMARY KEY CLUSTERED 
(
	[sc_ID_Solicitud_Credito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Automovil] ([au_Placa], [au_Modelo], [au_Numero_Chasis], [au_Codigo_Marca], [au_Tipo], [au_Cilindraje], [au_Avaluo]) VALUES (N'PDG9335', N'string', N'ewf123', 1, N'sedan', CAST(1 AS Decimal(18, 0)), 10000.0000)
GO
INSERT [dbo].[Cliente] ([cl_Identificacion], [cl_Nombres], [cl_Edad], [cl_Fecha_Nacimiento], [cl_Apellidos], [cl_Direccion], [cl_Telefono], [cl_Estado_Civil], [cl_Identificacion_Conyuge], [cl_Nombre_Conyuge], [cl_Sujeto_Credito]) VALUES (N'1720477341', N'Nombre1', 23, CAST(N'1989-11-14T00:00:00.000' AS DateTime), N'apellido1', N'direccion1', N'0995691214', N'soltero', N'1720477346', N'NInguna', 1)
GO
INSERT [dbo].[Cliente] ([cl_Identificacion], [cl_Nombres], [cl_Edad], [cl_Fecha_Nacimiento], [cl_Apellidos], [cl_Direccion], [cl_Telefono], [cl_Estado_Civil], [cl_Identificacion_Conyuge], [cl_Nombre_Conyuge], [cl_Sujeto_Credito]) VALUES (N'1720477343', N'Edita', 23, CAST(N'1989-11-14T00:00:00.000' AS DateTime), N'apellido1', N'direccion1', N'0995691214', N'soltero', N'1720477346', N'NInguna', 1)
GO
INSERT [dbo].[Cliente] ([cl_Identificacion], [cl_Nombres], [cl_Edad], [cl_Fecha_Nacimiento], [cl_Apellidos], [cl_Direccion], [cl_Telefono], [cl_Estado_Civil], [cl_Identificacion_Conyuge], [cl_Nombre_Conyuge], [cl_Sujeto_Credito]) VALUES (N'1720477346', N'Eduardo Alfonso', 35, CAST(N'1986-11-14T00:00:00.000' AS DateTime), N'Araujo Escobar', N'San Antonio', N'0995691214', N'Casado', N'1720477346', N'Cinthia Navarrete', 1)
GO
INSERT [dbo].[Cliente] ([cl_Identificacion], [cl_Nombres], [cl_Edad], [cl_Fecha_Nacimiento], [cl_Apellidos], [cl_Direccion], [cl_Telefono], [cl_Estado_Civil], [cl_Identificacion_Conyuge], [cl_Nombre_Conyuge], [cl_Sujeto_Credito]) VALUES (N'1720477347', N'Eduardo Alfonso', 35, CAST(N'1986-11-14T00:00:00.000' AS DateTime), N' Araujo Escobar', N' San Antonio', N'0995691214', N'Casado', N'1720477346', N'Cinthia Navarrete', 1)
GO
INSERT [dbo].[Cliente] ([cl_Identificacion], [cl_Nombres], [cl_Edad], [cl_Fecha_Nacimiento], [cl_Apellidos], [cl_Direccion], [cl_Telefono], [cl_Estado_Civil], [cl_Identificacion_Conyuge], [cl_Nombre_Conyuge], [cl_Sujeto_Credito]) VALUES (N'1720477348', N'Eduardo Alfonso', 35, CAST(N'1986-11-14T00:00:00.000' AS DateTime), N' Araujo Escobar', N' San Antonio', N'0995691214', N'Casado', N'1720477346', N'Cinthia Navarrete', 1)
GO
INSERT [dbo].[Cliente] ([cl_Identificacion], [cl_Nombres], [cl_Edad], [cl_Fecha_Nacimiento], [cl_Apellidos], [cl_Direccion], [cl_Telefono], [cl_Estado_Civil], [cl_Identificacion_Conyuge], [cl_Nombre_Conyuge], [cl_Sujeto_Credito]) VALUES (N'1720477349', N'Eduardo Alfonso', 35, CAST(N'1986-11-14T00:00:00.000' AS DateTime), N' Araujo Escobar', N' San Antonio', N'0995691214', N'Casado', N'1720477346', N'Cinthia Navarrete', 1)
GO
INSERT [dbo].[Ejecutivo] ([e_Identificacion], [e_Nombres], [e_Apellidos], [e_Direccion], [e_Telefono_Convencional], [e_Celular], [e_Numero_Patio], [e_Edad]) VALUES (N'1720477349', N'Cristian', N'Benalcazar', N'Cumanda', N'022345345', N'099123123', 1, 23)
GO
SET IDENTITY_INSERT [dbo].[Marca] ON 
GO
INSERT [dbo].[Marca] ([ma_Codigo], [ma_Nombre_Marca]) VALUES (1, N'KIA')
GO
INSERT [dbo].[Marca] ([ma_Codigo], [ma_Nombre_Marca]) VALUES (2, N'TOYOTA')
GO
INSERT [dbo].[Marca] ([ma_Codigo], [ma_Nombre_Marca]) VALUES (3, N'MAZDA')
GO
SET IDENTITY_INSERT [dbo].[Marca] OFF
GO
SET IDENTITY_INSERT [dbo].[Patio_Autos] ON 
GO
INSERT [dbo].[Patio_Autos] ([pa_Numero_Patio], [pa_Nombre], [pa_Direccion], [pa_Telefono]) VALUES (1, N'Patio Amazonas', N'Amazonas y Pereira', N'022698601')
GO
SET IDENTITY_INSERT [dbo].[Patio_Autos] OFF
GO
SET IDENTITY_INSERT [dbo].[Solicitud_Credito] ON 
GO
INSERT [dbo].[Solicitud_Credito] ([sc_ID_Solicitud_Credito], [sc_Fecha_Elaboracion], [sc_Identificacion_Cliente], [sc_Numero_Patio], [sc_Placa], [sc_Meses_Plazo], [sc_Cuotas], [sc_Entrada], [sc_Identificacion_Ejecutivo], [sc_Observacion], [sc_Solicitud_activa], [sc_Estado_Solicitud]) VALUES (1, CAST(N'2022-04-29T00:00:00.000' AS DateTime), N'1720477346', 1, N'PDG9335', 36, 120, 100.0000, N'1720477349', N'Ninguna', 1, NULL)
GO
INSERT [dbo].[Solicitud_Credito] ([sc_ID_Solicitud_Credito], [sc_Fecha_Elaboracion], [sc_Identificacion_Cliente], [sc_Numero_Patio], [sc_Placa], [sc_Meses_Plazo], [sc_Cuotas], [sc_Entrada], [sc_Identificacion_Ejecutivo], [sc_Observacion], [sc_Solicitud_activa], [sc_Estado_Solicitud]) VALUES (2, CAST(N'2022-04-29T00:00:00.000' AS DateTime), N'1720477341', 1, N'PDG9335', 36, 120, 100.0000, N'1720477349', N'Ninguna', 1, N'Registrada')
GO
SET IDENTITY_INSERT [dbo].[Solicitud_Credito] OFF
GO
ALTER TABLE [dbo].[Asigna_Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Asignacion_Cliente] FOREIGN KEY([ac_Identificacion])
REFERENCES [dbo].[Cliente] ([cl_Identificacion])
GO
ALTER TABLE [dbo].[Asigna_Cliente] CHECK CONSTRAINT [FK_Asignacion_Cliente]
GO
ALTER TABLE [dbo].[Asigna_Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Asignacion_Patio] FOREIGN KEY([ac_Numero_Patio])
REFERENCES [dbo].[Patio_Autos] ([pa_Numero_Patio])
GO
ALTER TABLE [dbo].[Asigna_Cliente] CHECK CONSTRAINT [FK_Asignacion_Patio]
GO
ALTER TABLE [dbo].[Automovil]  WITH CHECK ADD  CONSTRAINT [FK_Automoil_Marca] FOREIGN KEY([au_Codigo_Marca])
REFERENCES [dbo].[Marca] ([ma_Codigo])
GO
ALTER TABLE [dbo].[Automovil] CHECK CONSTRAINT [FK_Automoil_Marca]
GO
ALTER TABLE [dbo].[Ejecutivo]  WITH CHECK ADD  CONSTRAINT [FK_Ejecutivo_Patio] FOREIGN KEY([e_Numero_Patio])
REFERENCES [dbo].[Patio_Autos] ([pa_Numero_Patio])
GO
ALTER TABLE [dbo].[Ejecutivo] CHECK CONSTRAINT [FK_Ejecutivo_Patio]
GO
ALTER TABLE [dbo].[Solicitud_Credito]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudCredito_Cliente] FOREIGN KEY([sc_Identificacion_Cliente])
REFERENCES [dbo].[Cliente] ([cl_Identificacion])
GO
ALTER TABLE [dbo].[Solicitud_Credito] CHECK CONSTRAINT [FK_SolicitudCredito_Cliente]
GO
ALTER TABLE [dbo].[Solicitud_Credito]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudCredito_Ejecutivo] FOREIGN KEY([sc_Identificacion_Ejecutivo])
REFERENCES [dbo].[Ejecutivo] ([e_Identificacion])
GO
ALTER TABLE [dbo].[Solicitud_Credito] CHECK CONSTRAINT [FK_SolicitudCredito_Ejecutivo]
GO
ALTER TABLE [dbo].[Solicitud_Credito]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudCredito_Patio] FOREIGN KEY([sc_Numero_Patio])
REFERENCES [dbo].[Patio_Autos] ([pa_Numero_Patio])
GO
ALTER TABLE [dbo].[Solicitud_Credito] CHECK CONSTRAINT [FK_SolicitudCredito_Patio]
GO
ALTER TABLE [dbo].[Solicitud_Credito]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudCredito_Vehiculo] FOREIGN KEY([sc_Placa])
REFERENCES [dbo].[Automovil] ([au_Placa])
GO
ALTER TABLE [dbo].[Solicitud_Credito] CHECK CONSTRAINT [FK_SolicitudCredito_Vehiculo]
GO
USE [master]
GO
ALTER DATABASE [Blog] SET  READ_WRITE 
GO
