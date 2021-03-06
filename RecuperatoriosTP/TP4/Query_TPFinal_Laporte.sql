CREATE DATABASE [FARMACIA_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FARMACIA_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\FARMACIA_DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FARMACIA_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\FARMACIA_DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [FARMACIA_DB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FARMACIA_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FARMACIA_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FARMACIA_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FARMACIA_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FARMACIA_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FARMACIA_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [FARMACIA_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FARMACIA_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FARMACIA_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FARMACIA_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FARMACIA_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FARMACIA_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FARMACIA_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FARMACIA_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FARMACIA_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FARMACIA_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FARMACIA_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FARMACIA_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FARMACIA_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FARMACIA_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FARMACIA_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FARMACIA_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FARMACIA_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FARMACIA_DB] SET RECOVERY FULL 
GO
ALTER DATABASE [FARMACIA_DB] SET  MULTI_USER 
GO
ALTER DATABASE [FARMACIA_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FARMACIA_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FARMACIA_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FARMACIA_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FARMACIA_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FARMACIA_DB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'FARMACIA_DB', N'ON'
GO
ALTER DATABASE [FARMACIA_DB] SET QUERY_STORE = OFF
GO
USE [FARMACIA_DB]
GO
/****** Object:  Table [dbo].[carrito]    Script Date: 10/7/2022 17:12:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [FARMACIA_DB].[dbo].[carrito](
	[id_venta] [int] NOT NULL,
	[id_producto] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[clientes]    Script Date: 10/7/2022 17:12:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [FARMACIA_DB].[dbo].[clientes](
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[telefono] [varchar](15) NOT NULL,
	[dni] [int] NOT NULL,
	[debe] [float] NOT NULL,
 CONSTRAINT [PK_clientes] PRIMARY KEY CLUSTERED 
(
	[dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[productos]    Script Date: 10/7/2022 17:12:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [FARMACIA_DB].[dbo].[productos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](100) NOT NULL,
	[precio] [float] NOT NULL,
	[tipo] [int] NOT NULL,
	[cc] [int] NULL,
	[mg] [int] NULL,
	[uso] [int] NULL,
 CONSTRAINT [PK_productos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ventas]    Script Date: 10/7/2022 17:12:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [FARMACIA_DB].[dbo].[ventas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[precio] [float] NOT NULL,
	[senia] [float] NOT NULL,
	[dniCliente] [int] NOT NULL,
 CONSTRAINT [PK_ventas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[clientes] ADD  CONSTRAINT [DF_clientes_debe]  DEFAULT ((0)) FOR [debe]
GO
ALTER TABLE [dbo].[carrito]  WITH CHECK ADD  CONSTRAINT [FK_carrito_productos] FOREIGN KEY([id_producto])
REFERENCES [dbo].[productos] ([id])
GO
ALTER TABLE [dbo].[carrito] CHECK CONSTRAINT [FK_carrito_productos]
GO
ALTER TABLE [dbo].[clientes]  WITH CHECK ADD  CONSTRAINT [CK_clientes_debe] CHECK  (([debe]>=(0)))
GO
ALTER TABLE [dbo].[clientes] CHECK CONSTRAINT [CK_clientes_debe]
GO
ALTER TABLE [dbo].[productos]  WITH CHECK ADD  CONSTRAINT [CK_productos_medidas] CHECK  ((([tipo]=(0) AND [mg]>(0) AND [cc]=NULL) OR ([tipo]=(1) AND [cc]>(0) AND [mg]=NULL) OR ([tipo]=(2) AND [mg]=NULL AND [cc]=NULL AND [uso]=NULL)))
GO
ALTER TABLE [dbo].[productos] CHECK CONSTRAINT [CK_productos_medidas]
GO
ALTER TABLE [dbo].[productos]  WITH CHECK ADD  CONSTRAINT [CK_productos_precio] CHECK  (([precio]>(0)))
GO
ALTER TABLE [dbo].[productos] CHECK CONSTRAINT [CK_productos_precio]
GO
ALTER TABLE [dbo].[productos]  WITH CHECK ADD  CONSTRAINT [CK_productos_tipo] CHECK  (([tipo]>=(0) AND [tipo]<=(2)))
GO
ALTER TABLE [dbo].[productos] CHECK CONSTRAINT [CK_productos_tipo]
GO
ALTER TABLE [dbo].[productos]  WITH CHECK ADD  CONSTRAINT [CK_productos_uso] CHECK  (([uso]>=(0) AND [uso]<=(2)))
GO
ALTER TABLE [dbo].[productos] CHECK CONSTRAINT [CK_productos_uso]
GO
USE [master]
GO
ALTER DATABASE [FARMACIA_DB] SET  READ_WRITE 
GO
INSERT INTO [FARMACIA_DB].[dbo].[productos] ([descripcion],[precio],[tipo],[cc],[mg],[uso]) VALUES ('Cat Hair, Standardized', 2296.27, 0, NULL, 13, 2);
INSERT INTO [FARMACIA_DB].[dbo].[productos] ([descripcion],[precio],[tipo],[cc],[mg],[uso]) VALUES ('Jabon facial', 293.15, 2, NULL, NULL, NULL);
INSERT INTO [FARMACIA_DB].[dbo].[productos] ([descripcion],[precio],[tipo],[cc],[mg],[uso]) VALUES ('Jabon corporal', 809.57, 2, NULL, NULL, NULL);
INSERT INTO [FARMACIA_DB].[dbo].[productos] ([descripcion],[precio],[tipo],[cc],[mg],[uso]) VALUES ('Jabon abrasivo /exfoliante', 391.48, 2, NULL, NULL, NULL);
INSERT INTO [FARMACIA_DB].[dbo].[productos] ([descripcion],[precio],[tipo],[cc],[mg],[uso]) VALUES ('Jabon desodorante', 348.69, 2, NULL, NULL, NULL);
INSERT INTO [FARMACIA_DB].[dbo].[productos] ([descripcion],[precio],[tipo],[cc],[mg],[uso]) VALUES ('Jabon p/bebes y ninios', 1188.44, 2, NULL, NULL, NULL);
INSERT INTO [FARMACIA_DB].[dbo].[productos] ([descripcion],[precio],[tipo],[cc],[mg],[uso]) VALUES ('Jabon uso intimo', 1234.29, 2, NULL, NULL, NULL);
INSERT INTO [FARMACIA_DB].[dbo].[productos] ([descripcion],[precio],[tipo],[cc],[mg],[uso]) VALUES ('Jabon antibacterial', 1079.57, 2, NULL, NULL, NULL);
INSERT INTO [FARMACIA_DB].[dbo].[productos] ([descripcion],[precio],[tipo],[cc],[mg],[uso]) VALUES ('Shampoo', 627.72, 2, NULL, NULL, NULL);
INSERT INTO [FARMACIA_DB].[dbo].[productos] ([descripcion],[precio],[tipo],[cc],[mg],[uso]) VALUES ('Shampoo con acondicionador', 1006.82, 2, NULL, NULL, NULL);
INSERT INTO [FARMACIA_DB].[dbo].[productos] ([descripcion],[precio],[tipo],[cc],[mg],[uso]) VALUES ('Shampoo colorante', 735.87, 2, NULL, NULL, NULL);
INSERT INTO [FARMACIA_DB].[dbo].[productos] ([descripcion],[precio],[tipo],[cc],[mg],[uso]) VALUES ('Progesterone', 2941.52, 0, NULL, 7, 1);
INSERT INTO [FARMACIA_DB].[dbo].[productos] ([descripcion],[precio],[tipo],[cc],[mg],[uso]) VALUES ('SALICYLIC ACID', 2528.68, 0, NULL, 12, 1);
INSERT INTO [FARMACIA_DB].[dbo].[productos] ([descripcion],[precio],[tipo],[cc],[mg],[uso]) VALUES ('Citalopram', 1555.28, 0, NULL, 6, 2);
INSERT INTO [FARMACIA_DB].[dbo].[productos] ([descripcion],[precio],[tipo],[cc],[mg],[uso]) VALUES ('valsartan', 1204.79, 0, NULL, 5, 2);
INSERT INTO [FARMACIA_DB].[dbo].[productos] ([descripcion],[precio],[tipo],[cc],[mg],[uso]) VALUES ('HUMAN IMMUNOGLOBULIN G', 641.51, 0, NULL, 11, 0);
INSERT INTO [FARMACIA_DB].[dbo].[productos] ([descripcion],[precio],[tipo],[cc],[mg],[uso]) VALUES ('Calendula Officinalis', 1439.01, 0, NULL, 9, 2);
INSERT INTO [FARMACIA_DB].[dbo].[productos] ([descripcion],[precio],[tipo],[cc],[mg],[uso]) VALUES ('ceftriaxone', 2510.25, 0, NULL, 15, 1);
INSERT INTO [FARMACIA_DB].[dbo].[productos] ([descripcion],[precio],[tipo],[cc],[mg],[uso]) VALUES ('Clonidine Hydrochloride', 1044.17, 0, NULL, 6, 0);
INSERT INTO [FARMACIA_DB].[dbo].[productos] ([descripcion],[precio],[tipo],[cc],[mg],[uso]) VALUES ('LIDOCAINE', 2004.28, 0, NULL, 7, 1);
INSERT INTO [FARMACIA_DB].[dbo].[productos] ([descripcion],[precio],[tipo],[cc],[mg],[uso]) VALUES ('Echinacea', 1817.06, 0, NULL, 6, 1);
INSERT INTO [FARMACIA_DB].[dbo].[productos] ([descripcion],[precio],[tipo],[cc],[mg],[uso]) VALUES ('Sertraline Hydrochloride', 2937.22, 0, NULL, 12, 1);
INSERT INTO [FARMACIA_DB].[dbo].[productos] ([descripcion],[precio],[tipo],[cc],[mg],[uso]) VALUES ('azithromycin', 862.23, 1, 6, NULL, 0);
INSERT INTO [FARMACIA_DB].[dbo].[productos] ([descripcion],[precio],[tipo],[cc],[mg],[uso]) VALUES ('Standardized Senna Concentrate', 1031.61, 1, 9, NULL, 2);
INSERT INTO [FARMACIA_DB].[dbo].[productos] ([descripcion],[precio],[tipo],[cc],[mg],[uso]) VALUES ('Morphine Sulfate', 398.51, 1, 5, NULL, 1);
INSERT INTO [FARMACIA_DB].[dbo].[productos] ([descripcion],[precio],[tipo],[cc],[mg],[uso]) VALUES ('Pyridoxine Hydrochloride', 697.06, 1, 10, NULL, 1);
INSERT INTO [FARMACIA_DB].[dbo].[productos] ([descripcion],[precio],[tipo],[cc],[mg],[uso]) VALUES ('Acetaminophen and Diphenhydramine HCl', 905.09, 1, 15, NULL, 0);
INSERT INTO [FARMACIA_DB].[dbo].[productos] ([descripcion],[precio],[tipo],[cc],[mg],[uso]) VALUES ('ATORVASTATIN CALCIUM', 1159.38, 1, 9, NULL, 1);
INSERT INTO [FARMACIA_DB].[dbo].[productos] ([descripcion],[precio],[tipo],[cc],[mg],[uso]) VALUES ('zolpidem tartrate', 670.48, 1, 11, NULL, 2);
INSERT INTO [FARMACIA_DB].[dbo].[productos] ([descripcion],[precio],[tipo],[cc],[mg],[uso]) VALUES ('Divalproex Sodium', 389.03, 1, 10, NULL, 2);
INSERT INTO [FARMACIA_DB].[dbo].[productos] ([descripcion],[precio],[tipo],[cc],[mg],[uso]) VALUES ('Walnut California Black Pollen', 1416.46, 1, 14, NULL, 0);
INSERT INTO [FARMACIA_DB].[dbo].[productos] ([descripcion],[precio],[tipo],[cc],[mg],[uso]) VALUES ('Aluminum Chlorohydrate', 1242.17, 1, 8, NULL, 1);
GO

INSERT INTO [FARMACIA_DB].[dbo].[clientes] ([nombre],[apellido],[telefono],[dni],[debe]) VALUES ('Anakin', 'Skywalker', '165161516', 2301045, 0);
INSERT INTO [FARMACIA_DB].[dbo].[clientes] ([nombre],[apellido],[telefono],[dni],[debe]) VALUES ('Peter', 'Parker', '4781583080', 28818884, 0);
INSERT INTO [FARMACIA_DB].[dbo].[clientes] ([nombre],[apellido],[telefono],[dni],[debe]) VALUES ('Natasha', 'Romanoff', '6623469230', 29557358, 1469.5703);
INSERT INTO [FARMACIA_DB].[dbo].[clientes] ([nombre],[apellido],[telefono],[dni],[debe]) VALUES ('Loki', 'Odinson', '7758642509', 30234289, 0);
INSERT INTO [FARMACIA_DB].[dbo].[clientes] ([nombre],[apellido],[telefono],[dni],[debe]) VALUES ('The Migthy', 'Thor', '1132434159', 42587412, 0);
INSERT INTO [FARMACIA_DB].[dbo].[clientes] ([nombre],[apellido],[telefono],[dni],[debe]) VALUES ('Obi Wan', 'Kenobi', '12356987', 44578963, 0);
INSERT INTO [FARMACIA_DB].[dbo].[clientes] ([nombre],[apellido],[telefono],[dni],[debe]) VALUES ('Anthony', 'Stark', '6375125832', 45038419, 0);
INSERT INTO [FARMACIA_DB].[dbo].[clientes] ([nombre],[apellido],[telefono],[dni],[debe]) VALUES ('Clint', 'Barton', '9496175297', 45421268, 796.57007);
INSERT INTO [FARMACIA_DB].[dbo].[clientes] ([nombre],[apellido],[telefono],[dni],[debe]) VALUES ('Bruce', 'Banner', '9133370598', 49827708, 0);
INSERT INTO [FARMACIA_DB].[dbo].[clientes] ([nombre],[apellido],[telefono],[dni],[debe]) VALUES ('Qui Gon', 'Jinn', '918917891', 51951981, 0);
INSERT INTO [FARMACIA_DB].[dbo].[clientes] ([nombre],[apellido],[telefono],[dni],[debe]) VALUES ('Steve', 'Rogers', '5345408117', 58135220, 0);
INSERT INTO [FARMACIA_DB].[dbo].[clientes] ([nombre],[apellido],[telefono],[dni],[debe]) VALUES ('Stephen', 'Strange', '7363465932', 83150463, 0);
GO

INSERT INTO [FARMACIA_DB].[dbo].[ventas] ([precio],[senia],[dniCliente]) VALUES (4969.5703, 3500, 29557358);
INSERT INTO [FARMACIA_DB].[dbo].[ventas] ([precio],[senia],[dniCliente]) VALUES (8633.12, 8633.12, 45038419);
INSERT INTO [FARMACIA_DB].[dbo].[ventas] ([precio],[senia],[dniCliente]) VALUES (1296.5701, 500, 45421268);
GO

INSERT INTO [FARMACIA_DB].[dbo].[carrito] ([id_venta],[id_producto]) VALUES (1, 1);
INSERT INTO [FARMACIA_DB].[dbo].[carrito] ([id_venta],[id_producto]) VALUES (1, 17);
INSERT INTO [FARMACIA_DB].[dbo].[carrito] ([id_venta],[id_producto]) VALUES (1, 7);
INSERT INTO [FARMACIA_DB].[dbo].[carrito] ([id_venta],[id_producto]) VALUES (2, 2);
INSERT INTO [FARMACIA_DB].[dbo].[carrito] ([id_venta],[id_producto]) VALUES (2, 3);
INSERT INTO [FARMACIA_DB].[dbo].[carrito] ([id_venta],[id_producto]) VALUES (2, 4);
INSERT INTO [FARMACIA_DB].[dbo].[carrito] ([id_venta],[id_producto]) VALUES (2, 5);
INSERT INTO [FARMACIA_DB].[dbo].[carrito] ([id_venta],[id_producto]) VALUES (2, 6);
INSERT INTO [FARMACIA_DB].[dbo].[carrito] ([id_venta],[id_producto]) VALUES (2, 8);
INSERT INTO [FARMACIA_DB].[dbo].[carrito] ([id_venta],[id_producto]) VALUES (2, 9);
INSERT INTO [FARMACIA_DB].[dbo].[carrito] ([id_venta],[id_producto]) VALUES (2, 23);
INSERT INTO [FARMACIA_DB].[dbo].[carrito] ([id_venta],[id_producto]) VALUES (2, 24);
INSERT INTO [FARMACIA_DB].[dbo].[carrito] ([id_venta],[id_producto]) VALUES (2, 25);
INSERT INTO [FARMACIA_DB].[dbo].[carrito] ([id_venta],[id_producto]) VALUES (2, 26);
INSERT INTO [FARMACIA_DB].[dbo].[carrito] ([id_venta],[id_producto]) VALUES (2, 27);
INSERT INTO [FARMACIA_DB].[dbo].[carrito] ([id_venta],[id_producto]) VALUES (3, 4);
INSERT INTO [FARMACIA_DB].[dbo].[carrito] ([id_venta],[id_producto]) VALUES (3, 27);
INSERT INTO [FARMACIA_DB].[dbo].[carrito] ([id_venta],[id_producto]) VALUES (4, 14);
INSERT INTO [FARMACIA_DB].[dbo].[carrito] ([id_venta],[id_producto]) VALUES (4, 14);
INSERT INTO [FARMACIA_DB].[dbo].[carrito] ([id_venta],[id_producto]) VALUES (4, 14);
INSERT INTO [FARMACIA_DB].[dbo].[carrito] ([id_venta],[id_producto]) VALUES (5, 25);
INSERT INTO [FARMACIA_DB].[dbo].[carrito] ([id_venta],[id_producto]) VALUES (5, 6);
INSERT INTO [FARMACIA_DB].[dbo].[carrito] ([id_venta],[id_producto]) VALUES (5, 11);
INSERT INTO [FARMACIA_DB].[dbo].[carrito] ([id_venta],[id_producto]) VALUES (5, 10);
INSERT INTO [FARMACIA_DB].[dbo].[carrito] ([id_venta],[id_producto]) VALUES (5, 15);
INSERT INTO [FARMACIA_DB].[dbo].[carrito] ([id_venta],[id_producto]) VALUES (6, 16);
INSERT INTO [FARMACIA_DB].[dbo].[carrito] ([id_venta],[id_producto]) VALUES (6, 20);
INSERT INTO [FARMACIA_DB].[dbo].[carrito] ([id_venta],[id_producto]) VALUES (6, 21);
GO
