use master
go
create database [BanLinhKienMayTinh]
go
USE [BanLinhKienMayTinh]
GO
/****** Object:  Table [dbo].[About]    Script Date: 3/14/2022 5:21:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[About](
	[ID_About] [bigint] IDENTITY(1,1) NOT NULL,
	[Header] [ntext] NULL,
	[Image] [varchar](200) NULL,
	[Title_Body] [nvarchar](200) NULL,
	[Body] [ntext] NULL,
	[Title_Guarantee] [nvarchar](200) NULL,
	[Guarantee] [ntext] NULL,
 CONSTRAINT [PK_About] PRIMARY KEY CLUSTERED 
(
	[ID_About] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Category]    Script Date: 3/14/2022 5:21:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[ID_Category] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Metatitle] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Category] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 3/14/2022 5:21:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Contact](
	[ID_Contact] [bigint] IDENTITY(1,1) NOT NULL,
	[Phone] [varchar](12) NULL,
	[Email] [varchar](200) NULL,
	[Address] [nvarchar](200) NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[ID_Contact] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 3/14/2022 5:21:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Feedback](
	[ID_Feedback] [bigint] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](200) NULL,
	[Content] [ntext] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED 
(
	[ID_Feedback] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Login]    Script Date: 3/14/2022 5:21:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Login](
	[ID_Login] [bigint] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](100) NULL,
	[Password] [varchar](200) NULL,
	[ID_Role] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 3/14/2022 5:21:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[ID_OrderDetail] [bigint] IDENTITY(1,1) NOT NULL,
	[ID_Order] [bigint] NOT NULL,
	[Quantity] [int] NULL,
	[TotalPrice] [decimal](18, 0) NULL,
	[ID_Product] [bigint] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK__OrderDet__855D4EF54439E292] PRIMARY KEY CLUSTERED 
(
	[ID_OrderDetail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 3/14/2022 5:21:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Orders](
	[ID_Order] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Phone] [char](12) NULL,
	[Address] [nvarchar](500) NULL,
	[Status] [nvarchar](10) NULL,
	[CreateDate] [datetime] NULL,
	[Note] [ntext] NULL,
	[Email] [varchar](200) NULL,
 CONSTRAINT [PK__Orders__EC9FA955638D0AE2] PRIMARY KEY CLUSTERED 
(
	[ID_Order] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Product]    Script Date: 3/14/2022 5:21:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[ID_Product] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Price] [decimal](18, 0) NULL,
	[Description] [ntext] NULL,
	[Content] [ntext] NULL,
	[Avatar] [varchar](200) NULL,
	[Quantity] [int] NULL,
	[Color] [nvarchar](50) NULL,
	[Discount] [decimal](18, 0) NULL,
	[Metatitle] [varchar](100) NULL,
	[CreateDate] [datetime] NULL,
	[ID_Trademark] [bigint] NOT NULL,
	[ID_Promotion] [bigint] NULL,
 CONSTRAINT [PK__Product__522DE496F74B3569] PRIMARY KEY CLUSTERED 
(
	[ID_Product] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Promotion]    Script Date: 3/14/2022 5:21:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promotion](
	[ID_Promotion] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
 CONSTRAINT [PK__Promotio__ECECECBE60F6485A] PRIMARY KEY CLUSTERED 
(
	[ID_Promotion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Roles]    Script Date: 3/14/2022 5:21:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Roles](
	[ID_Role] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Role] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Trademark]    Script Date: 3/14/2022 5:21:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Trademark](
	[ID_Trademark] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Metatitle] [varchar](100) NULL,
	[ID_Category] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Trademark] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/14/2022 5:21:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[ID_User] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Address] [nvarchar](200) NULL,
	[Sex] [nchar](10) NULL,
	[Phone] [char](12) NULL,
	[email] [varchar](50) NULL,
	[ID_Login] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_User] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Category] ADD  DEFAULT (NULL) FOR [Name]
GO
ALTER TABLE [dbo].[Feedback] ADD  CONSTRAINT [DF_Contact_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Login] ADD  DEFAULT (NULL) FOR [Username]
GO
ALTER TABLE [dbo].[Login] ADD  DEFAULT (NULL) FOR [Password]
GO
ALTER TABLE [dbo].[OrderDetail] ADD  CONSTRAINT [DF__OrderDeta__Quant__2F10007B]  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[OrderDetail] ADD  CONSTRAINT [DF__OrderDeta__Total__300424B4]  DEFAULT ((0)) FOR [TotalPrice]
GO
ALTER TABLE [dbo].[OrderDetail] ADD  CONSTRAINT [DF_OrderDetail_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF__Orders__Name__276EDEB3]  DEFAULT (NULL) FOR [Name]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF__Orders__Phone__286302EC]  DEFAULT (NULL) FOR [Phone]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF__Orders__Address__29572725]  DEFAULT (NULL) FOR [Address]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF__Orders__Status__2A4B4B5E]  DEFAULT (NULL) FOR [Status]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF__Orders__Create_D__2B3F6F97]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF__Product__Name__173876EA]  DEFAULT (NULL) FOR [Name]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF__Product__Price__182C9B23]  DEFAULT ((0)) FOR [Price]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Promotion] ADD  CONSTRAINT [DF__Promotion__Name__34C8D9D1]  DEFAULT (NULL) FOR [Name]
GO
ALTER TABLE [dbo].[Promotion] ADD  CONSTRAINT [DF__Promotion__Start__35BCFE0A]  DEFAULT (getdate()) FOR [StartTime]
GO
ALTER TABLE [dbo].[Promotion] ADD  CONSTRAINT [DF__Promotion__EndTi__36B12243]  DEFAULT (getdate()) FOR [EndTime]
GO
ALTER TABLE [dbo].[Roles] ADD  DEFAULT (NULL) FOR [Name]
GO
ALTER TABLE [dbo].[Trademark] ADD  DEFAULT (NULL) FOR [Name]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (NULL) FOR [Name]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (NULL) FOR [Address]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (NULL) FOR [Sex]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (NULL) FOR [Phone]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (NULL) FOR [email]
GO
ALTER TABLE [dbo].[Login]  WITH CHECK ADD  CONSTRAINT [FK_Login_Role] FOREIGN KEY([ID_Role])
REFERENCES [dbo].[Roles] ([ID_Role])
GO
ALTER TABLE [dbo].[Login] CHECK CONSTRAINT [FK_Login_Role]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([ID_Order])
REFERENCES [dbo].[Orders] ([ID_Order])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Product] FOREIGN KEY([ID_Product])
REFERENCES [dbo].[Product] ([ID_Product])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Product]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([ID_Trademark])
REFERENCES [dbo].[Trademark] ([ID_Trademark])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Promotion] FOREIGN KEY([ID_Promotion])
REFERENCES [dbo].[Promotion] ([ID_Promotion])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Promotion]
GO
ALTER TABLE [dbo].[Trademark]  WITH CHECK ADD  CONSTRAINT [FK_Trademark_Category] FOREIGN KEY([ID_Category])
REFERENCES [dbo].[Category] ([ID_Category])
GO
ALTER TABLE [dbo].[Trademark] CHECK CONSTRAINT [FK_Trademark_Category]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_User_Login] FOREIGN KEY([ID_Login])
REFERENCES [dbo].[Login] ([ID_Login])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_User_Login]
GO
