USE [master]
GO
/****** Object:  Database [BeautySalon]    Script Date: 2018-12-27 21:07:48 ******/
CREATE DATABASE [BeautySalon] ON  PRIMARY 
( NAME = N'BeautySalon', FILENAME = N'E:\项目数据库\美容院管理系统\BeautySalon.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BeautySalon_log', FILENAME = N'E:\项目数据库\美容院管理系统\BeautySalon_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BeautySalon].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BeautySalon] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BeautySalon] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BeautySalon] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BeautySalon] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BeautySalon] SET ARITHABORT OFF 
GO
ALTER DATABASE [BeautySalon] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BeautySalon] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [BeautySalon] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BeautySalon] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BeautySalon] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BeautySalon] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BeautySalon] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BeautySalon] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BeautySalon] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BeautySalon] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BeautySalon] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BeautySalon] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BeautySalon] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BeautySalon] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BeautySalon] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BeautySalon] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BeautySalon] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BeautySalon] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BeautySalon] SET RECOVERY FULL 
GO
ALTER DATABASE [BeautySalon] SET  MULTI_USER 
GO
ALTER DATABASE [BeautySalon] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BeautySalon] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BeautySalon', N'ON'
GO
USE [BeautySalon]
GO
/****** Object:  Table [dbo].[BS_Admin]    Script Date: 2018-12-27 21:07:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BS_Admin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AdminName] [varchar](50) NULL,
	[AdminPassword] [varchar](20) NULL,
	[LoginCount] [varchar](20) NULL,
	[LastTime] [datetime] NOT NULL,
	[Lock] [varchar](1) NULL,
	[Power] [varchar](20) NULL,
 CONSTRAINT [PK_BS_Admin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BS_Appointment]    Script Date: 2018-12-27 21:07:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BS_Appointment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ServiceId] [int] NULL,
	[UserId] [int] NULL,
	[Time] [datetime] NULL,
	[TimeSlot] [varchar](50) NULL,
	[AddTime] [datetime] NULL,
	[Tel] [varchar](50) NULL,
	[State] [varchar](10) NULL,
 CONSTRAINT [PK_BS_Appointment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BS_Contact]    Script Date: 2018-12-27 21:07:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BS_Contact](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[Message] [varchar](250) NULL,
	[Reply] [varchar](50) NULL,
	[AddTime] [datetime] NULL,
	[ReplyTime] [datetime] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_BS_Contact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BS_Goods]    Script Date: 2018-12-27 21:07:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BS_Goods](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GoodsName] [varchar](50) NULL,
	[GoodsType] [nchar](10) NULL,
	[GoodsPic] [varchar](50) NULL,
	[GoodsPrice] [varchar](50) NULL,
	[Detail] [varchar](500) NULL,
	[AddTime] [datetime] NULL,
	[Blank] [varchar](50) NULL,
 CONSTRAINT [PK_BS_Goods] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BS_GoodsCar]    Script Date: 2018-12-27 21:07:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BS_GoodsCar](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GoodsId] [int] NULL,
	[UserId] [int] NULL,
	[SeqNo] [int] NULL,
	[AddTime] [datetime] NULL,
 CONSTRAINT [PK_BS_GoodsCar] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BS_Order]    Script Date: 2018-12-27 21:07:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BS_Order](
	[Id] [varchar](50) NOT NULL,
	[UserId] [int] NULL,
	[PayType] [varchar](50) NULL,
	[Money] [varchar](50) NULL,
	[OperTime] [datetime] NULL,
	[Tel] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[State] [varchar](10) NULL,
 CONSTRAINT [PK_BS_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BS_OrderDetail]    Script Date: 2018-12-27 21:07:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BS_OrderDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GoodsId] [int] NULL,
	[OrderId] [varchar](50) NULL,
	[AddTime] [datetime] NULL,
	[Num] [int] NULL,
	[Detail] [varchar](250) NULL,
 CONSTRAINT [PK_BS_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BS_Service]    Script Date: 2018-12-27 21:07:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BS_Service](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NULL,
	[Price] [varchar](50) NULL,
	[Detail] [varchar](500) NULL,
	[ServerPic] [varchar](50) NULL,
	[AddTime] [datetime] NULL,
 CONSTRAINT [PK_BS_Service] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BS_UserInfo]    Script Date: 2018-12-27 21:07:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BS_UserInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[RealName] [varchar](20) NULL,
	[Sex] [varchar](2) NULL,
	[Age] [varchar](3) NULL,
	[Email] [varchar](30) NULL,
	[Tel] [varchar](20) NULL,
	[Level] [varchar](2) NULL,
	[regTime] [datetime] NOT NULL,
	[Lock] [varchar](1) NULL,
	[Money] [varchar](20) NULL,
 CONSTRAINT [PK_BS_UserInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[BS_Admin] ON 

INSERT [dbo].[BS_Admin] ([Id], [AdminName], [AdminPassword], [LoginCount], [LastTime], [Lock], [Power]) VALUES (2, N'Admin', N'123456', N'9', CAST(0x0000A99F00F77DE0 AS DateTime), N'0', NULL)
INSERT [dbo].[BS_Admin] ([Id], [AdminName], [AdminPassword], [LoginCount], [LastTime], [Lock], [Power]) VALUES (4, N'xiaoming', N'123456', N'0', CAST(0x0000A98B00000000 AS DateTime), N'0', NULL)
INSERT [dbo].[BS_Admin] ([Id], [AdminName], [AdminPassword], [LoginCount], [LastTime], [Lock], [Power]) VALUES (6, N'xiaoxue', N'123456', N'0', CAST(0x0000A98B00000000 AS DateTime), N'0', NULL)
INSERT [dbo].[BS_Admin] ([Id], [AdminName], [AdminPassword], [LoginCount], [LastTime], [Lock], [Power]) VALUES (7, N'huajian', N'123456', N'0', CAST(0x0000A98B00000000 AS DateTime), N'0', NULL)
INSERT [dbo].[BS_Admin] ([Id], [AdminName], [AdminPassword], [LoginCount], [LastTime], [Lock], [Power]) VALUES (9, N'xiaowang', N'123456', N'0', CAST(0x0000A98B00000000 AS DateTime), N'0', NULL)
INSERT [dbo].[BS_Admin] ([Id], [AdminName], [AdminPassword], [LoginCount], [LastTime], [Lock], [Power]) VALUES (11, N'xiaodong', N'123456', N'0', CAST(0x0000A98B00000000 AS DateTime), N'0', NULL)
INSERT [dbo].[BS_Admin] ([Id], [AdminName], [AdminPassword], [LoginCount], [LastTime], [Lock], [Power]) VALUES (12, N'xiaojian', N'123456', N'0', CAST(0x0000A98B00000000 AS DateTime), N'0', NULL)
INSERT [dbo].[BS_Admin] ([Id], [AdminName], [AdminPassword], [LoginCount], [LastTime], [Lock], [Power]) VALUES (13, N'xiaobang', N'123456', N'0', CAST(0x0000A98B00000000 AS DateTime), N'0', NULL)
INSERT [dbo].[BS_Admin] ([Id], [AdminName], [AdminPassword], [LoginCount], [LastTime], [Lock], [Power]) VALUES (17, N'xiaodun', N'123456', N'0', CAST(0x0000A98B0120B64E AS DateTime), N'0', NULL)
INSERT [dbo].[BS_Admin] ([Id], [AdminName], [AdminPassword], [LoginCount], [LastTime], [Lock], [Power]) VALUES (18, N'xiaobin', N'123456', N'0', CAST(0x0000A98B0120D6F9 AS DateTime), N'0', NULL)
INSERT [dbo].[BS_Admin] ([Id], [AdminName], [AdminPassword], [LoginCount], [LastTime], [Lock], [Power]) VALUES (19, N'xiaos', N'123456', N'0', CAST(0x0000A98B0121075E AS DateTime), N'0', NULL)
INSERT [dbo].[BS_Admin] ([Id], [AdminName], [AdminPassword], [LoginCount], [LastTime], [Lock], [Power]) VALUES (20, N'xiaojie', N'123456', N'0', CAST(0x0000A98B0121C547 AS DateTime), N'0', NULL)
INSERT [dbo].[BS_Admin] ([Id], [AdminName], [AdminPassword], [LoginCount], [LastTime], [Lock], [Power]) VALUES (24, N'xiaoxue', N'123456', N'0', CAST(0x0000A98C00A63207 AS DateTime), N'0', N'1')
SET IDENTITY_INSERT [dbo].[BS_Admin] OFF
SET IDENTITY_INSERT [dbo].[BS_Appointment] ON 

INSERT [dbo].[BS_Appointment] ([Id], [ServiceId], [UserId], [Time], [TimeSlot], [AddTime], [Tel], [State]) VALUES (10, 3, 4, CAST(0x0000A99D00000000 AS DateTime), N'10:00~11:00', CAST(0x0000A99C00045CF0 AS DateTime), N'15260966227', N'已完成')
INSERT [dbo].[BS_Appointment] ([Id], [ServiceId], [UserId], [Time], [TimeSlot], [AddTime], [Tel], [State]) VALUES (11, 2, 4, CAST(0x0000A99F00000000 AS DateTime), N'10:00~11:00', CAST(0x0000A99C00046B50 AS DateTime), N'15260966227', N'已取消')
INSERT [dbo].[BS_Appointment] ([Id], [ServiceId], [UserId], [Time], [TimeSlot], [AddTime], [Tel], [State]) VALUES (12, 1, 4, CAST(0x0000A9A800000000 AS DateTime), N'10:00~11:00', CAST(0x0000A99C000471A9 AS DateTime), N'15260966227', N'已取消')
SET IDENTITY_INSERT [dbo].[BS_Appointment] OFF
SET IDENTITY_INSERT [dbo].[BS_Goods] ON 

INSERT [dbo].[BS_Goods] ([Id], [GoodsName], [GoodsType], [GoodsPic], [GoodsPrice], [Detail], [AddTime], [Blank]) VALUES (1006, N'亮润美白精华', N'护肤品       ', N'/File/63677963759983.png', N'500', N'保质期: 3年
功效: 美白 补水 保湿 提亮肤色 滋润
优点：经过一段时间的使用，自我感觉皮肤水润嫩白了很多，尤其现在这个季节，北方风大，皮肤总容易敏感，而这个套装解决了补水问题，吸收好，脸也不会油腻。上妆更容易了。', CAST(0x0000A99A00B9AA14 AS DateTime), N'Franic/法兰琳卡')
INSERT [dbo].[BS_Goods] ([Id], [GoodsName], [GoodsType], [GoodsPic], [GoodsPrice], [Detail], [AddTime], [Blank]) VALUES (1007, N'MINON蜜浓氨基酸面膜', N'护肤品       ', N'/File/63677963969757.png', N'350', N'保质期: 3年
功效: 补水 保湿 滋润 舒缓肌肤', CAST(0x0000A99A00BAA10F AS DateTime), N'MINON/蜜浓')
INSERT [dbo].[BS_Goods] ([Id], [GoodsName], [GoodsType], [GoodsPic], [GoodsPrice], [Detail], [AddTime], [Blank]) VALUES (1008, N'自然堂水润洗面奶', N'护肤品       ', N'/File/63677964203130.png', N'55', N'适用肤质：干性干到中性中性中到油性油性任何肌肤混合性肌肤 使用方法：取适量（约2cm）于掌心，加水揉出泡沫后，再涂于面部轻揉，仔细清洁后以清水冲洗干净。', CAST(0x0000A99A00BBB28B AS DateTime), N'CHANDO/自然堂')
INSERT [dbo].[BS_Goods] ([Id], [GoodsName], [GoodsType], [GoodsPic], [GoodsPrice], [Detail], [AddTime], [Blank]) VALUES (1009, N'雅诗兰黛小棕瓶', N'护肤品       ', N'/File/63677965293869.png', N'1200', N'雅诗兰黛小棕瓶 一滴滋润,感受肌肤柔嫩弹滑;每天醒来,毛孔变小了,细纹变淡了!肌肤好的透出光,一整天细腻保湿,匀亮弹润!', CAST(0x0000A99A00C0B0C1 AS DateTime), N'Estee Lauder/雅诗兰黛')
INSERT [dbo].[BS_Goods] ([Id], [GoodsName], [GoodsType], [GoodsPic], [GoodsPrice], [Detail], [AddTime], [Blank]) VALUES (1010, N'细胞博士护肤面霜', N'护肤品       ', N'/File/63677965432175.png', N'453', N'Dr.Cell/细胞博士', CAST(0x0000A99A00C152D5 AS DateTime), N'Dr.Cell/细胞博士')
INSERT [dbo].[BS_Goods] ([Id], [GoodsName], [GoodsType], [GoodsPic], [GoodsPrice], [Detail], [AddTime], [Blank]) VALUES (1011, N'芬妮遮瑕', N'护肤品       ', N'/File/63677965466687.png', N'569', N'补水 保湿 提拉紧致 提亮肤色 嫩肤', CAST(0x0000A99A00C17B46 AS DateTime), N' Funi/芬妮')
INSERT [dbo].[BS_Goods] ([Id], [GoodsName], [GoodsType], [GoodsPic], [GoodsPrice], [Detail], [AddTime], [Blank]) VALUES (1012, N'滋润爽肤水', N'护肤品       ', N'/File/63677965538063.png', N'198', N'美加净雪耳珍珠水光焕采
功效: 保湿 滋润
保质期: 3年', CAST(0x0000A99A00C1CEEB AS DateTime), N'maxam/美加净')
SET IDENTITY_INSERT [dbo].[BS_Goods] OFF
INSERT [dbo].[BS_Order] ([Id], [UserId], [PayType], [Money], [OperTime], [Tel], [Address], [State]) VALUES (N'5458097863534596546', 4, N'余额支付', N'198', CAST(0x0000A99C00F11777 AS DateTime), N'15260966227', N'闽侯工程学院', N'未发货')
SET IDENTITY_INSERT [dbo].[BS_OrderDetail] ON 

INSERT [dbo].[BS_OrderDetail] ([Id], [GoodsId], [OrderId], [AddTime], [Num], [Detail]) VALUES (6, 1012, N'5458097863534596546', CAST(0x0000A99C00EFBBE3 AS DateTime), 1, N'已退货')
SET IDENTITY_INSERT [dbo].[BS_OrderDetail] OFF
SET IDENTITY_INSERT [dbo].[BS_Service] ON 

INSERT [dbo].[BS_Service] ([Id], [Title], [Price], [Detail], [ServerPic], [AddTime]) VALUES (1, N'泰式按摩', N'138', N'泰式古法按摩，除了大家熟悉的关节纾整外，更有自成一套的经脉、穴位按压及伸展理论。利用手指、手臂、膝部和双腿等按摩对方穴位，又在肌肉和关节上按压和伸展，令身体、精神和心灵回复平衡，促进血液循环、呼吸系统、神经系统、消化系统运作正常和肌肉皮肤新陈代谢。定期进行，令人体精神和肉体保持最佳状态。泰式按摩是古代泰王招待皇家贵宾的最高礼节。', N'/File/63678073815911.jpg', CAST(0x0000A99B0125F505 AS DateTime))
INSERT [dbo].[BS_Service] ([Id], [Title], [Price], [Detail], [ServerPic], [AddTime]) VALUES (2, N'脸部Spa', N'158', N'水疗属于物理疗法的一类。用各种不同温度、压力、成分的水，以不同形式和方法（浸、冲、擦、淋洗）作用于人体全身或局部进行预防和治疗疾病的方法。 水的比热和热容量均很大，携带热能较易。其传热的方式有传导和对流两种。水除传热作用外，并有机械作用，如浮力、压力和水流、水射流的冲击作用。水又可溶解各种物质、药物，这些溶质也可起治疗作用。', N'/File/63678073900022.jpg', CAST(0x0000A99B01265797 AS DateTime))
INSERT [dbo].[BS_Service] ([Id], [Title], [Price], [Detail], [ServerPic], [AddTime]) VALUES (3, N'汗蒸', N'98', N'汗蒸是一种休闲项目，是热疗的一种，历史悠久，深受民众喜爱，是韩国的一大特色。韩式汗蒸是将黄泥和各种石头加温，人或坐或躺，用于驱风、袪寒、暖体活血、温肤靓颜，古代只是贵族或皇室的特权享受，文化渊源深厚。随着韩国文化的流行，汗蒸也紧随韩剧，服装，化妆，美容技术一起进入中国并且在短短的几年时间内迅速地被中国人所认可和接受，并且逐渐成为一种人们所热衷和追捧的休闲保健方式。', N'/File/63678073982303.jpg', CAST(0x0000A99B0126B803 AS DateTime))
INSERT [dbo].[BS_Service] ([Id], [Title], [Price], [Detail], [ServerPic], [AddTime]) VALUES (4, N'中医推拿', N'119', N'推拿按摩经济简便，因为它不需要特殊医疗设备，也不受时间地点气候条件的限制，随时随地都可实行；且平稳可靠，易学易用，无任何副作用。正由于这些优点，按摩成为深受广大群众喜爱的养生健身措施。对正常人来说，能增强人体的自然抗病能力，取得保健效果；对病人来说，既可使局部症状消退，又可加速恢复患部的功能，从而收到良好的治疗效果。', N'/File/63678097160809.jpg', CAST(0x0000A99C00055052 AS DateTime))
SET IDENTITY_INSERT [dbo].[BS_Service] OFF
SET IDENTITY_INSERT [dbo].[BS_UserInfo] ON 

INSERT [dbo].[BS_UserInfo] ([Id], [UserName], [Password], [RealName], [Sex], [Age], [Email], [Tel], [Level], [regTime], [Lock], [Money]) VALUES (4, N'sunshineboy', N'123456', N'姜华健', N'男', N'49', N'651499253@qq.com', N'15260966227', N'1', CAST(0x0000A99700EF3311 AS DateTime), N'0', N'1281')
SET IDENTITY_INSERT [dbo].[BS_UserInfo] OFF
ALTER TABLE [dbo].[BS_Appointment]  WITH CHECK ADD  CONSTRAINT [FK_BS_Appointment_BS_Service] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[BS_Service] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BS_Appointment] CHECK CONSTRAINT [FK_BS_Appointment_BS_Service]
GO
ALTER TABLE [dbo].[BS_Appointment]  WITH CHECK ADD  CONSTRAINT [FK_BS_Appointment_BS_UserInfo] FOREIGN KEY([UserId])
REFERENCES [dbo].[BS_UserInfo] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BS_Appointment] CHECK CONSTRAINT [FK_BS_Appointment_BS_UserInfo]
GO
ALTER TABLE [dbo].[BS_GoodsCar]  WITH CHECK ADD  CONSTRAINT [FK_BS_GoodsCar_BS_Goods] FOREIGN KEY([GoodsId])
REFERENCES [dbo].[BS_Goods] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BS_GoodsCar] CHECK CONSTRAINT [FK_BS_GoodsCar_BS_Goods]
GO
ALTER TABLE [dbo].[BS_Order]  WITH CHECK ADD  CONSTRAINT [FK_BS_Order_BS_UserInfo] FOREIGN KEY([UserId])
REFERENCES [dbo].[BS_UserInfo] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BS_Order] CHECK CONSTRAINT [FK_BS_Order_BS_UserInfo]
GO
ALTER TABLE [dbo].[BS_OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_BS_OrderDetail_BS_Goods] FOREIGN KEY([GoodsId])
REFERENCES [dbo].[BS_Goods] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BS_OrderDetail] CHECK CONSTRAINT [FK_BS_OrderDetail_BS_Goods]
GO
ALTER TABLE [dbo].[BS_OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_BS_OrderDetail_BS_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[BS_Order] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BS_OrderDetail] CHECK CONSTRAINT [FK_BS_OrderDetail_BS_Order]
GO
USE [master]
GO
ALTER DATABASE [BeautySalon] SET  READ_WRITE 
GO
